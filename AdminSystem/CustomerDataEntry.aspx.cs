using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class CustomerDataEntry : System.Web.UI.Page
{

    protected void btnOK_Click(object sender, EventArgs e)
    {

        clsCustomer Customer = new clsCustomer();

        int TraderId = int.Parse(txtID.Text);
        string TraderPassword = txtPassword.Text;
        string BusinessName = txtBusinessName.Text;
        string ContactEmail = txtContactEmail.Text;
        string DeliveryAddress = txtDeliveryAddr.Text;
        DateTime AccountCreationDate = calendarAccountCreationDate.SelectedDate;
        int NumberOfOrders = int.Parse(txtNumberOfOrders.Text);
        bool IsSignedIn = checkIsSignedIn.Checked;

        string Error = "";

        Error = Customer.Valid();

        if (Error == "")
        {
            Customer.TraderId = TraderId;
            Customer.TraderPassword = TraderPassword;
            Customer.BusinessName = BusinessName;
            Customer.ContactEmail = ContactEmail;
            Customer.DeliveryAddress = DeliveryAddress;
            Customer.AccountCreationDate = AccountCreationDate;
            Customer.NumberOfOrders = NumberOfOrders;
            Customer.IsSignedIn = IsSignedIn;
        }
        else
        {
            lblErr.Text = Error;
        }

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
            calendarAccountCreationDate.SelectedDate = Customer.AccountCreationDate;
            txtNumberOfOrders.Text = Convert.ToString(Customer.NumberOfOrders);
            checkIsSignedIn.Checked = Customer.IsSignedIn;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

}