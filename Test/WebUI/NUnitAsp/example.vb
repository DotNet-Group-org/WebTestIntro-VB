Option Strict On

Imports NUnit.Framework
' these are the imports for NUnitAsp
Imports NUnit.Extensions.Asp
' this maps the the Asp Server Side control testers
Imports NUnit.Extensions.Asp.AspTester
' NUnit.Extensions.Asp.HtmlTester maps to HTML Server Side Control testers

Namespace NUnitAsp

    <TestFixture()> Public Class ExampleFixture
        ' All test NUnitAsp test fixtures need to inherit the WebFormTestCase class, which is defined in NUnitAdapter
        Inherits NUnit.Extensions.Asp.WebFormTestCase

        Private mTestURL As String

        ' define test objects that correspond to server side controls on web page
        Private pnlEntry As PanelTester
        Private txtName As TextBoxTester
        Private btnSubmit As ButtonTester
        Private pnlResults As PanelTester
        Private lblName As LabelTester

        ' SetUp is called before every test method
        ' NOTE: NUnitAsp's WebFormTestCase already has a method with the <SetUp> attribute, so applying it here causes 
        ' problems
        Protected Overrides Sub SetUp()

            ' set test URL
            Me.mTestURL = "http://localhost/test/WebTestIntro/NUnitAspExample.aspx"

            ' instantiate testers.  Note that the naming container can be specified
            Me.pnlEntry = New PanelTester("pnlEntry")
            Me.txtName = New TextBoxTester("txtName", Me.pnlEntry)
            Me.btnSubmit = New ButtonTester("btnSubmit", Me.pnlEntry)
            Me.pnlResults = New PanelTester("pnlResults")
            Me.lblName = New LabelTester("lblName", Me.pnlResults)

            ' navigate to the page
            MyBase.Browser.GetPage(Me.mTestURL)

            ' verify we made it to the page
            Assert.AreEqual(Me.mTestURL, MyBase.Browser.CurrentUrl.ToString)

        End Sub

        ' does our page load as expected?
        <Test()> Public Sub SmokeTest()

            ' These first 2 methods are functionally equivalent.  AssertVisibility is a convenience method provided by 
            ' NUnitAsp
            Assert.IsTrue(Me.pnlEntry.Visible, "Entry Panel should be visible")
            AssertVisibility(Me.pnlEntry, True)

            AssertVisibility(Me.txtName, True)
            AssertVisibility(Me.btnSubmit, True)

            AssertVisibility(Me.pnlResults, False)
            AssertVisibility(Me.lblName, False)

        End Sub

        ' Let's try some interaction
        <Test()> Public Sub EnterName()

            Dim name As String = "John Hilts"

            ' put some text in a text box
            Me.txtName.Text = name

            ' click the submit button
            ' NOTE: NUnitAsp also provides a form tester, so if there wasn't a button available, you could still post
            ' the form
            Me.btnSubmit.Click()

            ' after post back, verify that the label displays the name
            Assert.AreEqual(name, Me.lblName.Text, "Wrong Name")

            ' verify visibility of the rest of the controls
            AssertVisibility(Me.pnlEntry, False)
            AssertVisibility(Me.txtName, False)
            AssertVisibility(Me.btnSubmit, False)

            AssertVisibility(Me.pnlResults, True)
            AssertVisibility(Me.lblName, True)

        End Sub

    End Class

End Namespace