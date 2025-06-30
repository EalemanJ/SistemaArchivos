using System;
using System.Deployment.Application;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmMenuPrincipalEsencial : Form
    {
        public frmMenuPrincipalEsencial()
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

        private void frmMenuPrincipalesencial_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = "";
            lblNombreUsuario.Text = Sesion.NombreUsuario.ToUpper();
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

        private void frmMenuPrincipalesencial_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmSeleccionarSistema ss = new frmSeleccionarSistema();
            ss.Show();
            Hide();
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
            Sesion.Menu_salir = "menu_Esencial";
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

        private void BtnIngreso_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmIngresoEsencial"] is frmIngresoEsencial a)
            {
                a.Focus();
            }
            else
            {
                frmIngresoEsencial a2 = new frmIngresoEsencial();
                a2.Show();
            }
        }

        private void BtnGenerarRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarArchivoRendicionEsencial"] is frmGenerarArchivoRendicionEsencial a)
            {
                a.Focus();
            }
            else
            {
                frmGenerarArchivoRendicionEsencial a2 = new frmGenerarArchivoRendicionEsencial();
                a2.Show();
            }
        }

        private void BtnRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRendicionEsencial"] is frmRendicionEsencial rc)
            {
                rc.Focus();
            }
            else
            {
                frmRendicionEsencial rc2 = new frmRendicionEsencial();
                rc2.Show();
            }
        }

        private void BtnEliminarFun_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEliminarFunEsencial"] is frmEliminarFunEsencial rc)
            {
                rc.Focus();
            }
            else
            {
                frmEliminarFunEsencial rc2 = new frmEliminarFunEsencial();
                rc2.Show();
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBuscarEsencial"] is frmBuscarEsencial bc)
            {
                bc.Focus();
            }
            else
            {
                frmBuscarEsencial bc2 = new frmBuscarEsencial();
                bc2.Show();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmModificarFunEsencial"] is frmModificarFunEsencial bc)
            {
                bc.Focus();
            }
            else
            {
                frmModificarFunEsencial bc2 = new frmModificarFunEsencial();
                bc2.Show();
            }
        }

        private void BtnCargarExcel_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCargarExcelEsencial"] is frmCargarExcelEsencial ce)
            {
                ce.Focus();
            }
            else
            {
                frmCargarExcelEsencial ce2 = new frmCargarExcelEsencial();
                ce2.Show();
            }
        }

        private void BtnGenerarDocCarga_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarCargaNotificadorEsencial"] is frmGenerarCargaNotificadorEsencial ce)
            {
                ce.Focus();
            }
            else
            {
                frmGenerarCargaNotificadorEsencial ce2 = new frmGenerarCargaNotificadorEsencial();
                ce2.Show();
            }
        }

        private void BtnMantenedor_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMantenedorPrincipalEsencial"] is frmMantenedorPrincipalEsencial ce)
            {
                ce.Focus();
            }
            else
            {
                frmMantenedorPrincipalEsencial ce2 = new frmMantenedorPrincipalEsencial();
                ce2.Show();
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