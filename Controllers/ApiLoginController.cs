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
    public class ApiLoginController : ApiController
    {
        private readonly BitacoraErrores_Mod objBitacoraMod = new BitacoraErrores_Mod();
        private readonly Login_Mod objLoginMod = new Login_Mod();


        /// <summary>
        /// Método que nos permite validar las credenciales de acceso al sistema
        /// </summary>
        /// <param name="objUsers">Recibimos la información como un objeto de datos de Users</param>
        /// <returns>nos retorna un objeto DataTable ConectionDB el resultado de la validación de las credenciales.</returns>
        [HttpPost]
        public IHttpActionResult ValidarCredencialesLogin(UsersVM objUsers)
        {
            try
            {
                DataTable dtResultado = new DataTable();
                dtResultado = objLoginMod.ValidarCredencialesLogin(objUsers.Accion, objUsers.UserName, EncriptarPassword(objUsers.Password));
                return Ok(dtResultado);

            }catch(Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiLoginController/ValidarCredencialesLogin()", "0", "Error", "ApiBetaClientes");
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
