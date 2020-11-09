using Group4_Online_Grocery_List_Application.Data;
using Group4_Online_Grocery_List_Application.Engine;
using Group4_Online_Grocery_List_Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Online_Grocery_List_Application.Accessors
{
    public class ItemAccessor
    {
        //Gets the itemId from the database.
        public static int GetItemId(int listId, string name)
        {
            int itemId = 0;

            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT itemId FROM dbo.Items WHERE listId = @Id AND itemName = @name";

                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);
                    SqlParameter namePar = new SqlParameter("@Name", SqlDbType.VarChar, 255);

                    idPar.Value = listId;
                    namePar.Value = name;

                    query.Parameters.Add(idPar);
                    query.Parameters.Add(namePar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        itemId = (int)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return itemId;
        }

        //Get the item Name
        public static string GetItemName(int listID, int itemID)
        {
            string itemName = "";

            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT itemName FROM dbo.Items WHERE listId = @ID AND itemId = @itemID";

                    SqlParameter IDPar = new SqlParameter("@ID", SqlDbType.Int, 255);
                    SqlParameter itemIDPar = new SqlParameter("@itemID", SqlDbType.VarChar, 255);

                    IDPar.Value = listID;
                    itemIDPar.Value = itemID;

                    query.Parameters.Add(IDPar);
                    query.Parameters.Add(itemIDPar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        itemName = (string)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return itemName;
        }

        //Get the item quantity
        public static int GetItemQuantity(int listID, int itemID, string itemName)
        {
            if (GetItemId(listID, itemName) != itemID)
            {
                throw new System.InvalidOperationException("Invalid data. Incorrect itemID");
            }

            int itemQuantity = 0;

            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT quantity FROM dbo.Items WHERE listId = @ID AND itemId = @itemID";

                    SqlParameter IDPar = new SqlParameter("@ID", SqlDbType.Int, 255);
                    SqlParameter itemIDPar = new SqlParameter("@itemID", SqlDbType.VarChar, 255);

                    IDPar.Value = listID;
                    itemIDPar.Value = itemID;

                    query.Parameters.Add(IDPar);
                    query.Parameters.Add(itemIDPar);

                    query.Prepare();
                    var temp = query.ExecuteScalar();


                    if (temp != null)
                    {
                        itemQuantity = (int)temp;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return itemQuantity;
        }

        //Will add a new item to a users lists in the the database.
        public static void AddItemToList(string name, int quantity, int listId)
        {
            GroceryItemsEngine.ItemValidityCheck(name, quantity);

            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "INSERT INTO dbo.Items(itemName, quantity, listId) VALUES (@name, @quantity, @Id)";

                    SqlParameter namePar = new SqlParameter("@name", SqlDbType.VarChar, 255);
                    SqlParameter quantityPar = new SqlParameter("@quantity", SqlDbType.Int, 255);
                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    namePar.Value = name;
                    quantityPar.Value = quantity;
                    idPar.Value = listId;

                    query.Parameters.Add(namePar);
                    query.Parameters.Add(quantityPar);
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

        //Will update a current item in a list in the database.
        public static void UpdateItemInList(int itemId, string newName, int newQuantity)
        {
            GroceryItemsEngine.ItemValidityCheck(newName, newQuantity);

            try
            {

                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "UPDATE dbo.Items SET itemName = @name, quantity = @quantity WHERE itemId = @Id;";

                    SqlParameter namePar = new SqlParameter("@name", SqlDbType.VarChar, 255);
                    SqlParameter quantityPar = new SqlParameter("@quantity", SqlDbType.Int, 255);
                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    namePar.Value = newName;
                    quantityPar.Value = newQuantity;
                    idPar.Value = itemId;

                    query.Parameters.Add(namePar);
                    query.Parameters.Add(quantityPar);
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

        //Removes a item that is connecto a list in the database.
        public static void RemoveItemFromList(int itemId)
        {
            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "DELETE FROM Items WHERE itemId = @Id;";


                    SqlParameter idPar = new SqlParameter("@Id", SqlDbType.Int, 255);

                    idPar.Value = itemId;

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

        public static List<GroceryItem> GetAllGroceryItems(string email, string title)
        {
            Debug.WriteLine(email);
            Debug.WriteLine(title);

            List <GroceryItem> list = new List<GroceryItem>();

            try
            {
                SqlConnectionStringBuilder builder = Database.ConnectionBuilder();


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();
                    SqlCommand query = new SqlCommand(null, connection);

                    query.CommandText = "SELECT itemName, quantity FROM dbo.Items join dbo.Grocery_List on dbo.Items.listId = dbo.Grocery_List.listId join dbo.End_User on dbo.Grocery_List.userId = dbo.End_User.userId WHERE dbo.End_User.Email = @email And dbo.Grocery_List.title = @title";


                    SqlParameter emailPar = new SqlParameter("@email", SqlDbType.VarChar, 255);
                    SqlParameter titlePar = new SqlParameter("@title", SqlDbType.VarChar, 255);

                    emailPar.Value = email;
                    titlePar.Value = title;

                    query.Parameters.Add(emailPar);
                    query.Parameters.Add(titlePar);

                    query.Prepare();
                    SqlDataReader reader = query.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GroceryItem item = new GroceryItem(reader[0].ToString(),(int) reader[1]);

                            list.Add(item);

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

            return list;
        }

    }
}
