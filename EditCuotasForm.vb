Imports System.Data
Imports System.Data.SqlClient
Public Class EditCuotasForm
    Dim CuotaSet As DataSet1
    Dim cuotAdapter As SqlDataAdapter
    Dim ConsejeraBuilder As SqlCommandBuilder
    Private Sub ConsejerasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Comisiones
        Form2.conexionLocal = New SqlConnection(Form2.miCadena)
        Try
            Form2.conexionLocal.Open()
            cuotAdapter = New SqlDataAdapter("Select Codigo_Consejera, Nombre_Consejera,Venta_Acumulada,Cuota,Equipo,Mes_Calculo From Cuotas", Form2.conexionLocal)
            ConsejeraBuilder = New SqlCommandBuilder(cuotAdapter)
            CuotaSet = New DataSet1
            cuotAdapter.Fill(CuotaSet, "Cuotas")
            Me.DataGridView1.DataSource = CuotaSet
            Me.DataGridView1.DataMember = "Cuotas"
            Me.DataGridView1.Columns("Codigo_Consejera").HeaderText = "Codigo"
            Me.DataGridView1.Columns("Nombre_Consejera").HeaderText = "Nombre"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Form2.conexionLocal.Close()
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If CuotaSet.HasChanges Then
            Dim filas As Integer, i As Integer
            filas = CuotaSet.Tables("Cuotas").Rows.Count
            For i = 0 To filas - 1
                If CuotaSet.Tables("Cuotas").Rows(i).RowState = DataRowState.Added Or CuotaSet.Tables("Cuotas").Rows(i).RowState = DataRowState.Modified Then
                    If IsDBNull(CuotaSet.Tables("Cuotas").Rows(i).Item("Codigo_Consejera")) Or IsDBNull(CuotaSet.Tables("Cuotas").Rows(i).Item("Nombre_Consejera")) Or IsDBNull(CuotaSet.Tables("Cuotas").Rows(i).Item("Venta_Acumulada")) Or IsDBNull(CuotaSet.Tables("Cuotas").Rows(i).Item("Cuota")) Then
                        MessageBox.Show("Por favor llenar los campos que son necesarios", "IMPORTANTE")
                        Exit Sub
                    End If
                End If
            Next
            Try
                Form2.conexionLocal = New SqlConnection(Form2.miCadena)
                Form2.conexionLocal.Open()
                Me.cuotAdapter.Update(CuotaSet, "Cuotas")
                MessageBox.Show("Tabla Cuotas actualizada con éxito")
            Catch ex As DuplicateNameException
                MessageBox.Show("No se puede Actualizar pues esta duplicado un codigo")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Form2.conexionLocal.Close()
        Else
            MessageBox.Show("No han habido cambios")
        End If
    End Sub
End Class