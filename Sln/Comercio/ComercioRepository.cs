

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_Metodologia.Comercio
{
    public class ComercioRepository
    {
        private DataSet aDatos;

        public DataSet Datos
        {
            get { return aDatos; }
        }

        public DataSet EjecutarSelect(string Consulta)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                conexion.Open();
                SqlDataAdapter a = new SqlDataAdapter(Consulta, conexion);
                aDatos = new DataSet();
                a.Fill(aDatos);
                conexion.Close();
            }
            return aDatos;
        }

        public string ValorAtributo(string pNombreCampo)
        {
            if (Datos.Tables[0].Rows.Count > 0)
            {
                return Datos.Tables[0].Rows[0][pNombreCampo].ToString();
            }
            return "";
        }

        public string[] obtenerDatosComercio()
        {
            string[] datos = new string[5];

            // Actualiza la consulta para solo obtener la columna 'Unidad'
            string Consulta = "SELECT Nombre, CONCAT('NIT: ',NIT)AS NIT, CONCAT('TLF: ', Telefono) AS Telefono, CONCAT('DIR: ', Direccion) AS Direccion, Correo FROM Comercio";

            EjecutarSelect(Consulta);

            datos[0] = ValorAtributo("Nombre");
            datos[1] = ValorAtributo("Telefono");
            datos[2] = ValorAtributo("NIT");
            datos[3] = ValorAtributo("Direccion");
            datos[4] = ValorAtributo("Correo");
            return datos;
        }
    }
}
