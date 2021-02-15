<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDataEntry.aspx.cs" Inherits="OrderDataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblID" runat="server" Text="Order ID"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Order State"></asp:Label>
            <asp:DropDownList ID="cmbState" runat="server">
                <asp:ListItem Value="WIP"></asp:ListItem>
                <asp:ListItem Value="Finalized"></asp:ListItem>
                <asp:ListItem Value="Shipped"></asp:ListItem>
                <asp:ListItem Value="Delievered"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Processed By"></asp:Label>
            <asp:TextBox ID="txtProcessedBy" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblOrderedBy" runat="server" Text="Ordered By"></asp:Label>
            <asp:TextBox ID="txtOrderedBy" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDeliveryNote" runat="server" Text="Delivery Note"></asp:Label>
            <asp:TextBox ID="txtDeliveryNote" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblError" runat="server" Text="(Message)"></asp:Label>
        </div>
        <p>
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
            <asp:Button ID="btnOkay" runat="server" OnClick="btnOK_Click" Text="OK" />
        </p>
    </form>
</body>
</html>
