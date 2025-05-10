using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmRegistroProductos : Form
    {

        private DataSet aDatos;
        //private int contador = 1; // Contador para ComboBox y TextBox
        public FrmRegistroProductos()
        {
            InitializeComponent();
          //  LlenarDatos();
            CargarCategorias();
            CargarProveedores();          

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

            var calculoIVA = CalcultarIVA(precioUnitario, iva);

            try
            {
                string consulta = "INSERT INTO TProductos (CodigoProducto, Descripcion, Unidad, Cantidad, PrecioUnitario, Iva, Categoria, Proveedor, PrecioCompra, ValorIVA) " +
                                  "VALUES (@CodigoProducto, @Descripcion, @Unidad, @Cantidad, @PrecioUnitario, @Iva, @Categoria, @Proveedor, @PrecioCompra, ValorIVA=@ValorIVA)";

                SqlParameter[] parametros = {
            new SqlParameter("@CodigoProducto", txtCodigo.Text.Trim()),
            new SqlParameter("@Descripcion", txtDescripcion.Text.Trim()),
            new SqlParameter("@Unidad", comboBox3.SelectedItem.ToString()),
            new SqlParameter("@Cantidad", cantidad),
            new SqlParameter("@PrecioUnitario", calculoIVA.precioUnitarioIVA),
            new SqlParameter("@Iva", iva),
            new SqlParameter("@Categoria", comboBox1.SelectedValue.ToString()),
            new SqlParameter("@Proveedor", comboBox2.SelectedValue.ToString()),
            new SqlParameter("@PrecioCompra", precioCompra),
            new SqlParameter("@ValorIVA", calculoIVA.valorIVA)
        };

                EjecutarComando(consulta, parametros);
                MessageBox.Show("Producto agregado correctamente.");


                string insertCompra = "INSERT INTO COMPRAS(CODIGOPRODUCTO) VALUES (@idProduct)";
                SqlParameter[] parametrosCompra = {
                    new SqlParameter("@idProduct", txtCodigo.Text.Trim())
                };

                EjecutarComando(insertCompra, parametrosCompra);

                //  LlenarDatos();
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        
}
        //boton de salir
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //boton de eliminar producto
        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        #region FUNCIONES
        private (float precioUnitarioIVA, float valorIVA) CalcultarIVA(float precio, float iva)
        {
            try
            {
                return (precio * (1 + iva / 100), (1 + iva / 100));
            }
            catch (Exception)
            {
                MessageBox.Show("Error calculando IVA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
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
        private void CargarCategorias()
        {
            string consulta = "SELECT IdCategoria, NombreCategoria FROM Categorias";
            DataTable dt = EjecutarSelect(consulta).Tables[0];
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "NombreCategoria";
            comboBox1.ValueMember = "NombreCategoria";
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
        #endregion
    }
}
