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
        ListBox1.DataSource = new clsOrderCollection().OrderList;
        ListBox1.DataValueField = "OrderID";
        ListBox1.DataTextField = "OrderedBy";
        ListBox1.DataBind();
    }
}