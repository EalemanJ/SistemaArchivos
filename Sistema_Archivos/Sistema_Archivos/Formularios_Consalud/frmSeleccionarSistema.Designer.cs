namespace Sistema_Archivos
{
    partial class frmSeleccionarSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccionarSistema));
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.Btnesencial = new System.Windows.Forms.Button();
            this.btnCarta = new System.Windows.Forms.Button();
            this.btnColmena = new System.Windows.Forms.Button();
            this.btnConsalud = new System.Windows.Forms.Button();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.Btnesencial);
            this.gb1.Controls.Add(this.btnCarta);
            this.gb1.Controls.Add(this.btnColmena);
            this.gb1.Controls.Add(this.btnConsalud);
            this.gb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(12, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(456, 155);
            this.gb1.TabIndex = 0;
            this.gb1.TabStop = false;
            // 
            // Btnesencial
            // 
            this.Btnesencial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.Btnesencial.FlatAppearance.BorderSize = 2;
            this.Btnesencial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Btnesencial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnesencial.Location = new System.Drawing.Point(343, 37);
            this.Btnesencial.Name = "Btnesencial";
            this.Btnesencial.Size = new System.Drawing.Size(105, 80);
            this.Btnesencial.TabIndex = 8;
            this.Btnesencial.Text = "Sistema  ESENCIAL";
            this.Btnesencial.UseVisualStyleBackColor = true;
            this.Btnesencial.Click += new System.EventHandler(this.Btnesencial_Click);
            // 
            // btnCarta
            // 
            this.btnCarta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnCarta.FlatAppearance.BorderSize = 2;
            this.btnCarta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCarta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarta.Location = new System.Drawing.Point(232, 37);
            this.btnCarta.Name = "btnCarta";
            this.btnCarta.Size = new System.Drawing.Size(105, 80);
            this.btnCarta.TabIndex = 7;
            this.btnCarta.Text = "Sistema  CARTA";
            this.btnCarta.UseVisualStyleBackColor = true;
            this.btnCarta.Click += new System.EventHandler(this.btnCarta_Click);
            // 
            // btnColmena
            // 
            this.btnColmena.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnColmena.FlatAppearance.BorderSize = 2;
            this.btnColmena.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnColmena.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColmena.Location = new System.Drawing.Point(121, 37);
            this.btnColmena.Name = "btnColmena";
            this.btnColmena.Size = new System.Drawing.Size(105, 80);
            this.btnColmena.TabIndex = 6;
            this.btnColmena.Text = "Sistema COLMENA";
            this.btnColmena.UseVisualStyleBackColor = true;
            this.btnColmena.Click += new System.EventHandler(this.btnColmena_Click);
            // 
            // btnConsalud
            // 
            this.btnConsalud.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(135)))), ((int)(((byte)(14)))));
            this.btnConsalud.FlatAppearance.BorderSize = 2;
            this.btnConsalud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConsalud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsalud.Location = new System.Drawing.Point(10, 37);
            this.btnConsalud.Name = "btnConsalud";
            this.btnConsalud.Size = new System.Drawing.Size(105, 80);
            this.btnConsalud.TabIndex = 5;
            this.btnConsalud.Text = "Sistema CONSALUD";
            this.btnConsalud.UseVisualStyleBackColor = true;
            this.btnConsalud.Click += new System.EventHandler(this.btnConsalud_Click);
            // 
            // frmSeleccionarSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 179);
            this.Controls.Add(this.gb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(496, 218);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(496, 218);
            this.Name = "frmSeleccionarSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Sistema";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSeleccionarSistema_FormClosing);
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnCarta;
        private System.Windows.Forms.Button btnColmena;
        private System.Windows.Forms.Button btnConsalud;
        private System.Windows.Forms.Button Btnesencial;
    }
}