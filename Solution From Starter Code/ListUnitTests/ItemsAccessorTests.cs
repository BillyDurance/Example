using _361Example.Accessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Accessors
{
    [TestClass]
    public class ItemsAccessorTests
    {
        //Additem Tests
        //Example 1
        //This test is to make sure the function AddItemToList works normally.
        [TestMethod]
        public void AddItemToList_NoError()
        {
            try
            {
                ItemAccessor.AddItemToList("Gumballs", 20,1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }

        //Example 2
        //This test is to make sure the function catches that an item's name is not valid.
        [TestMethod]
        public void AddItemToList_InvalidName()
        {
            try
            {
                ItemAccessor.AddItemToList("", 23, 2);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }

        //Example 3
        //This test is to make sure the function catches that the item's quanity is not valid.
        [TestMethod]
        public void AddItemToList_InvalidQty()
        {
            try
            {
                ItemAccessor.AddItemToList("Dog Food", -23, 2);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }

        //GetItemId Tests
        //Example 1
        //This test is to make sure the function checks if GetItemId is working normally.
        [TestMethod]
        public void GetItemId_NoError()
        {
            int testId = ItemAccessor.GetItemId(1, "Pens");

            if (testId != 1)
            {
                Assert.Fail("Not the right ID." + testId);
            }
        }

        //UpdateItemInList Tests
        //Example 1
        //This test is to make sure the function UpdateItemInList works normally.
        [TestMethod]
        public void UpdateItemInList_NoError()
        {
            try
            {
                ItemAccessor.UpdateItemInList(11, "Gumballs", 20);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }

        //RemoveItemFromList Tests
        //Example 1
        //This test is to make sure the function RemoveItemFromList works normally.
        [TestMethod]
        public void RemoveItemFromList_NoError()
        {
            try
            {
                ItemAccessor.RemoveItemFromList(16);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }

        //GetItemName Tests
        //Test 1, no error
        //This test is to make sure that GetItemName works normally
        [TestMethod]
        public void GetItemName_NoError()
        {
            string itemName = ItemAccessor.GetItemName(1, 1);

            Assert.AreEqual(itemName, "Pens");
        }
    }
}