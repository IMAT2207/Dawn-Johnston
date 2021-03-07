using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{

    public class clsCustomer
    {
        public static readonly int CUST_ID_MAX = int.MaxValue;

        private int PrivTraderId;
        public int TraderID
        {
            get
            {
                return PrivTraderId;
            }
            set
            {
                PrivTraderId = value;
            }
        }

        private string PrivTraderPassword;
        public string TraderPassword
        {
            get
            {
                return PrivTraderPassword;
            }
            set
            {
                PrivTraderPassword = value;
            }
        }

        private string PrivBusinessName;
        public string BusinessName
        {
            get
            {
                return PrivBusinessName;
            }
            set
            {
                PrivBusinessName = value;
            }
        }

        private string PrivContactEmail;
        public string ContactEmail
        {
            get
            {
                return PrivContactEmail;
            }
            set
            {
                PrivContactEmail = value;
            }
        }

        private string PrivDeliveryAddress;
        public string DeliveryAddress
        {
            get
            {
                return PrivDeliveryAddress;
            }
            set
            {
                PrivDeliveryAddress = value;
            }
        }

        private DateTime PrivAccountCreationDate;
        public DateTime AccountCreationDate
        {
            get
            {
                return PrivAccountCreationDate;
            }
            set
            {
                PrivAccountCreationDate = value;
            }
        }

        private int PrivNumberOfOrders;
        public int NumberOfOrders
        {
            get
            {
                return PrivNumberOfOrders;
            }
            set
            {
                PrivNumberOfOrders = value;
            }
        }

        private bool PrivIsSignedIn;
        public bool IsSignedIn
        {
            get
            {
                return PrivIsSignedIn;
            }
            set
            {
                PrivIsSignedIn = value;
            }
        }

        //When creating a customer default settings from entry "2" are utilised 
        public clsCustomer() => Find(2);

        public bool Find(int ID)
        {
            //Creation of an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //Adding prameter for search
            DB.AddParameter("@TraderID", ID);
            //Execute the procedure
            DB.Execute("sproc_tblCustomer_FilterByTraderId");
            //If data is found
            if (DB.Count == 1)
            {
                PrivTraderId = Convert.ToInt32(DB.DataTable.Rows[0]["TraderId"]);
                PrivTraderPassword = Convert.ToString(DB.DataTable.Rows[0]["TraderPassword"]);
                PrivBusinessName = Convert.ToString(DB.DataTable.Rows[0]["BusinessName"]);
                PrivContactEmail = Convert.ToString(DB.DataTable.Rows[0]["ContactEmail"]);
                PrivDeliveryAddress = Convert.ToString(DB.DataTable.Rows[0]["DeliveryAddress"]);
                PrivAccountCreationDate = Convert.ToDateTime(DB.DataTable.Rows[0]["AccountCreationDate"]);
                PrivNumberOfOrders = Convert.ToInt32(DB.DataTable.Rows[0]["NumberOfOrders"]);
                PrivIsSignedIn = Convert.ToBoolean(DB.DataTable.Rows[0]["IsSignedIn"]);
                //Return that the operation was completed
                return true;
            }
            else
            {
                //If no data is found
                return false;
            }
        }

        public void Valid()
        {

        }
    }
}
