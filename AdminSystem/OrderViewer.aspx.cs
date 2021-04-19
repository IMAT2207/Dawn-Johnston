using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class OrderViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsOrder clsOrder = (clsOrder) Session["order"];
        if (clsOrder == null) Button1_Click(null, null);
        Response.Write(clsOrder.OrderID + "<br/>");
        Response.Write(clsOrder.ProcessedBy + "<br/>");
        Response.Write(clsOrder.OrderedBy + "<br/>");
        Response.Write(clsOrder.State + "<br/>");
        Response.Write(clsOrder.PlacedOn + "<br/>");
        Response.Write(clsOrder.DeliveryNote + "<br/>");
        Response.Write(clsOrder.PaidFor + "<br/>");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderList.aspx");
    }
}