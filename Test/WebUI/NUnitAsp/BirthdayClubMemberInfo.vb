Option Strict On

Imports NUnit.Framework
Imports NUnit.Extensions.Asp
Imports NUnit.Extensions.Asp.AspTester

Namespace NUnitAsp

    <TestFixture()> Public Class BirthdayClubMemberInfoFixture
        Inherits NUnit.Extensions.Asp.WebFormTestCase

        Private mTestURL As String

        Private form As WebFormTester
        Private txtMemberName As TextBoxTester
        Private ddlLanguages As DropDownListTester
        Private btnAdd As ButtonTester
        Private lblBirthdate As LabelTester
        Private lblMessage As LabelTester

        Protected Overrides Sub SetUp()

            ReDim MyBase.Browser.UserLanguages(0)
            MyBase.Browser.UserLanguages(0) = "en-US"

            Me.mTestURL = "http://localhost/test/WebTestIntro/BirthdayClubMemberInfo.aspx"

            Me.form = New WebFormTester(MyBase.Browser)
            Me.txtMemberName = New TextBoxTester("txtMemberName")
            Me.ddlLanguages = New DropDownListTester("ddlLanguages")
            Me.btnAdd = New ButtonTester("btnAdd")
            Me.lblBirthdate = New LabelTester("lblBirthdate")
            Me.lblMessage = New LabelTester("lblMessage")

            MyBase.Browser.GetPage(Me.mTestURL)
            Assert.AreEqual(Me.mTestURL, MyBase.Browser.CurrentUrl.ToString)

        End Sub

        <Test()> Public Sub SmokeTest()

            AssertVisibility(Me.txtMemberName, True)

        End Sub

        <Test()> Public Sub PickDate()

            Assert.AreEqual(Me.lblBirthdate.Text, "Select Your Birthday from the Calendar")
            Me.form.PostBack("javascript:__doPostBack('calBirthDatePicker','2766')")
            Assert.IsTrue(IsDate(Me.lblBirthdate.Text), "No Date Selected")

        End Sub

        <Test()> Public Sub AddMember()

            Me.txtMemberName.Text = "NUnitAsp Test"
            Me.PickDate()
            Me.btnAdd.Click()
            Assert.AreEqual(Me.lblMessage.Text, "New Member Added")

            Dim re As New Text.RegularExpressions.Regex(Me.txtMemberName.Text)
            Assert.AreEqual(2, re.Matches(MyBase.Browser.CurrentPageText).Count, "Should be exactly 2 instances of newly added member on page")

        End Sub

        <Test()> Public Sub ChooseDifferentLanguage()

            Me.ddlLanguages.SelectedValue = "ja-JP"
            Dim expectedBirthdateLabelText As String = My.Resources.SelectBirthdayCalendarJP
            Assert.AreEqual(expectedBirthdateLabelText, Me.lblBirthdate.Text)

        End Sub

        <Test()> Public Sub UseDifferentUserLanguage()

            MyBase.Browser.UserLanguages(0) = "ja-JP"
            MyBase.Browser.GetPage(Me.mTestURL)
            Dim expectedBirthdateLabelText As String = My.Resources.SelectBirthdayCalendarJP
            Assert.AreEqual(expectedBirthdateLabelText, Me.lblBirthdate.Text)

        End Sub

        Protected Overrides Sub TearDown()

            Dim appDataFolder As String = "C:\data\programs\examples\WebTestingIntro\SourceCode\WebTestIntro\WebSite\App_Data\"
            IO.File.Copy(appDataFolder + "BACKUPBirthdayClubMembers.xml", appDataFolder + "BirthdayClubMembers.xml", True)

        End Sub

        <Test()> Public Sub GridViewExample()

            Dim gridview As New DataGridTester("gv")

            MyBase.Browser.GetPage("http://localhost/test/WebTestIntro/GridViewExample.aspx")

            AssertVisibility(gridview, True)
            Assert.Greater(gridview.RowCount, 0, "No rows in grid view")

        End Sub

    End Class

End Namespace