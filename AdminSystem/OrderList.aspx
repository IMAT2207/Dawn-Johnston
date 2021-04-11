<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="OrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:ListBox ID="lstOrders" runat="server" Height="471px" Width="608px"></asp:ListBox></div>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <p>
            Search for customer ID :
            <asp:TextBox ID="txtFilter" runat="server" Width="205px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnSearch" runat="server" OnClick="search_click" Text="Filter" Width="98px" />
            <asp:Button ID="btnClear" runat="server" OnClick="search_clear" Text="Clear" Width="110px" />
        </p>
    </form>
</body>
</html>