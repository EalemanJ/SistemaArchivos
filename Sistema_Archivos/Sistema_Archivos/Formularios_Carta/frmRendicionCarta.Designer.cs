namespace Sistema_Archivos
{
    partial class frmRendicionCarta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRendicionCarta));
            this.gbRendicion = new System.Windows.Forms.GroupBox();
            this.pbInformacion = new System.Windows.Forms.PictureBox();
            this.txtFechaRendicion = new System.Windows.Forms.TextBox();
            this.lblFechaRendicion = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtFechaCarga = new System.Windows.Forms.TextBox();
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.txtComunaE = new System.Windows.Forms.TextBox();
            this.txtDireccionE = new System.Windows.Forms.TextBox();
            this.txtNombreE = new System.Windows.Forms.TextBox();
            this.txtRutAfiliado = new System.Windows.Forms.TextBox();
            this.txtNotificador = new System.Windows.Forms.TextBox();
            this.txtFun = new System.Windows.Forms.TextBox();
            this.lblFechaCarga = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblComunaEmpresa = new System.Windows.Forms.Label();
            this.lblDireccionEmpresa = new System.Windows.Forms.Label();
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.lblRutAfiliado = new System.Windows.Forms.Label();
            this.lblNotificador = new System.Windows.Forms.Label();
            this.lblFun = new System.Windows.Forms.Label();
            this.gbRendicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRendicion
            // 
            this.gbRendicion.Controls.Add(this.pbInformacion);
            this.gbRendicion.Controls.Add(this.txtFechaRendicion);
            this.gbRendicion.Controls.Add(this.lblFechaRendicion);
            this.gbRendicion.Controls.Add(this.btnVerificar);
            this.gbRendicion.Controls.Add(this.btnSalir);
            this.gbRendicion.Controls.Add(this.btnLimpiar);
            this.gbRendicion.Controls.Add(this.btnActualizar);
            this.gbRendicion.Controls.Add(this.txtFechaCarga);
            this.gbRendicion.Controls.Add(this.txtFechaIngreso);
            this.gbRendicion.Controls.Add(this.txtComunaE);
            this.gbRendicion.Controls.Add(this.txtDireccionE);
            this.gbRendicion.Controls.Add(this.txtNombreE);
            this.gbRendicion.Controls.Add(this.txtRutAfiliado);
            this.gbRendicion.Controls.Add(this.txtNotificador);
            this.gbRendicion.Controls.Add(this.txtFun);
            this.gbRendicion.Controls.Add(this.lblFechaCarga);
            this.gbRendicion.Controls.Add(this.lblFechaIngreso);
            this.gbRendicion.Controls.Add(this.lblComunaEmpresa);
            this.gbRendicion.Controls.Add(this.lblDireccionEmpresa);
            this.gbRendicion.Controls.Add(this.lblNombreEmpresa);
            this.gbRendicion.Controls.Add(this.lblRutAfiliado);
            this.gbRendicion.Controls.Add(this.lblNotificador);
            this.gbRendicion.Controls.Add(this.lblFun);
            this.gbRendicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRendicion.Location = new System.Drawing.Point(12, 12);
            this.gbRendicion.Name = "gbRendicion";
            this.gbRendicion.Size = new System.Drawing.Size(611, 539);
            this.gbRendicion.TabIndex = 1;
            this.gbRendicion.TabStop = false;
            // 
            // pbInformacion
            // 
            this.pbInformacion.Image = global::Sistema_Archivos.Properties.Resources.globo_informacion;
            this.pbInformacion.Location = new System.Drawing.Point(511, 375);
            this.pbInformacion.Name = "pbInformacion";
            this.pbInformacion.Size = new System.Drawing.Size(46, 40);
            this.pbInformacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInformacion.TabIndex = 46;
            this.pbInformacion.TabStop = false;
            this.pbInformacion.Click += new System.EventHandler(this.PbInformacion_Click);
            // 
            // txtFechaRendicion
            // 
            this.txtFechaRendicion.Location = new System.Drawing.Point(194, 393);
            this.txtFechaRendicion.MaxLength = 10;
            this.txtFechaRendicion.Name = "txtFechaRendicion";
            this.txtFechaRendicion.ReadOnly = true;
            this.txtFechaRendicion.Size = new System.Drawing.Size(265, 22);
            this.txtFechaRendicion.TabIndex = 23;
            // 
            // lblFechaRendicion
            // 
            this.lblFechaRendicion.AutoSize = true;
            this.lblFechaRendicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRendicion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFechaRendicion.Location = new System.Drawing.Point(47, 399);
            this.lblFechaRendicion.Name = "lblFechaRendicion";
            this.lblFechaRendicion.Size = new System.Drawing.Size(125, 16);
            this.lblFechaRendicion.TabIndex = 22;
            this.lblFechaRendicion.Text = "Fecha Rendición";
            // 
            // btnVerificar
            // 
            this.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnVerificar.FlatAppearance.BorderSize = 2;
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Location = new System.Drawing.Point(495, 42);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(105, 28);
            this.btnVerificar.TabIndex = 21;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.BtnVerificar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(441, 447);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 32);
            this.btnSalir.TabIndex = 20;
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
            this.btnLimpiar.Location = new System.Drawing.Point(273, 447);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(145, 32);
            this.btnLimpiar.TabIndex = 19;
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
            this.btnActualizar.Location = new System.Drawing.Point(50, 447);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(205, 32);
            this.btnActualizar.TabIndex = 18;
            this.btnActualizar.Text = "Ingresar datos modificados";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // txtFechaCarga
            // 
            this.txtFechaCarga.Location = new System.Drawing.Point(194, 353);
            this.txtFechaCarga.Name = "txtFechaCarga";
            this.txtFechaCarga.ReadOnly = true;
            this.txtFechaCarga.Size = new System.Drawing.Size(265, 22);
            this.txtFechaCarga.TabIndex = 17;
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(194, 309);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(265, 22);
            this.txtFechaIngreso.TabIndex = 16;
            // 
            // txtComunaE
            // 
            this.txtComunaE.Location = new System.Drawing.Point(194, 264);
            this.txtComunaE.Name = "txtComunaE";
            this.txtComunaE.ReadOnly = true;
            this.txtComunaE.Size = new System.Drawing.Size(265, 22);
            this.txtComunaE.TabIndex = 15;
            // 
            // txtDireccionE
            // 
            this.txtDireccionE.Location = new System.Drawing.Point(194, 219);
            this.txtDireccionE.Name = "txtDireccionE";
            this.txtDireccionE.ReadOnly = true;
            this.txtDireccionE.Size = new System.Drawing.Size(265, 22);
            this.txtDireccionE.TabIndex = 14;
            // 
            // txtNombreE
            // 
            this.txtNombreE.Location = new System.Drawing.Point(194, 177);
            this.txtNombreE.Name = "txtNombreE";
            this.txtNombreE.ReadOnly = true;
            this.txtNombreE.Size = new System.Drawing.Size(265, 22);
            this.txtNombreE.TabIndex = 13;
            // 
            // txtRutAfiliado
            // 
            this.txtRutAfiliado.Location = new System.Drawing.Point(194, 135);
            this.txtRutAfiliado.Name = "txtRutAfiliado";
            this.txtRutAfiliado.ReadOnly = true;
            this.txtRutAfiliado.Size = new System.Drawing.Size(265, 22);
            this.txtRutAfiliado.TabIndex = 12;
            // 
            // txtNotificador
            // 
            this.txtNotificador.Location = new System.Drawing.Point(194, 96);
            this.txtNotificador.Name = "txtNotificador";
            this.txtNotificador.ReadOnly = true;
            this.txtNotificador.Size = new System.Drawing.Size(265, 22);
            this.txtNotificador.TabIndex = 11;
            // 
            // txtFun
            // 
            this.txtFun.Location = new System.Drawing.Point(194, 43);
            this.txtFun.Name = "txtFun";
            this.txtFun.Size = new System.Drawing.Size(265, 22);
            this.txtFun.TabIndex = 9;
            // 
            // lblFechaCarga
            // 
            this.lblFechaCarga.AutoSize = true;
            this.lblFechaCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFechaCarga.Location = new System.Drawing.Point(47, 359);
            this.lblFechaCarga.Name = "lblFechaCarga";
            this.lblFechaCarga.Size = new System.Drawing.Size(97, 16);
            this.lblFechaCarga.TabIndex = 8;
            this.lblFechaCarga.Text = "Fecha Carga";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFechaIngreso.Location = new System.Drawing.Point(47, 315);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(107, 16);
            this.lblFechaIngreso.TabIndex = 7;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // lblComunaEmpresa
            // 
            this.lblComunaEmpresa.AutoSize = true;
            this.lblComunaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComunaEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblComunaEmpresa.Location = new System.Drawing.Point(47, 270);
            this.lblComunaEmpresa.Name = "lblComunaEmpresa";
            this.lblComunaEmpresa.Size = new System.Drawing.Size(130, 16);
            this.lblComunaEmpresa.TabIndex = 6;
            this.lblComunaEmpresa.Text = "Comuna Empresa";
            // 
            // lblDireccionEmpresa
            // 
            this.lblDireccionEmpresa.AutoSize = true;
            this.lblDireccionEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblDireccionEmpresa.Location = new System.Drawing.Point(47, 225);
            this.lblDireccionEmpresa.Name = "lblDireccionEmpresa";
            this.lblDireccionEmpresa.Size = new System.Drawing.Size(136, 16);
            this.lblDireccionEmpresa.TabIndex = 5;
            this.lblDireccionEmpresa.Text = "Direccón Empresa";
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.AutoSize = true;
            this.lblNombreEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNombreEmpresa.Location = new System.Drawing.Point(47, 183);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(129, 16);
            this.lblNombreEmpresa.TabIndex = 4;
            this.lblNombreEmpresa.Text = "Nombre Empresa";
            // 
            // lblRutAfiliado
            // 
            this.lblRutAfiliado.AutoSize = true;
            this.lblRutAfiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutAfiliado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRutAfiliado.Location = new System.Drawing.Point(47, 141);
            this.lblRutAfiliado.Name = "lblRutAfiliado";
            this.lblRutAfiliado.Size = new System.Drawing.Size(88, 16);
            this.lblRutAfiliado.TabIndex = 3;
            this.lblRutAfiliado.Text = "Rut Afiliado";
            // 
            // lblNotificador
            // 
            this.lblNotificador.AutoSize = true;
            this.lblNotificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNotificador.Location = new System.Drawing.Point(47, 102);
            this.lblNotificador.Name = "lblNotificador";
            this.lblNotificador.Size = new System.Drawing.Size(84, 16);
            this.lblNotificador.TabIndex = 2;
            this.lblNotificador.Text = "Notificador";
            // 
            // lblFun
            // 
            this.lblFun.AutoSize = true;
            this.lblFun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFun.Location = new System.Drawing.Point(47, 49);
            this.lblFun.Name = "lblFun";
            this.lblFun.Size = new System.Drawing.Size(51, 16);
            this.lblFun.TabIndex = 0;
            this.lblFun.Text = "F.U.N.";
            // 
            // frmRendicionCarta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 563);
            this.Controls.Add(this.gbRendicion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(651, 602);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(651, 602);
            this.Name = "frmRendicionCarta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendición - Sistema CARTA";
            this.gbRendicion.ResumeLayout(false);
            this.gbRendicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInformacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRendicion;
        private System.Windows.Forms.PictureBox pbInformacion;
        private System.Windows.Forms.TextBox txtFechaRendicion;
        private System.Windows.Forms.Label lblFechaRendicion;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtFechaCarga;
        private System.Windows.Forms.TextBox txtFechaIngreso;
        private System.Windows.Forms.TextBox txtComunaE;
        private System.Windows.Forms.TextBox txtDireccionE;
        private System.Windows.Forms.TextBox txtNombreE;
        private System.Windows.Forms.TextBox txtRutAfiliado;
        private System.Windows.Forms.TextBox txtNotificador;
        private System.Windows.Forms.TextBox txtFun;
        private System.Windows.Forms.Label lblFechaCarga;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblComunaEmpresa;
        private System.Windows.Forms.Label lblDireccionEmpresa;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private System.Windows.Forms.Label lblRutAfiliado;
        private System.Windows.Forms.Label lblNotificador;
        private System.Windows.Forms.Label lblFun;
    }
}