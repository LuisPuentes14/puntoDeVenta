using System;
using System.Configuration;
using System.Data.SqlClient;

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
                    string query = "INSERT INTO CARTERA VALUES(@DocumentoCliente, @AbonoInicial, @IdVenta, @FechaCartera)";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@DocumentoCliente", cartera.DocumentoCliente);
                        cmd.Parameters.AddWithValue("@AbonoInicial", cartera.AbonoInicial);
                        cmd.Parameters.AddWithValue("@IdVenta", cartera.IdVenta);
                        cmd.Parameters.AddWithValue("@FechaCartera", cartera.FechaCartera);
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


        public bool InsertarHistoricoCartera(DetalleCarteraDto cartera)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    string query = "NSERT INTO HistoricoCartera values(@IdCartera, @MontoAbono, @FechaAbono)";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdCartera", cartera.IdCartera);
                        cmd.Parameters.AddWithValue("@MontoAbono", cartera.MontoAbono);
                        cmd.Parameters.AddWithValue("@FechaAbono", cartera.FechaAbono);
                        cmd.ExecuteNonQuery();
                    }
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