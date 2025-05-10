using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia.Cartera
{
    public class CarteraRepository
    {
        public bool InsertarCartera(CarteraDto cartera)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO CARTERA VALUES(@DocumentoCliente, @AbonoInicial, @IdVenta, @FechaCartera, @EstadoCartera)";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@DocumentoCliente", cartera.DocumentoCliente);
                        cmd.Parameters.AddWithValue("@AbonoInicial", cartera.AbonoInicial);
                        cmd.Parameters.AddWithValue("@IdVenta", cartera.IdVenta);
                        cmd.Parameters.AddWithValue("@FechaCartera", cartera.FechaCartera);
                        cmd.Parameters.AddWithValue("@EstadoCartera", cartera.EstadoCartera);
                        cmd.ExecuteNonQuery();
                    }
                    conexion.Close();
                    return true;
                }
                catch (Exception e) 
                { 
                    return false;
                }
            }
        }
        public void ActualizarEstadoCartera(string idcartera)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = @"UPDATE Cartera SET EstadoCartera = 'Credito Cancelado' WHERE IdCartera = @IDCARTERA";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores desde los controles del formulario
                        cmd.Parameters.AddWithValue("@IDCARTERA", idcartera);
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("¡Credito cancelado, puedes realizar otra compra acreditada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public float ObtenersumaAbonos(string idCartera)
        {
            try
            {
                string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                string query = @"SELECT SUM(MontoAbono) FROM HistoricoCartera WHERE IdCartera = @IDCARTERA";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IDCARTERA", idCartera);

                        conexion.Open();

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != DBNull.Value && resultado != null)
                        {
                            return float.Parse(resultado.ToString());
                        }
                        else
                        {
                            return 0; // si no hay abonos, retorna 0
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void InsertarAbono(string idcartera, float montoAbono)
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                try
                {
                    conexion.Open();
                    string query = @"
                INSERT INTO HistoricoCartera VALUES(@IDCARTERA, @MONTOABONO, @FECHAABONO)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Asignar valores desde los controles del formulario
                        cmd.Parameters.AddWithValue("@IDCARTERA", idcartera);
                        cmd.Parameters.AddWithValue("@MONTOABONO", montoAbono);
                        cmd.Parameters.AddWithValue("@FECHAABONO", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        // Ejecutar la consulta
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Abono realizado Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void CargarCreditos(DataGridView dgCartera, string filtro = "")
        {
            string conexionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            string query = @"SELECT 
                                C.IdVenta,
                                FORMAT(CAST(V.PrecioTotal AS money), 'N2', 'es-CO') AS [Precio Total], 
                                FORMAT(CAST(C.AbonoInicial AS money), 'N2', 'es-CO') AS [Abono Inicial], 
                                V.Fecha, 
                                CL.IdCliente AS [Documento Cliente],
                                FORMAT(CAST(ISNULL(SUM(HC.MontoAbono), 0) + C.AbonoInicial AS money), 'N2', 'es-CO') AS [Total Abonado],
                                FORMAT(CAST(V.PrecioTotal - (C.AbonoInicial + ISNULL(SUM(HC.MontoAbono), 0)) AS money), 'N2', 'es-CO') AS [Valor Restante],
                                C.EstadoCartera AS [Estado Cartera],
                                C.IdCartera AS [Id Cartera]
                            FROM Cartera C
                            INNER JOIN TVentas V ON C.IdVenta = V.CodigoVenta
                            INNER JOIN Clientes CL ON CL.IdCliente = V.Cliente
                            LEFT JOIN HistoricoCartera HC ON HC.IdCartera = C.IdCartera
                            WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += @" AND (C.DocumentoCliente LIKE @Filtro)";
            }

            query += @" GROUP BY 
                            C.IdVenta,
                            V.PrecioTotal,
                            C.AbonoInicial,
                            V.Fecha,
                            CL.IdCliente,
                            C.EstadoCartera,
                            C.IdCartera";

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
                        dgCartera.DataSource = tabla;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public bool EliminarCartera(string idVenta) 
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    conexion.Open();
                    string query = @"DELETE FROM HistoricoCartera WHERE IdCartera = @IdidVenta;
                                     GO
                                     DELETE FROM Cartera WHERE IdVenta = @IdidVenta;";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        cmd.ExecuteNonQuery();
                    }
                    conexion.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    
    }
}