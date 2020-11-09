using _361Example.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ListUnitTests
{
    [TestClass]
    public class ListUnitTest
    {
        /*
        //Michael Rahe
        //Test for groceryList function
        //Example 1
        //This test is to make sure the function makes a grocerList normally.
        [TestMethod]
        public void createList_NoError()
        {
            DateTime date = DateTime.Now;
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};
            try
            {
                groceryList testList = new groceryList("my temp list", "Walmart", "temp@email.email", date, itemsDict, qytDict);
            }
            catch
            {
                Assert.Fail("An exception was thrown.");
            }
            return;

        }

        /*Example 2
        // This test is check if the function catches that the title is equal to null.
        [TestMethod]
        public void createList_InvalidDataTitle()
        {
            DateTime date = DateTime.Now;
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};
            try
            {
                groceryList testList = new groceryList("", "Walmart", "temp@email.email", date, itemsDict, qytDict);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 3
        // This test is check if the function catches that the location is equal to null.
        [TestMethod]
        public void createList_InvalidDataLocation()
        {
            DateTime date = DateTime.Now;
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};

            try
            {
                groceryList testList = new groceryList("my temp list", "", "temp@email.email", date, itemsDict, qytDict);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 4
        // This test is check if the function catches that the email is equal to null.
        [TestMethod]
        public void createList_InvalidDataEmail()
        {
            DateTime date = DateTime.Now;
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};

            try
            {
                groceryList testList = new groceryList("my temp list", "Walmart", "", date, itemsDict, qytDict);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");

        }

        /*Example 5
        // This test is check if the function catches that the itemsDict is equal to null.
        [TestMethod]
        public void createList_InvalidDataItemDictIsNULL()
        {
            DateTime date = DateTime.Now;
            var itemsDict = new Dictionary<int, string>() { };

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};

            try
            {
                groceryList testList = new groceryList("my temp list", "Walmart", "temp@email.email", date, itemsDict, qytDict);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");

        }

        /*Example 6
        // This test is check if the function catches that the qytDict is equal to null.
        [TestMethod]
        public void createList_InvalidDataQtyDictIsNULL()
        {
            DateTime date = DateTime.Now;
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};


            var qytDict = new Dictionary<int, int>() { };

            try
            {
                groceryList testList = new groceryList("my temp list", "Walmart", "temp@email.email", date, itemsDict, qytDict);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");

        }




        //Michael Rahe
        /*Test for addToDB function
        /*Example 1
        //This test is to make sure the function adds to a database normally.
        [TestMethod]
        public void addToDB_NoError()
        {
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};
            groceryList testList = new groceryList("this is a test", "Walmart", "temp@email.com", DateTime.Now, itemsDict, qytDict);

            try
            {
                groceryList.addToDB(testList);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                Assert.Fail("An exception was thrown.");
            }
            return;
        }

        /*Example 2
        //This test is to make sure the function signals that a dupict entry has tried to be entered into the database.
        [TestMethod]
        public void addToDB_SameNameError()
        {
            var itemsDict = new Dictionary<int, string>() {
              {1, "cases of pop"},
              {2, "Grapes"},
              {3, "Loaves of bread"}};

            var qytDict = new Dictionary<int, int>() {
              {1, 5},
              {2, 10},
              {3, 15}};
            groceryList testList = new groceryList("my temp list", "Walmart", "temp@email.com", DateTime.Now, itemsDict, qytDict);

            try
            {
                groceryList.addToDB(testList);

            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }





        //Michael Rahe
        /*Test for editTitle function*/
        /*Example 1
        //This test is to make sure the function updates the title to a database normally.
        [TestMethod]
        public void editTitle_NoError()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editTitle(temp, 1, "yeet");
            }
            catch
            {
                Assert.Fail("An exception was thrown.");
            }
            return;
        }

        /*Example 2
        // This test to to see if the function catches that the new title is null.
        [TestMethod]
        public void editTitle_TitleIsEqualToNull()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editTitle(temp, 1, "");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 3
        // This test to to see if the function catches that the new title is the same as an existing one.
        [TestMethod]
        public void editTitle_TitleIsEqualToAnExistingTitle()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editTitle(temp, 0, "yeet");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }




        //Shelby Miller
        /*Test for editLocation function*/
        /*TODO*/





        //Michael Rahe
        /*Test for editEmail function*/
        /*TODO*/
        /*Example 1
        //This test is to make sure the function updates the email to a database normally.
        [TestMethod]
        public void editEmail_NoError()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "email@yeet.com");
            }
            catch
            {
                Assert.Fail("An exception was thrown.");
            }
            return;
        }

        /*Example 2
        //This test is to make sure the function checks if the email is null.
        [TestMethod]
        public void editEmail_EmailIsEqualToNull()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 3
        //This test is to make sure the function checks if the email is not a valid email.
        [TestMethod]
        public void editEmail_EmailIsFormatedWrong1()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "abc123/@gmail.com");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }


        /*Example 4
        //This test is to make sure the function checks if the email is not a valid email.
        [TestMethod]
        public void editEmail_EmailIsFormatedWrong2()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "abc123 @gmail.com");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 5
        //This test is to make sure the function checks if the email is not a valid email.
        [TestMethod]
        public void editEmail_EmailIsFormatedWrong3()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "abc123gmail.com");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 6
        //This test is to make sure the function checks if the email is not a valid email.
        [TestMethod]
        public void editEmail_EmailIsFormatedWrong4()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "123456789");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 7
        //This test is to make sure the function checks if the email is not a valid email.
        [TestMethod]
        public void editEmail_EmailIsEqualToAnother()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editEmail(temp, 1, "mrahe@csce.unl.edu");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }






        //Michael Rahe
        /*Test for editTime function*/
        /*TODO*/
        /*Example 1
        //This test is to make sure the function updates the time to a database normally.
        [TestMethod]
        public void editTime_NoError()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.editTime(temp, 1, DateTime.Now);
            }
            catch
            {
                Assert.Fail("An exception was thrown.");
            }
            return;
        }

        /*Example 2
        //This test is to make sure the function the time is the correct time now.
        [TestMethod]
        public void editTime_FurtureDate()
        {
            groceryList temp = groceryList.getGroceryList(1);
            DateTime tempdate = new DateTime(2100, 03, 15);
            try
            {
                groceryList.editTime(temp, 1, tempdate);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 3
        //This test is to make sure the function the time is the correct time now.
        [TestMethod]
        public void editTime_PastDate()
        {
            groceryList temp = groceryList.getGroceryList(1);
            DateTime tempdate = new DateTime(2000, 03, 15);
            try
            {
                groceryList.editTime(temp, 1, tempdate);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }





        //Zhiwei Jin
        /*Test for updateListItems function*/
        /*Example 1
        //This test is to make sure the function updateListItems is working normally.
        [TestMethod()]
        public void updateListItemsTest_Normal()
        {

            Dictionary<int, string> newDict = new Dictionary<int, string>();
            newDict.Add(0, "apple");

            groceryList temp = groceryList.getGroceryList(1);
            

            try
            {
                groceryList.updateListItems(temp, newDict, 1);
            }
            catch 
            {
                Assert.Fail("An exception was thrown.");
            }
            return;
    
        }

        /*Example 2
        //This test is to make sure the function chatches that a dictianry is null.
        [TestMethod()]
        public void updateListItemsTest_Empty_Dict()
        {
            groceryList temp = groceryList.getGroceryList(1);
            Dictionary<int, string> newDict = new Dictionary<int, string>();
  

            try
            {
                groceryList.updateListItems(temp, newDict, 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 3
        //This test is to make sure the function catches that a dictianry is null.
        [TestMethod()]
        public void updateListItemsTest_EmptyValueInDict()
        {
            groceryList temp = groceryList.getGroceryList(1);
            Dictionary<int, string> newDict = new Dictionary<int, string>();
            newDict.Add(0, "apple");
            newDict.Add(1, "");

            try
            {
                groceryList.updateListItems(temp, newDict, 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }














       

        //Zhiwei Jin
        /*Test for updateListQtys function*/
        /*Example 1
        //This test is to make sure the function works normally.
        [TestMethod()]
        public void updateItemsQuantityTest_Normal()
        {
            Dictionary<int, int> newDict = new Dictionary<int, int>();
            newDict.Add(0, 1);

            groceryList temp = groceryList.getGroceryList(1);

            try
            {
                groceryList.updateItemsQuantity(temp, newDict, 1);
            }
            catch
            {
                Assert.Fail("An exception was thrown.");
            }
            return;


        }

        /*Example 2
        //This test is to make sure the function catches that the Dict is empty.
        [TestMethod()]
        public void updateItemsQuantityTest_Empty_Dict()
        {
            Dictionary<int, int> newDict = new Dictionary<int, int>();
            

            groceryList temp = groceryList.getGroceryList(1);

            try
            {
                groceryList.updateItemsQuantity(temp, newDict, 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /*Example 3
        //This test is to make sure the function catches that a value in the Dict is 0.
        [TestMethod()]
        public void updateItemsQuantityTest_ZeroValueInDict1()
        {
            Dictionary<int, int> newDict = new Dictionary<int, int>();
            newDict.Add(0, 1);
            newDict.Add(1, 6);
            newDict.Add(2, 0);

            groceryList temp = groceryList.getGroceryList(1);

            try
            {
                groceryList.updateItemsQuantity(temp, newDict, 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }


        /*Example 4
        //This test is to make sure the function catches that a value in the Dict is negative.
        [TestMethod()]
        public void updateItemsQuantityTest_ZeroValueInDict2()
        {
            Dictionary<int, int> newDict = new Dictionary<int, int>();
            newDict.Add(0, 1);
            newDict.Add(1, 6);
            newDict.Add(2, -23);

            groceryList temp = groceryList.getGroceryList(1);

            try
            {
                groceryList.updateItemsQuantity(temp, newDict, 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }





        //Shelby Miller
        //Test remove list on an existing list
        [TestMethod]
        public void removeListTest_ExistingList()
        {
            groceryList temp = groceryList.getGroceryList(2);
            groceryList.DeleteList(2);
            Assert.AreNotEqual(temp, 2);
        }

        //Test remove list on a nonexisting list
        [TestMethod]
        public void removeListTest_NonExistingList()
        {
            groceryList temp = groceryList.getGroceryList(1);
            try
            {
                groceryList.DeleteList(4);

            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }

        //Test update location with a given location
        [TestMethod]
        public void updateLocationTest_GivenLocation()
        {
            groceryList temp = groceryList.getGroceryList(1);
            groceryList.UpdateLocation(temp, 1, "Aldis");
            Assert.AreEqual(temp.location, "Aldis");
        }

        //Test update location without a given location
        [TestMethod]
        public void updateLocationTest_LocationNotGiven()
        {
            groceryList temp = groceryList.getGroceryList(1);
            groceryList.UpdateLocation(temp, 1, "");
            Assert.AreEqual(temp.location, "None");
        }
        */
    }
}