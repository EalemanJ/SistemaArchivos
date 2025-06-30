namespace Sistema_Archivos
{
    partial class frmCambiarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarClave));
            this.gbCambiarClave = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtNuevaClave2 = new System.Windows.Forms.TextBox();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.txtClaveAhora = new System.Windows.Forms.TextBox();
            this.lblNuevaClave2 = new System.Windows.Forms.Label();
            this.lblNuevaClave = new System.Windows.Forms.Label();
            this.lblClaveAhora = new System.Windows.Forms.Label();
            this.gbCambiarClave.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCambiarClave
            // 
            this.gbCambiarClave.Controls.Add(this.btnSalir);
            this.gbCambiarClave.Controls.Add(this.btnLimpiar);
            this.gbCambiarClave.Controls.Add(this.btnActualizar);
            this.gbCambiarClave.Controls.Add(this.txtNuevaClave2);
            this.gbCambiarClave.Controls.Add(this.txtNuevaClave);
            this.gbCambiarClave.Controls.Add(this.txtClaveAhora);
            this.gbCambiarClave.Controls.Add(this.lblNuevaClave2);
            this.gbCambiarClave.Controls.Add(this.lblNuevaClave);
            this.gbCambiarClave.Controls.Add(this.lblClaveAhora);
            this.gbCambiarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCambiarClave.Location = new System.Drawing.Point(12, 12);
            this.gbCambiarClave.Name = "gbCambiarClave";
            this.gbCambiarClave.Size = new System.Drawing.Size(480, 223);
            this.gbCambiarClave.TabIndex = 0;
            this.gbCambiarClave.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(325, 166);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(122, 27);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 2;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(187, 166);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 27);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(20, 166);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(141, 27);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar datos";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // txtNuevaClave2
            // 
            this.txtNuevaClave2.Location = new System.Drawing.Point(189, 118);
            this.txtNuevaClave2.MaxLength = 300;
            this.txtNuevaClave2.Name = "txtNuevaClave2";
            this.txtNuevaClave2.Size = new System.Drawing.Size(258, 22);
            this.txtNuevaClave2.TabIndex = 5;
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(189, 75);
            this.txtNuevaClave.MaxLength = 300;
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.Size = new System.Drawing.Size(258, 22);
            this.txtNuevaClave.TabIndex = 4;
            // 
            // txtClaveAhora
            // 
            this.txtClaveAhora.Location = new System.Drawing.Point(189, 32);
            this.txtClaveAhora.MaxLength = 300;
            this.txtClaveAhora.Name = "txtClaveAhora";
            this.txtClaveAhora.Size = new System.Drawing.Size(258, 22);
            this.txtClaveAhora.TabIndex = 3;
            // 
            // lblNuevaClave2
            // 
            this.lblNuevaClave2.AutoSize = true;
            this.lblNuevaClave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevaClave2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNuevaClave2.Location = new System.Drawing.Point(36, 124);
            this.lblNuevaClave2.Name = "lblNuevaClave2";
            this.lblNuevaClave2.Size = new System.Drawing.Size(147, 16);
            this.lblNuevaClave2.TabIndex = 2;
            this.lblNuevaClave2.Text = "Repita Nueva Clave";
            // 
            // lblNuevaClave
            // 
            this.lblNuevaClave.AutoSize = true;
            this.lblNuevaClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevaClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNuevaClave.Location = new System.Drawing.Point(36, 81);
            this.lblNuevaClave.Name = "lblNuevaClave";
            this.lblNuevaClave.Size = new System.Drawing.Size(97, 16);
            this.lblNuevaClave.TabIndex = 1;
            this.lblNuevaClave.Text = "Nueva Clave";
            // 
            // lblClaveAhora
            // 
            this.lblClaveAhora.AutoSize = true;
            this.lblClaveAhora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveAhora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblClaveAhora.Location = new System.Drawing.Point(36, 38);
            this.lblClaveAhora.Name = "lblClaveAhora";
            this.lblClaveAhora.Size = new System.Drawing.Size(95, 16);
            this.lblClaveAhora.TabIndex = 0;
            this.lblClaveAhora.Text = "Clave Actual";
            // 
            // frmCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 247);
            this.Controls.Add(this.gbCambiarClave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 286);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 286);
            this.Name = "frmCambiarClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Clave Usuario";
            this.gbCambiarClave.ResumeLayout(false);
            this.gbCambiarClave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCambiarClave;
        private System.Windows.Forms.Label lblClaveAhora;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtNuevaClave2;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.TextBox txtClaveAhora;
        private System.Windows.Forms.Label lblNuevaClave2;
        private System.Windows.Forms.Label lblNuevaClave;
    }
}