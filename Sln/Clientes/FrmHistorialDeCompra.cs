using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia.Clientes
{
    public partial class FrmHistorialDeCompra : Form
    {
        public FrmHistorialDeCompra()
        {
            InitializeComponent();
            CargarDatos();
           
        }

        #region EVENTOS

        private void FrmHistorialDeCompra_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        //input que para filtrar en tiempo real
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            CargarClientes(filtro);
        }
        //evento para salir
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimeVentasDesde_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFechas();
        }

        private void dateTimeVentasHasta_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFechas();
        }
        #endregion

        #region FUNCIONES

        private void FiltrarPorFechas()
        {
            DateTime desde = dateTimeVentasDesde.Value.Date;
            DateTime hasta = dateTimeVentasHasta.Value.Date;

            if (desde >= hasta)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT V.PrecioTotal, V.Fecha, C.IdCliente AS Documento, C.Nombre, C.Apellido FROM Clientes C
JOIN TVentas V ON V.Cliente = C.IdCliente 
                     WHERE fecha BETWEEN @desde AND @hasta";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        adapter.Fill(tabla);
                        dgClientes.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //FUNCION CARGAR DATOS
        private void CargarDatos()
        {
            string query = "SELECT V.PrecioTotal, V.Fecha, C.IdCliente AS Documento, C.Nombre FROM Clientes C JOIN TVentas V ON V.Cliente = C.IdCliente"; // Cambiá por tu tabla

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgClientes.DataSource = dt;
            }
        }
        //FUNCION CARGAR CLIENTES EN TIEMPO REAL
        private void CargarClientes(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT V.PrecioTotal, V.Fecha, C.IdCliente AS Documento, C.Nombre, C.Apellido FROM Clientes C
JOIN TVentas V ON V.Cliente = C.IdCliente 
                     WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (C.IdCliente LIKE @Filtro OR C.Nombre LIKE @Filtro OR Apellido LIKE @Filtro OR Fecha LIKE @Filtro OR PrecioTotal LIKE @Filtro)";
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
                        dgClientes.DataSource = tabla;
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
