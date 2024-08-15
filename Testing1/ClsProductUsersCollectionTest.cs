using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using System;

namespace Testing1
{
    [TestClass]
    public class ClsProductUsersCollectionTest
    {
        [TestMethod]
        public void InstanceCreationTest()
        {
            ClsProductUsersCollection usersCollection = new ClsProductUsersCollection();
            Assert.IsNotNull(usersCollection);
        }

        [TestMethod]
        public void AddUserTest()
        {
            // Arrange
            ClsProductUsersCollection usersCollection = new ClsProductUsersCollection();
            ClsProductUsers newUser = new ClsProductUsers
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@example.com",
                Address = "123 Test Address",
                Password = "password123",
                Role = "User",
                IsActive = true
            };
            usersCollection.ThisUser = newUser;

            // Act
            int newUserId = usersCollection.Add(); // Add the user and get the new UserId
            usersCollection = new ClsProductUsersCollection(); // Reload the collection
            ClsProductUsers foundUser = usersCollection.UsersList.FirstOrDefault(u => u.UserId == newUserId);

            // Assert
            Assert.IsNotNull(foundUser);
            Assert.AreEqual(newUser.FirstName, foundUser.FirstName);
            Assert.AreEqual(newUser.LastName, foundUser.LastName);
            Assert.AreEqual(newUser.Email, foundUser.Email);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            // Arrange
            ClsProductUsersCollection usersCollection = new ClsProductUsersCollection();
            ClsProductUsers newUser = new ClsProductUsers
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@example.com",
                Address = "123 Test Address",
                Password = "password123",
                Role = "User",
                IsActive = true
            };
            usersCollection.ThisUser = newUser;
            int newUserId = usersCollection.Add(); // Add the user
            newUser.UserId = newUserId;

            // Act
            newUser.Email = "updated@example.com"; // Change some properties
            usersCollection.ThisUser = newUser;
            usersCollection.Update(); // Update the user
            usersCollection = new ClsProductUsersCollection(); // Reload the collection
            ClsProductUsers foundUser = usersCollection.UsersList.FirstOrDefault(u => u.UserId == newUserId);

            // Assert
            Assert.IsNotNull(foundUser);
            Assert.AreEqual("updated@example.com", foundUser.Email);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            // Arrange
            ClsProductUsersCollection usersCollection = new ClsProductUsersCollection();
            ClsProductUsers newUser = new ClsProductUsers
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@example.com",
                Address = "123 Test Address",
                Password = "password123",
                Role = "User",
                IsActive = true
            };
            usersCollection.ThisUser = newUser;
            int newUserId = usersCollection.Add(); // Add the user

            // Act
            usersCollection.Delete(newUserId); // Delete the user
            usersCollection = new ClsProductUsersCollection(); // Reload the collection
            ClsProductUsers foundUser = usersCollection.UsersList.FirstOrDefault(u => u.UserId == newUserId);

            // Assert
            Assert.IsNull(foundUser); // The user should no longer exist
        }

        [TestMethod]
        public void FilterByNameTest()
        {
            // Arrange
            ClsProductUsersCollection usersCollection = new ClsProductUsersCollection();

            // Act
            usersCollection.FilterByName("TestFirstName");
            var filteredUsers = usersCollection.UsersList;

            // Assert
            Assert.IsTrue(filteredUsers.All(u => u.FirstName.Contains("TestFirstName") || u.LastName.Contains("TestFirstName")));
        }
    }
}