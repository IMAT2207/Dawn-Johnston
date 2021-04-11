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

        string Error = "";
        int TraderId = 0;
        try
        {
            TraderId = Convert.ToInt32(txtID.Text);
        }
        catch (FormatException ex)
        {
            Error += "<br> TraderId must be a number";
        }
        string TraderPassword = txtPassword.Text;
        string BusinessName = txtBusinessName.Text;
        string ContactEmail = txtContactEmail.Text;
        string DeliveryAddress = txtDeliveryAddr.Text;
        int NumberOfOrders = 0;
        try
        {
            NumberOfOrders = Convert.ToInt32(txtNumberOfOrders.Text);
        }
        catch (FormatException ex)
        {
            Error += "<br> NumberOfOrders must be a number";
        }
        DateTime AccountCreationDate = calendarAccountCreationDate.SelectedDate;
        bool IsSignedIn = checkIsSignedIn.Checked;

        Error += clsCustomer.Valid( TraderId,
                                    TraderPassword,
                                    BusinessName,
                                    ContactEmail,
                                    DeliveryAddress,
                                    AccountCreationDate,
                                    NumberOfOrders,
                                    IsSignedIn);

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