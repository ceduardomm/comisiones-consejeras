<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.txtSalesName = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSalesPersonCode = New System.Windows.Forms.TextBox
        Me.btnProcesar = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.cmbStoreName = New System.Windows.Forms.ComboBox
        Me.cmbSucursalName = New System.Windows.Forms.ComboBox
        Me.cmbStoreCode = New System.Windows.Forms.ComboBox
        Me.cmbSucursalCode = New System.Windows.Forms.ComboBox
        Me.lblBrand = New System.Windows.Forms.Label
        Me.cmbBrandName = New System.Windows.Forms.ComboBox
        Me.cmbBrandCode = New System.Windows.Forms.ComboBox
        Me.btnCalculate = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(307, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Numero de Pedido :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(252, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre de Consejera :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Almacén :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 253)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Sucursal :"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(313, 39)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(200, 22)
        Me.txtDate.TabIndex = 0
        '
        'txtSalesName
        '
        Me.txtSalesName.Location = New System.Drawing.Point(188, 129)
        Me.txtSalesName.Name = "txtSalesName"
        Me.txtSalesName.Size = New System.Drawing.Size(325, 22)
        Me.txtSalesName.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(31, 293)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(589, 150)
        Me.DataGridView1.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Codigo de Consejera :"
        '
        'txtSalesPersonCode
        '
        Me.txtSalesPersonCode.Location = New System.Drawing.Point(188, 96)
        Me.txtSalesPersonCode.Name = "txtSalesPersonCode"
        Me.txtSalesPersonCode.Size = New System.Drawing.Size(82, 22)
        Me.txtSalesPersonCode.TabIndex = 1
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(31, 494)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(93, 23)
        Me.btnProcesar.TabIndex = 9
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(527, 494)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(93, 23)
        Me.btnCerrar.TabIndex = 10
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(462, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Label7"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(312, 446)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(48, 17)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(393, 446)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtTotal.TabIndex = 8
        '
        'cmbStoreName
        '
        Me.cmbStoreName.FormattingEnabled = True
        Me.cmbStoreName.Location = New System.Drawing.Point(104, 221)
        Me.cmbStoreName.Name = "cmbStoreName"
        Me.cmbStoreName.Size = New System.Drawing.Size(166, 24)
        Me.cmbStoreName.TabIndex = 4
        '
        'cmbSucursalName
        '
        Me.cmbSucursalName.FormattingEnabled = True
        Me.cmbSucursalName.Location = New System.Drawing.Point(105, 253)
        Me.cmbSucursalName.Name = "cmbSucursalName"
        Me.cmbSucursalName.Size = New System.Drawing.Size(165, 24)
        Me.cmbSucursalName.TabIndex = 5
        '
        'cmbStoreCode
        '
        Me.cmbStoreCode.FormattingEnabled = True
        Me.cmbStoreCode.Location = New System.Drawing.Point(310, 221)
        Me.cmbStoreCode.Name = "cmbStoreCode"
        Me.cmbStoreCode.Size = New System.Drawing.Size(75, 24)
        Me.cmbStoreCode.TabIndex = 20
        Me.cmbStoreCode.Visible = False
        '
        'cmbSucursalCode
        '
        Me.cmbSucursalCode.FormattingEnabled = True
        Me.cmbSucursalCode.Location = New System.Drawing.Point(310, 253)
        Me.cmbSucursalCode.Name = "cmbSucursalCode"
        Me.cmbSucursalCode.Size = New System.Drawing.Size(75, 24)
        Me.cmbSucursalCode.TabIndex = 21
        Me.cmbSucursalCode.Visible = False
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Location = New System.Drawing.Point(28, 186)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(55, 17)
        Me.lblBrand.TabIndex = 22
        Me.lblBrand.Text = "Marca :"
        '
        'cmbBrandName
        '
        Me.cmbBrandName.FormattingEnabled = True
        Me.cmbBrandName.Location = New System.Drawing.Point(105, 183)
        Me.cmbBrandName.Name = "cmbBrandName"
        Me.cmbBrandName.Size = New System.Drawing.Size(165, 24)
        Me.cmbBrandName.TabIndex = 3
        '
        'cmbBrandCode
        '
        Me.cmbBrandCode.FormattingEnabled = True
        Me.cmbBrandCode.Location = New System.Drawing.Point(309, 179)
        Me.cmbBrandCode.Name = "cmbBrandCode"
        Me.cmbBrandCode.Size = New System.Drawing.Size(75, 24)
        Me.cmbBrandCode.TabIndex = 24
        Me.cmbBrandCode.Visible = False
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(49, 449)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(116, 23)
        Me.btnCalculate.TabIndex = 7
        Me.btnCalculate.Text = "Calcular total"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(645, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.cmbBrandCode)
        Me.Controls.Add(Me.cmbBrandName)
        Me.Controls.Add(Me.lblBrand)
        Me.Controls.Add(Me.cmbSucursalCode)
        Me.Controls.Add(Me.cmbStoreCode)
        Me.Controls.Add(Me.cmbSucursalName)
        Me.Controls.Add(Me.cmbStoreName)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.txtSalesPersonCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtSalesName)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesName As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSalesPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmbStoreName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursalName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStoreCode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursalCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents cmbBrandName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBrandCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
End Class
