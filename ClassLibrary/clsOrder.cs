using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class clsOrder
    {
        int OrderID;
        string OrderState;
        static readonly string[] ORDER_STATES = new string[] { "WIP", "Finalized", "Shipped", "Delivered" };
        int ProcessedBy;
        int OrderedBy;
        DateTime PlacedOn;
        string DelieveryNote;
        Boolean PaidFor;
    }

    class clsOrderItem
    {
        string OrderItemID;
        int OrderID;
        int ProductID;
    }
}
