using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    //System.Data.SqlClient;

    public class AutoCompletarTextBox
    {
        private SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BDSISTEMA_VENTAS;Integrated Security=True"); // Reemplaza con tu cadena de conexión

        public SqlConnection Cnn { get => cnn; set => cnn = value; }

        public void ConfigurarAutocompletado(TextBox cajaTexto)
        {
            try
            {
                if (Cnn.State != ConnectionState.Open)
                {
                    Cnn.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT Descripcion FROM Tproductos", Cnn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Limpiar la lista antes de agregar nuevos elementos
                    cajaTexto.AutoCompleteCustomSource.Clear();

                    while (dr.Read())
                    {
                        cajaTexto.AutoCompleteCustomSource.Add(dr["Descripcion"].ToString());
                    }
                }

                // Activar Autocompletado
                ActivarAutocompletado(cajaTexto);

                // Manejar el evento KeyDown
                cajaTexto.KeyDown += new KeyEventHandler(txtcodp_KeyDown);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el autocompletado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActivarAutocompletado(TextBox cajaTexto)
        {
            cajaTexto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cajaTexto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void DesactivarAutocompletado(TextBox cajaTexto)
        {
            cajaTexto.AutoCompleteMode = AutoCompleteMode.None;
            cajaTexto.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void txtcodp_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Evita el "beep" de Windows

                if (!string.IsNullOrWhiteSpace(txt.Text))
                {
                    // Desactivar autocompletado antes de ejecutar la acción
                    DesactivarAutocompletado(txt);

                    // Ejecutar acción con el dato seleccionado
                    MessageBox.Show("Producto seleccionado: " + txt.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cargar información del producto
                    CargarDatosProducto(txt.Text);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CargarDatosProducto(string descripcion)
        {
            // Aquí colocas la lógica para cargar los datos del producto
            MessageBox.Show("Cargando datos del producto: " + descripcion);
        }
    }
}