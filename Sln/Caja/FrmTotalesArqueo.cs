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
    public partial class FrmTotalesArqueo : Form
    {
        private DataSet aDatos;
        public FrmTotalesArqueo()
        {
            InitializeComponent();
            dateTimeArqueo.Value = DateTime.Now;
        }
        public DataSet Datos
        {
            get { return aDatos; }
        }
        public DataSet EjecutarSelect(string pConsulta)
        {//-- Método para ejecutar consultas del tipo SELECT
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                SqlDataAdapter a = new SqlDataAdapter();
              //  using (SqlCommand cmd = new SqlCommand(pConsulta, conexion)) ;
                a.SelectCommand = new SqlCommand(pConsulta, conexion);
                aDatos = new DataSet();
                // aAdaptador.Fill(aDatos);
                a.Fill(aDatos);
                conexion.Close();
            }
            return aDatos;
        }
        public string ValorAtributo(string pNombreCampo)
        {//-- Recupera el valor de un atributo del dataset
            if (Datos.Tables[0].Rows.Count > 0)
            {
                return Datos.Tables[0].Rows[0][pNombreCampo].ToString();
            }
            else
                return "";
        }
        public DataTable validarfecha()
        {
            string consulta = "SELECT * FROM ARQUEO WHERE CAST(Fecha AS DATE) = @fecha";

            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@fecha", dateTimeArqueo.Value.Date);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    aDatos = new DataSet();
                    da.Fill(aDatos);
                }
            }
            return aDatos.Tables[0];
        }
        public DataTable validarfecha2()
        {
            string Consulta = "SELECT * FROM ARQUEO ";

            EjecutarSelect(Consulta);
            return Datos.Tables[0];
        }

        private void dateTimeArqueo_ValueChanged(object sender, EventArgs e)
        {
            CargarArqueosPorFecha(dateTimeArqueo.Value.Date);
        }

        private void CargarArqueosPorFecha(DateTime fecha)
        {
            // Asegura que el formato de la fecha sea compatible con el de tu VARCHAR (por ejemplo: "dd/MM/yyyy")
            string consulta = @"
        SELECT * FROM ARQUEO 
        WHERE CONVERT(date, Fecha, 103) = @fecha";

            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(conexionString))
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    dgventas.DataSource = tabla;
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal static FrmTotalesArqueo GetInstancia()
        {
            throw new NotImplementedException();
        }
    }
}
