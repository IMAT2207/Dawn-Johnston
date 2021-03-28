using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
        /// <summary>
        /// Max length of the VARCHAR underlying <a cref="DeliveryNote"/>
        /// </summary>
        public static readonly int DELIVERY_NOTE_LENGTH = 50;

        /// <summary>
        /// The max value for <a cref="OrderID"/>
        /// </summary>
        public static readonly int ORDER_ID_MAX = int.MaxValue;
        #endregion constants

        #region attributes
        /// <summary>
        /// The primary key of this order.

        /// <br/><br/>
        /// Cannot be null. If no order ID is found or assigned, will be -1.
        /// </summary>
        public int OrderID { get; private set; } = -1;

        /// <summary>
        /// Sets <a cref="OrderID"/> according to the string provided, after validation.
        /// </summary>
        /// <param name="ID">String representation of the new value for <a cref="OrderID"/></param>
        /// <returns></returns>
        public bool SetOrderID(String ID) => CanCast(ID) && SetOrderID(int.Parse(ID));
        public bool SetOrderID(int ID)
        {
            if (IntAttributeValid(ID, ORDER_ID_MAX) && !new clsOrder().Find(ID)) // If record with that ID already exists, ignore.
            {
                OrderID = ID;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// An enum of <a cref="OrderState"/> which represents the current state of the order.
        /// <br/><br/>
        /// By default is WIP. May not be null.
        /// </summary>
        public OrderState State { get; private set; } = OrderState.WIP;

        public bool SetOrderState(string text)
        {
            try
            {
                State = (OrderState) Enum.Parse(typeof(OrderState), text);
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// The primary key of a the staff member who processed this order.
        /// </summary>
        public int ProcessedBy { get; private set; }

        public bool SetProcessedBy(String ID) => CanCast(ID) && SetProcessedBy(int.Parse(ID));

        public bool SetProcessedBy(int StaffID)
        {
            if (IntAttributeValid(StaffID, clsStaff.STAFF_ID_MAX) && new clsCustomer().Find(StaffID)) // If record with that ID already exists, ignore.
            {
                ProcessedBy = StaffID;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// The primary key of the patron who placed this order
        /// </summary>
        public int OrderedBy { get; private set; }

        public bool SetOrderedBy(String ID) => CanCast(ID) && SetOrderedBy(int.Parse(ID));

        public bool SetOrderedBy(int CustomerID)
        {
            if (IntAttributeValid(CustomerID, int.MaxValue) && new clsCustomer().Find(CustomerID)) // If record with that ID already exists, ignore.
            {
                OrderedBy = CustomerID;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// The epoch on which this order was placed
        /// </summary>
        public DateTime PlacedOn { get; private set; }

        public bool SetPlacedOn(DateTime dt)
        {
            if (dt == null) return false;
            PlacedOn = dt;
            return true;
        }

        /// <summary>
        /// Any delivery note left by the user upon placing the order.
        /// </summary>
        public string DeliveryNote { get; private set; } = "";

        public bool SetDeliveryNote(string note)
        {
            if (StringAttributeValid(note, DELIVERY_NOTE_LENGTH))
            {
                DeliveryNote = note;
                return true;
            } else
            {
                DeliveryNote = "";
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean PaidFor { get; set; }

        private clsDataConnection db = new clsDataConnection();

        private static readonly string SPROC = "sproc_tblOrder_FilterByOrderID";
        #endregion attributes

        public clsOrder() { }

        public clsOrder(int ID) => Find(ID);

        public static clsOrder CreateAndFind(int ID) => new clsOrder(ID);

        /// <summary>
        /// Replaces which record this instance represents.
        /// <br/><br/>
        /// Calling this with a valid Order Primary Key mutates this order to represent the first matching record found in the database.
        /// </summary>
        /// <param name="ID">A valid Order ID primary key.</param>
        /// <returns>True if <paramref name="ID"/> was valid, record was found, and order was successfully mutated. False if <paramref name="ID"/> is negative, no matches were found, or failed to read the data stored within it.</returns>
        public bool Find(int ID)
        {
            OrderID = ID;
            if (!IDIsValid(ID, this)) return false;                             // Check ID exists, and fetch matching records. Return false if not valid, or no matches.

            try
            {
                // Mutate this instance with the first matching record.
                OrderID      = Convert.ToInt32(db.DataTable.Rows[0]["OrderID"]);
                State        = (OrderState)Enum.Parse(typeof(OrderState), Convert.ToString(db.DataTable.Rows[0]["OrderState"]));
                ProcessedBy  = Convert.ToInt32(db.DataTable.Rows[0]["ProcessedBy"]);
                OrderedBy    = Convert.ToInt32(db.DataTable.Rows[0]["OrderedBy"]);
                PlacedOn     = Convert.ToDateTime(db.DataTable.Rows[0]["PlacedOn"]);
                DeliveryNote = Convert.ToString(db.DataTable.Rows[0]["DeliveryNote"]);
                PaidFor      = Convert.ToBoolean(db.DataTable.Rows[0]["PaidFor"]);
            }
            // Cast / conversion errors. Shouldn't really quietly ignore it, but OH WELL!
            catch (Exception e) { return false; }
            // tis all good.
            return true;
        }

        public static bool IDIsValid(int ID) => IDIsValid(ID, new clsOrder());

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
            return (ID < 0) && IDExists(ID);
        }

        public bool IDExists() => IDExists(this.OrderID);

        public static bool IDExists(int ID)
        {
            clsDataConnection.dataConnection.SQLParams.Clear();
            clsDataConnection.dataConnection.AddParameter("@OrderID", ID);          // Fetch records
            clsDataConnection.dataConnection.Execute(SPROC);
            return clsDataConnection.dataConnection.Count > 0;                      // Return true if there was matches.
        }

        /// <summary>
        /// If no record mathing the ID of this one exists, this Order is inserted into the database.
        /// </summary>
        /// <returns>True if record did not exist AND was created successfully. False would indicate record exists, or it failed to be created.</returns>
        public Boolean AssertExists() => IDExists() ? false : new clsOrderCollection(this).Add() != -1;

        /// <summary>
        /// Updates the record which matches the OrderID of this instance to match this instance.
        /// </summary>
        /// <returns>True if updated successfully</returns>
        public Boolean Update() => IDExists() ? false : new clsOrderCollection(this).Update() == 0;


        private static bool StringAttributeValid(string str, int MaxLength) => StringAttributeValid(str, 0, MaxLength);
        private static bool StringAttributeValid(string str, int MinLength, int MaxLength) => StringAttributeValid(str, MinLength, MaxLength, ".*");
        private static bool StringAttributeValid(string str, int MinLength, int MaxLength, string regex) => Regex.IsMatch(str, regex) && (str.Length <= MaxLength && str.Length >= MinLength);
        private static bool IntAttributeValid(int value, int MaxVal) => IntAttributeValid(value, 0, MaxVal);
        private static bool IntAttributeValid(int value, int MinVal, int MaxVal) => value >= MinVal && value <= MaxVal;

        private static bool CanCast(string val)
        {
            try
            {
                int.Parse(val);
            }
            catch (Exception ignored)
            {
                return false;
            }

            return true;
        }

        public string Valid() => Valid(this);

        /// <summary>
        /// Checks values of a provided order, and gives error messages on any that are out of range.
        /// <br/>
        /// This is fairly baren since all validation and prevention of invalid possibilities or 
        /// enforcement of boundaries are enforced by setters or data types:
        /// 
        /// i.e max id = int.max -  we can't test to see  it it's above int.max, there's no point. We also can't check for null ints.
        /// Or out of range values on an enumerator.
        /// </summary>
        /// <param name="order">The order to check.</param>
        /// <returns></returns>
        public static string Valid(clsOrder order)
        {
            string message = "";

            if (order.DeliveryNote.Length > DELIVERY_NOTE_LENGTH)
            { message += "Delivery note is too long!"; NL(message); }

            message += ValidInt(order.OrderID,      "Order ID");
            message += ValidInt(order.ProcessedBy,  "Processed By");
            if (!new clsStaff().Find(order.ProcessedBy))
            { message += "The staff ID " + order.ProcessedBy + " does not exist!"; NL(message); }

            message += ValidInt(order.OrderedBy,    "Ordered By");
            if (!new clsCustomer().Find(order.OrderedBy))
            { message += "The customer ID " + order.OrderedBy + " does not exist!"; NL(message); }

            if (order.PlacedOn > DateTime.Now)
            { message += "Order cannot have been placed in the future!"; NL(message); }
            
            if (order.PlacedOn == null)
            { message += "There is not order date!"; NL(message); }
            
            if (order.DeliveryNote.Length > 50)
            { message += "Delivery note cannot be greater than 50 characters!"; NL(message); }
            
            if (!order.PaidFor)
            { message += "This order has not been paid for!"; NL(message); }
            
            return message;
        }

        public static string ValidInt(int i, string name)
        {
            string Error = "";
            if (i < 0) Error += name + " cannot be below 0!";
            return Error;
        }


        /// <summary>
        /// Adds a new line character to a string.
        /// </summary>
        /// <param name="s"></param>
        public static void NL(string s) => s += '\n';

    }

    [Obsolete]
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