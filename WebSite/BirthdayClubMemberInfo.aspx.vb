Option Strict On

Imports System.Globalization

Imports App.Presentation

Partial Class BirthdayClubMemberInfo
    Inherits System.Web.UI.Page
    Implements IBirthdayClubMemberInfoView

    Private presenter As BirthdayClubMemberInfoPresenter

    Public ReadOnly Property Languages() As DropDownList Implements IBirthdayClubMemberInfoView.Languages
        Get
            Return Me.ddlLanguages
        End Get
    End Property
    Public ReadOnly Property MemberName() As TextBox Implements IBirthdayClubMemberInfoView.MemberName
        Get
            Return Me.txtMemberName
        End Get
    End Property
    Public Property Birthdate() As Label Implements IBirthdayClubMemberInfoView.Birthdate
        Get
            Return Me.lblBirthdate
        End Get
        Set(ByVal value As Label)
            Me.lblBirthdate = value
        End Set
    End Property
    Public Property BirthdatePicker() As WebControls.Calendar Implements IBirthdayClubMemberInfoView.BirthdatePicker
        Get
            Return Me.calBirthDatePicker
        End Get
        Set(ByVal value As WebControls.Calendar)
            Me.calBirthDatePicker = value
        End Set
    End Property
    Public Property BirthdateSchedule() As WebControls.Calendar Implements IBirthdayClubMemberInfoView.BirthdateSchedule
        Get
            Return Me.calBirthDateSchedule
        End Get
        Set(ByVal value As WebControls.Calendar)
            Me.calBirthDateSchedule = value
        End Set
    End Property

    Public WriteOnly Property ErrorMessage() As String Implements IBirthdayClubMemberInfoView.ErrorMessage
        Set(ByVal value As String)
            lblMessage.Text = value
            lblMessage.CssClass = "error"
        End Set
    End Property

    Public WriteOnly Property InfoMessage() As String Implements IBirthdayClubMemberInfoView.InfoMessage
        Set(ByVal value As String)
            lblMessage.Text = value
            lblMessage.CssClass = "message"
        End Set
    End Property

    Public Sub BindLanguages() Implements IBirthdayClubMemberInfoView.BindLanguages

        Me.AddCulture("en-US")
        Me.AddCulture("es-MX")
        Me.AddCulture("ja-JP")

    End Sub

    Private Sub AddCulture(ByVal name As String)

        Dim ci As New CultureInfo(name)
        Me.ddlLanguages.Items.Add(New ListItem(ci.NativeName, ci.Name))

    End Sub

    Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)

        MyBase.OnInit(e)

        presenter = New BirthdayClubMemberInfoPresenter(Me, Me.Server.MapPath("~/App_Data/"))

        AddHandler ddlLanguages.SelectedIndexChanged, AddressOf presenter.ddlLanguages_SelectedIndexChanged
        AddHandler btnAdd.Click, AddressOf presenter.btnAdd_Click
        AddHandler calBirthDatePicker.SelectionChanged, AddressOf presenter.calBirthDatePicker_SelectionChanged
        AddHandler calBirthDateSchedule.DayRender, AddressOf presenter.calBirthDateSchedule_DayRender

    End Sub

    Protected Overrides Sub InitializeCulture()

        If Not Me.Request.Form("ddlLanguages") Is Nothing Then
            Me.UICulture = Me.Request.Form("ddlLanguages")
            Me.Culture = Me.Request.Form("ddlLanguages")
        End If

        MyBase.InitializeCulture()

    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Me.lblMessage.Text = ""

        If Me.IsPostBack Then Return

        Me.txtMemberName.Focus()

        Me.SetLanguageList()

    End Sub

    Private Sub SetLanguageList()

        Dim currentBrowserCulture As String = Me.Request.UserLanguages(0)

        If currentBrowserCulture <> Me.ddlLanguages.SelectedValue Then
            Me.ddlLanguages.SelectedValue = currentBrowserCulture
        End If

    End Sub

End Class
