using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmArqueo : Form
    {
        //private DataSet aDatos;

        public FrmArqueo()
        {
          //  MessageBox.Show("FrmArqueo se ha abierto");
            InitializeComponent();
            CargarUsuarios(); // Llenar el ComboBox al cargar el formulario
        }

        private void btnBuscarArqueo_Click_1(object sender, EventArgs e)
        
        {
            //MessageBox.Show("Seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = comboBox1.SelectedItem.ToString();
            DateTime fecha = dateTimePicker1.Value.Date;

            BuscarArqueo(usuario, fecha);
        }

        private void BuscarArqueo(string usuario, DateTime fecha)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = @"
                SELECT TotalSalida, TotalEntrada, TotalVenta, conteo, fecha 
                FROM Arqueo 
                WHERE usuario = @Usuario AND CONVERT(DATE, fecha) = @Fecha";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    textBox1.Text = reader["TotalSalida"].ToString();
                                    textBox2.Text = reader["TotalEntrada"].ToString();
                                    textBox3.Text = reader["TotalVenta"].ToString();
                                    txtconteo.Text = reader["conteo"].ToString();
                                    dateTimePicker1.Value = Convert.ToDateTime(reader["fecha"]);
                                }

                                MessageBox.Show("Arqueo encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para los criterios seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                LimpiarCampos();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el arqueo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            txtconteo.Clear();
            lbDiferencia.Text = "0.00";
        }


        private void CargarUsuarios()
        {
            comboBox1.Items.Clear(); // Evitar duplicados en recarga
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT usuario FROM TUsuarios";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["usuario"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConteo_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = comboBox1.SelectedItem.ToString();
            DateTime fecha = dateTimePicker1.Value.Date;
            CalcularTotales(usuario, fecha);
            CalcularDiferencia();
        }

        private void CalcularTotales(string usuario, DateTime fecha)
        {
            CalcularTotalVentas(usuario, fecha);
            CalcularTotalEntradas(usuario, fecha);
            CalcularTotalSalidas(usuario, fecha);
        }

        private void CalcularTotalVentas(string usuario, DateTime fecha)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT ISNULL(SUM(CAST(PrecioTotal AS DECIMAL(18,2))), 0) FROM TVentas WHERE Cajero = @Cajero AND CAST(Fecha AS DATE) = @Fecha";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cajero", usuario);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);
                        object result = cmd.ExecuteScalar();
                        textBox3.Text = Convert.ToDecimal(result).ToString("F2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular total de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularTotalEntradas(string usuario, DateTime fecha)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT ISNULL(SUM(valor), 0) FROM Entradaefectivo WHERE usuario = @Usuario AND CAST(Fecha AS DATE) = @Fecha";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);
                        object result = cmd.ExecuteScalar();
                        textBox2.Text = Convert.ToDecimal(result).ToString("F2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular total de entradas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularTotalSalidas(string usuario, DateTime fecha)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT ISNULL(SUM(valor), 0) FROM Salidaefectivo WHERE usuario = @Usuario AND CAST(Fecha AS DATE) = @Fecha";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);
                        object result = cmd.ExecuteScalar();
                        textBox1.Text = Convert.ToDecimal(result).ToString("F2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular total de salidas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularDiferencia()
        {
            if (double.TryParse(textBox2.Text, out double totalEntradas) &&
                double.TryParse(textBox3.Text, out double totalVentas) &&
                double.TryParse(textBox1.Text, out double totalSalidas) &&
                double.TryParse(textBox4.Text, out double apertura) &&
                double.TryParse(txtconteo.Text, out double conteo)) 

            {
                double diferencia = conteo - (totalEntradas + totalVentas + apertura - totalSalidas);
                lbDiferencia.Text = diferencia.ToString("F2");
            }
            else
            {
                lbDiferencia.Text = "0.00";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = comboBox1.SelectedItem.ToString();
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Arqueo (usuario, TotalSalida, TotalEntrada, TotalVenta, conteo, fecha) " +
                                   "VALUES (@Usuario, @TotalSalida, @TotalEntrada, @TotalVenta, @conteo, @fecha)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@TotalSalida", Convert.ToDecimal(textBox1.Text));
                        cmd.Parameters.AddWithValue("@TotalEntrada", Convert.ToDecimal(textBox2.Text));
                        cmd.Parameters.AddWithValue("@TotalVenta", Convert.ToDecimal(textBox3.Text));
                        cmd.Parameters.AddWithValue("@conteo", Convert.ToDecimal(txtconteo.Text));
                        cmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));

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


    }
}