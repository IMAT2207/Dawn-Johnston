<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lstCustomers" runat="server" Height="246px" Width="343px"></asp:ListBox>
            <br/>
            <asp:Button ID="btnAdd" runat="server" Height="25px" Text="Add" Width="58px" OnClick="btnAdd_Click" />
            <asp:Button ID="btnEdit" runat="server" Height="25px" Text="Edit" Width="58px" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Height="25px" Text="Delete" Width="58px" OnClick="btnDelete_Click" />
            <br/><br/>
            <asp:Label ID="Label1" runat="server" Text="Enter A Business Name"></asp:Label>
            <asp:TextBox ID="txtBusinessNameSearch" runat="server"></asp:TextBox>
            <br/><br/>
            <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnApply_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <br/><br/>
            <asp:label ID="lblError" runat="server" text=""></asp:label>
        </div>
    </form>
</body>
