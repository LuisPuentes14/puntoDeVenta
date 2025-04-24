using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Proyecto_Metodologia.Reportes
{
    public partial class FrmReporteVentas : Form
    {
        public FrmReporteVentas()
        {
            InitializeComponent();
            CargarVentas();
        }

        #region EVENTOS
        private void dateTimeVentasDesde_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFechas();
        }
        private void dateTimeVentasHasta_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFechas();
        }

        private void btneExportar_Click(object sender, EventArgs e)
        {
            DataTable datatable = ObtenerDataTableDesdeGrid(dgReporte);
            ExportarAExcelConClosedXML(datatable, ConfigurationManager.AppSettings["RutaReporteVentas"]);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            CargarVentas(filtro);
        }
        #endregion

        #region FUNCIONES

        //FUNCION CARGAR CLIENTES EN TIEMPO REAL
        private void CargarVentas(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT V.CodigoVenta as 'Codigo Venta', P.Descripcion, DV.Cantidad as Cantidad, V.PrecioTotal as 'Precio Total', V.Fecha, V.Cajero, V.Cliente FROM TVentas V JOIN DetallesVenta DV ON V.CodigoVenta = DV.IdVenta JOIN TProductos P ON DV.IdProducto = P.CodigoProducto 
                     WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND (p.Descripcion LIKE @Filtro OR v.Fecha LIKE @Filtro OR v.Cajero LIKE @Filtro OR v.Cliente LIKE @Filtro OR v.PrecioTotal LIKE @Filtro)";
            }

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                        cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        adapter.Fill(tabla);
                        dgReporte.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //FILTRADO POR FECHAS
        private void FiltrarPorFechas()
        {
            DateTime desde = dateTimeVentasDesde.Value.Date;
            DateTime hasta = dateTimeVentasHasta.Value.Date;

            if (desde >= hasta)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT V.CodigoVenta as 'Codigo Venta', P.Descripcion, DV.Cantidad as Cantidad, V.PrecioTotal as 'Precio Total', V.Fecha, V.Cajero, V.Cliente FROM TVentas V JOIN DetallesVenta DV ON V.CodigoVenta = DV.IdVenta JOIN TProductos P ON DV.IdProducto = P.CodigoProducto
                     WHERE fecha BETWEEN @desde AND @hasta";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        adapter.Fill(tabla);
                        dgReporte.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //CARGAR GRID EN MEMORIA
        private DataTable ObtenerDataTableDesdeGrid(DataGridView dgv)
        {
            DataTable tabla = new DataTable();

            // Crear columnas con tipo correcto
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                switch (columna.Name)
                {
                    case "Cantidad":
                        tabla.Columns.Add(columna.Name, typeof(int));
                        break;
                    case "Precio Total":
                        tabla.Columns.Add(columna.Name, typeof(decimal));
                        break;
                    case "Cliente":
                        tabla.Columns.Add(columna.Name, typeof(long));
                        break;
                    default:
                        tabla.Columns.Add(columna.Name, typeof(string));
                        break;
                }
            }

            // Copiar filas y castear según tipo
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (!fila.IsNewRow)
                {
                    DataRow nuevaFila = tabla.NewRow();
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        var valor = fila.Cells[i].Value?.ToString() ?? "";

                        switch (dgv.Columns[i].Name)
                        {
                            case "Cantidad":
                                nuevaFila[i] = int.TryParse(valor, out int cant) ? cant : 0;
                                break;
                            case "Precio Total":
                                nuevaFila[i] = decimal.TryParse(valor, out decimal precio) ? precio : 0;
                                break;
                            case "Cliente":
                                nuevaFila[i] = long.TryParse(valor, out long cliente) ? cliente : 0;
                                break;
                            default:
                                nuevaFila[i] = valor;
                                break;
                        }
                    }
                    tabla.Rows.Add(nuevaFila);
                }
            }

            return tabla;
        }
        //EXPORTAR A EXCEL
        private void ExportarAExcelConClosedXML(DataTable tabla, string ruta)
        {
            using (var libro = new XLWorkbook())
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                string nombreArchivo = $"Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                libro.Worksheets.Add(tabla, "Datos").Columns().AdjustToContents();
                libro.SaveAs(Path.Combine(ruta, nombreArchivo));
            }

            MessageBox.Show("Exportado a Excel (.xlsx) correctamente.");
        }
        #endregion
       
    }
}
