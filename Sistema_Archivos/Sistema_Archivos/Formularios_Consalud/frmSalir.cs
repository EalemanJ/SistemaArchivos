using System;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmSalir : Form
    {
        public frmSalir()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Sesion.LimpiarSesion();
                Application.ExitThread();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al momento de cerrar Sesión.", "ERROR DE CIERRE DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbVolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sesion.Menu_salir == "menu_consalud")
                {
                    frmMenuPrincipal mp = Application.OpenForms["frmMenuPrincipal"] as frmMenuPrincipal;
                    mp.Dispose();
                }
                else if (Sesion.Menu_salir == "menu_colmena")
                {
                    frmMenuPrincipalColmena mp = Application.OpenForms["frmMenuPrincipalColmena"] as frmMenuPrincipalColmena;
                    mp.Dispose();
                }
                else if (Sesion.Menu_salir == "menu_carta")
                {
                    frmMenuPrincipalCarta mp = Application.OpenForms["frmMenuPrincipalCarta"] as frmMenuPrincipalCarta;
                    mp.Dispose();
                }
                frmSeleccionarSistema ss = Application.OpenForms["frmSeleccionarSistema"] as frmSeleccionarSistema;
                if (ss != null)
                {
                    ss.Focus();
                    ss.Show();
                }
                else
                {
                    frmSeleccionarSistema ss2 = new frmSeleccionarSistema();
                    ss2.Show();
                }
                Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar volver al menú Principal de la Aplicación.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSalir_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Sesion.LimpiarSesion();
                Application.ExitThread();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al momento de cerrar Sesión.", "ERROR DE CIERRE DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}