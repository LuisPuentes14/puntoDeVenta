using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia.Cartera
{
    public partial class FrmAgregarAbono : Form
    {
        public FrmAgregarAbono()
        {
            InitializeComponent();
            CargarCreditos();
            txtDocumento.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarCreditos(txtDocumento.Text.Trim());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgCartera.CurrentRow != null)
                {
                    // Por ejemplo: obtener el valor de la celda de la columna 0
                    var valor = dgCartera.CurrentRow.Cells[4].Value?.ToString();

                    // Mostrarlo
                    MessageBox.Show($"Seleccionaste: {valor}");

                    // Evitar que el ENTER pase a la siguiente fila
                    e.Handled = true;
                }
            }
        }




        #region FUNCIONES
        private void CargarCreditos(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT 
                                C.IdVenta, 
                                V.PrecioTotal as 'precio total', 
                                C.AbonoInicial as 'Abono Inicial', 
                                v.Fecha, 
                                CL.IdCliente as 'Documento Cliente', 
                                C.EstadoCartera as 'Estado Cartera'
                                FROM Cartera C
                                JOIN TVentas V ON C.IdVenta = V.CodigoVenta
                                JOIN DetallesVenta DV ON DV.IdVenta = V.CodigoVenta
                                JOIN Clientes CL ON CL.IdCliente = V.Cliente
                        WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += @" AND (C.DocumentoCliente LIKE @Filtro)";
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
                        dgCartera.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
    }
}
