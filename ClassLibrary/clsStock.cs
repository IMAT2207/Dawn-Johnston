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

            DB.SQLParams.Clear();

            DB.AddParameter("@ProductID", ProductId);

            DB.Execute("sproc_tblStock_FilterByProductId");

            if (DB.Count == 1)
            {
                aProductId = Convert.ToInt32(DB.DataTable.Rows[0]["ProductId"]);
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

    }
}
