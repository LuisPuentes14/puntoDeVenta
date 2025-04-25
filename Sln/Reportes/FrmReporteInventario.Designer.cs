namespace Proyecto_Metodologia.Reportes
{
    partial class FrmReporteInventario
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.dgReporte = new System.Windows.Forms.DataGridView();
            this.btneExportar = new FontAwesome.Sharp.IconButton();
            this.dateTimeVentasHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimeVentasDesde = new System.Windows.Forms.DateTimePicker();
            this.lbFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReporte)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(987, 82);
            this.panel1.TabIndex = 21;
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
            this.label1.Size = new System.Drawing.Size(304, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORTE DE VENTAS";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 517);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(987, 59);
            this.panel3.TabIndex = 22;
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
            this.iconButton1.Location = new System.Drawing.Point(31, 15);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(113, 40);
            this.iconButton1.TabIndex = 4;
            this.iconButton1.Text = "Salir";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dgReporte
            // 
            this.dgReporte.AllowUserToAddRows = false;
            this.dgReporte.BackgroundColor = System.Drawing.Color.White;
            this.dgReporte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReporte.Location = new System.Drawing.Point(31, 160);
            this.dgReporte.Name = "dgReporte";
            this.dgReporte.ReadOnly = true;
            this.dgReporte.Size = new System.Drawing.Size(765, 335);
            this.dgReporte.TabIndex = 19;
            this.dgReporte.TabStop = false;
            // 
            // btneExportar
            // 
            this.btneExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneExportar.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            this.btneExportar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btneExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btneExportar.IconSize = 40;
            this.btneExportar.Location = new System.Drawing.Point(818, 160);
            this.btneExportar.Name = "btneExportar";
            this.btneExportar.Size = new System.Drawing.Size(157, 46);
            this.btneExportar.TabIndex = 23;
            this.btneExportar.Text = "Exportar";
            this.btneExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btneExportar.UseVisualStyleBackColor = true;
            this.btneExportar.Click += new System.EventHandler(this.btneExportar_Click);
            // 
            // dateTimeVentasHasta
            // 
            this.dateTimeVentasHasta.CustomFormat = "yy/MM/dd";
            this.dateTimeVentasHasta.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeVentasHasta.Location = new System.Drawing.Point(541, 130);
            this.dateTimeVentasHasta.Name = "dateTimeVentasHasta";
            this.dateTimeVentasHasta.Size = new System.Drawing.Size(255, 24);
            this.dateTimeVentasHasta.TabIndex = 24;
            this.dateTimeVentasHasta.Tag = "3";
            this.dateTimeVentasHasta.Value = new System.DateTime(2025, 4, 21, 0, 0, 0, 0);
            this.dateTimeVentasHasta.ValueChanged += new System.EventHandler(this.dateTimeVentasHasta_ValueChanged);
            // 
            // dateTimeVentasDesde
            // 
            this.dateTimeVentasDesde.CustomFormat = "yy/MM/dd";
            this.dateTimeVentasDesde.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeVentasDesde.Location = new System.Drawing.Point(541, 90);
            this.dateTimeVentasDesde.Name = "dateTimeVentasDesde";
            this.dateTimeVentasDesde.Size = new System.Drawing.Size(255, 24);
            this.dateTimeVentasDesde.TabIndex = 25;
            this.dateTimeVentasDesde.Tag = "2";
            this.dateTimeVentasDesde.Value = new System.DateTime(2025, 4, 21, 0, 0, 0, 0);
            this.dateTimeVentasDesde.ValueChanged += new System.EventHandler(this.dateTimeVentasDesde_ValueChanged);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(483, 96);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(52, 16);
            this.lbFecha.TabIndex = 26;
            this.lbFecha.Text = "DESDE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(481, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "HASTA:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.Tag = "1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "BUSCAR:";
            // 
            // FrmReporteInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 576);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.dateTimeVentasDesde);
            this.Controls.Add(this.dateTimeVentasHasta);
            this.Controls.Add(this.btneExportar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgReporte);
            this.Name = "FrmReporteInventario";
            this.Text = "FrmReporteInventario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label USUSARIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.DataGridView dgReporte;
        private FontAwesome.Sharp.IconButton btneExportar;
        private System.Windows.Forms.DateTimePicker dateTimeVentasHasta;
        private System.Windows.Forms.DateTimePicker dateTimeVentasDesde;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}