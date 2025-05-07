
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using Proyecto_Metodologia.Dtos;

namespace Proyecto_Metodologia.Clientes
{
    public class ClienteRepository
    {
        public bool ValidarCliente(string documento)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT 1  FROM Clientes where idCliente = @idCliente";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", documento);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            return true; // El cliente existe
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener información del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Error al consultar la base de datos

                }
            }
        }
        public void InsertarCliente(ClienteDto cliente)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    conexion.Open();
                    string queryDetalle = "INSERT INTO Clientes VALUES (@idCliente, @nombre, @apellido, @telefono, @correo)";
                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion))
                    {
                        cmdDetalle.Parameters.AddWithValue("@idCliente", cliente.Documento);
                        cmdDetalle.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        cmdDetalle.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        cmdDetalle.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        cmdDetalle.Parameters.AddWithValue("@correo", cliente.Correo);
                        cmdDetalle.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public ClienteDto ObtenerInfoCliente(string idCliente)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                try
                {
                    ClienteDto cliente = new ClienteDto();
                    conexion.Open();
                    string query = "SELECT nombre,apellido,telefono,correo  FROM Clientes where idCliente = @idCliente";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            cliente.Nombre = reader["nombre"].ToString();
                            cliente.Apellido = reader["apellido"].ToString();
                            cliente.Telefono = reader["telefono"].ToString();
                            cliente.Correo = reader["correo"].ToString();
                        }
                        return cliente;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener información del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new ClienteDto(); // Error al consultar la base de datos

                }
            }
        }
    }
}
