Option Strict On

Imports NUnit.Framework
Imports Selenium

Namespace Selenium

    <TestFixture()> Public Class SmokeTestFixture

        Private Browser As DefaultSelenium

        Private mTestURL As String

        <Test(), Category("SmokeTest")> Public Sub SmokeTest()

            Me.mTestURL = "http://localhost/test/WebTestIntro/SmokeTest.aspx"

            Me.Browser = New DefaultSelenium("localhost", 4444, "*iexplore", Me.mTestURL)
            Me.Browser.Start()
            Me.Browser.Open(Me.mTestURL)
            Assert.AreEqual(Me.mTestURL, Me.Browser.GetLocation)

        End Sub

        <TearDown()> Protected Overridable Sub TearDown()

            Me.Browser.Stop()

        End Sub

    End Class

End Namespace