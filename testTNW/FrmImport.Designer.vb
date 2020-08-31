<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImport
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
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.LblLog = New System.Windows.Forms.Label()
        Me.PBImportMeter = New System.Windows.Forms.ProgressBar()
        Me.BtnViewErrors = New System.Windows.Forms.Button()
        Me.CheckBoxMAF = New System.Windows.Forms.CheckBox()
        Me.CheckBoxIncludeInterest = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(496, 160)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(30, 160)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(75, 23)
        Me.BtnImport.TabIndex = 3
        Me.BtnImport.Text = "Import"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'LblLog
        '
        Me.LblLog.Location = New System.Drawing.Point(-1, 25)
        Me.LblLog.Name = "LblLog"
        Me.LblLog.Size = New System.Drawing.Size(600, 23)
        Me.LblLog.TabIndex = 6
        Me.LblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PBImportMeter
        '
        Me.PBImportMeter.Location = New System.Drawing.Point(8, 6)
        Me.PBImportMeter.Name = "PBImportMeter"
        Me.PBImportMeter.Size = New System.Drawing.Size(585, 12)
        Me.PBImportMeter.TabIndex = 8
        Me.PBImportMeter.Visible = False
        '
        'BtnViewErrors
        '
        Me.BtnViewErrors.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnViewErrors.Location = New System.Drawing.Point(263, 160)
        Me.BtnViewErrors.Name = "BtnViewErrors"
        Me.BtnViewErrors.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewErrors.TabIndex = 9
        Me.BtnViewErrors.Text = "View Errors"
        Me.BtnViewErrors.UseVisualStyleBackColor = True
        '
        'CheckBoxMAF
        '
        Me.CheckBoxMAF.AutoSize = True
        Me.CheckBoxMAF.Checked = True
        Me.CheckBoxMAF.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxMAF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMAF.Location = New System.Drawing.Point(86, 76)
        Me.CheckBoxMAF.Name = "CheckBoxMAF"
        Me.CheckBoxMAF.Size = New System.Drawing.Size(428, 24)
        Me.CheckBoxMAF.TabIndex = 10
        Me.CheckBoxMAF.Text = "Add  Monthly Access Fee (MAF) to this invoices creation."
        Me.CheckBoxMAF.UseVisualStyleBackColor = True
        '
        'CheckBoxIncludeInterest
        '
        Me.CheckBoxIncludeInterest.AutoSize = True
        Me.CheckBoxIncludeInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxIncludeInterest.Location = New System.Drawing.Point(86, 106)
        Me.CheckBoxIncludeInterest.Name = "CheckBoxIncludeInterest"
        Me.CheckBoxIncludeInterest.Size = New System.Drawing.Size(203, 24)
        Me.CheckBoxIncludeInterest.TabIndex = 11
        Me.CheckBoxIncludeInterest.Text = "Include Interest Charges"
        Me.CheckBoxIncludeInterest.UseVisualStyleBackColor = True
        '
        'FrmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 214)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBoxIncludeInterest)
        Me.Controls.Add(Me.CheckBoxMAF)
        Me.Controls.Add(Me.BtnViewErrors)
        Me.Controls.Add(Me.PBImportMeter)
        Me.Controls.Add(Me.LblLog)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Neptune file"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents LblLog As Label
    Friend WithEvents PBImportMeter As ProgressBar
    Friend WithEvents BtnViewErrors As Button
    Friend WithEvents CheckBoxMAF As CheckBox
    Friend WithEvents CheckBoxIncludeInterest As CheckBox
End Class
