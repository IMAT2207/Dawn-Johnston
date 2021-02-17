using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    /// <summary>
    /// A mutable, managed and validated representation of a database Order record.  
    /// </summary>
    public class clsOrder
    {
        #region constants
        /// <summary>
        /// Valid values for <a cref="OrderState"/>.
        /// </summary>
        public enum OrderState { WIP, Finalized, Shipped, Delivered };
        #endregion


        #region attributes
        /// <summary>
        /// The primary key of this order.
        /// </br></br>
        /// Cannot be null. If no order ID is found or assigned, will be -1/
        /// </summary>
        public int OrderID = -1;

        /// <summary>
        /// An enum of <a cref="OrderState"/> which represents the current state of the order.
        /// <br/><br/>
        /// By default is WIP. May not be null.
        /// </summary>
        public OrderState State = OrderState.WIP;

        /// <summary>
        /// The primary key of a the staff member who processed this order.
        /// </summary>
        public int ProcessedBy;

        /// <summary>
        /// The primary key of the patron who placed this order
        /// </summary>
        public int OrderedBy;

        /// <summary>
        /// The epoch on which this order was placed
        /// </summary>
        public DateTime PlacedOn;

        /// <summary>
        /// Any delivery note left by the user upon placing the order.
        /// </summary>
        public string DeliveryNote;

        /// <summary>
        /// 
        /// </summary>
        public Boolean PaidFor;
        #endregion attributes

        #warning for test data only, orders should not assume data; it may be treated as a valid record.
        public clsOrder() => Find(1);

        /// <summary>
        /// Replaces which record this instance represents.
        /// <br/><br/>
        /// Calling this with a valid Order Primary Key mutates this order to represent that record from the database.
        /// </summary>
        /// <param name="ID">A valid Order ID primary key.</param>
        /// <returns>True if ID was valid, record was found, and order was successfully mutated.</returns>
        public bool Find(int ID)
        {
            if (!IDIsValid(ID)) return false;

            OrderID = ID;
            State = OrderState.WIP;
            ProcessedBy = 100;
            OrderedBy = 420;
            PlacedOn = DateTime.Now;
            DeliveryNote = "Leave at door";
            PaidFor = true;
            return true;
        }

        #warning TODO this should also check if the ID exists on the database.
        /// <summary>
        /// Determines if the parsed ID is a valid order primary key, and a corresponding record exists on the database.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>True if the Id is valid, else false.</returns>
        public static bool IDIsValid(int ID) => ID > 0;
    }

    public class clsOrderItem
    {
        public bool Find(int ID)
        {
            OrderItemID = "12";
            ProductID = 1;
            OrderID = 1;
            return true;
        }

        public string OrderItemID;
        public int OrderID;
        public int ProductID;
    }
}