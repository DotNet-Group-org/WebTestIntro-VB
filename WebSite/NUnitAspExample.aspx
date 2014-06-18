<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NUnitAspExample.aspx.vb" Inherits="NUnitAspExample" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>NUnitAsp Example</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:panel ID="pnlEntry" runat="server">
            Please Enter your Name:
            <asp:TextBox ID="txtName" runat="server" TextMode="singleLine" />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Next" /><br />
        </asp:panel>

        <asp:Panel ID="pnlResults" runat="server" Visible="false">
            <asp:Label ID="lblName" runat="server" />
        </asp:Panel>

    </form>
</body>
</html>
