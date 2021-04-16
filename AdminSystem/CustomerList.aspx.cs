using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerList : System.Web.UI.Page
{

    //Variable to store the Primary Key with page level scope
    Int32 TraderId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
                //Display the current data found in the record
                DisplayCustomers();
        }
    }

    void DisplayCustomers()
    {
        //Create an instance of the customer collection
        clsCustomerCollection collection = new clsCustomerCollection();
        //Set the data source to the list of Business Names in the collection
        lstCustomers.DataSource = collection.CustomerList;
        //Set the name to the primary key
        lstCustomers.DataValueField = "TraderID";
        //Set the data field to display
        lstCustomers.DataTextField = "BusinessName";
        //Bind the data to the list
        lstCustomers.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Store -1 into the session object to indicate this is a new record
        Session["TraderID"] = -1;
        //Redirect to the data entry page
        Response.Redirect("CustomerDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //Variable to store the Primary Key value of the record to be edited
        Int32 TraderId;
        //if a record has been selcted from the list
        if (lstCustomers.SelectedIndex != -1)
        {
            //Get the primary value of the record to edit
            TraderId = Convert.ToInt32(lstCustomers.SelectedValue);
            //Store the data in a session object
            Session["TraderID"] = TraderId;
            //Redirect to the edit page
            Response.Redirect("CustomerdataEntry.aspx");
        }
        else //If no record had been select ed 
        {
            //Display an error
            lblError.Text = "Please select a record to edit from the list";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //Variable to store the Primary Key value of the record to be deleted
        Int32 TraderId;
        //if a record has been selcted from the list
        if (lstCustomers.SelectedIndex != -1)
        {
            //Get the primary value of the record to edit
            TraderId = Convert.ToInt32(lstCustomers.SelectedValue);
            //Store the data in a session object
            Session["TraderID"] = TraderId;
            //Redirect to the edit page
            Response.Redirect("CustomerConfirmDelete.aspx");
        }
        else //If no record had been select ed 
        {
            //Display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        //Create an instance of the customer collection
        clsCustomerCollection collection = new clsCustomerCollection();
        collection.ReportByBusinessName(txtBusinessNameSearch.Text);
        lstCustomers.DataSource = collection.CustomerList;
        //Set the name of the primary key
        lstCustomers.DataValueField = "TraderID";
        //Set the name of the field to display
        lstCustomers.DataTextField = "BusinessName";
        //Bind the data to the list
        lstCustomers.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Create an instance of the customer collection
        clsCustomerCollection collection = new clsCustomerCollection();
        collection.ReportByBusinessName("");
        //Clear any existing filters to tidy up the interface
        txtBusinessNameSearch.Text = "";
        lstCustomers.DataSource = collection.CustomerList;
        //Set the name of the primary key
        lstCustomers.DataValueField = "TraderID";
        //Set the name of the field to display
        lstCustomers.DataTextField = "BusinessName";
        //Bind the data to the list
        lstCustomers.DataBind();
    }
}