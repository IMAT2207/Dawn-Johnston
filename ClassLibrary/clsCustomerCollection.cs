using System.Collections.Generic;
using System;

namespace ClassLibrary
{


    public class clsCustomerCollection
    {
        //Private data member for the list
        List<clsCustomer> mCustomerList = new List<clsCustomer>();
        //Private data member for ThisCustomer
        clsCustomer mThisCustomer = new clsCustomer();
        
        //Class constructor
        public clsCustomerCollection()
        {
            //Object for data conneciton
            clsDataConnection DB = new clsDataConnection();
            //Execute the stored procedure
            DB.Execute("sproc_tblCustomer_SelectAll");
            //Populate the array list with the data table
            PopulateArray(DB);
        }

        public List<clsCustomer> CustomerList
        {
            get
            {
                //Return private data
                return mCustomerList;
            }
            set
            {
                //Set the private data
                mCustomerList = value;
            }
        }
        public int Count
        {
            get
            {
                //Return private data
                return mCustomerList.Count;
            }
            set
            {

            }
        }
        public clsCustomer ThisCustomer
        {
            get
            {
                //Return private data
                return mThisCustomer;
            }
            set
            {
                //Set the private data
                mThisCustomer = value;
            }
        }



        public int Add()
        {
            //Adds a new record to the database based on the values of mThisCustomer
            //Connect to the dayabase
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@TraderPassword", mThisCustomer.TraderPassword);
            DB.AddParameter("@BusinessName", mThisCustomer.BusinessName);
            DB.AddParameter("@ContactEmail", mThisCustomer.ContactEmail);
            DB.AddParameter("@DeliveryAddress", mThisCustomer.DeliveryAddress);
            DB.AddParameter("@AccountCreationDate", mThisCustomer.AccountCreationDate);
            DB.AddParameter("@IsSignedIn", mThisCustomer.IsSignedIn);
            DB.AddParameter("@NumberOfOrders", mThisCustomer.NumberOfOrders);
            //Execute the query returning the Primary Key Value
            return DB.Execute("sproc_tblCustomer_Insert");
        }

        public void Update()
        {
            //Adds a new record to the database based on the values of mThisCustomer
            //Connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@TraderID", mThisCustomer.TraderId);
            DB.AddParameter("@TraderPassword", mThisCustomer.TraderPassword);
            DB.AddParameter("@BusinessName", mThisCustomer.BusinessName);
            DB.AddParameter("@ContactEmail", mThisCustomer.ContactEmail);
            DB.AddParameter("@DeliveryAddress", mThisCustomer.DeliveryAddress);
            DB.AddParameter("@AccountCreationDate", mThisCustomer.AccountCreationDate);
            DB.AddParameter("@IsSignedIn", mThisCustomer.IsSignedIn);
            DB.AddParameter("@NumberOfOrders", mThisCustomer.NumberOfOrders);
            //Execute the query returning the Primary Key Value
            DB.Execute("sproc_tblCustomer_Update");
        }

        public void Delete()
        {
            //Deletes a record pointed from mThisCustomer
            //Connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@TraderID", mThisCustomer.TraderId);
            //Execute the stored procedure
            DB.Execute("sproc_tblCustomer_Delete");
        }

        public void ReportByBusinessName(string BusinessName)
        {
            //Filters records based on the business name
            //Connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@BusinessName", BusinessName);
            //Execute the stored procedure
            DB.Execute("sproc_tblCustomer_FilterByBusinessName");
            //Populate the array list with the data table
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //Variable for the index
            Int32 Index = 0;
            //Variable to store record count
            Int32 RecordCount;
            //Get the count of records
            RecordCount = DB.Count; 
            //Clear the private array list
            mCustomerList = new List<clsCustomer>();
            //While there are records to process
            while (Index < RecordCount)
            {
                //Create a blank Customer
                clsCustomer customer = new clsCustomer();
                //Read the fields in the current record
                customer.TraderId = Convert.ToInt32(DB.DataTable.Rows[Index]["TraderID"]);
                customer.TraderPassword = Convert.ToString(DB.DataTable.Rows[Index]["TraderPassword"]);
                customer.BusinessName = Convert.ToString(DB.DataTable.Rows[Index]["BusinessName"]);
                customer.ContactEmail = Convert.ToString(DB.DataTable.Rows[Index]["ContactEmail"]);
                customer.DeliveryAddress = Convert.ToString(DB.DataTable.Rows[Index]["DeliveryAddress"]);
                customer.AccountCreationDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["AccountCreationDate"]);
                customer.IsSignedIn = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsSignedIn"]);
                customer.NumberOfOrders = Convert.ToInt32(DB.DataTable.Rows[Index]["NumberOfOrders"]);

                //Add the record to the private object
                mCustomerList.Add(customer);
                Index++;
            }
        }
    }
}