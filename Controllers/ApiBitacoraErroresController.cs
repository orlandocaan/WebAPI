using ApiBetaClientes.Class;
using ApiBetaClientes.Repository;
using BetaClientesVM.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiBetaClientes.Controllers
{
    public class ApiBitacoraErroresController : ApiController
    {
        private readonly BitacoraErrores_Mod objBitacoraMod = new BitacoraErrores_Mod();


        /// <summary>
        /// Método para insertar en la bitácora de errores
        /// </summary>
        /// <param name="objBitacora">Objeto de Bitacora_ErroresVM</param>
        /// <returns>Nos devuelve un resultado de tipo bool si peticion es correcta, de lo contrario devolvemos el mensaje de error</returns>
        [HttpPost]
        [Route("api/ApiBitacoraErrores/InsertarBitacoraErrores")]
        public IHttpActionResult InsertarBitacoraErrores(Bitacora_ErroresVM objBitacora)
        {
            try
            {
                bool resultado = objBitacoraMod.InsertarBitacoraErrores(objBitacora.REPORTE_ERROR, objBitacora.SOURCE, objBitacora.USER_LOGIN, objBitacora.TYPE, objBitacora.RECEIVER);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiBitacoraErroresController/InsertarBitacoraErrores", "ApiBetaClientes", "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }




    }
}
