using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Proyecto_Metodologia
{
    public partial class FrmSistemaVentas : Form
    {

        private DataSet aDatos;




        public DataSet Datos
        {
            get { return aDatos; }
        }
        //
        public FrmSistemaVentas()
        {
       
            InitializeComponent();
            FrmLogin test = new FrmLogin();
            test.ShowDialog();
            txtheadtext.Text = test.usuario ;
            CONSTANS.USER = test.usuario;
            txtcategoria.Text = validarcategoria(test.usuario);
            categoriarango();
        }

        public DataSet EjecutarSelect(string pConsulta)
        {//-- Método para ejecutar consultas del tipo SELECT
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(pConsulta, conexion))
                {
                    SqlDataAdapter a = new SqlDataAdapter(cmd);
                    aDatos = new DataSet();
                    a.Fill(aDatos);
                }
            }
            return aDatos;
        }
        public string ValorAtributo(string pNombreCampo)
        {//-- Recupera el valor de un atributo del dataset
            if (Datos.Tables[0].Rows.Count > 0)
            {
                return Datos.Tables[0].Rows[0][pNombreCampo].ToString();
            }
            else
                return "";
        }
        public string  validarcategoria(String pusuario)
        {
            string Datos;
            string Consulta = "select * from TUsuarios where  Usuario='" + pusuario + "'";
            EjecutarSelect(Consulta);
            Datos = ValorAtributo("Categoria");
            return Datos;
        }
        public void categoriarango()
        {
            if (txtcategoria.Text == "Administra")
            {
                //btnventas.Visible = false;
            }
            if (txtcategoria.Text == "Cajero")
            {
                //btnusuarios.Visible = false;
                //btnregistro.Visible = false;
               
            }
        }
        public void AbrirFormularioHijo(Form FrmHijo)
        {

 
            FrmHijo.TopLevel = false;
            FrmHijo.FormBorderStyle = FormBorderStyle.None;
            FrmHijo.Dock = DockStyle.Fill;
            panelcontenido.Controls.Add(FrmHijo);
            panelcontenido.Tag = FrmHijo;
            FrmHijo.BringToFront();
            FrmHijo.Show();
        }
        private void btnusuarios_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo(new FrmRegistro());
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmVentas());
        }

        private void btnarqueo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmArqueo());

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRegistroUsuarios());
        }

        private void BtnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRegistroUsuarios());
        }
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mnuVentas_Click(object sender, EventArgs e)
        {

        }

        private void tsVender_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmVentas());
        }

        private void tsArticulos_Click(object sender, EventArgs e)
        {

            AbrirFormularioHijo(new FrmRegistroProductos());
        }
        private void tsCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas cerrar la sesión? Esto te regresará al Login.",
                "Cerrar sesión - (Sistema de ventas)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Mostrar el login antes de cerrar el formulario actual
                FrmLogin login = new FrmLogin();
                login.Show();

                // Esconder el formulario actual en lugar de cerrarlo
                this.Hide();
            }
        }


        private void tsSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CONSTANS.Reset();
                Application.Exit(); // Cierra toda la aplicación correctamente
            }
        }







        private void tsCategorias_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmProductos
            FrmRegistrocategoria usuarios = new FrmRegistrocategoria();

            // Mostrar el formulario
            usuarios.Show();
        }

        private void FrmSistemaVentas_Load(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmAperturacaja
            //FrmAperturacaja aperturaCaja = new FrmAperturacaja();

            // Mostrar el formulario de manera modal
           // if (aperturaCaja.ShowDialog() == DialogResult.OK)
           // {
                // Solo se muestra FrmSistemaVentas si el usuario guardó los datos
            //    this.Show();
          //  }
           // else
           // {
                // Cerrar FrmSistemaVentas si no se guardaron los datos
                //this.Close();
           // }
        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmDevolucionesDeVentas());
        }

        private void historialDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmHistoricoVentas());
        }

        private void panelcontenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmProveedores());
           
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmProductos
            FrmClientes usuarios = new FrmClientes();

            // Mostrar el formulario
            usuarios.Show();
        }

        private void registroEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmProductos
           // FrmSalidaefectivo salida = new FrmSalidaefectivo();

            // Mostrar el formulario
            //salida.Show();
          //  AbrirFormularioHijo(new FrmSalidaefectivo());

        }

        private void registrarIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmEntradaefectivo());
        }

        private void tsPresentaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmStockProductos());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmProductos
            FrmRegistroUsuarios Usuarios = new FrmRegistroUsuarios();

            // Mostrar el formulario
            Usuarios.Show();
        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmProductos
            FrmArqueo arqueo = new FrmArqueo();

            // Mostrar el formulario
            arqueo.Show();
        }

        private void aperturaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmProductos
            FrmAperturacaja apertura = new FrmAperturacaja();

            // Mostrar el formulario
            apertura.Show();
        }

        private void registrarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRegistroProductos());
        }

        private void devoluciónDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmDevolucionesDeCompras());
        }
    }
}
