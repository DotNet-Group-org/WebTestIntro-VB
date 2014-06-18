<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="../MasterPage.master" %>
<asp:Content ContentPlaceHolderID="cph" runat="server">
    <p>
        Reasons to use NUnitAsp</p>
    <p>
    </p>
    <ul>
    <li>
    Quicker Test Executions
    <blockquote>NUnitAsp saves time because it does not actually instantiate a browser</blockquote>
    <blockquote>You can set a User Agent property so that NUnitAsp mimics IE 6.0 (the default) or Firefox</blockquote>
    <blockquote>Warning: This string in HTML causes trouble with NUnitAsp:<br />
        <span style="color: #ff0000">
        &lt;!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"&gt;</span></blockquote>
        <blockquote>
            Stick that in your HTML and NUnitAsp will execute very slowly or even error out
            &nbsp;</blockquote>
    </li>
    <li>A tool made to specifically work with ASP.NET</li>
        <li>Specify Request's User Language</li>
    </ul>
    <p>
    </p>

</asp:Content>
