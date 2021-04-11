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

        int TraderId = 0;
        string TraderPassword = txtPassword.Text;
        string BusinessName = txtBusinessName.Text;
        string ContactEmail = txtContactEmail.Text;
        string DeliveryAddress = txtDeliveryAddr.Text;
        int NumberOfOrders = 0;
        DateTime AccountCreationDate = calendarAccountCreationDate.SelectedDate;
        bool IsSignedIn = checkIsSignedIn.Checked;

        string Error = "";

        try {
            TraderId = int.Parse(txtID.Text);
        } catch (FormatException Ignored)
        {
            Error += "\n Enter a valid number for Trader Id";
            
        }

        try
        {
            NumberOfOrders = int.Parse(txtNumberOfOrders.Text);
        }
        catch (FormatException Ignored)
        {
            Error += "\n Enter a valid number for Number O";
        }

        Error += Customer.Valid();

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
        if (Error.Equals(""))
        {
            Response.Redirect("CustomerViewer.aspx");
        }
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