using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Text.RegularExpressions;

namespace Proyecto_Metodologia
{
    public partial class FrmArqueo : Form
    {
        //private DataSet aDatos;

        public FrmArqueo()
        {
          //  MessageBox.Show("FrmArqueo se ha abierto");
            InitializeComponent();
            ObtenerTotalesCaja(CONSTANS.USER, DateTime.Now); // Calcular totales al iniciar
        }

        private void LimpiarCampos()
        {
            txtSalida.Clear();
            txtEntrada.Clear();
            txtTotalVentas.Clear();
            txtconteo.Clear();
            lbDiferencia.Text = "0.00";
            txtabonos.Clear();
            txttotalventaEfectivo.Clear();
        }

        public void ObtenerTotalesCaja(string cajero, DateTime fecha)
        {
;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_totales_caja", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@in_cajero", cajero);
                cmd.Parameters.AddWithValue("@in_date", fecha.Date);

                // Parámetros de salida
                SqlParameter outEntrada = new SqlParameter("@out_entrada", SqlDbType.Float) { Direction = ParameterDirection.Output };
                SqlParameter outSalida = new SqlParameter("@out_salida", SqlDbType.Float) { Direction = ParameterDirection.Output };
                SqlParameter outVentas = new SqlParameter("@out_totalVentasEfectivo", SqlDbType.Float) { Direction = ParameterDirection.Output };
                SqlParameter outAbonos = new SqlParameter("@out_totalAbonos", SqlDbType.Float) { Direction = ParameterDirection.Output };
                SqlParameter outTotal = new SqlParameter("@out_total", SqlDbType.Float) { Direction = ParameterDirection.Output };

                cmd.Parameters.AddRange(new[] { outEntrada, outSalida, outVentas, outAbonos, outTotal });

                conn.Open();
                cmd.ExecuteNonQuery();

                // Obtener valores
                txtEntrada.Text = ((double)(outEntrada.Value ?? 0)).ToString("C2");
                txtSalida.Text = ((double)(outSalida.Value ?? 0)).ToString("C2");
                txttotalventaEfectivo.Text = ((double)(outVentas.Value ?? 0)).ToString("C2");
                txtabonos.Text = ((double)(outAbonos.Value ?? 0)).ToString("C2");
                txtTotalVentas.Text = ((double)(outTotal.Value ?? 0)).ToString("C2");
            }
        }


        private void CalcularDiferencia(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                var cultura = new CultureInfo("es-CO");

                if (double.TryParse(txtEntrada.Text, NumberStyles.Currency, cultura, out double totalEntradas) &&
                    double.TryParse(txtTotalVentas.Text, NumberStyles.Currency, cultura, out double totalVentas) &&
                    double.TryParse(txtSalida.Text, NumberStyles.Currency, cultura, out double totalSalidas) &&
                    double.TryParse(txtconteo.Text, NumberStyles.Currency, cultura, out double conteo))
                {
                    double diferencia = totalVentas - conteo;
                    lbDiferencia.Text = diferencia.ToString("c2", cultura);
                }
                else
                {
                    lbDiferencia.Text = "0,00";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            var culture = new CultureInfo("es-CO");

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Arqueo (usuario, TotalSalida, TotalEntrada, TotalEnCaja, conteo, fecha,TotalAbonos, TotalVentasEfectivo) " +
                                   "VALUES (@Usuario, @TotalSalida, @TotalEntrada, @TotalCaja, @conteo, @fecha, @totalAbonos,@TotalVentasEfectivo)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario",CONSTANS.USER);
                        cmd.Parameters.AddWithValue("@TotalSalida", double.Parse(txtSalida.Text, NumberStyles.Currency, culture));
                        cmd.Parameters.AddWithValue("@TotalEntrada", double.Parse(txtEntrada.Text, NumberStyles.Currency, culture));
                        cmd.Parameters.AddWithValue("@TotalCaja", double.Parse(txtTotalVentas.Text, NumberStyles.Currency, culture));
                        cmd.Parameters.AddWithValue("@conteo", double.Parse(txtconteo.Text, NumberStyles.Currency, culture));
                        cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd-HH-mm"));
                        cmd.Parameters.AddWithValue("@totalAbonos", double.Parse(txtSalida.Text, NumberStyles.Currency, culture));
                        cmd.Parameters.AddWithValue("@TotalVentasEfectivo", double.Parse(txttotalventaEfectivo.Text, NumberStyles.Currency, culture));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Arqueo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el arqueo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtconteo_KeyDown(object sender, KeyEventArgs e)
        {
            CalcularDiferencia(e);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LimpiarCampos();
            DateTime fechaSeleccionada = dateTimePicker1.Value.Date;
            ObtenerTotalesCaja(CONSTANS.USER, fechaSeleccionada);
        }
    }
}