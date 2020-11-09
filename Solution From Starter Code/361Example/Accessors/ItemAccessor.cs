using _361Example.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _361Example.Accessors
{
    public class ItemAccessor
    {
        //Gets the itemId from the database.
        public static int GetItemId(int listId, string name)
        {
            int itemId = 0;

            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

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
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

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
            if(GetItemId(listID, itemName) != itemID)
            {
                throw new System.InvalidOperationException("Invalid data. Incorrect itemID");
            }

            int itemQuantity = 0;

            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

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
            GroceryItemsController.ItemValidityCheck(name, quantity);
           
            try
            {
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();

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
            GroceryItemsController.ItemValidityCheck(newName, newQuantity);

            try
            {

                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();


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
                SqlConnectionStringBuilder builder = DatabaseController.ConnectionBuilder();


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
    }
}
