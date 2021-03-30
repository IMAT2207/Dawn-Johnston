using ClassLibrary;
using System;
using System.Collections.Generic;

public partial class OrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsDataConnection DB = new clsDataConnection();
        DB.Execute("sproc_tblOrderSelectAll");
        PopulateArray(DB);
    }

    private void DisplayOrders(List<clsOrder> l)
    {
        lstOrders.DataSource = l;
        lstOrders.DataValueField = "OrderID";
        lstOrders.DataTextField = "OrderedBy";
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

    protected void search_click(object sender, EventArgs e)
    {
        clsOrderCollection collection = new clsOrderCollection();
        collection.FilterByCustomerID(txtFilter.Text);
        DisplayOrders(collection.OrderList);
    }

    protected void search_clear(object sender, EventArgs e)
    {
        clsOrderCollection collection = new clsOrderCollection();
        collection.FilterByCustomerID("");
        DisplayOrders(collection.OrderList);
    }

    private void PopulateArray(clsDataConnection DB)
    {
        List<clsOrder> orders = new List<clsOrder>();
        for (int i = 0; i < DB.Count; i++)
        {
            clsOrder order = new clsOrder();
            order.Find(Convert.ToInt32(DB.DataTable.Rows[i]["OrderID"]));
            orders.Add(order);
        }

        DisplayOrders(orders);
    }
}