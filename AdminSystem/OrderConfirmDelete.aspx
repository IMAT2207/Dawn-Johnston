<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderConfirmDelete.aspx.cs" Inherits="OrderConfirmDelete" %>



<!DOCTYPE html>
<html style="height: 100%;width: 100%;">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>LS Goods</title>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/styles.css">
</head>

<body style="height: 100%;width: 100%;">
        <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Are you sure you want to delete record #"></asp:Label>
    <br /><br />
    <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" /><asp:Button ID="btnNo" runat="server" Text="No" OnClick="btnNo_Click" />
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
            </form>
</body>

</html>