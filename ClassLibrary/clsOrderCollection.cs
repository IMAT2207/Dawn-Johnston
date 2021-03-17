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
            ThisOrder = new clsOrder(123);

            clsDataConnection DB = clsDataConnection.dataConnection;

            DB.AddParameter("ProcessedBy", ThisOrder.ProcessedBy);
            DB.AddParameter("OrderedBy", ThisOrder.OrderedBy);
            DB.AddParameter("PlacedOn", ThisOrder.PlacedOn);
            DB.AddParameter("DeliveryNote", ThisOrder.DeliveryNote);
            DB.AddParameter("OrderState", ThisOrder.State);
            DB.AddParameter("PaidFor", ThisOrder.PaidFor);
            return DB.Execute("sproc_tblOrder_Insert");
        }

        public void Delete()
        {

        }

        public void Update()
        {

        }

        #endregion
    }
}