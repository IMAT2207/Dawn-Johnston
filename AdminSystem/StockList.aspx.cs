using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StockList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        clsStockCollection Stocks = new clsStockCollection();
        //set the data source to the list
        lstStockList.DataSource = Stocks.StockList;
        //set the name of the primary key
        lstStockList.DataValueField = "ProductID";
        //set the data field to display
        lstStockList.DataTextField = "QuantityAvailable";
        //bind the data to the list
        lstStockList.DataBind();
    }
}