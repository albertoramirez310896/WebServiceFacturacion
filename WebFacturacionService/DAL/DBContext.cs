using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebFacturacionService.DataAccessLayer
{
    public static class DBContext
    {
        public static string getConnectionString() {
            var environmentConnectionString = Environment.GetEnvironmentVariable("MyLocalConnection", EnvironmentVariableTarget.User);
            var connectionString = !string.IsNullOrEmpty(environmentConnectionString) ? environmentConnectionString : ConfigurationManager.ConnectionStrings["FacturacionConnection"].ConnectionString;
            
            return connectionString;
        }
    }
}