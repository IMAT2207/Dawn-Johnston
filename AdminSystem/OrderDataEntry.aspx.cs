using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class OrderDataEntry : System.Web.UI.Page
{

    public static readonly string INVALID_ID = "The provided ID was not a valid!";
    public static readonly string READ_COMPLETE = "Displaying record read from database!";
    public static readonly int NO_RECORD = -1;

    protected void btnOK_Click(object sender, EventArgs e)
    {
        clsOrder order = new clsOrder();

        order.OrderID = int.Parse(txtID.Text);

        //order.State = cmbState.SelectedValue;

        order.ProcessedBy = int.Parse(txtProc.Text);

        #warning STOPSHIP change to currently logged in pk
        order.OrderedBy = 1; // TODO change to currently logged in customer PK.

        order.PlacedOn = PlacedOn.SelectedDate;

        order.DeliveryNote = txtDelivery.Text;

        order.PaidFor = chkPaidFor.Checked;

        #warning This should modify the database to write a record.
        Session["Order"] = order;
        lblMsg.Text = "Success!";
        Response.Redirect("OrderViewer.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e) { Response.Redirect("OrderDataEntry.aspx"); }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        showRecord(clsOrder.CreateAndFind(ReadID()));
    }

    /// <summary>
    /// Reads the ID input, and checks if it is a valid number, and there is a matching record.
    /// </summary>
    /// <returns>The ID the user entered, or <a cref="NO_RECORD"/> if the number was invalid, or does not exists on the database.</returns>
    private int ReadID()
    {
        int i = NO_RECORD;
        try { i = int.Parse(txtID.Text); }
        catch (Exception e) { InvalidID(); }
        return clsOrder.IDIsValid(i) ? i : NO_RECORD;
    }

    private void showRecord(clsOrder order)
    {
        Session["Order"]      = order;
        txtID.Text            = Convert.ToString(order.OrderID);
        txtState.Text         = order.State.ToString();
        txtCust.Text          = Convert.ToString(order.OrderedBy);
        txtProc.Text          = Convert.ToString(order.ProcessedBy);
        txtDelivery.Text      = order.DeliveryNote;
        chkPaidFor.Checked    = order.PaidFor;
        PlacedOn.SelectedDate = order.PlacedOn;
        if (order.OrderID != NO_RECORD) ReadComplete(); else InvalidID();
    }

    private void InvalidID() { Display(INVALID_ID); }
    private void ReadComplete() { Display(READ_COMPLETE); }

    private void Display(String s) { lblMsg.Text = s; }

    protected void chkPaidFor_CheckedChanged(object sender, EventArgs e)
    {

    }
}