<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrucked
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.PBImportTrucked = New System.Windows.Forms.ProgressBar()
        Me.LblLog = New System.Windows.Forms.Label()
        Me.LblFile = New System.Windows.Forms.Label()
        Me.TxtFileTrucked = New System.Windows.Forms.TextBox()
        Me.btnSelectXLSFile = New System.Windows.Forms.Button()
        Me.BtnViewBad = New System.Windows.Forms.Button()
        Me.CheckBoxMAF = New System.Windows.Forms.CheckBox()
        Me.CheckBoxIncludeInterest = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(483, 218)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 10
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(13, 218)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(75, 23)
        Me.BtnImport.TabIndex = 8
        Me.BtnImport.Text = "Import"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'PBImportTrucked
        '
        Me.PBImportTrucked.Location = New System.Drawing.Point(7, 13)
        Me.PBImportTrucked.Name = "PBImportTrucked"
        Me.PBImportTrucked.Size = New System.Drawing.Size(552, 19)
        Me.PBImportTrucked.TabIndex = 11
        Me.PBImportTrucked.Visible = False
        '
        'LblLog
        '
        Me.LblLog.Location = New System.Drawing.Point(-2, 35)
        Me.LblLog.Name = "LblLog"
        Me.LblLog.Size = New System.Drawing.Size(575, 23)
        Me.LblLog.TabIndex = 12
        Me.LblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFile
        '
        Me.LblFile.AutoSize = True
        Me.LblFile.Location = New System.Drawing.Point(9, 83)
        Me.LblFile.Name = "LblFile"
        Me.LblFile.Size = New System.Drawing.Size(58, 13)
        Me.LblFile.TabIndex = 13
        Me.LblFile.Text = "Import File:"
        '
        'TxtFileTrucked
        '
        Me.TxtFileTrucked.Location = New System.Drawing.Point(69, 80)
        Me.TxtFileTrucked.Name = "TxtFileTrucked"
        Me.TxtFileTrucked.ReadOnly = True
        Me.TxtFileTrucked.Size = New System.Drawing.Size(450, 20)
        Me.TxtFileTrucked.TabIndex = 14
        '
        'btnSelectXLSFile
        '
        Me.btnSelectXLSFile.Location = New System.Drawing.Point(525, 80)
        Me.btnSelectXLSFile.Name = "btnSelectXLSFile"
        Me.btnSelectXLSFile.Size = New System.Drawing.Size(34, 22)
        Me.btnSelectXLSFile.TabIndex = 15
        Me.btnSelectXLSFile.Text = "<<<"
        Me.btnSelectXLSFile.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSelectXLSFile.UseVisualStyleBackColor = True
        '
        'BtnViewBad
        '
        Me.BtnViewBad.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnViewBad.Location = New System.Drawing.Point(248, 218)
        Me.BtnViewBad.Name = "BtnViewBad"
        Me.BtnViewBad.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewBad.TabIndex = 16
        Me.BtnViewBad.Text = "View Bad"
        Me.BtnViewBad.UseVisualStyleBackColor = True
        '
        'CheckBoxMAF
        '
        Me.CheckBoxMAF.AutoSize = True
        Me.CheckBoxMAF.Checked = True
        Me.CheckBoxMAF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxMAF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMAF.Location = New System.Drawing.Point(69, 128)
        Me.CheckBoxMAF.Name = "CheckBoxMAF"
        Me.CheckBoxMAF.Size = New System.Drawing.Size(432, 24)
        Me.CheckBoxMAF.TabIndex = 17
        Me.CheckBoxMAF.Text = "Add  Monthly Access Fee (MAF) to this invoices creation. "
        Me.CheckBoxMAF.UseVisualStyleBackColor = True
        '
        'CheckBoxIncludeInterest
        '
        Me.CheckBoxIncludeInterest.AutoSize = True
        Me.CheckBoxIncludeInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxIncludeInterest.Location = New System.Drawing.Point(69, 168)
        Me.CheckBoxIncludeInterest.Name = "CheckBoxIncludeInterest"
        Me.CheckBoxIncludeInterest.Size = New System.Drawing.Size(203, 24)
        Me.CheckBoxIncludeInterest.TabIndex = 18
        Me.CheckBoxIncludeInterest.Text = "Include Interest Charges"
        Me.CheckBoxIncludeInterest.UseVisualStyleBackColor = True
        '
        'FrmTrucked
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 270)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBoxIncludeInterest)
        Me.Controls.Add(Me.CheckBoxMAF)
        Me.Controls.Add(Me.BtnViewBad)
        Me.Controls.Add(Me.btnSelectXLSFile)
        Me.Controls.Add(Me.TxtFileTrucked)
        Me.Controls.Add(Me.LblFile)
        Me.Controls.Add(Me.LblLog)
        Me.Controls.Add(Me.PBImportTrucked)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmTrucked"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Trucked Water"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents PBImportTrucked As ProgressBar
    Friend WithEvents LblLog As Label
    Friend WithEvents LblFile As Label
    Friend WithEvents TxtFileTrucked As TextBox
    Friend WithEvents btnSelectXLSFile As Button
    Friend WithEvents BtnViewBad As Button
    Friend WithEvents CheckBoxMAF As CheckBox
    Friend WithEvents CheckBoxIncludeInterest As CheckBox
End Class
