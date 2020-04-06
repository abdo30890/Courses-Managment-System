using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.Web.Models.ConnectionTools
{
    public class ConnectionString
    {
        public static string Connection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = @".\SQLEXPRESS",
                IntegratedSecurity = true,
                InitialCatalog = "Cms",
                ApplicationName = "Course Managment System Web Application"
            };
            return builder.ConnectionString;

        }
    }
}