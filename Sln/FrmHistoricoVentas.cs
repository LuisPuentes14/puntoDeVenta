using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmHistoricoVentas : Form
    {
        public FrmHistoricoVentas()
        {
            InitializeComponent();
        }

        private void FrmHistoricoVentas_Load(object sender, EventArgs e)
        {
            cmbFiltro1.Items.AddRange(new string[]
            {
                "Hoy",
                "Ayer",
                "Rango personalizado"
            });
            cmbFiltro1.SelectedIndex = 0;

            // Por defecto, desactiva los DateTimePicker si no es rango personalizado
            dtpDesde1.Enabled = false;
            dateTimePicker2.Enabled = false;

            cmbFiltro1.SelectedIndexChanged += (s, ev) =>
            {
                bool esRango = cmbFiltro1.SelectedItem.ToString() == "Rango personalizado";
                dtpDesde1.Enabled = esRango;
                dateTimePicker2.Enabled = esRango;
            };
        }

        private void btnBuscar1_Click_1(object sender, EventArgs e)
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = "SELECT CodigoVenta, PrecioTotal, Fecha FROM TVentas WHERE 1=1";

            DateTime hoy = DateTime.Today;
            DateTime desde = dtpDesde1.Value.Date;
            DateTime hasta = dateTimePicker2.Value.Date;

            switch (cmbFiltro1.SelectedItem.ToString())
            {
                case "Hoy":
                    query += " AND CONVERT(date, Fecha) = @FechaHoy";
                    break;

                case "Ayer":
                    query += " AND CONVERT(date, Fecha) = @FechaAyer";
                    break;

                case "Rango personalizado":
                    query += " AND CONVERT(date, Fecha) BETWEEN @Desde AND @Hasta";
                    break;
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@FechaHoy", hoy);
                    cmd.Parameters.AddWithValue("@FechaAyer", hoy.AddDays(-1));
                    cmd.Parameters.AddWithValue("@FechaSemanaPasada", hoy.AddDays(-7));
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    try
                    {
                        conexion.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        adapter.Fill(tabla);
                        dgvResultados1.DataSource = tabla;

                        // Consulta para total de ventas
                        //string queryTotal = "SELECT SUM(PrecioTotal) FROM TVentas WHERE 1=1";
                        string queryTotal = "SELECT SUM(CAST(PrecioTotal AS DECIMAL(18,2))) FROM TVentas WHERE 1=1";

                        switch (cmbFiltro1.SelectedItem.ToString())
                        {
                            case "Hoy":
                                queryTotal += " AND CONVERT(date, Fecha) = @FechaHoy";
                                break;

                            case "Ayer":
                                queryTotal += " AND CONVERT(date, Fecha) = @FechaAyer";
                                break;

                            case "Mismo día semana pasada":
                                queryTotal += " AND CONVERT(date, Fecha) = @FechaSemanaPasada";
                                break;

                            case "Rango personalizado":
                                queryTotal += " AND CONVERT(date, Fecha) BETWEEN @Desde AND @Hasta";
                                break;
                        }

                        using (SqlCommand cmdTotal = new SqlCommand(queryTotal, conexion))
                        {
                            cmdTotal.Parameters.AddWithValue("@FechaHoy", hoy);
                            cmdTotal.Parameters.AddWithValue("@FechaAyer", hoy.AddDays(-1));
                            cmdTotal.Parameters.AddWithValue("@FechaSemanaPasada", hoy.AddDays(-7));
                            cmdTotal.Parameters.AddWithValue("@Desde", desde);
                            cmdTotal.Parameters.AddWithValue("@Hasta", hasta);

                            object resultado = cmdTotal.ExecuteScalar();
                            decimal total = resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                            lblTotalVentas.Text = "Total ventas: $" + total.ToString("N2");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al consultar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
