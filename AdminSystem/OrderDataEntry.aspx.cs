using System;
using System.Drawing;
using ClassLibrary;

public partial class OrderDataEntry : System.Web.UI.Page
{
    /// <summary>
    /// Message displayed when <a cref="clsOrder.Find(int)"/> is used to read a record from the database.
    /// </summary>
    public static readonly string READ_COMPLETE = "Displaying record read from database!";

    /// <summary>
    /// When displaying a record via <a cref="showRecord(clsOrder)"/> this is the message displayed when the ID does not match a record.
    /// </summary>
    public static readonly string INVALID_ID = "Tried to display a record, but no matching record exists!";

    /// <summary>
    /// When displaying a record via <a cref="showRecord(clsOrder)"/> this is the default ID value displayed when no matching record is found.
    /// </summary>
    public static readonly int NO_RECORD = -1;

    /// <summary>
    /// Dirty Bit. <br/>
    /// A simple flag object. Raised when an invalid input is detected. <br/>
    /// Used to prevent submitting form with an invalid input.
    /// </summary>
    private class FormDirty
    {
        /// <summary>
        /// Bool representation of the flag.
        /// </summary>
        public bool isDirty { get; private set; }

        /// <summary>
        /// Raises the <c>Dirty</c> flag found in <a cref="isDirty"/>
        /// </summary>
        public void MarkDirty()
        {
            isDirty = true;
        }

        /// <summary>
        /// Lowers the <c>Dirty</c> flag found in <a cref="isDirty"/>
        /// </summary>
        public void reset()
        {
            isDirty = false;
        }
    }

    /// <summary>
    /// Dirty bit used to determine if the form has invalid inputs. Used as part of input validation to prevent submission of an invalid form.
    /// </summary>
    private FormDirty dirty = new FormDirty();

    /// <summary>
    /// Local storage for an order record. <br/>
    /// Is manipulated with user's inputs, handles validation & database access.
    /// </summary>
    private clsOrder order = new clsOrder();

    /// <summary>
    /// Attempts to submit the form with the data the user has entered.
    /// </summary>
    /// <param name="sender">The button clicked.  Ignored.</param>
    /// <param name="e">Args of this click event. Ignored.</param>
    protected void btnOK_Click(object sender, EventArgs e)
    {
        WarnIfInvalid(
                order.SetOrderID(txtID.Text)            // Attempt to parse, validate, and store the users input.
            ,                                           // If this returns false (Fails), the dirty bit is set, and a warning message is displayed to the user.
                "Order ID"                              // A dirty form is not submitted, the user must try again.
        );

        WarnIfInvalid(
            order.SetOrderState(txtState.Text)
        ,
            "Order State"
        );


        WarnIfInvalid(
            order.SetProcessedBy(txtProc.Text)
        ,
            "Processed By"
        );

        WarnIfInvalid(
            order.SetOrderedBy(txtCust.Text)
        ,
            "Ordered By"
        );

        WarnIfInvalid(
            order.SetDeliveryNote(txtDelivery.Text)
        ,
            "Delivery Note"
        );

        order.PaidFor = chkPaidFor.Checked;             // This shouldn't need validation. #Checked can only be true or false, both values are valid.

        if (dirty.isDirty) {                            // If form is dirty, reset dirty bit and return. Don't continue to success.
            dirty.reset();
            return; 
        }

        #warning This should modify the database to write a record.

        Session["Order"] = order;                       // Success! Form can be submitted. For now, Store order on session.
        lblMsg.Text = "Success!";                       // Display success message.
        Response.Redirect("OrderViewer.aspx");          // Switch to display form, which will display the record on the session.
    }

    /// <summary>
    /// Cancel button, reloads the page - effectively clearing the form.
    /// </summary>
    /// <param name="sender">The button clicked.  Ignored.</param>
    /// <param name="e">Args of this click event. Ignored.</param>
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

    /// <summary>
    /// Mutates the form to display <paramref name="order"/>. <br/>
    /// Not to be confused with the usage of <a cref="OrderDataViewer"/>
    /// </summary>
    /// <param name="order">The order whose values will be displayed on the form.</param>
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

        if (order.OrderID != NO_RECORD) ReadComplete(); else InvalidID();   // Display appropriate message. Invalid if no record matches, otherwise "Read Complete."
    }

    /// <summary>
    /// Warns the user that a <a cref="showRecord(clsOrder)"/> attempt displayed a record which does not exist.
    /// </summary>
    private void InvalidID() { Display(INVALID_ID); }

    /// <summary>
    /// Tells the user that <a cref="showRecord(clsOrder)"/> displayed an existing record successfully.
    /// </summary>
    private void ReadComplete() { Display(READ_COMPLETE); }

    /// <summary>
    /// Warns the user that a field in the form contains a value that was concidered dirty (invalid)
    /// </summary>
    /// <param name="field"></param>
    private void DisplayInvalidAttribute(string field) { Display("The '" + field + "' field was not given a valid value. Aborted. Try again."); }

    /// <summary>
    /// If an active setter returns false, indicating that the value was invalid, warns the user & sets the dirty bit.
    /// </summary>
    /// <param name="setter">The result of the setter.</param>
    /// <param name="fieldName">The name of the field being set.</param>
    private void WarnIfInvalid(bool setter, string fieldName)
    {
        if (!setter)
        {
            dirty.MarkDirty();
            DisplayInvalidAttribute(fieldName);
        }
    }

    private void Display(string s) { lblMsg.ForeColor = Color.FromArgb(200, 10, 10); lblMsg.Text = s; }

    protected void chkPaidFor_CheckedChanged(object sender, EventArgs e)
    {

    }

}