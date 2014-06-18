Imports System
Imports NUnit.Framework
Imports System.Xml
Imports NUnit.Extensions.Asp.AspTester
Imports NUnit.Extensions.Asp
Imports NUnit.Extensions.Asp.HtmlTester
Imports System.Globalization

Namespace NUnit.Extensions.Asp
    ' Base class for NUnitAsp test fixtures.  Extend this class to use NUnitAsp.
    <TestFixture()> Public MustInherit Class WebFormTestCase
        Inherits CompatibilityAdapter
        Private setupCalled As Boolean = False

        ' Do not call.  For use by NUnit only.
        <SetUp()> Public Sub MasterSetUp()
            setupCalled = True
            HttpClient.Default = New HttpClient()
            SetUp()
        End Sub

        ' Executed before each test method is run.  Override in subclasses to do subclass
        ' set up.  NOTE: The [SetUp] attribute cannot be used in subclasses because it is already
        ' in use.
        Protected Overridable Sub SetUp()

        End Sub

        ' Do not call.  For use by NUnit only.
        <TearDown()> Public Sub MasterTearDown()
            TearDown()
        End Sub

        ' Executed after each test method is run.  Override in subclasses to do subclass
        ' clean up.  NOTE: [TearDown] attribute cannot be used in subclasses because it is
        ' already in use.
        Protected Overridable Sub TearDown()

        End Sub

        ' The web form currently loaded by the browser.
        Protected ReadOnly Property CurrentWebForm() As WebFormTester
            Get
                AssertSetUp()
                Return New WebFormTester(HttpClient.Default)
            End Get
        End Property

        ' The web browser.
        Protected ReadOnly Property Browser() As HttpClient
            Get
                AssertSetUp()
                Return HttpClient.Default
            End Get
        End Property

        Private Sub AssertSetUp()
            If Not setupCalled Then
                Fail("A required setup method in WebFormTestCase was not called.  This is probably because you used the [SetUp] attribute in a subclass of WebFormTestCase.  That is not supported.  Override the SetUp() method instead.")
            End If
        End Sub
    End Class


    ' Everything below this line is for backwards compatibility and may be deleted.

    ' For backwards compatibility; will be deprecated in the future.
    ' This class provides convenience methods for common assertions.  You
    ' should use Assert and WebAssert methods instead.
    Public Class CompatibilityAdapter
        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertTrue(ByVal condition As Boolean)
            Assert.IsTrue(condition)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertTrue(ByVal message As String, ByVal condition As Boolean)
            Assert.IsTrue(condition, message)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertEquals(ByVal expected As Object, ByVal actual As Object)
            Assert.AreEqual(expected, actual)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertEquals(ByVal message As String, ByVal expected As Object, ByVal actual As Object)
            Assert.AreEqual(expected, actual, message)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertNotNull(ByVal o As Object)
            Assert.IsNotNull(o)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertNotNull(ByVal message As String, ByVal o As Object)
            Assert.IsNotNull(o, message)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertNull(ByVal o As Object)
            Assert.IsNull(o)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertNull(ByVal message As String, ByVal o As Object)
            Assert.IsNull(o, message)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertSame(ByVal expected As Object, ByVal actual As Object)
            Assert.AreSame(expected, actual)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertSame(ByVal message As String, ByVal expected As Object, ByVal actual As Object)
            Assert.AreSame(expected, actual, message)
        End Sub

        Public Shared Sub Fail(ByVal message As String)
            Assert.Fail(message)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertVisibility(ByVal tester As ControlTester, ByVal expectedVisibility As Boolean)
            If expectedVisibility Then
                WebAssert.Visible(tester)
            Else
                WebAssert.NotVisible(tester)
            End If
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertEquals(ByVal expected As String(), ByVal actual As String())
            WebAssert.AreEqual(expected, actual)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        Public Shared Sub AssertEquals(ByVal message As String, ByVal expected As String(), ByVal actual As String())
            WebAssert.AreEqual(expected, actual, message)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        <CLSCompliant(False)> Public Shared Sub AssertEquals(ByVal expected As String()(), ByVal actual As String()())
            WebAssert.AreEqual(expected, actual)
        End Sub

        ' For backwards compatibility; will be deprecated in the future.
        <CLSCompliant(False)> Public Shared Sub AssertEquals(ByVal message As String, ByVal expected As String()(), ByVal actual As String()())
            WebAssert.AreEqual(expected, actual, message)
        End Sub

        Public Class WebFormTesterAdapter
            Inherits WebFormTester

            Sub New(ByVal browser As HttpClient)
                MyBase.New(browser)
            End Sub

        End Class

    End Class

End Namespace