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
        clsOrder clsOrder = new clsOrder();
        Response.Write(clsOrder.OrderID);
        Response.Write(clsOrder.OrderState);
        Response.Write(clsOrder.ProcessedBy);
        Response.Write(clsOrder.OrderedBy);
        Response.Write(clsOrder.PlacedOn);
        Response.Write(clsOrder.DeliveryNote);
        Response.Write(clsOrder.PaidFor);
    }
}