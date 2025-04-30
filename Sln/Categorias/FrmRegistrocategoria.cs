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
    public partial class FrmRegistrocategoria : Form
    {
        public FrmRegistrocategoria()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registrar();
        }

        public void inicializar()
        {
            txtusuario.Text = "";
            txtNombre.Text = "";
        }

        public void registrar()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    string query = "INSERT INTO Categorias (IdCategoria, NombreCategoria) VALUES (@Id, @Nombre)";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtusuario.Text));
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Categoria registrada exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar la categoria.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}