using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingStock
{

    [TestClass]
    public class tstStock
    {
        //good test data
        string ProductName = "Product Name";
        string QuantityAvailable = "2";
        string RestockDate = DateTime.Now.Date.ToString();

        public clsStock createProduct()
        {
            clsStock product = new clsStock();
            product.Find(1);
            return product;
        }

        //Test Instance
        [TestMethod]
        public void InstanceOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product);
        }

        //Test Product ID
        [TestMethod]
        public void AttributeProductIdOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product.ProductId);
        }

        //Test Product Name
        [TestMethod]
        public void AttributeProductNameOK()
        {
            clsStock product = new clsStock();

            String TestData = "Product Name";
            product.ProductName = TestData;

            Assert.AreEqual(product.ProductName, TestData);
        }

        //Test Product Description
        [TestMethod]
        public void AttributeProductDescriptionOK()
        {
            clsStock product = new clsStock();
            Assert.IsNull(product.ProductDescription);        
        }

        //Test Is Available
        [TestMethod]
        public void AttributeIsAvailableOK()
        {
            clsStock product = new clsStock();

            Boolean TestData = true;
            product.IsAvailable = TestData;

            Assert.AreEqual(product.IsAvailable, TestData);
        }

        //Test Quantity
        [TestMethod]
        public void AttributeQuantityAvailableOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product.QuantityAvailable);
            Assert.IsTrue(product.QuantityAvailable >= 0 && product.QuantityAvailable <=50);
        }

        //Test Restock Date
        [TestMethod]
        public void AttributeRestockDateOK()
        {
            clsStock product = new clsStock();
            Assert.IsNotNull(product.RestockDate);
        }

        //Create FindOK
        [TestMethod]
        public void TestFindOK()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            int ProductId = 2;
            Found = product.Find(ProductId);
            Assert.IsTrue(Found);
        }

        //Create Find Porduct ID Test
        [TestMethod]
        public void TestProductIdFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 2;
            Found = product.Find(ProductId);
            if(product.ProductId != 2)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestProductNameFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 2;
            Found = product.Find(ProductId);
            if(product.ProductName != "Product Name")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        //Create Find ProductDescription Test
        [TestMethod]
        public void TestProductDescriptionFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 2;
            Found = product.Find(ProductId);
            OK = product.ProductDescription.Equals("Product Description");
            Assert.IsTrue(OK);
        }

        //Create Find Is Available Test
        [TestMethod]
        public void TestIsAvailableFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 1;
            Found = product.Find(ProductId);
            OK = product.IsAvailable;
            Assert.IsTrue(OK);
        }

        //Create Find Quantity Test
        [TestMethod]
        public void TestQuantityAvailableFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 2;
            Found = product.Find(ProductId);
            if(product.QuantityAvailable != 0)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        //Create Find Restock Date
        [TestMethod]
        public void TestRestockDateFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 2;
            Found = product.Find(ProductId);
            OK = product.RestockDate != null;
            Assert.IsTrue(OK);
        }

        //Create Test Validation Method
        [TestMethod]
        public void ValidMethodOK()
        {
            clsStock product = new clsStock();
            String Error = "";
            Error = product.Valid(ProductName,QuantityAvailable,RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test ProductName less than one Method
        [TestMethod]
        public void ProductNameMinLessOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            string ProductName = "";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test ProductName for one character Method
        [TestMethod]
        public void ProductNameMin()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            string ProductName = "a";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test ProductName for two characters Method
        [TestMethod]
        public void ProductNameMinPlusOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            string ProductName = "aa";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test ProductName for max minus one character Method
        [TestMethod]
        public void ProductNameMaxMinusOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            string ProductName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test ProductName for max characters Method
        [TestMethod]
        public void ProductNameMax()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            string ProductName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test ProductName for max plus one character Method
        [TestMethod]
        public void ProductNameMaxPlusOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            string ProductName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test ProductName for mid characters Method
        [TestMethod]
        public void ProductNameMid()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            string ProductName = "aaaaaaaaaaaaaaaa";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test ProductName for Extreme Max characters Method
        [TestMethod]
        public void ProductNameExtremeMax()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            string ProductName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }
    }
}
