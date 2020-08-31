Public Class FrmBadRecords
    Private Sub FrmWaterBad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text &= String.Format("  ({0})", PsTable)
        Dim LsSql As String = String.Format("Select * from [MNP].[dbo].{0} where [COMMENT]<>'' order by [IDCUST],[OLDACC]", PsTable)
        populateGrid(LsSql, DataGridViewTruckedBad, Me, BindingSource1)
        Dim lastColIndex = DataGridViewTruckedBad.Columns.Count '- 1
        Dim lastCol = DataGridViewTruckedBad.Columns.Item(lastColIndex - 1)
        lastCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        BtnCreateInvoices.Enabled = PbRecordsProcessed
        If Command.ToString <> "" Then
            BtnCreateInvoices.Enabled = True
        End If
        If PbRecordsProcessed Then
            LblDisplay.Text = "PLEASE, check bad records in the 'Excluded list'. Exit and fix and Import again. Only proceed to create invoices if you are OK with excluded records"
        Else
            LblDisplay.Text = "This is only an FYI view. To have the 'Create Invoices' option available, Import again from Import option."
        End If

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        'With DataGridViewTruckedBad
        csvExport(DataGridViewTruckedBad, "BadRecords")
        'End With

    End Sub
    Private Sub ButtonsOnOff(ByVal t As Boolean)
        BtnCancel.Enabled = t
        BtnCreateInvoices.Enabled = t
        BtnExport.Enabled = t
    End Sub
    Private Sub BtnCreateInvoices_Click(sender As Object, e As EventArgs) Handles BtnCreateInvoices.Click
        If MsgBox("Are you sure you want to create invoices? The displayed records will not be used." & vbCrLf & " Proceed?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, psTitle) = MsgBoxResult.Yes Then
            ButtonsOnOff(False)
            psErrors = ""
            pbErrorFound = False

            Dim LsMsg As String = ""
            Select Case PsTable
                Case "METERED"
                    PnNumberOfInvoices = 0
                    GetMetered(My.Resources.GetMetered)
                    If psErrors <> "" Then
                        MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                    Else
                        If Not IsNothing(AllMetered) Then
                            If AllMetered.Length > 0 Then
                                'MsgBox(AllMetered.Length.ToString)
                                If Command.ToString.ToUpper <> "DEBUG" Then
                                    FrmMonthYear.ShowDialog()
                                    If PnYear + PnMonth <> 0 Then
                                        CreateInvoiceMetered(Me.PBBad)
                                        LsMsg = String.Format("Created {0} {1} Water Invoices.", PnNumberOfInvoices, PsTable)
                                    Else
                                        LsMsg = "You cancelled Month/Year confirmation"
                                    End If
                                End If
                                If psErrors <> "" Then
                                    MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                                End If
                            End If
                        Else
                            MsgBox("something bad happened")
                        End If
                    End If
                Case "TRUCKED"
                    PnNumberOfInvoices = 0
                    GetTrucked(My.Resources.GetTrucked)
                    If psErrors <> "" Then
                        MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                    Else
                        If Not IsNothing(AllTrucked) Then
                            If AllTrucked.Length > 0 Then
                                If Command.ToString.ToUpper <> "DEBUG" Then
                                    CreateInvoiceTrucked(Me.PBBad)
                                End If
                                If psErrors <> "" Then
                                    MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                                End If
                            End If
                        End If
                        LsMsg = String.Format("Created {0} {1} Water Invoices.", PnNumberOfInvoices, PsTable)
                    End If
            End Select
            If LsMsg <> "" Then
                MsgBox(LsMsg, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, psTitle)
            End If
        End If
        ButtonsOnOff(True)
        BtnCreateInvoices.Enabled = False
    End Sub

    Private Sub LblDisplay_Click(sender As Object, e As EventArgs) Handles LblDisplay.Click

    End Sub
End Class