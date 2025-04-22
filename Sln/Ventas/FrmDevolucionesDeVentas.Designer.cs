namespace Proyecto_Metodologia
{
    partial class FrmDevolucionesDeVentas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.USUSARIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelcontenido = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.lbHora = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.dateTimeVentas = new System.Windows.Forms.DateTimePicker();
            this.dgventas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelcontenido.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgventas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.USUSARIO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 82);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // USUSARIO
            // 
            this.USUSARIO.AutoSize = true;
            this.USUSARIO.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USUSARIO.ForeColor = System.Drawing.Color.White;
            this.USUSARIO.Location = new System.Drawing.Point(732, 15);
            this.USUSARIO.Name = "USUSARIO";
            this.USUSARIO.Size = new System.Drawing.Size(0, 34);
            this.USUSARIO.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(193, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "DEVOLUCIONES DE VENTAS";
            // 
            // panelcontenido
            // 
            this.panelcontenido.BackColor = System.Drawing.Color.White;
            this.panelcontenido.Controls.Add(this.textBox1);
            this.panelcontenido.Controls.Add(this.panel3);
            this.panelcontenido.Controls.Add(this.txttotal);
            this.panelcontenido.Controls.Add(this.lbHora);
            this.panelcontenido.Controls.Add(this.label3);
            this.panelcontenido.Controls.Add(this.lbFecha);
            this.panelcontenido.Controls.Add(this.dateTimeVentas);
            this.panelcontenido.Controls.Add(this.dgventas);
            this.panelcontenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontenido.ForeColor = System.Drawing.Color.Black;
            this.panelcontenido.Location = new System.Drawing.Point(0, 82);
            this.panelcontenido.Name = "panelcontenido";
            this.panelcontenido.Size = new System.Drawing.Size(991, 452);
            this.panelcontenido.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(396, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 20);
            this.textBox1.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 379);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(991, 73);
            this.panel3.TabIndex = 15;
            // 
            // iconButton1
            // 
            this.iconButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.iconButton1.IconColor = System.Drawing.Color.Teal;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 35;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton1.Location = new System.Drawing.Point(72, 13);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(113, 40);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "Salir";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // txttotal
            // 
            this.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttotal.Enabled = false;
            this.txttotal.Location = new System.Drawing.Point(538, 339);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(87, 13);
            this.txttotal.TabIndex = 14;
            // 
            // lbHora
            // 
            this.lbHora.AutoSize = true;
            this.lbHora.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.Location = new System.Drawing.Point(629, 22);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(39, 16);
            this.lbHora.TabIndex = 6;
            this.lbHora.Text = "10:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(575, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "HORA:";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(28, 20);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(52, 16);
            this.lbFecha.TabIndex = 4;
            this.lbFecha.Text = "FECHA:";
            // 
            // dateTimeVentas
            // 
            this.dateTimeVentas.CustomFormat = "yy/MM/dd";
            this.dateTimeVentas.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeVentas.Location = new System.Drawing.Point(86, 14);
            this.dateTimeVentas.Name = "dateTimeVentas";
            this.dateTimeVentas.Size = new System.Drawing.Size(255, 24);
            this.dateTimeVentas.TabIndex = 3;
            this.dateTimeVentas.Value = new System.DateTime(2021, 3, 4, 11, 33, 0, 0);
            this.dateTimeVentas.ValueChanged += new System.EventHandler(this.dateTimeVentas_ValueChanged);
            // 
            // dgventas
            // 
            this.dgventas.AllowUserToAddRows = false;
            this.dgventas.AllowUserToDeleteRows = false;
            this.dgventas.BackgroundColor = System.Drawing.Color.White;
            this.dgventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgventas.Location = new System.Drawing.Point(31, 66);
            this.dgventas.Name = "dgventas";
            this.dgventas.ReadOnly = true;
            this.dgventas.Size = new System.Drawing.Size(834, 252);
            this.dgventas.TabIndex = 0;
            this.dgventas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // FrmDevolucionesDeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 534);
            this.Controls.Add(this.panelcontenido);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDevolucionesDeVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegistrodeVentas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelcontenido.ResumeLayout(false);
            this.panelcontenido.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgventas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label USUSARIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelcontenido;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.DateTimePicker dateTimeVentas;
        private System.Windows.Forms.DataGridView dgventas;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox textBox1;
    }
}