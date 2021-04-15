using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StaffViewer : System.Web.UI.Page
{
    // Variable to store the primary key value of the record to be deleted.
    int StaffID;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Obtains the StaffID number of the record to be deleted.
        StaffID = Convert.ToInt32(Session["StaffID"]);
    }


    protected void btnYes_Click(object sender, EventArgs e)
    {
        // Create a new instance of the staff list.
        clsStaffCollection StaffList = new clsStaffCollection();

        // Find the record to delete.
        StaffList.ThisStaff.Find(StaffID);

        // Delete the record.
        StaffList.Delete();

        // Redirect back to the main page.
        Response.Redirect("StaffList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffList.aspx");
    }
}