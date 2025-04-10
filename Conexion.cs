using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AutoCompletarTextBox
{
    class Conexion
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Conexion()
        {
            try
            {
                cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BDSISTEMA_VENTAS;Integrated Security=True");
                cnn.Open(); 

                
                //MessageBox.Show("conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar: " + ex.ToString());
            }
        }

        public void autoCompletar(TextBox cajaTexto)
        {
            try
            {
                cmd = new SqlCommand("Select Descripcion from Tproductos",cnn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cajaTexto.AutoCompleteCustomSource.Add(dr["Descripcion"].ToString());
                }
                dr.Close();
               //.AutoCompleteMode = AutoCompleteMode.None;
               // FrmVentas.txtPublico.AutoCompleteSource = AutoCompleteSource.None;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo autocompletar el TextBox: "+ex.ToString());
            }
        }
    }
}
