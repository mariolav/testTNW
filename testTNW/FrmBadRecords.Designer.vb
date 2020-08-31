<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBadRecords
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
        Me.components = New System.ComponentModel.Container()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTruckedBad = New System.Windows.Forms.DataGridView()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.BtnCreateInvoices = New System.Windows.Forms.Button()
        Me.PBBad = New System.Windows.Forms.ProgressBar()
        Me.LblDisplay = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewTruckedBad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewTruckedBad
        '
        Me.DataGridViewTruckedBad.AllowUserToAddRows = False
        Me.DataGridViewTruckedBad.AllowUserToDeleteRows = False
        Me.DataGridViewTruckedBad.AllowUserToResizeRows = False
        Me.DataGridViewTruckedBad.CausesValidation = False
        Me.DataGridViewTruckedBad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTruckedBad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridViewTruckedBad.Location = New System.Drawing.Point(12, 29)
        Me.DataGridViewTruckedBad.MultiSelect = False
        Me.DataGridViewTruckedBad.Name = "DataGridViewTruckedBad"
        Me.DataGridViewTruckedBad.ReadOnly = True
        Me.DataGridViewTruckedBad.RowHeadersVisible = False
        Me.DataGridViewTruckedBad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewTruckedBad.ShowCellErrors = False
        Me.DataGridViewTruckedBad.ShowCellToolTips = False
        Me.DataGridViewTruckedBad.ShowEditingIcon = False
        Me.DataGridViewTruckedBad.ShowRowErrors = False
        Me.DataGridViewTruckedBad.Size = New System.Drawing.Size(1347, 416)
        Me.DataGridViewTruckedBad.TabIndex = 0
        Me.DataGridViewTruckedBad.VirtualMode = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(1241, 494)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(117, 23)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnExport
        '
        Me.BtnExport.Location = New System.Drawing.Point(13, 494)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(117, 23)
        Me.BtnExport.TabIndex = 12
        Me.BtnExport.Text = "Export to Excel"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'BtnCreateInvoices
        '
        Me.BtnCreateInvoices.Location = New System.Drawing.Point(627, 494)
        Me.BtnCreateInvoices.Name = "BtnCreateInvoices"
        Me.BtnCreateInvoices.Size = New System.Drawing.Size(117, 23)
        Me.BtnCreateInvoices.TabIndex = 13
        Me.BtnCreateInvoices.Text = "Create Invoices"
        Me.BtnCreateInvoices.UseVisualStyleBackColor = True
        '
        'PBBad
        '
        Me.PBBad.Location = New System.Drawing.Point(12, 447)
        Me.PBBad.Name = "PBBad"
        Me.PBBad.Size = New System.Drawing.Size(1346, 9)
        Me.PBBad.TabIndex = 14
        Me.PBBad.Visible = False
        '
        'LblDisplay
        '
        Me.LblDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisplay.Location = New System.Drawing.Point(12, 459)
        Me.LblDisplay.Name = "LblDisplay"
        Me.LblDisplay.Size = New System.Drawing.Size(1346, 23)
        Me.LblDisplay.TabIndex = 15
        Me.LblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1347, 22)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "List of Excluded records due to one or more errors"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmBadRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1371, 529)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblDisplay)
        Me.Controls.Add(Me.PBBad)
        Me.Controls.Add(Me.BtnCreateInvoices)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.DataGridViewTruckedBad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmBadRecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Errors importing records (prior to Invoice creation). Please review and fix as ne" &
    "eded."
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewTruckedBad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents DataGridViewTruckedBad As DataGridView
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnExport As Button
    Friend WithEvents BtnCreateInvoices As Button
    Friend WithEvents PBBad As ProgressBar
    Friend WithEvents LblDisplay As Label
    Friend WithEvents Label1 As Label
End Class
