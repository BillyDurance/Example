using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Group4_Online_Grocery_List_Application.Controllers;
using Group4_Online_Grocery_List_Application.Data;
using Group4_Online_Grocery_List_Application.Engine;

namespace Group4_Online_Grocery_List_Application.Accessors
{
    public class UserAccessor
    {
        //Gets the userId from the SQL databse.
        public static int GetUserID(string email)
        {
            int userId = 0;
            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT userId FROM dbo.End_User WHERE email = @email";

                    SqlParameter emailPar = new SqlParameter("@email", SqlDbType.VarChar, 255);

                    emailPar.Value = email;

                    query.Parameters.Add(emailPar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        userId = (int)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return userId;
        }


        //Will add a new user to the SQL database.
        public static void AddUser(string email, string password)
        {
            //Checks to make sure the new data is valid
            UserEngine.EmailValidityCheck(email, password);

            //check to see if that email is in the database.
            if (GetUserID(email) > 0)
            {
                throw new System.InvalidOperationException("Invalid data. email is taken.");
            }


            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "INSERT INTO dbo.End_User(email, passwordValue) VALUES (@email, @password)";

                    SqlParameter emailPar = new SqlParameter("@email", SqlDbType.VarChar, 255);
                    SqlParameter passwordPar = new SqlParameter("@password", SqlDbType.VarChar, 255);

                    emailPar.Value = email;
                    passwordPar.Value = password;

                    query.Parameters.Add(emailPar);
                    query.Parameters.Add(passwordPar);

                    query.Prepare();
                    query.ExecuteNonQuery();


                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return;
        }

        //Updates a current user in the SQL database.
        public static void UpdateUser(string currentEmail, string newEmail, string NewPassword, int userId)
        {
            if (GetUserID(currentEmail) != userId)
            {
                throw new System.InvalidOperationException("Invalid data. Incorrect userId");
            }

            //Checks to make sure the new data is valid.
            UserEngine.EmailValidityCheck(newEmail, NewPassword);

            try
            {

                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "UPDATE dbo.End_User SET email = @email, passwordValue = @password WHERE userID = @Id;";

                    SqlParameter emailPar = new SqlParameter("@email", SqlDbType.VarChar, 255);
                    SqlParameter passwordPar = new SqlParameter("@password", SqlDbType.VarChar, 255);
                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    emailPar.Value = newEmail;
                    passwordPar.Value = NewPassword;
                    idPar.Value = userId;

                    query.Parameters.Add(emailPar);
                    query.Parameters.Add(passwordPar);
                    query.Parameters.Add(idPar);

                    query.Prepare();
                    query.ExecuteNonQuery();


                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return;
        }

        //Will remove a existing user in the database.
        public static void RemoveUser(int userId)
        {
            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "DELETE FROM End_User WHERE userId = @Id;";


                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    idPar.Value = userId;

                    query.Parameters.Add(idPar);

                    query.Prepare();
                    query.ExecuteNonQuery();


                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return;
        }
    }
}
