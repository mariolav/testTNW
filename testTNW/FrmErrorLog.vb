Imports System.IO

Public Class FrmErrorLog
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub FrmErrorLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lsfile As String = psExeName & "_log.txt"

        If File.Exists(Application.StartupPath & "\" & lsfile) Then
            TxtErrorLog.Text = File.ReadAllText(Application.StartupPath & "\" & lsfile)
        End If
    End Sub

    Private Sub BtnEmailLOg_Click(sender As Object, e As EventArgs) Handles BtnEmailLOg.Click
        If TxtErrorLog.Text.Trim = "" Then
            MsgBox("Please select a log first.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, Application.ProductName)
        Else
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim lsfile As String = psExeName & "_log.txt"

            If File.Exists(Application.StartupPath & "\" & lsfile) Then

                BtnEmailLOg.Enabled = False
                MailFile(Application.StartupPath & "\" & lsfile, "Manually sent log. Please check attached file.")
                BtnEmailLOg.Enabled = True
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub
End Class