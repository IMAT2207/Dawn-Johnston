using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace TestingOrder
{
    [TestClass]
    public class tstOrder
    {


        [TestMethod]
        public void AttributeProductIDOK()
        {
            clsOrderItem order = new clsOrderItem();
            Assert.IsNotNull(order.ProductID);
            Assert.IsNotNull(new clsStock().Find(order.ProductID));
        }

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
        public void AttributeProcessedByOK()
        {

        }

        #region OrderID
        [TestMethod]
        public void AttributeOrderIDOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(order.OrderID);
        }

        [TestMethod]
        public void OrderIDMin()
        {
            clsOrder order = createOrder();
            order.SetOrderID(0);
            Assert.IsTrue(order.Valid().Length == 0);
        }

        [TestMethod]
        public void OrderIDMinMinus1()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderID(-1);
                Assert.Fail();
            }catch (Exception ignored) {}
            Assert.IsTrue(order.Valid().Length == 0);
        }

        [TestMethod]
        public void OrderIDExtremeMin()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderID(int.MinValue);
                Assert.Fail();
            }
            catch (Exception ignored) { }
            Assert.IsTrue(order.Valid().Length == 0);
        }


        [TestMethod]
        public void OrderIDMax()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderID(int.MaxValue);
                Assert.Fail();
            }
            catch (Exception ignored) { }
            Assert.IsTrue(order.Valid().Length == 0);
        }

        [TestMethod]
        public void OrderIDMaxPlus1()
        {
            // Test is impossible, value overflows at compile time, raw converts to unsigned integer
        }

        [TestMethod]
        public void OrderIDExtremeMax()
        {
            clsOrder order = createOrder();
            order.SetOrderID(int.MaxValue);
            Assert.IsTrue(order.Valid().Length == 0);
        }
        #endregion OrderID

        #region PaidFor

        [TestMethod]
        public void AttributePaidForOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(order.PaidFor);
        }

        [TestMethod]
        public void PaidForFalse()
        {
            clsOrder order = createOrder();
            order.PaidFor = false;
            Assert.IsTrue(order.Valid().Length == 0);
        }

        [TestMethod]
        public void PaidForTrue()
        {
            clsOrder order = createOrder();
            order.PaidFor = true;
            Assert.IsTrue(order.Valid().Length == 0);
        }

        #endregion PaidFor

        #region OrderState
        [TestMethod]
        public void AttributeOrderStateOK()
        {
            clsOrder order = createOrder();
            bool valid = false;
            Assert.IsNotNull(order.State);
            valid = Enum.IsDefined(typeof(clsOrder.OrderState), order.State); // Not sure this will be valid, but we'll see i guess.
            Assert.IsTrue(valid);

        }

        [TestMethod]
        public void OrderStateNull()
        {
            clsOrder order = createOrder();
            order.SetOrderState(null);
            Assert.IsTrue(order.Valid().Length != 0); // Unsure of expected result atm
        }

        [TestMethod]
        public void OrderStateInvalid()
        {
            clsOrder order = createOrder();
            order.SetOrderState("This is not a valid state. Take that, code.");
            Assert.IsTrue(order.Valid().Length == 0); // unsure
        }
        #endregion OrderState

        #region PlacedOn

        [TestMethod]
        public void AttributePlacedOnOK()
        {
            clsOrder order = createOrder();
            Assert.IsNotNull(order.OrderedBy);                       // Check foriegn key exists
        }

        [TestMethod]
        public void PlacedOnDate()
        {
            clsOrder order = createOrder();
            order.SetPlacedOn(DateTime.Now);
            Assert.IsTrue(order.Valid().Length == 0);
        }


        [TestMethod]
        public void PlacedOnNull()
        {
            // impossible, setter does not accept nullable values
        }
        #endregion PlacedOn

        #region DeliveryNote
        [TestMethod]
        public void AttributeDeliveryNoteOK()
        {
            clsOrder order = createOrder();
            Assert.IsTrue(order.DeliveryNote.Length <= 50);
        }

        [TestMethod]
        public void DeliveryNoteMin()
        {
            clsOrder order = createOrder();
            order.SetDeliveryNote("");
            Assert.IsTrue(order.Valid().Length == 0);
        }

        [TestMethod]
        public void DeliveryNoteMinMinus1()
        {
            // Impossible, can't have a string less that length == 0
        }

        [TestMethod]
        public void DeliveryNoteMax()
        {
            clsOrder order = createOrder();
            order.SetDeliveryNote("Note Note Note Note Note Note Note Note Note Note ");
            Assert.IsTrue(order.Valid().Length == 0); // Should set, so we should see it
            Assert.IsTrue(order.DeliveryNote.Equals("Note Note Note Note Note Note Note Note Note Note "));
        }

        [TestMethod]
        public void DeliveryNoteMaxPlus1()
        {
            clsOrder order = createOrder();
            order.SetDeliveryNote("Note Note Note Note Note Note Note Note Note Note  ");
            Assert.IsTrue(order.Valid().Length == 0); // Message will not be set, so there will be no errors.
            Assert.IsTrue(order.DeliveryNote.Equals("")); // Should be empty, since it will not set if it's too long.
        }

        [TestMethod]
        public void DeliveryNoteExtremeMax()
        {
            clsOrder order = createOrder();
            order.SetDeliveryNote("Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note Note ");
            // This should note set, since it's too long. Thus this message should not be found 
            Assert.IsFalse(order.Valid().Contains("Delivery note is too long!"));
            // In fact, there should be no error messages.
            Assert.IsTrue(order.Valid().Length == 0);
        }
        #endregion DeliveryNote

        #region OrderedBy

        [TestMethod]
        public void AttributeOrderedByOK()
        {
            clsOrder order = createOrder();
            order.SetOrderedBy(1);
            Assert.IsNotNull(new clsCustomer().Find(order.OrderedBy)); // Check foriegn key exists
            Assert.IsNotNull(order.OrderedBy);                       // Check 
        }

        [TestMethod]
        public void OrderedByMin()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderedBy(0);
            } catch (Exception e)
            {
                Assert.Fail(); // Will fail if there is no customer with id 0
            }
        }

        [TestMethod]
        public void OrderedByMinMinus1()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderedBy(-1); // Throws an exception if ID is not valid.
            } catch (Exception e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void OrderedByExtremeMin()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderedBy(int.MinValue); // Throws an exception if ID is not valid.
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void OrderedByMax()
        {
            clsOrder order = createOrder(); try
            {
                order.SetOrderedBy(int.MaxValue);  // Throws an exception if no customer exists with this ID
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void OrderedByExtremeMax()
        {
            clsOrder order = createOrder();
            try
            {
                order.SetOrderedBy(int.MaxValue); // Throws an exception of ID is not valid.
            } catch (Exception e)
            {
                Assert.Fail();
            }

        }
        #endregion OrderedBy

    }
}
