using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia.Clientes
{
    public partial class FrmAdministrarClientes : Form
    {
        public FrmAdministrarClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        #region EVENTOS
        //input que para filtrar en tiempo real
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            CargarClientes(filtro);
        }
        //evento para actualizar o eliminar los datos de la tabla
        private void dataDgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && dgClientes.SelectedRows.Count > 0)
            {
                DeleteClientes(); // tu método para borrar de DB
                CargarClientes(); // refresca la tabla   
            }
            if (e.KeyCode == Keys.Enter && dgClientes.SelectedRows.Count > 0)
            {
                ActualizarDatos();
            }
        }
        // evento para actualizar por el boton
        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }
        //evento para eliminar por el boton
        private void iconButton3_Click(object sender, EventArgs e)
        {
            DeleteClientes();
        }
        //evento para salir 
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        #region FUNCIONES 
        //FUNCION ELIMINAR PRODUCTOS
        private void DeleteClientes()
        {
            {
                DialogResult confirm = MessageBox.Show("¿Estás seguro que deseas eliminar este cliente?",
                                                       "Confirmar eliminación",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string documento = dgClientes.SelectedRows[0].Cells["Documento"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM clientes WHERE IdCliente = @Documento";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Documento", documento);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cliente eliminado correctamente.");
                                dgClientes.Rows.RemoveAt(dgClientes.SelectedRows[0].Index);
                            }
                            else
                            {
                                MessageBox.Show("Error: No se pudo eliminar el cliente.");
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
        //FUNCION ACTUALIZAR CLIENTES
        private void ActualizarDatos()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dgClientes.Rows)
                {
                    if (row.IsNewRow) continue;

                    string documento = row.Cells["Documento"].Value.ToString();
                    string nombre = row.Cells["Nombre"].Value.ToString();
                    string apellido = row.Cells["Apellido"].Value.ToString();
                    string telefono = row.Cells["Telefono"].Value.ToString();
                    string correo = row.Cells["Correo"].Value.ToString();


                    string query = @"UPDATE CLIENTES 
                      SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, 
                          Correo = @Correo
                      WHERE IdCliente = @Documento";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Documento", documento);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellido", apellido);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cambios guardados correctamente.");
            }
        }
        //FUNCION CARGAR DATOS
        private void CargarClientes(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"select IdCliente as Documento, Nombre, Apellido, Telefono, Correo from Clientes 
                     WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (IdCliente LIKE @Filtro OR Nombre LIKE @Filtro OR Apellido LIKE @Filtro OR Telefono LIKE @Filtro OR Correo LIKE @Filtro)";
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
                        MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
    }
}
