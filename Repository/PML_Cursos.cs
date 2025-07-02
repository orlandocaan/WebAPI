using ApiBetaClientes.Class;
using BetaClientesVM.PML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiBetaClientes.Repository
{
    public class PML_Cursos
    {
        private readonly ApiConnectionDB conexionBD = new ApiConnectionDB(clsConnStrSQL.CnnStrSQLApiBetaClientes, CommandType.StoredProcedure);
        private readonly BitacoraErrores_Mod objBitacora = new BitacoraErrores_Mod();


        /// <summary>
        /// JGPJ 15/04/2024  Este Método nos permite realizar consultas sobre el StoredProcedure SP_Areas
        /// </summary>
        /// <param name="objCursosVM">Objeto de datos de PMLAreasVM</param>
        /// <returns>Nos retorna un DataTable como resultado</returns>
        public DataTable DTConsultaCursos(PMLCursosVM objCursosVM)
        {
            try
            {

                DataTable dtConsulta = new DataTable();

                SqlParameter[] param =
  {
    new SqlParameter("@Accion", SqlDbType.Int) { Value = objCursosVM.Accion, Direction = ParameterDirection.Input },
    new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = objCursosVM.IdUsuario, Direction = ParameterDirection.Input },
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
       new SqlParameter("@Cur_AreaNombre", SqlDbType.Int) { Value = objCursosVM.Cur_AreaNombre, Direction = ParameterDirection.Input }
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
    }
}