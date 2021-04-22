using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class CustomerDataEntry : System.Web.UI.Page
{
    //Declare an int for a traderID
    int TraderId;

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //Create a new instance of clsCustomer
        clsCustomer Customer = new clsCustomer();

        string Error = "";
        //Set variables from the text box data
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

        //Check for validity, any errors fill the error string
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
            Response.Redirect("CustomerViewer.aspx");

        }
        else
        {
            //Display the error
            lblErr.Text = Error;
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        //Create a new instance of customer
        clsCustomer Customer = new clsCustomer();
        //Create and set the Trader Id variable
        int TraderId = Convert.ToInt32(txtID.Text); ;
        //Create and set theBoolean variable
        Boolean Found = Customer.Find(TraderId);

        //If data is foind display the customer
        if (Found)
        {
            DisplayCustomer(Customer);
        }
    }

    private void DisplayCustomer(clsCustomer Customer)
    {
        //Set all text boxes to their respective data
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
        //Mutate traderID to -1 if null or set to The session ID if not
        TraderId = (Session["TraderID"] == null) ? -1 : (Int32)Session["TraderID"];
        if (!IsPostBack)
        {
            //if the session is not -1
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