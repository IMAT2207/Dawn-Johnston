using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StockList : System.Web.UI.Page
{
    Int32 ProductId;
    protected void Page_Load(object sender, EventArgs e)
    {
        ProductId = Convert.ToInt32(Session["ProductID"]);
        //if this is the first time the page is displayed
        if (IsPostBack == false)
        {
            //upate the list box
            DisplayStocks();
        }
    }
    void DisplayStocks()
    {
        //create an instance
        ClassLibrary.clsStockCollection Stocks = new ClassLibrary.clsStockCollection();
        //set the data source to the list
        lstStockList.DataSource = Stocks.StockList;
        //set the name of the primary key
        lstStockList.DataValueField = "ProductID";
        //set the data field to display
        lstStockList.DataTextField = "ProductName";
        //bind the data to the list
        lstStockList.DataBind();
    }

    protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //create an instance of the Stock Collection
        clsStockCollection Stocks = new clsStockCollection();
        //set the data source to the list
        lstStockList.DataSource = Stocks.StockList;
        //set the name of the primary key
        lstStockList.DataValueField = "ProductID";
        //set the data field to display
        lstStockList.DataTextField = "ProductName";
        //bind the data to the list
        lstStockList.DataBind();
    }

    //add button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //store -1 into the session object to indicate this is a new record
        Session["ProductID"] = -1;
        //redirect to the data entry page
        Response.Redirect("StockDataEntry.aspx");
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //store the data in the session object
        Session["ProductID"] = ProductId;
        //redirect to the edit page
        Response.Redirect("StockDataEntry.sapx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //var to store the primary key value of the record to be edited
        Int32 ProductId;
        //if a record has been selected from the list
        if (lstStockList.SelectedIndex != -1)
        {
            //get the primary key value of the record to edit
            ProductId = Convert.ToInt32(lstStockList.SelectedValue);
            //store the data in the session object
            Session["ProductID"] = ProductId;
            //redirect to the edit page
            Response.Redirect("StockDataEntry.aspx");
        }
        //if no record has been selected
        else
        {
            lblError.Text = "Please select a record to delete from the list";
        }
    }



    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //var to store the primary key value of the record to be deleted
        Int32 ProductId;
        //if a record has been selected from the list
        if(lstStockList.SelectedIndex != -1)
        {
            //get the primary key value of the record to delte
            ProductId = Convert.ToInt32(lstStockList.SelectedValue);
            //store the data in the session object
            Session["ProductID"] = ProductId;
            //redirect to the delete page
            Response.Redirect("StockDelete.aspx");
        }
        //no record has been selected
        else
        {
            //display an error
            lblError.Text = "Please select a record to delete from the list";
        }
    }
}