Option Strict On

Imports System.Web.UI.WebControls

Namespace Presentation
    Public Interface IBirthdayClubMemberInfoView

        ReadOnly Property Languages() As DropDownList
        ReadOnly Property MemberName() As TextBox
        Property Birthdate() As Label
        Property BirthdatePicker() As Web.UI.WebControls.Calendar

        Property BirthdateSchedule() As Web.UI.WebControls.Calendar

        WriteOnly Property ErrorMessage() As String
        WriteOnly Property InfoMessage() As String

        Sub BindLanguages()

    End Interface
End Namespace
