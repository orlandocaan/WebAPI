using ApiBetaClientes.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BetaClientesVM.PML;
using System.Net.Http.Headers;
using BetaClientesVM.Funciones;

namespace ApiBetaClientes.Repository
{
    public class PML_Mod
    {
        private readonly ApiConnectionDB conexionBD = new ApiConnectionDB(clsConnStrSQL.CnnStrSQLApiBetaClientes, CommandType.StoredProcedure);
        private readonly BitacoraErrores_Mod objBitacora = new BitacoraErrores_Mod();

        /// <summary>
        /// JGPJ 15/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Areas
        /// </summary>
        /// <param name="objAreasVM">Objeto de datos de PMLAreasVM</param>
        /// <returns>Nos retorna un DataTable como resultado</returns>
        public DataTable DTConsultaAreas(PMLAreasVM objAreasVM)
        {
            try
            {
                
                DataTable dtConsulta = new DataTable();
                
                SqlParameter[] param = 
                {
                    new SqlParameter("@Accion"            ,     DbType.Int32)     { Value = objAreasVM.Accion            ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_IdArea"       ,     DbType.Int32)     { Value = objAreasVM.Area_IdArea       ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_IdAreaPadre"  ,     DbType.Int32)     { Value = objAreasVM.Area_IdAreaPadre  ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_IdPlanta"     ,     DbType.Int32)     { Value = objAreasVM.Area_IdPlanta     ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_Nombre"       ,     DbType.String)    { Value = objAreasVM.Area_Nombre       ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_Activo"       ,     DbType.Boolean)   { Value = objAreasVM.Area_Activo       ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_UsuarioCrea"  ,     DbType.Int32)     { Value = objAreasVM.Area_UsuarioCrea  ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_UsuarioMod"   ,     DbType.Int32)     { Value = objAreasVM.Area_UsuarioMod   ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_FechaCrea"    ,     DbType.DateTime)  { Value = objAreasVM.Area_FechaCrea    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_FechaMod"     ,     DbType.DateTime)  { Value = objAreasVM.Area_FechaMod     ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_IdResponsable",     DbType.Int32)     { Value = objAreasVM.Area_IdResponsable,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Area_IdSupervisor" ,     DbType.Int32)     { Value = objAreasVM.Area_IdSupervisor ,      Direction = ParameterDirection.Input    },

                };
                dtConsulta = conexionBD.Fill_Tabla("SP_PMLAreas", param);
                return dtConsulta;
            }
            catch(Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// JGPJ 15/04/2024  Este método consulta sobre SP_PML_Equipos
        /// </summary>
        /// <param name="objEquiposVM"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public DataTable DTConsultaEquipos(PMLEquiposVM objEquiposVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"          , DbType.Int32)     { Value = objEquiposVM.Accion           , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_IdEquipo"   , DbType.Int32)     { Value = objEquiposVM.Equi_IdEquipo    , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_Nombre"     , DbType.String)    { Value = objEquiposVM.Equi_Nombre      , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_TipoEquipo" , DbType.Int32)     { Value = objEquiposVM.Equi_TipoEquipo  , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_IdArea"     , DbType.Int32)     { Value = objEquiposVM.Equi_IdArea      , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_POES"       , DbType.String)    { Value = objEquiposVM.Equi_POES        , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_Activo"     , DbType.Boolean)   { Value = objEquiposVM.Equi_Activo      , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_UsuarioCrea", DbType.Int32)     { Value = objEquiposVM.Equi_UsuarioCrea , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_UsuarioMod" , DbType.Int32)     { Value = objEquiposVM.Equi_UsuarioMod  , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_FechaCrea"  , DbType.DateTime)  { Value = objEquiposVM.Equi_FechaCrea   , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_FechaMod"   , DbType.DateTime)  { Value = objEquiposVM.Equi_FechaMod    , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_IdTurno"    , DbType.Int32)     { Value = objEquiposVM.Equi_IdTurno     , Direction = ParameterDirection.Input},
                    new SqlParameter("@Equi_IdPlanta"   , DbType.Int32)     { Value = objEquiposVM.Equi_IdPlanta    , Direction = ParameterDirection.Input},

                };
                dtConsulta = conexionBD.Fill_Tabla("SP_PMLEquipos", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaEquipos()", objEquiposVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// GFLT 22/04/2024  Este método consulta sobre SP_PMLTurnos
        /// </summary>
        /// <param name="objTurnosVM"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public DataTable DTConsultaTurnos(PMLTurnosVM objTurnosVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"          , DbType.Int32)     { Value = objTurnosVM.Accion               , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_Id"          , DbType.Int32)     { Value = objTurnosVM.Tur_Id               , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_Descripcion" , DbType.String)    { Value = objTurnosVM.Tur_Descripcion      , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_HoraEntrada" , DbType.DateTime)  { Value = objTurnosVM.Tur_HoraEntrada      , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_HoraSalida"  , DbType.DateTime)  { Value = objTurnosVM.Tur_HoraSalida       , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_Activo"      , DbType.Boolean)   { Value = objTurnosVM.Tur_Activo           , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_UsuarioCrea" , DbType.Int32)     { Value = objTurnosVM.Tur_UsuarioCrea      , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_UsuarioMod"  , DbType.Int32)     { Value = objTurnosVM.Tur_UsuarioMod       , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_FechaCrea"   , DbType.DateTime)  { Value = objTurnosVM.Tur_FechaCrea        , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_FechaMod"    , DbType.DateTime)  { Value = objTurnosVM.Tur_FechaMod         , Direction = ParameterDirection.Input},
                    new SqlParameter("@Tur_IdPlanta"    , DbType.Int32)     { Value = objTurnosVM.Tur_IdPlanta        , Direction = ParameterDirection.Input},
                };
                dtConsulta = conexionBD.Fill_Tabla("SP_PMLTurnos", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaTurnos()", objTurnosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// Método para gestionar los datos de la tabla PML_Equipos
        /// </summary>
        /// <param name="objEquiposVM">Objeto de datos del tipo de </param>
        /// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado</returns>
        public int GestionarEquipos(PMLEquiposVM objEquiposVM)
        {
            try
            {

                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"          , DbType.Int32)     { Value = objEquiposVM.Accion               , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_IdEquipo"   , DbType.Int32)     { Value = objEquiposVM.Equi_IdEquipo        , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_Nombre"     , DbType.String)    { Value = objEquiposVM.Equi_Nombre          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_TipoEquipo" , DbType.Int32)     { Value = objEquiposVM.Equi_TipoEquipo      , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_IdArea"     , DbType.Int32)     { Value = objEquiposVM.Equi_IdArea          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_POES"       , DbType.String)    { Value = objEquiposVM.Equi_POES            , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_Activo"     , DbType.Boolean)   { Value = objEquiposVM.Equi_Activo          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_UsuarioCrea", DbType.Int32)     { Value = objEquiposVM.Equi_UsuarioCrea     , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_UsuarioMod" , DbType.Int32)     { Value = objEquiposVM.Equi_UsuarioMod      , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_FechaCrea"  , DbType.DateTime)  { Value = objEquiposVM.Equi_FechaCrea       , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_FechaMod"   , DbType.DateTime)  { Value = objEquiposVM.Equi_FechaMod        , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_IdTurno"    , DbType.Int32)     { Value = objEquiposVM.Equi_IdTurno         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Equi_IdPlanta"   , DbType.Int32)     { Value = objEquiposVM.Equi_IdPlanta        , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Resultado"       , DbType.Int32)     {                                             Direction = ParameterDirection.Output }
                };
                resultado = conexionBD.ObtenerRegistroSP("SP_PMLEquipos", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaTurnos()", objEquiposVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }


        /// <summary>
        /// Este método me permite realizar una consulta sobre la tabla de PMLFrecuencia
        /// </summary>
        /// <param name="objFrecuenciaVM">Objeto de datos de PNLFrecuenciaVM</param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public DataTable DTConsultaFrecuencia(PMLFrecuenciaVM objFrecuenciaVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"                      , DbType.Int32)         { Value = objFrecuenciaVM.Accion                      , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdFrecuencia"           , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdFrecuencia           , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdFrecuenciaPadre"      , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdFrecuenciaPadre      , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdEquipo"               , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdEquipo               , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdTipoProducto"         , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdTipoProducto         , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdProducto"             , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdProducto             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_Concentracion"          , DbType.Decimal)       { Value = objFrecuenciaVM.Frec_Concentracion          , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdUDM"                  , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdUDM                  , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdTipoLimpieza"         , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdTipoLimpieza         , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_Activo"                 , DbType.Boolean)       { Value = objFrecuenciaVM.Frec_Activo                 , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_UsuarioCrea"            , DbType.Int32)         { Value = objFrecuenciaVM.Frec_UsuarioCrea            , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_UsuarioMod"             , DbType.Int32)         { Value = objFrecuenciaVM.Frec_UsuarioMod             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_FechaCrea"              , DbType.DateTime)      { Value = objFrecuenciaVM.Frec_FechaCrea              , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_FechaMod"               , DbType.DateTime)      { Value = objFrecuenciaVM.Frec_FechaMod               , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdPlanta"               , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdPlanta               , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_DescripcionFrecuencia"  , DbType.String)        { Value = objFrecuenciaVM.Frec_DescripcionFrecuencia  , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_Frecuencia"             , DbType.String)        { Value = objFrecuenciaVM.Frec_Frecuencia             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_DiasSemana"             , DbType.String)        { Value = objFrecuenciaVM.Frec_DiasSemana             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_DiaAplicacion"          , DbType.Int32)         { Value = objFrecuenciaVM.Frec_DiaAplicacion          , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_MesAplicacion"          , DbType.Int32)         { Value = objFrecuenciaVM.Frec_MesAplicacion          , Direction = ParameterDirection.Input    },
                
                };
                dtConsulta = conexionBD.Fill_Tabla("SP_PMLFrecuencia", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaFrecuencia()", objFrecuenciaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// Método para gestionar los datos de la View_ListaClientes_ERP
        /// </summary>
        /// <param name="objProductosVM">Objeto de datos de PMLProductosVM</param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public DataTable DTConsultaProductos(PMLProductosVM objProductosVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"      ,   DbType.Int32)     { Value = objProductosVM.Accion       , Direction = ParameterDirection.Input},
                    new SqlParameter("@IdCliente"   ,   DbType.String)    { Value = objProductosVM.CustId       , Direction = ParameterDirection.Input},

                };
                dtConsulta = conexionBD.Fill_Tabla("SP_PMLProductos", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaProductos()", objProductosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }



        /// <summary>
        /// Método para gestionar los datos de la tabla PML_Equipos
        /// </summary>
        /// <param name="objEquiposVM">Objeto de datos del tipo de </param>
        /// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado.</returns>
        public int GestionarFrecuencia(PMLFrecuenciaVM objFrecuenciaVM)
        {
            try
            {

                int resultado = 0;
                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"                      , DbType.Int32)         { Value = objFrecuenciaVM.Accion                      , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdFrecuencia"           , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdFrecuencia           , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdFrecuenciaPadre"      , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdFrecuenciaPadre      , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdEquipo"               , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdEquipo               , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdTipoProducto"         , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdTipoProducto         , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdProducto"             , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdProducto             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_Concentracion"          , DbType.Decimal)       { Value = objFrecuenciaVM.Frec_Concentracion          , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdUDM"                  , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdUDM                  , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdTipoLimpieza"         , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdTipoLimpieza         , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_Activo"                 , DbType.Boolean)       { Value = objFrecuenciaVM.Frec_Activo                 , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_UsuarioCrea"            , DbType.Int32)         { Value = objFrecuenciaVM.Frec_UsuarioCrea            , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_UsuarioMod"             , DbType.Int32)         { Value = objFrecuenciaVM.Frec_UsuarioMod             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_FechaCrea"              , DbType.DateTime)      { Value = objFrecuenciaVM.Frec_FechaCrea              , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_FechaMod"               , DbType.DateTime)      { Value = objFrecuenciaVM.Frec_FechaMod               , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_IdPlanta"               , DbType.Int32)         { Value = objFrecuenciaVM.Frec_IdPlanta               , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_DescripcionFrecuencia"  , DbType.String)        { Value = objFrecuenciaVM.Frec_DescripcionFrecuencia  , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_Frecuencia"             , DbType.String)        { Value = objFrecuenciaVM.Frec_Frecuencia             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_DiasSemana"             , DbType.String)        { Value = objFrecuenciaVM.Frec_DiasSemana             , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_DiaAplicacion"          , DbType.Int32)         { Value = objFrecuenciaVM.Frec_DiaAplicacion          , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Frec_MesAplicacion"          , DbType.Int32)         { Value = objFrecuenciaVM.Frec_MesAplicacion          , Direction = ParameterDirection.Input    },
                    new SqlParameter("@Resultado"                   , DbType.Int32)         {                                                       Direction = ParameterDirection.Output   }

                };

                resultado = conexionBD.ObtenerRegistroSP("SP_PMLFrecuencia", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaTurnos()", objFrecuenciaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }


		/// <summary>
		/// JGPJ 15/04/2024  Este método consulta sobre SP_PMLColaboradores
		/// </summary>
		/// <param name="objColaboradoresVM"></param>
		/// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
		public DataTable DTConsultaColaboradores(PMLColaboradoresVM objColaboradoresVM)
		{
			try
			{

				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
                    new SqlParameter("@Accion"            , DbType.Int32)     { Value = objColaboradoresVM.Accion             , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_IdColaborador" , DbType.Int32)     { Value = objColaboradoresVM.Col_IdColaborador  , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_Nombre"        , DbType.String)    { Value = objColaboradoresVM.Col_Nombre         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_Puesto"        , DbType.Int32)     { Value = objColaboradoresVM.Col_Puesto         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_Activo"        , DbType.Boolean)   { Value = objColaboradoresVM.Col_Activo         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_UsuarioCrea"   , DbType.Int32)     { Value = objColaboradoresVM.Col_UsuarioCrea    , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_UsuarioMod"    , DbType.Int32)     { Value = objColaboradoresVM.Col_UsuarioMod     , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Col_IdPlanta"      , DbType.Int32)     { Value = objColaboradoresVM.Col_IdPlanta       , Direction = ParameterDirection.Input  },
                    new SqlParameter("@IdArea"            , DbType.Int32)     { Value = objColaboradoresVM.IdArea             , Direction = ParameterDirection.Input  },
                    new SqlParameter("@IdEquipo"          , DbType.Int32)     { Value = objColaboradoresVM.IdEquipo           , Direction = ParameterDirection.Input  },

                };

				dtConsulta = conexionBD.Fill_Tabla("SP_PMLColaboradores", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaColaboradores()", objColaboradoresVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}


		/// <summary>
		/// Método para gestionar los datos de la tabla PML_Colaboradores
		/// </summary>
		/// <param name="objColaboradoresVM">Objeto de datos del tipo de </param>
		/// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado</returns>
		public int GestionarColaboradores(PMLColaboradoresVM objColaboradoresVM)
		{
			try
			{

				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@Accion"            , DbType.Int32)     { Value = objColaboradoresVM.Accion             , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_IdColaborador" , DbType.Int32)     { Value = objColaboradoresVM.Col_IdColaborador  , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_Nombre"        , DbType.String)    { Value = objColaboradoresVM.Col_Nombre         , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_Puesto"        , DbType.Int32)     { Value = objColaboradoresVM.Col_Puesto         , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_Activo"        , DbType.Boolean)   { Value = objColaboradoresVM.Col_Activo         , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_UsuarioCrea"   , DbType.Int32)     { Value = objColaboradoresVM.Col_UsuarioCrea     , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_UsuarioMod"    , DbType.Int32)     { Value = objColaboradoresVM.Col_UsuarioMod     , Direction = ParameterDirection.Input  },
					new SqlParameter("@Col_IdPlanta"      , DbType.Int32)     { Value = objColaboradoresVM.Col_IdPlanta       , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"         , DbType.Int32)     {                                                 Direction = ParameterDirection.Output }
				};

				resultado = conexionBD.ObtenerRegistroSP("SP_PMLColaboradores", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarColaboradores()", objColaboradoresVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// Este método consulta sobre SP_PMLPuestos
		/// </summary>
		/// <param name="objPuestosVM"></param>
		/// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
		public DataTable DTConsultaPuestos(CatalogosVM objCatalogosVM)
		{
			try
			{

				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@Accion"            , DbType.Int32)     { Value = objCatalogosVM.Accion           , Direction = ParameterDirection.Input},
					new SqlParameter("@Catt_Nombre"       , DbType.String)    { Value = objCatalogosVM.Catt_Nombre      , Direction = ParameterDirection.Input},
				};

				dtConsulta = conexionBD.Fill_Tabla("SP_SISCatalogos", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaPuestos()", "BetaVM", "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// Este método consulta sobre SP_PMLCalificaciones
		/// </summary>
		/// <param name="objCalificacionesVM"></param>
		/// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
		public DataTable DTConsultaCalificaciones(PMLCalificacionesVM objCalificacionesVM)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@Accion"             , DbType.Int32)     { Value = objCalificacionesVM.Accion             , Direction = ParameterDirection.Input},
					new SqlParameter("@Cal_IdColaborador"  , DbType.Int32)     { Value = objCalificacionesVM.Cal_IdColaborador  , Direction = ParameterDirection.Input},
					new SqlParameter("@Cal_IdPlanta"       , DbType.Int32)     { Value = objCalificacionesVM.Cal_IdPlanta       , Direction = ParameterDirection.Input},
					new SqlParameter("@IdArea"             , DbType.Int32)     { Value = objCalificacionesVM.IdArea             , Direction = ParameterDirection.Input}, ///JGPJ Se agrega el 02/05/2024 para el filtro de las calificaciones por área
					new SqlParameter("@IdEquipo"           , DbType.Int32)     { Value = objCalificacionesVM.IdEquipo             , Direction = ParameterDirection.Input}, ///JGPJ Se agrega el 02/05/2024 para el filtro de las calificaciones por equipo
				
                };

				dtConsulta = conexionBD.Fill_Tabla("SP_PMLCalificaciones", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaCalificaciones()", objCalificacionesVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// Método para gestionar los datos de la tabla PML_Calificaciones
		/// </summary>
		/// <param name="objCalificacionesVM">Objeto de datos del tipo de </param>
		/// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado</returns>
		public int GestionarCalificaciones(PMLCalificacionesVM objCalificacionesVM)
		{
			try
			{

				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@Accion"            , DbType.Int32)    { Value = objCalificacionesVM.Accion             , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_IdCalificacion", DbType.Int32)    { Value = objCalificacionesVM.Cal_IdCalificacion , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_IdColaborador" , DbType.Int32)    { Value = objCalificacionesVM.Cal_IdColaborador  , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_IdCurso"       , DbType.Int32)    { Value = objCalificacionesVM.Cal_IdCurso        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_Calificacion"  , DbType.Decimal)  { Value = objCalificacionesVM.Cal_Calificacion   , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_IdUsuario"     , DbType.Int32)    { Value = objCalificacionesVM.IdUsuario          , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_DocEvidencia"  , DbType.Binary)   { Value = objCalificacionesVM.Cal_DocEvidencia   , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_ExtensionDoc"  , DbType.String)   { Value = objCalificacionesVM.Cal_ExtensionDoc   , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_NombreDoc"     , DbType.String)   { Value = objCalificacionesVM.Cal_NombreDoc      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_FechaVigencia" , DbType.DateTime) { Value = objCalificacionesVM.Cal_FechaVigencia  , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_FechaCurso"    , DbType.DateTime) { Value = objCalificacionesVM.Cal_FechaCurso     , Direction = ParameterDirection.Input  },
					new SqlParameter("@Cal_IdPlanta"      , DbType.Int32)    { Value = objCalificacionesVM.Cal_IdPlanta       , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"         , DbType.Int32)    {                                                  Direction = ParameterDirection.Output }
				};

				resultado = conexionBD.ObtenerRegistroSP("SP_PMLCalificaciones", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarCalificaciones()", objCalificacionesVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}



        /// <summary>
        /// JGPJ Método para gestionar las acciones de INSERT, UPDATE, DELETE dentro de la s tablas de PMLAresVM
        /// </summary>
        /// <param name="objAreasVM">Objeto de datos de PMLAreasVM aquí recibimos toda la información</param>
        /// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado.</returns>
        public int GestionarAreasYSubAreas(PMLAreasVM objAreasVM)
        {
            try
            {

                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"            ,   DbType.Int32   )      { Value = objAreasVM.Accion            ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_IdArea"       ,   DbType.Int32   )      { Value = objAreasVM.Area_IdArea       ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_IdAreaPadre"  ,   DbType.Int32   )      { Value = objAreasVM.Area_IdAreaPadre  ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_IdPlanta"     ,   DbType.Int32   )      { Value = objAreasVM.Area_IdPlanta     ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_Nombre"       ,   DbType.String  )      { Value = objAreasVM.Area_Nombre       ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_Activo"       ,   DbType.Boolean )      { Value = objAreasVM.Area_Activo       ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_UsuarioCrea"  ,   DbType.Int32   )      { Value = objAreasVM.Area_UsuarioCrea  ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_UsuarioMod"   ,   DbType.Int32   )      { Value = objAreasVM.Area_UsuarioMod   ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_FechaCrea"    ,   DbType.DateTime)      { Value = objAreasVM.Area_FechaCrea    ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_FechaMod"     ,   DbType.DateTime)      { Value = objAreasVM.Area_FechaMod     ,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_IdResponsable",   DbType.Int32   )      { Value = objAreasVM.Area_IdResponsable,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Area_IdSupervisor" ,   DbType.Int32   )      { Value = objAreasVM.Area_IdSupervisor,     Direction = ParameterDirection.Input   },
                    new SqlParameter("@Resultado"         ,   DbType.Int32   )      {                                            Direction = ParameterDirection.Output  }
                };
                resultado = conexionBD.ObtenerRegistroSP("SP_PMLAreas", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarAreasYSubAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }



        ///// <summary>
        ///// Este Método nos permite realizar consultas sobre el StoredProcedure SP_Colaboradores
        ///// JGPJ 15/04/2024  
        ///// </summary>
        ///// <param name="objAreasVM">Objeto de datos de PMLColaboradoresVM</param>
        ///// <returns>Nos retorna un DataTable como resultado</returns>
        //public DataTable DTConsultaColaboradores(PMLColaboradoresVM objColaboradoresVM)
        //{
        //    try
        //    {

        //        DataTable dtConsulta = new DataTable();

        //        SqlParameter[] param =
        //        {
        //            new SqlParameter("@Accion"            ,     DbType.Int32    )   { Value = objColaboradoresVM.Accion                ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_IdColaborador" ,     DbType.Int32    )   { Value = objColaboradoresVM.Col_IdColaborador     ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_Nombre"        ,     DbType.String   )   { Value = objColaboradoresVM.Col_Nombre            ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_Puesto"        ,     DbType.Int32    )   { Value = objColaboradoresVM.Col_Puesto            ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_Activo"        ,     DbType.Boolean  )   { Value = objColaboradoresVM.Col_Activo            ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_UsuarioCrea"    ,     DbType.Int32    )   { Value = objColaboradoresVM.Col_UsuarioCrea       ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_UsuarioMod"    ,     DbType.Int32    )   { Value = objColaboradoresVM.Col_UsuarioMod        ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_FechaCrea"     ,     DbType.DateTime )   { Value = objColaboradoresVM.Col_FechaCrea         ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_FechaMod"      ,     DbType.DateTime )   { Value = objColaboradoresVM.Col_FechaMod          ,    Direction = ParameterDirection.Input  },
        //            new SqlParameter("@Col_IdPlanta"      ,     DbType.Int32    )   { Value = objColaboradoresVM.Col_IdPlanta          ,    Direction = ParameterDirection.Input  },
        //        };

        //        dtConsulta = conexionBD.Fill_Tabla("SP_PMLColaboradores", param);
        //        return dtConsulta;
        //    }
        //    catch (Exception ex)
        //    {
        //        objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaColaboradores()", objColaboradoresVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
        //        return null;
        //    }
        //}



        /// <summary>
        /// JGPJ 15/04/2024  Este método consulta sobre SP_PMLPrograma
        /// </summary>
        /// <param name="objEquiposVM"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public DataTable DTConsultaPrograma(PMLProgramaVM objProgramaVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"           ,      DbType.Int32    )     { Value = objProgramaVM.Accion            ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_IdPrograma"   ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdPrograma    ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_FechaPrograma",      DbType.DateTime )     { Value = objProgramaVM.Pro_FechaPrograma ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_IdTurno"      ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdTurno       ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_IdPlanta"     ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdPlanta      ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_IdUsuarioCrea",      DbType.Int32    )     { Value = objProgramaVM.Pro_IdUsuarioCrea ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_IdUsuarioMod" ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdUsuarioMod  ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_FechaCrea"    ,      DbType.DateTime )     { Value = objProgramaVM.Pro_FechaCrea     ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_FechaMod"     ,      DbType.DateTime )     { Value = objProgramaVM.Pro_FechaMod      ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_Activo"       ,      DbType.Boolean  )     { Value = objProgramaVM.Pro_Activo        ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@Pro_Estatus"      ,      DbType.String   )     { Value = objProgramaVM.Pro_Estatus       ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@FechaInicio"      ,      DbType.DateTime )     { Value = objProgramaVM.FechaInicio       ,       Direction = ParameterDirection.Input},
                    new SqlParameter("@FechaFin"         ,      DbType.DateTime )     { Value = objProgramaVM.FechaFin          ,       Direction = ParameterDirection.Input},
                };

                dtConsulta = conexionBD.Fill_Tabla("SP_PMLPrograma", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaEquipos()", objProgramaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// GFLT 22/04/2024  Método para gestionar los datos de la tabla PML_CURSOS
        /// </summary>
        /// <param name="objCursosVM">Objeto de datos del tipo de </param>
        /// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado</returns>
        public int GestionarCursos(PMLCursosVM objCursosVM)
        {
            try
            {

                int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@Accion", SqlDbType.Int) { Value = objCursosVM.Accion, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_IdCurso", SqlDbType.Int) { Value = objCursosVM.Cur_IdCurso, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_Nombre", SqlDbType.NVarChar) { Value = objCursosVM.Cur_Nombre, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_Activo", SqlDbType.Bit) { Value = objCursosVM.Cur_Activo, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_UsuarioCrea", SqlDbType.Int) { Value = objCursosVM.Cur_UsuarioCrea, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_UsuarioMod", SqlDbType.Int) { Value = objCursosVM.Cur_UsuarioMod, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_FechaCrea", SqlDbType.DateTime) { Value = objCursosVM.Cur_FechaCrea, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_FechaMod", SqlDbType.DateTime) { Value = objCursosVM.Cur_FechaMod, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_Objetivos", SqlDbType.NVarChar) { Value = objCursosVM.Cur_Objetivos, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_IdPlanta", SqlDbType.Int) { Value = objCursosVM.Cur_IdPlanta, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_IdArea", SqlDbType.Int) { Value = objCursosVM.Cur_IdArea, Direction = ParameterDirection.Input },
					new SqlParameter("@Cur_IdEquipo", SqlDbType.Int) { Value = objCursosVM.Cur_IdEquipo, Direction = ParameterDirection.Input },
					new SqlParameter("@Resultado"       , DbType.Int32)     {                                             Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_PMLCursos", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarCursos()", objCursosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}


        /// <summary>
        /// GFLT 22/04/2024  Este método consulta sobre SP_PMLCursos
        /// </summary>
        /// <param name="objCursosVM"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public DataTable DTConsultaCursos(PMLCursosVM objCursosVM)
		{
			try
			{

				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
			  new SqlParameter("@Accion", SqlDbType.Int) { Value = objCursosVM.Accion, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_IdCurso", SqlDbType.Int) { Value = objCursosVM.Cur_IdCurso, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_Nombre", SqlDbType.NVarChar) { Value = objCursosVM.Cur_Nombre, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_Activo", SqlDbType.Bit) { Value = objCursosVM.Cur_Activo, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_UsuarioCrea", SqlDbType.Int) { Value = objCursosVM.Cur_UsuarioCrea, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_UsuarioMod", SqlDbType.Int) { Value = objCursosVM.Cur_UsuarioMod, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_FechaCrea", SqlDbType.DateTime) { Value = objCursosVM.Cur_FechaCrea, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_FechaMod", SqlDbType.DateTime) { Value = objCursosVM.Cur_FechaMod, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_Objetivos", SqlDbType.NVarChar) { Value = objCursosVM.Cur_Objetivos, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_IdPlanta", SqlDbType.Int) { Value = objCursosVM.Cur_IdPlanta, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_IdArea", SqlDbType.Int) { Value = objCursosVM.Cur_IdArea, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_IdEquipo", SqlDbType.Int) { Value = objCursosVM.Cur_IdEquipo, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_EquipoNombre", SqlDbType.NVarChar) { Value = objCursosVM.Cur_EquipoNombre, Direction = ParameterDirection.Input },
			  new SqlParameter("@Cur_AreaNombre", SqlDbType.NVarChar) { Value = objCursosVM.Cur_AreaNombre, Direction = ParameterDirection.Input },
			};

				dtConsulta = conexionBD.Fill_Tabla("SP_PMLCursos", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaCursos()", objCursosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// GFLT 22/04/2024  Este método consulta sobre SP_PMLTurnos
		/// </summary>
		/// <param name="objTurnosVM"></param>
		/// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
		public int GestionarTurnos(PMLTurnosVM objTurnosVM)
		{
			try
			{
				int resultado = 0;



				SqlParameter[] param =
				{
					new SqlParameter("@Accion"          , DbType.Int32)     { Value = objTurnosVM.Accion               , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_Id"          , DbType.Int32)     { Value = objTurnosVM.Tur_Id               , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_Descripcion" , DbType.String)    { Value = objTurnosVM.Tur_Descripcion      , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_HoraEntrada" , DbType.DateTime)  { Value = objTurnosVM.Tur_HoraEntrada      , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_HoraSalida"  , DbType.DateTime)  { Value = objTurnosVM.Tur_HoraSalida       , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_Activo"      , DbType.Boolean)   { Value = objTurnosVM.Tur_Activo           , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_UsuarioCrea" , DbType.Int32)     { Value = objTurnosVM.Tur_UsuarioCrea      , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_UsuarioMod"  , DbType.Int32)     { Value = objTurnosVM.Tur_UsuarioMod       , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_FechaCrea"   , DbType.DateTime)  { Value = objTurnosVM.Tur_FechaCrea        , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_FechaMod"    , DbType.DateTime)  { Value = objTurnosVM.Tur_FechaMod         , Direction = ParameterDirection.Input},
					new SqlParameter("@Tur_IdPlanta"    , DbType.Int32)     { Value = objTurnosVM.Tur_IdPlanta        , Direction = ParameterDirection.Input},
					new SqlParameter("@Resultado"       , DbType.Int32)     {                                             Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_PMLTurnos", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarTurnos()", objTurnosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objProgramaVM"></param>
        /// <returns></returns>
        public int GestionarProgramaMaestro(PMLProgramaVM objProgramaVM)
        {
            try
            {

                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"           ,      DbType.Int32    )     { Value = objProgramaVM.Accion            ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_IdPrograma"   ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdPrograma    ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_FechaPrograma",      DbType.DateTime )     { Value = objProgramaVM.Pro_FechaPrograma ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_IdTurno"      ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdTurno       ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_IdPlanta"     ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdPlanta      ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_IdUsuarioCrea",      DbType.Int32    )     { Value = objProgramaVM.Pro_IdUsuarioCrea ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_IdUsuarioMod" ,      DbType.Int32    )     { Value = objProgramaVM.Pro_IdUsuarioMod  ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_FechaCrea"    ,      DbType.DateTime )     { Value = objProgramaVM.Pro_FechaCrea     ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_FechaMod"     ,      DbType.DateTime )     { Value = objProgramaVM.Pro_FechaMod      ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_Activo"       ,      DbType.Boolean  )     { Value = objProgramaVM.Pro_Activo        ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Pro_Estatus"      ,      DbType.String   )     { Value = objProgramaVM.Pro_Estatus       ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@FechaInicio"      ,      DbType.DateTime )     { Value = objProgramaVM.FechaInicio       ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@FechaFin"         ,      DbType.DateTime )     { Value = objProgramaVM.FechaFin          ,       Direction = ParameterDirection.Input    },
                    new SqlParameter("@Resultado"        ,      DbType.Int32    )     {                                                 Direction = ParameterDirection.Output   }

                };
                resultado = conexionBD.ObtenerRegistroSP("SP_PMLPrograma", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarProgramaMaestro()", objProgramaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }


        /// <summary>
        /// Método que nos permite consultar sobre la tabla PML_DetallePrograma
        /// </summary>
        /// <param name="objDetalleVM">Objeto de datos de PMLDetalleProgramaVM</param>
        /// <returns>Nos retorna un DataTable con los resultados de la consulta</returns>
        public DataTable DTConsultaDetallesPrograma(PMLDetalleProgramaVM objDetalleVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"                   ,     DbType.Int32    )    { Value = objDetalleVM.Accion                   ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdDetalle"         ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdDetalle         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdPrograma"        ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdPrograma        ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdAreaPrograma"    ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdAreaPrograma    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdArea"            ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdArea            ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdEquipo"          ,     DbType.Int32    )    { Value = objDetalleVM.@DetPro_IdEquipo         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreEquipo"      ,     DbType.String   )    { Value = objDetalleVM.DetPro_NombreEquipo      ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdProductoBase"    ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdProductoBase    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdProductoAlt1"    ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdProductoAlt1    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdProductoAlt2"    ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdProductoAlt2    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_Estatus"           ,     DbType.String   )    { Value = objDetalleVM.DetPro_Estatus           ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_Activo"            ,     DbType.Boolean  )    { Value = objDetalleVM.DetPro_Activo            ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_UsuarioCrea"       ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_UsuarioCrea       ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_UsuarioMod"        ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_UsuarioMod        ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_FechaCrea"         ,     DbType.DateTime )    { Value = objDetalleVM.DetPro_FechaCrea         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_FechaMod"          ,     DbType.DateTime )    { Value = objDetalleVM.DetPro_FechaMod          ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreProductoBase",     DbType.String   )    { Value = objDetalleVM.DetPro_NombreProductoBase,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreProductoAlt1",     DbType.String   )    { Value = objDetalleVM.DetPro_NombreProductoAlt1,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreProductoAlt2",     DbType.String   )    { Value = objDetalleVM.DetPro_NombreProductoAlt2,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@FechaDelPrograma"         ,     DbType.DateTime )    { Value = objDetalleVM.FechaDelPrograma         ,      Direction = ParameterDirection.Input    },                   
                    new SqlParameter("@IdTurno"                  ,     DbType.Int32    )    { Value = objDetalleVM.IdTurno                  ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@IdPlanta"                 ,     DbType.Int32    )    { Value = objDetalleVM.IdPlanta                 ,      Direction = ParameterDirection.Input    },

                };
                dtConsulta = conexionBD.Fill_Tabla("SP_PMLDetallesPrograma", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaDetallesPrograma()", objDetalleVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// Este método nos oermite realizar las operaciones de INSERT, UPDATE, DELETE en la tabla PML_DetallePrograma
        /// </summary>
        /// <param name="objProgramaVM">Objeto de datos de PMLProgramaVM </param>
        /// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado.</returns>
        public int GestionarDetallesPrograma(PMLDetalleProgramaVM objDetalleVM)
        {
            try
            {

                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"                   ,     DbType.Int32    )    { Value = objDetalleVM.Accion                   ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdDetalle"         ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdDetalle         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdPrograma"        ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdPrograma        ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdAreaPrograma"    ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdAreaPrograma    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdArea"            ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdArea            ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdColaborador"     ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_IdColaborador     ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdEquipo"          ,     DbType.Int32    )    { Value = objDetalleVM.@DetPro_IdEquipo         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreColaborador" ,     DbType.String   )    { Value = objDetalleVM.DetPro_NombreColaborador ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreEquipo"      ,     DbType.String   )    { Value = objDetalleVM.DetPro_NombreEquipo      ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdProductoBase"    ,     DbType.String   )    { Value = objDetalleVM.DetPro_IdProductoBase    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdProductoAlt1"    ,     DbType.String   )    { Value = objDetalleVM.DetPro_IdProductoAlt1    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_IdProductoAlt2"    ,     DbType.String   )    { Value = objDetalleVM.DetPro_IdProductoAlt2    ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_Estatus"           ,     DbType.String   )    { Value = objDetalleVM.DetPro_Estatus           ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_Activo"            ,     DbType.Boolean  )    { Value = objDetalleVM.DetPro_Activo            ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_UsuarioCrea"       ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_UsuarioCrea       ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_UsuarioMod"        ,     DbType.Int32    )    { Value = objDetalleVM.DetPro_UsuarioMod        ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_FechaCrea"         ,     DbType.DateTime )    { Value = objDetalleVM.DetPro_FechaCrea         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_FechaMod"          ,     DbType.DateTime )    { Value = objDetalleVM.DetPro_FechaMod          ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreProductoBase",     DbType.String   )    { Value = objDetalleVM.DetPro_NombreProductoBase,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreProductoAlt1",     DbType.String   )    { Value = objDetalleVM.DetPro_NombreProductoAlt1,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_NombreProductoAlt2",     DbType.String   )    { Value = objDetalleVM.DetPro_NombreProductoAlt2,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_ProductoBaseActivo",     DbType.Boolean  )    { Value = objDetalleVM.DetPro_ProductoBaseActivo,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_ProductoAlt1Activo",     DbType.Boolean  )    { Value = objDetalleVM.DetPro_ProductoAlt1Activo,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@DetPro_ProductoAlt2Activo",     DbType.Boolean  )    { Value = objDetalleVM.DetPro_ProductoAlt2Activo,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@FechaDelPrograma"         ,     DbType.DateTime )    { Value = objDetalleVM.FechaDelPrograma         ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@IdTurno"                  ,     DbType.Int32    )    { Value = objDetalleVM.IdTurno                  ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@IdPlanta"                 ,     DbType.Int32    )    { Value = objDetalleVM.IdPlanta                 ,      Direction = ParameterDirection.Input    },
                    new SqlParameter("@Resultado"                ,     DbType.Int32    )    {                                                      Direction = ParameterDirection.Output   }

                };
                resultado = conexionBD.ObtenerRegistroSP("SP_PMLDetallesPrograma", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarProgramaMaestro()", objDetalleVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }




        /// <summary>
        /// Este método nos permite realizar acciones INSERT, UPDATE, DELETE en la tabla PML_AreaPrograma
        /// </summary>
        /// <param name="objProgramaVM">Objeto de datos de PMLAreaProgramaVM</param>
        /// <returns>Nos retorna 0 si ocurres un error, de lo contrario devuelve 1 o el id insertado.</returns>
        public int GestionarAreasPrograma(PMLAreaProgramaVM objProgramaVM)
        {
            try
            {

                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"                      ,   DbType.Int32 )  { Value = objProgramaVM.Accion                      ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdAreaPrograma"        ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdAreaPrograma        ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdPrograma"            ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdPrograma            ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdArea"                ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdArea                ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdResponsable"         ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdResponsable         ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_NombreResponsable"     ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_NombreResponsable     ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_ComentarioResponsable" ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_ComentarioResponsable ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_FirmaResponsable"      ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_FirmaResponsable      ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdSupervisor"          ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdSupervisor          ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_NombreSupervisor"      ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_NombreSupervisor      ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_ComentarioSupervisor"  ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_ComentarioSupervisor  ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_FirmaSupervisor"       ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_FirmaSupervisor       ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdUsuarioCrea"         ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdUsuarioCrea         ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_IdUsuarioMod"          ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_IdUsuarioMod          ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_FechaCrea"             ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_FechaCrea             ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_FechaMod"              ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_FechaMod              ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_Estatus"               ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_Estatus               ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_FechaFirmaResponsable" ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_FechaFirmaResponsable ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Aprog_FechaFirmaSupervisor"  ,   DbType.Int32 )  { Value = objProgramaVM.Aprog_FechaFirmaSupervisor  ,   Direction = ParameterDirection.Input    },
                    new SqlParameter("@Resultado"                   ,   DbType.Int32 )  {                                                       Direction = ParameterDirection.Output   }
                };

                resultado = conexionBD.ObtenerRegistroSP("SP_PMLAreaPrograma", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/GestionarAreasPrograma()", objProgramaVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }



        /// <summary>
        /// Este método nos permite consultar la información del IdAreaPrograma de la tabla PML_AREAPROGRAMA
        /// </summary>
        /// <param name="accion">Accion a ejecutar dentro del SP</param>
        /// <param name="idPrograma">Id del programa a consultar</param>
        /// <param name="idArea">Id del area a consultar</param>
        /// <param name="idUsuario">Id del usuario con sesion iniciada</param>
        /// <returns>Nos retorna el valor del IdAreaPrograma si ya esta registrado, retorna -1 si ocurre un error en la consulta de la información, 0 si el idPrograma no esta registrado.</returns>
        public int ConsultarIdAreaPrograma(int accion, int idPrograma, int? idArea, int idUsuario)
        {
            try
            {

                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"          ,   DbType.Int32   )   { Value =    accion    ,      Direction = ParameterDirection.Input   },
                    new SqlParameter("@Aprog_IdPrograma",   DbType.Int32   )   { Value =    idPrograma,      Direction = ParameterDirection.Input   },
                    new SqlParameter("@Aprog_IdArea"    ,   DbType.Int32   )   { Value =    idArea    ,      Direction = ParameterDirection.Input   },

                };

                DataTable dtConsulta = conexionBD.Fill_Tabla("SP_PMLAreaPrograma", param);

                if (dtConsulta.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtConsulta.Rows[0]["Aprog_IdPrograma"]);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/ConsultarIdAreaPrograma()", idUsuario.ToString(), "Error", "ApiBetaClientes");
                return -1;
            }
        }









    }
}

