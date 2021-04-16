using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class CustomerDataEntry : System.Web.UI.Page
{
    int TraderId;

    protected void btnOK_Click(object sender, EventArgs e)
    {

        clsCustomer Customer = new clsCustomer();

        string Error = "";
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
            //Capture the data
            Customer.TraderId = TraderId;
            Customer.TraderPassword = TraderPassword;
            Customer.BusinessName = BusinessName;
            Customer.ContactEmail = ContactEmail;
            Customer.DeliveryAddress = DeliveryAddress;
            Customer.AccountCreationDate = AccountCreationDate;
            Customer.NumberOfOrders = NumberOfOrders;
            Customer.IsSignedIn = IsSignedIn;

            //Create a new instance of the customer collection
            clsCustomerCollection collection = new clsCustomerCollection();

            //If this is a new record then add the data
            if (TraderId == -1)
            {
                //Set this customer to property
                collection.ThisCustomer = Customer;
                //Add the new record
                collection.Add();
            }
            else //Update
            {
                //Find the record to update
                collection.ThisCustomer.Find(TraderId);
                //Set this customer to property
                collection.ThisCustomer = Customer;
                //Update the record
                collection.Update();
            }
            //Redirect back to the list page
            Response.Redirect("CustomerList.aspx");

        }
        else
        {
            lblErr.Text = Error;
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
            DisplayCustomer(Customer);
        }
    }

    private void DisplayCustomer(clsCustomer Customer)
    {
        txtID.Text = Convert.ToString(Customer.TraderId);
        txtBusinessName.Text = Customer.BusinessName;
        txtPassword.Text = Customer.TraderPassword;
        txtContactEmail.Text = Customer.ContactEmail;
        txtDeliveryAddr.Text = Customer.DeliveryAddress;
        calendarAccountCreationDate.SelectedDate = Customer.AccountCreationDate;
        txtNumberOfOrders.Text = Convert.ToString(Customer.NumberOfOrders);
        checkIsSignedIn.Checked = Customer.IsSignedIn;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //Redirect back to the customer list
        Response.Redirect("CustomerList.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            TraderId = (Session["TraderID"] == null) ? -1 : (Int32)Session["TraderID"];
            //if the session is not null or -1
            if (TraderId != -1)
            {

                //Create a customer object
                clsCustomer customer = new clsCustomer();
                //Find and link the customer object to the session
                customer.Find((Int32)Session["TraderID"]);
                //Display the customer
                DisplayCustomer(customer);
            }
        }
    }
}