Imports System.Data
Imports System.Data.SqlClient
Public Class CuotasForm
    Dim dsCuotas As DataSet
    Private Sub CuotasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Definicion de Cuotas del mes por consejera"
    End Sub
    Public Sub New(ByVal Equipo As Object)
        Me.MdiParent = Comisiones
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.cmbTeam.SelectedItem = Equipo
        ' Add any initialization after the InitializeComponent() call.
        Form2.conexionLocal = New SqlConnection(Form2.miCadena)
        Dim miSQl As SqlCommand = New SqlCommand("Select Codigo_Consejera,Nombre,Apellidos From Consejeras Where Equipo='" & Me.cmbTeam.SelectedItem & "'")
        'Dim miotroSQl As SqlCommand = New SqlCommand("Select Codigo_Almacen,Nombre_Almacen From Almacenes")
        Form2.conexionLocal.Open()
        miSQl.Connection = Form2.conexionLocal
        Dim resultado1 As SqlDataReader = miSQl.ExecuteReader()
        Dim filas As Integer = 0
        Me.DataGridView1.Columns.Add(0, "Codigo_Consejera")
        'Me.DataGridView1.Columns(0).Visible = False
        Me.DataGridView1.Columns.Add(1, "Consejera")
        Me.DataGridView1.Columns.Add(2, "Cuota")
        While resultado1.Read
            Me.DataGridView1.Rows.Add()
            Me.DataGridView1.Rows(filas).Cells.Item(0).Value = resultado1.Item(0)
            Me.DataGridView1.Rows(filas).Cells.Item(1).Value = resultado1.Item(1) + " " + resultado1.Item(2)
            filas = filas + 1
        End While
        Form2.conexionLocal.Close()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim lineas As Integer
        Dim fecha As Date = Now()
        Dim sqlInsert As SqlCommand
        Dim Mes As Integer = Me.cmbMes.SelectedIndex + 1
        lineas = Me.DataGridView1.Rows.Count
        Try
            For i As Integer = 0 To lineas - 1
                If Me.DataGridView1.Rows(i).Cells.Item(2).Value > 0 Then
                    sqlInsert = New SqlCommand("insert into Cuotas (Codigo_Consejera,Nombre_Consejera, Cuota,Equipo,Fecha_Creacion,Mes_calculo,User_sign)" _
                    & "VALUES('" & Me.DataGridView1.Rows(i).Cells.Item(0).Value & "','" & Me.DataGridView1.Rows(i).Cells.Item(1).Value & "','" _
                    & Me.DataGridView1.Rows(i).Cells.Item(2).Value & "','" & Me.cmbTeam.SelectedItem & "','" & fecha & "','" & Mes & "','" & My.Computer.Name & "')")
                    Form2.conexionLocal = New SqlConnection(Form2.miCadena)
                    Form2.conexionLocal.Open()
                    sqlInsert.Connection = Form2.conexionLocal
                    sqlInsert.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Form2.conexionLocal.Close()
        MessageBox.Show("Se han agregado con éxito las filas afectadas")
        Me.DataGridView1.Enabled = False
        Me.btnGuardar.Enabled = False
    End Sub
End Class