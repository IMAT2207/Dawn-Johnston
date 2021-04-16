using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class CustomerConfirmDelete : System.Web.UI.Page
{
    //Var to store the primary key of the record being deleted
    Int32 TraderId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the TraderID to be deleted from the session object
        TraderId = Convert.ToInt32(Session["TraderID"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //Create a new instance of the collection
        clsCustomerCollection collection = new clsCustomerCollection();
        //find the record to delete
        collection.ThisCustomer.Find(TraderId);
        //Delete the record
        collection.Delete();
        //Redirect back to the main page
        Response.Redirect("CustomerList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        //Redirect back to the customer list
        Response.Redirect("CustomerList.aspx");
    }
}