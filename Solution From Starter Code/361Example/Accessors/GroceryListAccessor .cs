using _361Example.Controllers;
using Accessors;
using javax.jws;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace _361Example.Accessors
{
    public class GroceryListAccessor
    {
        //Gets the listId from the SQL database.
        public static int GetListId(int userId, string title)
        {
            int listId = 0;

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
                        listId = (int)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }


            return listId;
        }
        //Get list title
        public static string GetListTitle(int userID, int listID)
        {
            string listTitle = "";
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT title FROM dbo.Grocery_List WHERE userId = @ID AND listId = @listID";

                    SqlParameter IDPar = new SqlParameter("@ID", SqlDbType.Int, 255);
                    SqlParameter listIDPar = new SqlParameter("@listID", SqlDbType.VarChar, 255);

                    IDPar.Value = userID;
                    listIDPar.Value = listID;

                    query.Parameters.Add(IDPar);
                    query.Parameters.Add(listIDPar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        listTitle = (string)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return listTitle;
        }

        //Get list location
        public static string GetListLocation(int userID, string listTitle, int listID)
        {
            if (GetListId(userID, listTitle) != listID)
            {
                throw new System.InvalidOperationException("Invalid data. Incorrect listID");
            }

            string listLocation = "";
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT locationSite FROM dbo.Grocery_List WHERE userId = @ID AND listId = @listID";

                    SqlParameter IDPar = new SqlParameter("@ID", SqlDbType.Int, 255);
                    SqlParameter listIDPar = new SqlParameter("@listID", SqlDbType.VarChar, 255);

                    IDPar.Value = userID;
                    listIDPar.Value = listID;

                    query.Parameters.Add(IDPar);
                    query.Parameters.Add(listIDPar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        listLocation = (string)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return listLocation;
        }

        //Get list last updated time
        public static DateTime GetListLastUpdatedTime(int userID, string listTitle, int listID)
        {
            if (GetListId(userID, listTitle) != listID)
            {
                throw new System.InvalidOperationException("Invalid data. Incorrect listID");
            }

            DateTime lastUpdate = DateTime.Now;
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT dateCreated FROM dbo.Grocery_List WHERE userId = @ID AND listId = @listID";

                    SqlParameter IDPar = new SqlParameter("@ID", SqlDbType.Int, 255);
                    SqlParameter listIDPar = new SqlParameter("@listID", SqlDbType.VarChar, 255);

                    IDPar.Value = userID;
                    listIDPar.Value = listID;

                    query.Parameters.Add(IDPar);
                    query.Parameters.Add(listIDPar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        lastUpdate = (DateTime)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return lastUpdate;
        }

        //Adds a new list to the SQL database.
        public static void AddList(string title, string location, DateTime date, int userId)
        {
            GroceryListController.UserListTitleCheck(userId, title);
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "INSERT INTO dbo.Grocery_List(title, locationSite, dateCreated, userId) VALUES (@title, @location, @date, @Id)";

                    SqlParameter titlePar = new SqlParameter("@title", SqlDbType.VarChar, 255);
                    SqlParameter locationPar = new SqlParameter("@location", SqlDbType.VarChar, 255);
                    SqlParameter datePar = new SqlParameter("@date", SqlDbType.DateTime, 255);
                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    titlePar.Value = title;
                    locationPar.Value = location;
                    datePar.Value = date;
                    idPar.Value = userId;

                    query.Parameters.Add(titlePar);
                    query.Parameters.Add(locationPar);
                    query.Parameters.Add(datePar);
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

        //Updates a exixsting list in the SQL database.
        public static void UpdateList(int userId, int listId, string currentTitle, string newTitle, string newLocation)
        {
            if (GetListId(userId, currentTitle) != listId)
            {
                throw new System.InvalidOperationException("Invalid data. Incorrect listId");
            }


            GroceryListController.UserListTitleCheck(userId, newTitle);


            try
            {

                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "UPDATE dbo.Grocery_List SET title = @title, locationSite = @location, dateCreated = @date WHERE listId = @Id;";

                    SqlParameter titlePar = new SqlParameter("@title", SqlDbType.VarChar, 255);
                    SqlParameter locationPar = new SqlParameter("@location", SqlDbType.VarChar, 255);
                    SqlParameter datePar = new SqlParameter("@date", SqlDbType.VarChar, 255);

                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    titlePar.Value = newTitle;
                    locationPar.Value = newLocation;
                    datePar.Value = DateTime.Now;
                    idPar.Value = userId;

                    query.Parameters.Add(titlePar);
                    query.Parameters.Add(locationPar);
                    query.Parameters.Add(datePar);
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

        ////Removes a exixsting list in the SQL database.
        public static void DeleteList(int listId)
        {
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "DELETE FROM dbo.Grocery_List WHERE listId = @Id;";


                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    idPar.Value = listId;

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

        [WebMethod]
        public static string GetAllLists(string email)
        {
            int userId = UserAccessor.GetUserID(email);
            string[][] jaggedArray = new string[100][];
            string yeet = "";
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT title, locationSite, dateCreated FROM dbo.Grocery_List WHERE userId = @Id";

                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    idPar.Value = userId;

                    query.Parameters.Add(idPar);

                    query.Prepare();
                    var temp = query.ExecuteReader();


                    if (temp != null)
                    {
                        foreach (int i in temp)
                        {
                            //jaggedArray[i][] = temp;

                        }
                        Console.WriteLine(temp);
                        yeet = temp.ToString();
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            yeet = "The usersname is" + email;
            return yeet;

        }


    }
}


        
