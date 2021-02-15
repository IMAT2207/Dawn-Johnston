using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsOrder
    {
        public int OrderID;
        public string OrderState;
        public static readonly string[] ORDER_STATES = new string[] { "WIP", "Finalized", "Shipped", "Delivered" };
        public int ProcessedBy;
        public int OrderedBy;
        public DateTime PlacedOn;
        public string DeliveryNote;
        public Boolean PaidFor;

        public clsOrder() => Find(1);

        public bool Find(int ID)
        {
            OrderID = 1;
            OrderState = "WIP";
            ProcessedBy = 100;
            OrderedBy = 420;
            PlacedOn = DateTime.Now;
            DeliveryNote = "Leave at door";
            PaidFor = true;
            return true;
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
