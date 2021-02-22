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

    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsCustomer Customer = new clsCustomer();
        int TraderId;
        Boolean Found = false;
        TraderId = Convert.ToInt32(txtID.Text);
        Found = Customer.Find(TraderId);

        if (Found)
        {
            txtBusinessName.Text = Customer.BusinessName;
            txtPassword.Text = Customer.TraderPassword;
            txtContactEmail.Text = Customer.ContactEmail;
            txtDeliveryAddr.Text = Customer.DeliveryAddress;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

}