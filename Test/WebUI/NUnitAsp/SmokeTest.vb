Option Strict On

Imports NUnit.Framework
Imports NUnit.Extensions.Asp
Imports NUnit.Extensions.Asp.AspTester

Namespace NUnitAsp

    <TestFixture()> Public Class SmokeTestFixture
        Inherits NUnit.Extensions.Asp.WebFormTestCase

        Private mTestURL As String

        Protected Overrides Sub SetUp()

            Me.mTestURL = "http://localhost/test/WebTestIntro/SmokeTest.aspx"

        End Sub

        <Test(), Category("SmokeTest")> Public Sub SmokeTest()

            MyBase.Browser.GetPage(Me.mTestURL)
            Assert.AreEqual(Me.mTestURL, MyBase.Browser.CurrentUrl.ToString)
            Console.WriteLine("hi!")

        End Sub

    End Class

End Namespace