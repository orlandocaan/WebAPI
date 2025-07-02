using ApiBetaClientes.Class;
using ApiBetaClientes.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiBetaClientes.Repository
{
    public class Login_Mod
    {
        private readonly ApiConnectionDB connectionDB = new ApiConnectionDB(clsConnStrSQL.CnnStrSQLApiBetaClientes, CommandType.StoredProcedure);
        private readonly BitacoraErrores_Mod objBitacora  = new BitacoraErrores_Mod();


        /// <summary>
        /// Metodo para validar las credenciales de inicio de sesion
        /// </summary>
        /// <param name="accion">accion a ejecutar en el SP</param>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns>Nos retorna un DataTable</returns>
       public DataTable ValidarCredencialesLogin(int accion, string username, string password)
        {
            DataTable dt;
            try
            {

                SqlParameter[] param = 
                {
                    new SqlParameter("@Accion"  , DbType.Int32 )  { Value = accion,   Direction = ParameterDirection.Input},
                    new SqlParameter("@UserName", DbType.String)  { Value = username, Direction = ParameterDirection.Input},
                    new SqlParameter("@Password", DbType.String)  { Value = password, Direction = ParameterDirection.Input},
                };
                dt = connectionDB.Fill_Tabla("SP_ValidarInicioSesion", param);
            }
            catch (SqlException ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/Login_Mod", "0", "ValidarCredencialesLogin", "Login_Mod");
                throw (ex);
            }
            finally
            {
                connectionDB.CloseConnection();
            }
            return dt;
        }




    }
}