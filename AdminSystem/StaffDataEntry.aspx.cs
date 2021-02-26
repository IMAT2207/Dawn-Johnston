using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StaffDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        // Creates a new instance of the staff class.
        clsStaff StaffMember = new clsStaff();

        // Captures the StaffID.
        int x = int.Parse(txtStaffID.Text);
        StaffMember.StaffID = x;

        // Captures the staff memebers password.
        StaffMember.StaffPassword = txtStaffPassword.Text;

        // Captures the staff memebers first name.
        StaffMember.FirstName = txtFirstName.Text;

        // Captures the staff members DOB.
        DateTime enteredDate = DateTime.Parse(txtDOB.Text).Date;

        DateTime dateOnly = enteredDate.Date;

        StaffMember.DOB = DateTime.Parse(dateOnly.ToString("dd/MM/yyyy"));

        // Captures the staff memebers family name.
        StaffMember.FamilyName = txtFamilyName.Text;

        bool box = chkIsManager.Checked == true;
        StaffMember.IsManager = box;

        // Stores the first name in the session object.
        Session["StaffMember"] = StaffMember;

        // Navigates to the staff viewer page.
        Response.Redirect("StaffViewer.aspx");
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
            txtDOB.Text = StaffMember.DOB.ToString();
            txtFirstName.Text = StaffMember.FirstName;
            txtFamilyName.Text = StaffMember.FamilyName;
        }
    }
}