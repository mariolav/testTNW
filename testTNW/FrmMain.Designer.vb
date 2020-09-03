<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
        Me.BtnSetup = New System.Windows.Forms.Button()
        Me.BtnImport = New System.Windows.Forms.Button()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnImportTrucked = New System.Windows.Forms.Button()
        Me.LblHelp = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.BtnPenaltyInvoices = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnSetup
        '
        Me.BtnSetup.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetup.Location = New System.Drawing.Point(131, 367)
        Me.BtnSetup.Name = "BtnSetup"
        Me.BtnSetup.Size = New System.Drawing.Size(209, 40)
        Me.BtnSetup.TabIndex = 4
        Me.BtnSetup.Text = "Setup"
        Me.BtnSetup.UseVisualStyleBackColor = True
        '
        'BtnImport
        '
        Me.BtnImport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImport.Location = New System.Drawing.Point(131, 190)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(209, 40)
        Me.BtnImport.TabIndex = 2
        Me.BtnImport.Text = "Import from Neptune"
        Me.BtnImport.UseVisualStyleBackColor = True
        '
        'BtnExport
        '
        Me.BtnExport.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Location = New System.Drawing.Point(131, 131)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(209, 40)
        Me.BtnExport.TabIndex = 1
        Me.BtnExport.Text = "Export to Neptune"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(131, 475)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(209, 40)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnImportTrucked
        '
        Me.BtnImportTrucked.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnImportTrucked.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImportTrucked.Location = New System.Drawing.Point(131, 249)
        Me.BtnImportTrucked.Name = "BtnImportTrucked"
        Me.BtnImportTrucked.Size = New System.Drawing.Size(209, 40)
        Me.BtnImportTrucked.TabIndex = 3
        Me.BtnImportTrucked.Text = "Import Trucked Water"
        Me.BtnImportTrucked.UseVisualStyleBackColor = True
        '
        'LblHelp
        '
        Me.LblHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHelp.Location = New System.Drawing.Point(12, 61)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(447, 40)
        Me.LblHelp.TabIndex = 6
        Me.LblHelp.Text = "Help: Put mouse pointer over button to get help"
        Me.LblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCompany
        '
        Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(12, 9)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(448, 36)
        Me.lblCompany.TabIndex = 7
        Me.lblCompany.Text = "Company Selected: "
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnPenaltyInvoices
        '
        Me.BtnPenaltyInvoices.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnPenaltyInvoices.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPenaltyInvoices.Location = New System.Drawing.Point(131, 306)
        Me.BtnPenaltyInvoices.Name = "BtnPenaltyInvoices"
        Me.BtnPenaltyInvoices.Size = New System.Drawing.Size(209, 40)
        Me.BtnPenaltyInvoices.TabIndex = 8
        Me.BtnPenaltyInvoices.Text = "Create Penalty Invoices"
        Me.BtnPenaltyInvoices.UseVisualStyleBackColor = True
        Me.BtnPenaltyInvoices.Visible = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 549)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnPenaltyInvoices)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.BtnImportTrucked)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.BtnImport)
        Me.Controls.Add(Me.BtnSetup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Neptune Utility"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnSetup As Button
    Friend WithEvents BtnImport As Button
    Friend WithEvents BtnExport As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnImportTrucked As Button
    Friend WithEvents LblHelp As Label
    Friend WithEvents lblCompany As Label
    Friend WithEvents BtnPenaltyInvoices As Button
End Class
