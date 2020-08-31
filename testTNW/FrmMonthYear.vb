Public Class FrmMonthYear
    Private Sub FrmMonthYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnMonth = CInt(getValueFromSQL("select top 1 [MONTH] from [MNP].[dbo].[METERED]"))
        PnYear = CInt(getValueFromSQL("select top 1 [YEAR] from [MNP].[dbo].[METERED]"))
        LblNotice.Text = "PLEASE NOTE: Normally, you will be creating invoices for the month before." & vbCrLf & "  Only change the dates if it is a special Invoice creation."
        With CmbMonth
            .Items.Clear()
            For x As Integer = 1 To 12
                .Items.Add(x.ToString)
            Next
            .SelectedIndex = .Items.IndexOf(PnMonth.ToString)
        End With
        With CmbYear
            .Items.Clear()
            For x As Integer = Now.Year - 1 To Now.Year
                .Items.Add(x.ToString)
            Next
            .SelectedIndex = .Items.IndexOf(PnYear.ToString)
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        PnMonth = 0
        PnYear = 0
        Me.Dispose()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        If (CmbMonth.Text.ToString.Trim <> PnMonth.ToString.Trim) Or (CmbYear.Text.ToString.Trim <> PnYear.ToString.Trim) Then
            PnMonth = CmbMonth.Text.ToString.Trim
            PnYear = CmbYear.Text.ToString.Trim
            sqlExe(String.Format("Update [MNP].[dbo].[METERED] set [MONTH]={0}, [YEAR]={1};", PnMonth.ToString.Trim, PnYear.ToString.Trim))
        End If
        Me.Dispose()
    End Sub
End Class