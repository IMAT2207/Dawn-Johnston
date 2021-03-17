using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsOrderCollection
    {
        public List<clsOrder> OrderList { get; set; }
        
        public clsOrder ThisOrder { get; set; }

        public int count => (OrderList == null) ? 0 : OrderList.Count;

        public clsOrderCollection()
        {
            OrderList.Add(new clsOrder(1));
            OrderList.Add(new clsOrder(1));
        }

        #region operations
        public Int32 Add() => 0;

        public void Delete()
        {

        }

        public void Update()
        {

        }

        #endregion
    }
}