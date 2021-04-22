using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class OrderConfirmDelete : System.Web.UI.Page
{
    private clsOrder order;
    protected void Page_Load(object sender, EventArgs e)
    {
        order = (clsOrder)Session["orderToDelete"];
        if (order == null) exit();

        Label1.Text = "Are you sure you want to delete this record ?";
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        clsOrderCollection collection = new clsOrderCollection(order);
        collection.Delete();
        exit();
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        exit();
    }

    private void exit()
    {
        Response.Redirect("OrderList.aspx");
    }
}