using System.Data.SqlClient;

namespace Group4_Online_Grocery_List_Application.Data
{
    public class Database
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
