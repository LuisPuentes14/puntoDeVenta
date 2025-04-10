using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmregistroProveedores : Form
    {
        public FrmregistroProveedores()
        {
            InitializeComponent();
        }

        private void GuardarProveedor()
        {
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
                        cmd.Parameters.AddWithValue("@NombreContacto", txtUnidad.Text);
                        cmd.Parameters.AddWithValue("@Direccion", txtCantidad.Text);
                        cmd.Parameters.AddWithValue("@Ciudad", txtPrecio.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtIva.Text);

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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GuardarProveedor();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
