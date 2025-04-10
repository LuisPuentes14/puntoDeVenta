namespace Proyecto_Metodologia
{
    partial class FrmHistoricoVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnBuscar1 = new System.Windows.Forms.Button();
            this.cmbFiltro1 = new System.Windows.Forms.ComboBox();
            this.dtpDesde1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dgvResultados1 = new System.Windows.Forms.DataGridView();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "Hoy",
            "",
            "",
            "Ayer",
            "",
            "",
            "",
            "",
            "Por un rango de fechas personalizado"});
            this.cmbFiltro.Location = new System.Drawing.Point(23, 27);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(172, 21);
            this.cmbFiltro.TabIndex = 0;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(215, 28);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(431, 28);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(655, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(119, 24);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "button1";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(23, 65);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(608, 324);
            this.dgvResultados.TabIndex = 4;
            // 
            // btnBuscar1
            // 
            this.btnBuscar1.Location = new System.Drawing.Point(700, 27);
            this.btnBuscar1.Name = "btnBuscar1";
            this.btnBuscar1.Size = new System.Drawing.Size(124, 31);
            this.btnBuscar1.TabIndex = 0;
            this.btnBuscar1.Text = "Buscar";
            this.btnBuscar1.UseVisualStyleBackColor = true;
            this.btnBuscar1.Click += new System.EventHandler(this.btnBuscar1_Click_1);
            // 
            // cmbFiltro1
            // 
            this.cmbFiltro1.FormattingEnabled = true;
            this.cmbFiltro1.Location = new System.Drawing.Point(89, 33);
            this.cmbFiltro1.Name = "cmbFiltro1";
            this.cmbFiltro1.Size = new System.Drawing.Size(151, 21);
            this.cmbFiltro1.TabIndex = 1;
            // 
            // dtpDesde1
            // 
            this.dtpDesde1.Location = new System.Drawing.Point(267, 34);
            this.dtpDesde1.Name = "dtpDesde1";
            this.dtpDesde1.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(473, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dgvResultados1
            // 
            this.dgvResultados1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados1.Location = new System.Drawing.Point(89, 78);
            this.dgvResultados1.Name = "dgvResultados1";
            this.dgvResultados1.Size = new System.Drawing.Size(584, 249);
            this.dgvResultados1.TabIndex = 4;
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.Location = new System.Drawing.Point(86, 346);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(23, 25);
            this.lblTotalVentas.TabIndex = 6;
            this.lblTotalVentas.Text = "0";
            // 
            // FrmHistoricoVentas
            // 
            this.ClientSize = new System.Drawing.Size(1056, 471);
            this.Controls.Add(this.lblTotalVentas);
            this.Controls.Add(this.dgvResultados1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dtpDesde1);
            this.Controls.Add(this.cmbFiltro1);
            this.Controls.Add(this.btnBuscar1);
            this.Name = "FrmHistoricoVentas";
            this.Load += new System.EventHandler(this.FrmHistoricoVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnBuscar1;
        private System.Windows.Forms.ComboBox cmbFiltro1;
        private System.Windows.Forms.DateTimePicker dtpDesde1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dgvResultados1;
        private System.Windows.Forms.Label lblTotalVentas;
    }
}