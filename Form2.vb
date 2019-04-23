Imports System.Data
Imports System.Data.SqlClient
Public Class Form2
    Public SalesPersonCode As String
    Public conexionLocal As SqlConnection
    Public miLector As SqlDataReader
    Public miCadena As String = "Data Source=AUXINFORMATICA; Initial Catalog=Comisiones; user=sa; password=adminsql"
    Public DsLocal As DataSet
    Public miComando, miComandoDetalle As SqlCommand
    Public lineas As Integer
    Public Adaptador, adaptadorDetalle As SqlDataAdapter
    Public pedido As Integer
    Dim flag As Boolean 'This flag is true when are modifying an Order
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llenar_Combo_Almacen()
        Llenar_Combo_Marca()
        Llenar_Combo_Sucursal()
    End Sub
    Public Sub New()
        InitializeComponent()
        flag = False
        'Averiguando el numero de pedido para poder
        'controlar a mas de un usuario accediendo a guardar los datos
        Dim miConexion As New SqlConnection(miCadena)
        miComando = New SqlCommand("Select IDENT_CURRENT('Transacciones')", miConexion)
        Dim resultado As String
        miConexion.Open()
        resultado = CInt(miComando.ExecuteScalar()) + 1
        Me.Label7.Text = resultado
        miConexion.Close()
        Me.DataGridView1.Enabled = False
        Me.Text = "Ingreso de Datos"
        Me.MdiParent = Comisiones
        Me.txtDate.Text = DateAdd(DateInterval.Month, -1, Now())
        'Me.DataGridView1.Columns.Clear()
        Me.DataGridView1.Columns.Add("CodeBar", "Codigo de Barra")
        Me.DataGridView1.Columns(0).Width = 107
        Me.DataGridView1.Columns.Add("ItemName", "Description")
        Me.DataGridView1.Columns(1).Width = 200
        Me.DataGridView1.Columns(1).ReadOnly = True
        Me.DataGridView1.Columns.Add("Price", "Precio")
        Me.txtSalesName.Enabled = False
        Me.txtDate.Enabled = False
    End Sub
    Public Sub New(ByVal numero As Object)
        'Formulario que carga con los datos del pedido existente que será modificado
        'Ocupo escenario conectado pues solo será un momento que se cargarán los datos.
        InitializeComponent()
        flag = True
        Me.MdiParent = Comisiones
        pedido = numero
        Try
            conexionLocal = New SqlConnection(miCadena)
            conexionLocal.Open()
            Dim miSQL As SqlCommand = New SqlCommand("Select Pedido_Numero, Codigo_Consejera,Marca,Codigo_Almacen,Codigo_Sucursal,Fecha From Transacciones Where Pedido_Numero ='" & pedido & "'", conexionLocal)
            Adaptador = New SqlDataAdapter(miSQL)
            miComandoDetalle = New SqlCommand("Select Numero_Linea,Pedido_Numero,Codigo_Articulo,Precio_Articulo From Detalle Where Pedido_Numero ='" & pedido & "'", conexionLocal)
            adaptadorDetalle = New SqlDataAdapter(miComandoDetalle)
            DsLocal = New DataSet
            Adaptador.Fill(DsLocal, "Encabezado")
            adaptadorDetalle.Fill(DsLocal, "Detalle")
            conexionLocal.Close()
            DataGridView1.DataSource = DsLocal
            DataGridView1.DataMember = "Detalle"
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Refresh()
            Valor_Total_Grid()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If (MessageBox.Show("¿¿Desea salir realmente??", "Cerrar Programa", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
            Me.Dispose()
        End If
    End Sub
    Private Sub txtSalesPersonCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesPersonCode.Leave
        'llenando el campo de Nombre de Consejera en base al numero que se ha introducido
        'cuando se cambia de campo el nombre es introducido.
        SalesPersonCode = Me.txtSalesPersonCode.Text
        Dim miConexion As New SqlConnection(miCadena)
        Dim miComando As SqlCommand = New SqlCommand("Select Nombre, Apellidos From Consejeras Where Codigo_Consejera='" & SalesPersonCode & "'", miConexion)
        Try
            miConexion.Open()
            Dim miLector As SqlDataReader = miComando.ExecuteReader()
            If miLector.HasRows Then
                Do While miLector.Read
                    Me.txtSalesName.Text = miLector.Item(0) & " " & miLector.Item(1)
                Loop
                Me.DataGridView1.Enabled = True
            Else
                MessageBox.Show("Nada que mostrar")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_Row_Leave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim indice As Integer
        Dim Barra As String
        Dim lineas() As DataRow
        indice = e.RowIndex
        If flag = True Then
            Barra = Me.DataGridView1.Rows(indice).Cells.Item("Codigo_Articulo").Value
            Try
                lineas = My.Forms.Comisiones.DbSAP.Tables("Item").Select("CodeBars='" & Barra & "'")
                Me.DataGridView1.Rows(indice).Cells.Item("Codigo_Articulo").Value = lineas(0).Item(1)
                'Me.DataGridView1.Rows(indice).Cells.Item("ItemName").Value = lineas(0).Item(2)
                Me.DataGridView1.Rows(indice).Cells.Item("Precio_Articulo").Value = lineas(0).Item(3)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Barra = Me.DataGridView1.Rows(indice).Cells.Item("CodeBar").Value
            Try
                lineas = My.Forms.Comisiones.DbSAP.Tables("Item").Select("CodeBars='" & Barra & "'")
                Me.DataGridView1.Rows(indice).Cells.Item("CodeBar").Value = lineas(0).Item(1)
                Me.DataGridView1.Rows(indice).Cells.Item("ItemName").Value = lineas(0).Item(2)
                Me.DataGridView1.Rows(indice).Cells.Item("Price").Value = lineas(0).Item(3)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Dim NoPedido, almacen, sucursal, marca, Vendedor As String
        Dim fecha As Date
        'este IF es para comprobar el estado de la bandera False = pedido nuevo
        If flag = False Then
            If (Me.txtSalesPersonCode.Text = "") Or (Me.cmbBrandCode.SelectedItem = "") Or (Me.cmbSucursalCode.SelectedItem = "") Or (Me.cmbStoreCode.SelectedItem = "") Then
                MessageBox.Show("no puede quedar ningun campo en blanco o letras en la cuadricula", "Encabezado")
            Else
                If Me.DataGridView1.Rows.Count = 1 Then
                    MessageBox.Show("debe agregar por lo menos un valor al pedido", "Detalle")
                Else
                    If (MessageBox.Show("Esta seguro a proceder con guardar este pedido?", "Guardar Cambios", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel) Then
                        Exit Sub
                    Else
                        Try
                            fecha = Me.txtDate.Text.ToString
                            almacen = Me.cmbStoreCode.SelectedItem.ToString
                            sucursal = Me.cmbSucursalCode.SelectedItem.ToString
                            marca = Me.cmbBrandCode.SelectedItem.ToString
                            Vendedor = Me.txtSalesPersonCode.Text.ToString
                            'Inserta la informacion en cada una de las tablas
                            conexionLocal = New SqlConnection(miCadena)
                            conexionLocal.Open()
                            miComando.CommandText = ("Insert Into Transacciones (Fecha,Codigo_Consejera,Marca,Codigo_Almacen,Codigo_Sucursal,Fecha_modificacion) " _
                            & " VALUES ('" & Mid(fecha, 1, 19) & "','" & Vendedor & "','" _
                            & marca & "','" & almacen & "','" _
                            & sucursal & "','" & Mid(fecha, 1, 19) & "')")
                            miComando.Connection = conexionLocal
                            miComando.ExecuteNonQuery()
                            conexionLocal.Close()
                            'insertando filas del DataGridView1 en la tabla Detalle 
                            conexionLocal.Open()
                            'cuenta cuantas filas tiene el grid que capturó los valores
                            Dim i As Integer = Me.DataGridView1.Rows.Count
                            NoPedido = Label7.Text.ToString
                            'inicia el lazo para guardar la info en Tbla Detalle
                            miComandoDetalle = New SqlCommand
                            miComandoDetalle.Connection = conexionLocal
                            For j As Integer = 0 To i - 2
                                miComandoDetalle.CommandText = ("Insert Into Detalle (Pedido_numero,Codigo_Articulo,Precio_Articulo) " _
                                & " VALUES ('" & (NoPedido) & "','" & Me.DataGridView1.Rows(j).Cells.Item(0).Value.ToString & "','" & Me.DataGridView1.Rows(j).Cells.Item(2).Value.ToString & "')")
                                miComandoDetalle.ExecuteNonQuery()
                            Next j
                            MessageBox.Show("Se han agregado correctamente las filas", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            conexionLocal.Close()
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString, ex.Message)
                        End Try
                    End If
                    Me.DataGridView1.Rows.Clear()
                    Me.Close()
                End If
            End If
        Else
            'Actualiza la base de datos con las modificaciones hechas por el usuario
            'ocupo un DataAdapter y un DataSet para poder actualizar la BD(Tabla detalle).
            'por alguna razón las filas agregadas no me las actualizaba por eso tuve
            'que agregarlas manuelmente. Las filas eliminadas y modificadas si se actualizan
            'con el update del Adapter.
            'Try
            Dim agregadas As Integer = 0
            Dim filas As Integer = Me.DataGridView1.Rows.Count - 2
            miLector.Close()
            conexionLocal = New SqlConnection(miCadena)
            conexionLocal.Open()
            miComandoDetalle.Connection = conexionLocal
            For i As Integer = 0 To filas
                If Me.DsLocal.Tables("Detalle").Rows(i).RowState = DataRowState.Added Then
                    miComandoDetalle.CommandText = ("Insert Into Detalle (Pedido_numero,Codigo_Articulo,Precio_Articulo) " _
                    & " VALUES ('" & (pedido) & "','" & Me.DsLocal.Tables("Detalle").Rows(i).Item("Codigo_Articulo") & "','" & Me.DsLocal.Tables("Detalle").Rows(i).Item("Precio_Articulo") & "')")
                    miComandoDetalle.ExecuteNonQuery()
                    agregadas += 1
                ElseIf (Me.DsLocal.Tables("Detalle").Rows(i).RowState = DataRowState.Modified) Then
                    Dim UpdateText As String
                    UpdateText = "Update Detalle SET Precio_Articulo='" & Me.DsLocal.Tables("Detalle").Rows(i).Item("Precio_Articulo") & "'" & _
                    "Where Pedido_Numero='" & pedido & "' And Numero_Linea='" & Me.DsLocal.Tables("Detalle").Rows(i).Item("Numero_Linea") & "'"
                    Adaptador.UpdateCommand = New SqlCommand(UpdateText, conexionLocal)
                    miComandoDetalle.ExecuteNonQuery()
                End If
            Next i
            miComando = New SqlCommand
            conexionLocal = New SqlConnection(miCadena)
            conexionLocal.Open()
            miComando.Connection = conexionLocal
            miComando.CommandText = ("Update Transacciones SET Fecha='" & Mid(Me.txtDate.Text, 1, 19) & "',Codigo_Consejera='" _
            & Me.txtSalesPersonCode.Text & "',Marca='" & Me.cmbBrandCode.SelectedItem & "', Codigo_Almacen='" _
            & Me.cmbStoreCode.SelectedItem & "', Codigo_Sucursal='" _
            & Me.cmbSucursalCode.SelectedItem & "', Fecha_modificacion='" _
            & Mid(DateTime.Now, 1, 19) & "' WHERE Pedido_Numero ='" & pedido & "'")
            miComando.ExecuteNonQuery()
            Me.Adaptador.Update(Me.DsLocal, "Detalle")
            MessageBox.Show("Actualizacion exitosa")
            'Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString)
            Exit Sub
            'Finally
            conexionLocal.Close()
            miLector.Close()
            Me.Close()
            'End Try
        End If
    End Sub
    Public Sub Valor_Total_Grid()
        Dim lineas_Grid As Integer
        Dim total As Double
        lineas_Grid = Me.DataGridView1.Rows.Count
        total = 0
        If flag = False Then
            For i As Integer = 0 To lineas_Grid - 2
                total = total + Me.DataGridView1.Rows(i).Cells.Item("Price").Value
            Next
            txtTotal.Text = total
        Else
            For i As Integer = 0 To lineas_Grid - 2
                total = total + Me.DataGridView1.Rows(i).Cells.Item(3).Value
            Next
            txtTotal.Text = total
        End If
    End Sub
    Private Sub Llenar_Combo_Marca()
        'Llenando Combo de Marcas
        Dim MySQL As New SqlCommand
        conexionLocal = New SqlConnection(miCadena)
        MySQL.CommandText = ("Select Codigo_Marca,Nombre_Marca From Marcas")
        miLector = Nothing
        MySQL.Connection = conexionLocal
        conexionLocal.Open()
        Try
            miLector = MySQL.ExecuteReader
            Do While miLector.Read
                cmbBrandName.Items.Add(miLector.Item("Nombre_Marca"))
                cmbBrandCode.Items.Add(miLector.Item("Codigo_Marca"))
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conexionLocal.Close()
    End Sub
    Private Sub Llenar_Combo_Almacen()
        conexionLocal = New SqlConnection(miCadena)
        'Llenando Combos de Almacenes
        Dim mySQL As New SqlCommand
        mySQL.CommandText = ("select Nombre_Almacen, Codigo_Almacen From Almacenes")
        miLector = Nothing
        mySQL.Connection = conexionLocal
        conexionLocal.Open()
        Try
            miLector = mySQL.ExecuteReader
            Do While miLector.Read
                cmbStoreName.Items.Add(miLector.Item("Nombre_Almacen"))
                cmbStoreCode.Items.Add(miLector.Item("Codigo_Almacen"))
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        conexionLocal.Close()
    End Sub
    Private Sub Llenar_Combo_Sucursal()
        'Lenando ComboBox de Sucursal
        Dim mySQL As New SqlCommand
        conexionLocal = New SqlConnection(miCadena)
        mySQL.CommandText = ("Select Nombre_Sucursal, Codigo_Sucursal From Sucursales")
        miLector = Nothing
        mySQL.Connection = conexionLocal
        conexionLocal.Open()
        Try
            miLector = mySQL.ExecuteReader
            Do While miLector.Read
                cmbSucursalName.Items.Add(miLector.Item("Nombre_Sucursal"))
                cmbSucursalCode.Items.Add(miLector.Item("Codigo_Sucursal"))
            Loop
        Catch ex As Exception
        End Try
        conexionLocal.Close()
    End Sub

    Private Sub cmbBrandName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrandName.SelectedIndexChanged
        'If flag = True Then
        Me.cmbBrandCode.SelectedItem = Me.cmbBrandCode.Items.Item(Me.cmbBrandName.SelectedIndex)
        'End If
    End Sub

    Private Sub cmbStoreName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStoreName.SelectedIndexChanged
        'If flag = True Then
        Me.cmbStoreCode.SelectedItem = Me.cmbStoreCode.Items.Item(Me.cmbStoreName.SelectedIndex)
        'End If
    End Sub

    Private Sub cmbSucursalName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursalName.SelectedIndexChanged
        'If flag = True Then
        Me.cmbSucursalCode.SelectedItem = Me.cmbSucursalCode.Items.Item(Me.cmbSucursalName.SelectedIndex)
        'End If
    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Me.Valor_Total_Grid()
    End Sub
End Class