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
        // Creates a new instance of the staff class.
        clsStaff StaffMember = new clsStaff();
        // Obtains the data from the session object.
        StaffMember = (clsStaff) Session["StaffMember"];

        // Displays the StaffID for this entry.
        Response.Write(StaffMember.StaffID);
        // Displays the staff password for this entry.
        Response.Write(StaffMember.StaffPassword);
        // Displays the staff DOB for this entry.
        Response.Write(StaffMember.DOB);
        // Displays the first name for this entry.
        Response.Write(StaffMember.FirstName);
        // Displays the family name for this entry.
        Response.Write(StaffMember.FamilyName);
        // Displays the staff is manager status for this entry.
        Response.Write(StaffMember.IsManager);
        
    }
}