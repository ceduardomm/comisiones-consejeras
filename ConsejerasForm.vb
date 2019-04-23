Imports System.Data
Imports System.Data.SqlClient
Public Class ConsejerasForm
    Dim ConsejeraSet As DataSet1
    Dim consejerAdapter As SqlDataAdapter
    Dim ConsejeraBuilder As SqlCommandBuilder
    Private Sub ConsejerasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = Comisiones
        Form2.conexionLocal = New SqlConnection(Form2.miCadena)
        Try
            Form2.conexionLocal.Open()
            consejerAdapter = New SqlDataAdapter("Select Codigo_Consejera, Nombre, Apellidos,Equipo From Consejeras", Form2.conexionLocal)
            ConsejeraBuilder = New SqlCommandBuilder(consejerAdapter)
            ConsejeraSet = New DataSet1
            consejerAdapter.Fill(ConsejeraSet, "Consejeras")
            Me.DataGridView1.DataSource = ConsejeraSet
            Me.DataGridView1.DataMember = "Consejeras"
            Me.DataGridView1.Columns("Codigo_Consejera").HeaderText = "Codigo"
            Me.DataGridView1.Columns("Nombre").HeaderText = "Nombre"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Form2.conexionLocal.Close()
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If ConsejeraSet.HasChanges Then
            Dim filas As Integer, i As Integer
            filas = ConsejeraSet.Tables("Consejeras").Rows.Count
            For i = 0 To filas - 1
                If ConsejeraSet.Tables("Consejeras").Rows(i).RowState = DataRowState.Added Or ConsejeraSet.Tables("Consejeras").Rows(i).RowState = DataRowState.Modified Then
                    If IsDBNull(ConsejeraSet.Tables("Consejeras").Rows(i).Item("Codigo_Consejera")) Or IsDBNull(ConsejeraSet.Tables("Consejeras").Rows(i).Item("Nombre")) Or IsDBNull(ConsejeraSet.Tables("Consejeras").Rows(i).Item("Apellidos")) Or IsDBNull(ConsejeraSet.Tables("Consejeras").Rows(i).Item("Equipo")) Then
                        MessageBox.Show("Por favor llenar los 4 campos que son necesarios", "IMPORTANTE")
                        Exit Sub
                    End If
                End If
            Next
            Try
                Form2.conexionLocal = New SqlConnection(Form2.miCadena)
                Form2.conexionLocal.Open()
                Me.consejerAdapter.Update(ConsejeraSet, "Consejeras")
                MessageBox.Show("Tabla Consejeras actualizada con éxito")
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