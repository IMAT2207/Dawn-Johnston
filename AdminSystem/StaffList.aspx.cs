using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StaffList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // If this is the first time the page is displayed.
        if (IsPostBack == false)
        {
            // Update the list box.
            DisplayStaffMembers();
        }
    }

    void DisplayStaffMembers()
    {
        // Create an instance of the staff collection.
        clsStaffCollection StaffMembers = new clsStaffCollection();

        // Sets the data source to the list of staff members in the collection.
        lstStaffList.DataSource = StaffMembers.StaffList;

        // Set the name of the primary key.
        lstStaffList.DataValueField = "StaffID";

        // Sets the data field to display.
        lstStaffList.DataTextField = "FirstName";

        // Bind the data to the list.
        lstStaffList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // Store -1 into the session object to indicate this is a new record.
        Session["StaffID"] = -1;

        // Redirect to the StaffDataEntry webpage.
        Response.Redirect("StaffDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // Variable to store the primary key value of the record to be modified.
        int StaffID;

        // If a record has been selected from the list.
        if (lstStaffList.SelectedIndex != -1)
        {
            // Obtain the primary key value of the record to modify.
            StaffID = Convert.ToInt32(lstStaffList.SelectedValue);

            // Stores the data in the session object.
            Session["StaffID"] = StaffID;

            // Redirect to the edit page.
            Response.Redirect("StaffDataEntry.aspx");
        }
        else
        {
            // Display an error message.
            lblError.Text = "Please select a record to edit from the list";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        // Variable to store the primary key value of the record to be modified.
        int StaffID;

        // If a record has been selected from the list.
        if (lstStaffList.SelectedIndex != -1)
        {
            // Obtain the primary key value of the record to modify.
            StaffID = Convert.ToInt32(lstStaffList.SelectedValue);

            // Stores the data in the session object.
            Session["StaffID"] = StaffID;

            // Redirect to the edit page.
            Response.Redirect("StaffConfirmDelete.aspx");
        }
        else
        {
            // Display an error message.
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        // Create an instance of the staff collection.
        clsStaffCollection StaffMembers = new clsStaffCollection();
        StaffMembers.ReportByFirstName(txtFilter.Text);
        lstStaffList.DataSource = StaffMembers.StaffList;

        // Set the name of the primary key.
        lstStaffList.DataValueField = "StaffID";

        // Set the name of the field to display.
        lstStaffList.DataValueField = "FirstName";

        // Bind the data to the list.
        lstStaffList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        // Create an instance of the staff collection.
        clsStaffCollection StaffMembers = new clsStaffCollection();
        StaffMembers.ReportByFirstName("");

        // Clear any existing filter to empty the interface.
        txtFilter.Text = "";
        lstStaffList.DataSource = StaffMembers.StaffList;

        // Set the name of the primary key.
        lstStaffList.DataValueField = "StaffID";

        // Set the name of the field to display.
        lstStaffList.DataValueField = "FirstName";

        // Bind the data to the list.
        lstStaffList.DataBind();
    }

    protected void txtFilter_TextChanged(object sender, EventArgs e)
    {

    }
}