using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _361Example.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _361Example.Controllers
{
  
    public class GroceryListController : Controller
    {
        // Checks if a title is already being used for another list.
        public static void UserListTitleCheck(int userId, string title)
        {
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

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



        [HttpGet]
        public string TestFunction(string email)
        {
            return "Your email is: " + email;
        }

    }


    
}

