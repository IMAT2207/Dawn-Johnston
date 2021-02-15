using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary;

namespace Testing4
{
    [TestClass]
    public class tstCustomer
    {

        public clsCustomer createCustomer()
        {
            clsCustomer order = new clsCustomer();
            order.Find(1);
            return order;
        }

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
            Assert.IsTrue(customer.TraderPassword.Length > 0 && customer.TraderPassword.Length <= 50);
        }

        [TestMethod]
        public void AttributeBusinesNameOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.BusinessName);
            Assert.IsTrue(customer.BusinessName.Length > 0 && customer.BusinessName.Length <= 50);
        }

        [TestMethod]
        public void AttributeContactEmailOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.ContactEmail);
            Assert.IsTrue(customer.ContactEmail.Length > 0 && customer.ContactEmail.Length <= 50);
        }

        [TestMethod]
        public void AttributeDeliveryAddressOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.DeliveryAddress);
            Assert.IsTrue(customer.DeliveryAddress.Length > 0 && customer.DeliveryAddress.Length <= 50);
        }

        [TestMethod]
        public void AttributeAccountCreationOk()
        {
            clsCustomer customer = new clsCustomer();
            Assert.IsNotNull(customer.AccountCreation);
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


    }
}
