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

        Response.Write(StaffMember.StaffPassword);
        Response.Write(StaffMember.RecordCreated);
        Response.Write(StaffMember.FirstName);
        Response.Write(StaffMember.FamilyName);
    }

    protected void btnStaffList_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffList.aspx");
    }
}