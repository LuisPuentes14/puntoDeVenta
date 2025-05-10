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
            dateTimeVentas.Value = DateTime.Now;
            lbHora.Text = DateTime.Now.TimeOfDay.Hours.ToString() + ":" + DateTime.Now.TimeOfDay.Minutes.ToString();
            cargarDatos();
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
                    dgventas.CurrentCell = dgventas[0, currentRowIndex - 1];

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (currentRowIndex < dgventas.Rows.Count - 1)
                    dgventas.CurrentCell = dgventas[0, currentRowIndex + 1];

                e.Handled = true;
            }
        }
        // Evento para buscar cuando cambia la fecha
        private void dateTimeVentas_ValueChanged(object sender, EventArgs e)
        {
            cargarDatos(); // Recargar datos de la BD para la nueva fecha
            textBox1.Clear(); // Limpiar el filtro de búsqueda
        }
        // Evento para actualizar búsqueda en tiempo real
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


        #region FUNCIONES
        public (string mensaje, string tipoMensaje) DevolverProducto(string idVenta, double valorDescontar, string idProducto, int cantidad)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_transaccion_devolucion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@in_idVenta", idVenta);
                cmd.Parameters.AddWithValue("@in_valorDescontar", valorDescontar);
                cmd.Parameters.AddWithValue("@in_idProducto", idProducto);
                cmd.Parameters.AddWithValue("@in_cantidad", cantidad);

                // Parámetros de salida
                var paramMensaje = new SqlParameter("@out_mensaje", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramMensaje);

                var paramTipoMensaje = new SqlParameter("@out_tipoMensaje", SqlDbType.VarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramTipoMensaje);

                // Ejecutar
                conn.Open();
                cmd.ExecuteNonQuery();

                // Obtener resultados de salida
                string mensaje = paramMensaje.Value?.ToString();
                string tipoMensaje = paramTipoMensaje.Value?.ToString();
                return (mensaje, tipoMensaje);
            }
        }
        private void eliminarRegistroSeleccionado()
        {
            if (dgventas.CurrentRow != null)
            {
                string idVenta = dgventas.CurrentRow.Cells["IdVenta"].Value.ToString();
                string idProducto = dgventas.CurrentRow.Cells["IdProducto"].Value.ToString();
                int cantidad = Convert.ToInt32(dgventas.CurrentRow.Cells["Cantidad"].Value);
                double precioTotal = double.Parse(dgventas.CurrentRow.Cells["PrecioTotal"].Value.ToString());
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var resultado = DevolverProducto(idVenta, precioTotal, idProducto, cantidad);
                    MessageBox.Show(resultado.mensaje, resultado.tipoMensaje);
                    cargarDatos();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningún registro.", "ALERTA");
            }
        }
        public void cargarDatos(string filtro = "")
        {
            string Consulta = @"SELECT dv.IdVenta, dv.IdProducto, tp.Descripcion, tp.PrecioUnitario, dv.Cantidad, DV.PrecioUnidad AS 'PrecioTotal', v.Cliente, v.Fecha  
                        FROM DetallesVenta dv
                        INNER JOIN TVentas v ON dv.IdVenta = v.CodigoVenta
                        INNER JOIN TProductos tp ON dv.IdProducto = tp.CodigoProducto
                        WHERE CONVERT(DATE, v.Fecha) = @Fecha";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                Consulta += " AND (dv.IdVenta LIKE @Filtro OR dv.IdProducto LIKE @Filtro OR tp.Descripcion LIKE @Filtro OR dv.PrecioUnidad LIKE @Filtro OR dv.Cantidad LIKE @Filtro OR tp.PrecioUnitario LIKE @Filtro)";
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
        #endregion
    }
}
