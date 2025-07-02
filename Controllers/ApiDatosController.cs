using ApiBetaClientes.Repository;
using BetaClientesVM.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace ApiBetaClientes.Controllers
{
    public class ApiDatosController : ApiController
    {
        private readonly BitacoraErrores_Mod objBitacoraMod = new BitacoraErrores_Mod();
        private readonly Datos_Mod objDatos = new Datos_Mod();


        /// <summary>
        /// Método que nos permite consultar la información correspondiente al menú dinámico
        /// </summary>
        /// <param name="accion">Numero de Acción a ejecutar en SP</param>
        /// <param name="idUsuario">IdDel usuario ConectionDB sesión iniciada</param>
        /// <param name="roleCode">Rol del usuario</param>
        /// <param name="language">Lenguaje</param>
        /// <returns>Nos retorna un DataTable ConectionDB la información del Menu</returns>
        [HttpGet]
        [Route("api/ApiDatos/DTMenuDinamico")]
        public IHttpActionResult DTMenuDinamico(int accion, int idUsuario, int roleCode, string language)
        {
            try
            {
                DataTable dtResultado = new DataTable();
                dtResultado = objDatos.DTMenuDinamico(accion, idUsuario, roleCode, language);
                return Ok(dtResultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiDatosController/dtMenuDinamico()", idUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Metodo para administrar los usuarios del sistema, insertar, actualizar, eliminar
        /// </summary>
        /// <param name="objUsers">Objeto de datos de Usuarios</param>
        /// <returns>Nos retorna 0 si accion es errónea, mayor o igual a 1 si es correcta</returns>
        [HttpPost]
        [Route("api/ApiDatos/AdministrarUsuarios")]
        public IHttpActionResult AdministrarUsuarios(UsersVM objUsers)
        {
            try
            {

                string password = !string.IsNullOrEmpty(objUsers.Password) ? EncriptarPassword(objUsers.Password) : objUsers.Password;

                int resultado = objDatos.AdministrarUsuarios(objUsers.Accion,
                                                             objUsers.UserId, 
                                                             objUsers.UserName, 
                                                             password, 
                                                             objUsers.Name, 
                                                             objUsers.LastName, 
                                                             objUsers.Email, 
                                                             objUsers.Enabled,
                                                             objUsers.Img,
                                                             objUsers.FirstLogin,
                                                             objUsers.RoleId);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiDatosController/AdministrarUsuarios()", objUsers.UserId.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Método para consultar los catalogos del sistema
        /// </summary>
        /// <param name="objCatalogo">Objeto de datos de Catalogo</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ApiDatos/DTConsultaCatalogos")]
        public IHttpActionResult DTConsultaCatalogos(CatalogosVM objCatalogo)
        {
            try
            {
                DataTable dtResultado = new DataTable();
                dtResultado = objDatos.DTConsultaCatalogos(objCatalogo);
                return Ok(dtResultado);

            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiDatosController/DTConsultaCatalogos()", "0", "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// Método que nos permite realizar la encriptación de la contraseña
        /// </summary>
        /// <param name="password">Parámetro ue recibe la cadena de la contraseña</param>
        /// <returns>Nos devuelve la cadena encriptada de la contraseña.</returns>
        private string EncriptarPassword(string password)
        {
            string passwordEncrypt = null;
            UnicodeEncoding ueCodigo = new UnicodeEncoding();
            SHA1Managed SHA1 = new SHA1Managed();

            byte[] bHash = SHA1.ComputeHash(ueCodigo.GetBytes(password));
            passwordEncrypt = Convert.ToBase64String(bHash);
            return passwordEncrypt;
        }







    }
}
