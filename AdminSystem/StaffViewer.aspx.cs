using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StaffViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsStaff StaffMember = new clsStaff();

        StaffMember = (clsStaff)Session["StaffMember"];

        Response.Write("First name: " + StaffMember.FirstName + "<br/>");
        Response.Write("Family name: " + StaffMember.FamilyName + "<br/>");
        Response.Write("Password: " + StaffMember.StaffPassword + "<br/>");
        Response.Write("Record Created: " + StaffMember.RecordCreated + "<br/>");
        
    }

    protected void btnStaffList_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffList.aspx");
    }
}