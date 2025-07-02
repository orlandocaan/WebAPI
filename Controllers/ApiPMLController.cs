using ApiBetaClientes.Repository;
using BetaClientesVM.Funciones;
using BetaClientesVM.PML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Transactions;


namespace ApiBetaClientes.Controllers
{
    public class ApiPMLController : ApiController
    {
        private readonly BitacoraErrores_Mod objBitacoraMod = new BitacoraErrores_Mod();
        private readonly PML_Mod objPmlMod = new PML_Mod();




        /// <summary>
        /// Este método nos permite realizar consultas sobre el procedimiento almacenado SP_Areas.
        /// JGPJ 15/04/2024 
        /// </summary>
        /// <param name="objAreasVM">Objeto de datos de PMLAreasVM que contiene los parámetros de consulta.</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaAreas")]
        public IHttpActionResult DTConsultaAreas(PMLAreasVM objAreasVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaAreas(objAreasVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Método que nos permite realizar consultas sobre la tabla de PML_Equipos
        /// JGPJ 15/04/2024 
        /// </summary>
        /// <param name="objEquiposVM">Objeto de datos de PMLEquiposVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaEquipos")]
        public IHttpActionResult DTConsultaEquipos(PMLEquiposVM objEquiposVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaEquipos(objEquiposVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaEquipos()", objEquiposVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Nos permite realizar consultas sobre la tabla de PML_Turnos
        /// GFLT 22/04/2024 
        /// </summary>
        /// <param name="objTurnosVM">Objeto de datos de PMLTurnosVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaTurnos")]
        public IHttpActionResult DTConsultaTurnos(PMLTurnosVM objTurnosVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaTurnos(objTurnosVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaTurnos()", objTurnosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_Equipos.
        /// JGPJ 17/04/2024 
        /// </summary>
        /// <param name="objEquiposVM">Objeto de datos de objEquiposVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarEquipos")]
        public IHttpActionResult GestionarEquipos(PMLEquiposVM objEquiposVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarEquipos(objEquiposVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaAreas()", objEquiposVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// Este método nos permite consultar sobre la tabla de PML_Frecuencia
        /// JGPJ 18/04/2024 
        /// </summary>
        /// <param name="objFrecuenciaVM">Objeto de tipo PMLFrecuenciaVM que contiene los datos para la consulta.</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaFrecuencia")]
        public IHttpActionResult DTConsultaFrecuencia(PMLFrecuenciaVM objFrecuenciaVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaFrecuencia(objFrecuenciaVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaFrecuencia()", objFrecuenciaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método nos permite consultar la información de la tabla PML_Productos
        /// </summary>
        /// <param name="objProductosVM">Objeto de datos de PMLProductosVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaProductos")]
        public IHttpActionResult DTConsultaProductos(PMLProductosVM objProductosVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaProductos(objProductosVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaAreas()", objProductosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_Frecuencia
        /// JGPJ 17/04/2024 
        /// </summary>
        /// <param name="objFrecuenciaVM">Objeto de datos de objFrecuenciaVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarFrecuencia")]
        public IHttpActionResult GestionarFrecuencia(PMLFrecuenciaVM objFrecuenciaVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarFrecuencia(objFrecuenciaVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestonarFrecuencia()", objFrecuenciaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_Areas.
        /// JGPJ 17/04/2024 
        /// </summary>
        /// <param name="objEquiposVM">Objeto de datos de objEquiposVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarAreasYSubAreas")]
        public IHttpActionResult GestionarAreasYSubAreas(PMLAreasVM objAreasVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarAreasYSubAreas(objAreasVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarAreasYSubAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// Este método nos permite realizar consultas sobre el procedimiento almacenado SP_PMLPrograma
        /// JGPJ 25/04/2024 
        /// </summary>
        /// <param name="objAreasVM">Objeto de datos de PMLProgramaVM que contiene los parámetros de consulta.</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaPrograma")]
        public IHttpActionResult DTConsultaPrograma(PMLProgramaVM objProgramaVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaPrograma(objProgramaVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPrograma()", objProgramaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }






        /// <summary>
        /// OCA - 16/04/2024 Método que nos permite realizar consultas sobre la tabla de PML_Colaboradores
        /// </summary>
        /// <param name="objColaboradoresVM">Objeto de datos de PMLColaboradoresVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaColaboradores")]
        public IHttpActionResult DTConsultaColaboradores(PMLColaboradoresVM objColaboradoresVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaColaboradores(objColaboradoresVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaColaboradores()", objColaboradoresVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_Colaboradores.
        /// </summary>
        /// <param name="objColaboradoresVM">Objeto de datos de objColaboradoresVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarColaboradores")]
        public IHttpActionResult GestionarColaboradores(PMLColaboradoresVM objColaboradoresVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarColaboradores(objColaboradoresVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarColaboradores()", objColaboradoresVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// OCA - 16/04/2024 Método que nos permite realizar consultas sobre la tabla de PML_Colaboradores
        /// </summary>
        /// <param name="objPuestosVM">Objeto de datos de PMLPuestosVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaPuestos")]
        public IHttpActionResult DTConsultaPuestos(CatalogosVM objCatalogos)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaPuestos(objCatalogos);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", "BetaClienteVM", "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// OCA - 16/04/2024 Método que nos permite realizar consultas sobre la tabla de PML_Calificaciones
        /// </summary>
        /// <param name="objCalificacionesVM">Objeto de datos de PMLCalificacionesVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaCalificaciones")]
        public IHttpActionResult DTConsultaCalificaciones(PMLCalificacionesVM objCalificacionesVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaCalificaciones(objCalificacionesVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaCalificaciones()", objCalificacionesVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// GFLT - 29/04/2024 Método que nos permite realizar consultas sobre la tabla de PML_TURNOS
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PMLTurnos.
        /// </summary>
        /// <param name="objTurnosVM">Objeto de datos de PMLTurnosVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarTurnos")]
        public IHttpActionResult GestionarTurnos(PMLTurnosVM objTurnosVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarTurnos(objTurnosVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaAreas()", objTurnosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_Calificaciones.
        /// </summary>
        /// <param name="objCalificacionesVM">Objeto de datos de objCalificacionesVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarCalificaciones")]
        public IHttpActionResult GestionarCalificaciones(PMLCalificacionesVM objCalificacionesVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarCalificaciones(objCalificacionesVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarColaboradores()", objCalificacionesVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// GFLT - 29/04/2024 Método que nos permite realizar consultas sobre la tabla de PML_Cursos
        /// </summary>
        /// <param name="objCursosVM">Objeto de datos de objCursosVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaCursos")]
        public IHttpActionResult DTConsultaCursos(PMLCursosVM objCursosVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaCursos(objCursosVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaCursos()", objCursosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_Programa.
        /// JGPJ 26/04/2024 
        /// </summary>
        /// <param name="objEquiposVM">Objeto de datos de objEquiposVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarProgramaMaestro")]
        public IHttpActionResult GestionarProgramaMaestro(PMLProgramaVM objProgramaVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarProgramaMaestro(objProgramaVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarProgramaMaestro()", objProgramaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método nos permite consultar los detalles de un programa
        /// </summary>
        /// <param name="objDetalleVM">Objeto de daltos de PMLDetalleProgramaVM </param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiPML/DTConsultaDetallesPrograma")]
        public IHttpActionResult DTConsultaDetallesPrograma(PMLDetalleProgramaVM objDetalleVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objPmlMod.DTConsultaDetallesPrograma(objDetalleVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaDetallesPrograma()", objDetalleVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Este método nos permite insertar la información completa del Programa, inserta en la tabla PML_PROGRAMA, PML_AREAPROGRAMA y PML_DETALLESPROGRAMA
        /// </summary>
        /// <param name="objProgramaVM">Objeto de datos e PMLProgramaVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarProgramas")]
        public IHttpActionResult GestionarProgramas(PMLProgramaVM objProgramaVM)
        {
            try
            {
                int idPrograma = 0;

                List<PMLAreaProgramaVM> listaAreasPrograma = objProgramaVM.ListaDetalles
                    .GroupBy(dato => dato.DetPro_IdArea) 
                    .Select(group => new PMLAreaProgramaVM
                    {
                        Aprog_IdArea = group.Key, 
                        Aprog_IdResponsable = group.First().IdResponsable,
                        Aprog_NombreResponsable = group.First().NombreResponsable,
                        Aprog_IdSupervisor = group.First().IdSupervisor,
                        Aprog_NombreSupervisor = group.First().NombreSupervisor,
                        Aprog_IdUsuarioCrea = objProgramaVM.IdUsuario,
                        Aprog_IdUsuarioMod = objProgramaVM.IdUsuario
                    })
                    .ToList();


                using (TransactionScope transcope = new TransactionScope())
                {
                    //Insertamos el programa maestro (Insert sobre PML_PROGRAMA)
                    idPrograma = objPmlMod.GestionarProgramaMaestro(objProgramaVM);

                    if (idPrograma != 0)
                    {

                        //Insertamos las firmas de las áreas (Insert sobre PML_AREAPROGRAMA)
                        foreach (var areaspro in listaAreasPrograma)
                        {
                            areaspro.Accion                 =   1;        
                            areaspro.Aprog_IdPrograma       =   idPrograma;
                            areaspro.Aprog_IdUsuarioCrea    =   objProgramaVM.IdUsuario;
                            areaspro.Aprog_IdUsuarioMod     =   objProgramaVM.IdUsuario;
                            int IdAreaPrograma = objPmlMod.GestionarAreasPrograma(areaspro);

                            if (IdAreaPrograma > 0)
                            {
                                foreach (var item in objProgramaVM.ListaDetalles.Where(x=>x.DetPro_IdArea == areaspro.Aprog_IdArea).ToList())
                                {
                                    item.DetPro_IdPrograma      =   idPrograma;
                                    item.DetPro_IdAreaPrograma  =   IdAreaPrograma;
                                    item.DetPro_UsuarioCrea     =   objProgramaVM.IdUsuario;
                                    item.DetPro_UsuarioMod      =   objProgramaVM.IdUsuario;
                                    int IdDetalle               =   objPmlMod.GestionarDetallesPrograma(item);

                                    if (IdDetalle == 0)
                                    {
                                        transcope.Dispose();
                                        return BadRequest("No se pudo crear uno de los detalles del programa.");
                                    }
                                }
                            }
                            else
                            {
                                transcope.Dispose();
                                return BadRequest("No se pudo crear el programa maestro.");
                            }

                        }

                    }
                    else
                    {
                        transcope.Dispose();
                        return BadRequest("Error al insertar el Programa (PML_PROGRAMA)");
                    }

                    transcope.Complete();
                }

                return Ok(idPrograma);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarProgramas()", objProgramaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }




        /// <summary>
        /// Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla PML_DETALLESPROGRAMA.
        /// JGPJ 07/05/2024 
        /// </summary>
        /// <param name="objDetallesVM">Objeto de datos de objDetallesVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiPML/GestionarDetallesPrograma")]
        public IHttpActionResult GestionarDetallesPrograma(PMLDetalleProgramaVM objDetallesVM)
        {
            try
            {
                int resultado = 0;
                resultado = objPmlMod.GestionarDetallesPrograma(objDetallesVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarDetallesPrograma()", objDetallesVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// Este método se encarga de gestionar los insert de nuevos detalles al programa, realiza insert sobre la tabla PML_DETALLESPROGRAMA
        /// </summary>
        /// <param name="listaDetalles">Aquí recibimos una List<PMLDetalleProgramaVM></param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado</returns>
        [HttpPost]
        [Route("api/ApiPML/ListaGestionarDetallesPrograma")]
        public IHttpActionResult ListaGestionarDetallesPrograma(List<PMLDetalleProgramaVM> listaDetalles)
        {
            int idUsuario = listaDetalles.Select(dato=>dato.IdUsuario).FirstOrDefault();
            int idPrograma = listaDetalles.Select(dato=>dato.DetPro_IdPrograma).FirstOrDefault();

            try
            {
                int resultado = idPrograma;
                

                //Obtenemos la lista de las areas
                List<PMLAreaProgramaVM> listaAreasPrograma = listaDetalles
                .GroupBy(dato => dato.DetPro_IdArea)
                .Select(group => new PMLAreaProgramaVM
                {
                    Aprog_IdArea            =   group.Key,
                    Aprog_IdResponsable     =   group.First().IdResponsable,
                    Aprog_NombreResponsable =   group.First().NombreResponsable,
                    Aprog_IdSupervisor      =   group.First().IdSupervisor,
                    Aprog_NombreSupervisor  =   group.First().NombreSupervisor,
                    Aprog_IdUsuarioCrea     =   idUsuario,
                    Aprog_IdUsuarioMod      =   idUsuario
                })
                .ToList();



                using (TransactionScope transcope = new TransactionScope())
                {

                    //Insertamos los datosen la tabla de PML_AREAPROGRAMA
                    foreach (var areaspro in listaAreasPrograma)
                    {
                        areaspro.Accion = 1;
                        areaspro.Aprog_IdPrograma       =   idPrograma;
                        areaspro.Aprog_IdUsuarioCrea    =   idUsuario;
                        areaspro.Aprog_IdUsuarioMod     =   idUsuario;


                        //Consultamos el valor del IdAreaProgrma, si no existe en la tabla lo insertamos
                        int idAreaPrograma = objPmlMod.ConsultarIdAreaPrograma(2, idPrograma, areaspro.Aprog_IdArea, idUsuario);

                        if (idAreaPrograma == -1 )
                        {
                            transcope.Dispose();
                            return BadRequest("Ocurrio un error en ApiPMLController->ConsultarIdAreaPrograma()");
                        }
                        else if (idAreaPrograma == 0)
                        {
                            idAreaPrograma = objPmlMod.GestionarAreasPrograma(areaspro);
                        }



                        if (idAreaPrograma>0)
                        {
                            //Insertamos sobre PML_DetallesPrograma
                            foreach (var item in listaDetalles.Where(x => x.DetPro_IdArea == areaspro.Aprog_IdArea).ToList())
                            {
                                item.DetPro_IdPrograma = idPrograma;
                                item.DetPro_IdAreaPrograma = idAreaPrograma;
                                item.DetPro_UsuarioCrea = idUsuario;
                                item.DetPro_UsuarioMod = idUsuario;
                                int IdDetalle = objPmlMod.GestionarDetallesPrograma(item);

                                if (IdDetalle == 0)
                                {
                                    transcope.Dispose();
                                    return BadRequest("No se pudo crear uno de los detalles del programa.");
                                }
                            }

                        }
                        else
                        {
                            transcope.Dispose();
                            return BadRequest("Error al insertar sobre PML_AreaPrograma");
                        }




                    }

                    transcope.Complete();
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GestionarDetallesPrograma()", idUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }



        /// <summary>
        /// Este método se encarga de actualizar los detalles de un programa
        /// realiza Update sobre la tabla PML_DETALLESPROGRAMA y Realiza Insert de las firmas agregadas en PML_FIRMAS
        /// </summary>
        /// <param name="listaDetalles">Aquí recibimos una List<PMLDetalleProgramaVM></param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado</returns>
        [HttpPost]
        [Route("api/ApiPML/ActualizarDetallesPrograma")]
        public IHttpActionResult ActualizarDetallesPrograma(List<PMLDetalleProgramaVM> listaDetalles)
        {
            int idUsuario   =   listaDetalles.Select(dato => dato.IdUsuario).FirstOrDefault();
            int idPrograma  =   listaDetalles.Select(dato => dato.DetPro_IdPrograma).FirstOrDefault();

            try
            {
                int resultado = 1;


                //Realizamos el update sobre los campos que fueron firmados
                List<PMLAreaProgramaVM> listaAreasPrograma = listaDetalles
                .Where(dato=>dato.DetPro_IdAreaPrograma!=null)
                .GroupBy(dato => dato.DetPro_IdAreaPrograma)
                .Select(group => new PMLAreaProgramaVM
                {
                    Accion                          =       3,
                    Aprog_IdAreaPrograma            =       group.Key,
                    Aprog_IdPrograma                =       idPrograma,
                    Aprog_IdArea                    =       group.First().DetPro_IdArea,
                    Aprog_IdResponsable             =       group.First().IdResponsable,
                    Aprog_NombreResponsable         =       group.First().NombreResponsable,
                    Aprog_ComentarioResponsable     =       group.First().ComentariosResponsable,
                    Aprog_FirmaResponsable          =       group.First().CadenaFirmaResponsable != null ? Convert.FromBase64String(group.First().CadenaFirmaResponsable) : null,
                    Aprog_IdSupervisor              =       group.First().IdSupervisor,
                    Aprog_NombreSupervisor          =       group.First().NombreSupervisor,
                    Aprog_ComentarioSupervisor      =       group.First().ComentariosSupervisor,
                    Aprog_FirmaSupervisor           =       group.First().CadenaFirmaSupervisor != null ? Convert.FromBase64String(group.First().CadenaFirmaSupervisor) :  null,
                    Aprog_IdUsuarioCrea             =       idUsuario,
                    Aprog_IdUsuarioMod              =       idUsuario
                }).ToList();



                using (TransactionScope transcope = new TransactionScope())
                {

                    foreach (var areaspro in listaAreasPrograma)
                    {

                        //Solo cuando vienen nuevas firmas
                        if (areaspro.Aprog_FirmaResponsable != null || areaspro.Aprog_FirmaSupervisor != null)
                        {
                            //Actualizamos la información en la tabla PML_AreasPrograma
                            int idAreaPrograma = objPmlMod.GestionarAreasPrograma(areaspro);
                            if (idAreaPrograma==0)
                            {
                                transcope.Dispose();
                                return BadRequest("No se pudo actualizar uno de los registros de PML_AREAPROGRAMA");
                            }

                        }


                        //Hacemos el update de los detalles en la tabla PML_DETALLESPROGRAMA
                        foreach (var item in listaDetalles.Where(x => x.DetPro_IdArea == areaspro.Aprog_IdArea).ToList())
                        {
                            item.Accion     =   6;
                            int idDetalle = objPmlMod.GestionarDetallesPrograma(item);

                            if (idDetalle == 0)
                            {
                                transcope.Dispose();
                                return BadRequest("No se pudo actualizar uno de los registros de PML_DETALLESPROGRAMA");
                            }
                        }

                    }


                    transcope.Complete();

                }


                return Ok(resultado);
            }
            catch (Exception ex)
            {
                objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/ActualizarDetallesPrograma()", idUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }












    }

}

