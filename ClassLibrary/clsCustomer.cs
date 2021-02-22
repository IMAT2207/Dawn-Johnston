using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomer
    {
        public int TraderId {get; set;}
        public string TraderPassword { get; set; }
        public string BusinessName { get; set; }
        public string ContactEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public int NumberOfOrders { get; set; }
        public Boolean IsSignedIn { get; set; }

        public bool Find(int ID)
        {
            //Creation of an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //Adding prameter for search
            DB.AddParameter("@TraderID", TraderId);
            //Execute the procedure
            DB.Execute("sproc_tblCustomer_FilterByTraderId");
            //If data is found
            if (DB.Count == 1)
            {
                TraderId = Convert.ToInt32(DB.DataTable.Rows[0]["TraderId"]);
                TraderPassword = Convert.ToString(DB.DataTable.Rows[0]["TraderPassword"]);
                BusinessName = Convert.ToString(DB.DataTable.Rows[0]["BusinessName"]);
                ContactEmail = Convert.ToString(DB.DataTable.Rows[0]["ContactEmail"]);
                DeliveryAddress = Convert.ToString(DB.DataTable.Rows[0]["DeliveryAddress"]);
                AccountCreationDate = Convert.ToDateTime(DB.DataTable.Rows[0]["AccountCreationDate"]);
                NumberOfOrders = Convert.ToInt32(DB.DataTable.Rows[0]["NumberOfOrders"]);
                IsSignedIn = Convert.ToBoolean(DB.DataTable.Rows[0]["IsSignedIn"]);
                //Return that the operation was completed
                return true;
            }
            else
            {
                //If no data is found
                return false;
            }
        }   
    }
}
