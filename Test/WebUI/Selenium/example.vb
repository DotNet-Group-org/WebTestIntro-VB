Option Strict On

Imports NUnit.Framework
Imports Selenium

Namespace Selenium

    <TestFixture()> Public Class ExampleFixture

        Private Browser As DefaultSelenium

        Private mTestURL As String

        ' there are no "tester" objects like in NUnitAsp - Selenium will parse HTML output with string identifiers
        Private pnlEntry As String = "pnlEntry"
        Private txtName As String = "txtName"
        Private btnSubmit As String = "btnSubmit"
        Private pnlResults As String = "pnlResults"
        Private lblName As String = "lblName"

        ' SetUp is called before every test method
        ' NOTE: for Selenium we do need to use the <SetUp> attribute
        <SetUp()> Protected Sub SetUp()

            ' set test URL
            Me.mTestURL = "http://localhost/test/WebTestIntro/SeleniumExample.aspx"

            ' Instantiate Selenium and start the browser (I believe this is where it actually creates a browser window)
            ' 4444 is the default port for the Selenium Server            
            Me.Browser = New DefaultSelenium("localhost", 4444, "*iexplore", Me.mTestURL)
            Me.Browser.Start()

            ' navigate to the page
            Me.Browser.Open(Me.mTestURL)

            ' verify we made it to the page
            Assert.AreEqual(Me.mTestURL, Me.Browser.GetLocation)

        End Sub

        ' does our page load as expected?
        <Test()> Public Sub SmokeTest()

            ' These is no AssertVisibility convenience method provided by Selenium, but it's so useful I created my own
            AssertVisibility(Me.pnlEntry, True)

            AssertVisibility(Me.txtName, True)
            AssertVisibility(Me.btnSubmit, True)

            AssertVisibility(Me.pnlResults, False)
            AssertVisibility(Me.lblName, False)

        End Sub

        Private Sub AssertVisibility(ByVal controlID As String, ByVal shouldBeVisible As Boolean)

            If shouldBeVisible Then
                Try
                    If Me.Browser.GetElementIndex(controlID) >= 0 Then Return
                Catch ex As Exception
                    Assert.Fail("Control '" + controlID + "' should be Visible.")
                End Try
            Else
                Try
                    If Me.Browser.GetElementIndex(controlID) < 0 Then Return
                    Assert.Fail("Control '" + controlID + "' should NOT be Visible.")
                Catch ex As Exception
                    Return
                End Try
            End If

        End Sub

        ' Let's try some interaction
        <Test()> Public Sub EnterName()

            Dim name As String = "John Hilts"

            ' put some text in a text box
            Me.Browser.Type(Me.txtName, name)

            ' click the submit button
            Me.Browser.Click(Me.btnSubmit)
            ' NOTE: alternatively, we could have done this to submit the form:
            ' Me.Browser.Submit()

            ' Selenium will time out a lot but that can be prevented with wait calls
            ' this isn't a problem with NUnitAsp or WatiN
            Me.Browser.WaitForPageToLoad("6000")

            ' Retrieves the message of a JavaScript confirmation dialog generated during the previous action. 
            ' By default, the confirm function will return true, having the same effect as manually clicking OK. 
            Me.Browser.GetConfirmation()

            ' after post back, verify that the label displays the name
            Assert.AreEqual(name, Me.Browser.GetText(Me.lblName), "Wrong Name")

            ' verify visibility of the rest of the controls
            AssertVisibility(Me.pnlEntry, False)
            AssertVisibility(Me.txtName, False)
            AssertVisibility(Me.btnSubmit, False)

            AssertVisibility(Me.pnlResults, True)
            AssertVisibility(Me.lblName, True)

        End Sub

        <TearDown()> Protected Overridable Sub TearDown()

            ' this closes the browser window
            Me.Browser.Stop()
            ' if you want to see what the browser looks like, comment out the .Stop call

        End Sub

    End Class

End Namespace