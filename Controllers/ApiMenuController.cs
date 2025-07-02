using ApiBetaClientes.Repository;
using BetaClientesVM.Menu;
using BetaClientesVM.PML;
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
    public class ApiMenuController : ApiController
    {
		private readonly Menu_Mod objMenuMod = new Menu_Mod();
		private readonly ApiDatosController objDatos = new ApiDatosController();
		/// <summary>
		/// OCA - 24/04/2024 Método que nos permite realizar consultas sobre la tabla Settings
		/// </summary>
		/// <param name="objSetting">Objeto de datos de MSettingsVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/GetSettings")]
		public IHttpActionResult GetSetting(MSettingVM objSetting)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetSettingsMod(objSetting);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 25/04/2024 Método que nos permite realizar consultas sobre la tabla de Label
		/// </summary>
		/// <param name="objLabel">Objeto de datos de MLabelVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/GetSupportedLanguages")]
		public IHttpActionResult GetSupportedLanguages(MLabelVM objLabel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetSupportedLanguagesMod(objLabel);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		///// <summary>
		///// OCA - 02/04/2024 Método que nos permite realizar consultas sobre la tabla de Languages
		///// </summary>
		///// <param name="objLang">Objeto de datos de MLanguageVM</param>
		///// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		//[System.Web.Http.HttpPost]
		//[System.Web.Http.Route("api/ApiMenu/GetLanguages")]
		//public IHttpActionResult GetLanguages(MLanguageVM objLang)
		//{
		//	try
		//	{
		//		DataTable dtConsulta = new DataTable();
		//		dtConsulta = objMenuMod.GetLanguagesMod(objLang);
		//		return Ok(dtConsulta);
		//	}
		//	catch (Exception ex)
		//	{
		//		//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
		//		return InternalServerError(ex);
		//	}
		//}

		///// <summary>
		///// OCA - 02/04/2024 Método que nos permite realizar consultas sobre la tabla de Label
		///// </summary>
		///// <param name="objLabel">Objeto de datos de MLabelVM</param>
		///// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		//[System.Web.Http.HttpPost]
		//[System.Web.Http.Route("api/ApiMenu/GetLangCodes")]
		//public IHttpActionResult GetLangCodes(MLabelVM objLabel)
		//{
		//	try
		//	{
		//		DataTable dtConsulta = new DataTable();
		//		dtConsulta = objMenuMod.GetLangCodesMod(objLabel);
		//		return Ok(dtConsulta);
		//	}
		//	catch (Exception ex)
		//	{
		//		//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
		//		return InternalServerError(ex);
		//	}
		//}

		/// <summary>
		/// OCA - 02/04/2024 Método que nos permite realizar consultas sobre la tabla de Label
		/// </summary>
		/// <param name="objLabel">Objeto de datos de MLabelVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/GetLabelLang")]
		public IHttpActionResult GetLabelLang(MLabelVM objLabel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetLabelLangMod(objLabel);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 02/04/2024 Método que nos permite realizar consultas sobre la tabla de Label
		/// </summary>
		/// <param name="objMenu">Objeto de datos de MLabelVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/GetDataMenu")]
		public IHttpActionResult GetDataMenu(MMenuVM objMenu)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetDataMenuMod(objMenu);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de users
		/// </summary>
		/// <param name="objUser">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/GetUsers")]
		public IHttpActionResult GetUsers(MUserVM objUser)
		{
			try
			{
				List<MUserVM> users = new List<MUserVM>();
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetUsersMod(objUser);
				if (dtConsulta != null && dtConsulta.Rows.Count > 0)
				{
					users = dtConsulta.AsEnumerable()
								   .Select(dataRow => new MUserVM
								   {
									   UserId = Convert.ToInt32(dataRow.Field<object>("UserId") ?? 0),
									   UserName = dataRow.Field<string>("UserName"),
									   Password = dataRow.Field<string>("Password"),
									   Name = dataRow.Field<string>("Name"),
									   LastName = dataRow.Field<string>("LastName"),
									   Email = dataRow.Field<string>("Email"),
									   Img = dataRow.Field<byte[]>("Img") ?? new byte[0],
									   Enabled = Convert.ToBoolean(dataRow.Field<object>("Enabled") ?? false),
									   FirstLogin = Convert.ToBoolean(dataRow.Field<object>("FirstLogin") ?? false),
									   RoleId = Convert.ToInt32(dataRow.Field<object>("RoleId") ?? 0),
									   Code = dataRow.Table.Columns.Contains("Code") ? dataRow.Field<string>("Code") : null,
									   IdEmpresa = dataRow.Table.Columns.Contains("IdEmpresa") ? Convert.ToInt32(dataRow.Field<object>("IdEmpresa") ?? 0) : 0,
									   IdPlanta = dataRow.Table.Columns.Contains("IdPlanta") ? Convert.ToInt32(dataRow.Field<object>("IdPlanta") ?? 0) : 0
								   }).ToList();
				}
				return Ok(users);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objRoleVM">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetRoles")]
		public IHttpActionResult GetRoles(MRoleVM objRoleVM)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetRolesMod(objRoleVM);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de users
		/// </summary>
		/// <param name="objMenu">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManageUsers")]
		public IHttpActionResult ManageUsers(MUserVM objUser)
		{
			try
			{
				
				int resultado = 0;
				resultado = objMenuMod.ManageUsersMod(objUser);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 08/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objLabelVM">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetLanguages")]
		public IHttpActionResult GetLanguages(MLabelVM objLabelVM)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetLanguagesMod(objLabelVM);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 08/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objLanguage">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetLangcodes")]
		public IHttpActionResult GetLangcodes(MLanguageVM objLanguage)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetLangcodesMod(objLanguage);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}


		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de users
		/// </summary>
		/// <param name="objUser">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManagePassword")]
		public IHttpActionResult ManagePassword(MUserVM objUser)
		{
			try
			{
				string password = EncriptarPassword(objUser.Password);
				objUser.Password = password;
				int resultado = 0;
				resultado = objMenuMod.ManagePasswordMod(objUser);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
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

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de users
		/// </summary>
		/// <param name="objRole">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManageRoles")]
		public IHttpActionResult ManageRoles(MRoleVM objRole)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManageRolesMod(objRole);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objCompanie">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetCompanies")]
		public IHttpActionResult GetCompanies(MCompanieVM objCompanie)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetCompaniesMod(objCompanie);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objPlanta">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetPlantas")]
		public IHttpActionResult GetPlantas(MPlantaVM objPlanta)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetPlantasMod(objPlanta);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de users
		/// </summary>
		/// <param name="objPlanta">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManagePlantas")]
		public IHttpActionResult ManagePlantas(MPlantaVM objPlanta)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManagePlantasMod(objPlanta);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de users
		/// </summary>
		/// <param name="objMenu">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManageMenu")]
		public IHttpActionResult ManageMenu(MMenuVM objMenu)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManageMenuMod(objMenu);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Comapanies
		/// </summary>
		/// <param name="objCompanie">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManageCompanies")]
		public IHttpActionResult ManageCompanies(MCompanieVM objCompanie)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManageCompaniesMod(objCompanie);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Comapanies
		/// </summary>
		/// <param name="objCompanie">Objeto de datos de MUserVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[System.Web.Http.HttpPost]
		[System.Web.Http.Route("api/ApiMenu/ManageSettings")]
		public IHttpActionResult ManageSettings(MSettingVM objSetting)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManageSettingsMod(objSetting);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}


        /// <summary>
        /// GFLT - 06/05/2024 Método que nos permite realizar consultas sobre la tabla de Functions 
        /// </summary>
        /// <param name="objFunctionsVM">Objeto de datos de MFunctionsVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiMenu/GetFunctions")]
        public IHttpActionResult GetFunctions(MFunctionsVM objFunctionsVM)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objMenuMod.GetFunctionsMod(objFunctionsVM);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                //objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/GetFunctions()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// GFLT - 06/05/2024 Este método se encarga de gestionar las operaciones de inserción, actualización y eliminación de la tabla Functions, Permissions, Labels.
        /// </summary>
        /// <param name="objFunctionsVM">Objeto de datos de objFunctionsVM</param>
        /// <returns>Nos retorna un valor entero (0 si ocurre un error, 1 si solicitud es exitosa o el id insertado)</returns>
        [HttpPost]
        [Route("api/ApiMenu/ManageFunction")]
        public IHttpActionResult ManageFunction(MFunctionsVM objFunctionsVM)
        {
            try
            {
                int resultado = 0;
                resultado = objMenuMod.ManageFunction(objFunctionsVM);
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objCatalog">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetCatalogTypes")]
		public IHttpActionResult GetCatalogTypes(MCatalogoTipoVM objCatalog)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetCatalogTypesMod(objCatalog);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objCatalog">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetCatalogOptions")]
		public IHttpActionResult GetCatalogOptions(MCatalogoOpcionVM objCatalog)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetCatalogOptionsMod(objCatalog);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Catalogos
		/// </summary>
		/// <param name="objCatalog">Objeto de datos de MCatalogoTipoVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/ManageCatalogs")]
		public IHttpActionResult ManageCatalogs(MCatalogoTipoVM objCatalog)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManageCatalogsMod(objCatalog);
				return Ok(resultado);
			}
			catch (Exception ex)
			{

				return InternalServerError(ex);
			}
		}


		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objCatalog">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/InsertCatalogType")]
		public IHttpActionResult InsertCatalogType(MCatalogoTipoVM objCatalog)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetCatalogTypesMod(objCatalog);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Roles
		/// </summary>
		/// <param name="objCarousel">Objeto de datos de MRoleVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/GetCarousel")]
		public IHttpActionResult GetCarousel(MCarouselVM objCarousel)
		{
			try
			{
				DataTable dtConsulta = new DataTable();
				dtConsulta = objMenuMod.GetCarouselMod(objCarousel);
				return Ok(dtConsulta);
			}
			catch (Exception ex)
			{
				//objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
				return InternalServerError(ex);
			}
		}

		/// <summary>
		/// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Catalogos
		/// </summary>
		/// <param name="objCarousel">Objeto de datos de MCatalogoTipoVM</param>
		/// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
		[HttpPost]
		[Route("api/ApiMenu/ManageCarousel")]
		public IHttpActionResult ManageCarousel(MCarouselVM objCarousel)
		{
			try
			{
				int resultado = 0;
				resultado = objMenuMod.ManageCarouselMod(objCarousel);
				return Ok(resultado);
			}
			catch (Exception ex)
			{

				return InternalServerError(ex);
			}
		}

        /// <summary>
        /// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Messages
        /// </summary>
        /// <param name="objMessage">Objeto de datos de MMessageVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiMenu/GetMessages")]
        public IHttpActionResult GetMessages(MMessagesVM objMessage)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = objMenuMod.GetMessagesMod(objMessage);
                return Ok(dtConsulta);
            }
            catch (Exception ex)
            {
                //objBitacoraMod.InsertarBitacoraErrores(ex.Message, "ApiBetaClientes/ApiPMLController/DTConsultaPuestos()", objPuestosVM.IdUsuario.ToString(), "Error", "ApiBetaClientes");
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// OCA - 03/04/2024 Método que nos permite realizar consultas sobre la tabla de Catalogos
        /// </summary>
        /// <param name="objMessage">Objeto de datos de MCatalogoTipoVM</param>
        /// <returns>Retorna un objeto IHttpActionResult con un DataTable si no hay errores. En caso de error, retorna un mensaje de error.</returns>
        [HttpPost]
        [Route("api/ApiMenu/ManageConversation")]
        public IHttpActionResult ManageConversation(MMessagesVM objMessage)
        {
            try
            {
                int resultado = 0;
                resultado = objMenuMod.ManageConversationMod(objMessage);
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
