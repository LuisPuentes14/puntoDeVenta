using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmAdministrarProveedores : Form
    {
        private FrmProveedores _fatherForm;
        public FrmAdministrarProveedores(FrmProveedores fatherForm)
        {
            InitializeComponent();
            CargarDatos();
            _fatherForm = fatherForm; 
        }

        //evento para crear un nuevo proveedor
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _fatherForm.AbrirFormularioHijo(new FrmregistroProveedores(new FrmProveedores()));
        }

        //evento para actualizar los datos de la tabla
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        // eventos para cargar los datos en tiempo real
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            CargarProveedores(filtro);
        }

        // evento para eliminar los proveedores
        private void iconButton3_Click(object sender, EventArgs e)
        {
            DeleteProveedores();
        }

        // EVENTO POR LETRA
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && dataGridView1.SelectedRows.Count > 0)
            {
                DeleteProveedores(); // tu método para borrar de DB
                CargarDatos(); // refresca la tabla   
            }
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedRows.Count > 0)
            {
                ActualizarDatos();
            }
        }



        #region FUNCIONES
        //funcion para cargar los datos de la tabla
        private void CargarDatos()
        {
            string query = "SELECT * FROM Proveedores";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        //funcion para cargar los proveedores en tiempo real
        private void CargarProveedores(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT * FROM Proveedores 
                     WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (NombreContacto LIKE @Filtro OR NombreCompañía LIKE @Filtro OR Direccion LIKE @Filtro OR Ciudad LIKE @Filtro OR Telefono LIKE @Filtro)";
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

        //funcion para eliminar los proveedores
        private void DeleteProveedores()
        {
            {
                DialogResult confirm = MessageBox.Show("¿Estás seguro que deseas eliminar este proveedor?",
                                                       "Confirmar eliminación",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string idProveedor = dataGridView1.SelectedRows[0].Cells["IdProveedor"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM Proveedores WHERE IdProveedor = @idProveedor";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Proveedor eliminado correctamente.");
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            }
                            else
                            {
                                MessageBox.Show("Error: No se pudo eliminar el proveedor.");
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

        private void ActualizarDatos() 
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string idProvedor = row.Cells["IdProveedor"].Value.ToString();
                    string nombreCompañia = row.Cells["NombreCompañía"].Value.ToString();
                    string nombreContacto = row.Cells["NombreContacto"].Value.ToString();
                    string Direccion = row.Cells["Direccion"].Value.ToString();
                    string ciudad = row.Cells["Ciudad"].Value.ToString();
                    string telefono = row.Cells["Telefono"].Value.ToString();

                    string query = @" UPDATE Proveedores SET  NombreCompañía = @NombreCompañia, NombreContacto = @NombreContacto, Direccion = @Direccion, Ciudad = @Ciudad WHERE IdProveedor = @IdProveedor";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdProveedor", idProvedor);
                        cmd.Parameters.AddWithValue("@NombreCompañia", nombreCompañia);
                        cmd.Parameters.AddWithValue("@NombreContacto", nombreContacto);
                        cmd.Parameters.AddWithValue("@Direccion", Direccion);
                        cmd.Parameters.AddWithValue("@Ciudad", ciudad);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cambios guardados correctamente.");
            }
        }
        #endregion
    }
}
