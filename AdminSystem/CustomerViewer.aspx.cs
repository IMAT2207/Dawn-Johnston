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
        clsCustomer Customer = new clsCustomer();
        Customer = (clsCustomer)Session["Customer"];

        // Displays the entries on the custom viewer web page
        Response.Write(Customer.TraderId);
        Response.Write(Customer.TraderPassword);
        Response.Write(Customer.BusinessName);
        Response.Write(Customer.ContactEmail);
        Response.Write(Customer.DeliveryAddress);
    }
}