using System;

namespace ClassLibrary
{
    public class clsStock
    {
        private int aProductId;
        public int ProductId
        {
            get
            {
                return aProductId;
            }
            set
            {
                aProductId = value;
            }
        }

        private string aProductName;
        public string ProductName
        {
            get
            {
                return aProductName;
            }
            set
            {
                aProductName = value;
            }
        }

        private string aProductDescription;
        public string ProductDescription
        {
            get
            {
                return aProductDescription;
            }
            set
            {
                aProductDescription = value;
            }
        }

        private Boolean aIsAvailable;
        public Boolean IsAvailable
        {
            get
            {
                return aIsAvailable;
            }
            set
            {
                aIsAvailable = value;
            }
        }
        private int aQuantityAvailable;
        public int QuantityAvailable
        {
            get
            {
                return aQuantityAvailable;
            }
            set
            {
                aQuantityAvailable = value;
            }
        }

        private DateTime aRestockDate;
        public DateTime RestockDate
        {
            get
            {
                return aRestockDate;
            }
            set
            {
                aRestockDate = value;
            }
        }

        public bool Find(int ProductId)
        {
            clsDataConnection DB = clsDataConnection.GetDataConnection();

            DB.AddParameter("@ProductID", ProductId);

            DB.Execute("sproc_tblStock_FilterByProductId");

            if (DB.Count == 1)
            {
                aProductId = Convert.ToInt32(DB.DataTable.Rows[0]["ProductID"]);
                aProductName = Convert.ToString(DB.DataTable.Rows[0]["ProductName"]);
                aProductDescription = Convert.ToString(DB.DataTable.Rows[0]["ProductDescription"]);
                aIsAvailable = Convert.ToBoolean(DB.DataTable.Rows[0]["IsAvailable"]);
                aQuantityAvailable = Convert.ToInt32(DB.DataTable.Rows[0]["QuantityAvailable"]);
                aRestockDate = Convert.ToDateTime(DB.DataTable.Rows[0]["RestockDate"]);

                return true;
            }
            else
            {
                return false;
            }
        }

        public string Valid(string productName,
                            string quantityAvailable,
                            string restockDate)
        {
            String Error = "";
            int x = Int32.Parse(quantityAvailable);
            int y = Math.Abs(x);
            DateTime DateTemp;
            //if the Product Name is blank
            if (productName.Length == 0)
            {
                Error = Error + "The Product Name may not be blank : ";
            }
            //if the Product Name is greater than 33 characters
            if (productName.Length > 32)
            {
                Error = Error + "The Product Name must be less than 32 characters";
            }
            //if the QuantityAvailable is blank
            if (quantityAvailable.Length == 0)
            {
                Error = Error + "The Quantity Availability may not be blank : ";
            }
            //if the QuantityAvailable is a negative number
            if (x < 0)
            {
                Error = Error + "The Quantity Availability may not be negative : ";
            }
            //if the QuantityAvailable is more than 2147483647
            if (y > 2147483647)
            {
                Error = Error + "The Quantity Availability may not be greater than 2147483647 : ";
            }
            try
            {
                //Set restockDate value to the DateTemp variable
                DateTemp = Convert.ToDateTime(restockDate);
                //if set DateTime value is less than now DateTime
                if (DateTemp < DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the past : ";
                }
                //if set DateTime value is greater than now DateTime
                if (DateTemp > DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the future : ";
                }
            }
            catch
            {
                Error = Error + "The date was not a valid date : ";
            }
            return Error;
        }

    }
}
