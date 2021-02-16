using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StockDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //instance of the stock class
        clsStock product = new clsStock();

        product.ProductId = int.Parse(txtProductID.Text);

        product.ProductName = txtProductName.Text;

        product.ProductDescription = txtProductDescription.Text;

        product.IsAvailable = chkAvailability.Checked;

        int i = int.Parse(txtQuantity.Text);
        product.QuantityAvailable = i;

        product.RestockDate = DateTime.Now;

        Session["Product Stock"] = product;
        lblError.Text = "Success!";
        Response.Redirect("StockViewer.aspx");


    }
}