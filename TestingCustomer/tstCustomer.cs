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

        //--Database Connection Test--

        [TestMethod]
        public void FindCustomerOK()
        {
            clsCustomer CustomerDatabaseTest = new clsCustomer();

            Assert.IsTrue(CustomerDatabaseTest.Find(2));
        }
    }
}
