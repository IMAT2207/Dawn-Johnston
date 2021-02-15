using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCustomer
    {
        public int TraderId;
        public string TraderPassword;
        public string BusinesName;
        public string ContactEmail;
        public string DeliveryAddress;
        public DateTime AccountCreation;
        public int NumberOfOrders;
        public Boolean IsSignedIn;

        public bool Find(int ID)
        {
            TraderId = 1;
            TraderPassword = "1234";
            BusinesName = "Unknown";
            ContactEmail = "Email@unknown.com";
            DeliveryAddress = "1UnknonwnStreet";
            AccountCreation = DateTime.Now;
            NumberOfOrders = 1;
            IsSignedIn = true;
            
            return true;
        }   
    }
}
