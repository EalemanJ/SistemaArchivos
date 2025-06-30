namespace Sistema_Archivos
{
    partial class frmGenerarArchivoRendicionColmena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarArchivoRendicionColmena));
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGenerarArchivo = new System.Windows.Forms.Button();
            this.dgvArchivoRendicion = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaRendicion = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbTipoRendicion = new System.Windows.Forms.ComboBox();
            this.lblFiltroRendicion = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivoRendicion)).BeginInit();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.cmbTipoRendicion);
            this.gb1.Controls.Add(this.lblFiltroRendicion);
            this.gb1.Controls.Add(this.cmbUsuario);
            this.gb1.Controls.Add(this.lblUsuario);
            this.gb1.Controls.Add(this.btnLimpiar);
            this.gb1.Controls.Add(this.btnSalir);
            this.gb1.Controls.Add(this.btnGenerarArchivo);
            this.gb1.Controls.Add(this.dgvArchivoRendicion);
            this.gb1.Controls.Add(this.btnBuscar);
            this.gb1.Controls.Add(this.dtpFechaRendicion);
            this.gb1.Controls.Add(this.lblFecha);
            this.gb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(12, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(976, 660);
            this.gb1.TabIndex = 0;
            this.gb1.TabStop = false;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(185, 70);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(254, 24);
            this.cmbUsuario.TabIndex = 10;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUsuario.Location = new System.Drawing.Point(21, 78);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(158, 16);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Rendición de Usuario";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 2;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(652, 616);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(145, 29);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(815, 616);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 29);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnGenerarArchivo
            // 
            this.btnGenerarArchivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnGenerarArchivo.FlatAppearance.BorderSize = 2;
            this.btnGenerarArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGenerarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarArchivo.Location = new System.Drawing.Point(730, 117);
            this.btnGenerarArchivo.Name = "btnGenerarArchivo";
            this.btnGenerarArchivo.Size = new System.Drawing.Size(230, 29);
            this.btnGenerarArchivo.TabIndex = 4;
            this.btnGenerarArchivo.Text = "Generar Archivo con Rendición";
            this.btnGenerarArchivo.UseVisualStyleBackColor = true;
            this.btnGenerarArchivo.Click += new System.EventHandler(this.BtnGenerarArchivo_Click);
            // 
            // dgvArchivoRendicion
            // 
            this.dgvArchivoRendicion.AllowUserToAddRows = false;
            this.dgvArchivoRendicion.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvArchivoRendicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchivoRendicion.EnableHeadersVisualStyles = false;
            this.dgvArchivoRendicion.Location = new System.Drawing.Point(6, 170);
            this.dgvArchivoRendicion.Name = "dgvArchivoRendicion";
            this.dgvArchivoRendicion.ReadOnly = true;
            this.dgvArchivoRendicion.Size = new System.Drawing.Size(954, 431);
            this.dgvArchivoRendicion.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnBuscar.FlatAppearance.BorderSize = 2;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(482, 117);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(145, 29);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar ";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // dtpFechaRendicion
            // 
            this.dtpFechaRendicion.Location = new System.Drawing.Point(185, 23);
            this.dtpFechaRendicion.Name = "dtpFechaRendicion";
            this.dtpFechaRendicion.Size = new System.Drawing.Size(254, 22);
            this.dtpFechaRendicion.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFecha.Location = new System.Drawing.Point(21, 29);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(125, 16);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha Rendición";
            // 
            // cmbTipoRendicion
            // 
            this.cmbTipoRendicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRendicion.FormattingEnabled = true;
            this.cmbTipoRendicion.Items.AddRange(new object[] {
            "Habilitado",
            "Fuera de Plazo",
            "Rechazado"});
            this.cmbTipoRendicion.Location = new System.Drawing.Point(185, 122);
            this.cmbTipoRendicion.Name = "cmbTipoRendicion";
            this.cmbTipoRendicion.Size = new System.Drawing.Size(254, 24);
            this.cmbTipoRendicion.TabIndex = 12;
            // 
            // lblFiltroRendicion
            // 
            this.lblFiltroRendicion.AutoSize = true;
            this.lblFiltroRendicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroRendicion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFiltroRendicion.Location = new System.Drawing.Point(21, 130);
            this.lblFiltroRendicion.Name = "lblFiltroRendicion";
            this.lblFiltroRendicion.Size = new System.Drawing.Size(136, 16);
            this.lblFiltroRendicion.TabIndex = 11;
            this.lblFiltroRendicion.Text = "Tipo de Rendición";
            // 
            // frmGenerarArchivoRendicionColmena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 684);
            this.Controls.Add(this.gb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1016, 723);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1016, 723);
            this.Name = "frmGenerarArchivoRendicionColmena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Archivo Rendición - Sistema COLMENA";
            this.Load += new System.EventHandler(this.frmGenerarArchivoRendicionColmena_Load);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchivoRendicion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaRendicion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridView dgvArchivoRendicion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGenerarArchivo;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbTipoRendicion;
        private System.Windows.Forms.Label lblFiltroRendicion;
    }
}