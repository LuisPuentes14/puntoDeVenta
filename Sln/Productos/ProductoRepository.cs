
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using AutoCompletarTextBox;
using System.Windows.Forms;
using System;

namespace Proyecto_Metodologia.Productos
{
    public class ProductoRepository
    {
        FrmVentas frmVentas = new FrmVentas();

        public string[] obtenerDatos(string pCodigo)
        {
            string[] datos = new string[9]; // Ahora tenemos un nuevo campo para la cantidad

            // Actualiza la consulta para solo obtener la columna 'Unidad'
            string Consulta = long.TryParse(pCodigo, out long result)
                ? $"SELECT * FROM TProductos WHERE CodigoProducto = '{pCodigo}'"
                : $"SELECT * FROM TProductos WHERE Descripcion LIKE '%{pCodigo}%'";

            frmVentas.EjecutarSelect(Consulta);

            datos[0] = frmVentas.ValorAtributo("CodigoProducto");
            datos[1] = frmVentas.ValorAtributo("Descripcion");
            datos[6] = frmVentas.ValorAtributo("PrecioUnitario");
            datos[2] = frmVentas.ValorAtributo("Unidad");  // Solo obtenemos la unidad
            datos[7] = frmVentas.ValorAtributo("Iva");
            datos[8] = frmVentas.ValorAtributo("Cantidad"); // Ahora cargamos el campo Cantidad

            return datos;
        }

        public void ActualizarStockProducto(string idProducto, float cantidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {

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
