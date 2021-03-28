using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using ClassLibrary;
using System.Collections.Generic;

namespace TestingOrder
{
    [TestClass]
    public class tstOrder
    {

// order item objects not implemented, they weren't required.
//       [TestMethod]
//       public void AttributeProductIDOK()
//       {
//           clsOrderItem order = new clsOrderItem(0);
//           Assert.IsNotNull(order.ProductID);
//           Assert.IsNotNull(new clsStock().Find(order.ProductID));
//       }

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
            try
            {
                order.SetOrderID(int.MaxValue);
                Assert.Fail();
            }
            catch (Exception ignored) { }
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
            Assert.IsTrue(order.Valid().Length != 0);
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
            Assert.IsTrue(order.Valid().Length == 0); // State will still be valid, it will not be set to null.
        }

        [TestMethod]
        public void OrderStateInvalid()
        {
            clsOrder order = createOrder();
            order.SetOrderState("This is not a valid state. Take that, code.");
            Assert.IsTrue(order.Valid().Length == 0); // State will be valid, it will not be set.
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

            Assert.IsFalse(order.SetOrderedBy(-1)); // Throws an exception if ID is not valid.

        }

        [TestMethod]
        public void OrderedByExtremeMin()
        {
            clsOrder order = createOrder();
            Assert.IsFalse(order.SetOrderedBy(int.MinValue)); // Fails if below 0.
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

        #region orderCollection

        [TestMethod]
        public void CollectionInstanceOK()
        {
            Assert.IsNotNull(new clsOrderCollection());
        }
        
 //       [TestMethod]
 //       public void CollectionCountPropOK()
 //       {
 //           clsOrderCollection collection = new clsOrderCollection();
 //           Int32 count = 1;
 //          collection.count = count;
 //          Assert.AreEqual(count, collection.count);
 //       }
       
        [TestMethod]
        public void CollectionOrderPropOK()
        {
            clsOrderCollection collection = new clsOrderCollection();

            // Create and populate an order with db record #1
            clsOrder order = new clsOrder(1);

            collection.ThisOrder = order;
        }
        
        [TestMethod]
        public void CollectionOrderListPropOK()
        {
            clsOrderCollection collection = new clsOrderCollection();
            List<clsOrder> OrderList = new List<clsOrder>();

            // Create and populate an order with db record #1
            OrderList.Add(new clsOrder(1));

            collection.OrderList = OrderList;
            Assert.AreEqual(collection.OrderList, OrderList);
        }

// Now that we're accessing the database, this is obsolete. Database may have more than 2 records.
//        [TestMethod]
//        public void Collection2RecsPresent()
//        {
//            clsOrderCollection collection = new clsOrderCollection();
//            Assert.AreEqual(collection.count, 2);
//        }

        [TestMethod]
        public void CollectionCountOK()
        {
            clsOrderCollection collection = new clsOrderCollection();
            List<clsOrder> OrderList = new List<clsOrder>();

            // Create and populate an order with db record #1
            OrderList.Add(new clsOrder(1));
            OrderList.Add(new clsOrder(1));
            OrderList.Add(new clsOrder(1));


            collection.OrderList = OrderList;
            Assert.AreEqual(collection.count, OrderList.Count);
        }


        #endregion

    }
}
