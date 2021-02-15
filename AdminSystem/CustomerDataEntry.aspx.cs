using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class CustomerDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {

        clsCustomer Customer = new clsCustomer();

        int ID = int.Parse(txtID.Text);
        Customer.TraderId = ID;

        Customer.TraderPassword = txtPassword.Text;
        Customer.BusinessName = txtBusinessName.Text;
        Customer.ContactEmail = txtContactEmail.Text;
        Customer.DeliveryAddress = txtDeliveryAddr.Text;

        Session["Customer"] = Customer;
        Response.Redirect("CustomerViewer.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}