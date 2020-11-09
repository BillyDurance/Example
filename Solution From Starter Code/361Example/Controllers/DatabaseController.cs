using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Controllers
{
    public class DatabaseController
    {
        public static SqlConnectionStringBuilder ConnectionBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "group4database.database.windows.net";
            builder.UserID = "admin2020";
            builder.Password = "P@$$w0rd";
            builder.InitialCatalog = "Group4_SQL_Database";

            return builder;
        }
    }
}
