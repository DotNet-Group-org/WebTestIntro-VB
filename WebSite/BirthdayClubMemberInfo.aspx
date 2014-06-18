<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BirthdayClubMemberInfo.aspx.vb" Inherits="BirthdayClubMemberInfo" UICulture="auto" Culture="auto" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Birthday Club Member Info</title>
    <style type="text/css">
       td {font-size:10pt;font-family:arial;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblMessage" EnableViewState="False" BorderStyle="None"
                        meta:resourcekey="lblMessageResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Localize ID="lclChooseLanguage" runat="server" Text="Choose Language:" meta:resourcekey="lclChooseLanguageResource1" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="True" meta:resourcekey="ddlLanguagesResource1" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Localize ID="lclInstructions" runat="server" Text="Enter Birthdate Info:" meta:resourcekey="lclInstructionsResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Localize ID="lclYourName" runat="server" Text="Your Name:" meta:resourcekey="lclYourNameResource1" />
                </td>
                <td>
                    <asp:TextBox ID="txtMemberName" runat="server" meta:resourcekey="txtMemberNameResource1" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Localize ID="lclYourNextBirthday" runat="server" Text="Your Next Birthday:"
                        meta:resourcekey="lclYourNextBirthdayResource1" />
                </td>
                <td>
                    <asp:Label ID="lblBirthdate" runat="server" Text="Select Your Birthday from the Calendar"
                        meta:resourcekey="lblBirthdateResource1" /><br />
                    <asp:Calendar ID="calBirthDatePicker" runat="server" meta:resourcekey="calBirthDatePickerResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Member" meta:resourcekey="btnAddResource" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Localize ID="lclBirthdayClubSchedule" Text="Birthday Club Schedule:" runat="server"
                        meta:resourcekey="lclBirthdayClubScheduleResource1" /><br />
                    <asp:Calendar ID="calBirthDateSchedule" runat="server" meta:resourcekey="calBirthDateScheduleResource1" DayStyle-Height="30" DayStyle-Width="60" OtherMonthDayStyle-BackColor="gray" />
                    <br />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
