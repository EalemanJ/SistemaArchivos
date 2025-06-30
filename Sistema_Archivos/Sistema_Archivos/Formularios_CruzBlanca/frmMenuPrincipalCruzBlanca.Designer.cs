namespace Sistema_Archivos
{
    partial class frmMenuPrincipalCruzBlanca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipalCruzBlanca));
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.llActualizar = new System.Windows.Forms.LinkLabel();
            this.btnGenerarDocCarga = new System.Windows.Forms.Button();
            this.btnCargarExcel = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnEliminarFun = new System.Windows.Forms.Button();
            this.btnRendicion = new System.Windows.Forms.Button();
            this.btnGenerarRendicion = new System.Windows.Forms.Button();
            this.btnMantenedor = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.msMenuOpciones = new System.Windows.Forms.MenuStrip();
            this.tsmiPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAgregarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCambiarContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInformacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiArranqueWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.gb1.SuspendLayout();
            this.msMenuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.llActualizar);
            this.gb1.Controls.Add(this.btnGenerarDocCarga);
            this.gb1.Controls.Add(this.btnCargarExcel);
            this.gb1.Controls.Add(this.btnModificar);
            this.gb1.Controls.Add(this.btnConsultar);
            this.gb1.Controls.Add(this.btnEliminarFun);
            this.gb1.Controls.Add(this.btnRendicion);
            this.gb1.Controls.Add(this.btnGenerarRendicion);
            this.gb1.Controls.Add(this.btnMantenedor);
            this.gb1.Controls.Add(this.btnIngreso);
            this.gb1.Controls.Add(this.lblNombreUsuario);
            this.gb1.Controls.Add(this.lblBienvenido);
            this.gb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(12, 27);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(531, 305);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            // 
            // llActualizar
            // 
            this.llActualizar.AutoSize = true;
            this.llActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llActualizar.Location = new System.Drawing.Point(226, 275);
            this.llActualizar.Name = "llActualizar";
            this.llActualizar.Size = new System.Drawing.Size(287, 18);
            this.llActualizar.TabIndex = 12;
            this.llActualizar.TabStop = true;
            this.llActualizar.Text = "Comprobar si hay una nueva actualización";
            this.llActualizar.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llActualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlActualizar_LinkClicked);
            // 
            // btnGenerarDocCarga
            // 
            this.btnGenerarDocCarga.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnGenerarDocCarga.FlatAppearance.BorderSize = 2;
            this.btnGenerarDocCarga.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGenerarDocCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarDocCarga.Location = new System.Drawing.Point(365, 219);
            this.btnGenerarDocCarga.Name = "btnGenerarDocCarga";
            this.btnGenerarDocCarga.Size = new System.Drawing.Size(148, 44);
            this.btnGenerarDocCarga.TabIndex = 10;
            this.btnGenerarDocCarga.Text = "Generar Carga Notificador";
            this.btnGenerarDocCarga.UseVisualStyleBackColor = true;
            this.btnGenerarDocCarga.Click += new System.EventHandler(this.BtnGenerarDocCarga_Click);
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnCargarExcel.FlatAppearance.BorderSize = 2;
            this.btnCargarExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCargarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarExcel.Location = new System.Drawing.Point(196, 219);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(148, 44);
            this.btnCargarExcel.TabIndex = 9;
            this.btnCargarExcel.Text = "Cargar información desde Excel";
            this.btnCargarExcel.UseVisualStyleBackColor = true;
            this.btnCargarExcel.Click += new System.EventHandler(this.BtnCargarExcel_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnModificar.FlatAppearance.BorderSize = 2;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Location = new System.Drawing.Point(26, 219);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(148, 44);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnConsultar.FlatAppearance.BorderSize = 2;
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Location = new System.Drawing.Point(365, 156);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(148, 44);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // btnEliminarFun
            // 
            this.btnEliminarFun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnEliminarFun.FlatAppearance.BorderSize = 2;
            this.btnEliminarFun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminarFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFun.Location = new System.Drawing.Point(196, 156);
            this.btnEliminarFun.Name = "btnEliminarFun";
            this.btnEliminarFun.Size = new System.Drawing.Size(148, 44);
            this.btnEliminarFun.TabIndex = 6;
            this.btnEliminarFun.Text = "Eliminar FUN";
            this.btnEliminarFun.UseVisualStyleBackColor = true;
            this.btnEliminarFun.Click += new System.EventHandler(this.BtnEliminarFun_Click);
            // 
            // btnRendicion
            // 
            this.btnRendicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnRendicion.FlatAppearance.BorderSize = 2;
            this.btnRendicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRendicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRendicion.Location = new System.Drawing.Point(26, 156);
            this.btnRendicion.Name = "btnRendicion";
            this.btnRendicion.Size = new System.Drawing.Size(148, 44);
            this.btnRendicion.TabIndex = 5;
            this.btnRendicion.Text = "Rendición";
            this.btnRendicion.UseVisualStyleBackColor = true;
            this.btnRendicion.Click += new System.EventHandler(this.BtnRendicion_Click);
            // 
            // btnGenerarRendicion
            // 
            this.btnGenerarRendicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnGenerarRendicion.FlatAppearance.BorderSize = 2;
            this.btnGenerarRendicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGenerarRendicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarRendicion.Location = new System.Drawing.Point(365, 90);
            this.btnGenerarRendicion.Name = "btnGenerarRendicion";
            this.btnGenerarRendicion.Size = new System.Drawing.Size(148, 44);
            this.btnGenerarRendicion.TabIndex = 4;
            this.btnGenerarRendicion.Text = "Generar archivos de Rendición";
            this.btnGenerarRendicion.UseVisualStyleBackColor = true;
            this.btnGenerarRendicion.Click += new System.EventHandler(this.BtnGenerarRendicion_Click);
            // 
            // btnMantenedor
            // 
            this.btnMantenedor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnMantenedor.FlatAppearance.BorderSize = 2;
            this.btnMantenedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMantenedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenedor.Location = new System.Drawing.Point(196, 90);
            this.btnMantenedor.Name = "btnMantenedor";
            this.btnMantenedor.Size = new System.Drawing.Size(148, 44);
            this.btnMantenedor.TabIndex = 3;
            this.btnMantenedor.Text = "Mantenedor";
            this.btnMantenedor.UseVisualStyleBackColor = true;
            this.btnMantenedor.Click += new System.EventHandler(this.BtnMantenedor_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnIngreso.FlatAppearance.BorderSize = 2;
            this.btnIngreso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.Location = new System.Drawing.Point(26, 90);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(148, 44);
            this.btnIngreso.TabIndex = 2;
            this.btnIngreso.Text = "Ingresar";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.BtnIngreso_Click);
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNombreUsuario.Location = new System.Drawing.Point(163, 40);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(65, 18);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "nombre";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBienvenido.Location = new System.Drawing.Point(23, 40);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(111, 18);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenido(a)";
            // 
            // msMenuOpciones
            // 
            this.msMenuOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.msMenuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPersonal,
            this.tsmiInformacion});
            this.msMenuOpciones.Location = new System.Drawing.Point(0, 0);
            this.msMenuOpciones.Name = "msMenuOpciones";
            this.msMenuOpciones.Size = new System.Drawing.Size(555, 24);
            this.msMenuOpciones.TabIndex = 2;
            this.msMenuOpciones.Text = "menuStrip1";
            // 
            // tsmiPersonal
            // 
            this.tsmiPersonal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAgregarUsuario,
            this.tsmiVerUsuarios,
            this.tsmiCambiarContrasena,
            this.tsmiSalir});
            this.tsmiPersonal.ForeColor = System.Drawing.Color.White;
            this.tsmiPersonal.Name = "tsmiPersonal";
            this.tsmiPersonal.Size = new System.Drawing.Size(98, 20);
            this.tsmiPersonal.Text = "Menú Personal";
            this.tsmiPersonal.MouseEnter += new System.EventHandler(this.TsmiPersonal_MouseEnter);
            // 
            // tsmiAgregarUsuario
            // 
            this.tsmiAgregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.tsmiAgregarUsuario.ForeColor = System.Drawing.Color.White;
            this.tsmiAgregarUsuario.Name = "tsmiAgregarUsuario";
            this.tsmiAgregarUsuario.Size = new System.Drawing.Size(212, 22);
            this.tsmiAgregarUsuario.Text = "Agregar un nuevo Usuario";
            this.tsmiAgregarUsuario.Click += new System.EventHandler(this.TsmiAgregarUsuario_Click);
            // 
            // tsmiVerUsuarios
            // 
            this.tsmiVerUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.tsmiVerUsuarios.ForeColor = System.Drawing.Color.White;
            this.tsmiVerUsuarios.Name = "tsmiVerUsuarios";
            this.tsmiVerUsuarios.Size = new System.Drawing.Size(212, 22);
            this.tsmiVerUsuarios.Text = "Ver Usuarios";
            this.tsmiVerUsuarios.Click += new System.EventHandler(this.TsmiVerUsuarios_Click);
            // 
            // tsmiCambiarContrasena
            // 
            this.tsmiCambiarContrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.tsmiCambiarContrasena.ForeColor = System.Drawing.Color.White;
            this.tsmiCambiarContrasena.Name = "tsmiCambiarContrasena";
            this.tsmiCambiarContrasena.Size = new System.Drawing.Size(212, 22);
            this.tsmiCambiarContrasena.Text = "Cambiar Contraseña";
            this.tsmiCambiarContrasena.Click += new System.EventHandler(this.TsmiCambiarContrasena_Click);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.tsmiSalir.ForeColor = System.Drawing.Color.White;
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(212, 22);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.TsmiSalir_Click);
            // 
            // tsmiInformacion
            // 
            this.tsmiInformacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAcercaDe,
            this.tsmiArranqueWindows});
            this.tsmiInformacion.ForeColor = System.Drawing.Color.White;
            this.tsmiInformacion.Name = "tsmiInformacion";
            this.tsmiInformacion.Size = new System.Drawing.Size(128, 20);
            this.tsmiInformacion.Text = "Información Sistema";
            this.tsmiInformacion.MouseEnter += new System.EventHandler(this.TsmiInformacion_MouseEnter);
            // 
            // tsmiAcercaDe
            // 
            this.tsmiAcercaDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.tsmiAcercaDe.ForeColor = System.Drawing.Color.White;
            this.tsmiAcercaDe.Name = "tsmiAcercaDe";
            this.tsmiAcercaDe.Size = new System.Drawing.Size(245, 22);
            this.tsmiAcercaDe.Text = "Acerca De";
            this.tsmiAcercaDe.Click += new System.EventHandler(this.TsmiAcercaDe_Click);
            // 
            // tsmiArranqueWindows
            // 
            this.tsmiArranqueWindows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.tsmiArranqueWindows.ForeColor = System.Drawing.Color.White;
            this.tsmiArranqueWindows.Name = "tsmiArranqueWindows";
            this.tsmiArranqueWindows.Size = new System.Drawing.Size(245, 22);
            this.tsmiArranqueWindows.Text = "Configurar Arranque del sistema";
            this.tsmiArranqueWindows.Click += new System.EventHandler(this.TsmiArranqueWindows_Click);
            // 
            // frmMenuPrincipalCruzBlanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 344);
            this.Controls.Add(this.msMenuOpciones);
            this.Controls.Add(this.gb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(571, 383);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(571, 383);
            this.Name = "frmMenuPrincipalCruzBlanca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal CRUZ BLANCA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenuPrincipalCruzBlanca_FormClosing);
            this.Load += new System.EventHandler(this.frmMenuPrincipalCruzBlanca_Load);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.msMenuOpciones.ResumeLayout(false);
            this.msMenuOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnGenerarDocCarga;
        private System.Windows.Forms.Button btnCargarExcel;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnEliminarFun;
        private System.Windows.Forms.Button btnRendicion;
        private System.Windows.Forms.Button btnGenerarRendicion;
        private System.Windows.Forms.Button btnMantenedor;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.MenuStrip msMenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonal;
        private System.Windows.Forms.ToolStripMenuItem tsmiAgregarUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiVerUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarContrasena;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmiInformacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiAcercaDe;
        private System.Windows.Forms.ToolStripMenuItem tsmiArranqueWindows;
        private System.Windows.Forms.LinkLabel llActualizar;
    }
}