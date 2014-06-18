<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID="cph" runat="server">
    <strong><span style="font-size: 14pt">
        Introduction to Web UI Testing Frameworks<br />
    </span></strong>
    <br />
    <strong>
    NUnitAsp </strong>- http://nunitasp.sourceforge.net/<br />
    <br />
    <strong>
    Selenium Remote Control </strong>- http://www.openqa.org/selenium/<br />
    <br />
    <strong>WatiN </strong>- http://watin.sourceforge.net/<br />
    <strong>
        <br />
        What</strong>: These 3 frameworks allow you to write automated tests for your Web UI.<br />
    &nbsp; These are extensions to Unit Tests written for business logic, which would
    fall under the category of "Integration Tests".<br />
    <br />
    <strong>Who</strong>: Tests are written by the developer, similar to Unit Tests.&nbsp; Instead of
    writing tests against business objects, these tests are written against web pages
    to verify they work correctly.<br />
    <br />
    <strong>When</strong>: I believe Unit Tests and Integration Tests are most effective when written
    FIRST, that is you write a failing test first, then write the code that makes the
    test pass.&nbsp; One benefit of this is that you grow a regression testing suite
    as you write your code.<br />
    <br />
    <strong>Where</strong>: Some developers write their tests in the same project as the items they test
    (using conditional compiling to keep any testing code out of release), others have
    a separate test project which contains all the test code.<br />
    <br />
    <strong>Why</strong>: Automated tests are more efficient than opening a browser and making sure it
    works, especially as more and more changes are added.&nbsp;<br />
    <br />
        <br />
</asp:Content>