Option Strict On

Imports NUnit.Framework

Imports WatiN.Core
Imports WatiN.Core.DialogHandlers

Namespace WatiN

    <TestFixture()> Public Class ExampleFixture

        Private Browser As IE

        Private mTestURL As String

        ' define test objects that correspond to server side controls on web page
        ' note: I'm defining these objects based on the client-side equivalent of the server-side control
        ' divs for panels, spans for labels, etc
        Private pnlEntry As Div
        Private txtName As TextField
        Private btnSubmit As Button
        Private pnlResults As Div
        Private lblName As Span

        ' SetUp is called before every test method
        ' NOTE: for WatiN we do need to use the <SetUp> attribute
        <SetUp()> Protected Overridable Sub SetUp()

            ' set test URL
            Me.mTestURL = "http://localhost/test/WebTestIntro/SeleniumExample.aspx" ' I'm using the same example as NUnitAsp

            ' navigate to the page
            Me.Browser = New IE(Me.mTestURL)

            ' verify we made it to the page
            Assert.AreEqual(Me.mTestURL, Me.Browser.Url)

            Me.GetControls(False)

        End Sub

        Private Sub GetControls(ByVal isPostBack As Boolean)

            ' instantiate testers.
            If isPostBack Then
                Me.pnlResults = New Div(Me.Browser.Element(Find.ById("pnlResults")))
                Me.lblName = New Span(Me.Browser.Element(Find.ById("lblName")))
            Else
                Me.pnlEntry = New Div(Me.Browser.Element(Find.ById("pnlEntry")))
                Me.txtName = New TextField(Me.Browser.Element(Find.ById("txtName")))
                Me.btnSubmit = New Button(Me.Browser.Element(Find.ById("btnSubmit")))
            End If

        End Sub

        ' does our page load as expected?
        <Test()> Public Sub SmokeTest()

            ' These is no AssertVisibility convenience method provided by WatiN, but it's so useful I created my own
            AssertVisibility(Me.pnlEntry.Id, True)

            AssertVisibility(Me.txtName.Id, True)
            AssertVisibility(Me.btnSubmit.Id, True)

            'AssertVisibility(Me.pnlResults.Id, False)
            'AssertVisibility(Me.lblName.Id, False)

        End Sub

        Private Sub AssertVisibility(ByVal id As String, ByVal shouldBeVisible As Boolean)

            Assert.AreEqual(shouldBeVisible, Me.Browser.Element(Find.ById(id)).Exists)

        End Sub

        Protected Sub AssertVisibility(ByVal element As Element, ByVal shouldBeVisible As Boolean)

            Assert.AreEqual(shouldBeVisible, Me.Browser.Element(Find.ById(element.Id)).Exists)

        End Sub

        ' Let's try some interaction
        <Test()> Public Sub EnterName()

            Dim name As String = "John Hilts"

            ' put some text in a text box
            Me.txtName.TypeText(name)

            ' click the submit button
            Me.btnSubmit.Click()
            ' NOTE: alternatively, we could have done this to submit the form:
            ' Me.Browser.Form("FormID").Submit()

            ' click the confirm dialog OK button
            Dim confirm As New ConfirmDialogHandler
            Me.Browser.AddDialogHandler(confirm)
            confirm.WaitUntilExists(5)
            confirm.OKButton.Click()

            ' NOTE: In WatiN, I need to instantiate (re-instantiate) any controls I want to reference after post-back
            Me.GetControls(True)

            ' after post back, verify that the label displays the name
            Assert.AreEqual(name, Me.lblName.Text, "Wrong Name")

            ' verify visibility of the rest of the controls
            AssertVisibility(Me.pnlEntry, False)
            AssertVisibility(Me.txtName, False)
            AssertVisibility(Me.btnSubmit, False)

            AssertVisibility(Me.pnlResults, True)
            AssertVisibility(Me.lblName, True)

        End Sub

        <TearDown()> Protected Sub TearDown()

            Me.Browser.Close()

        End Sub

    End Class

End Namespace