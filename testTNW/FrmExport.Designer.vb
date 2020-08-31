<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmExport
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
        Me.components = New System.ComponentModel.Container()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.DataGridViewExport = New System.Windows.Forms.DataGridView()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IDCUST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OLDACC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Water = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Garbage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Meter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridViewExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnExport
        '
        Me.BtnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnExport.Location = New System.Drawing.Point(39, 495)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(112, 23)
        Me.BtnExport.TabIndex = 0
        Me.BtnExport.Text = "Export to Neptune"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(1099, 495)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(112, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'DataGridViewExport
        '
        Me.DataGridViewExport.AllowUserToAddRows = False
        Me.DataGridViewExport.AllowUserToDeleteRows = False
        Me.DataGridViewExport.AllowUserToResizeRows = False
        Me.DataGridViewExport.CausesValidation = False
        Me.DataGridViewExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewExport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.IDCUST, Me.OLDACC, Me.CustName, Me.Address1, Me.Address2, Me.Address4, Me.City, Me.Prov, Me.PCode, Me.Water, Me.Garbage, Me.Meter})
        Me.DataGridViewExport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridViewExport.Location = New System.Drawing.Point(12, 41)
        Me.DataGridViewExport.MultiSelect = False
        Me.DataGridViewExport.Name = "DataGridViewExport"
        Me.DataGridViewExport.RowHeadersVisible = False
        Me.DataGridViewExport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewExport.ShowCellErrors = False
        Me.DataGridViewExport.ShowCellToolTips = False
        Me.DataGridViewExport.ShowEditingIcon = False
        Me.DataGridViewExport.ShowRowErrors = False
        Me.DataGridViewExport.Size = New System.Drawing.Size(1227, 425)
        Me.DataGridViewExport.TabIndex = 3
        Me.DataGridViewExport.VirtualMode = True
        '
        'Sel
        '
        Me.Sel.DataPropertyName = "Sel"
        Me.Sel.FalseValue = "0"
        Me.Sel.Frozen = True
        Me.Sel.HeaderText = "Select"
        Me.Sel.Name = "Sel"
        Me.Sel.TrueValue = "-1"
        '
        'IDCUST
        '
        Me.IDCUST.DataPropertyName = "IDCUST"
        Me.IDCUST.Frozen = True
        Me.IDCUST.HeaderText = "Cust #"
        Me.IDCUST.Name = "IDCUST"
        Me.IDCUST.ReadOnly = True
        '
        'OLDACC
        '
        Me.OLDACC.DataPropertyName = "OLDACC"
        Me.OLDACC.HeaderText = "Old Acc#"
        Me.OLDACC.Name = "OLDACC"
        Me.OLDACC.ReadOnly = True
        '
        'CustName
        '
        Me.CustName.DataPropertyName = "CustName"
        Me.CustName.HeaderText = "Cust Name"
        Me.CustName.Name = "CustName"
        Me.CustName.ReadOnly = True
        '
        'Address1
        '
        Me.Address1.DataPropertyName = "Address1"
        Me.Address1.HeaderText = "Address1"
        Me.Address1.Name = "Address1"
        Me.Address1.ReadOnly = True
        '
        'Address2
        '
        Me.Address2.DataPropertyName = "Address2"
        Me.Address2.HeaderText = "Address 2"
        Me.Address2.Name = "Address2"
        Me.Address2.ReadOnly = True
        '
        'Address4
        '
        Me.Address4.DataPropertyName = "Address4"
        Me.Address4.HeaderText = "Address 4"
        Me.Address4.Name = "Address4"
        Me.Address4.ReadOnly = True
        '
        'City
        '
        Me.City.DataPropertyName = "City"
        Me.City.HeaderText = "City"
        Me.City.Name = "City"
        Me.City.ReadOnly = True
        '
        'Prov
        '
        Me.Prov.DataPropertyName = "Prov"
        Me.Prov.HeaderText = "Province"
        Me.Prov.Name = "Prov"
        Me.Prov.ReadOnly = True
        '
        'PCode
        '
        Me.PCode.DataPropertyName = "PCode"
        Me.PCode.HeaderText = "PCode"
        Me.PCode.Name = "PCode"
        Me.PCode.ReadOnly = True
        '
        'Water
        '
        Me.Water.DataPropertyName = "Water"
        Me.Water.HeaderText = "Water"
        Me.Water.Name = "Water"
        Me.Water.ReadOnly = True
        '
        'Garbage
        '
        Me.Garbage.DataPropertyName = "Garbage"
        Me.Garbage.HeaderText = "Garbage"
        Me.Garbage.Name = "Garbage"
        Me.Garbage.ReadOnly = True
        '
        'Meter
        '
        Me.Meter.DataPropertyName = "Meter"
        Me.Meter.HeaderText = "Meter #"
        Me.Meter.Name = "Meter"
        Me.Meter.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search Cust #:"
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(92, 12)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(145, 20)
        Me.TxtSearch.TabIndex = 5
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(243, 12)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(66, 23)
        Me.BtnSearch.TabIndex = 6
        Me.BtnSearch.Text = "Refresh"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnSelect
        '
        Me.BtnSelect.Location = New System.Drawing.Point(1164, 10)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(75, 23)
        Me.BtnSelect.TabIndex = 7
        Me.BtnSelect.Text = "Unselect All"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(569, 495)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Export to Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1251, 540)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewExport)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnExport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Neptune file"
        CType(Me.DataGridViewExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnExport As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtSearch As TextBox
    Friend WithEvents BtnSearch As Button
    Friend WithEvents BtnSelect As Button
    Friend WithEvents DataGridViewExport As DataGridView
    Friend WithEvents Sel As DataGridViewCheckBoxColumn
    Friend WithEvents IDCUST As DataGridViewTextBoxColumn
    Friend WithEvents OLDACC As DataGridViewTextBoxColumn
    Friend WithEvents CustName As DataGridViewTextBoxColumn
    Friend WithEvents Address1 As DataGridViewTextBoxColumn
    Friend WithEvents Address2 As DataGridViewTextBoxColumn
    Friend WithEvents Address4 As DataGridViewTextBoxColumn
    Friend WithEvents City As DataGridViewTextBoxColumn
    Friend WithEvents Prov As DataGridViewTextBoxColumn
    Friend WithEvents PCode As DataGridViewTextBoxColumn
    Friend WithEvents Water As DataGridViewTextBoxColumn
    Friend WithEvents Garbage As DataGridViewTextBoxColumn
    Friend WithEvents Meter As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
End Class
