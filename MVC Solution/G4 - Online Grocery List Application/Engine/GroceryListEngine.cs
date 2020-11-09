using Group4_Online_Grocery_List_Application.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Group4_Online_Grocery_List_Application.Engine
{
    public class GroceryListEngine
    {
        public static void EmailCheck(int databaseID, string newEmail, string newPassword)
        {
            if (newEmail == "")
            {
                throw new System.InvalidOperationException("Invalid data. Can not null as a email.");
            }

            //Check for bad email
            Regex rgx = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");

            if (!rgx.IsMatch(newEmail))
            {
                throw new System.InvalidOperationException("Invalid data. Not a valid email.");
            }

        }


        public static void UserListTitleCheck(int userId, string title)
        {
            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT listId FROM dbo.Grocery_List WHERE userId = @Id AND title = @tile";

                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);
                    SqlParameter titlePar = new SqlParameter("@tile", SqlDbType.VarChar, 255);

                    idPar.Value = userId;
                    titlePar.Value = title;

                    query.Parameters.Add(idPar);
                    query.Parameters.Add(titlePar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        throw new System.InvalidOperationException("Invalid data. Taken title.");
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
