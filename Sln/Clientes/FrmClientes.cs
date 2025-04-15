using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar de nuevo los elementos de búsqueda
            State_acount.Visible = true;
            Button_acept.Visible = true;
            dataGridView1.Visible = true;
            label1.Visible = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evitar sonido de error en el textbox
                string idCliente = State_acount.Text.Trim();

                if (!string.IsNullOrEmpty(idCliente))
                {
                    llenardatos(idCliente); // Filtrar datos si se ingresó un valor
                }
                else
                {
                    llenardatos(); // Si está vacío, mostrar todos los datos
                }
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

           }

        public void registrarClienta()
        { }

        public DataTable datosClientes(string idCliente = "")
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();

                string consulta = "SELECT IdCliente, Nombre, Apellido, Teléfono, Saldo FROM Clientes";

                if (!string.IsNullOrEmpty(idCliente))
                {
                    consulta += " WHERE IdCliente = @IdCliente"; // Filtrar si se proporciona un ID
                }

                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (!string.IsNullOrEmpty(idCliente))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public void llenardatos(string idCliente = "")
        {
            dataGridView1.DataSource = datosClientes(idCliente);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    // Consulta SQL para insertar en la tabla Clientas
                    string query = "INSERT INTO Clientes (IdCliente, Nombre, Apellido, Teléfono) " +
                                   "VALUES (@IdCliente, @Nombre, @Apellido, @Telefono)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores de los TextBox a los parámetros de la consulta SQL
                        cmd.Parameters.AddWithValue("@IdCliente", Id_client.Text);
                        cmd.Parameters.AddWithValue("@Nombre", Name_client.Text);
                        cmd.Parameters.AddWithValue("@Apellido", LastName_client.Text);
                        cmd.Parameters.AddWithValue("@Telefono", CellPhone_client.Text);

                        int result = cmd.ExecuteNonQuery(); // Ejecutar la consulta

                        if (result > 0)
                        {
                            MessageBox.Show("Clienta registrada exitosamente.");
                            llenardatos(); // Método para actualizar el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar la clienta.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    // Consulta SQL para insertar en la tabla Clientas
                    string query = "INSERT INTO Clientes (IdCliente, Nombre, Apellido, Teléfono) " +
                                   "VALUES (@IdCliente, @Nombre, @Apellido, @Telefono)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores de los TextBox a los parámetros de la consulta SQL
                        cmd.Parameters.AddWithValue("@IdCliente", Id_client.Text);
                        cmd.Parameters.AddWithValue("@Nombre", Name_client.Text);
                        cmd.Parameters.AddWithValue("@Apellido", LastName_client.Text);
                        cmd.Parameters.AddWithValue("@Telefono", CellPhone_client.Text);

                        int result = cmd.ExecuteNonQuery(); // Ejecutar la consulta

                        if (result > 0)
                        {
                            MessageBox.Show("Clienta registrada exitosamente.");
                            llenardatos(); // Método para actualizar el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar la clienta.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Ocultar y mostrar elementos para registrar un nuevo cliente
            State_acount.Visible = false;
            Button_acept.Visible = false;
            dataGridView1.Visible = false;
            label1.Visible = false;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            Id_client.Visible = true;
            Name_client.Visible = true;
            LastName_client.Visible = true;
            CellPhone_client.Visible = true;
            button_save_client.Visible = true;
        }

        private void FrmClientes_Load_1(object sender, EventArgs e)
        {
            State_acount.KeyDown += new KeyEventHandler(textBox1_KeyDown);
            llenardatos(); // Cargar los datos al iniciar
            // Configuración inicial de visibilidad
            State_acount.Visible = true;
            Button_acept.Visible = true;
            dataGridView1.Visible = true;
            label1.Visible = true;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            Id_client.Visible = false;
            Name_client.Visible = false;
            LastName_client.Visible = false;
            CellPhone_client.Visible = false;
            button_save_client.Visible = false;

            llenardatos(); // Cargar los datos al iniciar

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verificar si el campo de búsqueda no está vacío
            string idCliente = State_acount.Text.Trim();

            if (string.IsNullOrEmpty(idCliente))
            {
                MessageBox.Show("Por favor, ingrese un ID de cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación antes de eliminar
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                    using (SqlConnection conexion = new SqlConnection(cnn))
                    {
                        conexion.Open();

                        string query = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";

                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                llenardatos(); // Actualizar DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se encontró un cliente con ese ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}