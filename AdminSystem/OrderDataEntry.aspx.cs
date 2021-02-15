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

        order.OrderState = cmbState.SelectedValue;

        order.ProcessedBy = int.Parse(txtProcessedBy.Text);

        // STOPSHIP
        order.OrderedBy = 1; // TODO change to currently logged in customer PK.

        order.PlacedOn = DateTime.Now;

        order.DeliveryNote = txtDeliveryNote.Text;

        order.PaidFor = true;

        lblError.Text = "Success!";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}