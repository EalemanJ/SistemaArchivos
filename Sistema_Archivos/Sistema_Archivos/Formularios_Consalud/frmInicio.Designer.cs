namespace Sistema_Archivos
{
    partial class frmInicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.pbCarga = new System.Windows.Forms.ProgressBar();
            this.lblAvisoCarga = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCarga
            // 
            this.pbCarga.Location = new System.Drawing.Point(73, 455);
            this.pbCarga.MarqueeAnimationSpeed = 1;
            this.pbCarga.Name = "pbCarga";
            this.pbCarga.Size = new System.Drawing.Size(403, 23);
            this.pbCarga.TabIndex = 7;
            this.pbCarga.UseWaitCursor = true;
            // 
            // lblAvisoCarga
            // 
            this.lblAvisoCarga.AutoSize = true;
            this.lblAvisoCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoCarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAvisoCarga.Location = new System.Drawing.Point(69, 416);
            this.lblAvisoCarga.Name = "lblAvisoCarga";
            this.lblAvisoCarga.Size = new System.Drawing.Size(60, 24);
            this.lblAvisoCarga.TabIndex = 6;
            this.lblAvisoCarga.Text = "label2";
            this.lblAvisoCarga.UseWaitCursor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNombre.Location = new System.Drawing.Point(145, 375);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(250, 24);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Sistema FUN Versión 1.9.3.2";
            this.lblNombre.UseWaitCursor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Sistema_Archivos.Properties.Resources.aleman_informatica;
            this.pictureBox1.Location = new System.Drawing.Point(73, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(403, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 500);
            this.Controls.Add(this.pbCarga);
            this.Controls.Add(this.lblAvisoCarga);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(576, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(576, 500);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arranque del Sistema";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCarga;
        private System.Windows.Forms.Label lblAvisoCarga;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}