using ApiBetaClientes.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiBetaClientes.Repository
{
    public class BitacoraErrores_Mod
    {
        private readonly ApiConnectionDB connectionDB =  new ApiConnectionDB(clsConnStrSQL.CnnStrSQLApiBetaClientes, CommandType.StoredProcedure);


        /// <summary>
        /// JGPJ 15/04/2024 Método para insertar en la bitácora de errores
        /// </summary>
        /// <param name="reporteError">Representa la columna de REPORTE_ERROR</param>
        /// <param name="source">RepreseNta la columna SOURCE</param>
        /// <param name="userLogin">Representa la columna UserLogin</param>
        /// <param name="type">Representa la columna Type</param>
        /// <param name="receiver">Representa la columna RECEIVER</param>
        /// <returns></returns>
        public bool InsertarBitacoraErrores(string reporteError, string source, string userLogin, string type, string receiver)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Accion"       , DbType.Int32 ) { Value = 1            , Direction = ParameterDirection.Input},
                    new SqlParameter("@REPORTE_ERROR", DbType.String) { Value = reporteError , Direction = ParameterDirection.Input},
                    new SqlParameter("@SOURCE"       , DbType.String) { Value = source       , Direction = ParameterDirection.Input},
                    new SqlParameter("@USER_LOGIN"   , DbType.String) { Value = userLogin    , Direction = ParameterDirection.Input},
                    new SqlParameter("@TYPE"         , DbType.String) { Value = type         , Direction = ParameterDirection.Input},
                    new SqlParameter("@RECEIVER"     , DbType.String) { Value = receiver     , Direction = ParameterDirection.Input},
                    new SqlParameter("@Resultado"    , DbType.Int32)  {                        Direction = ParameterDirection.Output}

                };

                return connectionDB.ObtenerRegistroSP("SP_BITACORA_ERRORES", param, "@Resultado") == 0 ? false : true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }






    }
}