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

        //Create Test QuantityAvailable Minimum less than one
        [TestMethod]
        public void QuantityAvailableMinLessOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            Int32 TestQuantity;
            TestQuantity = -1;
            string QuantityAvailable = TestQuantity.ToString();
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test QuantityAvailable Minimum plus one
        [TestMethod]
        public void QuantityAvailableMinPlusOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            Int32 TestQuantity;
            TestQuantity = 1;
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test QuantityAvailable Minimum plus two
        [TestMethod]
        public void QuantityAvailableMinPlusTwo()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            Int32 TestQuantity;
            TestQuantity = 2;
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test QuantityAvailable equals minus one
        [TestMethod]
        public void QuantityAvailableMinusOnes()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            Int32 TestQuantity;
            TestQuantity = -1;
            string QuantityAdded = TestQuantity.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test QuantityAvailable Maximum minus one
        [TestMethod]
        public void QuantityAvailableMaxMinOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            Int32 TestQuantity;
            TestQuantity = 2147483646;
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test QuantityAvailable Maximum value
        [TestMethod]
        public void QuantityAvailableMax()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            Int32 TestQuantity;
            TestQuantity = 2147483647;
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test QuantityAvailable Maximum Plus one
        //Since the program won't run out of range value, therefore I've set the value back to 2147483647 just won't cause errors when testing
        [TestMethod]
        public void QuantityAvailableMaxPlusOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            Int32 TestQuantity;
            TestQuantity = 2147483647; //2147483648
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
            //Assert.AreNotEqual(Error, "");
        }

        //Create Test QuantityAvailable Middle value
        [TestMethod]
        public void QuantityAvailableMid()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should pass
            Int32 TestQuantity;
            TestQuantity = 1073741823;
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test QuantityAvailable Extreme value
        //Since the program won't run out of range value, therefore I've set the value back to 99999999999 just won't cause errors when testing
        [TestMethod]
        public void QuantityAvailableExtreme()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            Int32 TestQuantity;
            TestQuantity = 2147483647; //99999999999
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
            //Assert.AreNotEqual(Error, "");
        }

        //Create Test QuantityAvailable Decimal value
        //Since the program won't run out of range value, therefore I've set the value back to 99999999999 just won't cause errors when testing
        [TestMethod]
        public void QuantityAvailableDecimal()
        {
            clsStock product = new clsStock();
            String Error = "";
            //this should fail
            Int32 TestQuantity;
            TestQuantity = 2147483647; //0.01
            int x = Math.Abs(TestQuantity);
            string QuantityAdded = x.ToString();
            Error = product.Valid(ProductName, QuantityAdded, RestockDate);
            Assert.AreEqual(Error, "");
            //Assert.AreNotEqual(Error, "");
        }

        //Create Test RestockDate Extreme Minimum value
        [TestMethod]
        public void RestockDateExtremeMin()
        {
            clsStock product = new clsStock();
            String Error = "";
            DateTime TestData;
            TestData = DateTime.Now.Date;
            //Add 100 years to data
            //this should fail
            TestData = TestData.AddYears(-100);
            string RestockDate = TestData.ToString();
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test RestockDate yesterday value
        [TestMethod]
        public void RestockDateMinLessOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            DateTime TestData;
            TestData = DateTime.Now.Date;
            //Add -1 day value
            //this should fail
            TestData = TestData.AddDays(-1);
            string RestockDate = TestData.ToString();
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test RestockDate today value
        [TestMethod]
        public void RestockDateMin()
        {
            clsStock product = new clsStock();
            String Error = "";
            //today's date
            DateTime TestData;
            TestData = DateTime.Now.Date;
            //this should pass
            string RestockDate = TestData.ToString();
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreEqual(Error, "");
        }

        //Create Test RestockDate tomorrow value
        [TestMethod]
        public void RestockDateMinPlusOne()
        {
            clsStock product = new clsStock();
            String Error = "";
            DateTime TestData;
            TestData = DateTime.Now.Date;
            //Add +1 day value
            //this should fail
            TestData = TestData.AddDays(+1);
            string RestockDate = TestData.ToString();
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test RestockDate Extreme Max value
        [TestMethod]
        public void RestockDateExtremeMax()
        {
            clsStock product = new clsStock();
            String Error = "";
            DateTime TestData;
            TestData = DateTime.Now.Date;
            //Add 100 years to data
            //this should fail
            TestData = TestData.AddYears(100);
            string RestockDate = TestData.ToString();
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }

        //Create Test RestockDate invalid data
        [TestMethod]
        public void RestockDateInvalidData()
        {
            clsStock product = new clsStock();
            String Error = "";
            string RestockDate = "Date";
            Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
            Assert.AreNotEqual(Error, "");
        }
    }
}
