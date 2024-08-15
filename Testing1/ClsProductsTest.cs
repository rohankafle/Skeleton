using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing1
{
    [TestClass]
    public class ClsProductsTest
    {
        // Test data
        string Name = "Coca-Cola";
        string Description = "Refreshing soft drink";
        string Price = "1.50"; //
        string Quantity = "100"; // 

        /******************** Validation OK Tests *********************/
        [TestMethod]
        public void ValidMethodOK()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        /********************** Name Validation ************************/
        [TestMethod]
        public void NameMinLessOne()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Name = ""; // Invalid empty name
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "The Name cannot be blank. ");
        }

        [TestMethod]
        public void NameMin()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Name = "C"; // Minimum valid length
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMinPlusOne()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Name = "Co"; // Minimum plus one character
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxLessOne()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Name = new string('C', 99); // Max length less one character
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMax()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Name = new string('C', 100); // Maximum length
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NameMaxPlusOne()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Name = new string('C', 101); // Exceeding max length
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "The Name must be less than 100 characters. ");
        }

        /********************** Price Validation ************************/
        [TestMethod]
        public void PriceValid()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Price = "1.50"; // Valid price
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PriceInvalid()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Price = "-5.00"; // Invalid negative price
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "The Price must be a positive decimal value. ");
        }

        [TestMethod]
        public void PriceInvalidNonDecimal()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Price = "One"; // Invalid non-numeric price
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "The Price must be a positive decimal value. ");
        }

        /********************** Quantity Validation ************************/
        [TestMethod]
        public void QuantityValid()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Quantity = "100"; // Valid quantity
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void QuantityInvalidNegative()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Quantity = "-10"; // Invalid negative quantity
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "The Quantity must be a positive integer value. ");
        }

        [TestMethod]
        public void QuantityInvalidNonInteger()
        {
            ClsProducts AProduct = new ClsProducts();
            string Error = "";
            string Quantity = "Ten"; // Invalid non-numeric quantity
            Error = AProduct.Valid(Name, Description, Price, Quantity);
            Assert.AreEqual(Error, "The Quantity must be a positive integer value. ");
        }

        /********************** Find Method Tests ************************/
        [TestMethod]
        public void FindMethodOK()
        {
            ClsProducts AProduct = new ClsProducts();
            Boolean Found = false;
            Int32 ProductId = 1;
            Found = AProduct.Find(ProductId);
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestProductIdFound()
        {
            ClsProducts AProduct = new ClsProducts();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 1;
            Found = AProduct.Find(ProductId);
            if (AProduct.ProductId != 1)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestNameFound()
        {
            ClsProducts AProduct = new ClsProducts();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 1;
            Found = AProduct.Find(ProductId);
            if (AProduct.Name != "Coca-Cola")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestDescriptionFound()
        {
            ClsProducts AProduct = new ClsProducts();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 1;
            Found = AProduct.Find(ProductId);
            if (AProduct.Description != "Refreshing soft drink")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPriceFound()
        {
            ClsProducts AProduct = new ClsProducts();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 1;
            Found = AProduct.Find(ProductId);
            if (AProduct.Price != 1.50M)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestQuantityFound()
        {
            ClsProducts AProduct = new ClsProducts();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 1;
            Found = AProduct.Find(ProductId);
            if (AProduct.Quantity != 100)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }
    }
}