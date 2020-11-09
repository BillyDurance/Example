using _361Example.Accessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Accessors
{
    [TestClass]
    public class ListAccessorTests
    {
        //AddList Tests
        //Example 1
        //This test is to make sure the function AddList works normally.
        [TestMethod]
        public void AddList_NoError()
        {
            try
            {
                GroceryListAccessor.AddList("title7", "target", DateTime.Now , 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;
        }

        //Example 2
        //This test is to make sure the function catches that the title is already in the database.
        [TestMethod]
        public void AddList_TakenTitle()
        {
            try
            {
                GroceryListAccessor.AddList("title1", "target", DateTime.Now, 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }


        //UpdateList Tests
        //Example 1
        //This test is to make sure the function UpdateList works normally.
        [TestMethod]
        public void UpdateList_NoError()
        {
            try
            {
                GroceryListAccessor.UpdateList(2,2, "title2", "title2Updated", "site2");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }

        //Example 2
        //This test is to make sure the function catches if the wrong listId is given.
        public void UpdateList_WrongListId()
        {
            try
            {
                GroceryListAccessor.UpdateList(4, 3, "title4", "title4Updated", "site4");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        //Example 3
        //This test is to make sure the function catches if the new tilte is not already taken.
        public void UpdateList_Takentitle()
        {
            try
            {
                GroceryListAccessor.UpdateList(4, 4, "title4", "title3", "site4");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }


        //DeleteList Tests
        //Example 1
        //This test is to make sure the function DeleteList works normally.
        [TestMethod]
        public void DeleteList_NoError()
        {
            try
            {
                GroceryListAccessor.AddList("test1", "target", DateTime.Now, 1);
                GroceryListAccessor.DeleteList(9);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }


        //GetListId Tests
        //Example 1
        //This test is to make sure the function GetListId works normally.
        [TestMethod]
        public void GetListId_NoError()
        {
            int testId = GroceryListAccessor.GetListId(1, "title1");

            if (testId != 1)
            {
                Assert.Fail("Not the right ID." + testId);
            }
        }

        //GetListName Tests
        //Test 1, no error
        //Tests to ensure that GetListName works normally
        [TestMethod]
        public void GetListName_NoError()
        {
            string testName = GroceryListAccessor.GetListTitle(1, 1);

            Assert.AreEqual(testName, "title1");
        }


        [TestMethod]
        public void GetTest()
        {
            string jaggedArray = GroceryListAccessor.GetAllLists("test1@gmail.com");

            //Assert.AreEqual(testName, "title1");
        }
    }
}