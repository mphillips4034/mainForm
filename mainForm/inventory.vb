﻿Imports MySql.Data.MySqlClient

Public Class inventory

    Dim conn As New MySqlConnection
    Dim dvdsCommand As New MySqlCommand
    Dim dvdsAdapter As New MySqlDataAdapter
    Dim dvdsData As New DataTable

    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Dim SQL As String

    Public Sub connect()
        Dim DatabaseName As String = "vbtest"
        Dim server As String = "localhost"
        Dim userName As String = "root"
        Dim password As String = "mypassword2"
        If Not conn Is Nothing Then conn.Close()
        conn.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DatabaseName)
        Try
            conn.Open()

            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If titlechk.Checked Then
            SQL = "SELECT * FROM DVDS inner JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC inner JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC AND DVDS.title = '" & TextBox1.Text & "'"
        ElseIf genreChk.Checked Then
            SQL = "SELECT * FROM DVDS inner JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC inner JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC AND DVDS.genre = '" & TextBox1.Text & "'"

        ElseIf languagechk.Checked Then
            SQL = "SELECT * FROM DVDS inner JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC inner JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC AND DVDS.language = '" & TextBox1.Text & "'"

        ElseIf directorChk.Checked Then
            SQL = "SELECT * FROM DVDS inner JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC inner JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC AND DVDS.directors = '" & TextBox1.Text & "'"


        ElseIf actorChk.Checked Then
            SQL = "SELECT * FROM DVDS inner JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC inner JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC AND DVDS.actors = '" & TextBox1.Text & "'"
        Else
            MessageBox.Show("Please enter a value")

        End If

        connect()


        DataGridView1.DataSource = dvdsData

        Try

            conn.Open()

            dvdsCommand.Connection = conn
            dvdsCommand.CommandText = SQL
            dvdsAdapter.SelectCommand = dvdsCommand
            dvdsAdapter.Fill(dvdsData)

            DataGridView1.DataSource = dvdsData


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        invInfo.Show()
        Me.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()

        SQL = "SELECT * FROM DVDS LEFT JOIN CATEGORIES ON DVDS.UPC = CATEGORIES.UPC Left JOIN DVD_INFO ON DVDS.UPC = DVD_INFO.UPC"

       
        Try

            conn.Open()

            dvdsCommand.Connection = conn
            dvdsCommand.CommandText = SQL
            dvdsAdapter.SelectCommand = dvdsCommand
            dvdsAdapter.Fill(dvdsData)

            DataGridView1.DataSource = dvdsData


        Catch ex As Exception
            MessageBox.Show("Cannot connect to database: ")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim title As String
        Dim releaseDate As Date
        Dim genre As String
        Dim ageRating As String
        Dim language As String
        Dim actors As String
        Dim director As String
        Dim rentalStatus As String
        Dim UPC As String
        Dim rentCount As Integer
        Dim onHand As Integer


        UPC = Me.DataGridView1.Item(0, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        title = Me.DataGridView1.Item(1, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        rentalStatus = Me.DataGridView1.Item(2, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        rentCount = Me.DataGridView1.Item(3, Me.DataGridView1.CurrentCell.RowIndex).Value
        onHand = Me.DataGridView1.Item(4, Me.DataGridView1.CurrentCell.RowIndex).Value
        genre = Me.DataGridView1.Item(6, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        language = Me.DataGridView1.Item(7, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        releaseDate = Me.DataGridView1.Item(8, Me.DataGridView1.CurrentCell.RowIndex).Value
        ageRating = Me.DataGridView1.Item(10, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        actors = Me.DataGridView1.Item(11, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString
        director = Me.DataGridView1.Item(12, Me.DataGridView1.CurrentCell.RowIndex).Value.ToString

        Dim d1 As DVD = New DVD(UPC, title, rentalStatus, genre, language, ageRating, releaseDate, director, actors, rentCount, onHand)

        user.dvd = d1

        invBreakDown.Show()
        Me.Close()

         

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        finReport.Show()

        Me.Hide()

    End Sub
End Class
