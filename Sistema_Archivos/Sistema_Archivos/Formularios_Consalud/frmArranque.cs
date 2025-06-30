using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmArranque : Form
    {
        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public frmArranque()
        {
            InitializeComponent();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            //para iniciar con windows
            try
            {
                if (ckbArranque.Checked)
                {
                    rkApp.SetValue("registro_fun", Application.ExecutablePath.ToString());
                    MessageBox.Show("Se ha programado la aplicación para iniciar con Windows.", "PROGRAMACIÓN COMPLETA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Dispose();
                }
                else
                {
                    rkApp.DeleteValue("registro_fun", false);
                    MessageBox.Show("Se ha desactivado el arranque al iniciar windows.", "ARRANQUE DESACTIVADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " +
                ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmArranque_Load(object sender, EventArgs e)
        {
            //comprueba si está registrado el inicio con windows
            try
            {
                lblAviso.Visible = false;
                if (rkApp.GetValue("registro_fun") == null)
                {
                    ckbArranque.Checked = false;
                    lblAviso.Visible = false;
                }
                else
                {
                    ckbArranque.Checked = true;
                    lblAviso.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " +
                ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}