using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class clsStaff
    {
        public static readonly int STAFF_ID_MAX = Int32.MaxValue;

        private int pStaffID;
        public int StaffID
        {
            get
            {
                return pStaffID;
            }
            set
            {
                pStaffID = value;
            }
        }

        private string pStaffPassword;
        public string StaffPassword
        {
            get
            {
                return pStaffPassword;
            }
            set
            {
                pStaffPassword = value;
            }
        }

        private bool pIsManager;
        public bool IsManager
        {
            get
            {
                return pIsManager;
            }
            set
            {
                pIsManager = value;
            }
        }

        private DateTime pDOB;
        public DateTime DOB
        {
            get
            {
                return pDOB;
            }
            set
            {
                pDOB = value;
            }
        }

        private string pFirstName; 
        public string FirstName
        {
            get
            {
                return pFirstName;
            }
            set
            {
                pFirstName = value;
            }
        }

        private string pFamilyName;
        public string FamilyName
        {
            get
            {
                return pFamilyName;
            }
            set
            {
                pFamilyName = value;
            }
        }

         public bool Find(int StaffID)
         {
            // Creates a new instance of the data connection.
            clsDataConnection DB = new clsDataConnection();
            // Add the parameter for the StaffID to seach for.
            DB.AddParameter("@StaffID", StaffID);
            // Executes the stored procedure.
            DB.Execute("sproc_tblStaff_FilterByStaffID");

            // Copy the data from the database to the private data members.
            if (DB.Count == 1)
            {
                pStaffID = Convert.ToInt32(DB.DataTable.Rows[0]["StaffID"]);
                pStaffPassword = Convert.ToString(DB.DataTable.Rows[0]["StaffPassword"]);
                pIsManager = Convert.ToBoolean(DB.DataTable.Rows[0]["IsManager"]);
                pDOB = Convert.ToDateTime(DB.DataTable.Rows[0]["DOB"]);
                pFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                pFamilyName = Convert.ToString(DB.DataTable.Rows[0]["FamilyName"]);

                // Returns true if values are matched, and works.
                return true;
            }
            // If no record is found.
            else
            {
                // Returns false if a problem occurs.
                return false;
            }
         }
    }
}