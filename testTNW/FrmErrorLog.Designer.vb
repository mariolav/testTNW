<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmErrorLog
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TxtErrorLog = New System.Windows.Forms.TextBox()
        Me.BtnEmailLOg = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(602, 527)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 31
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TxtErrorLog
        '
        Me.TxtErrorLog.BackColor = System.Drawing.Color.White
        Me.TxtErrorLog.Location = New System.Drawing.Point(12, 12)
        Me.TxtErrorLog.Multiline = True
        Me.TxtErrorLog.Name = "TxtErrorLog"
        Me.TxtErrorLog.ReadOnly = True
        Me.TxtErrorLog.Size = New System.Drawing.Size(692, 491)
        Me.TxtErrorLog.TabIndex = 32
        '
        'BtnEmailLOg
        '
        Me.BtnEmailLOg.Location = New System.Drawing.Point(35, 527)
        Me.BtnEmailLOg.Name = "BtnEmailLOg"
        Me.BtnEmailLOg.Size = New System.Drawing.Size(75, 23)
        Me.BtnEmailLOg.TabIndex = 33
        Me.BtnEmailLOg.Text = "Email log"
        Me.BtnEmailLOg.UseVisualStyleBackColor = True
        '
        'FrmErrorLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(713, 572)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnEmailLOg)
        Me.Controls.Add(Me.TxtErrorLog)
        Me.Controls.Add(Me.btnExit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmErrorLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Program Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents TxtErrorLog As TextBox
    Friend WithEvents BtnEmailLOg As Button
End Class
