Option Strict On

Imports NUnit.Framework
Imports Selenium

Namespace Selenium

    <TestFixture()> Public Class BirthdayClubMemberInfoFixture

        Private Browser As DefaultSelenium

        Private mTestURL As String

        Private txtMemberName As String = "txtMemberName"
        Private ddlLanguages As String = "ddlLanguages"
        Private btnAdd As String = "btnAdd"
        Private lblBirthdate As String = "lblBirthdate"
        Private lblMessage As String = "lblMessage"

        <SetUp()> Protected Sub SetUp()

            Me.mTestURL = "http://localhost/test/WebTestIntro/BirthdayClubMemberInfo.aspx"

            ' 4444 is the default port for the Selenium Server            
            Me.Browser = New DefaultSelenium("localhost", 4444, "*iexplore", Me.mTestURL)
            Me.Browser.Start()
            Me.Browser.Open(Me.mTestURL)
            Assert.AreEqual(Me.mTestURL, Me.Browser.GetLocation)

        End Sub

        <Test()> Public Sub SmokeTest()

            Assert.GreaterOrEqual(Me.Browser.GetElementIndex(Me.txtMemberName), 0, "Element " + Me.txtMemberName + " not visible")

        End Sub

        <Test()> Public Sub PickDate()

            Assert.AreEqual(Me.Browser.GetText(Me.lblBirthdate), "Select Your Birthday from the Calendar")
            Me.Browser.Click("link=14")
            Me.Browser.WaitForPageToLoad("6000")
            Assert.IsTrue(IsDate(Me.Browser.GetText(Me.lblBirthdate)), "No Date Selected")

        End Sub

        <Test()> Public Sub AddMember()

            Me.Browser.Type(Me.txtMemberName, "SeleniumTest")
            Me.PickDate()
            Me.Browser.Click(Me.btnAdd)
            Me.Browser.WaitForPageToLoad("6000")

            Assert.AreEqual(Me.Browser.GetText(Me.lblMessage), "New Member Added")

            Dim re As New Text.RegularExpressions.Regex(Me.Browser.GetValue(Me.txtMemberName))
            '            Assert.AreEqual(2, re.Matches(Me.Browser.GetBodyText).Count, "Should be exactly 2 instances of newly added member on page")

        End Sub

        <Test()> Public Sub ChooseDifferentLanguage()

            Me.Browser.Select(Me.ddlLanguages, "value=ja-JP")
            Me.Browser.WaitForPageToLoad("6000")
            Dim expectedBirthdateLabelText As String = My.Resources.SelectBirthdayCalendarJP
            Assert.AreEqual(expectedBirthdateLabelText, Me.Browser.GetText(Me.lblBirthdate))

        End Sub

        '<Test()> Public Sub UseDifferentUserLanguage()

        '    MyBase.Browser.UserLanguages(0) = "ja-JP"
        '    MyBase.Browser.GetPage(Me.mTestURL)
        '    Dim expectedBirthdateLabelText As String = My.Resources.SelectBirthdayCalendarJP
        '    Assert.AreEqual(expectedBirthdateLabelText, Me.lblBirthdate.Text)

        'End Sub

        <TearDown()> Protected Sub TearDown()

            Me.Browser.Stop()

            Dim appDataFolder As String = "C:\data\programs\examples\WebTestingIntro\SourceCode\WebTestIntro\WebSite\App_Data\"
            IO.File.Copy(appDataFolder + "BACKUPBirthdayClubMembers.xml", appDataFolder + "BirthdayClubMembers.xml", True)

        End Sub

    End Class

End Namespace