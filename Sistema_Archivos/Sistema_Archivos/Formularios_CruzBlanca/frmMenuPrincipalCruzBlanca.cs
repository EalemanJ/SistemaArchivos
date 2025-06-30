using System;
using System.Deployment.Application;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmMenuPrincipalCruzBlanca : Form
    {
        public frmMenuPrincipalCruzBlanca()
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

        private void frmMenuPrincipalCruzBlanca_Load(object sender, EventArgs e)
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

        private void frmMenuPrincipalCruzBlanca_FormClosing(object sender, FormClosingEventArgs e)
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
            Sesion.Menu_salir = "menu_CruzBlanca";
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
            if (Application.OpenForms["frmIngresoCruzBlanca"] is frmIngresoCruzBlanca a)
            {
                a.Focus();
            }
            else
            {
                frmIngresoCruzBlanca a2 = new frmIngresoCruzBlanca();
                a2.Show();
            }
        }

        private void BtnGenerarRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarArchivoRendicionCruzBlanca"] is frmGenerarArchivoRendicionCruzBlanca a)
            {
                a.Focus();
            }
            else
            {
                frmGenerarArchivoRendicionCruzBlanca a2 = new frmGenerarArchivoRendicionCruzBlanca();
                a2.Show();
            }
        }

        private void BtnRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRendicionCruzBlanca"] is frmRendicionCruzBlanca rc)
            {
                rc.Focus();
            }
            else
            {
                frmRendicionCruzBlanca rc2 = new frmRendicionCruzBlanca();
                rc2.Show();
            }
        }

        private void BtnEliminarFun_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEliminarFunCruzBlanca"] is frmEliminarFunCruzBlanca rc)
            {
                rc.Focus();
            }
            else
            {
                frmEliminarFunCruzBlanca rc2 = new frmEliminarFunCruzBlanca();
                rc2.Show();
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBuscarCruzBlanca"] is frmBuscarCruzBlanca bc)
            {
                bc.Focus();
            }
            else
            {
                frmBuscarCruzBlanca bc2 = new frmBuscarCruzBlanca();
                bc2.Show();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmModificarFunCruzBlanca"] is frmModificarFunCruzBlanca bc)
            {
                bc.Focus();
            }
            else
            {
                frmModificarFunCruzBlanca bc2 = new frmModificarFunCruzBlanca();
                bc2.Show();
            }
        }

        private void BtnCargarExcel_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCargarExcelCruzBlanca"] is frmCargarExcelCruzBlanca ce)
            {
                ce.Focus();
            }
            else
            {
                frmCargarExcelCruzBlanca ce2 = new frmCargarExcelCruzBlanca();
                ce2.Show();
            }
        }

        private void BtnGenerarDocCarga_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarCargaNotificadorCruzBlanca"] is frmGenerarCargaNotificadorCruzBlanca ce)
            {
                ce.Focus();
            }
            else
            {
                frmGenerarCargaNotificadorCruzBlanca ce2 = new frmGenerarCargaNotificadorCruzBlanca();
                ce2.Show();
            }
        }

        private void BtnMantenedor_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] is frmMantenedorPrincipalCruzBlanca ce)
            {
                ce.Focus();
            }
            else
            {
                frmMantenedorPrincipalCruzBlanca ce2 = new frmMantenedorPrincipalCruzBlanca();
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