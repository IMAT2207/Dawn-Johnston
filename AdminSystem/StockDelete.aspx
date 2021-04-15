<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockDelete.aspx.cs" Inherits="StockDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 289px">
    <form id="form1" runat="server">
        <div style="height: 18px">
            Are you sure you want to delete this record?<br />
            <br />
        </div>
        <p>
            <asp:Button ID="btnYes" runat="server" Text="Yes" />
            <asp:Button ID="btnNo" runat="server" Text="No" />
        </p>
    </form>
</body>
</html>
