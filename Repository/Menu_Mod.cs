using ApiBetaClientes.Class;
using BetaClientesVM.PML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Drawing;
using Antlr.Runtime.Misc;
using BetaClientesVM.Menu;
using Newtonsoft.Json;

namespace ApiBetaClientes.Repository
{
	public class Menu_Mod
	{
		private readonly ApiConnectionDB conexionBD = new ApiConnectionDB(clsConnStrSQL.CnnStrSQLApiBetaClientes, CommandType.StoredProcedure);


		/// <summary>
		/// OCA 24/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objSetting">Objeto de datos de MSettingVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetSettingsMod(MSettingVM objSetting)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@Accion"   , DbType.Int32)  { Value = objSetting.Accion   , Direction = ParameterDirection.Input},
					new SqlParameter("@Class"    , DbType.String) { Value = objSetting.Class    , Direction = ParameterDirection.Input},
					new SqlParameter("@Property" , DbType.String) { Value = objSetting.property , Direction = ParameterDirection.Input},
					new SqlParameter("@RecordId" , DbType.Int32)  { Value = objSetting.RecordId , Direction = ParameterDirection.Input},
				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 25/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_MSettings
		/// </summary>
		/// <param name="objLabel">Objeto de datos de MLabelVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetSupportedLanguagesMod(MLabelVM objLabel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objLabel.Accion   , Direction = ParameterDirection.Input},
					new SqlParameter("@class"    , DbType.String) { Value = objLabel.Class    , Direction = ParameterDirection.Input},
					new SqlParameter("@lang"     , DbType.String) { Value = objLabel.langcode , Direction = ParameterDirection.Input},
				};
				dtConsulta = conexionBD.Fill_Tabla("SP_MLabels", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 02/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_MLanguages
		/// </summary>
		/// <param name="objLang">Objeto de datos de MLanguagesVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetLanguagesMod(MLanguageVM objLang)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objLang.Accion   , Direction = ParameterDirection.Input},
					new SqlParameter("@id"		 , DbType.String) { Value = objLang.Id		, Direction = ParameterDirection.Input},
					new SqlParameter("@langcode" , DbType.String) { Value = objLang.langCode , Direction = ParameterDirection.Input},
				};
				dtConsulta = conexionBD.Fill_Tabla("SP_MLanguages", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 02/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_MLabels
		/// </summary>
		/// <param name="objLabel">Objeto de datos de MLabelVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetLangCodesMod(MLabelVM objLabel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objLabel.Accion   , Direction = ParameterDirection.Input},
					new SqlParameter("@lang"     , DbType.String) { Value = objLabel.langcode , Direction = ParameterDirection.Input},
					new SqlParameter("@class"    , DbType.String) { Value = objLabel.Class    , Direction = ParameterDirection.Input},
					new SqlParameter("@property" , DbType.String) { Value = objLabel.Property , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_MLabels", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 02/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_MLabels
		/// </summary>
		/// <param name="objLabel">Objeto de datos de MLabelVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetLabelLangMod(MLabelVM objLabel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objLabel.Accion   , Direction = ParameterDirection.Input},
					new SqlParameter("@RecordId" , DbType.Int32)  { Value = objLabel.RecordId , Direction = ParameterDirection.Input},
					new SqlParameter("@class"    , DbType.String) { Value = objLabel.Class    , Direction = ParameterDirection.Input},
					new SqlParameter("@lang"     , DbType.String) { Value = objLabel.langcode , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_MLabels", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 02/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_MLabels
		/// </summary>
		/// <param name="objMenu">Objeto de datos de MLabelVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetDataMenuMod(MMenuVM objMenu)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objMenu.Accion   , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 03/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objUser">Objeto de datos de MUserVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetUsersMod(MUserVM objUser)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objUser.Accion   , Direction = ParameterDirection.Input},
                    new SqlParameter("@FunctionsId"   , DbType.Int32)  { Value = objUser.FunctionsId  , Direction = ParameterDirection.Input}

                };
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 03/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objRole">Objeto de datos de MRoleVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetRolesMod(MRoleVM objRole)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objRole.Accion   , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objUser">Objeto de datos de MUserVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManageUsersMod(MUserVM objUser)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"    , DbType.Int32)  { Value = objUser.Accion   , Direction = ParameterDirection.Input  },
					new SqlParameter("@UserId"    , DbType.Int32)  { Value = objUser.UserId   , Direction = ParameterDirection.Input  },
					new SqlParameter("@UserName"  , DbType.String) { Value = objUser.UserName , Direction = ParameterDirection.Input  },
					new SqlParameter("@Password"  , DbType.String) { Value = objUser.Password , Direction = ParameterDirection.Input  },
					new SqlParameter("@Name"      , DbType.String) { Value = objUser.Name     , Direction = ParameterDirection.Input  },
					new SqlParameter("@LastName"  , DbType.String) { Value = objUser.LastName , Direction = ParameterDirection.Input  },
					new SqlParameter("@Enable"    , DbType.Boolean){ Value = objUser.Enabled  , Direction = ParameterDirection.Input  },
					new SqlParameter("@Email"     , DbType.String) { Value = objUser.Email    , Direction = ParameterDirection.Input  },
					new SqlParameter("@Img"       , DbType.Binary) { Value = objUser.Img      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Role"      , DbType.Int32)  { Value = objUser.RoleId   , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdPlanta"  , DbType.Int32)  { Value = objUser.IdPlanta , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdEmpresa" , DbType.Int32)  { Value = objUser.IdEmpresa, Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado" , DbType.Int32)  {                            Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objUser">Objeto de datos de MUserVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManagePasswordMod(MUserVM objUser)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"    , DbType.Int32)  { Value = objUser.Accion   , Direction = ParameterDirection.Input  },
					new SqlParameter("@UserId"    , DbType.Int32)  { Value = objUser.UserId   , Direction = ParameterDirection.Input  },
					new SqlParameter("@Password"  , DbType.String) { Value = objUser.Password , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado" , DbType.Int32)  {                            Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 03/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objLabel">Objeto de datos de MLabelVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetLanguagesMod(MLabelVM objLabel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objLabel.Accion   , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 03/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objLanguage">Objeto de datos de MLanguageVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetLangcodesMod(MLanguageVM objLanguage)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objLanguage.Accion   , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objRole">Objeto de datos de MRoleVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManageRolesMod(MRoleVM objRole)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"      , DbType.Int32)  { Value = objRole.Accion      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Role"        , DbType.Int32)  { Value = objRole.RoleID      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Code"        , DbType.String) { Value = objRole.Code        , Direction = ParameterDirection.Input  },
					new SqlParameter("@text"        , DbType.String) { Value = objRole.Description , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"   , DbType.Int32)  {                               Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 03/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objCompanie">Objeto de datos de MCompanieVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetCompaniesMod(MCompanieVM objCompanie)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"   , DbType.Int32)  { Value = objCompanie.Accion   , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 03/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objPlanta">Objeto de datos de MPlantaVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetPlantasMod(MPlantaVM objPlanta)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{
					new SqlParameter("@accion"    , DbType.Int32)  { Value = objPlanta.Accion         , Direction = ParameterDirection.Input},
					new SqlParameter("@IdEmpresa" , DbType.Int32)  { Value = objPlanta.Plan_IdEmpresa , Direction = ParameterDirection.Input},

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objPlanta">Objeto de datos de MPlantaVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManagePlantasMod(MPlantaVM objPlanta)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"      , DbType.Int32)  { Value = objPlanta.Accion           , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdPlanta"    , DbType.Int32)  { Value = objPlanta.Plan_IdPlanta    , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdEmpresa"   , DbType.Int32)  { Value = objPlanta.Plan_IdEmpresa   , Direction = ParameterDirection.Input  },
					new SqlParameter("@Name"        , DbType.String) { Value = objPlanta.Plan_Nombre      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Descripcion" , DbType.String) { Value = objPlanta.Plan_Descripcion , Direction = ParameterDirection.Input  },
					new SqlParameter("@Logo"        , DbType.String) { Value = objPlanta.Plan_Logo        , Direction = ParameterDirection.Input  },
					new SqlParameter("@URL"         , DbType.String) { Value = objPlanta.Plan_URL         , Direction = ParameterDirection.Input  },
					new SqlParameter("@Telefono"    , DbType.String) { Value = objPlanta.Plan_Telefono    , Direction = ParameterDirection.Input  },
					new SqlParameter("@Fax"         , DbType.String) { Value = objPlanta.Plan_Fax         , Direction = ParameterDirection.Input  },
					new SqlParameter("@CP"          , DbType.String) { Value = objPlanta.Plan_CP          , Direction = ParameterDirection.Input  },
					new SqlParameter("@Calle"       , DbType.String) { Value = objPlanta.Plan_Calle       , Direction = ParameterDirection.Input  },
					new SqlParameter("@Colonia"     , DbType.String) { Value = objPlanta.Plan_Colonia     , Direction = ParameterDirection.Input  },
					new SqlParameter("@Ciudad"      , DbType.String) { Value = objPlanta.Plan_Ciudad      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Email"       , DbType.String) { Value = objPlanta.Plan_Email       , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdUsuario"   , DbType.Int32)  { Value = objPlanta.IdUsuario        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"   , DbType.Int32)  {                                      Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objMenu">Objeto de datos de MMenuVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManageMenuMod(MMenuVM objMenu)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"      , DbType.Int32)  { Value = objMenu.Accion      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Id"          , DbType.Int32)  { Value = objMenu.Id          , Direction = ParameterDirection.Input  },
					new SqlParameter("@Item"        , DbType.String) { Value = objMenu.Item        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Parent"      , DbType.String) { Value = objMenu.Parent      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Type"        , DbType.Int32)  { Value = objMenu.Type        , Direction = ParameterDirection.Input  },
					new SqlParameter("@FunctionsId" , DbType.Int32)  { Value = objMenu.FunctionId  , Direction = ParameterDirection.Input  },
					new SqlParameter("@Property"    , DbType.String) { Value = objMenu.Property    , Direction = ParameterDirection.Input  },
					new SqlParameter("@text"        , DbType.String) { Value = objMenu.Descripcion , Direction = ParameterDirection.Input  },
					new SqlParameter("@Icon"        , DbType.String) { Value = objMenu.Icon        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"   , DbType.Int32)  {                               Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objCompanie">Objeto de datos de McompanieVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManageCompaniesMod(MCompanieVM objCompanie)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"      , DbType.Int32)   { Value = objCompanie.Accion      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Id"          , DbType.Int32)   { Value = objCompanie.Id          , Direction = ParameterDirection.Input  },
					new SqlParameter("@Code"        , DbType.String)  { Value = objCompanie.Code        , Direction = ParameterDirection.Input  },
					new SqlParameter("@RFC"         , DbType.String)  { Value = objCompanie.RFC         , Direction = ParameterDirection.Input  },
					new SqlParameter("@Name"        , DbType.String)  { Value = objCompanie.Name        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Enable"      , DbType.Boolean) { Value = objCompanie.Enabled     , Direction = ParameterDirection.Input  },
					new SqlParameter("@ShortName"   , DbType.String)  { Value = objCompanie.ShortName   , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdErp"       , DbType.String)  { Value = objCompanie.IdErp       , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdUsuario"   , DbType.Int32)   { Value = objCompanie.IdUsuario   , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"   , DbType.Int32)   {                                   Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 06/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objSetting">Objeto de datos de MSettingVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public int ManageSettingsMod(MSettingVM objSetting)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"      , DbType.Int32)   { Value = objSetting.Accion      , Direction = ParameterDirection.Input  },
					new SqlParameter("@Id"          , DbType.Int32)   { Value = objSetting.Id          , Direction = ParameterDirection.Input  },
					new SqlParameter("@Class"       , DbType.String)  { Value = objSetting.Class       , Direction = ParameterDirection.Input  },
					new SqlParameter("@Property"    , DbType.String)  { Value = objSetting.property    , Direction = ParameterDirection.Input  },
					new SqlParameter("@Value"       , DbType.String)  { Value = objSetting.value       , Direction = ParameterDirection.Input  },
					new SqlParameter("@RecordId"    , DbType.String)  { Value = objSetting.RecordId    , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"   , DbType.Int32)   {                                  Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}


        /// <summary>
        /// OCA 07/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
        /// </summary>
        /// <param name="objFunctions">Objeto de datos de MFunctionsVM</param>
        /// <returns>Nos retorna un DataTable como resultado</returns>
        public DataTable GetFunctionsMod(MFunctionsVM objFunctions)
        {
            try
            {
                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {

                    new SqlParameter("@accion"       , DbType.Int32)  { Value = objFunctions.Accion       , Direction = ParameterDirection.Input },
                    new SqlParameter("@FunctionsId"  , DbType.Int32)  { Value = objFunctions.FunctionsId  , Direction = ParameterDirection.Input }

                };
                dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                //objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }


        /// <summary>
        /// GFLT 07/05/2024  Este método consulta sobre SP_Menu
        /// </summary>
        /// <param name="objFunctions"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public int ManageFunction(MFunctionsVM objFunctions)
        {
            try
            {
                int resultado = 0;


                // Convertir la lista a JSON
                string opcionesSelectIDsJson = JsonConvert.SerializeObject(objFunctions.OpcionesSelectIDs);




                // Agregar todos los parámetros a la lista de parámetros
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FunctionsId"       , SqlDbType.Int)      { Value = objFunctions.FunctionsId  , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Label_Text"        , SqlDbType.NVarChar) { Value = objFunctions.Label_Text   , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Type"              , SqlDbType.Int)      { Value = objFunctions.Type         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Url"               , SqlDbType.NVarChar) { Value = objFunctions.Url          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@accion"            , SqlDbType.Int)      { Value = objFunctions.Accion       , Direction = ParameterDirection.Input  },
                    new SqlParameter("@OpcionesSelectIDs" , SqlDbType.NVarChar) { Value = opcionesSelectIDsJson     , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Resultado"         , SqlDbType.Int)      {                                     Direction = ParameterDirection.Output },
                    new SqlParameter("@Code"              , SqlDbType.NVarChar) { Value = objFunctions.Code         , Direction = ParameterDirection.Input  },
                };

                resultado = conexionBD.ObtenerRegistroSP("SP_Menu", parameters, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

		/// <summary>
		/// OCA 07/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objCatalog">Objeto de datos de MCatalogVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetCatalogTypesMod(MCatalogoTipoVM objCatalog)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{

					new SqlParameter("@accion"       , DbType.Int32)    { Value = objCatalog.Accion             , Direction = ParameterDirection.Input  },
					new SqlParameter("@Name"         , DbType.String)   { Value = objCatalog.Catt_Nombre        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Actualizable" , DbType.Boolean)  { Value = objCatalog.Catt_Actualizable  , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdUsuario"    , DbType.Int32)    { Value = objCatalog.IdUsuario          , Direction = ParameterDirection.Input  },

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// OCA 07/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objCatalog">Objeto de datos de MCatalogVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetCatalogOptionsMod(MCatalogoOpcionVM objCatalog)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{

					new SqlParameter("@accion"   , DbType.Int32)  { Value = objCatalog.Accion           , Direction = ParameterDirection.Input},
					new SqlParameter("@Id"       , DbType.Int32)  { Value = objCatalog.Catv_IdCatalogo  , Direction = ParameterDirection.Input},
				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}

		/// <summary>
		/// GFLT 07/05/2024  Este método consulta sobre SP_Menu
		/// </summary>
		/// <param name="objCatalog"></param>
		/// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
		public int ManageCatalogsMod(MCatalogoTipoVM objCatalog)
		{
			try
			{
				int resultado = 0;

				SqlParameter[] param =
				{
					new SqlParameter("@accion"       , DbType.Int32)    { Value = objCatalog.Accion             , Direction = ParameterDirection.Input  },
					new SqlParameter("@Id"           , DbType.Int32)    { Value = objCatalog.Catt_IdCatalogo    , Direction = ParameterDirection.Input  },
					new SqlParameter("@Name"         , DbType.String)   { Value = objCatalog.Catt_Nombre        , Direction = ParameterDirection.Input  },
					new SqlParameter("@Actualizable" , DbType.Boolean)  { Value = objCatalog.Catt_Actualizable  , Direction = ParameterDirection.Input  },
					new SqlParameter("@Opcion"       , DbType.String)   { Value = objCatalog.Opcion             , Direction = ParameterDirection.Input  },
					new SqlParameter("@Orden"        , DbType.Int32)    { Value = objCatalog.Orden              , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdOpcion"     , DbType.Int32)    { Value = objCatalog.IdCatalogoOpcion   , Direction = ParameterDirection.Input  },
					new SqlParameter("@IdUsuario"    , DbType.Int32)    { Value = objCatalog.IdUsuario          , Direction = ParameterDirection.Input  },
					new SqlParameter("@Resultado"    , DbType.Int32)    {                                         Direction = ParameterDirection.Output }
				};
				resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
				return resultado;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return 0;
			}
		}

		/// <summary>
		/// OCA 07/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
		/// </summary>
		/// <param name="objCarousel">Objeto de datos de MCatalogVM</param>
		/// <returns>Nos retorna un DataTable como resultado</returns>
		public DataTable GetCarouselMod(MCarouselVM objCarousel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();

				SqlParameter[] param =
				{

					new SqlParameter("@accion"       , DbType.Int32)    { Value = objCarousel.Accion             , Direction = ParameterDirection.Input  },

				};
				dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
				return dtConsulta;
			}
			catch (Exception ex)
			{
				//objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return null;
			}
		}


        /// <summary>
        /// GFLT 07/05/2024  Este método consulta sobre SP_Menu
        /// </summary>
        /// <param name="objCarousel"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public int ManageCarouselMod(MCarouselVM objCarousel)
        {
            try
            {
                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@accion"     , DbType.Int32)     { Value = objCarousel.Accion           , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Id"         , DbType.Int32)     { Value = objCarousel.Crsl_IdCarousel  , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Title"      , DbType.String)    { Value = objCarousel.Crsl_Title       , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Message"    , DbType.String)    { Value = objCarousel.Crsl_Message     , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Path"       , DbType.String)    { Value = objCarousel.Crsl_Img         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@DateStart"  , DbType.DateTime)  { Value = objCarousel.Crsl_DateStart   , Direction = ParameterDirection.Input  },
                    new SqlParameter("@DateEnd"    , DbType.DateTime)  { Value = objCarousel.Crsl_DateEnd     , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Resultado"  , DbType.Int32)     {                                        Direction = ParameterDirection.Output }
                };
                resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                //objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }

        /// <summary>
        /// OCA 07/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Menu
        /// </summary>
        /// <param name="objMessage">Objeto de datos de MMessagesVM</param>
        /// <returns>Nos retorna un DataTable como resultado</returns>
        public DataTable GetMessagesMod(MMessagesVM objMessage)
        {
            try
            {
                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
                {

                    new SqlParameter("@accion"        , DbType.Int32)    { Value = objMessage.Accion         , Direction = ParameterDirection.Input  },
                    new SqlParameter("@UserId1"       , DbType.Int32)    { Value = objMessage.UserId1        , Direction = ParameterDirection.Input  },
                    new SqlParameter("@UserId2"       , DbType.Int32)    { Value = objMessage.UserId2        , Direction = ParameterDirection.Input  },

                };
                dtConsulta = conexionBD.Fill_Tabla("SP_Menu", param);
                return dtConsulta;
            }
            catch (Exception ex)
            {
                //objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return null;
            }
        }

        /// <summary>
        /// GFLT 07/05/2024  Este método consulta sobre SP_Menu
        /// </summary>
        /// <param name="objMessage"></param>
        /// <returns>Un objeto DataTable que contiene los datos obtenidos si la solicitud es exitosa; de lo contrario, devuelve null.</returns>
        public int ManageConversationMod(MMessagesVM objMessage)
        {
            try
            {
                int resultado = 0;

                SqlParameter[] param =
                {
                    new SqlParameter("@accion"         , DbType.Int32)     { Value = objMessage.Accion           , Direction = ParameterDirection.Input  },
                    new SqlParameter("@IdConversation" , DbType.Int32)     { Value = objMessage.IdConversation   , Direction = ParameterDirection.Input  },
                    new SqlParameter("@UserId1"        , DbType.Int32)     { Value = objMessage.UserId1          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@UserId2"        , DbType.Int32)     { Value = objMessage.UserId2          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Content"        , DbType.String)    { Value = objMessage.Content          , Direction = ParameterDirection.Input  },
                    new SqlParameter("@Resultado"      , DbType.Int32)     {                                       Direction = ParameterDirection.Output }
                };
                resultado = conexionBD.ObtenerRegistroSP("SP_Menu", param, "@Resultado");
                return resultado;
            }
            catch (Exception ex)
            {
                //objBitacora.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/Repository/PML_Mod/DTConsultaAreas()", objAreasVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return 0;
            }
        }
    }
}
