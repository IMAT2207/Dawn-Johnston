using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StockViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        clsStock product = (clsStock)Session["Product"]; ;

        //Display all entities from Stock Data Entry.aspx.cs
        Response.Write(product.ProductId);

        Response.Write(product.ProductName);

        Response.Write(product.ProductDescription);

        Response.Write(product.IsAvailable);

        Response.Write(product.QuantityAvailable);

        Response.Write(product.RestockDate);
    }
}