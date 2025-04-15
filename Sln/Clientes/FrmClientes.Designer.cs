namespace Proyecto_Metodologia
{
    partial class FrmClientes
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.State_acount = new System.Windows.Forms.TextBox();
            this.button_new_client = new System.Windows.Forms.Button();
            this.button_delete_client = new System.Windows.Forms.Button();
            this.button_update_client = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_acept = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Id_client = new System.Windows.Forms.TextBox();
            this.Name_client = new System.Windows.Forms.TextBox();
            this.LastName_client = new System.Windows.Forms.TextBox();
            this.CellPhone_client = new System.Windows.Forms.TextBox();
            this.button_save_client = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(652, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // State_acount
            // 
            this.State_acount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.State_acount.Location = new System.Drawing.Point(38, 92);
            this.State_acount.Name = "State_acount";
            this.State_acount.Size = new System.Drawing.Size(369, 30);
            this.State_acount.TabIndex = 1;
            // 
            // button_new_client
            // 
            this.button_new_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_new_client.Location = new System.Drawing.Point(38, 402);
            this.button_new_client.Name = "button_new_client";
            this.button_new_client.Size = new System.Drawing.Size(144, 36);
            this.button_new_client.TabIndex = 3;
            this.button_new_client.Text = "Nuevo Cliente";
            this.button_new_client.UseVisualStyleBackColor = true;
            this.button_new_client.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button_delete_client
            // 
            this.button_delete_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete_client.Location = new System.Drawing.Point(322, 402);
            this.button_delete_client.Name = "button_delete_client";
            this.button_delete_client.Size = new System.Drawing.Size(135, 36);
            this.button_delete_client.TabIndex = 4;
            this.button_delete_client.Text = "Eliminar Cliente";
            this.button_delete_client.UseVisualStyleBackColor = true;
            this.button_delete_client.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_update_client
            // 
            this.button_update_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update_client.Location = new System.Drawing.Point(205, 402);
            this.button_update_client.Name = "button_update_client";
            this.button_update_client.Size = new System.Drawing.Size(99, 36);
            this.button_update_client.TabIndex = 5;
            this.button_update_client.Text = "Modificar Cliente";
            this.button_update_client.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado de cuenta";
            // 
            // Button_acept
            // 
            this.Button_acept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_acept.Location = new System.Drawing.Point(430, 89);
            this.Button_acept.Name = "Button_acept";
            this.Button_acept.Size = new System.Drawing.Size(126, 32);
            this.Button_acept.TabIndex = 7;
            this.Button_acept.Text = "Aceptar";
            this.Button_acept.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Apellidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Telefono";
            // 
            // Id_client
            // 
            this.Id_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id_client.Location = new System.Drawing.Point(220, 52);
            this.Id_client.Name = "Id_client";
            this.Id_client.Size = new System.Drawing.Size(204, 30);
            this.Id_client.TabIndex = 12;
            // 
            // Name_client
            // 
            this.Name_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_client.Location = new System.Drawing.Point(220, 88);
            this.Name_client.Name = "Name_client";
            this.Name_client.Size = new System.Drawing.Size(204, 30);
            this.Name_client.TabIndex = 13;
            // 
            // LastName_client
            // 
            this.LastName_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName_client.Location = new System.Drawing.Point(220, 126);
            this.LastName_client.Name = "LastName_client";
            this.LastName_client.Size = new System.Drawing.Size(204, 30);
            this.LastName_client.TabIndex = 14;
            // 
            // CellPhone_client
            // 
            this.CellPhone_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CellPhone_client.Location = new System.Drawing.Point(220, 164);
            this.CellPhone_client.Name = "CellPhone_client";
            this.CellPhone_client.Size = new System.Drawing.Size(204, 30);
            this.CellPhone_client.TabIndex = 15;
            // 
            // button_save_client
            // 
            this.button_save_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save_client.Location = new System.Drawing.Point(238, 224);
            this.button_save_client.Name = "button_save_client";
            this.button_save_client.Size = new System.Drawing.Size(186, 36);
            this.button_save_client.TabIndex = 16;
            this.button_save_client.Text = "Guardar Cliente";
            this.button_save_client.UseVisualStyleBackColor = true;
            this.button_save_client.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 450);
            this.Controls.Add(this.button_save_client);
            this.Controls.Add(this.CellPhone_client);
            this.Controls.Add(this.LastName_client);
            this.Controls.Add(this.Name_client);
            this.Controls.Add(this.Id_client);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Button_acept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_update_client);
            this.Controls.Add(this.button_delete_client);
            this.Controls.Add(this.button_new_client);
            this.Controls.Add(this.State_acount);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmClientes";
            this.Text = "FrmClientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox State_acount;
        private System.Windows.Forms.Button button_new_client;
        private System.Windows.Forms.Button button_delete_client;
        private System.Windows.Forms.Button button_update_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_acept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Id_client;
        private System.Windows.Forms.TextBox Name_client;
        private System.Windows.Forms.TextBox LastName_client;
        private System.Windows.Forms.TextBox CellPhone_client;
        private System.Windows.Forms.Button button_save_client;
    }
}