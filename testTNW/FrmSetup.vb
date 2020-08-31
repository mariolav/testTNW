Public Class FrmSetup
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If BtnSave.Enabled Then
            If MsgBox("You made changes to " & Me.Text & ". If you proceed without saving, changes will be lost." & vbCrLf & " Proceed?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, psTitle) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.Dispose()

    End Sub

    Private Sub txtUserid_TextChanged(sender As Object, e As EventArgs) Handles txtUserid.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtDbName_TextChanged(sender As Object, e As EventArgs) Handles txtDbName.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtDataSource_TextChanged(sender As Object, e As EventArgs) Handles txtDataSource.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSageUserid_TextChanged(sender As Object, e As EventArgs) Handles txtSageUserid.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSagePassword_TextChanged(sender As Object, e As EventArgs) Handles txtSagePassword.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSageCompany_TextChanged(sender As Object, e As EventArgs) Handles txtSageCompany.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSMTPFrom_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPFrom.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSMTPPassword_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPPassword.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSMTPTo_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPTo.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSMTPServer_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPServer.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub txtSMTPPort_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPPort.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub CheckBoxEnableSSL_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEnableSSL.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub FrmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetIds()
        txtUserid.Text = psDBID
        txtPassword.Text = psDBPwd
        txtDbName.Text = psDBName
        txtDataSource.Text = psDatabase
        txtSageUserid.Text = psSageUserName
        txtSagePassword.Text = psSagePassword
        txtSageCompany.Text = psSageCompany
        TxtFolder.Text = PsFolder


        TxtMailUserID.Text = PsMailUserid
        txtSMTPFrom.Text = psMailFrom
        txtSMTPPassword.Text = psMailPassword
        txtSMTPTo.Text = psMailTo
        txtSMTPServer.Text = psMailSMTPHost
        txtSMTPPort.Text = pnMailPort
        'TxtPenaltyPercent.Text = PsPenaltyPercent
        CheckBoxEnableSSL.Checked = pbMailEnableSSL
        CheckBoxIncludeZeroConsumption.Checked = PbIncludeZeroConsumption
        BtnSave.Enabled = False
    End Sub

    Private Sub FrmSetup_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        BtnSave.Enabled = False
    End Sub
    Private Sub WriteSettings()
        Settings.Item("SQLID") = txtUserid.Text
        Settings.Item("SQLPW") = fnEncrypt(txtPassword.Text)
        Settings.Item("DBName") = txtDbName.Text
        Settings.Item("DataSource") = txtDataSource.Text
        Settings.Item("SageID") = txtSageUserid.Text
        Settings.Item("SagePW") = fnEncrypt(txtSagePassword.Text)
        Settings.Item("SageCompany") = txtSageCompany.Text
        Settings.Item("FileFolder") = TxtFolder.Text

        Settings.Item("SMTPFrom") = txtSMTPFrom.Text
        Settings.Item("SMTPPassword") = fnEncrypt(txtSMTPPassword.Text)
        Settings.Item("SMTPTo") = IIf(txtSMTPTo.Text <> "", Replace(txtSMTPTo.Text, ";", ","), "")
        Settings.Item("SMTPServer") = txtSMTPServer.Text
        Settings.Item("SMTPPort") = txtSMTPPort.Text
        Settings.Item("SMTPEnableSSL") = CheckBoxEnableSSL.Checked
        Settings.Item("SMTPUserid") = TxtMailUserID.Text
        Settings.Item("IncludeCero") = CheckBoxIncludeZeroConsumption.Checked
        'Settings.Item("penaltypercent") = TxtPenaltyPercent.Text
        Settings.WriteSettings()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        WriteSettings()

        GetIds()
        BtnSave.Enabled = False
    End Sub

    Private Sub TxtFolder_TextChanged(sender As Object, e As EventArgs) Handles TxtFolder.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub BtnFolder_Click(sender As Object, e As EventArgs) Handles BtnFolder.Click

        Using fbd As New FolderBrowserDialog
            fbd.RootFolder = Environment.SpecialFolder.MyComputer
            fbd.SelectedPath = PsFolder
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtFolder.Text = fbd.SelectedPath
            End If
        End Using
    End Sub

    Private Sub TxtMailUserID_TextChanged(sender As Object, e As EventArgs) Handles TxtMailUserID.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub BtnViewLog_Click(sender As Object, e As EventArgs) Handles BtnViewLog.Click
        FrmLog.ShowDialog()
    End Sub

    Private Sub CheckBoxIncludeCeroConsumption_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeZeroConsumption.CheckedChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtPenaltyPercentage_TextChanged(sender As Object, e As EventArgs)
        BtnSave.Enabled = True
    End Sub

    Private Sub TxtPenaltyPercent_TextChanged(sender As Object, e As EventArgs)
        BtnSave.Enabled = True
    End Sub

End Class