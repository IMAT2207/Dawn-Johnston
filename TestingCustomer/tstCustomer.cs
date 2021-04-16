using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace TestingCustomer
{
    [TestClass]
    public class tstCustomer
    {
        //  --TestInitialise--

        [TestMethod]
        public void InstanceOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void AttributeTraderPasswordOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.TraderPassword);
            Assert.IsTrue(customer.TraderPassword.Length > 6 && customer.TraderPassword.Length <= 50); //Check if lengh is between 1 and 50
        }

        [TestMethod]
        public void AttributeBusinesNameOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.BusinessName);
            Assert.IsTrue(customer.BusinessName.Length > 0 && customer.BusinessName.Length <= 50); //Check if lengh is between 1 and 50
        }

        [TestMethod]
        public void AttributeContactEmailOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.ContactEmail);
            Assert.IsTrue(customer.ContactEmail.Length > 0 && customer.ContactEmail.Length <= 50); //Check if lengh is between 1 and 50
        }

        [TestMethod]
        public void AttributeDeliveryAddressOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.DeliveryAddress);
            Assert.IsTrue(customer.DeliveryAddress.Length > 0 && customer.DeliveryAddress.Length <= 50); //Check if lengh is between 1 and 50
        }

        [TestMethod]
        public void AttributeAccountCreationDateOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.AccountCreationDate);
        }

        [TestMethod]
        public void AttributeNumberOfOrdersOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.NumberOfOrders);
        }

        [TestMethod]
        public void AttributeIsSignedInOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.IsSignedIn);
        }

        //  --TestPropery--

        [TestMethod]
        public void TraderPasswordPropertyOK()
        {
            //TraderPassword should be equal to TestData
            clsCustomer customer = new clsCustomer();
            string TestData = "1two3FOUR";
            customer.TraderPassword = TestData;
            Assert.AreEqual(customer.TraderPassword, TestData);
        }

        [TestMethod]
        public void BusinessPropertyOK()
        {
            //BusinessName should be equal to TestData
            clsCustomer customer = new clsCustomer(); 
            string TestData = "A Business";
            customer.BusinessName = TestData;
            Assert.AreEqual(customer.BusinessName, TestData);
        }

        [TestMethod]
        public void ContactEmailPropertyOK()
        {
            //ContactEmail should be equal to TestData
            clsCustomer customer = new clsCustomer();
            string TestData = "BusinessName@Email.com";
            customer.ContactEmail = TestData;
            Assert.AreEqual(customer.ContactEmail, TestData);
        }

        [TestMethod]
        public void DeliveryAddressPropertyOK()
        {
            //DeliveryAddress should be equal to TestData
            clsCustomer customer = new clsCustomer();
            string TestData = "10BusinessRoad";
            customer.DeliveryAddress = TestData;
            Assert.AreEqual(customer.DeliveryAddress, TestData);
        }

        [TestMethod]
        public void AccountCreationDatePropertyOK()
        {
            //AccountCreationDate should be equal to TestData
            clsCustomer customer = new clsCustomer();
            DateTime TestData = DateTime.Today;
            customer.AccountCreationDate = TestData;
            Assert.AreEqual(customer.AccountCreationDate, TestData);
        }

        [TestMethod]
        public void NumberOfOrdersPropertyOK()
        {
            //NumberOfOrders should be equal to TestData
            clsCustomer customer = new clsCustomer();
            int TestData = 4;
            customer.NumberOfOrders = TestData;
            Assert.AreEqual(customer.NumberOfOrders, TestData);
        }

        [TestMethod]
        public void IsSignedInPropertyOK()
        {
            //IsSignedIn should be equal to TestData
            clsCustomer customer = new clsCustomer();
            bool TestData = false;
            customer.IsSignedIn = TestData;
            Assert.AreEqual(customer.IsSignedIn, TestData);
        }

        #region Validation Testing
        //--Validity Testing TraderId (Int)--

        [TestMethod]
        public void TraderIdNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderId = 0;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderIdMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderId = 1;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderIdMaxMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderId = int.MaxValue -1;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderIdNoMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderId = int.MaxValue;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        //--Validity Testing NumberOfOrders (Int)--

        [TestMethod]
        public void NumberOfOrdersExtremeMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.NumberOfOrders = -9999;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NumberOfOrdersMinMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.NumberOfOrders = -1;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void NumberOfOrdersNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.NumberOfOrders = 0;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberOfOrdersMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.NumberOfOrders = 1;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberOfOrdersMaxMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.NumberOfOrders = int.MaxValue - 1;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberOfOrdersNoMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.NumberOfOrders = int.MaxValue;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        //--Validity Testing TraderPassword (String)--

        [TestMethod]
        public void TraderPasswordMinMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordMaxMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordMid()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TraderPasswordExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.TraderPassword = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        //--Validity Testing DeliveryAddress (String)--

        [TestMethod]
        public void DeliveryAddressNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void DeliveryAddressMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "a";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void DeliveryAddressMaxMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void DeliveryAddressMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void DeliveryAddressMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DeliveryAddressMid()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "aaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void DeliveryAddressExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.DeliveryAddress = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        //--Validity Testing ContactEmail (String)--

        [TestMethod]
        public void ContactEmailNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ContactEmailMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "a";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ContactEmailMaxMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ContactEmailMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ContactEmailMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ContactEmailMid()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "aaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ContactEmailExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.ContactEmail = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        //--Validity Testing BusinessName (String)--

        [TestMethod]
        public void BusinessNameNoMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void BusinessNameMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "a";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void BusinessNameMaxMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void BusinessNameMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void BusinessNameMaxPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void BusinessNameMid()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "aaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void BusinessNameExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create some test data to pass to the method
            customer.BusinessName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        //--Validity AccountCreationDate (Date/Time)--

        [TestMethod]
        public void AccountCreationDateExtremeMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is less 100 years
            TestDate = TestDate.AddYears(-100);
            //convert the date variable to a string variable
            customer.AccountCreationDate = TestDate;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void AccountCreationDateMinMinusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is less 1 day
            TestDate = TestDate.AddDays(-1);
            //convert the date variable to a string variable
            customer.AccountCreationDate = TestDate;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AccountCreationDateMin()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //convert the date variable to a string variable
            customer.AccountCreationDate = TestDate;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AccountCreationDateMinPlusOne()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date is less 1 day
            TestDate = TestDate.AddDays(1);
            //convert the date variable to a string variable
            customer.AccountCreationDate = TestDate;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void AccountCreationDateExtremeMax()
        {
            //create an instance of the class we want to create
            clsCustomer customer = new clsCustomer();
            //string variable to store any error message
            String Error = "";
            //create a variable to store the test date data
            DateTime TestDate;
            //set the date totodays date
            TestDate = DateTime.Now.Date;
            //change the date to whatever the date plus 100 years
            TestDate = TestDate.AddYears(100);
            //convert the date variable to a string variable
            customer.AccountCreationDate = TestDate;
            //invoke the method
            Error = customer.Valid();
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        #endregion

        //--Database Connection Test--

        [TestMethod]
        public void FindCustomerOK()
        {
            clsCustomer CustomerDatabaseTest = new clsCustomer();

            Assert.IsTrue(CustomerDatabaseTest.Find(2));
        }
    }
}
