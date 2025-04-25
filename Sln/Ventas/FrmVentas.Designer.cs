namespace Proyecto_Metodologia
{
    partial class FrmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.CodProcuto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombrep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaventa = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtpreciou = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtigv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodVentas = new System.Windows.Forms.TextBox();
            this.txtDocumentoCliente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nupcantidad = new System.Windows.Forms.TextBox();
            this.txtcodp = new System.Windows.Forms.TextBox();
            this.Unidad = new System.Windows.Forms.Label();
            this.Unidadmedida = new System.Windows.Forms.ComboBox();
            this.Txtiva = new System.Windows.Forms.TextBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lbCambio = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.lbEfectivo = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.lbTotalPagar = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.labelAbono = new System.Windows.Forms.Label();
            this.tipoVenta = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodProcuto,
            this.Nombrep,
            this.Cantidad,
            this.Total,
            this.Iva});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVentas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.Location = new System.Drawing.Point(65, 323);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.Size = new System.Drawing.Size(649, 296);
            this.dgvVentas.TabIndex = 9;
            this.dgvVentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVentas_KeyDown);
            // 
            // CodProcuto
            // 
            this.CodProcuto.HeaderText = "Codigo de Producto";
            this.CodProcuto.Name = "CodProcuto";
            this.CodProcuto.ReadOnly = true;
            // 
            // Nombrep
            // 
            this.Nombrep.HeaderText = "Nombre del Producto";
            this.Nombrep.Name = "Nombrep";
            this.Nombrep.ReadOnly = true;
            this.Nombrep.Width = 300;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Iva
            // 
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(76, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo Producto :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 59);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(395, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "VENTAS";
            // 
            // fechaventa
            // 
            this.fechaventa.CustomFormat = "yy/MM/dd";
            this.fechaventa.Enabled = false;
            this.fechaventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaventa.Location = new System.Drawing.Point(1021, 62);
            this.fechaventa.Name = "fechaventa";
            this.fechaventa.Size = new System.Drawing.Size(342, 30);
            this.fechaventa.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(70, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre Producto :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(172, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stock :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1106, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Precio Unidad :";
            this.label5.Visible = false;
            // 
            // txtnombre
            // 
            this.txtnombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtnombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombre.Location = new System.Drawing.Point(257, 204);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(676, 30);
            this.txtnombre.TabIndex = 8;
            // 
            // txtpreciou
            // 
            this.txtpreciou.Enabled = false;
            this.txtpreciou.Location = new System.Drawing.Point(1192, 228);
            this.txtpreciou.Name = "txtpreciou";
            this.txtpreciou.Size = new System.Drawing.Size(100, 20);
            this.txtpreciou.TabIndex = 9;
            this.txtpreciou.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(257, 276);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 30);
            this.txtStock.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.to);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtigv);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txttotal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 633);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 78);
            this.panel2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 31);
            this.label7.TabIndex = 18;
            this.label7.Text = "SUBTOTAL :";
            // 
            // to
            // 
            this.to.Enabled = false;
            this.to.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.to.ForeColor = System.Drawing.Color.Red;
            this.to.Location = new System.Drawing.Point(206, 26);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(192, 38);
            this.to.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(443, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 31);
            this.label8.TabIndex = 16;
            this.label8.Text = "IVA: ";
            // 
            // txtigv
            // 
            this.txtigv.Enabled = false;
            this.txtigv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtigv.ForeColor = System.Drawing.Color.Red;
            this.txtigv.Location = new System.Drawing.Point(522, 26);
            this.txtigv.Name = "txtigv";
            this.txtigv.Size = new System.Drawing.Size(192, 38);
            this.txtigv.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(743, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 31);
            this.label9.TabIndex = 17;
            this.label9.Text = "TOTAL:";
            // 
            // txttotal
            // 
            this.txttotal.Enabled = false;
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.ForeColor = System.Drawing.Color.Red;
            this.txttotal.Location = new System.Drawing.Point(859, 29);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(248, 38);
            this.txttotal.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(143, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(66, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 25);
            this.label10.TabIndex = 22;
            this.label10.Text = "Factura: ";
            // 
            // txtCodVentas
            // 
            this.txtCodVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVentas.Location = new System.Drawing.Point(157, 61);
            this.txtCodVentas.Name = "txtCodVentas";
            this.txtCodVentas.Size = new System.Drawing.Size(124, 30);
            this.txtCodVentas.TabIndex = 23;
            // 
            // txtDocumentoCliente
            // 
            this.txtDocumentoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentoCliente.Location = new System.Drawing.Point(449, 61);
            this.txtDocumentoCliente.Name = "txtDocumentoCliente";
            this.txtDocumentoCliente.Size = new System.Drawing.Size(181, 30);
            this.txtDocumentoCliente.TabIndex = 3;
            this.txtDocumentoCliente.Text = "2222222222";
            this.txtDocumentoCliente.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(318, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Documento: ";
            // 
            // nupcantidad
            // 
            this.nupcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupcantidad.Location = new System.Drawing.Point(257, 240);
            this.nupcantidad.Name = "nupcantidad";
            this.nupcantidad.Size = new System.Drawing.Size(100, 30);
            this.nupcantidad.TabIndex = 2;
            this.nupcantidad.Text = "1";
            // 
            // txtcodp
            // 
            this.txtcodp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodp.Location = new System.Drawing.Point(257, 168);
            this.txtcodp.Name = "txtcodp";
            this.txtcodp.Size = new System.Drawing.Size(295, 30);
            this.txtcodp.TabIndex = 1;
            this.txtcodp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVentas_KeyDown);
            // 
            // Unidad
            // 
            this.Unidad.AutoSize = true;
            this.Unidad.Location = new System.Drawing.Point(1150, 180);
            this.Unidad.Name = "Unidad";
            this.Unidad.Size = new System.Drawing.Size(47, 13);
            this.Unidad.TabIndex = 29;
            this.Unidad.Text = "Unidad :";
            this.Unidad.Visible = false;
            // 
            // Unidadmedida
            // 
            this.Unidadmedida.FormattingEnabled = true;
            this.Unidadmedida.Location = new System.Drawing.Point(1203, 177);
            this.Unidadmedida.Name = "Unidadmedida";
            this.Unidadmedida.Size = new System.Drawing.Size(89, 21);
            this.Unidadmedida.TabIndex = 33;
            this.Unidadmedida.Visible = false;
            // 
            // Txtiva
            // 
            this.Txtiva.Location = new System.Drawing.Point(1159, 270);
            this.Txtiva.Name = "Txtiva";
            this.Txtiva.Size = new System.Drawing.Size(133, 20);
            this.Txtiva.TabIndex = 34;
            this.Txtiva.Visible = false;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(1021, 507);
            this.txtEfectivo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(271, 44);
            this.txtEfectivo.TabIndex = 11;
            this.txtEfectivo.Visible = false;
            this.txtEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVentas_KeyDown);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // lbCambio
            // 
            this.lbCambio.AutoSize = true;
            this.lbCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCambio.Location = new System.Drawing.Point(903, 571);
            this.lbCambio.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbCambio.Name = "lbCambio";
            this.lbCambio.Size = new System.Drawing.Size(107, 31);
            this.lbCambio.TabIndex = 40;
            this.lbCambio.Text = "Cambio";
            this.lbCambio.Visible = false;
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.Location = new System.Drawing.Point(1021, 565);
            this.txtCambio.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(271, 44);
            this.txtCambio.TabIndex = 39;
            this.txtCambio.Visible = false;
            this.txtCambio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVentas_KeyDown);
            this.txtCambio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // lbEfectivo
            // 
            this.lbEfectivo.AutoSize = true;
            this.lbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEfectivo.Location = new System.Drawing.Point(898, 513);
            this.lbEfectivo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbEfectivo.Name = "lbEfectivo";
            this.lbEfectivo.Size = new System.Drawing.Size(112, 31);
            this.lbEfectivo.TabIndex = 38;
            this.lbEfectivo.Text = "Efectivo";
            this.lbEfectivo.Visible = false;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.Location = new System.Drawing.Point(1021, 387);
            this.txtTotalPagar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(271, 44);
            this.txtTotalPagar.TabIndex = 37;
            this.txtTotalPagar.Visible = false;
            // 
            // lbTotalPagar
            // 
            this.lbTotalPagar.AutoSize = true;
            this.lbTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPagar.Location = new System.Drawing.Point(834, 393);
            this.lbTotalPagar.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbTotalPagar.Name = "lbTotalPagar";
            this.lbTotalPagar.Size = new System.Drawing.Size(176, 31);
            this.lbTotalPagar.TabIndex = 36;
            this.lbTotalPagar.Text = "Total a Pagar";
            this.lbTotalPagar.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(825, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(467, 46);
            this.label15.TabIndex = 42;
            this.label15.Text = "            COBRAR             ";
            this.label15.Visible = false;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(449, 97);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(181, 30);
            this.txtNombreCliente.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(344, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 23);
            this.label16.TabIndex = 44;
            this.label16.Text = "Nombre:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(771, 64);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(188, 30);
            this.txtApellido.TabIndex = 5;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(771, 101);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(317, 30);
            this.txtCorreo.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(676, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 23);
            this.label17.TabIndex = 47;
            this.label17.Text = "Apellido:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(688, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 23);
            this.label18.TabIndex = 48;
            this.label18.Text = "Correo:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(771, 137);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(188, 30);
            this.txtTelefono.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(676, 143);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 23);
            this.label19.TabIndex = 50;
            this.label19.Text = "Telefono:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(407, 245);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 25);
            this.label20.TabIndex = 52;
            this.label20.Text = "Tipo de venta:";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbono.Location = new System.Drawing.Point(1021, 445);
            this.txtAbono.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(271, 44);
            this.txtAbono.TabIndex = 10;
            this.txtAbono.Visible = false;
            this.txtAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbono_KeyDown);
            // 
            // labelAbono
            // 
            this.labelAbono.AutoSize = true;
            this.labelAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbono.Location = new System.Drawing.Point(913, 451);
            this.labelAbono.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelAbono.Name = "labelAbono";
            this.labelAbono.Size = new System.Drawing.Size(92, 31);
            this.labelAbono.TabIndex = 55;
            this.labelAbono.Text = "Abono";
            this.labelAbono.Visible = false;
            // 
            // tipoVenta
            // 
            this.tipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoVenta.FormattingEnabled = true;
            this.tipoVenta.Items.AddRange(new object[] {
            "Efectivo",
            "Credito"});
            this.tipoVenta.SelectedIndex = 0;
            this.tipoVenta.Location = new System.Drawing.Point(550, 246);
            this.tipoVenta.Name = "tipoVenta";
            this.tipoVenta.Size = new System.Drawing.Size(140, 28);
            this.tipoVenta.TabIndex = 8;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 711);
            this.Controls.Add(this.tipoVenta);
            this.Controls.Add(this.labelAbono);
            this.Controls.Add(this.txtAbono);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.lbCambio);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.lbEfectivo);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.lbTotalPagar);
            this.Controls.Add(this.Txtiva);
            this.Controls.Add(this.Unidadmedida);
            this.Controls.Add(this.Unidad);
            this.Controls.Add(this.txtcodp);
            this.Controls.Add(this.nupcantidad);
            this.Controls.Add(this.txtDocumentoCliente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodVentas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtpreciou);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fechaventa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvVentas);
            this.Name = "FrmVentas";
            this.Text = "FrmVentas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoVenta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaventa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtpreciou;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.TextBox txtigv;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCodVentas;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox nupcantidad;
        private System.Windows.Forms.TextBox txtcodp;
        private System.Windows.Forms.Label Unidad;
        private System.Windows.Forms.ComboBox Unidadmedida;
        private System.Windows.Forms.TextBox Txtiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProcuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombrep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lbCambio;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label lbEfectivo;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label lbTotalPagar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label labelAbono;
        private System.Windows.Forms.ComboBox tipoVenta;
        //    private System.Windows.Forms.Button imprimir;
    }
}