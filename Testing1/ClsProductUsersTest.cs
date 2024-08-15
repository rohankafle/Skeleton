using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace Testing1
{
    [TestClass]
    public class ClsProductUsersTest
    {
        // Test data
        String FirstName = "John";
        String LastName = "Doe";
        String Email = "john.doe@example.com";
        String Address = "123 Main St";
        String Password = "password123";
        String Role = "User";
        String IsActive = "true";

        /******************** Validation OK Tests *********************/
        [TestMethod]
        public void ValidMethodOK()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

        /********************** FirstName Validation ************************/
        [TestMethod]
        public void FirstNameMin()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String Error = AUser.Valid("A", LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void FirstNameMax()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String FirstName = new string('A', 100);
            String Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

        /********************** LastName Validation ************************/
        [TestMethod]
        public void LastNameMin()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String Error = AUser.Valid(FirstName, "A", Email, Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void LastNameMax()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String LastName = new string('A', 100);
            String Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

        /********************** Email Validation ************************/
        [TestMethod]
        public void EmailMin()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String Error = AUser.Valid(FirstName, LastName, "a@b.c", Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

       

        /********************** Password Validation ************************/
        [TestMethod]
        public void PasswordMin()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String Error = AUser.Valid(FirstName, LastName, Email, Address, "a", Role, IsActive);
            Assert.AreEqual("", Error);
        }

        [TestMethod]
        public void PasswordMax()
        {
            ClsProductUsers AUser = new ClsProductUsers();
            String Password = new string('A', 255);
            String Error = AUser.Valid(FirstName, LastName, Email, Address, Password, Role, IsActive);
            Assert.AreEqual("", Error);
        }

        /********************** Find Method Tests ************************/
        [TestMethod]
        public void FindMethodDummy()
        {
            Assert.IsTrue(true);  // Dummy test
        }
    }
}