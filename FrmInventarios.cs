using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmInventarios : Form
    {
        private DataSet aDatos;
        private DataTable productosTable;

        public FrmInventarios()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmInventarios_Load);
            comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged); // Evento para filtrar productos
        }

        // Método para llenar el ComboBox con los nombres de las categorías
        private void CargarCategorias()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string consulta = "SELECT DISTINCT NombreCategoría FROM Categorías";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox2.Items.Add("Todas"); // Opción para ver todos los productos
                            while (reader.Read())
                            {
                                comboBox2.Items.Add(reader["NombreCategoría"].ToString());
                            }
                            comboBox2.SelectedIndex = 0; // Selecciona "Todas" por defecto
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        // Método para cargar productos en el DataGridView (con o sin filtro)
        private void CargarProductos(string categoria = "")
        {
            string consulta = @"SELECT CodigoProducto, Descripcion, Unidad, Cantidad, PrecioUnitario, Iva, Categoria, Proveedor 
                                FROM TProductos";

            if (!string.IsNullOrEmpty(categoria) && categoria != "Todas")
            {
                consulta += " WHERE Categoria = @Categoria";
            }

            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        if (!string.IsNullOrEmpty(categoria) && categoria != "Todas")
                        {
                            cmd.Parameters.AddWithValue("@Categoria", categoria);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        aDatos = new DataSet();
                        adapter.Fill(aDatos);
                        productosTable = aDatos.Tables[0];
                    }
                }
                dgventas.DataSource = productosTable;

                // Calcular y mostrar el total del inventario en label2
                CalcularTotalInventario();
                // Calcular y mostrar la cantidad total de productos en label5
                CalcularTotalCantidadProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // Método para calcular el valor total del inventario
        private void CalcularTotalInventario()
        {
            double totalInventario = 0;

            if (productosTable != null)
            {
                foreach (DataRow row in productosTable.Rows)
                {
                    double precioUnitario = Convert.ToDouble(row["PrecioUnitario"]);
                    double cantidad = Convert.ToDouble(row["Cantidad"]);
                    totalInventario += precioUnitario * cantidad;
                }
            }

            label2.Text = totalInventario.ToString("N2");
        }

        // Método para calcular la cantidad total de productos
        private void CalcularTotalCantidadProductos()
        {
            double totalCantidad = 0;

            if (productosTable != null)
            {
                foreach (DataRow row in productosTable.Rows)
                {
                    totalCantidad += Convert.ToDouble(row["Cantidad"]);
                }
            }

            label5.Text = totalCantidad.ToString("N0");
        }

        // Evento para filtrar productos según la categoría seleccionada
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaSeleccionada = comboBox2.SelectedItem.ToString();
            CargarProductos(categoriaSeleccionada);
        }

        // Evento Load del formulario
        private void FrmInventarios_Load(object sender, EventArgs e)
        {
            CargarCategorias(); // Llenar ComboBox al cargar el formulario
            CargarProductos();  // Llenar DataGridView con todos los productos inicialmente
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
