namespace Proyecto_Metodologia.Cartera
{
    partial class FrmAgregarAbono
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
            this.dgCartera = new System.Windows.Forms.DataGridView();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.txtDebe = new System.Windows.Forms.TextBox();
            this.labelAbono = new System.Windows.Forms.Label();
            this.txtPagado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCartera)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1171, 82);
            this.panel1.TabIndex = 23;
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
            this.label1.Size = new System.Drawing.Size(266, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "AGREGAR ABONO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 515);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1171, 59);
            this.panel3.TabIndex = 24;
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
            this.iconButton1.TabIndex = 3;
            this.iconButton1.Text = "Salir";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // dgCartera
            // 
            this.dgCartera.AllowUserToAddRows = false;
            this.dgCartera.BackgroundColor = System.Drawing.Color.White;
            this.dgCartera.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCartera.Location = new System.Drawing.Point(31, 179);
            this.dgCartera.Name = "dgCartera";
            this.dgCartera.ReadOnly = true;
            this.dgCartera.Size = new System.Drawing.Size(671, 294);
            this.dgCartera.TabIndex = 2;
            this.dgCartera.TabStop = false;
            this.dgCartera.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(184, 144);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtDocumento.TabIndex = 31;
            this.txtDocumento.Tag = "1";
            this.txtDocumento.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "DOCUMENTO CLIENTE:";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.BackColor = System.Drawing.Color.Yellow;
            this.lbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValor.Location = new System.Drawing.Point(783, 179);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(371, 33);
            this.lbValor.TabIndex = 43;
            this.lbValor.Text = "    VALOR RESTANTE        ";
            this.lbValor.Visible = false;
            // 
            // txtDebe
            // 
            this.txtDebe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDebe.Enabled = false;
            this.txtDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebe.Location = new System.Drawing.Point(883, 246);
            this.txtDebe.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.ReadOnly = true;
            this.txtDebe.Size = new System.Drawing.Size(271, 44);
            this.txtDebe.TabIndex = 44;
            this.txtDebe.Visible = false;
            // 
            // labelAbono
            // 
            this.labelAbono.AutoSize = true;
            this.labelAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbono.Location = new System.Drawing.Point(780, 252);
            this.labelAbono.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelAbono.Name = "labelAbono";
            this.labelAbono.Size = new System.Drawing.Size(87, 31);
            this.labelAbono.TabIndex = 56;
            this.labelAbono.Text = "Debe:";
            this.labelAbono.Visible = false;
            // 
            // txtPagado
            // 
            this.txtPagado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtPagado.Enabled = false;
            this.txtPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagado.Location = new System.Drawing.Point(883, 318);
            this.txtPagado.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPagado.Name = "txtPagado";
            this.txtPagado.ReadOnly = true;
            this.txtPagado.Size = new System.Drawing.Size(271, 44);
            this.txtPagado.TabIndex = 57;
            this.txtPagado.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(713, 324);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 31);
            this.label3.TabIndex = 58;
            this.label3.Text = "Ha pagado:";
            this.label3.Visible = false;
            // 
            // FrmAgregarAbono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 574);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPagado);
            this.Controls.Add(this.labelAbono);
            this.Controls.Add(this.txtDebe);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.dgCartera);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAgregarAbono";
            this.Text = "FrmAgregarAbono";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCartera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label USUSARIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.DataGridView dgCartera;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbValor;
        private System.Windows.Forms.TextBox txtDebe;
        private System.Windows.Forms.Label labelAbono;
        private System.Windows.Forms.TextBox txtPagado;
        private System.Windows.Forms.Label label3;
    }
}