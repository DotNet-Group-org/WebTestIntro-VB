<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="..\masterpage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="cph">
    Let's write a simple Selenium test to get an idea how it works.<br />
    <br />
    Make sure you have a Java runtime which is needed for the Selenium Server<br />
    <br />
    Step by Step:<br />
    <blockquote>
    1. Download the latest version from http://www.openqa.org/selenium-rc/download.action<br />
    2. Create an ASPX web page<br />
    3. Create a class library for testing (or add a new class to an existing library)<br />
    4. Add References to NUnit (from the .NET tab in the Add Reference dialog), and
    the ThougthWorks.Selenium.Core.dll that was downloaded<br />
    5. Start the Selenium Server.&nbsp; Here are the contents of a .BAT file I made
    for that purpose:<br />
    <span style="color: #003399"><strong>&nbsp; &nbsp;
    TITLE Selenium<br />
        &nbsp; &nbsp;
    ECHO Starting Selenium . . .<br />
        &nbsp; &nbsp;
    CD &lt;The Folder where the Selenium RC DLL you downloaded is located&gt;\selenium-remote-control-0.9.0<br />
        &nbsp; &nbsp;
    java -jar server\selenium-server.jar -interactive<br />
    </strong></span>
    6. Write the test<br />
    7. Compile web page and test project<br />
    8. Run in NUnit<strong>&nbsp;</strong>
    </blockquote>
</asp:Content>
