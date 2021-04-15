<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockDataEntry.aspx.cs" Inherits="StockDataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <p>
               <asp:Label ID="lblProductID" runat="server" Text="Product ID" width="125px" height="19px"></asp:Label>
               <asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>
               <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
           </p>
           <asp:Label ID="lblProductName" runat="server" Text="Product Name" width="125px" height="19px"></asp:Label>
           <asp:TextBox ID="txtProductName" runat="server" width="128px"></asp:TextBox>
           <br />
           <br />
           <asp:Label ID="lblProductDescription" runat="server" Text="Product Description" width="125px"></asp:Label>
           <asp:TextBox ID="txtProductDescription" runat="server" width="128px"></asp:TextBox>
           <br />
           <br />
           <asp:CheckBox ID="chkAvailability" runat="server" Text="Available" height="19px" width="125px" />
           <br />
           <br />
           <asp:Label ID="lblQuantity" runat="server" Text="Quantity" width="125px" height="19px"></asp:Label>
           <asp:TextBox ID="txtQuantity" runat="server" width="128px"></asp:TextBox>
           <br />
           <br />
           <asp:Label ID="lblRestockDate" runat="server" Text="Restock Date" height="19px" width="125px"></asp:Label>
            <asp:TextBox ID="txtRestockDate" runat="server" width="128px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </div>
    </form>
</body>
</html>
