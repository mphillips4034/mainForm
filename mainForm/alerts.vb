﻿Public Class alerts

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        alertsPending.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        alertResults.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.Show()
        Me.Hide()

    End Sub
End Class
