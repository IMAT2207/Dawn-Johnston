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
        public int TraderId
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

        public static void NewLine(string ErrorMessage)
        {
            ErrorMessage += '\n';
        }

        public string Valid() => Valid(TraderId, TraderPassword, BusinessName, ContactEmail, DeliveryAddress, AccountCreationDate, NumberOfOrders, IsSignedIn);

        public static string Valid(  int TraderId, 
                            string TraderPassword,
                            string BusinessName,
                            string ContactEmail,
                            string DeliveryAddress,
                            DateTime AccountCreationDate,
                            int NumberOfOrders,
                            bool IsSignedIn )

        {
            string ErrorMessage = "";

            //--TraderId--
            if (TraderId < 0)
            {
                ErrorMessage += "TraderId cannot be less than 0";
                NewLine(ErrorMessage);
            }

            if (TraderId > int.MaxValue)
            {
                ErrorMessage += "TraderId cannot be greater than 2,147,483,647";
                NewLine(ErrorMessage);
            }

            //--TraderPassword--
            if (TraderPassword == null)
            {
                ErrorMessage += "TraderPassword cannot be null";
                NewLine(ErrorMessage);
            }

            if (TraderPassword.Length < 6)
            {
                ErrorMessage += "TraderPassword cannot be less than 50 characters";
                NewLine(ErrorMessage);
            }

            if (TraderPassword.Length > 50)
            {
                ErrorMessage += "TraderPassword cannot be longer than 50 characters";
                NewLine(ErrorMessage);
            }

            //--BusinessName--
            if (BusinessName == null)
            {
                ErrorMessage += "BusinessName cannot be null";
                NewLine(ErrorMessage);
            }

            if (BusinessName.Length > 50)
            {
                ErrorMessage += "BusinessName cannot be longer than 50 characters";
                NewLine(ErrorMessage);
            }

            //--ContactEmail--
            if (ContactEmail == null)
            {
                ErrorMessage += "ContactEmail cannot be null";
                NewLine(ErrorMessage);
            }

            if (ContactEmail.Length > 50)
            {
                ErrorMessage += "ContactEmail cannot be longer than 50 characters";
                NewLine(ErrorMessage);
            }

            //--DeliveryAddress--
            if (DeliveryAddress == null)
            {
                ErrorMessage += "DeliveryAddress cannot be null";
                NewLine(ErrorMessage);
            }

            if (DeliveryAddress.Length > 50)
            {
                ErrorMessage += "DeliveryAddress cannot be longer than 50 characters";
                NewLine(ErrorMessage);
            }

            //--AccountCreationDate--
            if (AccountCreationDate == null)
            {
                ErrorMessage += "AccountCreationDate cannot be null";
                NewLine(ErrorMessage);
            }

            if (AccountCreationDate > DateTime.Now)
            {
                ErrorMessage += "AccountCreationDate cannot be created in the future";
                NewLine(ErrorMessage);
            }

            //--NumberOfOrders--
            if (NumberOfOrders < 0)
            {
                ErrorMessage += "NumberOfOrders cannot be less than 0";
                NewLine(ErrorMessage);
            }

            if (NumberOfOrders > int.MaxValue)
            {
                ErrorMessage += "NumberOfOrders cannot be greater than 2,147,483,647";
                NewLine(ErrorMessage);
            }

            //--IsSignedIn-- 'Redundant since bool is never null, however included for consistency'
            if (IsSignedIn == null)
            {
                ErrorMessage += "NumberOfOrders cannot be less than 0";
                NewLine(ErrorMessage);
            }

            return ErrorMessage;
        }
    }
}
