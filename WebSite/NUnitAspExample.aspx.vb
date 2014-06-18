Option Strict On

Partial Class NUnitAspExample
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then Return

        Dim name As String = Me.txtName.Text
        Me.pnlEntry.Visible = False

        Me.pnlResults.Visible = True

        Me.lblName.Text = Me.Server.HtmlEncode(name)

    End Sub

End Class
