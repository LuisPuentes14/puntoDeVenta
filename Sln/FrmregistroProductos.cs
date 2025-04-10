using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Para usar InputBox

namespace Proyecto_Metodologia
{
    public partial class FrmRegistroProductos : Form
    {

        private DataSet aDatos;
        private int contador = 1; // Contador para ComboBox y TextBox
        public FrmRegistroProductos()
        {
            InitializeComponent();
          //  LlenarDatos();
            CargarCategorias();
            CargarProveedores();          

        }

        //private void btnModificar_Click(object sender, EventArgs e)
        private void iconButton4_Click(object sender, EventArgs e)
        {
            
        }


        private string ObtenerConexion()
        {
            return ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        }

        
        public DataSet EjecutarSelect(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexion = new SqlConnection(ObtenerConexion()))
            {
                conexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                if (parametros != null)
                {
                    foreach (var param in parametros)
                    {
                        adapter.SelectCommand.Parameters.Add(param);
                    }
                }
                aDatos = new DataSet();
                adapter.Fill(aDatos);
            }
            return aDatos;
        }

        public DataTable ObtenerProductos()
        {
            string consulta = "SELECT * FROM TProductos";
            return EjecutarSelect(consulta).Tables[0];
        }

        private void CargarCategorias()
        {
            string consulta = "SELECT IdCategoría, NombreCategoría FROM Categorías";
            DataTable dt = EjecutarSelect(consulta).Tables[0];
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "NombreCategoría";
            comboBox1.ValueMember = "NombreCategoría";
        }

        private void CargarProveedores()
        {
            string consulta = "SELECT IdProveedor, NombreCompañía FROM Proveedores";
            DataTable dt = EjecutarSelect(consulta).Tables[0];
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "NombreCompañía";
            comboBox2.ValueMember = "NombreCompañía";
        }
            

        private void EjecutarComando(string consulta, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = new SqlConnection(ObtenerConexion()))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery(); // Ejecuta la consulta
                }
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtIva.Text) ||
                comboBox1.SelectedValue == null ||
                comboBox2.SelectedValue == null ||
                comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!float.TryParse(txtCantidad.Text, out float cantidad))
            {
                MessageBox.Show("Cantidad debe ser un número válido.");
                return;
            }

            if (!float.TryParse(txtPrecio.Text, out float precioUnitario))
            {
                MessageBox.Show("Precio Unitario debe ser un número válido.");
                return;
            }

            if (!int.TryParse(txtIva.Text, out int iva))
            {
                MessageBox.Show("IVA debe ser un número válido.");
                return;
            }

            if (!float.TryParse(txtCompra.Text, out float precioCompra))
            {
                MessageBox.Show("Precio de compra debe ser un número válido.");
                return;
            }

            try
            {
                string consulta = "INSERT INTO TProductos (CodigoProducto, Descripcion, Unidad, Cantidad, PrecioUnitario, Iva, Categoria, Proveedor, PrecioCompra) " +
                                  "VALUES (@CodigoProducto, @Descripcion, @Unidad, @Cantidad, @PrecioUnitario, @Iva, @Categoria, @Proveedor, @PrecioCompra)";

                SqlParameter[] parametros = {
            new SqlParameter("@CodigoProducto", txtCodigo.Text.Trim()),
            new SqlParameter("@Descripcion", txtDescripcion.Text.Trim()),
            new SqlParameter("@Unidad", comboBox3.SelectedItem.ToString()),
            new SqlParameter("@Cantidad", cantidad),
            new SqlParameter("@PrecioUnitario", precioUnitario),
            new SqlParameter("@Iva", iva),
            new SqlParameter("@Categoria", comboBox1.SelectedValue.ToString()),
            new SqlParameter("@Proveedor", comboBox2.SelectedValue.ToString()),
            new SqlParameter("@PrecioCompra", precioCompra)
        };

                EjecutarComando(consulta, parametros);
                MessageBox.Show("Producto agregado correctamente.");

              //  LlenarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error al agregar producto: " + ex.Message);
            }
        
}

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtIva.Clear();
            txtCompra.Clear();

            // Reiniciar ComboBox a su estado inicial
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            // Opcional: Establecer el foco en el primer campo
            txtCodigo.Focus();
        }

       // private void iconButton4_Click(object sender, EventArgs e)
        //{
            
       // }
    }
}
