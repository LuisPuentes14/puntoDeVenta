using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;


namespace Proyecto_Metodologia
{
      public partial class FrmVentas : Form

    {
        private PrintDocument printDocument;

        private DataSet aDatos;
        
        public static TextBox txtPublico;


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
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            txtPublico = txtcodp;

        }

         private void FrmVentas_KeyDown(object sender, KeyEventArgs e)

        {
            double descuento = 0;
            double total = 0;
            double descuentoiva = 0;
            double totaliva = 0;
            double nuevoiva = 0;
            double dessubtotal = 0;
            double nuevosubtotal = 0;
            double totalsubtotal = 0;

                

            if (e.KeyCode == Keys.F1)

            {
                if (txttotal.Text != "0")
                {
                txtcodp.Enabled = false;
                textBox2.Enabled= true;
                textBox2.Visible = true;
                textBox3.Enabled = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label14.Visible = true;
                label13.Visible = true;
                label12.Visible = true;
                label15.Visible = true;
                textBox4.Text = txttotal.Text;

                textBox3.Focus();
                }
                else {

                    MessageBox.Show("Aun no hay venta registrada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (e.KeyCode == Keys.F2)
            {
                txtcodp.Enabled = false;
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                // Activar selección si no hay fila seleccionada
                if (dgvVentas.SelectedRows.Count == 0 && dgvVentas.Rows.Count > 0)
                {
                    dgvVentas.Rows[0].Selected = true;
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
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
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // Eliminar la fila seleccionada con Enter
                if (dgvVentas.SelectedRows.Count > 0)
                {
                    int rowIndex = dgvVentas.SelectedRows[0].Index;
                    double valor = Convert.ToDouble(dgvVentas.Rows[rowIndex].Cells["Total"].Value);
                    double iva = Convert.ToDouble(dgvVentas.Rows[rowIndex].Cells["Iva"].Value);
                    dgvVentas.Rows.RemoveAt(rowIndex);
                    
                    total= double.Parse(txttotal.Text);
                    
                    descuento = total - valor;
                    descuentoiva = valor * iva;
                    totaliva= double.Parse(txtigv.Text);
                    nuevoiva = totaliva - descuentoiva;
                    dessubtotal = valor - descuentoiva;
                    totalsubtotal= double.Parse(to.Text);
                    nuevosubtotal = totalsubtotal - dessubtotal;

                    txttotal.Text = Math.Round(descuento, 2).ToString();
                    textBox4.Text = txttotal.Text;
                    txtigv.Text = Math.Round(nuevoiva, 2).ToString();
                    to.Text= Math.Round(nuevosubtotal, 2).ToString();
                    txtcodp.Enabled = true;
                    txtcodp.Focus();

                }
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F3)
            {
                txtnombre.Focus();
            }


            if (e.KeyCode == Keys.F3)

            {
                FrmSalidaEfectivo salida = new FrmSalidaEfectivo();
                salida.Show();
            }

            if (e.KeyCode == Keys.F4)

            {
                FrmEntradaefectivo entrada = new FrmEntradaefectivo();
                entrada.Show();
            }

            if (e.KeyCode == Keys.F6)

            {
               FrmArqueo arqueo = new FrmArqueo();
               arqueo.Show();
               // arqueo.Close();
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    // Convertir los valores a double
                    double totalAPagar = double.Parse(textBox4.Text);
                    double efectivo = double.Parse(textBox3.Text);

                    // Validar que el efectivo no sea menor que el total a pagar
                    if (efectivo < totalAPagar)
                    {
                        MessageBox.Show("El valor del efectivo no puede ser menor que el total a pagar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox3.Focus();
                        return;
                    }

                    // Calcular el cambio
                    double cambio = efectivo - totalAPagar;

                    // Mostrar el cambio en textBox2
                    textBox2.Text = Math.Round(cambio, 2).ToString();
                    textBox2.Focus();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyChar == (char)Keys.Enter)  // 13 es el valor ASCII de la tecla Enter
            {

                string fechaVenta = DateTime.Now.ToString("yyyy-MM-dd");
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            string cajero = CONSTANS.USER;
                
                

                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    try
                    {
                        conexion.Open();

                        // Inserción de datos de la ventacliente
                        string queryVenta = "INSERT INTO TVentas (CodigoVenta, PrecioTotal, Fecha,cajero,Cliente) VALUES (@CodigoVenta, @Total, @FechaVenta,@cajero, @Cliente)";
                        using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion))

                        {
                            cmdVenta.Parameters.AddWithValue("@CodigoVenta", txtCodVentas.Text);
                            cmdVenta.Parameters.AddWithValue("@Total", txttotal.Text);
                            cmdVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                            cmdVenta.Parameters.AddWithValue("@Cajero", cajero);
                            cmdVenta.Parameters.AddWithValue("@Cliente", textBox1.Text);
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


                                string queryActualizarInventario = "UPDATE Tproductos SET cantidad = cantidad - @Cantidad WHERE CodigoProducto = @CodigoProducto";
                                using (SqlCommand cmdActualizar = new SqlCommand(queryActualizarInventario, conexion))

                                {
                                    cmdActualizar.Parameters.AddWithValue("@Cantidad", cantidad);
                                    cmdActualizar.Parameters.AddWithValue("@CodigoProducto", idProducto);
                                    cmdActualizar.ExecuteNonQuery();
                                }

                                detallesVenta.Add($"{cantidad} x {nombre} - {precioUnidad:C}");
                            }
                        }


                        DialogResult result = MessageBox.Show("¿Desea imprimir?", "Éxito", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        // Verificar si el usuario presionó 'OK' (Enter) o 'Cancel' (Escape)
                        if (result == DialogResult.OK)
                        {
                            // Aquí agregas el código para realizar la acción de impresión
                            
                            // Crear una nueva instancia de PrintDocument
                            PrintDocument printDoc = new PrintDocument();

                            // Asegurarse de que la impresora se ha configurado correctamente con el nombre correcto
                            printDoc.PrinterSettings.PrinterName = "POS-80"; // Usar el nombre exacto de la impresora

                            // Verificar si la impresora está disponible
                            if (string.IsNullOrEmpty(printDoc.PrinterSettings.PrinterName) || !printDoc.PrinterSettings.IsValid)
                            {
                                MessageBox.Show("No se puede encontrar la impresora POS-80.");
                                return;
                            }

                            // Establecer el contenido a imprimir, en este caso, el texto del TextBox
                            printDoc.PrintPage += (sender1, args) =>
                            {
                                // Obtener el texto del TextBox
                                //string textoAImprimir = "hola";
                                printDocument.Print();


                                // Verificar si el texto es nulo o vacío antes de intentar imprimir
                                // if (string.IsNullOrEmpty(textoAImprimir))


                                // Especificamos la fuente y el color
                                Font font = new Font("Arial", 12);
                                Brush brush = Brushes.Black;

                                // Dibujar el texto en la página de impresión
                                // args.Graphics.DrawString(textoAImprimir, font, brush, 100, 100);  // Ajusta las coordenadas según sea necesario
                            };

                            // Imprimir el documento
                            try
                            {
                                printDoc.Print();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ocurrió un error al imprimir: {ex.Message}");
                            }


                        }
                        else if (result == DialogResult.Cancel)
                        {
                            // Si se presionó Escape, no se realiza ninguna acción
                            //MessageBox.Show("La impresión ha sido cancelada.");
                        }



                        limpiarventa();
                        dgvVentas.Rows.Clear();
                        autoincrementable();
                        clear();

                        

                        // Generar el ticket PDF
                        // Crear una nueva instancia de Form1

                        txtcodp.Enabled = true;
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        label14.Visible = false;
                        label13.Visible = false;
                        label12.Visible = false;
                        label15.Visible = false;
                        txtcodp.Focus();

                        // Imprimir la frase "Tienda Hector" en la impresora POS-80
                        
                        to.Text = "0";
                        txtigv.Text = "0";
                        txttotal.Text = "0";
                        textBox2.Text = "0";
                        textBox3.Text = "0";
                        textBox4.Text = "0";


                       


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Posición inicial para imprimir
            int yPosition = 20; // Se inicia con un margen superior
            int xPosition = 10; // Margen izquierdo

            // Fuente y pincel para el texto con tamaños reducidos
            Font font = new Font("Arial", 8); // Tamaño más pequeño para los datos
            Font fontBold = new Font("Arial", 10, FontStyle.Bold); // Tamaño reducido para títulos
            Brush brush = Brushes.Black;

            // Definir altura de línea y ancho de columna
            int lineHeight = (int)font.GetHeight(e.Graphics) + 2; // Ajuste de espaciado
            int codeWidth = 40;   // Ancho de la columna Código
            int nameWidth = 120;  // Ancho de la columna Nombre del Artículo
            int qtyWidth = 40;    // Ancho de la columna Cantidad
         //   int priceWidth = 60;  // Ancho de la columna Valor
            int spacing = 5;      // Espaciado entre columnas

            // Obtener el número de factura desde txtCodVentas
            string numeroFactura = string.IsNullOrEmpty(txtCodVentas.Text) ? "N/A" : txtCodVentas.Text;

            // ENCABEZADO DEL TICKET
            e.Graphics.DrawString("SUPERMERCADO HÉCTOR", fontBold, brush, xPosition, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString("NIT: 12345678-9", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            e.Graphics.DrawString($"Factura No: {numeroFactura}", font, brush, xPosition, yPosition);
            yPosition += lineHeight * 2; // Espaciado extra antes de los productos

            // LÍNEA SEPARADORA
            e.Graphics.DrawString("-----------------------------------------------", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // ENCABEZADO DE COLUMNAS
            int currentX = xPosition;
            e.Graphics.DrawString("Cod", fontBold, brush, currentX, yPosition);
            currentX += codeWidth + spacing;

            e.Graphics.DrawString("Artículo", fontBold, brush, currentX, yPosition);
            currentX += nameWidth + spacing;

            e.Graphics.DrawString("Cant", fontBold, brush, currentX, yPosition);
            currentX += qtyWidth + spacing;

            e.Graphics.DrawString("Precio", fontBold, brush, currentX, yPosition);

            yPosition += lineHeight;

            // LÍNEA SEPARADORA
            e.Graphics.DrawString("-----------------------------------------------", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // IMPRESIÓN DE DATOS
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la fila vacía

                currentX = xPosition; // Reiniciar posición X por cada fila

                string codigo = row.Cells[0].Value?.ToString() ?? "";
                string articulo = row.Cells[1].Value?.ToString() ?? "";
                string cantidad = row.Cells[2].Value?.ToString() ?? "";
                string valor = row.Cells[3].Value?.ToString() ?? "";

                // Imprimir cada celda en su respectiva columna
                e.Graphics.DrawString(codigo, font, brush, currentX, yPosition);
                currentX += codeWidth + spacing;

                e.Graphics.DrawString(articulo, font, brush, currentX, yPosition);
                currentX += nameWidth + spacing;

                e.Graphics.DrawString(cantidad, font, brush, currentX, yPosition);
                currentX += qtyWidth + spacing;

                e.Graphics.DrawString(valor, font, brush, currentX, yPosition);

                yPosition += lineHeight; // Mover a la siguiente línea
            }

            // LÍNEA SEPARADORA FINAL
            yPosition += lineHeight;
            e.Graphics.DrawString("-----------------------------------------------", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // MENSAJE DE AGRADECIMIENTO
            e.Graphics.DrawString("¡Gracias por su compra!", fontBold, brush, xPosition, yPosition);
            yPosition += lineHeight * 2; // Espaciado extra

            // MENSAJE DE DESARROLLADOR
            e.Graphics.DrawString("Software desarrollado por SERVISISTEMAS", font, brush, xPosition, yPosition);
            yPosition += lineHeight;

            // Indicar que no hay más páginas para imprimir
            e.HasMorePages = false;
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

        public IWin32Window Ventatotal { get; private set; }


       SqlConnection cnn;
      

       public void Conexion()
        {
            try
            {
                cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
                cnn.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar: " + ex.ToString());
            }
        }
    
        public void AutoCompletar(TextBox cajaTexto)
        {

            try
            {
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
                //cajaTexto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cajaTexto.AutoCompleteSource = AutoCompleteSource.CustomSource;


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


        // private void txtcodp_PreviewKeyDown(object sender, KeyPressEventArgs e)
        private void txtcodp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            
            //DesactivarAutocompletado(txtcodp);
            TextBox txt = sender as TextBox;
            //MessageBox.Show("Producto seleccionado: " + txt.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //DesactivarAutocompletado(txt);

            //if (e.KeyChar == (char)Keys.Space)
            // if (e.KeyCode == (char)Keys.Space || e.KeyChar == (char)Keys.Enter)
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
                //e.Handled = true;

                if (!string.IsNullOrWhiteSpace(txtcodp.Text))

                {
                    //MessageBox.Show("Producto seleccionado: " + txt.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DesactivarAutocompletado(txtcodp);
                    //MessageBox.Show("Producto seleccionado: " + txt.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDatosProducto(txtcodp.Text, GetUnidadmedida());
                    //MessageBox.Show("Producto seleccionado: " + txt.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //nupcantidad.Focus();
                }
                else
                {
                    MessageBox.Show("Código de producto vacío. Escanee nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtcodp.Focus();
                    //SetFocusToTxtCodp();
                }
            }
        }

        private ComboBox GetUnidadmedida()
        {
            return Unidadmedida;
        }

        private void CargarDatosProducto(string codigo, ComboBox unidadmedida)
        {
            string[] datos = obtenerDatos(codigo);

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

        public string[] obtenerDatos(string pCodigo)
        {
            string[] datos = new string[9]; // Ahora tenemos un nuevo campo para la cantidad

            // Actualiza la consulta para solo obtener la columna 'Unidad'
            string Consulta = long.TryParse(pCodigo, out long result)
                ? $"SELECT * FROM TProductos WHERE CodigoProducto = '{pCodigo}'"
                : $"SELECT * FROM TProductos WHERE Descripcion LIKE '%{pCodigo}%'";

            EjecutarSelect(Consulta);

            datos[0] = ValorAtributo("CodigoProducto");
            datos[1] = ValorAtributo("Descripcion");
            datos[6] = ValorAtributo("PrecioUnitario");
            datos[2] = ValorAtributo("Unidad");  // Solo obtenemos la unidad
            datos[7] = ValorAtributo("Iva");
            datos[8] = ValorAtributo("Cantidad"); // Ahora cargamos el campo Cantidad

            return datos;
        }

        public DataSet EjecutarSelect(string Consulta)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlDataAdapter a = new SqlDataAdapter(Consulta, conexion);
                aDatos = new DataSet();
                a.Fill(aDatos);
                conexion.Close();
            }
            return aDatos;
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            string fechaVenta = DateTime.Now.ToString("yyyy-MM-dd");
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();

                    string queryVenta = "INSERT INTO TVentas (CodigoVenta, PrecioTotal, Fecha) VALUES (@CodigoVenta, @Total, @FechaVenta)";
                    using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion))
                    {
                        cmdVenta.Parameters.AddWithValue("@CodigoVenta", txtCodVentas.Text);
                        cmdVenta.Parameters.AddWithValue("@Total", txttotal.Text);
                        cmdVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                        cmdVenta.ExecuteNonQuery();
                    }

                    List<string> detallesVenta = new List<string>();

                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string idProducto = row.Cells[0].Value.ToString();
                            string nombre = row.Cells[1].Value.ToString();
                            int cantidad = Convert.ToInt32(row.Cells[2].Value);
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

                            detallesVenta.Add($"{cantidad} x {nombre} - {precioUnidad:C}");
                        }
                    }

                    limpiarventa();
                    dgvVentas.Rows.Clear();
                    autoincrementable();
                    clear();

                    MessageBox.Show("Venta guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   // GenerarTicketPDF(txtCodVentas.Text, detallesVenta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void SetFocusToTxtCodp()
        {
            if (txtcodp.Enabled && txtcodp.Visible)
            {
                txtcodp.Select();
                txtcodp.Focus();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                double preciounidad = double.Parse(txtpreciou.Text);
                double cantidad = Convert.ToDouble(nupcantidad.Text);  // Obtener la cantidad ingresada
                double iva = double.Parse(Txtiva.Text)/100;

                string unidad = ValorAtributo("Unidad");

                // Si la unidad es "Kilo", convertir la cantidad a gramos
                if (unidad == "Kilo")
                {
                    cantidad *= 1000;
                }

                double total = cantidad * preciounidad;
                textBox4.Text = total.ToString();

                dgvVentas.Rows.Add(txtcodp.Text, txtnombre.Text, nupcantidad.Text.ToString(), total.ToString("0"),iva.ToString());

                calculartotal();
                clear();
            }
            catch
            {
                MessageBox.Show("INGRESA UN PRODUCTO");
            }
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

        
        public void imprimir_Click(object sender, EventArgs e)
        {
            string fechaVenta = DateTime.Now.ToString("yyyy-MM-dd");
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();

                    // Inserción de datos de la venta
                    string queryVenta = "INSERT INTO TVentas (CodigoVenta, PrecioTotal, Fecha, Cliente) VALUES (@CodigoVenta, @Total, @FechaVenta, @Cliente)";
                    using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion))
                    {
                        cmdVenta.Parameters.AddWithValue("@CodigoVenta", txtCodVentas.Text);
                        cmdVenta.Parameters.AddWithValue("@Total", txttotal.Text);
                        cmdVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                        cmdVenta.Parameters.AddWithValue("@Cliente", textBox1.Text);

                        cmdVenta.ExecuteNonQuery();
                    }

                    List<string> detallesVenta = new List<string>();

                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string idProducto = row.Cells[0].Value.ToString();
                            string nombre = row.Cells[1].Value.ToString();
                            float cantidad = Convert.ToInt32(row.Cells[2].Value);
                            decimal precioUnidad = Convert.ToDecimal(row.Cells[3].Value);
                            decimal iva = Math.Round(precioUnidad * 0.18m, 2);
                            //MessageBox.Show("Venta guardada con éxito. Cantidad: " + cantidad.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                            detallesVenta.Add($"{cantidad} x {nombre} - {precioUnidad:C}");
                        }
                    }

                    limpiarventa();
                    dgvVentas.Rows.Clear();
                    autoincrementable();
                    clear();

                    MessageBox.Show("Venta guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void imprimir()
        {
            throw new NotImplementedException();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string fechaVenta = DateTime.Now.ToString("yyyy-MM-dd");
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();

                    // Inserción de datos de la venta
                    string queryVenta = "INSERT INTO TVentas (CodigoVenta, PrecioTotal, Fecha, Cliente) VALUES (@CodigoVenta, @Total, @FechaVenta, @Cliente)";
                    using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion))
                    {
                        cmdVenta.Parameters.AddWithValue("@CodigoVenta", txtCodVentas.Text);
                        cmdVenta.Parameters.AddWithValue("@Total", txttotal.Text);
                        cmdVenta.Parameters.AddWithValue("@FechaVenta", fechaVenta);
                        cmdVenta.Parameters.AddWithValue("@Cliente", textBox1.Text);
                        cmdVenta.ExecuteNonQuery();
                    }

                    List<string> detallesVenta = new List<string>();

                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string idProducto = row.Cells[0].Value.ToString();
                            string nombre = row.Cells[1].Value.ToString();
                            int cantidad = Convert.ToInt32(row.Cells[2].Value);
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

                            detallesVenta.Add($"{cantidad} x {nombre} - {precioUnidad:C}");
                        }
                    }

                    limpiarventa();
                    dgvVentas.Rows.Clear();
                    autoincrementable();
                    clear();

                    MessageBox.Show("Venta guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
           // FrmArqueo frm = new FrmArqueo(); // Crea una instancia del formulario
          // frm.Show(); // Muestra el formulario de manera no modal
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


    
}
