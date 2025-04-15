using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_Metodologia
{
    public partial class FrmDevolucionesDeCompras : Form
    {
        private DataSet aDatos;
        private DataTable detallesVentaTable;

        public FrmDevolucionesDeCompras()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown; // Vincular evento
            dateTimeVentas.Value = DateTime.Now;
            cargarDatos();
            //configurarColumnas();
            txttotal.Text = dgventas.Rows.Count.ToString();
            dgventas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgventas.MultiSelect = false;
            dgventas.KeyDown += dgventas_KeyDown;
        }

        public DataSet Datos
        {
            get { return aDatos; }
        }

        public DataSet EjecutarSelect(string pConsulta)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlDataAdapter a = new SqlDataAdapter();
                a.SelectCommand = new SqlCommand(pConsulta, conexion);
                aDatos = new DataSet();
                a.Fill(aDatos);
                conexion.Close();
            }
            return aDatos;
        }

        public void cargarDatos()
        {
            string Consulta = @"SELECT P.CODIGOPRODUCTO, P.DESCRIPCION, P.UNIDAD, P.CANTIDAD, P.PRECIOCOMPRA, C.FECHACOMPRA FROM TPRODUCTOS P INNER JOIN COMPRAS C ON P.CODIGOPRODUCTO = C.CODIGOPRODUCTO WHERE CONVERT(DATE, C.FECHACOMPRA) = @Fecha";

            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(Consulta, conexion);
                cmd.Parameters.AddWithValue("@Fecha", dateTimeVentas.Value.Date);
                SqlDataAdapter a = new SqlDataAdapter(cmd);
                aDatos = new DataSet();
                a.Fill(aDatos);
                detallesVentaTable = aDatos.Tables[0];
                conexion.Close();
            }
            dgventas.DataSource = detallesVentaTable;
        }


        // Evento para buscar cuando cambia la fecha
        private void dateTimeVentas_ValueChanged(object sender, EventArgs e)
        {
            cargarDatos(); // Recargar datos de la BD para la nueva fecha
            textBox1.Clear(); // Limpiar el filtro de búsqueda
        }

        private void configurarColumnas()
        {
            dgventas.Columns["IdVenta"].Width = 150;
            dgventas.Columns["IdVenta"].HeaderText = "Código de Venta";
            dgventas.Columns["IdProducto"].Width = 150;
            dgventas.Columns["IdProducto"].HeaderText = "Código del Producto";
            dgventas.Columns["Descripcion"].Width = 200;
            dgventas.Columns["Descripcion"].HeaderText = "Descripción del Producto";
        }

        public void eliminarDetalleVenta(string idVenta, string idProducto, int cantidad)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();

                // Eliminar el detalle de la venta
                string consultaEliminar = "DELETE FROM DetallesVenta WHERE IdVenta = @IdVenta AND IdProducto = @IdProducto";
                SqlCommand cmdEliminar = new SqlCommand(consultaEliminar, conexion);
                cmdEliminar.Parameters.AddWithValue("@IdVenta", idVenta);
                cmdEliminar.Parameters.AddWithValue("@IdProducto", idProducto);
                cmdEliminar.ExecuteNonQuery();

                // Sumar la cantidad eliminada al stock de productos
                string consultaActualizar = "UPDATE TProductos SET Cantidad = Cantidad + @Cantidad WHERE CodigoProducto = @IdProducto";
                SqlCommand cmdActualizar = new SqlCommand(consultaActualizar, conexion);
                cmdActualizar.Parameters.AddWithValue("@Cantidad", cantidad);
                cmdActualizar.Parameters.AddWithValue("@IdProducto", idProducto);
                cmdActualizar.ExecuteNonQuery();

                conexion.Close();
            }
        }

        private void eliminarRegistroSeleccionado()
        {
            if (dgventas.CurrentRow != null)
            {
                string idVenta = dgventas.CurrentRow.Cells["IdVenta"].Value.ToString();
                string idProducto = dgventas.CurrentRow.Cells["IdProducto"].Value.ToString();
                int cantidad = Convert.ToInt32(dgventas.CurrentRow.Cells["Cantidad"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    eliminarDetalleVenta(idVenta, idProducto, cantidad);
                    detallesVentaTable.Rows.RemoveAt(dgventas.CurrentRow.Index);
                    MessageBox.Show("Registro eliminado y stock actualizado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningún registro.", "ALERTA");
            }
        }

      

        // Evento para actualizar búsqueda en tiempo real
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "'%%'");
            CargarCompras(filtro);
            txttotal.Text = dgventas.Rows.Count.ToString();
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCompras(); // Llamar a la función de búsqueda
                txttotal.Text = dgventas.Rows.Count.ToString();
                e.SuppressKeyPress = true; // Evitar sonido de beep en el TextBox

                // Si hay filas en el DataGridView después del filtro, selecciona la primera
                if (dgventas.Rows.Count > 0)
                {
                    dgventas.Focus(); // Pasar el foco al DataGridView
                    dgventas.CurrentCell = dgventas.Rows[0].Cells[0]; // Seleccionar la primera celda
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            eliminarRegistroSeleccionado();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgventas_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Enter) && dgventas.CurrentRow != null)
            {
                eliminarRegistroSeleccionado();
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }


        #region FUNCIONES 
        private void CargarCompras(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT P.CODIGOPRODUCTO, P.DESCRIPCION, P.UNIDAD, P.CANTIDAD, P.PRECIOCOMPRA, C.FECHACOMPRA FROM TPRODUCTOS P INNER JOIN COMPRAS C ON P.CODIGOPRODUCTO = C.CODIGOPRODUCTO WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (P.CODIGOPRODUCTO LIKE @Filtro OR DESCRIPCION LIKE @Filtro OR P.UNIDAD LIKE @Filtro OR P.CANTIDAD LIKE @Filtro OR P.PRECIOCOMPRA LIKE @Filtro OR CONVERT(VARCHAR, C.FECHACOMPRA, 105) LIKE @Filtro)";
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                        cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        adapter.Fill(tabla);
                        dgventas.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        #endregion

        private void txttotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
