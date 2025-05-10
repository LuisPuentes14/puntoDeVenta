using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto_Metodologia.Cartera
{
    public partial class FrmAgregarAbono : Form
    {
        CarteraRepository _cartera = new CarteraRepository();
        public FrmAgregarAbono()
        {
            InitializeComponent();
            _cartera.CargarCreditos(dgCartera);
            txtDocumento.Focus();
        }

        //cargar datos en tiempo real al escribir en el textbox 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _cartera.CargarCreditos(dgCartera, txtDocumento.Text.Trim());
        }
        //boton de salir
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //seleccinar fila de la grid
        private void dgCartera_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCartera.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgCartera.SelectedRows[0];

                // Asignar valores a los TextBox
                var abono = float.Parse(filaSeleccionada.Cells["Total Abonado"].Value?.ToString() ?? ""); 
                var debe = float.Parse(filaSeleccionada.Cells["Valor Restante"].Value?.ToString() ?? "");

                txtPagado.Text = abono.ToString("c2");
                txtDebe.Text = debe.ToString("c2");
            }
        }
        //evento en la grid para agregar un abono
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgCartera.CurrentRow != null)
                    {
                        var idcartera = dgCartera.CurrentRow.Cells[8].Value?.ToString();
                        var montoInicial = dgCartera.CurrentRow.Cells[2].Value?.ToString();
                        string valorAbono = Interaction.InputBox("Ingrese el valor a abonar:", "Agregar Abono", "0");

                        if (string.IsNullOrEmpty(valorAbono))
                        {
                            MessageBox.Show("El valor a abonar no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (float.Parse(valorAbono) > float.Parse(dgCartera.CurrentRow.Cells[6].Value?.ToString()))
                        {
                            MessageBox.Show("El valor a abonar es mayor al que debe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        _cartera.InsertarAbono(idcartera, float.Parse(valorAbono));
                        var subtotal = _cartera.ObtenersumaAbonos(idcartera);
                        var totalAbonos = subtotal + float.Parse(montoInicial);
                        var totalVenta = float.Parse(dgCartera.CurrentRow.Cells[1].Value?.ToString());
                        var debeMonto = totalVenta - totalAbonos;

                        if (debeMonto == 0)
                            _cartera.ActualizarEstadoCartera(idcartera);

                        txtPagado.Text = totalAbonos.ToString("c2");
                        txtDebe.Text = debeMonto.ToString("c2");

                        _cartera.CargarCreditos(dgCartera);

                        // Evitar que el ENTER pase a la siguiente fila
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error ingrese un valor numerico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgCartera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
