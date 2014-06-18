Option Strict On

Imports NUnit.Framework

Imports App.Business

<TestFixture()> Public Class BirthdayClubMemberInfoFixture

    Private mBirthdayClubMemberInfo As BirthdayClubMemberInfo

    <SetUp()> Protected Overridable Sub SetUp()

        Me.mBirthdayClubMemberInfo = New BirthdayClubMemberInfo("data\")

    End Sub

    <Test()> Public Sub List()

        Me.GetBirthdayClubMemberList()

    End Sub

    Private Function GetBirthdayClubMemberList() As DataTable

        Dim BirthdayClubMemberTable As DataTable = Me.mBirthdayClubMemberInfo.List
        Assert.IsNotNull(BirthdayClubMemberTable, "BirthdayClubMember Table NULL")
        Assert.Greater(BirthdayClubMemberTable.Rows.Count, 0)
        Return BirthdayClubMemberTable

    End Function

    <Test()> Public Sub Add()

        Dim BirthdayClubMemberTable As DataTable = Me.GetBirthdayClubMemberList()
        Dim originalRowCount As Int32 = BirthdayClubMemberTable.Rows.Count

        Me.AddTestBirthdayClubMember()

        Dim newRowCount As Int32 = Me.GetBirthdayClubMemberList.Rows.Count
        Assert.AreEqual(originalRowCount + 1, newRowCount, "Wrong Row count after Add")

        Me.DeleteNewestBirthdayClubMember()

    End Sub

    Private Sub AddTestBirthdayClubMember()

        Me.mBirthdayClubMemberInfo.MemberName = "Test"
        Me.mBirthdayClubMemberInfo.Birthdate = Today
        Me.mBirthdayClubMemberInfo.Add()

    End Sub

    <Test()> Public Sub Delete()

        Me.AddTestBirthdayClubMember()

        Dim birthdayClubMemberTable As DataTable = Me.GetBirthdayClubMemberList()
        Dim originalRowCount As Int32 = BirthdayClubMemberTable.Rows.Count

        Me.DeleteNewestBirthdayClubMember()

        Dim newRowCount As Int32 = Me.GetBirthdayClubMemberList.Rows.Count
        Assert.AreEqual(originalRowCount - 1, newRowCount, "Wrong Row count after Delete")

    End Sub

    Private Sub DeleteNewestBirthdayClubMember()

        Dim maxMemberID As Int32 = Me.mBirthdayClubMemberInfo.GetMaxMemberID
        Me.mBirthdayClubMemberInfo.MemberID = maxMemberID
        Me.mBirthdayClubMemberInfo.Delete()

    End Sub

End Class
