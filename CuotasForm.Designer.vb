<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuotasForm
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.lblTopic = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.lblTeam = New System.Windows.Forms.Label
        Me.cmbTeam = New System.Windows.Forms.ComboBox
        Me.cmbMes = New System.Windows.Forms.ComboBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(51, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(675, 354)
        Me.DataGridView1.TabIndex = 0
        '
        'lblTopic
        '
        Me.lblTopic.AutoSize = True
        Me.lblTopic.Location = New System.Drawing.Point(12, 16)
        Me.lblTopic.Name = "lblTopic"
        Me.lblTopic.Size = New System.Drawing.Size(12, 17)
        Me.lblTopic.TabIndex = 1
        Me.lblTopic.Text = "."
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(51, 418)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(651, 418)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(552, 13)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(12, 17)
        Me.lblTeam.TabIndex = 4
        Me.lblTeam.Text = "."
        '
        'cmbTeam
        '
        Me.cmbTeam.Enabled = False
        Me.cmbTeam.FormattingEnabled = True
        Me.cmbTeam.Items.AddRange(New Object() {"1", "2", "3", "4", "7"})
        Me.cmbTeam.Location = New System.Drawing.Point(651, 6)
        Me.cmbTeam.Name = "cmbTeam"
        Me.cmbTeam.Size = New System.Drawing.Size(73, 24)
        Me.cmbTeam.TabIndex = 5
        '
        'cmbMes
        '
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(437, 6)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(62, 24)
        Me.cmbMes.TabIndex = 6
        '
        'CuotasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.cmbTeam)
        Me.Controls.Add(Me.lblTeam)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblTopic)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "CuotasForm"
        Me.Text = "CuotasForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblTopic As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents cmbTeam As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
End Class
