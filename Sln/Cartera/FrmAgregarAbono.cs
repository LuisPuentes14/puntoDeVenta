using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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

        private void dgCartera_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCartera.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgCartera.SelectedRows[0];

                // Asignar valores a los TextBox
                var abono = float.Parse(filaSeleccionada.Cells["Total Abonado"].Value?.ToString() ?? ""); 
                var debe = float.Parse(filaSeleccionada.Cells["Valor Restante"].Value?.ToString() ?? "");

                txtPagado.Text = abono.ToString("c3");
                txtDebe.Text = debe.ToString("c3");
            }
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgCartera.CurrentRow != null)
                    {
                        var idcartera = dgCartera.CurrentRow.Cells[8].Value?.ToString();
                        var montoInicial = dgCartera.CurrentRow.Cells[2].Value?.ToString();
                        string valorAbono = Interaction.InputBox("Ingrese el valor a abonar:", "Agregar Abono", "0");

                        if (string.IsNullOrEmpty(valorAbono))
                        {
                            MessageBox.Show("El valor a abonar no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (float.Parse(valorAbono) > float.Parse(dgCartera.CurrentRow.Cells[6].Value?.ToString()))
                        {
                            MessageBox.Show("El valor a abonar es mayor al que debe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        InsertarAbono(idcartera, float.Parse(valorAbono));
                        var subtotal = ObtenersumaAbonos(idcartera);
                        var totalAbonos = subtotal + float.Parse(montoInicial);
                        var totalVenta = float.Parse(dgCartera.CurrentRow.Cells[1].Value?.ToString());
                        var debeMonto = totalVenta - totalAbonos;

                        if (debeMonto == 0)
                            ActualizarEstadoCartera(idcartera);

                        txtPagado.Text = totalAbonos.ToString("c3");
                        txtDebe.Text = debeMonto.ToString("c3");

                        CargarCreditos();

                        // Evitar que el ENTER pase a la siguiente fila
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error ingrese un valor numerico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #region FUNCIONES
        private void ActualizarEstadoCartera(string idcartera)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = @"UPDATE Cartera SET EstadoCartera = 'Credito Cancelado' WHERE IdCartera = @IDCARTERA";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores desde los controles del formulario
                        cmd.Parameters.AddWithValue("@IDCARTERA", idcartera);
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("¡Credito cancelado, puedes realizar otra compra acreditada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private float ObtenersumaAbonos(string idCartera)
        {
            try
            {
                string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                string query = @"SELECT SUM(MontoAbono) FROM HistoricoCartera WHERE IdCartera = @IDCARTERA";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IDCARTERA", idCartera);

                        conexion.Open();

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != DBNull.Value && resultado != null)
                        {
                            return float.Parse(resultado.ToString());
                        }
                        else
                        {
                            return 0; // si no hay abonos, retorna 0
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }






        private void InsertarAbono(string idcartera, float montoAbono)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = @"
                INSERT INTO HistoricoCartera VALUES(@IDCARTERA, @MONTOABONO, @FECHAABONO)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores desde los controles del formulario
                        cmd.Parameters.AddWithValue("@IDCARTERA", idcartera);
                        cmd.Parameters.AddWithValue("@MONTOABONO", montoAbono);
                        cmd.Parameters.AddWithValue("@FECHAABONO", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Abono realizado Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void CargarCreditos(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT 
                                C.IdVenta,
                                V.PrecioTotal AS [Precio Total], 
                                C.AbonoInicial AS [Abono Inicial], 
                                V.Fecha, 
                                CL.IdCliente AS [Documento Cliente],
                                (ISNULL(SUM(HC.MontoAbono), 0) + C.AbonoInicial) AS [Total Abonado],
                                (V.PrecioTotal - (C.AbonoInicial + ISNULL(SUM(HC.MontoAbono), 0))) AS [Valor Restante],
                                C.EstadoCartera AS [Estado Cartera],
                                C.IdCartera AS [Id Cartera]
                            FROM Cartera C
                            JOIN TVentas V ON C.IdVenta = V.CodigoVenta
                            JOIN DetallesVenta DV ON DV.IdVenta = V.CodigoVenta
                            JOIN Clientes CL ON CL.IdCliente = V.Cliente
                            LEFT JOIN HistoricoCartera HC ON HC.IdCartera = C.IdCartera
                            WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += @" AND (C.DocumentoCliente LIKE @Filtro)";
            }

            query += @" GROUP BY 
                            C.IdVenta,
                            V.PrecioTotal,
                            C.AbonoInicial,
                            V.Fecha,
                            CL.IdCliente,
                            C.EstadoCartera,
                            C.IdCartera";

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

        private void dgCartera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
