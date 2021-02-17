using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class OrderDataEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsOrder order = new clsOrder();

        order.OrderID = int.Parse(txtID.Text);

        //order.State = cmbState.SelectedValue;

        order.ProcessedBy = int.Parse(txtProc.Text);

        // STOPSHIP
        order.OrderedBy = 1; // TODO change to currently logged in customer PK.

        order.PlacedOn = DateTime.Now;

        order.DeliveryNote = txtDelivery.Text;

        order.PaidFor = true;

        Session["Order"] = order;
        lblMsg.Text = "Success!";
        Response.Redirect("OrderViewer.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {

    }
}