using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ApiBetaClientes.Class
{
    public class ApiConnectionDB
    {

        /// <summary>
        /// Variables para la conexión ConnectionDB la base de datos
        /// </summary>
        public SqlConnection m_scConnection = null;
        public string m_strConnection;
        public CommandType m_eType;



        /// <summary>
        /// Constructor de la clase ApiConnectionDB.
        /// </summary>
        /// <param name="ConnectionString">Cadena de conexión requerida para establecer la conexión con la base de datos.</param>
        /// <param name="Type">Tipo de comando que indica si la consulta será de tipo texto o de un procedimiento almacenado.</param>
        public ApiConnectionDB(string ConnectionString, CommandType Type)
        {
            m_strConnection = ConnectionString;
            m_eType = Type;
        }



        /// <summary>
        /// Método para abrir la conexión con la base de datos.
        /// </summary>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error al abrir la conexión.</exception>
        public void OpenConnection()
        {
            try
            {
                if (m_scConnection == null)
                {
                    m_scConnection = new SqlConnection(m_strConnection);
                }
                if (m_scConnection.State != ConnectionState.Open)
                {
                    m_scConnection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión.", ex);
            }
        }



        /// <summary>
        /// Método para llenar una tabla de datos con el resultado de un procedimiento almacenado.
        /// </summary>
        /// <param name="nombreSP">Nombre del procedimiento almacenado a ejecutar.</param>
        /// <param name="parametros">Arreglo de parámetros para el procedimiento almacenado.</param>
        /// <returns>Retorna DataTable con los resultados del procedimiento almacenado.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error al ejecutar el procedimiento almacenado.</exception>
        public DataTable Fill_Tabla(string nombreSP, SqlParameter[] parametros)
        {
            DataTable tablaDatos = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(m_strConnection))
                {
                    using (SqlCommand comando = new SqlCommand(nombreSP, conexion))
                    {
                        comando.CommandType = m_eType;
                        comando.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ProcedureTimeout"]);

                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(tablaDatos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar la tabla con el procedimiento almacenado.", ex);
            }

            return tablaDatos;
        }



        /// <summary>
        /// Método para ejecutar un procedimiento almacenado que guarda datos en la base de datos.
        /// </summary>
        /// <param name="nombreSP">Nombre del procedimiento almacenado a ejecutar.</param>
        /// <param name="parametros">Arreglo de parámetros para el procedimiento almacenado.</param>
        /// <returns>True si los datos se guardaron correctamente; de lo contrario, false.</returns>
        public bool GuardarDatosBD(string nombreSP, SqlParameter[] parametros)
        {
            bool procesado = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(m_strConnection))
                {
                    using (SqlCommand comando = new SqlCommand(nombreSP, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ProcedureTimeout"]);

                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros);
                        }

                        conexion.Open();
                        comando.ExecuteNonQuery();
                        procesado = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Puedes registrar o manejar la excepción según sea necesario
                Console.WriteLine("Error al guardar datos en la base de datos: " + ex.Message);
            }

            return procesado;
        }



        /// <summary>
        /// Ejecuta un procedimiento almacenado que devuelve un valor escalar.
        /// </summary>
        /// <param name="nombreSP">Nombre del procedimiento almacenado a ejecutar.</param>
        /// <param name="params">Arreglo de parámetros para el procedimiento almacenado.</param>
        /// <param name="paramOut">Nombre del parámetro de salida que contiene el valor escalar.</param>
        /// <returns>El valor escalar obtenido del procedimiento almacenado.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la ejecución del procedimiento almacenado.</exception>
        public int ObtenerRegistroSP(string nombreSP, SqlParameter[] @params, string paramOut)
        {
            try
            {
                OpenConnection();

                using (SqlCommand _Command = new SqlCommand(nombreSP, m_scConnection))
                {
                    _Command.CommandType = CommandType.StoredProcedure;
                    _Command.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ProcedureTimeout"]);

                    foreach (SqlParameter parameter in @params)
                    {
                        _Command.Parameters.Add(parameter);
                    }

                    _Command.ExecuteNonQuery();

                    CloseConnection();

                    return _Command.Parameters[paramOut].Value == null ? 0 : Convert.ToInt32(_Command.Parameters[paramOut].Value);

                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                return 0;
            }
        }



        /// <summary>
        /// Ejecuta un procedimiento almacenado sin parametros que no devuelve ningún resultado.
        /// </summary>
        /// <param name="nombreSP">Nombre del procedimiento almacenado a ejecutar.</param>
        /// <returns>True si la ejecución del procedimiento almacenado fue exitosa; de lo contrario, false.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la ejecución del procedimiento almacenado.</exception>
        public bool EjecutarSP(string nombreSP)
        {
            bool completo = false;

            try
            {
                using (SqlCommand _Command = new SqlCommand(nombreSP, m_scConnection))
                {
                    _Command.CommandType = m_eType;
                    _Command.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ProcedureTimeout"]);

                    _Command.ExecuteNonQuery();
                    completo = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                throw new Exception("Error al ejecutar el procedimiento almacenado.", ex);
            }
            finally
            {
                CloseConnection();
            }

            return completo;
        }




        /// <summary>
        /// Ejecuta un procedimiento almacenado que devuelve un SqlDataReader con los resultados.
        /// </summary>
        /// <param name="nombreSP">Nombre del procedimiento almacenado a ejecutar.</param>
        /// <param name="params">Arreglo de parámetros para el procedimiento almacenado.</param>
        /// <returns>SqlDataReader con los resultados de la consulta.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la ejecución del procedimiento almacenado.</exception>
        public SqlDataReader drConsultarDatos(string nombreSP, SqlParameter[] @params)
        {
            try
            {
                using (SqlCommand _Command = new SqlCommand(nombreSP, m_scConnection))
                {
                    _Command.CommandType = m_eType;
                    _Command.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ProcedureTimeout"]);

                    if (@params != null)
                    {
                        foreach (SqlParameter parametro in @params)
                        {
                            _Command.Parameters.Add(parametro);
                        }
                    }

                    m_scConnection.Open();
                    SqlDataReader dr = _Command.ExecuteReader(CommandBehavior.CloseConnection);
                    return dr;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el procedimiento almacenado.", ex);
            }
        }




        /// <summary>
        /// Libera los recursos no administrados utilizados por la conexión con la base de datos.
        /// </summary>
        public void Dispose()
        {
            if (m_scConnection != null)
            {
                m_scConnection.Dispose();
                m_scConnection = null;
            }
        }



        /// <summary>
        /// Método para cerrar la conexión con la base de datos.
        /// </summary>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error al intentar cerrar la conexión.</exception>
        public void CloseConnection()
        {
            try
            {
                if (m_scConnection != null && m_scConnection.State != ConnectionState.Closed)
                {
                    m_scConnection.Close();
                }
            }
            catch (Exception ex)
            {
                // Puedes manejar la excepción según sea necesario, por ejemplo, registrándola o relanzándola
                throw new Exception("Error al cerrar la conexión.", ex);
            }
        }



        /// <summary>
        /// Método para ejecutar una consulta con parámetros y devolver un DataSet.
        /// </summary>
        /// <param name="strQuery">Consulta SQL o nombre del procedimiento almacenado a ejecutar.</param>
        /// <param name="arrParametros">Arreglo de parámetros para la consulta.</param>
        /// <returns>Un DataSet que contiene los resultados de la consulta.</returns>
        /// <exception cref="Exception">Se lanza una excepción si ocurre un error durante la ejecución de la consulta.</exception>
        public DataSet ParametrosDS(string strQuery, SqlParameter[] arrParametros)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["NombreConexion"].ConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand(strQuery, conexion))
                    {
                        conexion.Open();

                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ProcedureTimeout"]);

                        if (arrParametros != null)
                        {
                            foreach (SqlParameter parametro in arrParametros)
                            {
                                comando.Parameters.Add(parametro);
                            }
                        }

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta con parámetros.", ex);
            }

            return ds;
        }




    }
}