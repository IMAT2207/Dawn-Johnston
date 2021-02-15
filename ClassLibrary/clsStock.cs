using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
    public class clsStock
    {
        public clsStock AStock = new clsStock();
        public int ProductId;
        public string ProductName;
        public string ProductDescription;
        public Boolean IsAvailable = false;
        public int QuantityAvailable = 0;
        public DateTime RestockDate;

        public bool Find(int ProductId)
        {
            ProductId = 1;
            ProductName = "Beef";
            ProductDescription = "About Something...";
            IsAvailable = true;
            QuantityAvailable = 10;
            RestockDate = DateTime.Now;

            return true;
        }

    }
}
