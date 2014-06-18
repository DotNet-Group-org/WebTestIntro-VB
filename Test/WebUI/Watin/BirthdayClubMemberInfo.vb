Option Strict On

Imports NUnit.Framework
Imports WatiN.Core

Namespace WatiN

    <TestFixture()> Public Class BirthdayClubMemberInfoFixture

        Private Browser As IE

        Private mTestURL As String

        Private txtMemberName As TextField
        Private ddlLanguages As SelectList
        Private btnAdd As Button
        Private lblBirthdate As Span
        Private lblMessage As Span

        <SetUp()> Protected Sub SetUp()

            Me.mTestURL = "http://localhost/test/WebTestIntro/BirthdayClubMemberInfo.aspx"

            Me.Browser = New IE(Me.mTestURL)
            Assert.AreEqual(Me.mTestURL, Me.Browser.Url)

            Me.txtMemberName = New TextField(Me.Browser.Element(Find.ById("txtMemberName")))
            Me.ddlLanguages = New SelectList(Me.Browser.Element(Find.ById("ddlLanguages")))
            Me.btnAdd = New Button(Me.Browser.Element(Find.ById("btnAdd")))
            Me.lblBirthdate = New Span(Me.Browser.Element(Find.ById("lblBirthdate")))
            Me.lblMessage = New Span(Me.Browser.Element(Find.ById("lblMessage")))

        End Sub

        <Test()> Public Sub SmokeTest()

            Assert.IsTrue(Me.txtMemberName.Exists, "Element " + Me.txtMemberName.Id + " not visible")
            Assert.IsTrue(Me.ddlLanguages.Exists, "Element " + Me.ddlLanguages.Id + " not visible")
            Assert.IsTrue(Me.lblBirthdate.Exists, "Element " + Me.lblBirthdate.Id + " not visible")

        End Sub

        <Test()> Public Sub PickDate()

            Assert.AreEqual(Me.lblBirthdate.Text, "Select Your Birthday from the Calendar")
            UtilityClass.RunScript("javascript:__doPostBack('calBirthDatePicker','2766')", "javascript", Me.Browser.HtmlDocument.parentWindow)
            Me.lblBirthdate = New Span(Me.Browser.Element(Find.ById(Me.lblBirthdate.Id)))
            Assert.IsTrue(IsDate(Me.lblBirthdate.Text), "No Date Selected (value = " + Me.lblBirthdate.Text + ")")

        End Sub

        <Test()> Public Sub AddMember()

            Me.txtMemberName.TypeText("WatiN Test")
            Me.PickDate()
            Me.btnAdd = New Button(Me.Browser.Element(Find.ById("btnAdd")))
            Me.btnAdd.Click()
            Me.lblMessage = New Span(Me.Browser.Element(Find.ById("lblMessage")))
            Assert.AreEqual(Me.lblMessage.Text, "New Member Added")

            Dim re As New System.Text.RegularExpressions.Regex(Me.txtMemberName.Text)
            Assert.AreEqual(2, re.Matches(Me.Browser.HtmlDocument.body.innerHTML).Count, "Should be exactly 2 instances of newly added member on page")

        End Sub

        <Test()> Public Sub ChooseDifferentLanguage()

            Me.ddlLanguages.SelectByValue("ja-JP")
            Dim expectedBirthdateLabelText As String = My.Resources.SelectBirthdayCalendarJP
            Me.lblBirthdate = New Span(Me.Browser.Element(Find.ById("lblBirthdate")))
            Assert.AreEqual(expectedBirthdateLabelText, Me.lblBirthdate.Text)

        End Sub

        '<Test()> Public Sub UseDifferentUserLanguage()

        '    MyBase.Browser.UserLanguages(0) = "ja-JP"
        '    MyBase.Browser.GetPage(Me.mTestURL)
        '    Dim expectedBirthdateLabelText As String = My.Resources.SelectBirthdayCalendarJP
        '    Assert.AreEqual(expectedBirthdateLabelText, Me.lblBirthdate.Text)

        'End Sub

        <TearDown()> Protected Sub TearDown()

            Me.Browser.Close()

            Dim appDataFolder As String = "C:\data\programs\examples\WebTestingIntro\SourceCode\WebTestIntro\WebSite\App_Data\"
            IO.File.Copy(appDataFolder + "BACKUPBirthdayClubMembers.xml", appDataFolder + "BirthdayClubMembers.xml", True)

        End Sub

    End Class

End Namespace