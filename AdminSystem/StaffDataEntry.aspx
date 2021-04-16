<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffDataEntry.aspx.cs" Inherits="StaffDataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblStaffID" runat="server" Text="StaffID" width="81px"></asp:Label>
        <asp:TextBox ID="txtStaffID" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
        <p>
            <asp:Label ID="lblStaffPassword" runat="server" Text="Password" width="81px"></asp:Label>
            <asp:TextBox ID="txtStaffPassword" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblRecordCreated" runat="server" Text="Record Created" width="81px"></asp:Label>
        <asp:TextBox ID="txtRecordCreated" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lblFirstname" runat="server" Text="First Name" width="81px"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lblFamilyName" runat="server" Text="Family Name" width="81px"></asp:Label>
        <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
        <p>
            <asp:CheckBox ID="chkIsManager" runat="server" Text="Is Manager?" />
        </p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <p>
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="OK" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </p>
    </form>
</body>
</html>
