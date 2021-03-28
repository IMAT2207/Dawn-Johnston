using System;
using ClassLibrary;

public partial class OrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) DisplayOrders();
    }

    private void DisplayOrders()
    {
        lstOrders.DataSource = new clsOrderCollection().OrderList;
        lstOrders.DataTextField = "DeliveryNote";
        lstOrders.DataValueField = "OrderID"; 
        lstOrders.DataBind();                                   
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (lstOrders.SelectedIndex == -1)
        {
            lblError.Text = "No item selected";
            return;
        }

        // Get the selected index and hope it's a valid item id
        Session["OrderID"] = Int32.Parse(lstOrders.SelectedValue);
        Response.Redirect("OrderDataEntry.aspx");
    }
}