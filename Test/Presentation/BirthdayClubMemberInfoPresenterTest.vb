Option Strict On

Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports App
Imports NUnit.Framework
Imports Rhino.Mocks
Imports App.Presentation
Imports App.Business

Namespace Test.Presentation
    <TestFixture()> _
    Public Class BirthdayClubMemberInfoPresenterTest
        Private mocks As MockRepository
        Private presenter As BirthdayClubMemberInfoPresenter
        Private view As IBirthdayClubMemberInfoView
        Private birthdayClubMemberInfo As BirthdayClubMemberInfo

        <SetUp()> _
        Public Sub SetUp()
            mocks = New MockRepository()
            view = mocks.CreateMock(Of IBirthdayClubMemberInfoView)()
            birthdayClubMemberInfo = mocks.CreateMock(Of birthdayClubMemberInfo)()
            presenter = New BirthdayClubMemberInfoPresenter(view, birthdayClubMemberInfo)
        End Sub

        <TearDown()> _
        Public Sub TearDown()
            mocks.VerifyAll()
        End Sub

        '    <Test()> _
        '    Public Sub ShouldHandleSelectedbirthdayClubMemberInfoChanged()
        '        ' setup expectations
        '        Dim dv As New DetailsView()
        '        dv.ChangeMode(DetailsViewMode.Insert)
        '        Expect.[Call](view.birthdayClubMemberInfoDetails).[Return](dv)
        '        mocks.ReplayAll()

        '        ' execute event handler under test
        '        presenter.SelectedbirthdayClubMemberInfoChanged(Nothing, Nothing)

        '        ' assert expected state
        '        Assert.AreEqual(DetailsViewMode.[ReadOnly], dv.CurrentMode)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandleRowDataBoundHeader()
        '        mocks.ReplayAll()

        '        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        '        Dim args As New GridViewRowEventArgs(row)
        '        presenter.birthdayClubMemberInfoRowDataBound(Nothing, args)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandleRowDataBoundBackOrdered()
        '        mocks.ReplayAll()
        '        Dim row As GridViewRow = GetGridRow(Status.BackOrdered)
        '        Dim args As New GridViewRowEventArgs(row)
        '        presenter.birthdayClubMemberInfoRowDataBound(Nothing, args)
        '        Assert.AreEqual(Color.LightBlue, row.Cells(4).BackColor)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandleRowDataBoundNotAvailable()
        '        mocks.ReplayAll()
        '        Dim row As GridViewRow = GetGridRow(Status.NotAvailable)
        '        Dim args As New GridViewRowEventArgs(row)
        '        presenter.birthdayClubMemberInfoRowDataBound(Nothing, args)
        '        Assert.AreEqual(Color.BlanchedAlmond, row.Cells(4).BackColor)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandleRowDataBoundInStock()
        '        mocks.ReplayAll()
        '        Dim row As GridViewRow = GetGridRow(Status.InStock)
        '        Dim args As New GridViewRowEventArgs(row)
        '        presenter.birthdayClubMemberInfoRowDataBound(Nothing, args)
        '        Assert.AreEqual(Color.LightGreen, row.Cells(4).BackColor)
        '    End Sub

        '    Private Function GetGridRow(ByVal status As Status) As GridViewRow
        '        Dim row As New GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal)
        '        Dim testbirthdayClubMemberInfo As New birthdayClubMemberInfo("title", "author", 10D, 20, "desc", 2006, _
        '         status)
        '        row.DataItem = testbirthdayClubMemberInfo
        '        row.Cells.Add(New TableCell())
        '        row.Cells.Add(New TableCell())
        '        row.Cells.Add(New TableCell())
        '        row.Cells.Add(New TableCell())
        '        row.Cells.Add(New TableCell())
        '        Return row
        '    End Function

        '    <Test()> _
        '    Public Sub ShouldHandlebirthdayClubMemberInfoDeleted()
        '        mocks.ReplayAll()
        '        Dim args As New ObjectDataSourceStatusEventArgs(Nothing, Nothing, Nothing)
        '        presenter.birthdayClubMemberInfoDeleted(Nothing, args)
        '        Assert.IsNull(args.Exception)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandlebirthdayClubMemberInfoDeletedException()
        '        view.ErrorMessage = birthdayClubMemberInfo.DeleteErrorMessage
        '        mocks.ReplayAll()
        '        Dim args As New ObjectDataSourceStatusEventArgs(Nothing, Nothing, New Exception("test", New Exception(birthdayClubMemberInfo.DeleteErrorMessage)))
        '        presenter.birthdayClubMemberInfoDeleted(Nothing, args)
        '        Assert.IsTrue(args.ExceptionHandled)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldInvalidateYear()
        '        mocks.ReplayAll()
        '        Dim args As New ServerValidateEventArgs(2100.ToString(), True)
        '        presenter.YearValidate(Nothing, args)
        '        Assert.IsFalse(args.IsValid)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldValidateYear()
        '        mocks.ReplayAll()
        '        Dim args As New ServerValidateEventArgs((DateTime.Now.Year + 1).ToString(), True)
        '        presenter.YearValidate(Nothing, args)
        '        Assert.IsTrue(args.IsValid)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandlebirthdayClubMemberInfoItemUpdated()
        '        Dim dv As New DetailsView()
        '        Expect.[Call](view.birthdayClubMemberInfoDetails).[Return](dv)
        '        view.BindBirthdayClubMemberInfo()
        '        mocks.ReplayAll()
        '        presenter.birthdayClubMemberInfoItemUpdated(Nothing, Nothing)
        '        Assert.AreEqual(DetailsViewMode.Insert, dv.CurrentMode)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandlebirthdayClubMemberInfoItemInserted()
        '        Dim dv As New DetailsView()
        '        Expect.[Call](view.birthdayClubMemberInfoDetails).[Return](dv)
        '        view.BindBirthdayClubMemberInfo()
        '        mocks.ReplayAll()
        '        presenter.birthdayClubMemberInfoItemInserted(Nothing, Nothing)
        '        Assert.AreEqual(DetailsViewMode.Insert, dv.CurrentMode)
        '    End Sub

        '    <Test()> _
        '    Public Sub ShouldHandleAdjustPriceClicked()
        '        Dim percent As Decimal = 10D
        '        Expect.[Call](view.PriceAdjustPercent).[Return](percent.ToString())
        '        BirthdayClubMemberInfo.AdjustPrice(10D)
        '        view.BindBirthdayClubMemberInfo()
        '        view.InfoMessage = String.Format(BirthdayClubMemberInfoPresenter.AdjustPriceMessage, 10D)
        '        mocks.ReplayAll()
        '        presenter.AdjustPriceClicked(Nothing, Nothing)
        '    End Sub
    End Class
End Namespace
