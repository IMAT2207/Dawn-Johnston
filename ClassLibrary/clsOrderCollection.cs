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
            clsDataConnection.dataConnection = new clsDataConnection();
            clsDataConnection.dataConnection.Execute("sproc_tblOrder_SelectAll");
            int Count = clsDataConnection.dataConnection.Count;
            int Index = 0;

            while (Index < Count)
            {
                OrderList.Add(new clsOrder(Index));
                Index++;
            }
        }

        #region operations
        public Int32 Add() { 

            clsDataConnection DB = clsDataConnection.dataConnection;
            DB.SQLParams.Clear();
            DB.AddParameter("ProcessedBy",  ThisOrder.ProcessedBy);
            DB.AddParameter("OrderedBy",    ThisOrder.OrderedBy);
            DB.AddParameter("PlacedOn",     ThisOrder.PlacedOn);
            DB.AddParameter("DeliveryNote", ThisOrder.DeliveryNote);
            DB.AddParameter("OrderState",   ThisOrder.State.ToString());
            DB.AddParameter("PaidFor",      ThisOrder.PaidFor);
            ThisOrder.SetOrderID(DB.Execute("sproc_tblOrder_Insert"));
            return ThisOrder.OrderID;
        }

        public void FilterByCustomerID(String customerID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@param1", customerID);
            DB.Execute("sproc_tblOrder_FilterByCustomerID");
            OrderList.Clear();
            for (int i = 0; i < DB.DataTable.Rows.Count; i++)
            {
                clsOrder order = new clsOrder();
                order.Find(Convert.ToInt32(DB.DataTable.Rows[i]["OrderID"]));
                OrderList.Add(order);
            }
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@param1", ThisOrder.OrderID);
            DB.Execute("sproc_tblOrder_Delete");
        }

        public int Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.SQLParams.Clear();
            DB.AddParameter("OrderId", ThisOrder.OrderID);
            DB.AddParameter("ProcessedBy", ThisOrder.ProcessedBy);
            DB.AddParameter("OrderedBy", ThisOrder.OrderedBy);
            DB.AddParameter("PlacedOn", ThisOrder.PlacedOn);
            DB.AddParameter("DeliveryNote", ThisOrder.DeliveryNote);
            DB.AddParameter("OrderState", ThisOrder.State.ToString());
            DB.AddParameter("PaidFor", ThisOrder.PaidFor);
            ThisOrder.SetOrderID(DB.Execute("sproc_tblOrder_Update"));
            return ThisOrder.OrderID;
        }
        #endregion
    }
}