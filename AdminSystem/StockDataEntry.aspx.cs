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
        //create a new instance of clsStock
        clsStock product = new clsStock();
        //capture the Product ID
        string ProductId = txtProductID.Text;
        //capture the Product Name
        string ProductName = txtProductName.Text;
        //capture the Product Description
        string ProductDescription = txtProductDescription.Text;
        //capture Quantity Available
        string QuantityAvailable = txtQuantity.Text;
        //capture Restock Date
        string RestockDate = txtRestockDate.Text;
        //variable to store any error messages
        string Error = "";
        //validation the data
        Error = product.Valid(ProductName, QuantityAvailable, RestockDate);
        if (Error == "")
        {
            //capture the product id
            product.ProductId = int.Parse(txtProductID.Text);
            //capture the product name
            product.ProductName = txtProductName.Text;
            //capture the product description
            product.ProductDescription = txtProductDescription.Text;
            //capture the availability
            product.IsAvailable = chkAvailability.Checked;
            //capture quantity
            int i = int.Parse(txtQuantity.Text);
            product.QuantityAvailable = i;
            //capture restock date
            product.RestockDate = Convert.ToDateTime(RestockDate);
            //store the stock in the session object
            Session["Product Stock"] = product;
            //create a new instance of the stock collection
            clsStockCollection StockList = new clsStockCollection();
            //set the ThisStock
            StockList.ThisStock = product;
            //add the new record
            StockList.Add();
            //redirect to the viewer page
            Response.Redirect("StockViewer.aspx");
        }
        else
        {
            //display the error message
            lblError.Text = Error;
        }


    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsStock product = new clsStock();

        Int32 ProductId;

        Boolean Found = false;

        ProductId = Convert.ToInt32(txtProductID.Text);

        Found = product.Find(ProductId);

        if(Found == true)
        {
            txtProductID.Text = product.ProductName;

            txtProductID.Text = product.ProductDescription;

            txtProductID.Text = product.IsAvailable.ToString();

            txtProductID.Text = product.QuantityAvailable.ToString();

            txtProductID.Text = product.RestockDate.ToString();
        }
    }
}