using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsOrderCollection
    {
        public List<clsOrder> OrderList { get; set; } = new List<clsOrder>();
        
        public clsOrder ThisOrder { get; set; }

        public int count => (OrderList == null) ? 0 : OrderList.Count;

        public clsOrderCollection()
        {
            Populate();
        }

        public clsOrderCollection(clsOrder thisOrder)
        {
            ThisOrder = thisOrder;
        }


        private void Populate()
        {
            OrderList.Add(new clsOrder(1));
            OrderList.Add(new clsOrder(1));
        }

        #region operations
        public Int32 Add() { 

            clsDataConnection DB = clsDataConnection.dataConnection;
            DB.SQLParams.Clear();
            DB.AddParameter("ProcessedBy", ThisOrder.ProcessedBy);
            DB.AddParameter("OrderedBy", ThisOrder.OrderedBy);
            DB.AddParameter("PlacedOn", ThisOrder.PlacedOn);
            DB.AddParameter("DeliveryNote", ThisOrder.DeliveryNote);
            DB.AddParameter("OrderState", ThisOrder.State.ToString());
            DB.AddParameter("PaidFor", ThisOrder.PaidFor);
            return DB.Execute("sproc_tblOrder_Insert");
        }

        public void FilterByCustomerID(String customerID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@param1", customerID);
            DB.Execute("sproc_tblOrder_FilterByCustomerID");
            for (int i = 0; i < DB.Count; i++)
            {
                clsOrder order = new clsOrder();
                order.Find(Convert.ToInt32(DB.DataTable.Rows[i]["OrderID"]));
                OrderList.Add(order);
            }
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@OrderID", ThisOrder.OrderID);
            DB.Execute("sproc_tblOrder_Delete");

        }

        public int Update()
        {
            return 0;
        }

        #endregion
    }
}