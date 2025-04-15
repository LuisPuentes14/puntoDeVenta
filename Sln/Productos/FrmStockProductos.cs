using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmStockProductos : Form
    {
        public FrmStockProductos()
        {
            InitializeComponent();
        }

        private void FrmStockProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT CodigoProducto, Descripcion, Unidad, Cantidad, PrecioUnitario, Iva, Categoria, Proveedor, PrecioCompra 
                     FROM TProductos 
                     WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (Descripcion LIKE @Filtro OR CodigoProducto LIKE @Filtro)";
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
                        dgvStock.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarProductos();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarProductos(filtro);
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
