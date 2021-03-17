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
        // Creates an instance of the staff collection.
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
}