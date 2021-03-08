<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDataEntry.aspx.cs" Inherits="CustomerDataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server">

        <div>
            <asp:Label ID="lblTraderID" runat="server" Text="Trader ID" width="100px"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" Width="128px"></asp:TextBox>
            <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
        </div>
        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Password" width="100px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblBusinessName" runat="server" Text="Business Name" width="100px"></asp:Label>
            <asp:TextBox ID="txtBusinessName" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblContactEmail" runat="server" Text="Contact Email" width="100px"></asp:Label>
            <asp:TextBox ID="txtContactEmail" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDeliveryAddr" runat="server" Text="Delivery Address" width="100px"></asp:Label>
            <asp:TextBox ID="txtDeliveryAddr" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblAccountCreationDate" runat="server" Text="Account Creation Date" width="100px"></asp:Label>
            <asp:Calendar ID="calendarAccountCreationDate" runat="server" Width="128px"></asp:Calendar>
        </div>
        <div>
            <asp:Label ID="lblNumberOfOrders" runat="server" Text="Number Of Orders" width="100px"></asp:Label>
            <asp:TextBox ID="txtNumberOfOrders" runat="server" Width="128px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblIsSignedIn" runat="server" Text="Is Signed In?" width="100px"></asp:Label>
            <asp:CheckBox ID="checkIsSignedIn" Text=" " runat="server"></asp:CheckBox>
        </div>
        <div>
            <asp:Label ID="lblErr" runat="server" Text="[Error]"></asp:Label>
        </div>
        <p>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK"/>
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </p>

        </form>
</body>
</html>
