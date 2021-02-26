using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomer
    {
        public static readonly int CUST_ID_MAX = Int32.MaxValue;

        public int TraderId = -1;
        public string TraderPassword = "1234";
        public string BusinessName = "Unassigned Business Name";
        public string ContactEmail = "Unassigned Contact Email";
        public string DeliveryAddress = "Unassigned Delivery Address";
        public DateTime AccountCreationDate = DateTime.Now;
        public int NumberOfOrders = 0;
        public Boolean IsSignedIn = false;

        public bool Find(int ID)
        {
            TraderId = 1;
            TraderPassword = "1234";
            BusinessName = "Unknown";
            ContactEmail = "Email@unknown.com";
            DeliveryAddress = "1UnknonwnStreet";
            AccountCreationDate = DateTime.Now;
            NumberOfOrders = 1;
            IsSignedIn = true;
            
            return true;
        }   
    }
}
