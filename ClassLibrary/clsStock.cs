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
            clsDataConnection DB = clsDataConnection.dataConnection;

            DB.AddParameter("@ProductId", ProductId);

            DB.Execute("sproc_tblAddress_FilterByProductId");

            if (DB.Count == 1)
            {
                aProductId = Convert.ToInt32(DB.DataTable.Rows[0]["ProductId"]);
                aProductName = Convert.ToString(DB.DataTable.Rows[0]["Product Name"]);
                aProductDescription = Convert.ToString(DB.DataTable.Rows[0]["Product Description"]);
                aIsAvailable = Convert.ToBoolean(DB.DataTable.Rows[0]["Active"]);
                aQuantityAvailable = Convert.ToInt32(DB.DataTable.Rows[0]["10"]);
                aRestockDate = Convert.ToDateTime(DB.DataTable.Rows[0]["DateAdded"]);

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
