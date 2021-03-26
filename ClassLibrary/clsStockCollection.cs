using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStockCollection
    {
        //private data member for the list
        List<clsStock> mStockList = new List<clsStock>();
        //private data member thisStock
        clsStock mThisStock = new clsStock();
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
        public clsStock ThisStock
        {
            get
            {
                //return the private data
                return mThisStock;
            }
            set
            {
                //set the private data
                mThisStock = value;
            }
        }

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
            DB.Execute("sproc_tblStock_SelectAll");
            //get the count of records
            RecordCount = DB.Count;
            //while there are records to process
            while(Index < RecordCount)
            {
                //create a blank stock
                clsStock AStock = new clsStock();
                //read in the fields from the current record
                AStock.ProductId = Convert.ToInt32(DB.DataTable.Rows[Index]["ProductId"]);
                AStock.ProductName = Convert.ToString(DB.DataTable.Rows[Index]["ProductName"]);
                AStock.ProductDescription = Convert.ToString(DB.DataTable.Rows[Index]["ProductDescription"]);
                AStock.IsAvailable = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsAvailable"]);
                AStock.QuantityAvailable = Convert.ToInt32(DB.DataTable.Rows[Index]["QuantityAvailable"]);
                AStock.RestockDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["RestockDate"]);
                //add the record to the private data member
                mStockList.Add(AStock);
                //point at the next record
                Index++;
            }
        }

        public int Add()
        {
            //add a new record to the database based on the values of thisStock
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@ProductName", mThisStock.ProductName);
            DB.AddParameter("@ProductDescription", mThisStock.ProductDescription);
            DB.AddParameter("@IsAvabile", mThisStock.IsAvailable);
            DB.AddParameter("@QuantityAvailable", mThisStock.QuantityAvailable);
            DB.AddParameter("@RestockDate", mThisStock.RestockDate);
            //execute the query returning the primary key value
            return DB.Execute("sproc_tblStock_Insert");
        }

        public void Update()
        {
            //update an existing record based on the values of thisStock
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@ProductID", mThisStock.ProductId);
            DB.AddParameter("@ProductName", mThisStock.ProductName);
            DB.AddParameter("@ProductDescription", mThisStock.ProductDescription);
            DB.AddParameter("@IsAvailable", mThisStock.IsAvailable);
            DB.AddParameter("@QuantityAvailable", mThisStock.QuantityAvailable);
            DB.AddParameter("@RestockDate", mThisStock.RestockDate);
            //execute the stored procedure
            DB.Execute("spro_tblStock_Update");
        }
    }
}