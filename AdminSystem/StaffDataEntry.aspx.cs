using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StaffDataEntry : System.Web.UI.Page
{
    // variable to store the primary key with page level scope.
    int StaffID;
    protected void Page_Load(object sender, EventArgs e)
    {
        // get the StaffID value to be processed.
        StaffID = Convert.ToInt32(Session["StaffID"]);
        if (IsPostBack == false)
        {
            // If this is not a new record.
            if (StaffID != 1)
            {
                // Display the current data for the record.
                DisplayStaffMember();
            }
        }
    }

    void DisplayStaffMember()
    {
        // Create an instance of the staff list.
        clsStaffCollection StaffMembers = new clsStaffCollection();

        // Finds the record to update.
        StaffMembers.ThisStaff.Find(StaffID);

        // Display the data for the record.
        txtStaffID.Text = StaffMembers.ThisStaff.StaffID.ToString();
        txtStaffPassword.Text = StaffMembers.ThisStaff.StaffPassword;
        chkIsManager.Checked = StaffMembers.ThisStaff.IsManager;
        txtRecordCreated.Text = StaffMembers.ThisStaff.RecordCreated.ToString();
        txtFirstName.Text = StaffMembers.ThisStaff.FirstName;
        txtFamilyName.Text = StaffMembers.ThisStaff.FamilyName;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Creates a new instance of the staff class.
        clsStaff StaffMember = new clsStaff();

        // Capture the data.
        string StaffPassword = txtStaffPassword.Text;
        string RecordCreated = txtRecordCreated.Text;
        string FirstName = txtFirstName.Text;
        string FamilyName = txtFamilyName.Text;

        // Variable to store any error messages.
        string Error = "";

        Error = StaffMember.Valid(StaffPassword, RecordCreated, FirstName, FamilyName);
        if (Error == "")
        {
            // Captures the data.
            StaffMember.StaffID = StaffID;
            StaffMember.StaffPassword = StaffPassword;
            StaffMember.IsManager = chkIsManager.Checked;
            StaffMember.RecordCreated = Convert.ToDateTime(RecordCreated);
            StaffMember.FirstName = FirstName;
            StaffMember.FamilyName = FamilyName;

            // Create a new instance of the staff collection.
            clsStaffCollection StaffMembers = new clsStaffCollection();

            // If this is a new record, then add data.
            if (StaffID == -1)
            {
                // Set the ThisStaff property.
                StaffMembers.ThisStaff = StaffMember;

                // Add the record.
                StaffMembers.Add();

            }
            else // Otherwise its a modification.
            {
                // Find the record to update.
                StaffMembers.ThisStaff.Find(StaffID);

                // Set the ThisStaff property.
                StaffMembers.ThisStaff = StaffMember;

                StaffMembers.Update();
            }

            Session["StaffMember"] = StaffMember;
            Response.Redirect("StaffViewer.aspx");
        }
        else
        {
            lblError.Text = Error;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffList.aspx");
    }


    protected void btnFind_Click(object sender, EventArgs e)
    {
        // Creates a new instance of the staff class.
        clsStaff StaffMember = new clsStaff();

        // Variable to sote the primnary key.
        Int32 StaffID;

        // Variable to store the result of the find operation.
        Boolean Found = false;

        // Gets the primary key value entered by the user.
        StaffID = Convert.ToInt32(txtStaffID.Text);

        // Finds the record using the StaffID (PK).
        Found = StaffMember.Find(StaffID);

        // If the records is found.
        if (Found == true)
        {
            txtStaffID.Text = StaffMember.StaffID.ToString();
            txtStaffPassword.Text = StaffMember.StaffPassword;
            txtRecordCreated.Text = StaffMember.RecordCreated.ToString();
            txtFirstName.Text = StaffMember.FirstName;
            txtFamilyName.Text = StaffMember.FamilyName;
        }
    }
}


