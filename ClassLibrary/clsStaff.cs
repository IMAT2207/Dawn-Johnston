using System;

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

        private Boolean pIsManager;
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

         public bool Find(int ID)
         {
             StaffID = 11;
             StaffPassword = "password";
             IsManager = true;
             DOB = DateTime.Now;
             FirstName = "first name";
             FamilyName = "family name";

             return true;
         }
    }
}