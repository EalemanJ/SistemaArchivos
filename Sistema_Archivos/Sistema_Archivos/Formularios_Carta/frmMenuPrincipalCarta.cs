using System;
using System.Deployment.Application;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmMenuPrincipalCarta : Form
    {
        public frmMenuPrincipalCarta()
        {
            InitializeComponent();
            msMenuOpciones.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Gray, rc);
                    e.Graphics.DrawRectangle(Pens.Black, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
        }

        private void frmMenuPrincipalCarta_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = "";
            lblNombreUsuario.Text = Sesion.NombreUsuario.ToUpper();
        }

        private void TsmiAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAgregarUsuario"] is frmAgregarUsuario au)
            {
                au.Focus();
            }
            else
            {
                frmAgregarUsuario au2 = new frmAgregarUsuario();
                au2.Show();
            }
        }

        private void TsmiVerUsuarios_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmVerUsuarios"] is frmVerUsuarios vu)
            {
                vu.Focus();
            }
            else
            {
                frmVerUsuarios vu2 = new frmVerUsuarios();
                vu2.Show();
            }
        }

        private void TsmiCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCambiarClave"] is frmCambiarClave cc)
            {
                cc.Focus();
            }
            else
            {
                frmCambiarClave cc2 = new frmCambiarClave();
                cc2.Show();
            }
        }

        private void TsmiSalir_Click(object sender, EventArgs e)
        {
            Sesion.Menu_salir = "menu_carta";
            if (Application.OpenForms["frmSalir"] is frmSalir s)
            {
                s.Focus();
            }
            else
            {
                frmSalir s2 = new frmSalir();
                s2.Show();
            }
        }

        private void TsmiAcercaDe_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAcercaDe"] is frmAcercaDe ac)
            {
                ac.Focus();
            }
            else
            {
                frmAcercaDe ac2 = new frmAcercaDe();
                ac2.Show();
            }
        }

        private void TsmiArranqueWindows_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmArranque"] is frmArranque a)
            {
                a.Focus();
            }
            else
            {
                frmArranque a2 = new frmArranque();
                a2.Show();
            }
        }

        private void TsmiPersonal_MouseEnter(object sender, EventArgs e)
        {
            tsmiPersonal.ForeColor = Color.Black;
            tsmiInformacion.ForeColor = Color.White;
        }

        private void TsmiInformacion_MouseEnter(object sender, EventArgs e)
        {
            tsmiPersonal.ForeColor = Color.White;
            tsmiInformacion.ForeColor = Color.Black;
        }

        private void frmMenuPrincipalCarta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["frmSeleccionarSistema"] is frmSeleccionarSistema si)
            {
                si.Focus();
                si.Show();
            }
            else
            {
                frmSeleccionarSistema si2 = new frmSeleccionarSistema();
                si2.Show();
            }
        }

        private void BtnIngreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmIngresoCarta"] is frmIngresoCarta ic)
            {
                ic.Focus();
                ic.Show();
            }
            else
            {
                frmIngresoCarta ic2 = new frmIngresoCarta();
                ic2.Show();
            }
        }

        private void BtnGenerarRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarArchivoRendicionCarta"] is frmGenerarArchivoRendicionCarta rc)
            {
                rc.Focus();
                rc.Show();
            }
            else
            {
                frmGenerarArchivoRendicionCarta rc2 = new frmGenerarArchivoRendicionCarta();
                rc2.Show();
            }
        }

        private void BtnRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRendicionCarta"] is frmRendicionCarta rc)
            {
                rc.Focus();
                rc.Show();
            }
            else
            {
                frmRendicionCarta rc2 = new frmRendicionCarta();
                rc2.Show();
            }
        }

        private void BtnEliminarFun_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEliminarFunCarta"] is frmEliminarFunCarta efc)
            {
                efc.Focus();
                efc.Show();
            }
            else
            {
                frmEliminarFunCarta efc2 = new frmEliminarFunCarta();
                efc2.Show();
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBuscarFunCarta"] is frmBuscarFunCarta bc)
            {
                bc.Focus();
                bc.Show();
            }
            else
            {
                frmBuscarFunCarta bc2 = new frmBuscarFunCarta();
                bc2.Show();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmModificarFunCarta"] is frmModificarFunCarta mfc)
            {
                mfc.Focus();
                mfc.Show();
            }
            else
            {
                frmModificarFunCarta mfc2 = new frmModificarFunCarta();
                mfc2.Show();
            }
        }

        private void BtnCargarExcel_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCargarExcelCarta"] is frmCargarExcelCarta ec)
            {
                ec.Focus();
                ec.Show();
            }
            else
            {
                frmCargarExcelCarta ec2 = new frmCargarExcelCarta();
                ec2.Show();
            }
        }

        private void BtnGenerarDocCarga_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarCargaNotificadorCarta"] is frmGenerarCargaNotificadorCarta ec)
            {
                ec.Focus();
                ec.Show();
            }
            else
            {
                frmGenerarCargaNotificadorCarta ec2 = new frmGenerarCargaNotificadorCarta();
                ec2.Show();
            }
        }

        private void BtnMantenedor_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMantenedorPrincipalCarta"] is frmMantenedorPrincipalCarta mpc)
            {
                mpc.Focus();
                mpc.Show();
            }
            else
            {
                frmMantenedorPrincipalCarta mpc2 = new frmMantenedorPrincipalCarta();
                mpc2.Show();
            }
        }

        private void LlActualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    if (ApplicationDeployment.CurrentDeployment.CheckForUpdate())
                    {
                        ComprobarUpdate u = new ComprobarUpdate();
                        u.BuscarActualizacion("link");
                    }
                    else
                    {
                        MessageBox.Show("Está usando la última versión, no es necesario actualizar.", "VERSIÓN ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("No hay actualizaciones para el programa.", "SIN ACTUALIZACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar la actualización. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}