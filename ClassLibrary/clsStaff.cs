using System;

namespace ClassLibrary
{
    public class clsStaff
    {
        public int StaffID { get; set; }
        public string StaffPassword { get; set; }
        public bool IsManager { get; set; }
        public DateTime DOB { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public bool Find(int ID)
        {
            StaffID = 1;
            StaffPassword = "passwrod";
            IsManager = true;
            DOB = DateTime.Now;
            FirstName = "first name";
            FamilyName = "family name";

            return true;
        }
    }
}