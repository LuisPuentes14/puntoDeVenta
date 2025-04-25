using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_Metodologia
{
    public partial class FrmDevolucionesDeVentas : Form
    {
        private DataSet aDatos;
        private DataTable detallesVentaTable;

        public FrmDevolucionesDeVentas()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown; // ✅ Vincular evento
            dateTimeVentas.Value = DateTime.Now;
            lbHora.Text = DateTime.Now.TimeOfDay.Hours.ToString() + ":" + DateTime.Now.TimeOfDay.Minutes.ToString();
            cargarDatos();
            configurarColumnas();
            txttotal.Text = dgventas.Rows.Count.ToString();
            dgventas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgventas.MultiSelect = false;
            dgventas.KeyDown += dgventas_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgventas.Focus();
            if (dgventas.Rows.Count > 0)
                dgventas.CurrentCell = dgventas[0, 0];
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgventas.Rows.Count == 0) return;

            int currentRowIndex = dgventas.CurrentCell.RowIndex;

            if (e.KeyCode == Keys.Up)
            {
                if (currentRowIndex > 0)
                {
                    dgventas.CurrentCell = dgventas[0, currentRowIndex - 1];
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (currentRowIndex < dgventas.Rows.Count - 1)
                {
                    dgventas.CurrentCell = dgventas[0, currentRowIndex + 1];
                }
                e.Handled = true;
            }
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


        public void cargarDatos(string filtro = "")
        {
            string Consulta = @"SELECT dv.IdVenta, dv.IdProducto, tp.Descripcion, dv.PrecioUnidad, dv.Cantidad, dv.Iva, v.Fecha  
                        FROM DetallesVenta dv
                        INNER JOIN TVentas v ON dv.IdVenta = v.CodigoVenta
                        INNER JOIN TProductos tp ON dv.IdProducto = tp.CodigoProducto
                        WHERE CONVERT(DATE, v.Fecha) = @Fecha";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                Consulta += " AND (dv.IdVenta LIKE @Filtro OR dv.IdProducto LIKE @Filtro OR tp.Descripcion LIKE @Filtro OR dv.PrecioUnidad LIKE @Filtro OR dv.Cantidad LIKE @Filtro OR dv.Iva LIKE @Filtro)";
            }

            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(Consulta, conexion);
                cmd.Parameters.AddWithValue("@Fecha", dateTimeVentas.Value.Date);
                cmd.Parameters.AddWithValue("@Filtro", filtro);
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
            dgventas.Columns["PrecioUnidad"].Width = 100;
            dgventas.Columns["PrecioUnidad"].HeaderText = "Precio Unitario";
            dgventas.Columns["Cantidad"].Width = 100;
            dgventas.Columns["Cantidad"].HeaderText = "Cantidad";
            dgventas.Columns["Iva"].Width = 80;
            dgventas.Columns["Iva"].HeaderText = "IVA";
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

        private void buscarVenta()
        {
            if (detallesVentaTable != null)
            {
                string filtro = textBox1.Text.Trim();
                int idVenta;

                DataView dv = new DataView(detallesVentaTable); // Solo filtrar sobre los datos cargados

                if (!string.IsNullOrEmpty(filtro) && int.TryParse(filtro, out idVenta))
                {
                    // Filtrar por ID de Venta (los datos ya están filtrados por fecha)
                    dv.RowFilter = $"IdVenta = {idVenta}";
                }

                dgventas.DataSource = dv;
            }
        }

        // Evento para actualizar búsqueda en tiempo real
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscarVenta();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarVenta(); // Llamar a la función de búsqueda
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            cargarDatos(filtro);
        }
    }
}
