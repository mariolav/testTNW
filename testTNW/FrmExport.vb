Public Class FrmExport
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim LsFound As String = fnGetSqlRecords(My.Resources.CheckMetersRecords)
        If LsFound.Trim <> "" Then
            If MsgBox("Found Customers with missing Optional fields or Optional fields 'data'" & vbCrLf & LsFound & vbCrLf & "Continue Export to Handheld file without bad customers?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then

                Exit Sub
            End If
        End If
        psErrors = ""
        pbErrorFound = False
        Dim LsTemp As String = FnCreateSelected()
        If LsTemp <> "" Then
            sqlExe(String.Format(My.Resources.InsertMeteredSelected, LsTemp))
            If pbErrorFound Then
                MsgBox("An error ocurred inserting values. Please check log in Setup/log")
            Else
                ExportFile()
            End If
        Else
            MsgBox("Can't create Export file. Please select Customers", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, psTitle)
        End If

    End Sub
    Private Function FnCreateSelected() As String
        Dim LsTemp As String = ""
        'DataGridViewExport.Refresh()
        For x = 0 To DataGridViewExport.Rows.Count - 1
            If DataGridViewExport(0, x).Value.ToString.Trim = "-1" Then
                If LsTemp <> "" Then
                    LsTemp &= ","
                End If
                LsTemp &= "('" & DataGridViewExport(1, x).Value.ToString & "')"
            End If
        Next
        Return LsTemp
    End Function
    Public Sub ExportFile()
        Dim LsSql As String = ""
        LsSql = My.Resources.ExportSql
        pbErrorFound = False
        getExportSQL(LsSql)
        If Not pbErrorFound Then
            MsgBox("Export complete", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, psTitle)
        Else
            MsgBox("Export FAILED" & vbCrLf & psErrors, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, psTitle)
        End If
    End Sub

    Private Sub FrmExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList("", "-1")
        BtnSearch.Visible = False
    End Sub
    Private Sub RefreshList(ByVal search As String, ByVal allornone As String)
        Dim LsSql As String = String.Format(My.Resources.GetExportRecordToSelect, allornone, "%" & search)
        DataGridViewExport.AutoGenerateColumns = False
        populateGrid(LsSql, DataGridViewExport, Me, BindingSource1)
        Dim lastColIndex = DataGridViewExport.Columns.Count - 1
        For x As Integer = 1 To lastColIndex
            DataGridViewExport.Columns.Item(x).ReadOnly = True
        Next

    End Sub
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        If BtnSelect.Text = "Unselect All" Then
            BtnSelect.Text = "Select All"
            RefreshList(TxtSearch.Text, "0")
        Else
            BtnSelect.Text = "Unselect All"
            RefreshList(TxtSearch.Text, "-1")
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        RefreshList(TxtSearch.Text, IIf(BtnSelect.Text = "Select All", "0", "-1"))
        BtnSearch.Visible = False
    End Sub

    Private Sub DataGridViewExport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewExport.CellContentClick

    End Sub

    Private Sub DataGridViewExport_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridViewExport.CurrentCellDirtyStateChanged
        DataGridViewExport.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub


    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        BtnSearch.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        csvExport(DataGridViewExport, "Customer to be Exported to Handheld")
    End Sub
End Class