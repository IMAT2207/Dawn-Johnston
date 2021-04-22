<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerViewer.aspx.cs" Inherits="CustomerViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCustomer" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnRedirect" runat="server" Text="Customer List" OnClick="btnRedirect_Click" />
        </div>
    </form>
</body>
</html>
