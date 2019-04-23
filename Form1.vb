Imports System
Imports System.Data.SqlClient
Public Class Comisiones
    Public cadena As String = "Data Source=SWCServer;Initial Catalog=SBO_COSPERFUSION_SV;user=sa; password=adminsql"
    Public conexion As SqlConnection = New SqlConnection(cadena)
    Public lector As SqlDataReader
    Public DbSAP, OwnDb As DataSet
    Public Adapter As SqlDataAdapter
    Public number As Object
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Control de Viñetas Comisiones"
        Me.Name = "frmCapturaNew"
        Dim Splash As New SplashScreen1
        Me.Opacity = 0
        With Splash.Timer1
            .interval = 1500
            .Enabled = True
        End With
        Splash.ShowDialog(Me)
        Splash.Dispose()
        Try
            Conectar()
            Dim miSentencia As String = "Select OITM.ItemCode, OITM.CodeBars,OITM.ItemName,ITM1.Price,OITM.U_CLASES From OITM " _
            & "INNER JOIN ITM1 ON OITM.ItemCode=ITM1.ItemCode INNER JOIN OITW ON OITM.ItemCode=OITW.ItemCode Where OITW.WhsCode Between'" & "00101'" & "AND'" & "00105'" & " AND PriceList=1"
            Dim comnd As SqlCommand = New SqlCommand(miSentencia, conexion)
            Adapter = New SqlDataAdapter(comnd)
            DbSAP = New DataSet()
            Adapter.Fill(DbSAP, "Item")
            Adapter.Dispose()
            comnd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cerrar_Conexion()
    End Sub

    Private Sub PedidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidoToolStripMenuItem.Click
        Dim frmIngreso As New Form2
        frmIngreso.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub Conectar()
        If conexion.State = ConnectionState.Closed Then
            conexion.Open()
        End If
    End Sub
    Private Sub Cerrar_Conexion()
        If conexion.State = ConnectionState.Open Then
            conexion.Close()
        End If
    End Sub

    Private Sub PedidoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PedidoToolStripMenuItem1.Click
        number = InputBox("Ingrese numero de pedido: ", "PEDIDO NUMERO?")
        If (number = Nothing) Or (number = "") Or (IsNumeric(number) = False) Then
            MessageBox.Show("Verifique por favor el numero que está introduciendo, que sea un valor válido", "ADVERTENCIA")
            Exit Sub
        Else
            Try
                Dim frmEdit As Form2 = New Form2(number)
                If (frmEdit.DsLocal.Tables("Encabezado").Rows.Count > 0) Then
                    frmEdit.Show()
                    Try
                        'Llenando formulario de acuerdo a los resultados obtenidos
                        frmEdit.Label7.Text = frmEdit.DsLocal.Tables("Encabezado").Rows(0).Item(0)
                        frmEdit.txtDate.Text = frmEdit.DsLocal.Tables("Encabezado").Rows(0).Item(5).ToString
                        frmEdit.txtSalesPersonCode.Text = frmEdit.DsLocal.Tables("Encabezado").Rows(0).Item(1).ToString
                        frmEdit.cmbBrandCode.SelectedItem = frmEdit.DsLocal.Tables("Encabezado").Rows(0).Item(2).ToString
                        frmEdit.cmbBrandName.SelectedItem = frmEdit.cmbBrandName.Items.Item(frmEdit.cmbBrandCode.SelectedIndex)
                        frmEdit.cmbStoreCode.SelectedItem = frmEdit.DsLocal.Tables("Encabezado").Rows(0).Item(3).ToString
                        frmEdit.cmbStoreName.SelectedItem = frmEdit.cmbStoreName.Items.Item(frmEdit.cmbStoreCode.SelectedIndex)
                        frmEdit.cmbSucursalCode.SelectedItem = frmEdit.DsLocal.Tables("Encabezado").Rows(0).Item(4).ToString
                        frmEdit.cmbSucursalName.SelectedItem = frmEdit.cmbSucursalName.Items.Item(frmEdit.cmbSucursalCode.SelectedIndex)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    MessageBox.Show("Numero de pedido no existe", "Tome nota")
                End If
            Catch ex As NullReferenceException
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub AlmacénToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlmacénToolStripMenuItem.Click
        Dim frmStore As New NuevoAlmacen
        frmStore.lblCode.Text = "Codigo de Almacén :"
        frmStore.lblName.Text = "Nombre del Almacén :"
        frmStore.btnSave.Text = "Guardar"
        frmStore.btnCancel.Text = "Salir"
        frmStore.Text = "Nuevo Almacén"
        frmStore.Show()
    End Sub

    Private Sub MarcaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcaToolStripMenuItem.Click
        Dim frmBrand As New NuevoAlmacen
        frmBrand.Text = "Nueva Marca"
        frmBrand.lblName.Text = " Nombre de Marca:"
        frmBrand.lblCode.Text = " Codigo de Marca:"
        frmBrand.Show()
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SucursalToolStripMenuItem.Click
        Dim frmSucursal As New NuevoAlmacen
        frmSucursal.lblName.Text = " Nombre de Sucursal:"
        frmSucursal.lblCode.Text = " Codigo de Sucursal:"
        frmSucursal.Show()
    End Sub
    Private Sub CuotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuotasToolStripMenuItem.Click
        Dim EditCuotas As New EditCuotasForm
        EditCuotas.Show()
    End Sub

    Private Sub CuotasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuotasToolStripMenuItem1.Click
        number = InputBox("¿¿Para que equipo alimentará las cuotas??")
        Dim frmCuotas As New CuotasForm(number)
        frmCuotas.lblTopic.Text = "Alimentacion de Cuotas por Consejera para el mes de: "
        frmCuotas.lblTeam.Text = "Equipo :"
        frmCuotas.Show()
    End Sub
    Private Sub ParaCuotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParaCuotasToolStripMenuItem.Click
        Dim mes, year As Integer
        Form2.conexionLocal = New SqlConnection(Form2.miCadena)
        If (MessageBox.Show("Recuerde que para correr este procedimiento ya deben haber terminado el ingreso de las viñetas para todos los Equipos y debe haber alimentado las cuotas también de todos los equipos. ¿Realmente desea continuar?", "ADVERTENCIA", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            'Capturando el numero de mes que necesito para calcular la venta acumulada e insertarla en la tabla omónima
            mes = InputBox("Ingrese el mes en número para calcular para las comisiones", "GRACIAS")
            year = InputBox("Ingrese el Año en número para calcular para las comisiones", "GRACIAS")
            'Construyendo la venta acumulada por cada uno de los equipos segun las marcas 01%, 02%,03% y 04%
            Dim sqlventa As New SqlCommand
            Form2.conexionLocal.Open()
            Try
                sqlventa.CommandText = ("Insert into Ventas (Codigo_Consejera, Venta_Acumulada, Mes) " _
                               & "select T0.Codigo_Consejera, SUM(T1.Precio_Articulo) as ""Venta_Acumulada"", '" & mes & "' " _
                               & "From dbo.Transacciones as T0 inner join dbo.Detalle as T1 " _
                               & "On T0.Pedido_numero = T1.Pedido_numero " _
                               & "Where month(T0.Fecha) = '" & mes & "'and year(T0.Fecha)='" & year & "' Group by T0.Codigo_Consejera")
                sqlventa.Connection = Form2.conexionLocal
                sqlventa.ExecuteNonQuery()
                MessageBox.Show("ventas acumuladas calculadas con exito")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Form2.conexionLocal.Close()
            End Try
            'AHORA CONSTRUYO CONSULTA PARA COMPLETAR LA TABLA DE CUOTAS Y PODER HACER LOS REPORTES
            'DEL CALCULO DE COMISIONES POR CONSEJERA POR EQUIPO
            Dim sqlSale As SqlCommand = New SqlCommand("Update Cuotas Set Cuotas.Venta_Acumulada=Ventas.Venta_Acumulada, " _
            & "Fecha_Modificacion='" & Now & "'From Ventas inner join Cuotas " _
            & "On Ventas.Codigo_Consejera=Cuotas.Codigo_Consejera Where Ventas.Mes='" & mes & "'")
            Form2.conexionLocal = New SqlConnection(Form2.miCadena)
            Form2.conexionLocal.Open()
            sqlSale.Connection = Form2.conexionLocal
            Try
                sqlSale.ExecuteNonQuery()
                MessageBox.Show("Tabla Cuotas llenada con exito")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Form2.conexionLocal.Close()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub ConsejerasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsejerasToolStripMenuItem.Click
        Dim EditConsejeras As New ConsejerasForm
        EditConsejeras.Show()
    End Sub
End Class
