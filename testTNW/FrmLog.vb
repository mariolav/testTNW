Imports System.IO

Public Class FrmLog
    Private Sub FrmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lsfile As String = PsExeName & "_log.txt"

        If File.Exists(Application.StartupPath & "\Logs\" & lsfile) Then
            TxtErrorLog.Text = File.ReadAllText(Application.StartupPath & "\Logs\" & lsfile)
        End If
    End Sub

    Private Sub BtnEmailLOg_Click(sender As Object, e As EventArgs) Handles BtnEmailLOg.Click
        If TxtErrorLog.Text.Trim = "" Then
            MsgBox("Please select a log first.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, Application.ProductName)
        Else
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim lsfile As String = PsExeName & "_log.txt"

            If File.Exists(Application.StartupPath & "\Logs\" & lsfile) Then

                BtnEmailLOg.Enabled = False
                MailFile(Application.StartupPath & "\Logs\" & lsfile, "Manually sent log. Please check attached file.")
                BtnEmailLOg.Enabled = True
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub BtnClearLog_Click(sender As Object, e As EventArgs) Handles BtnClearLog.Click
        If MsgBox("Delete log file?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, psTitle) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim lsfile As String = PsExeName & "_log.txt"

        If File.Exists(Application.StartupPath & "\Logs\" & lsfile) Then
            File.Delete(Application.StartupPath & "\Logs\" & lsfile)
            TxtErrorLog.Text = ""
        End If

    End Sub
End Class