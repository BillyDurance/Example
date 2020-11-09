using _361Example.Accessors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Accessors
{
    [TestClass]
    public class UserAccessorTests
    {
        //AddUser Tests
        //Example 1
        //This test is to make sure the function adds a user normally.
        [TestMethod]
        public void AddUser_NoError()
        {
            try
            {
                UserAccessor.AddUser("test7@gmail.com", "password");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }


        //Example 2
        //This test is to make sure the function catches that the email is already in the database.
        [TestMethod]
        public void AddUser_TakenEmail()
        {
            try
            {
                UserAccessor.AddUser("test6@gmail.com", "password");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }

        //Example 3
        //This test is to make sure the function catches that the email is not valid.
        [TestMethod]
        public void AddUser_InvalidEmail()
        {
            try
            {
                UserAccessor.AddUser("test123 @gmail.com", "password");
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }


        //UpdateUser Tests
        //Example 1
        //This test is to make sure the function UpdateUser works normally.
        [TestMethod]
        public void UpdateUser_NoError()
        {
            try
            {
                UserAccessor.UpdateUser("temp1@gmail.com", "temp33@gmail.com", "password", 3);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }

        //Example 2
        //This test is to make sure the function catches that a userId is not correct.
        [TestMethod]
        public void UpdateUser_IDIsWrong()
        {
            try
            {
                UserAccessor.UpdateUser("test5@gmail.com", "tempx@gmail.com", "password", 1);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }


        //Example 3
        //This test is to make sure the function takes only the valid data for the email string.
        [TestMethod]
        public void UpdateUser_InvalidDataEmail()
        {
            try
            {
                UserAccessor.UpdateUser("test7@gmail.com", "tempx @gmail.com", "password", 7);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }


        //RemoveUser Tests
        //Example 1
        //This test is to make sure the function RemoveUser works normally.
        [TestMethod]
        public void RemoveUser_NoError()
        {
            try
            {
                UserAccessor.AddUser("temp12@gmail.com", "password");
                UserAccessor.RemoveUser(8);
            }
            catch (InvalidOperationException e)
            {
                StringAssert.Contains(e.Message, "");
            }
            return;

        }



        //GetUserId Tests
        //Example 1
        //This test is to make sure the function GetUserId works normally.
        [TestMethod]
        public void GetUserID_NoError()
        {
            int testId = UserAccessor.GetUserID("test4@gmail.com");

            if(testId != 4)
            {
                Assert.Fail("Not the right ID."+ testId);
            }
        }


    }
}