﻿namespace Proyecto_Metodologia
{
    partial class FrmSalidaEfectivo
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(64, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(64, 65);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(144, 30);
            this.txtValor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "        Valor         ";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcepto.Location = new System.Drawing.Point(12, 146);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(258, 30);
            this.txtConcepto.TabIndex = 6;
            this.txtConcepto.TextChanged += new System.EventHandler(this.txtConcepto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "        Concepto         ";
            // 
            // FrmSalidaEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 234);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalidaEfectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salida de Efectivo";
            this.Load += new System.EventHandler(this.FrmSalidaEfectivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label2;
    }
}