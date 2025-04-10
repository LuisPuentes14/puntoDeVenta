using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_Metodologia
{
    public partial class FrmRegistroUsuarios : Form
    {
        private DataSet aDatos;

        public FrmRegistroUsuarios()
        {
            InitializeComponent();
            llenardatos();
            llenarComboCategoria(); // Llenar ComboBox al cargar el formulario
        }

        public DataSet Datos
        {
            get { return aDatos; }
        }

        public void llenarComboCategoria()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Administrador");
            cmbCategoria.Items.Add("Cajero");
            cmbCategoria.SelectedIndex = 0; // Selecciona "Administrador" por defecto
        }

        public DataSet EjecutarSelect(string pConsulta)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlDataAdapter a = new SqlDataAdapter();
                a.SelectCommand = new SqlCommand(pConsulta, conexion);
                aDatos = new DataSet();
                a.Fill(aDatos);
                conexion.Close();
            }
            return aDatos;
        }

        public void registrarUsuario()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    string categoria = cmbCategoria.SelectedItem.ToString(); // Obtiene el valor del ComboBox

                    string query = "INSERT INTO TUsuarios (Usuario, Contraseña, Nombre, Apellidos, DNI, Correo, Categoria) " +
                                   "VALUES (@Usuario, @Contraseña, @Nombre, @Apellidos, @DNI, @Correo, @Categoria)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", txtusuario.Text);
                        cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellido.Text);
                        cmd.Parameters.AddWithValue("@DNI", txtDni.Text);
                        cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Categoria", categoria);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Usuario registrado exitosamente.");
                            llenardatos();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el usuario.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string Consulta = "UPDATE TUsuarios SET Nombre=@Nombre, Apellidos=@Apellidos, Correo=@Correo, Categoria=@Categoria WHERE Usuario=@Usuario";

                string categoria = cmbCategoria.SelectedItem.ToString();

                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(Consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", txtusuario.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellido.Text);
                        cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Categoria", categoria);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ACTUALIZACIÓN CORRECTA");
                        llenardatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN LA ACTUALIZACIÓN: " + ex.Message);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            string Consulta = "DELETE FROM TUsuarios WHERE Usuario=@Usuario";
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(Consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@Usuario", txtusuario.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ELIMINACIÓN CORRECTA");
                    llenardatos();
                }
            }
        }

        public DataTable datosusuarios()
        {
            string Consulta = "SELECT * FROM TUsuarios";
            EjecutarSelect(Consulta);
            return Datos.Tables[0];
        }

        public void llenardatos()
        {
            dgvusuarios.DataSource = datosusuarios();
            dgvusuarios.Columns["Contraseña"].Visible = false;
        }

        private void dgvusuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtusuario.Text = dgvusuarios[0, e.RowIndex].Value.ToString();
                txtNombre.Text = dgvusuarios[1, e.RowIndex].Value.ToString();
                txtApellido.Text = dgvusuarios[2, e.RowIndex].Value.ToString();
                txtDni.Text = dgvusuarios[4, e.RowIndex].Value.ToString();
                txtCorreo.Text = dgvusuarios[5, e.RowIndex].Value.ToString();

                // Cargar la categoría en el ComboBox
                string categoria = dgvusuarios[6, e.RowIndex].Value.ToString();
                cmbCategoria.SelectedItem = categoria;
            }
        }

        private void FrmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            llenarComboCategoria(); // Asegurar que el ComboBox se llene al iniciar el formulario
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    string categoria = cmbCategoria.SelectedItem.ToString(); // Obtiene el valor del ComboBox

                    string query = "INSERT INTO TUsuarios (Usuario, Contraseña, Nombre, Apellidos, DNI, Correo, Categoria) " +
                                   "VALUES (@Usuario, @Contraseña, @Nombre, @Apellidos, @DNI, @Correo, @Categoria)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", txtusuario.Text);
                        cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtApellido.Text);
                        cmd.Parameters.AddWithValue("@DNI", txtDni.Text);
                        cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@Categoria", categoria);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Usuario registrado exitosamente.");
                            llenardatos();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el usuario.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
