using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Configuration;
using Proyecto_Metodologia.Cartera;
using Proyecto_Metodologia.Clientes;
using Proyecto_Metodologia.Dtos;
using Proyecto_Metodologia.Ventas;
using Proyecto_Metodologia.Productos;
using TextBox = System.Windows.Forms.TextBox;


namespace Proyecto_Metodologia
{
    public partial class FrmVentas : Form

    {
        private PrintDocument printDocument;
        private DataSet aDatos;
        public static TextBox txtPublico;
        ClienteRepository _cliente = new ClienteRepository();
        Factura _factura = new Factura();
        ProductoRepository _producto = new ProductoRepository();


        public FrmVentas()
        {
            InitializeComponent();
            autoincrementable();
            this.KeyDown += FrmVentas_KeyDown;
            this.KeyPreview = true;
            this.Shown += FrmVentas_Shown;
            nupcantidad.KeyPress += nupcantidad_KeyPress; // Registro del evento KeyPress para nupcantidad

            txtcodp.PreviewKeyDown += txtcodp_PreviewKeyDown;
            printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            _factura.PrintDocument_PrintPageCustom(sender, e, txtCodVentas.Text, dgvVentas);
            txtPublico = txtcodp;
            tipoVenta.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
        }

        public IWin32Window Ventatotal { get; private set; }

        #region Eventos
        private void tipoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // Seleccionar ítem anterior
                if (tipoVenta.SelectedIndex > 0)
                {
                    tipoVenta.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                // Seleccionar ítem siguiente
                if (tipoVenta.SelectedIndex < tipoVenta.Items.Count - 1)
                {
                    tipoVenta.SelectedIndex++;
                }
            }
        }
        private void FrmVentas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    CerrarVenta();
                    e.Handled = true;

                    break;

                case Keys.F2:
                    txtcodp.Enabled = false;
                    txtEfectivo.Enabled = false;
                    txtCambio.Enabled = false;
                    // Activar selección si no hay fila seleccionada
                    if (dgvVentas.SelectedRows.Count == 0 && dgvVentas.Rows.Count > 0)
                        dgvVentas.Rows[0].Selected = true;
                    break;

                case Keys.F3:
                    FrmSalidaEfectivo salida = new FrmSalidaEfectivo();
                    salida.Show();
                    break;

                case Keys.F4:
                    FrmEntradaefectivo entrada = new FrmEntradaefectivo();
                    entrada.Show();
                    break;

                case Keys.F6:
                    FrmArqueo arqueo = new FrmArqueo();
                    arqueo.Show();
                    break;
                case Keys.Enter:
                    EliminarFila_Enter(e);
                    break;
                case Keys.Up:
                    NavegacionXFlechas(e);
                    break;

                case Keys.Down:
                    NavegacionXFlechas(e);
                    break;


                default:
                    // Opcional: manejar otras teclas si es necesario
                    break;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (tipoVenta.SelectedItem.ToString() == "Efectivo")
                    {
                        // Convertir los valores a double
                        double totalAPagar = double.Parse(txtTotalPagar.Text);
                        double efectivo = double.Parse(txtEfectivo.Text);
                        // Validar que el efectivo no sea menor que el total a pagar
                        if (efectivo < totalAPagar)
                        {
                            MessageBox.Show("El valor del efectivo no puede ser menor que el total a pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEfectivo.Focus();
                            return;
                        }
                        // Calcular el cambio
                        double cambio = efectivo - totalAPagar;
                        // Mostrar el cambio en textBox2
                        txtCambio.Text = Math.Round(cambio, 2).ToString();
                        txtCambio.Focus();
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            var cliente = _cliente.ObtenerInfoCliente(txtDocumentoCliente.Text);

            txtNombreCliente.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            txtCorreo.Text = cliente.Correo;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)  // 13 es el valor ASCII de la tecla Enter
            {
                TransaccionVenta();
            }
        }
        private void txtAbono_KeyDown(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)  // 13 es el valor ASCII de la tecla Enter
            {
                TransaccionVenta();
            }
        }

        private void nupcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Detectar si la tecla presionada es 'Enter'
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evitar el comportamiento por defecto de Enter (cambiar foco)
                // Llamar a la función para agregar los datos al DataGridView
                button3_Click_1(sender, e);
            }
            // Verificar si la unidad seleccionada es "Unidad" y evitar valores decimales
            string unidad = ValorAtributo("Unidad"); // Obtener la unidad del producto
            if (unidad == "Unidad")
            {
                // Si la tecla presionada no es un número y no es la tecla de retroceso
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; // Evitar la entrada de caracteres no numéricos
                }
                // Si el texto ya contiene un punto decimal, evitar otro punto decimal
                if (e.KeyChar == '.' && nupcantidad.Text.Contains("."))
                {
                    e.Handled = true; // Evitar múltiples puntos decimales
                }
            }
        }
        private void FrmVentas_Shown(object sender, EventArgs e)
        {
            SetFocusToTxtCodp();
        }
        public DataSet Datos
        {
            get { return aDatos; }
        }
        private void txtcodp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;

                if (!string.IsNullOrWhiteSpace(txtcodp.Text))
                    CargarDatosProducto(txtcodp.Text, GetUnidadmedida());
                else
                    MessageBox.Show("Código de producto vacío. Escanee nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcodp.Focus();
            }
        }
        private ComboBox GetUnidadmedida()
        {
            return Unidadmedida;
        }
        private void CargarDatosProducto(string codigo, ComboBox unidadmedida)
        {
            string[] datos = _producto.obtenerDatos(codigo);

            if (!string.IsNullOrWhiteSpace(datos[0]))
            {
                // Asignar los datos a los controles del formulario
                txtcodp.Text = datos[0];  // Código del producto
                txtnombre.Text = datos[1];  // Descripción del producto

                // Llenar el ComboBox solo con la unidad obtenida de la base de datos
                unidadmedida.Items.Clear();
                if (!string.IsNullOrWhiteSpace(datos[2])) unidadmedida.Items.Add(datos[2]);  // Solo Unidad

                // Establecer el primer valor como el seleccionado
                if (unidadmedida.Items.Count > 0)
                {
                    unidadmedida.SelectedIndex = 0;
                }

                txtpreciou.Text = datos[6];  // Precio unitario
                txtStock.Text = datos[8];  // Asignamos la cantidad al txtStock
                Txtiva.Text = datos[7];

                if (datos[8] == "0")
                {
                    MessageBox.Show("No hay stock disponible para este producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcodp.Focus();
                    return;
                }

                // Verificar si la unidad es "GRAMO" y ajustar el precio si es necesario
                string unidad = ValorAtributo("Unidad");

                if (unidad == "GRAMO")
                {
                    decimal precioUnidad = Convert.ToDecimal(txtpreciou.Text);
                    txtpreciou.Text = (precioUnidad / 1000).ToString("F3");  // Convertir a gramos
                }

                nupcantidad.Focus();
            }
            else
            {
                MessageBox.Show("Producto no encontrado. Verifique el código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetFocusToTxtCodp();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                double preciounidad = double.Parse(txtpreciou.Text);
                double cantidad = Convert.ToDouble(nupcantidad.Text);  // Obtener la cantidad ingresada
                double iva = double.Parse(Txtiva.Text) / 100;

                string unidad = ValorAtributo("Unidad");

                // Si la unidad es "Kilo", convertir la cantidad a gramos
                if (unidad == "Kilo")
                {
                    cantidad *= 1000;
                }

                double total = cantidad * preciounidad;
                txtTotalPagar.Text = total.ToString();

                dgvVentas.Rows.Add(txtcodp.Text, txtnombre.Text, nupcantidad.Text.ToString(), total.ToString("0"), iva.ToString());

                calculartotal();
                clear();
            }
            catch
            {
                MessageBox.Show("INGRESA UN PRODUCTO");
            }
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {


            // Código que se ejecutará después de que se cierre frmAperturacaja
            to.Text = "0";
            txtigv.Text = "0";
            txttotal.Text = "0";

            Conexion();
            AutoCompletar(txtcodp);

        }
        private void tipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarOpcionPago(tipoVenta.SelectedItem.ToString());
        }
        #endregion



        #region FUNCIONES
        public void Conexion()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
                cnn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar: " + ex.ToString());
            }
        }
        private void TransaccionVenta()
        {
            try
            {
                CarteraRepository _cartera = new CarteraRepository();


                // validar que no sea un cliente generico para registrar el cliente
                if (txtDocumentoCliente.Text != "2222222222" && !_cliente.ValidarCliente(txtDocumentoCliente.Text))
                {
                    _cliente.InsertarCliente(new ClienteDto()
                    {
                        Documento = txtDocumentoCliente.Text,
                        Nombre = txtNombreCliente.Text,
                        Apellido = txtApellido.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text


                    });
                }
                //validar cliente para realizar venta a credito
                if (txtDocumentoCliente.Text != "2222222222" && tipoVenta.SelectedItem.ToString() == "Credito")
                {

                    if (double.Parse(txtAbono.Text) < 0)
                    {
                        MessageBox.Show("Valor de abono no permitido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string codigoVenta = InsertarVenta();
                    CarteraDto cartera = new CarteraDto()
                    {
                        AbonoInicial = double.Parse(txtAbono.Text),
                        DocumentoCliente = txtDocumentoCliente.Text,
                        IdVenta = codigoVenta,
                        FechaCartera = DateTime.UtcNow,
                        EstadoCartera = "Credito Activo"
                    };
                    _cartera.InsertarCartera(cartera);
                }
                else if (txtDocumentoCliente.Text == "2222222222" && tipoVenta.SelectedItem.ToString() == "Credito")
                {
                    MessageBox.Show("No se puede acreditar una venta a un cliente desconocido, inserte los datos del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    _ = InsertarVenta();
                }

                _factura.ImprimirFactura(printDocument);
                limpiarventa();
                dgvVentas.Rows.Clear();
                autoincrementable();
                clear();
                txtDocumentoCliente.Text = "2222222222";
                txtNombreCliente.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtTelefono.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataSet EjecutarSelect(string Consulta)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                conexion.Open();
                SqlDataAdapter a = new SqlDataAdapter(Consulta, conexion);
                aDatos = new DataSet();
                a.Fill(aDatos);
                conexion.Close();
            }
            return aDatos;
        }
        public void AutoCompletar(TextBox cajaTexto)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
                // Asegurar que la conexión está abierta
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT Descripcion FROM Tproductos", cnn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Limpiar la lista antes de agregar nuevos elementos
                    cajaTexto.AutoCompleteCustomSource.Clear();

                    while (dr.Read())
                    {
                        cajaTexto.AutoCompleteCustomSource.Add(dr["Descripcion"].ToString());
                    }
                }
                // Configurar el autocompletado
                ActivarAutocompletado(cajaTexto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo autocompletar el TextBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActivarAutocompletado(TextBox cajaTexto)
        {
            cajaTexto.AutoCompleteMode = AutoCompleteMode.Suggest;
            cajaTexto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void DesactivarAutocompletado(TextBox cajaTexto)
        {
            cajaTexto.AutoCompleteMode = AutoCompleteMode.None;
            cajaTexto.AutoCompleteSource = AutoCompleteSource.None;
        }
        public void calculartotal()
        {
            double cantidad = 0;
            double subtotal = 0;
            double iva = 0;
            double ventatotal = 0;
            double tiva = 0;
            int i = 0;
            while (i < dgvVentas.RowCount)
            {
                cantidad = double.Parse(dgvVentas[3, i].Value.ToString());
                iva = double.Parse(dgvVentas[4, i].Value.ToString());
                subtotal += cantidad - cantidad * iva;
                tiva = tiva + cantidad * iva;
                i++;
            }

            ventatotal = subtotal + tiva;
            //ventaglobal.Valorglobal = ventatotal;


            to.Text = Math.Round(subtotal, 2).ToString();
            txtigv.Text = Math.Round(tiva, 2).ToString();
            txttotal.Text = Math.Round(ventatotal, 2).ToString();
            if (dgvVentas.Rows.Count == 0)
            {
                to.Text = "0.00";
                txtigv.Text = "0.00";
                txttotal.Text = "0.00";
            }
        }
        public string ValorAtributo(string pNombreCampo)
        {
            if (Datos.Tables[0].Rows.Count > 0)
            {
                return Datos.Tables[0].Rows[0][pNombreCampo].ToString();
            }
            return "";
        }
        public void clear()
        {
            txtcodp.Clear();
            txtnombre.Clear();
            txtpreciou.Clear();
            txtStock.Clear();
            nupcantidad.Text = "1";
            SetFocusToTxtCodp();
        }
        public void limpiarventa()
        {
            to.Clear();
            txtigv.Clear();
            txttotal.Clear();
            txtCodVentas.Clear();
            txtAbono.Clear();
        }
        public string ultimoValorAtributo()
        {
            string Consulta = "SELECT MAX(CodigoVenta) AS ULTIMO FROM TVentas";
            EjecutarSelect(Consulta);
            string A = ValorAtributo("ULTIMO");
            return string.IsNullOrEmpty(A) ? "00000" : A;
        }
        public void autoincrementable()
        {
            string A = ultimoValorAtributo();
            string prefix = A.Substring(0, 1);
            int numero = int.Parse(A.Substring(1)) + 1;
            string nuevoCodigo = prefix + numero.ToString("D4");

            txtCodVentas.Text = nuevoCodigo;
            txtCodVentas.Enabled = false;
        }
        private void SetFocusToTxtCodp()
        {
            if (txtcodp.Enabled && txtcodp.Visible)
            {
                txtcodp.Select();
                txtcodp.Focus();
            }
        }
        private string InsertarVenta()
        {
            string fechaVenta = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string cajero = CONSTANS.USER;
            string codigoVenta = txtCodVentas.Text;


            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    conexion.Open();

                    // Inserción de datos de la ventacliente
                    string queryVenta = "INSERT INTO TVentas (CodigoVenta, PrecioTotal, Fecha,cajero,Cliente) VALUES (@CodigoVenta, @Total, @FechaVenta,@cajero, @Cliente)";
                    using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion))

                    {
                        cmdVenta.Parameters.AddWithValue("@CodigoVenta", codigoVenta);
                        cmdVenta.Parameters.AddWithValue("@Total", txttotal.Text);
                        cmdVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                        cmdVenta.Parameters.AddWithValue("@Cajero", cajero);
                        cmdVenta.Parameters.AddWithValue("@Cliente", txtDocumentoCliente.Text);
                        cmdVenta.ExecuteNonQuery();
                    }

                    List<string> detallesVenta = new List<string>();

                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string idProducto = row.Cells[0].Value.ToString();
                            string nombre = row.Cells[1].Value.ToString();
                            //float cantidad = Convert.ToInt32(row.Cells[2].Value);
                            float cantidad = (float)Math.Round(Convert.ToSingle(row.Cells[2].Value), 1);
                            decimal precioUnidad = Convert.ToDecimal(row.Cells[3].Value);
                            decimal iva = Math.Round(precioUnidad * 0.18m, 2);


                            string queryDetalle = "INSERT INTO DetallesVenta (IdVenta, IdProducto, PrecioUnidad, Cantidad, Iva) " +
                                                  "VALUES (@IdVenta, @IdProducto, @PrecioUnidad, @Cantidad, @Iva)";
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion))
                            {
                                cmdDetalle.Parameters.AddWithValue("@IdVenta", txtCodVentas.Text);
                                cmdDetalle.Parameters.AddWithValue("@IdProducto", idProducto);
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnidad", precioUnidad);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@Iva", iva);
                                cmdDetalle.ExecuteNonQuery();
                            }

                            _producto.ActualizarStockProducto(idProducto, cantidad);

                            detallesVenta.Add($"{cantidad} x {nombre} - {precioUnidad:C}");
                        }
                    }

                    // Generar el ticket PDF
                    // Crear una nueva instancia de Form1

                    txtcodp.Enabled = true;
                    txtCambio.Visible = false;
                    txtEfectivo.Visible = false;
                    txtTotalPagar.Visible = false;
                    lbTotalPagar.Visible = false;
                    lbEfectivo.Visible = false;
                    lbCambio.Visible = false;
                    lbCobrar.Visible = false;
                    txtAbono.Visible = false;
                    labelAbono.Visible = false;
                    txtcodp.Focus();

                    // Imprimir la frase "Tienda Hector" en la impresora POS-80

                    to.Text = "0";
                    txtigv.Text = "0";
                    txttotal.Text = "0";
                    txtCambio.Text = "0";
                    txtEfectivo.Text = "0";
                    txtTotalPagar.Text = "0";

                    return codigoVenta;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception();
                }
            }
        }
        private void CambiarOpcionPago(string opcionSeleccionada)
        {
            if (opcionSeleccionada == "Credito" && lbCobrar.Visible)
            {
                txtAbono.Visible = true;
                labelAbono.Visible = true;
                lbCambio.Visible = false;
                txtCambio.Visible = false;
                txtEfectivo.Visible = false;
                lbEfectivo.Visible = false;
            }
            else if (opcionSeleccionada == "Efectivo" && lbCobrar.Visible)
            {
                txtAbono.Visible = false;
                labelAbono.Visible = false;
                lbCambio.Visible = true;
                txtCambio.Visible = true;
                txtEfectivo.Visible = true;
                lbEfectivo.Visible = true;
            }
        }

        private void NavegacionXFlechas(KeyEventArgs e) 
        {
            // Permitir navegación con flechas
            int rowIndex = dgvVentas.CurrentRow?.Index ?? -1;
            if (rowIndex >= 0)
            {
                if (e.KeyCode == Keys.Up && rowIndex > 0)
                {
                    dgvVentas.Rows[rowIndex].Selected = false;
                    dgvVentas.Rows[rowIndex - 1].Selected = true;
                    dgvVentas.CurrentCell = dgvVentas.Rows[rowIndex - 1].Cells[0];
                }
                else if (e.KeyCode == Keys.Down && rowIndex < dgvVentas.Rows.Count - 1)
                {
                    dgvVentas.Rows[rowIndex].Selected = false;
                    dgvVentas.Rows[rowIndex + 1].Selected = true;
                    dgvVentas.CurrentCell = dgvVentas.Rows[rowIndex + 1].Cells[0];
                }
                e.Handled = true;
            }
        }

        private void EliminarFila_Enter(KeyEventArgs e) 
        {
            // Eliminar la fila seleccionada con Enter
            if (dgvVentas.SelectedRows.Count > 0)
            {
                double descuento = 0;
                double total = 0;
                double descuentoiva = 0;
                double totaliva = 0;
                double nuevoiva = 0;
                double dessubtotal = 0;
                double nuevosubtotal = 0;
                double totalsubtotal = 0;


                int rowIndex = dgvVentas.SelectedRows[0].Index;
                double valor = Convert.ToDouble(dgvVentas.Rows[rowIndex].Cells["Total"].Value);
                double iva = Convert.ToDouble(dgvVentas.Rows[rowIndex].Cells["Iva"].Value);
                dgvVentas.Rows.RemoveAt(rowIndex);

                total = double.Parse(txttotal.Text);

                descuento = total - valor;
                descuentoiva = valor * iva;
                totaliva = double.Parse(txtigv.Text);
                nuevoiva = totaliva - descuentoiva;
                dessubtotal = valor - descuentoiva;
                totalsubtotal = double.Parse(to.Text);
                nuevosubtotal = totalsubtotal - dessubtotal;

                txttotal.Text = Math.Round(descuento, 2).ToString();
                txtTotalPagar.Text = txttotal.Text;
                txtigv.Text = Math.Round(nuevoiva, 2).ToString();
                to.Text = Math.Round(nuevosubtotal, 2).ToString();
                txtcodp.Enabled = true;
                txtcodp.Focus();
            }
            e.Handled = true;
        }

        private void CerrarVenta() 
        {
            if (txttotal.Text != "0")
            {
                txtcodp.Enabled = false;
                if (tipoVenta.SelectedItem.ToString() == "Credito")
                {
                    txtAbono.Visible = true;
                    labelAbono.Visible = true;
                }
                else
                {
                    txtCambio.Enabled = true;
                    txtCambio.Visible = true;
                    txtEfectivo.Enabled = true;
                    txtEfectivo.Visible = true;
                    lbEfectivo.Visible = true;
                    lbCambio.Visible = true;
                }

                txtTotalPagar.Visible = true;
                lbTotalPagar.Visible = true;
                lbCobrar.Visible = true;
                txtTotalPagar.Text = txttotal.Text;

                txtEfectivo.Focus();
            }
            else
                MessageBox.Show("Aun no hay venta registrada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
