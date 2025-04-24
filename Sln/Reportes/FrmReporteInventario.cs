using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Proyecto_Metodologia.Reportes
{
    public partial class FrmReporteInventario : Form
    {
        public FrmReporteInventario()
        {
            InitializeComponent();
            CargarInventario();
        }

        #region EVENTOS
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.Trim().Replace("'", "''");
            CargarInventario(filtro);
        }

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
            ExportarAExcelConClosedXML(datatable, ConfigurationManager.AppSettings["RutaReporteInventario"]);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FUNCIONES
        //FUNCION CARGAR CLIENTES EN TIEMPO REAL
        private void CargarInventario(string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT CodigoProducto, Descripcion, Unidad, Cantidad, PrecioUnitario, Iva, Categoria, Proveedor, PrecioCompra FROM TProductos
                     WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += "AND (CodigoProducto LIKE @Filtro OR Descripcion LIKE @Filtro OR Unidad LIKE @Filtro OR  Cantidad LIKE @Filtro OR PrecioUnitario LIKE @Filtro OR Iva LIKE @Filtro OR Categoria LIKE @Filtro OR Proveedor LIKE @Filtro OR PrecioCompra LIKE @Filtro)";
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
            string query = @"SELECT P.CodigoProducto, P.Descripcion, P.PrecioUnitario, P.PrecioCompra, P.Proveedor, C.FechaCompra FROM TProductos P JOIN Compras C ON P.CodigoProducto = C.CodigoProducto
                     WHERE FechaCompra BETWEEN @desde AND @hasta";

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
        //CARGAR EN MEMORIA LA GRID
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
                    case "PrecioUnitario":
                        tabla.Columns.Add(columna.Name, typeof(float));
                        break;
                    case "Iva":
                        tabla.Columns.Add(columna.Name, typeof(int));
                        break;
                    case "PrecioCompra":
                        tabla.Columns.Add(columna.Name, typeof(float));
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
                            case "PrecioUnitario":
                                nuevaFila[i] = float.TryParse(valor, out float precioUnitario) ? precioUnitario : 0;
                                break;
                            case "PrecioCompra":
                                nuevaFila[i] = float.TryParse(valor, out float precio) ? precio : 0;
                                break;
                            case "Iva":
                                nuevaFila[i] = int.TryParse(valor, out int iva) ? iva : 0;
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
                string nombreArchivo = $"Inventario_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                libro.Worksheets.Add(tabla, "Datos").Columns().AdjustToContents();
                libro.SaveAs(Path.Combine(ruta, nombreArchivo));
            }

            MessageBox.Show("Exportado a Excel (.xlsx) correctamente.");
        }
        #endregion
    }
}
