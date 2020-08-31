Public Class FrmImport
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    'Private Sub BtnTest_Click(sender As Object, e As EventArgs)
    '    ReadImport()
    'End Sub
    'Sub ReadImport()
    '    If Not System.IO.File.Exists(PsFolder & "\Waterimport.txt") Then
    '        MsgBox(String.Format("File: {0} does not exist.", PsFolder & "\Waterimport.txt"), MsgBoxStyle.OkOnly, psTitle)
    '        Exit Sub
    '    End If
    '    Dim lsT As String = ""
    '    Dim lsMinDate As String = "123130"
    '    Dim lsMaxDate As String = "010119"
    '    Dim Lx As Integer = 0
    '    Dim lsTemp As String = "({0}-{1}-{2}-{3}-{4}-{5}-{6})"
    '    Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(PsFolder & "\Waterimport.txt")
    '        Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
    '        Reader.SetFieldWidths(2, 12, 4, 23, 13, 14, 10, 57, 6, 6, 15, 10, 270, 24, 1, 40, -1)
    '        ' 2,12,4,23,13,14,10,57,6,6,320,40,6
    '        ' We will use fields 0,2,4,6,8,9,11
    '        Dim cRow As String()
    '        While Not Reader.EndOfData
    '            Try
    '                cRow = Reader.ReadFields()
    '                If cRow(8) < lsMinDate And cRow(8) <> "" Then
    '                    lsMinDate = cRow(8)
    '                End If
    '                If cRow(8) > lsMaxDate Then
    '                    lsMaxDate = cRow(8)
    '                End If
    '                If IsNumeric(cRow(6)) And IsNumeric(cRow(11)) Then
    '                    lsT = String.Format(lsTemp, cRow(13), cRow(15), cRow(4), CLng(cRow(6)).ToString, CLng(cRow(11)).ToString, cRow(8), cRow(9))
    '                    Lx += 1
    '                End If
    '                UpdateLableImportWater(lsT)
    '            Catch ex As Microsoft.VisualBasic.
    '                    FileIO.MalformedLineException
    '                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
    '            End Try
    '        End While
    '    End Using
    '    MsgBox(String.Format("Lines: {0}  -  Min. Date: {1}  -  Max. Date: {2}", Lx, lsMinDate, lsMaxDate), MsgBoxStyle.OkOnly, psTitle)
    '    UpdateLableImportWater("")
    'End Sub
    Private Sub ButtonsOnOff(ByVal t As Boolean)
        BtnImport.Enabled = t
        '  BtnTest.Enabled = t
        BtnCancel.Enabled = t
        BtnViewErrors.Enabled = t
        CheckBoxIncludeInterest.Enabled = t
        CheckBoxMAF.Enabled = t

    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        If Not System.IO.File.Exists(PsFolder & "\Waterimport.txt") Then
            MsgBox(String.Format("File: {0} does not exist.", PsFolder & "\Waterimport.txt"), MsgBoxStyle.OkOnly, psTitle)
            Exit Sub
        End If
        pbIncludeMAF = CheckBoxMAF.Checked
        pbIncludeInterest = CheckBoxIncludeInterest.Checked
        ButtonsOnOff(False)
        psErrors = ""
        pbErrorFound = False
        Dim lsT As String = ""
        Dim lsMinDate As String = "123130"
        Dim lsMaxDate As String = "010119"
        Dim Lx As Integer = 0
        Dim lsInsert As String = ""
        Dim lsTemp As String = "('{0}','{1}','{2}',{3},{4},'{5}','{6}')"
        Using Reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(PsFolder & "\Waterimport.txt")
            Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            Reader.SetFieldWidths(2, 12, 4, 23, 13, 14, 10, 57, 6, 6, 15, 10, 270, 24, 1, 40, -1)
            ' 2,12,4,23,13,14,10,57,6,6,320,40,6
            ' We will use fields 0,2,4,6,8,9,11
            UpdateLableImportWater("Reading records, please wait...")
            Dim cRow As String()
            While Not Reader.EndOfData
                Try
                    cRow = Reader.ReadFields()
                    If IsNumeric(cRow(6)) And IsNumeric(cRow(11)) Then
                        If lsInsert <> "" Then
                            lsInsert &= ","
                        End If
                        lsT = String.Format(lsTemp, cRow(13) & "", cRow(15), cRow(4), CLng(cRow(6)).ToString, CLng(cRow(11)).ToString, cRow(8), cRow(9))
                        lsInsert &= lsT
                        Lx += 1
                    End If
                    '                    MsgBox(lsT)
                Catch ex As Microsoft.VisualBasic.
                        FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        If lsInsert <> "" Then
            UpdateLableImportWater("Saving records to tmp table, please wait...")
            sqlExe(String.Format(My.Resources.InsertIntoMetered, lsInsert))
            If pbErrorFound Then
                sqlExe("DELETE from [MNP].[dbo].[METERED]")
            End If
            Dim LsCheck As String = FnCheckAll("METERED")
            If LsCheck <> "" Then
                MsgBox(LsCheck & "Please fix!!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
                Exit Sub
            End If
            If pbIncludeInterest = False Then
                sqlExe("UPDATE [MNP].[dbo].[METERED] set [INTEREST]='N'")
            End If

            If fnCheckRecordExist(String.Format("Select * from [MNP].[dbo].{0} where [COMMENT]<>''", PsTable)) Then
                PbRecordsProcessed = True
                UpdateLableImportWater("")
                MsgBox("Bad records found." & vbCrLf & "Please review before creating Invoices", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
                FrmBadRecords.Show()
            Else
                UpdateLableImportWater("Creating Metered Invoices, please wait...")
                GetMetered(My.Resources.GetMetered)
                If Not IsNothing(AllMetered) Then
                    If AllMetered.Length > 0 Then
                        'MsgBox(AllMetered.Length.ToString)
                        If Command.ToString.ToUpper <> "DEBUG" Then
                            FrmMonthYear.ShowDialog()
                            If PnYear + PnMonth <> 0 Then
                                CreateInvoiceMetered(Me.PBImportMeter)
                            Else
                                MsgBox("You cancelled Month/Year confirmation", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
                            End If
                        End If
                        If psErrors <> "" Then
                            MsgBox(psErrors, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, psTitle)
                        End If
                    End If
                End If
                UpdateLableImportWater("")
            End If
        End If
        If pbErrorFound Then
            MsgBox("An error ocurred. Please check log in Setup/log")
        End If
        ButtonsOnOff(True)
    End Sub

    Private Sub FrmImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PsTable = "METERED"
        PbRecordsProcessed = False
    End Sub
    Public Sub UpdateLableImportWater(ByVal sText As String)
        LblLog.Text = sText
        LblLog.Refresh()
    End Sub

    Private Sub BtnViewErrors_Click(sender As Object, e As EventArgs) Handles BtnViewErrors.Click
        psBadSql = "Select * from [MNP].[dbo].[METERED] where [COMMENT]<>''"
        FrmBadRecords.ShowDialog()
    End Sub


End Class