Public Class FrmPenaltyOthers
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim LsCheck As String = getValueFromSQL(My.Resources.FindMissingOptFields)
        If LsCheck <> "" Then
            MsgBox(LsCheck & vbCrLf & "Please fix!!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
            Exit Sub
        End If

        FrmMonthYear.ShowDialog()

        If PnYear + PnMonth <> 0 Then
            GetOthers(String.Format(My.Resources.GetOtherPenalty, PnMonth.ToString.Trim, PnYear.ToString.Trim))
            If psErrors <> "" Then
                MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
            Else
                If Not IsNothing(AllOthers) Then
                    If AllOthers.Length > 0 Then
                        If Command.ToString.ToUpper <> "DEBUG" Then
                            PnNumberOfInvoices = 0
                            UpdateLableImportOthers("Creating Late Payment Invoices, please wait...")
                            CreateInvoiceOthers(Me.PBImportMeter)
                            MsgBox(String.Format("Created {0} Late Payment Invoices.", PnNumberOfInvoices), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, psTitle)
                            PnNumberOfInvoices = 0
                            UpdateLableImportOthers("")
                        End If
                        If psErrors <> "" Then
                            MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                        End If
                    End If
                End If
            End If
            UpdateLableImportOthers("")
        Else
            MsgBox("You cancelled Month/Year confirmation", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
        End If
    End Sub

    Private Sub FrmPenaltyOthers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub UpdateLableImportOthers(ByVal sText As String)
        LblLog.Text = sText
        LblLog.Refresh()
    End Sub
End Class