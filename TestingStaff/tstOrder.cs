using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace Testing4
{
    [TestClass]
    public class tstOrder
    {

        public clsOrder createOrder()
        {
            clsOrder order = new clsOrder();
            order.Find(1);
            return order;
        }

        [TestMethod]
        public void InstanceOK()
        {
            clsOrder order = new clsOrder();
            clsOrderItem orderItem = new clsOrderItem();
            Assert.IsNotNull(order);
            Assert.IsNotNull(orderItem);
        }

        [TestMethod]
        public void AttributeOrderStateOK()
        {
            clsOrder order = createOrder();
            bool valid = false;
            Assert.IsNotNull(order.OrderState);


            foreach (String s in clsOrder.ORDER_STATES)             // Check in range
                if (s.Equals(order.OrderState))
                {
                    valid = true;
                    break;
                }

            Assert.IsTrue(valid);

        }

        [TestMethod]
        public void AttributeOrderedByOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(new clsCustomer().Find(order.OrderedBy)); // Check foriegn key exists
            Assert.IsNotNull(order.OrderedBy);                       // Check 
        }

        [TestMethod]
        public void AttributePlacedOnOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(order.OrderedBy);                       // Check foriegn key exists
        }

        [TestMethod]
        public void AttributeDeliveryNoteOK()
        {
            clsOrder order = createOrder();
            Assert.IsTrue(order.DeliveryNote.Length <= 50);
        }

        [TestMethod]
        public void AttributePaidForOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(order.PaidFor);
        }

        [TestMethod]
        public void AttributeOrderIDOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(order.OrderID);
        }

        [TestMethod]
        public void AttributeProductIDOK()
        {
            clsOrderItem order = new clsOrderItem();
            Assert.IsNotNull(order.ProductID);
            Assert.IsNotNull(new clsStock().Find(order.ProductID));
        }

        [TestMethod]
        public void AttributeProcessedByOK()
        {

        }
    }
}
