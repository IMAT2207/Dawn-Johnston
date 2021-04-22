using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StockConfirmDelete : System.Web.UI.Page
{
    int ProductId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the product to be deleted from the session object
        ProductId = Convert.ToInt32(Session["ProductID"]);
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        //create a new instance
        clsStockCollection Stocks = new clsStockCollection();
        //find the record to delete
        Stocks.ThisStock.Find(ProductId);
        //delete the record
        Stocks.Delete();
        //redirect back to the main page
        Response.Redirect("StockList.aspx");
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("StockList.aspx");
    }
}