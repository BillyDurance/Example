using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _361Example.Models;

namespace groceryListNS
{
    public class UserEngine
    {
 


        public string title { get; set; }

        public string location { get; set; }

        public string email { get; set; }

        public DateTime dateUpdated { get; set; }

        public Dictionary<int, string> itemsDict { get; set; }

        public Dictionary<int, int> qytDict { get; set; }

        /*
        public static groceryList getGroceryList(int DBid)
        {
            for (int i = 0; i < database_dict.Count() - 1; i++)
            {
                if (DBid == i)
                {
                    return database_dict[i];
                }
            }
            return null;
        }

        public groceryList(string title, string location, string email, DateTime dateUpdated, Dictionary<int, string> itemsDict, Dictionary<int, int> qytDict)
        {
            if (title == "" || location == "" || email == "")
            {
                throw new System.InvalidOperationException("Invalid data. Can not have a null value for title, location, or email");
            }

            if (itemsDict.Count() == 0 || qytDict.Count() == 0)
            {
                throw new System.InvalidOperationException("Invalid data. Can not have a null value for your list class");
            }

            this.title = title;
            this.location = location;
            this.email = email;
            this.dateUpdated = dateUpdated;
            this.itemsDict = itemsDict;
            this.qytDict = qytDict;
        }

        public static void addToDB(groceryList templist)
        {

            int size = database_dict.Count;

            for (int i = 0; i < size; i++)
            {

                if ((templist.email == database_dict[i].email) && (templist.title == database_dict[i].title))
                {
                    throw new System.InvalidOperationException("Invalid data. Can not have multiple lists with the same name.");
                }
            }


            database_dict.Add(size, templist);
            return;
        }

        public static void editTitle(groceryList templist, int databaseID, string newTitle)
        {
            if (newTitle == "")
            {
                throw new System.InvalidOperationException("Invalid data. Can not null as a title.");
            }


            for (int i = 0; i < database_dict.Count(); i++)
            {
                if ((templist.email == database_dict[i].email) && (newTitle == database_dict[i].title))
                {
                    throw new System.InvalidOperationException("Invalid data. Can not have multiple lists with the same name.");
                }
            }

            templist.title = newTitle;
            database_dict[databaseID] = templist;
        }

        //Edit Location
        public static void UpdateLocation(groceryList templist, int databaseID, string location)
        {
            if (location == null | location == "")
            {
                templist.location = "None";
                database_dict[databaseID] = templist;
                return;
            }
            templist.location = location;
            database_dict[databaseID] = templist;
        }

        public static void editEmail(groceryList templist, int databaseID, string newEmail)
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



            for (int i = 0; i < database_dict.Count(); i++)
            {
                if ((newEmail == database_dict[i].title))
                {
                    throw new System.InvalidOperationException("Invalid data. Can not have multiple emails with the same name.");
                }
            }

            templist.email = newEmail;
            database_dict[databaseID] = templist;
        }



        public static void editTime(groceryList templist, int databaseID, DateTime newTime)
        {

            TimeSpan timediff = newTime.Subtract(DateTime.Now).Duration();
            TimeSpan shortTime = new TimeSpan(0, 0, 1, 0);

            if (timediff > shortTime)
            {
                throw new System.InvalidOperationException("Invalid data. The time can not be anything but now.");
            }



            templist.dateUpdated = newTime;
            database_dict[databaseID] = templist;
        }




        public static void updateListItems(groceryList templist, Dictionary<int, string> newDict, int databaseID)
        {
            if (database_dict[databaseID].email != templist.email)
            {
                throw new System.InvalidOperationException("Invalid acces. The databaseID given is not the same as the one trying to be changed.");
            }

            if (database_dict[databaseID].title != templist.title)
            {
                throw new System.InvalidOperationException("Invalid acces. The databaseID given is not the same as the one trying to be changed.");
            }

            if (newDict.Count() == 0)
            {
                throw new System.InvalidOperationException("Invalid data. The item list can not be null.");
            }

            for (int i = 0; i < newDict.Count(); i++)
            {
                if (newDict[i] == "")
                {
                    throw new System.InvalidOperationException("Invalid data. A item in your list can not be null.");
                }
            }
            templist.itemsDict = newDict;
            database_dict[databaseID] = templist;
        }

        public static void updateItemsQuantity(groceryList templist, Dictionary<int, int> newDict, int databaseID)
        {
            if (database_dict[databaseID].email != templist.email)
            {
                throw new System.InvalidOperationException("Invalid acces. The databaseID given is not the same as the one trying to be changed.");
            }

            if (database_dict[databaseID].title != templist.title)
            {
                throw new System.InvalidOperationException("Invalid acces. The databaseID given is not the same as the one trying to be changed.");
            }

            if (newDict.Count() == 0)
            {
                throw new System.InvalidOperationException("Invalid data. The item list can not be null.");
            }

            for (int i = 0; i < newDict.Count(); i++)
            {
                if (newDict[i] <= 0)
                {
                    throw new System.InvalidOperationException("Invalid data. A quantity in your list can not be 0.");
                }
            }

            templist.qytDict = newDict;
            database_dict[databaseID] = templist;
        }


        public static void DeleteList(int databaseID)
        {
            if (!database_dict.ContainsKey(databaseID))
            {
                throw new System.InvalidOperationException("Invalid Operation. Can not delete a list that does not exist");
            }
            database_dict.Remove(databaseID);
        }
        */
    }

}