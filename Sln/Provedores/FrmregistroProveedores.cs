using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmregistroProveedores : Form
    {
        private FrmProveedores _FatherForm;

        #region EVENTS
        public FrmregistroProveedores(FrmProveedores fatherForm)
        {
            InitializeComponent();
            _FatherForm = fatherForm;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GuardarProveedor();
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            _FatherForm.AbrirFormularioHijo(new FrmAdministrarProveedores(_FatherForm));
        }
        #endregion



        #region FUNCIONES
        private void CleanForm() 
        {
            txtCiudad.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txTelefono.Text = string.Empty;
        }

        private void GuardarProveedor()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtCiudad.Text) || string.IsNullOrEmpty(txTelefono.Text) || string.IsNullOrEmpty(txtContacto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = @"
                INSERT INTO Proveedores (IdProveedor, NombreCompañía, NombreContacto, Direccion, Ciudad, Telefono)
                VALUES (@IdProveedor, @NombreCompañia, @NombreContacto, @Direccion, @Ciudad, @Telefono)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores desde los controles del formulario
                        cmd.Parameters.AddWithValue("@IdProveedor", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@NombreCompañia", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@NombreContacto", txtContacto.Text);
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txTelefono.Text);

                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Proveedor guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CleanForm();
        }
        #endregion
    }
}
