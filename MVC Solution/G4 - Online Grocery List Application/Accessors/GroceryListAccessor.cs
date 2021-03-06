﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Group4_Online_Grocery_List_Application.Data;
using Group4_Online_Grocery_List_Application.Engine;
using Group4_Online_Grocery_List_Application.Models;

namespace Group4_Online_Grocery_List_Application.Accessors
{
    public class GroceryListAccessor
    {

        //Gets the listId from the SQL database.
        public static int GetListId(int userId, string title)
        {
            int listId = 0;

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
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

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
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

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
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

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
            GroceryListEngine.UserListTitleCheck(userId, title);

            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

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


            GroceryListEngine.UserListTitleCheck(userId, newTitle);


            try
            {

                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


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

        //Removes a exixsting list in the SQL database.
        public static void DeleteList(int listId)
        {
            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


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

      
        public static List<GroceryList> GetAllLists(string email)
        {
            List<GroceryList> GroceryListsList = new List<GroceryList>();
            
            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    //query.CommandText = "SELECT title, locationSite, dateCreated FROM dbo.Grocery_List WHERE userId = @Id";
                    query.CommandText = "SELECT title, locationSite, dateCreated FROM dbo.Grocery_List join dbo.End_User on dbo.Grocery_List.userId = dbo.End_User.userId  WHERE dbo.End_User.Email = @Email";

                    SqlParameter emailPar = new SqlParameter("@Email", SqlDbType.VarChar, 255);

                    emailPar.Value = email;

                    query.Parameters.Add(emailPar);

                    query.Prepare();
                    SqlDataReader reader = query.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GroceryList tempList = new GroceryList(reader[0].ToString(), reader[1].ToString(), email, (DateTime)reader[2]);

                            GroceryListsList.Add(tempList);
                          
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No rows found.");
                    }
                    reader.Close();



                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            
            return GroceryListsList;

        }
    }
}
