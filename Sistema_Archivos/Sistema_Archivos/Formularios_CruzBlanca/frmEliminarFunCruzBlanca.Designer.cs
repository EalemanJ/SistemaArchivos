namespace Sistema_Archivos
{
    partial class frmEliminarFunCruzBlanca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEliminarFunCruzBlanca));
            this.gbEliminarFun = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarFun = new System.Windows.Forms.Button();
            this.dgvEliminarFun = new System.Windows.Forms.DataGridView();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.txtFun = new System.Windows.Forms.TextBox();
            this.lblFun = new System.Windows.Forms.Label();
            this.gbEliminarFun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarFun)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEliminarFun
            // 
            this.gbEliminarFun.Controls.Add(this.btnLimpiar);
            this.gbEliminarFun.Controls.Add(this.btnSalir);
            this.gbEliminarFun.Controls.Add(this.btnEliminarFun);
            this.gbEliminarFun.Controls.Add(this.dgvEliminarFun);
            this.gbEliminarFun.Controls.Add(this.btnVerificar);
            this.gbEliminarFun.Controls.Add(this.txtFun);
            this.gbEliminarFun.Controls.Add(this.lblFun);
            this.gbEliminarFun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEliminarFun.Location = new System.Drawing.Point(12, 12);
            this.gbEliminarFun.Name = "gbEliminarFun";
            this.gbEliminarFun.Size = new System.Drawing.Size(851, 460);
            this.gbEliminarFun.TabIndex = 1;
            this.gbEliminarFun.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 2;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(514, 424);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(153, 30);
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
            this.btnSalir.Location = new System.Drawing.Point(692, 424);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(153, 30);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // btnEliminarFun
            // 
            this.btnEliminarFun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnEliminarFun.FlatAppearance.BorderSize = 2;
            this.btnEliminarFun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEliminarFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFun.Location = new System.Drawing.Point(23, 424);
            this.btnEliminarFun.Name = "btnEliminarFun";
            this.btnEliminarFun.Size = new System.Drawing.Size(153, 30);
            this.btnEliminarFun.TabIndex = 4;
            this.btnEliminarFun.Text = "Eliminar Fun";
            this.btnEliminarFun.UseVisualStyleBackColor = true;
            this.btnEliminarFun.Click += new System.EventHandler(this.BtnEliminarFun_Click);
            // 
            // dgvEliminarFun
            // 
            this.dgvEliminarFun.AllowUserToAddRows = false;
            this.dgvEliminarFun.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvEliminarFun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEliminarFun.EnableHeadersVisualStyles = false;
            this.dgvEliminarFun.Location = new System.Drawing.Point(23, 87);
            this.dgvEliminarFun.Name = "dgvEliminarFun";
            this.dgvEliminarFun.ReadOnly = true;
            this.dgvEliminarFun.Size = new System.Drawing.Size(822, 319);
            this.dgvEliminarFun.TabIndex = 3;
            this.dgvEliminarFun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvEliminarFun_KeyDown);
            // 
            // btnVerificar
            // 
            this.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnVerificar.FlatAppearance.BorderSize = 2;
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Location = new System.Drawing.Point(514, 32);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(122, 29);
            this.btnVerificar.TabIndex = 2;
            this.btnVerificar.Text = "Verificar Fun";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.BtnVerificar_Click);
            // 
            // txtFun
            // 
            this.txtFun.Location = new System.Drawing.Point(198, 39);
            this.txtFun.Name = "txtFun";
            this.txtFun.Size = new System.Drawing.Size(260, 22);
            this.txtFun.TabIndex = 1;
            // 
            // lblFun
            // 
            this.lblFun.AutoSize = true;
            this.lblFun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFun.Location = new System.Drawing.Point(20, 45);
            this.lblFun.Name = "lblFun";
            this.lblFun.Size = new System.Drawing.Size(161, 16);
            this.lblFun.TabIndex = 0;
            this.lblFun.Text = "F.U.N. o Código Único";
            // 
            // frmEliminarFunCruzBlanca
            // 
            this.AcceptButton = this.btnVerificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 484);
            this.Controls.Add(this.gbEliminarFun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(891, 523);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(891, 523);
            this.Name = "frmEliminarFunCruzBlanca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Fun - Sistema CRUZ BLANCA";
            this.Load += new System.EventHandler(this.frmEliminarFunCruzBlanca_Load);
            this.gbEliminarFun.ResumeLayout(false);
            this.gbEliminarFun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEliminarFun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEliminarFun;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminarFun;
        private System.Windows.Forms.DataGridView dgvEliminarFun;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.TextBox txtFun;
        private System.Windows.Forms.Label lblFun;
    }
}