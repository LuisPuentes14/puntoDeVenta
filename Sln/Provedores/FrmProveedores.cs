using System;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
    
        }


        #region EVENTOS
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
                AbrirFormularioHijo(new FrmAdministrarProveedores(this));
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmregistroProveedores(this));
        }
        #endregion

        #region FUNCIONES
        public void AbrirFormularioHijo(Form FrmHijo)
        {
            // Limpia el panel
            panelContenido.Controls.Clear();


            FrmHijo.TopLevel = false;
            FrmHijo.FormBorderStyle = FormBorderStyle.None;
            FrmHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(FrmHijo);
            panelContenido.Tag = FrmHijo;
            FrmHijo.BringToFront();
            FrmHijo.Show();
        }
        #endregion
    }
}
