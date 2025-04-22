using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Proyecto_Metodologia
{
    public partial class FrmStockProductos : Form
    {
        public FrmStockProductos()
        {
            InitializeComponent();
        }

        #region EVENTOS
        //evento para cargar el formulario
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            CargarDatos();
        }
        //evento para actualizar los datos de la tabla
        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
        //boton para eliminar
        private void iconButton3_Click(object sender, EventArgs e)
        {
            DeleteProducts();
        }
        // EVENTO POR LETRA
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && dataGridView1.SelectedRows.Count > 0)
            {     
                    DeleteProducts(); // tu método para borrar de DB
                    CargarProductos(); // refresca la tabla   
            }
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedRows.Count > 0)
            {
                ActualizarDatos();
            }
        }
        // boton de agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProveedores proveedores = new FrmProveedores();
            proveedores.AbrirFormularioHijo(new FrmregistroProveedores(new FrmProveedores()));
        }
        //evento buscar en tiempo real
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            CargarProductos(filtro);

        }
        //evento para cerrar el formulario
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


        #region FUNCIONES
        //FUNCION CARGAR DATOS
        private void CargarDatos()
        {
            string query = "select * from TProductos"; // Cambiá por tu tabla

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
        //FUNCION PARA ACTUALIZAR PRODUCTOS
        private void ActualizarDatos() 
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string codigo = row.Cells["CodigoProducto"].Value.ToString();
                    string descripcion = row.Cells["Descripcion"].Value.ToString();
                    string unidad = row.Cells["Unidad"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                    int iva = Convert.ToInt32(row.Cells["Iva"].Value);
                    string categoria = row.Cells["Categoria"].Value.ToString();
                    string proveedor = row.Cells["Proveedor"].Value.ToString();

                    string query = @"UPDATE TProductos 
                             SET Descripcion = @descripcion, Unidad = @unidad, Cantidad = @cantidad, 
                                 PrecioUnitario = @precioUnitario, Iva = @iva, Categoria = @categoria, Proveedor = @proveedor 
                             WHERE CodigoProducto = @codigo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@unidad", unidad);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                        cmd.Parameters.AddWithValue("@iva", iva);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor);
                        cmd.Parameters.AddWithValue("@codigo", codigo);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cambios guardados correctamente.");
            }
        }
        //FUNCION ELIMINAR PRODUCTOS
        private void DeleteProducts()
        {
            {
                DialogResult confirm = MessageBox.Show("¿Estás seguro que deseas eliminar este producto?",
                                                       "Confirmar eliminación",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string codigoProducto = dataGridView1.SelectedRows[0].Cells["CodigoProducto"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM TProductos WHERE CodigoProducto = @codigo";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigoProducto);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Producto eliminado correctamente.");
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            }
                            else
                            {
                                MessageBox.Show("Error: No se pudo eliminar el producto.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una fila para eliminar.");
                }
            }
        }
        //funcion para el filtrado en tiempo real
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
                        dataGridView1.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
    }
}

