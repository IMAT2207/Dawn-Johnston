using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsStaffCollection
    {
        public clsStaffCollection()
        {
            // Object for data connection.
            clsDataConnection DB = new clsDataConnection();

            // Executes the stored procedure.
            DB.Execute("sproc_tblStaff_SelectAll");

            // Populate the ArrayList with the data table.
            PopulateArray(DB);
        }
        private List<clsStaff> pStaffList = new List<clsStaff>();
        public List<clsStaff> StaffList
        {
            get
            {
                return pStaffList; // Returns the private data.
            }
            set
            {
                pStaffList = value; // Sets the private data.
            }
        }
        public int Count
        {
            get
            {
                return pStaffList.Count; // Returns the count of the list.
            }
            set
            {
                // Future work.
            }
        }
        clsStaff pThisStaff = new clsStaff();
        public clsStaff ThisStaff
        {
            get
            {
                return pThisStaff;
            }
            set
            {
                pThisStaff = value;
            }
        }
        public int Add()
        {
            // Adds a new record to the database based on the values of pThisStaff.
            // Establishes a new database connection.
            clsDataConnection DB = new clsDataConnection();

            // Sets the parameters for the stores procedure.
            DB.AddParameter("@StaffPassword", pThisStaff.StaffPassword);
            DB.AddParameter("@IsManager", pThisStaff.IsManager);
            DB.AddParameter("@RecordCreated", pThisStaff.RecordCreated);
            DB.AddParameter("@FirstName", pThisStaff.FirstName);
            DB.AddParameter("@FamilyName", pThisStaff.FamilyName);

            // Executes the query, returning the primary key value.
            return DB.Execute("sproc_tblStaff_Insert");
        }

        public void Update()
        {
            // Updates an existing record in the database.
            // Establishes a new database connection.
            clsDataConnection DB = new clsDataConnection();

            // Sets the parameters for the stores procedure.
            DB.AddParameter("@StaffID", pThisStaff.StaffID);
            DB.AddParameter("@StaffPassword", pThisStaff.StaffPassword);
            DB.AddParameter("@IsManager", pThisStaff.IsManager);
            DB.AddParameter("@RecordCreated", pThisStaff.RecordCreated);
            DB.AddParameter("@FirstName", pThisStaff.FirstName);
            DB.AddParameter("@FamilyName", pThisStaff.FamilyName);

            // Executes the query, returning the primary key value.
            DB.Execute("sproc_tblStaff_Update");
        }

        public void Delete()
        {
            // Connects to the database.
            clsDataConnection DB = new clsDataConnection();

            // Set the parameters for the stored procedure.
            DB.AddParameter("@StaffID", pThisStaff.StaffID);

            // Execute the stored procedure.
            DB.Execute("sproc_tblStaff_Delete");
        }

        public void ReportByFirstName(string FirstName)
        {
            // Filters the records based on a full or partial first name.
            
            // Connects to the database.
            clsDataConnection DB = new clsDataConnection();

            // Send the FirstName parameter to the database.
            DB.AddParameter("@FirstName", FirstName);

            // Execute the stored procedure.
            DB.Execute("sproc_tblStaff_FilterByFirstName");

            // Populate the ArrayList with the data table.
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            // Populates the array list based on the data table in the parameter DB.

            // Variable for the index.
            int Index = 0;

            // Variable to store the record count.
            int RecordCount;

            // Obtains the count of records.
            RecordCount = DB.Count;

            // Clear the private ArrayList.
            pStaffList = new List<clsStaff>();

            // While there are records to process.
            while (Index < RecordCount)
            {
                // Create a blank staff record.
                clsStaff StaffMember = new clsStaff();

                // Read in the fields from the current record.
                StaffMember.StaffID = Convert.ToInt32(DB.DataTable.Rows[Index]["StaffID"]);
                StaffMember.StaffPassword = Convert.ToString(DB.DataTable.Rows[Index]["StaffPassword"]);
                StaffMember.IsManager = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsManager"]);
                StaffMember.RecordCreated = Convert.ToDateTime(DB.DataTable.Rows[Index]["RecordCreated"]);
                StaffMember.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                StaffMember.FamilyName = Convert.ToString(DB.DataTable.Rows[Index]["FamilyName"]);

                // Add the record to the private data member.
                pStaffList.Add(StaffMember);

                // Increment the index.
                Index++;
            }
        }
    }
}