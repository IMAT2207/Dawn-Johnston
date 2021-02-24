using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingStock
{

    [TestClass]
    public class tstStock
    {
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
            if (product.ProductDescription != "Product Description")
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        //Create Find Is Available Test
        [TestMethod]
        public void TestIsAvailableFound()
        {
            clsStock product = new clsStock();
            Boolean Found = false;
            Boolean OK = true;
            Int32 ProductId = 2;
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
            if(product.QuantityAvailable == 0)
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
    }
}
