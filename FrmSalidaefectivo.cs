using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static Proyecto_Metodologia.FrmSistemaVentas;

namespace Proyecto_Metodologia
{
    public partial class FrmSalidaEfectivo : Form
    {
        private SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BDSISTEMA_VENTAS;Integrated Security=True");
      //  string cajero = ventaglobal.Valorglobal;
        public FrmSalidaEfectivo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Centrar el formulario en pantalla
        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        private void GuardarRegistro()
        {
            try
            {
                cnn.Open();

                // Obtener el próximo código disponible
                string getCodigoQuery = "SELECT ISNULL(MAX(codigo), 0) + 1 FROM salidaefectivo";
                SqlCommand getCodigoCmd = new SqlCommand(getCodigoQuery, cnn);
                int nuevoCodigo = (int)getCodigoCmd.ExecuteScalar();

                // Insertar nuevo registro con código autoincremental
                string query = "INSERT INTO salidaefectivo (codigo, usuario, valor, concepto, fecha) VALUES (@Codigo, @Usuario, @Valor, @Concepto, @Fecha)";
                SqlCommand cmd = new SqlCommand(query, cnn);

                cmd.Parameters.AddWithValue("@Codigo", nuevoCodigo);
              //  cmd.Parameters.AddWithValue("@Usuario", cajero);
                cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(txtValor.Text));
                cmd.Parameters.AddWithValue("@Concepto", txtConcepto.Text);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registro guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmSalidaEfectivo_Load(object sender, EventArgs e)
        {

        }

        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }
    }

}
