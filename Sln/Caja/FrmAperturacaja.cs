using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Proyecto_Metodologia
{
    public partial class FrmAperturacaja : Form
    {
        private SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

      string cajero = CONSTANS.USER;


        public FrmAperturacaja()
        {
            InitializeComponent();
        }

       

        private void GuardarRegistro()
        {
            try
            {
                cnn.Open();

                // Obtener el próximo código disponible
                string getCodigoQuery = "SELECT ISNULL(MAX(codigo), 0) + 1 FROM aperturacaja";
                SqlCommand getCodigoCmd = new SqlCommand(getCodigoQuery, cnn);
                int nuevoCodigo = (int)getCodigoCmd.ExecuteScalar();

                // Insertar nuevo registro con código autoincremental
                string query = "INSERT INTO aperturacaja (codigo, Usuario, valor, fecha) VALUES (@Codigo, @Usuario, @Valor, @Fecha)";
                SqlCommand cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@Codigo", nuevoCodigo);
                cmd.Parameters.AddWithValue("@Usuario", cajero);
                cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Registro guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario después de guardar

                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        private void FrmAperturacaja_Load(object sender, EventArgs e)
        {

        }
    }
}
