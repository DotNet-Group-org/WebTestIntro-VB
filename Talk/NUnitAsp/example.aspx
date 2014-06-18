<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="..\masterpage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="cph">
    Let's write a simple NUnitAsp test to get an idea how it works.<br />
    <br />
    Step by Step:<br />
    <blockquote>
    1. Download the latest version from http://nunitasp.sourceforge.net/download.html<br />
    2. Create an ASPX web page<br />
    3. Create a class library for testing<br />
    4. Add References to NUnit (from the .NET tab in the Add Reference dialog), and the NUnitAsp.dll that was downloaded<br />
    5. Include "NUnitAdapter" in the testing class library.&nbsp; The NUnitAsp download
    includes a .cs version, I have translated it to .vb<br />
    6. Write the test<br />
    7. Compile web page and test project<br />
    8. Run in NUnit<strong>&nbsp;</strong>
    </blockquote>
</asp:Content>
