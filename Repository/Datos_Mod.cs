using Antlr.Runtime.Misc;
using ApiBetaClientes.Class;
using BetaClientesVM.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Security;
using System.Xml.Linq;

namespace ApiBetaClientes.Repository
{
    public class Datos_Mod
    {

        private readonly ApiConnectionDB connectionDB = new ApiConnectionDB(clsConnStrSQL.CnnStrSQLApiBetaClientes, CommandType.StoredProcedure);
        BitacoraErrores_Mod objBitacora = new BitacoraErrores_Mod();



        /// <summary>
        /// Método para consultar la información correspondiente al menú dinámico
        /// </summary>
        /// <param name="accion">Numero de acción a ejecutar</param>
        /// <param name="idUsuario">Id del usuario ConectionDB sesión iniciada</param>
        /// <param name="roleCode">Rol del usuario</param>
        /// <param name="language">Lenguaje a desplegar en el sistema</param>
        /// <returns>Nos retorna un dtatable ConectionDB la informacion que el usuario puede visualizar</returns>
        public DataTable DTMenuDinamico(int accion, int idUsuario, int roleCode, string language)
        {
            DataTable dt;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Accion"    , DbType.Int32)  { Value = accion    , Direction = ParameterDirection.Input },
                    new SqlParameter("@Language"  , DbType.String) { Value = language  , Direction = ParameterDirection.Input },
                    new SqlParameter("@Role"      , DbType.Int32)  { Value = roleCode  , Direction = ParameterDirection.Input },
					new SqlParameter("@IdUsuario" , DbType.Int32)  { Value = idUsuario , Direction = ParameterDirection.Input }
				};
                dt = connectionDB.Fill_Tabla("SP_Menu", param);
            }
            catch (SqlException ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/Login_Mod/DTMenuDinamico()", "0", "dtMenuDinamico", "Login_Mod");
                return null;
            }
            finally
            {
                connectionDB.CloseConnection();
            }
            return dt;
        }


        /// <summary>
        /// Método para administrar los usuarios del sistema
        /// </summary>
        /// <param name="Accion">Numero de acción a ejecutar</param>
        /// <param name="UserId">Id del usuario</param>
        /// <param name="UserName">Nombre de usuario</param>
        /// <param name="Password">Contraseña encriptada</param>
        /// <param name="Name">Nombre del usuario</param>
        /// <param name="LastName">Apellido(s)</param>
        /// <param name="Email">Correo electrónico</param>
        /// <param name="Enabled">Estatus del usuario</param>
        /// <param name="Img">Imagen del perfil</param>
        /// <param name="FirstLogin">Primer Login (Forzar cambio de contraseña)</param>
        /// <param name="RoleId">Id del rol del usuario</param>
        /// <returns>Nos retorna mayor o igual a 1 si solicitud es correcta, 0 si ocurre un error</returns>
        public int AdministrarUsuarios(int Accion, int UserId, string UserName, string Password, string Name, string LastName, string Email, bool Enabled, byte[] Img, bool FirstLogin, int RoleId)
        {
            int resultado = 0;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Accion", DbType.Int32) { Value = Accion, Direction = ParameterDirection.Input},
                    new SqlParameter("@UserId", DbType.Int32) { Value = UserId, Direction = ParameterDirection.Input},
                    new SqlParameter("@UserName", DbType.String) { Value = UserName, Direction = ParameterDirection.Input},
                    new SqlParameter("@Password", DbType.String) { Value = Password, Direction = ParameterDirection.Input},
                    new SqlParameter("@Name", DbType.String) { Value = Name, Direction = ParameterDirection.Input},
                    new SqlParameter("@LastName", DbType.String) { Value = LastName, Direction = ParameterDirection.Input},
                    new SqlParameter("@Email", DbType.String) { Value = Email, Direction = ParameterDirection.Input},
                    new SqlParameter("@Enabled", DbType.Boolean) { Value = Enabled, Direction = ParameterDirection.Input},
                    new SqlParameter("@Img", DbType.String) { Value = Img, Direction = ParameterDirection.Input},
                    new SqlParameter("@FirstLogin", DbType.Boolean) { Value = FirstLogin, Direction = ParameterDirection.Input},
                    new SqlParameter("@RoleId", DbType.Int32) { Value = RoleId, Direction = ParameterDirection.Input},
                    new SqlParameter("@Resultado", DbType.Int32) { Direction = ParameterDirection.Output},
                };
                resultado = connectionDB.ObtenerRegistroSP("SP_Users", param, "@Resultado");
            }
            catch (SqlException ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/Login_Mod/AdministrarUsuarios", "0", "ValidarCredencialesLogin", "Login_Mod");
                return 0;
            }
            finally
            {
                connectionDB.CloseConnection();
            }
            return resultado;
        }


        /// <summary>
        /// Método que nos permitira realizar las consultas sobre SP_Catalogos
        /// </summary>
        /// <param name="objCatalogos">Objeto de datos de CatalogosVM</param>
        /// <returns>Nos retorna un DataTable</returns>
        public DataTable DTConsultaCatalogos(CatalogosVM objCatalogos)
        {
            DataTable dt;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Accion", DbType.Int32) { Value = objCatalogos.Accion, Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_IdCatalogo", DbType.Int32) { Value = objCatalogos.Catt_IdCatalogo , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_Nombre", DbType.String) { Value = objCatalogos.Catt_Nombre , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_Actualizable", DbType.Boolean) { Value = objCatalogos.Catt_Actualizable , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_Activo", DbType.Boolean) { Value = objCatalogos.Catt_Activo , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_UsuarioCrea", DbType.Int32) { Value = objCatalogos.Catt_UsuarioCrea , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_UsuarioMod", DbType.Int32) { Value = objCatalogos.Catt_UsuarioMod , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_FechaCrea", DbType.DateTime) { Value = objCatalogos.Catt_FechaCrea , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catt_FechaMod", DbType.DateTime) { Value = objCatalogos.Catt_FechaMod , Direction = ParameterDirection.Input},

                    new SqlParameter("@Catv_IdOpcion", DbType.Int32) { Value = objCatalogos.Catv_IdOpcion , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_IdCatalogo", DbType.Int32) { Value = objCatalogos.Catv_IdCatalogo , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_Nombre", DbType.String) { Value = objCatalogos.Catv_Nombre , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_Orden", DbType.Int32) { Value = objCatalogos.Catv_Orden , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_Activo", DbType.Boolean) { Value = objCatalogos.Catv_Activo , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_Actualizable", DbType.Boolean) { Value = objCatalogos.Catv_Actualizable , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_UsuarioCrea", DbType.Int32) { Value = objCatalogos.Catv_UsuarioCrea , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_UsuarioMod", DbType.Int32) { Value = objCatalogos.Catv_UsuarioMod, Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_FechaCrea", DbType.DateTime) { Value = objCatalogos.Catv_FechaCrea , Direction = ParameterDirection.Input},
                    new SqlParameter("@Catv_FechaMod", DbType.DateTime) { Value = objCatalogos.Catv_FechaMod, Direction = ParameterDirection.Input},
                };
                dt = connectionDB.Fill_Tabla("SP_Catalogos", param);
            }
            catch (SqlException ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/Login_Mod", "0", "ValidarCredencialesLogin", "Login_Mod");
                return null;
            }
            finally
            {
                connectionDB.CloseConnection();
            }
            return dt;
        }






    }
}