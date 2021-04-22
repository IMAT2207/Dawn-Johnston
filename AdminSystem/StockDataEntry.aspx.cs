using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class StockDataEntry : System.Web.UI.Page
{
    //variable to store the primary key with page level scope
    int ProductId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the number of the product to be processed
        ProductId = Convert.ToInt32(Session["ProductID"]);
        if (IsPostBack == false)
        {
            //if this is not a new record
            if (ProductId != -1)
            {
                //display the current data for the record
                DisplayStocks();
            }
        }
    }

    void DisplayStocks()
    {
        //create an instance of the stock book
        clsStockCollection StockBook = new clsStockCollection();
        //find the record to update
        StockBook.ThisStock.Find(ProductId);
        //display the data for the current record
        txtProductID.Text = StockBook.ThisStock.ProductId.ToString();
        txtProductName.Text = StockBook.ThisStock.ProductName;
        txtProductDescription.Text = StockBook.ThisStock.ProductDescription;
        chkAvailability.Checked = StockBook.ThisStock.IsAvailable;
        txtQuantity.Text = StockBook.ThisStock.QuantityAvailable.ToString();
        txtRestockDate.Text = StockBook.ThisStock.RestockDate.ToString();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        //create a new instance of clsStock
        clsStock product = new clsStock();
        //capture the Product ID
        //string ProductId = txtProductID.Text;
        //capture the Product Name
        string ProductName = txtProductName.Text;
        //capture the Product Description
        string ProductDescription = txtProductDescription.Text;
        string IsAvailability = chkAvailability.Text;
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
            //    product.ProductId = int.Parse(txtProductID.Text);
            //capture the product name
            //    product.ProductName = txtProductName.Text;
            //capture the product description
            //    product.ProductDescription = txtProductDescription.Text;
            //capture the availability
            //    product.IsAvailable = chkAvailability.Checked;
            //capture quantity
            //    int i = int.Parse(txtQuantity.Text);
            //    product.QuantityAvailable = i;

            product.ProductId = ProductId;
            product.ProductName = ProductName;
            product.ProductDescription = ProductDescription;
            product.IsAvailable = chkAvailability.Checked;
            product.QuantityAvailable = Convert.ToInt32(QuantityAvailable);
            product.RestockDate = Convert.ToDateTime(RestockDate);
            //capture restock date
            product.RestockDate = Convert.ToDateTime(RestockDate);
            //create a new instance of the stock collection
            clsStockCollection StockList = new clsStockCollection();

            //if this is a new record
            if (product.ProductId == -1)
            {
                //set the ThisStock property
                StockList.ThisStock = product;
                //add the new record
                StockList.Add();
            }
            //else it must be an update
            else
            {
                //find the record to update
                StockList.ThisStock.Find(product.ProductId);
                //set the ThisStock property
                StockList.ThisStock = product;
                //update the record
                StockList.Update();
            }

            Session["Product"] = product;
            //redirect back to the listpage
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

        int ProductId;

        Boolean Found = false;

        ProductId = Convert.ToInt32(txtProductID.Text);

        Found = product.Find(ProductId);

        if (Found == true)
        {
            txtProductName.Text = product.ProductName;

            txtProductDescription.Text = product.ProductDescription;

            chkAvailability.Checked = product.IsAvailable;

            txtQuantity.Text = product.QuantityAvailable.ToString();

            txtRestockDate.Text = product.RestockDate.ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StockList.aspx");
    }
}