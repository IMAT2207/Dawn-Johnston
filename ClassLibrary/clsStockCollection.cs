using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStockCollection
    {
        //private data member for the list
        List<clsStock> mStockList = new List<clsStock>();
        //public list for StockList
        public List<clsStock> StockList
        {
            get
            {
                //return the private data
                return mStockList;
            }
            set
            {
                //set the private data
                mStockList = value;
            }
        }
        //public property for count
        public int Count
        {
            get
            {
                //return the count of the list
                return mStockList.Count;
            }
            set
            {

            }
        }
        //public property for ThisStock
        public clsStock ThisStock { get; set; }

        //constructor for the class
        public clsStockCollection()
        {
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount = 0;
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("");
            //create the items of test data
            clsStock TestItem = new clsStock();
            //set its properties
            TestItem.ProductId = 1;
            TestItem.ProductName = "Beef";
            TestItem.ProductDescription = "Something Good";
            TestItem.IsAvailable = true;
            TestItem.QuantityAvailable = 1;
            TestItem.RestockDate = DateTime.Now.Date;
            //add the item to the test list
            mStockList.Add(TestItem);
            //re initialise the obkect for some new data
            TestItem = new clsStock();
            //set its properties
            TestItem.ProductId = 2;
            TestItem.ProductName = "Chicken";
            TestItem.ProductDescription = "Something Better";
            TestItem.IsAvailable = true;
            TestItem.QuantityAvailable = 1;
            TestItem.RestockDate = DateTime.Now.Date;
            //add the item to the test list
            mStockList.Add(TestItem);
        }
    }
}