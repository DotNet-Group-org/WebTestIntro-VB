Option Strict On

Imports System.Data

Namespace Business

    Public Class BirthdayClubMemberInfo

        Private mMemberID As Int32
        Private mMemberName As String
        Private mBirthdate As DateTime

        Private mBirthdayClubMemberTable As DataTable

        Public Property MemberID() As Int32
            Get
                Return Me.mMemberID
            End Get
            Set(ByVal value As Int32)
                Me.mMemberID = value
            End Set
        End Property
        Public Property MemberName() As String
            Get
                Return Me.mMemberName
            End Get
            Set(ByVal value As String)
                Me.mMemberName = value
            End Set
        End Property
        Public Property Birthdate() As DateTime
            Get
                Return Me.mBirthdate
            End Get
            Set(ByVal value As DateTime)
                Me.mBirthdate = value
            End Set
        End Property

        Private saveFileName As String

        Public Sub New()

            Me.New("C:\data\programs\examples\WebTestingIntro\SourceCode\WebTestIntro\WebSite\App_Data\")

        End Sub

        Public Sub New(ByVal dataPath As String)

            Me.GetData(dataPath)

        End Sub

        Private Sub GetData(ByVal dataPath As String)

            ' why can't data table retrieve any records??! check p246 - maybe something's missing from my xml . . . 
            Dim BirthdayClubMemberTable As New DataSet("BirthdayClubMembers")
            Me.saveFileName = dataPath + "BirthdayClubMembers.xml"
            BirthdayClubMemberTable.ReadXml(Me.saveFileName)
            Me.mBirthdayClubMemberTable = BirthdayClubMemberTable.Tables(0)

        End Sub

        Public Function List() As DataTable

            Return Me.mBirthdayClubMemberTable

        End Function

        Public Sub Add()

            Dim newRow As DataRow = Me.mBirthdayClubMemberTable.NewRow
            newRow("MemberID") = Me.GetMaxMemberID + 1
            newRow("MemberName") = Me.mMemberName
            newRow("Birthdate") = Me.mBirthdate
            Me.mBirthdayClubMemberTable.Rows.Add(newRow)

            Me.mBirthdayClubMemberTable.WriteXml(Me.saveFileName, XmlWriteMode.WriteSchema)

        End Sub

        Public Function GetMaxMemberID() As Int32

            Dim maxMemberRow As DataRow() = Me.mBirthdayClubMemberTable.Select("", "MemberID DESC")
            If maxMemberRow IsNot Nothing AndAlso maxMemberRow.Length > 0 Then
                Return Convert.ToInt32(maxMemberRow(0)("MemberID"))
            End If

            Return 0

        End Function

        Public Sub Delete()

            Dim deleteRow As DataRow() = Me.mBirthdayClubMemberTable.Select("MemberID = " + Me.mMemberID.ToString)
            If deleteRow IsNot Nothing AndAlso deleteRow.Length > 0 Then
                deleteRow(0).Delete()
                Me.mBirthdayClubMemberTable.AcceptChanges()
                Me.mBirthdayClubMemberTable.WriteXml(Me.saveFileName, XmlWriteMode.WriteSchema)
            End If

        End Sub

    End Class

End Namespace
