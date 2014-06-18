<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GridViewExample.aspx.vb" Inherits="GridViewExample" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="List" TypeName="App.Business.BirthdayClubMemberInfo">
        </asp:ObjectDataSource>
    </div>
        <asp:GridView ID="gv" runat="server" DataSourceID="ObjectDataSource1">
        </asp:GridView>
    </form>
</body>
</html>
