using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ApiBetaClientes.Class
{
    public class clsConnStrSQL
    {
        public static string CnnStrSQLApiBetaClientes
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ApiBetaConnectionString"].ConnectionString;
            }
        }

    }
}