<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLog
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
        Me.BtnEmailLOg = New System.Windows.Forms.Button()
        Me.TxtErrorLog = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.BtnClearLog = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnEmailLOg
        '
        Me.BtnEmailLOg.Location = New System.Drawing.Point(12, 527)
        Me.BtnEmailLOg.Name = "BtnEmailLOg"
        Me.BtnEmailLOg.Size = New System.Drawing.Size(75, 23)
        Me.BtnEmailLOg.TabIndex = 36
        Me.BtnEmailLOg.Text = "Email log"
        Me.BtnEmailLOg.UseVisualStyleBackColor = True
        '
        'TxtErrorLog
        '
        Me.TxtErrorLog.BackColor = System.Drawing.Color.White
        Me.TxtErrorLog.Location = New System.Drawing.Point(12, 12)
        Me.TxtErrorLog.Multiline = True
        Me.TxtErrorLog.Name = "TxtErrorLog"
        Me.TxtErrorLog.ReadOnly = True
        Me.TxtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtErrorLog.Size = New System.Drawing.Size(844, 491)
        Me.TxtErrorLog.TabIndex = 35
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(781, 527)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 34
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'BtnClearLog
        '
        Me.BtnClearLog.Location = New System.Drawing.Point(384, 527)
        Me.BtnClearLog.Name = "BtnClearLog"
        Me.BtnClearLog.Size = New System.Drawing.Size(75, 23)
        Me.BtnClearLog.TabIndex = 37
        Me.BtnClearLog.Text = "Clear log"
        Me.BtnClearLog.UseVisualStyleBackColor = True
        '
        'FrmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 572)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnClearLog)
        Me.Controls.Add(Me.BtnEmailLOg)
        Me.Controls.Add(Me.TxtErrorLog)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Program Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnEmailLOg As Button
    Friend WithEvents TxtErrorLog As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents BtnClearLog As Button
End Class
