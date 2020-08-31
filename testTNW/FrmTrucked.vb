Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmTrucked
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Dispose()

    End Sub

    Private Sub FrmTrucked_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PsTable = "TRUCKED"
        PbRecordsProcessed = False
    End Sub

    Private Sub btnSelectXLSFile_Click(sender As Object, e As EventArgs) Handles btnSelectXLSFile.Click
        Using fbd As New OpenFileDialog
            With fbd
                .Filter = "Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*"

                .InitialDirectory = PsFolder
                '.DefaultExt = "xlsx"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    TxtFileTrucked.Text = .FileName
                End If
            End With
        End Using

    End Sub
    Private Sub ButtonsOnOff(ByVal t As Boolean)
        btnSelectXLSFile.Enabled = t
        BtnImport.Enabled = t
        BtnCancel.Enabled = t
        BtnViewBad.Enabled = t
        CheckBoxIncludeInterest.Enabled = t
        CheckBoxMAF.Enabled = t
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim LsCheck As String = FnCheckAll("TRUCKED")
        If LsCheck <> "" Then
            MsgBox(LsCheck & "Please fix!!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
            ' Exit Sub
        End If
        If TxtFileTrucked.Text = "" Then
            MsgBox("Please select file first", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
            Exit Sub
        End If
        pbIncludeMAF = CheckBoxMAF.Checked
        pbIncludeInterest = CheckBoxIncludeInterest.Checked
        psErrors = ""
        pbErrorFound = False

        LblLog.Text = ""
        ButtonsOnOff(False)
        Dim lsInsert As String = ""
        Dim LastRow As Integer = 0
        Try
            Dim APP As New Microsoft.Office.Interop.Excel.Application
            Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim workbook As Microsoft.Office.Interop.Excel.Workbook
            workbook = APP.Workbooks.Open(TxtFileTrucked.Text)
            worksheet = workbook.Worksheets("Sheet1")
            Dim LsAvoidText As String = "ACCOUNTTOTALCOMMERCIAL CUSTOMERS"
            Dim myDate As Date
            Dim lsT As String = ""
            Dim lsTemp As String = "('','{0}',{1},{2},{3},'{4}')"
            Dim lMonth As Byte = 0
            Dim lYear As Integer = 0
            ' ([IDCUST]
            ',[OLDACC]
            ',[CONSUMPTION]
            ',[MONTH]
            ',[YEAR]
            UpdateLableImportWater("Reading records, please wait...")
            With worksheet
                myDate = .Cells(1, 2).Value
                If Not IsDate(.Cells(1, 2).Value) Then

                    MsgBox(String.Format("{0} is not a valid date!", .Cells(1, 2).Value))
                Else
                    lMonth = Month(myDate)
                    lYear = Year(myDate)
                    LastRow = worksheet.Cells(worksheet.Rows.Count, "C").End(Excel.XlDirection.xlUp).Row
                    For x As Integer = 2 To LastRow
                        If Not IsNothing(.Cells(x, 3).value) Then

                            If (LsAvoidText.Contains(.Cells(x, 3).value.ToString.ToUpper.Trim) = 0) And ((.Cells(x, 3).value.ToString.Trim & "") <> "") Then
                                If lsInsert <> "" Then
                                    lsInsert &= ","
                                End If
                                lsT = String.Format(lsTemp, .Cells(x, 3).Value, .Cells(x, 4).Value + 0, lMonth.ToString, lYear.ToString, Replace(.Cells(x, 1).Value, "'", "''"))
                                lsInsert &= lsT
                                LblLog.Text = String.Format("Account: {0} Amount: {1}", .Cells(x, 3).Value, .Cells(x, 4).Value + 0)
                            End If
                        End If
                        'End If
                    Next
                End If
            End With
            workbook.Close()
            APP.Quit()
            Try
                worksheet = Nothing
                workbook = Nothing
                APP = Nothing
            Catch ex2 As Exception

            End Try

        Catch ex As Exception
            MyErrorMsg(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try
        If lsInsert <> "" Then
            UpdateLableImportWater("Saving records to tmp table, please wait...")
            sqlExe(String.Format(My.Resources.InsertIntoTrucked, lsInsert))
            If pbErrorFound Then
                sqlExe("DELETE from [MNP].[dbo].[TRUCKED]")
            End If
            If pbIncludeInterest = False Then
                sqlExe("UPDATE [MNP].[dbo].[TRUCKED] set [INTEREST]='N'")
            End If

            If fnCheckRecordExist(String.Format("Select * from [MNP].[dbo].{0} where [COMMENT]<>''", PsTable)) Then
                PbRecordsProcessed = True

                UpdateLableImportWater("")
                MsgBox("Bad records found." & vbCrLf & "Please review before creating Invoices", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
                FrmBadRecords.Show()
            Else
                UpdateLableImportWater("Getting fields, please wait...")
                ' ***********************************************************
                ' August 21, 2020
                ' Change to read list of trucked water
                ' there could be more than one delivery to same customer
                ' ***********************************************************
                GetTrucked(My.Resources.GetTrucked)
                UpdateLableImportWater("Creating Trucked Invoices, please wait...")
                If Not IsNothing(AllTrucked) Then
                    If AllTrucked.Length > 0 Then
                        'MsgBox(AllTrucked.Length.ToString)
                        If Command.ToString.ToUpper <> "DEBUG" Then
                            CreateInvoiceTrucked(Me.PBImportTrucked)
                        End If
                        If psErrors <> "" Then
                            MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                        End If
                    End If
                End If
            End If
            If psErrors <> "" Then
                MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
            End If
            UpdateLableImportWater("")
        End If
        If pbErrorFound Then
            MsgBox("An error ocurred. Please check log in Setup/log")
        End If

        ButtonsOnOff(True)
    End Sub
    Public Sub UpdateLableImportWater(ByVal sText As String)
        LblLog.Text = sText
        LblLog.Refresh()
    End Sub

    Private Sub BtnViewBad_Click(sender As Object, e As EventArgs) Handles BtnViewBad.Click
        FrmBadRecords.ShowDialog()
    End Sub
End Class