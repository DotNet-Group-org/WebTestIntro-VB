Option Strict On

Imports System
Imports System.Drawing
Imports System.Web.UI.WebControls
Imports System.Globalization

Imports App.Business

Namespace Presentation
    Public Class BirthdayClubMemberInfoPresenter
        Private view As IBirthdayClubMemberInfoView
        Private birthdayClubMemberInfo As BirthdayClubMemberInfo
        Public Const FeedbackMessage As String = "New Member Added"

        Private birthdayClubMemberRecords As Data.DataTable

        Public Sub New(ByVal view As IBirthdayClubMemberInfoView, ByVal birthdayClubMemberInfo As BirthdayClubMemberInfo)

            Me.view = view
            Me.birthdayClubMemberInfo = birthdayClubMemberInfo
            Me.LoadSchedule()
            Me.BindLanguages()

        End Sub

        Public Sub New(ByVal view As IBirthdayClubMemberInfoView, ByVal dataPath As String)
            Me.New(view, New BirthdayClubMemberInfo(dataPath))
        End Sub

        Private Sub LoadSchedule()

            Me.birthdayClubMemberRecords = Me.birthdayClubMemberInfo.List

        End Sub

        Public Sub calBirthDateSchedule_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs)

            Dim birthdaysOnThisDay As Data.DataRow() = Me.birthdayClubMemberRecords.Select("Birthdate = '" + e.Day.Date.ToShortDateString + "'")
            If birthdaysOnThisDay IsNot Nothing Then
                Dim lit As New Literal
                lit.Visible = True
                lit.Text = "<br />"
                e.Cell.Controls.Add(lit)
                Dim memberNames As New System.Text.StringBuilder(256)
                For Each row As Data.DataRow In birthdaysOnThisDay
                    memberNames.AppendFormat("{0}<br>", row("MemberName"))
                Next row
                Dim lbl As New Label
                lbl.Visible = True
                lbl.Text = String.Format("<font color='red'>{0}</font>", memberNames.ToString)
                e.Cell.Controls.Add(lbl)
            End If

        End Sub

        Public Sub calBirthDatePicker_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            Me.view.Birthdate.Text = Me.view.BirthdatePicker.SelectedDate.ToShortDateString

        End Sub

        Public Sub BindLanguages()

            Me.view.BindLanguages()

        End Sub

        Public Sub ddlLanguages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            Dim specificLanguageSelection As String = Me.view.Languages.SelectedValue
            Dim specificLanguage As String = CultureInfo.GetCultureInfo(specificLanguageSelection).EnglishName

        End Sub

        Public Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

            Me.birthdayClubMemberInfo.MemberName = view.MemberName.Text
            Me.birthdayClubMemberInfo.Birthdate = Convert.ToDateTime(view.Birthdate.Text)
            Me.birthdayClubMemberInfo.Add()
            Me.view.InfoMessage = FeedbackMessage
            Me.view.BirthdateSchedule.VisibleDate = Me.birthdayClubMemberInfo.Birthdate

        End Sub

    End Class

End Namespace
