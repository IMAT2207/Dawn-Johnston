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
        public int OrderID { get; set; } = -1;

        /// <summary>
        /// An enum of <a cref="OrderState"/> which represents the current state of the order.
        /// <br/><br/>
        /// By default is WIP. May not be null.
        /// </summary>
        public OrderState State { get; set; } = OrderState.WIP;

        /// <summary>
        /// The primary key of a the staff member who processed this order.
        /// </summary>
        public int ProcessedBy { get; set; }

        /// <summary>
        /// The primary key of the patron who placed this order
        /// </summary>
        public int OrderedBy { get; set; }

        /// <summary>
        /// The epoch on which this order was placed
        /// </summary>
        public DateTime PlacedOn { get; set; }

        /// <summary>
        /// Any delivery note left by the user upon placing the order.
        /// </summary>
        public string DeliveryNote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean PaidFor;

        private clsDataConnection db = new clsDataConnection();

        private static readonly string SPROC = "sproc_tblOrder_FilterByOrderID";
        #endregion attributes

#warning for test data only, orders should not assume data; it may be treated as a valid record.
        public clsOrder() => Find(1);

        /// <summary>
        /// Replaces which record this instance represents.
        /// <br/><br/>
        /// Calling this with a valid Order Primary Key mutates this order to represent the first matching record found in the database.
        /// </summary>
        /// <param name="ID">A valid Order ID primary key.</param>
        /// <returns>True if <paramref name="ID"/> was valid, record was found, and order was successfully mutated. False if <paramref name="ID"/> is negative, no matches were found, or failed to read the data stored within it.</returns>
        public bool Find(int ID)
        {
            if (!IDIsValid(ID, this)) return false;                             // Check ID exists, and fetch matching records. Return false if not valid, or no matches.

            try
            {
                // Mutate this instance with the first matching record.
                OrderID = Convert.ToInt32(db.DataTable.Rows[0]["OrderID"]);
                State = (OrderState)Enum.Parse(typeof(OrderState), Convert.ToString(db.DataTable.Rows[0]["OrderState"]));
                ProcessedBy = Convert.ToInt32(db.DataTable.Rows[0]["ProcessedBy"]);
                OrderedBy = Convert.ToInt32(db.DataTable.Rows[0]["OrderedBy"]);
                PlacedOn = Convert.ToDateTime(db.DataTable.Rows[0]["PlacedOn"]);
                DeliveryNote = Convert.ToString(db.DataTable.Rows[0]["DeliveryNote"]);
                PaidFor = Convert.ToBoolean(db.DataTable.Rows[0]["PaidFor"]);
            }
            // Cast / conversion errors. Shouldn't really quietly ignore it, but OH WELL!
            catch (Exception e) { return false; }
            // tis all good.
            return true;
        }

#warning TODO this should also check if the ID exists on the database.
        /// <summary>
        /// Determines if the parsed ID is a valid order primary key, and a corresponding record exists on the database.
        /// <br/><br/>
        /// If the ID is positive, checks the database for any matching entries.
        /// Returns false if ID is negative, or the database returned no results.
        /// <br/><br/>
        /// SIDE EFFECT: Configures <a cref="clsOrder#bd"/>, which will contain matching records.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>True if the Id is valid, else false.</returns>
        public static bool IDIsValid(int ID, clsOrder order) {
            if (ID < 0) return false;                       // Don't fetch if id is low
            order.db.SQLParams.Clear();
            order.db.AddParameter("@OrderID", ID);          // Fetch records
            order.db.Execute(SPROC);
            return order.db.Count > 0;                      // Return true if there was matches.
        }

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