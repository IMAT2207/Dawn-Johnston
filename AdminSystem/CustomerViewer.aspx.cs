using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class CustomerViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Create a customer object
            clsCustomer customer = new clsCustomer();
            //Find and link the customer object to the session
            customer.Find((Int32)Session["TraderID"]);

            // Displays the entries on the custom viewer web page
            lblCustomer.Text = Convert.ToInt32(customer.TraderId) + "<br/>"
                   + customer.TraderPassword + "<br/>"
                   + customer.BusinessName + "<br/>"
                   + customer.ContactEmail + "<br/>"
                   + customer.DeliveryAddress + "<br/>"
                   + Convert.ToString(customer.AccountCreationDate) + "<br/>"
                   + Convert.ToInt32(customer.NumberOfOrders) + "<br/>";
        } catch { }

    }

    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        //Redirect to the customer list page
        Response.Redirect("CustomerList.aspx");
    }
}