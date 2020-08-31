<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CheckBoxEnableSSL = New System.Windows.Forms.CheckBox()
        Me.txtSMTPPort = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSMTPPassword = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSMTPServer = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSMTPTo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSMTPFrom = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtMailUserID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDataSource = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDbName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSageCompany = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSagePassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSageUserid = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnFolder = New System.Windows.Forms.Button()
        Me.TxtFolder = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnViewLog = New System.Windows.Forms.Button()
        Me.CheckBoxIncludeZeroConsumption = New System.Windows.Forms.CheckBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBoxEnableSSL
        '
        Me.CheckBoxEnableSSL.AutoSize = True
        Me.CheckBoxEnableSSL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxEnableSSL.Checked = True
        Me.CheckBoxEnableSSL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEnableSSL.Location = New System.Drawing.Point(471, 103)
        Me.CheckBoxEnableSSL.Name = "CheckBoxEnableSSL"
        Me.CheckBoxEnableSSL.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxEnableSSL.TabIndex = 14
        Me.CheckBoxEnableSSL.Text = "Enable SSL"
        Me.CheckBoxEnableSSL.UseVisualStyleBackColor = True
        '
        'txtSMTPPort
        '
        Me.txtSMTPPort.Location = New System.Drawing.Point(385, 100)
        Me.txtSMTPPort.Name = "txtSMTPPort"
        Me.txtSMTPPort.Size = New System.Drawing.Size(58, 20)
        Me.txtSMTPPort.TabIndex = 13
        Me.txtSMTPPort.Text = "587"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(350, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Port:"
        '
        'txtSMTPPassword
        '
        Me.txtSMTPPassword.Location = New System.Drawing.Point(385, 26)
        Me.txtSMTPPassword.Name = "txtSMTPPassword"
        Me.txtSMTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSMTPPassword.Size = New System.Drawing.Size(168, 20)
        Me.txtSMTPPassword.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(323, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Password:"
        '
        'txtSMTPServer
        '
        Me.txtSMTPServer.Location = New System.Drawing.Point(105, 100)
        Me.txtSMTPServer.Name = "txtSMTPServer"
        Me.txtSMTPServer.Size = New System.Drawing.Size(206, 20)
        Me.txtSMTPServer.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "SMTP server:"
        '
        'txtSMTPTo
        '
        Me.txtSMTPTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtSMTPTo.Location = New System.Drawing.Point(348, 66)
        Me.txtSMTPTo.Name = "txtSMTPTo"
        Me.txtSMTPTo.Size = New System.Drawing.Size(205, 20)
        Me.txtSMTPTo.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(298, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Sent to:"
        '
        'txtSMTPFrom
        '
        Me.txtSMTPFrom.Location = New System.Drawing.Point(105, 65)
        Me.txtSMTPFrom.Name = "txtSMTPFrom"
        Me.txtSMTPFrom.Size = New System.Drawing.Size(183, 20)
        Me.txtSMTPFrom.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(348, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(206, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Separate email addresses with a comma (,)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxtMailUserID)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.CheckBoxEnableSSL)
        Me.GroupBox4.Controls.Add(Me.txtSMTPPort)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txtSMTPPassword)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtSMTPServer)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtSMTPTo)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtSMTPFrom)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 330)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(577, 128)
        Me.GroupBox4.TabIndex = 42
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "SMTP settings"
        '
        'TxtMailUserID
        '
        Me.TxtMailUserID.Location = New System.Drawing.Point(105, 26)
        Me.TxtMailUserID.Name = "TxtMailUserID"
        Me.TxtMailUserID.Size = New System.Drawing.Size(183, 20)
        Me.TxtMailUserID.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "User ID:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(44, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Sent from:"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(490, 587)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 18
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDataSource)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDbName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUserid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(577, 173)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sql settings"
        '
        'txtDataSource
        '
        Me.txtDataSource.Location = New System.Drawing.Point(105, 135)
        Me.txtDataSource.Name = "txtDataSource"
        Me.txtDataSource.Size = New System.Drawing.Size(447, 20)
        Me.txtDataSource.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Data source:"
        '
        'txtDbName
        '
        Me.txtDbName.Location = New System.Drawing.Point(105, 100)
        Me.txtDbName.Name = "txtDbName"
        Me.txtDbName.Size = New System.Drawing.Size(447, 20)
        Me.txtDbName.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "DB Name:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(105, 63)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(447, 20)
        Me.txtPassword.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password:"
        '
        'txtUserid
        '
        Me.txtUserid.Location = New System.Drawing.Point(105, 26)
        Me.txtUserid.Name = "txtUserid"
        Me.txtUserid.Size = New System.Drawing.Size(447, 20)
        Me.txtUserid.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Userid:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSageCompany)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtSagePassword)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtSageUserid)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 184)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(577, 140)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sage 300 ERP settings"
        '
        'txtSageCompany
        '
        Me.txtSageCompany.Location = New System.Drawing.Point(105, 100)
        Me.txtSageCompany.Name = "txtSageCompany"
        Me.txtSageCompany.Size = New System.Drawing.Size(447, 20)
        Me.txtSageCompany.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Company:"
        '
        'txtSagePassword
        '
        Me.txtSagePassword.Location = New System.Drawing.Point(105, 63)
        Me.txtSagePassword.Name = "txtSagePassword"
        Me.txtSagePassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSagePassword.Size = New System.Drawing.Size(447, 20)
        Me.txtSagePassword.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Password:"
        '
        'txtSageUserid
        '
        Me.txtSageUserid.Location = New System.Drawing.Point(105, 26)
        Me.txtSageUserid.Name = "txtSageUserid"
        Me.txtSageUserid.Size = New System.Drawing.Size(447, 20)
        Me.txtSageUserid.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Userid:"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(41, 587)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 17
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnFolder)
        Me.GroupBox3.Controls.Add(Me.TxtFolder)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 468)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(577, 57)
        Me.GroupBox3.TabIndex = 45
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Neptune and Trucked file folder"
        '
        'BtnFolder
        '
        Me.BtnFolder.Location = New System.Drawing.Point(521, 25)
        Me.BtnFolder.Name = "BtnFolder"
        Me.BtnFolder.Size = New System.Drawing.Size(33, 22)
        Me.BtnFolder.TabIndex = 16
        Me.BtnFolder.Text = "<<<"
        Me.BtnFolder.UseVisualStyleBackColor = True
        Me.BtnFolder.Visible = False
        '
        'TxtFolder
        '
        Me.TxtFolder.BackColor = System.Drawing.SystemColors.Window
        Me.TxtFolder.Location = New System.Drawing.Point(105, 26)
        Me.TxtFolder.Name = "TxtFolder"
        Me.TxtFolder.Size = New System.Drawing.Size(445, 20)
        Me.TxtFolder.TabIndex = 15
        Me.TxtFolder.Text = "\\tnw-sage-19\Neptune"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Files folder:"
        '
        'BtnViewLog
        '
        Me.BtnViewLog.Location = New System.Drawing.Point(263, 587)
        Me.BtnViewLog.Name = "BtnViewLog"
        Me.BtnViewLog.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewLog.TabIndex = 46
        Me.BtnViewLog.Text = "View Log"
        Me.BtnViewLog.UseVisualStyleBackColor = True
        '
        'CheckBoxIncludeZeroConsumption
        '
        Me.CheckBoxIncludeZeroConsumption.AutoSize = True
        Me.CheckBoxIncludeZeroConsumption.Location = New System.Drawing.Point(74, 531)
        Me.CheckBoxIncludeZeroConsumption.Name = "CheckBoxIncludeZeroConsumption"
        Me.CheckBoxIncludeZeroConsumption.Size = New System.Drawing.Size(455, 17)
        Me.CheckBoxIncludeZeroConsumption.TabIndex = 47
        Me.CheckBoxIncludeZeroConsumption.Text = "Create invoice record for Zero  Consumption. (Garbage will be created regardless " &
    "of setting)"
        Me.CheckBoxIncludeZeroConsumption.UseVisualStyleBackColor = True
        Me.CheckBoxIncludeZeroConsumption.Visible = False
        '
        'FrmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 652)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBoxIncludeZeroConsumption)
        Me.Controls.Add(Me.BtnViewLog)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBoxEnableSSL As CheckBox
    Friend WithEvents txtSMTPPort As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtSMTPPassword As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSMTPServer As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSMTPTo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSMTPFrom As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDataSource As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDbName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUserid As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtSageCompany As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSagePassword As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSageUserid As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnSave As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BtnFolder As Button
    Friend WithEvents TxtFolder As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtMailUserID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnViewLog As Button
    Friend WithEvents CheckBoxIncludeZeroConsumption As CheckBox
End Class
