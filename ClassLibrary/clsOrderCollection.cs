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

        public void Delete()
        {

        }

        public int Update()
        {
            return 0;
        }

        #endregion
    }
}