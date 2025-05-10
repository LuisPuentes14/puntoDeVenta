
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Data;

namespace Proyecto_Metodologia.Productos
{
    public class ProductoRepository
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

        public string[] obtenerDatos(string pCodigo)
        {
            string[] datos = new string[10]; // Ahora tenemos un nuevo campo para la cantidad

            // Actualiza la consulta para solo obtener la columna 'Unidad'
            string Consulta = long.TryParse(pCodigo, out long result)
                ? $"SELECT * FROM TProductos WHERE CodigoProducto = '{pCodigo}'"
                : $"SELECT * FROM TProductos WHERE Descripcion LIKE '%{pCodigo}%'";

            EjecutarSelect(Consulta);

            datos[0] = ValorAtributo("CodigoProducto");
            datos[1] = ValorAtributo("Descripcion");
            datos[6] = ValorAtributo("PrecioUnitario");
            datos[2] = ValorAtributo("Unidad");  // Solo obtenemos la unidad
            datos[7] = ValorAtributo("Iva");
            datos[8] = ValorAtributo("Cantidad"); // Ahora cargamos el campo Cantidad
            datos[9] = ValorAtributo("ValorIVA");


            return datos;
        }

        public void ActualizarStockProducto(string idProducto, float cantidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    conexion.Open();
                    string queryActualizarInventario = "UPDATE Tproductos SET cantidad = cantidad - @Cantidad WHERE CodigoProducto = @CodigoProducto";
                    using (SqlCommand cmdActualizar = new SqlCommand(queryActualizarInventario, conexion))

                    {
                        cmdActualizar.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmdActualizar.Parameters.AddWithValue("@CodigoProducto", idProducto);
                        cmdActualizar.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al actualizar el stock del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception();
                }
            }
        }
    }
}
