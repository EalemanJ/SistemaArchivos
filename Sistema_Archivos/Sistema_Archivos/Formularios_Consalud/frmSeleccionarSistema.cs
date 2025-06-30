using System;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmSeleccionarSistema : Form
    {
        public frmSeleccionarSistema()
        {
            InitializeComponent();
        }

        private void frmSeleccionarSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sesion.Menu_salir = "";
            frmSalir s = Application.OpenForms["frmSalir"] as frmSalir;
            if (s != null)
            {
                s.Focus();
                s.Show();
            }
            else
            {
                frmSalir s1 = new frmSalir();
                s1.Show();
            }
            this.Hide();
        }

        private void btnConsalud_Click(object sender, EventArgs e)
        {
            Sesion.Menu_salir = "";
            frmMenuPrincipal mp = Application.OpenForms["frmMenuPrincipal"] as frmMenuPrincipal;
            if (mp != null)
            {
                mp.Focus();
                mp.Show();
            }
            else
            {
                frmMenuPrincipal mp1 = new frmMenuPrincipal();
                mp1.Show();
            }
            Hide();
        }

        private void btnColmena_Click(object sender, EventArgs e)
        {
            Sesion.Menu_salir = "";
            frmMenuPrincipalColmena mp = Application.OpenForms["frmMenuPrincipalColmena"] as frmMenuPrincipalColmena;
            if (mp != null)
            {
                mp.Focus();
                mp.Show();
            }
            else
            {
                frmMenuPrincipalColmena mp1 = new frmMenuPrincipalColmena();
                mp1.Show();
            }
            Hide();
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            Sesion.Menu_salir = "";
            frmMenuPrincipalCarta mp = Application.OpenForms["frmMenuPrincipalCarta"] as frmMenuPrincipalCarta;
            if (mp != null)
            {
                mp.Focus();
                mp.Show();
            }
            else
            {
                frmMenuPrincipalCarta mp1 = new frmMenuPrincipalCarta();
                mp1.Show();
            }
            Hide();
        }

        private void Btnesencial_Click(object sender, EventArgs e)
        {
            Sesion.Menu_salir = "";
            frmMenuPrincipalEsencial mp = Application.OpenForms["frmMenuPrincipalEsencial"] as frmMenuPrincipalEsencial;
            if (mp != null)
            {
                mp.Focus();
                mp.Show();
            }
            else
            {
                frmMenuPrincipalEsencial mp1 = new frmMenuPrincipalEsencial();
                mp1.Show();
            }
            Hide();
        }
    }
}