<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPenaltyOthers
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
        Me.PBImportMeter = New System.Windows.Forms.ProgressBar()
        Me.LblLog = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PBImportMeter
        '
        Me.PBImportMeter.Location = New System.Drawing.Point(13, 5)
        Me.PBImportMeter.Name = "PBImportMeter"
        Me.PBImportMeter.Size = New System.Drawing.Size(585, 12)
        Me.PBImportMeter.TabIndex = 13
        Me.PBImportMeter.Visible = False
        '
        'LblLog
        '
        Me.LblLog.Location = New System.Drawing.Point(4, 24)
        Me.LblLog.Name = "LblLog"
        Me.LblLog.Size = New System.Drawing.Size(600, 23)
        Me.LblLog.TabIndex = 12
        Me.LblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(511, 133)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImport.Location = New System.Drawing.Point(24, 133)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(75, 23)
        Me.BtnImport.TabIndex = 10
        Me.BtnImport.Text = "Import"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'FrmPenaltyOthers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.PBImportMeter)
        Me.Controls.Add(Me.LblLog)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnImport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPenaltyOthers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Penalty invoice for Others"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PBImportMeter As ProgressBar
    Friend WithEvents LblLog As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnImport As Button
End Class
