<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerConfirmDelete.aspx.cs" Inherits="CustomerConfirmDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:label runat="server" text="Are you sure you want to delete this record?"></asp:label>
            <br/><br/>
            <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" Width="48px" />
            <asp:Button ID="btnNo" runat="server" Text="No" Width="48px" OnClick="btnNo_Click" />
        </div>
    </form>
</body>
</html>
