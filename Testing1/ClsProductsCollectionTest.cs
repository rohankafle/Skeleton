using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Testing1
{
    [TestClass]
    public class ClsProductsCollectionTest
    {
        /********************** Constructor Test ************************/
        [TestMethod]
        public void InstanceOK()
        {
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            Assert.IsNotNull(AllProducts);
        }

        /********************** Products List Test ************************/
        [TestMethod]
        public void ProductsListOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            // Create a test list of products
            var TestList = new List<ClsProducts>
            {
                new ClsProducts { ProductId = 1, Name = "Coca-Cola", Description = "Soft Drink", Price = 1.5M, Quantity = 100, CategoryId = 1 },
                new ClsProducts { ProductId = 2, Name = "Pepsi", Description = "Soft Drink", Price = 1.5M, Quantity = 150, CategoryId = 1 }
            };

            // Act
            AllProducts.ProductsList = TestList;

            // Assert
            Assert.AreEqual(AllProducts.ProductsList, TestList);
        }

        /********************** ThisProduct Property Test ************************/
        [TestMethod]
        public void ThisProductPropertyOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            ClsProducts TestProduct = new ClsProducts
            {
                ProductId = 1,
                Name = "Coca-Cola",
                Description = "Refreshing Soft Drink",
                Price = 1.5M,
                Quantity = 100,
                CategoryId = 1
            };

            // Act
            AllProducts.ThisProduct = TestProduct;

            // Assert
            Assert.AreEqual(AllProducts.ThisProduct, TestProduct);
        }

        /********************** Count Property Test ************************/
        [TestMethod]
        public void CountPropertyOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            int expectedCount = 2;

            // Create a test list of products
            var TestList = new List<ClsProducts>
            {
                new ClsProducts { ProductId = 1, Name = "Coca-Cola", Description = "Soft Drink", Price = 1.5M, Quantity = 100, CategoryId = 1 },
                new ClsProducts { ProductId = 2, Name = "Pepsi", Description = "Soft Drink", Price = 1.5M, Quantity = 150, CategoryId = 1 }
            };

            // Act
            AllProducts.ProductsList = TestList;

            // Assert
            Assert.AreEqual(AllProducts.Count, expectedCount);
        }

        /********************** Add Method Test ************************/
        [TestMethod]
        public void AddMethodOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            ClsProducts TestProduct = new ClsProducts
            {
                CategoryId = 1,
                Name = "Sprite",
                Description = "Lemon-Lime Soft Drink",
                Price = 1.25M,
                Quantity = 50
            };

            // Set ThisProduct
            AllProducts.ThisProduct = TestProduct;

            // Act
            int primaryKey = AllProducts.Add();

            // Assert
            Assert.AreNotEqual(primaryKey, 0); // Primary key should be non-zero if successfully added
        }

        /********************** Update Method Test ************************/
        [TestMethod]
        public void UpdateMethodOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            ClsProducts TestProduct = new ClsProducts
            {
                ProductId = 1, // Existing product ID in your database
                CategoryId = 1,
                Name = "Sprite",
                Description = "Lemon-Lime Soft Drink Updated",
                Price = 1.50M,
                Quantity = 100
            };

            // Set ThisProduct
            AllProducts.ThisProduct = TestProduct;

            // Act
            AllProducts.Update();

            // Assert
            Assert.AreEqual(AllProducts.ThisProduct.Name, "Sprite");
            Assert.AreEqual(AllProducts.ThisProduct.Description, "Lemon-Lime Soft Drink Updated");
            Assert.AreEqual(AllProducts.ThisProduct.Price, 1.50M);
        }

        /********************** Delete Method Test ************************/
        [TestMethod]
        public void DeleteMethodOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();
            ClsProducts TestProduct = new ClsProducts
            {
                ProductId = 1 // Set to a valid product ID that exists in your database
            };

            // Set ThisProduct
            AllProducts.ThisProduct = TestProduct;

            // Act
            AllProducts.Delete(TestProduct.ProductId);

            // Try to find the product again (assuming Find method exists)
            bool found = TestProduct.Find(TestProduct.ProductId);

            // Assert
            Assert.IsFalse(found); // The product should no longer exist after deletion
        }

        /********************** Filter By Name Method Test ************************/
        [TestMethod]
        public void FilterByNameMethodOK()
        {
            // Arrange
            ClsProductsCollection AllProducts = new ClsProductsCollection();

            // Act
            AllProducts.FilterByName("Coca-Cola");

            // Assert
            Assert.AreEqual(AllProducts.Count, 1); // Assuming one product with the name "Coca-Cola" exists
        }
    }
}