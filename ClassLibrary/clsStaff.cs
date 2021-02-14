using System;

namespace ClassLibrary
{
    public class clsStaff
    {
        public bool IsManager { get; set; }
        public DateTime DOB { get; set; }
        public int StaffID { get; set; }
        public string StaffPassword { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
    }
}