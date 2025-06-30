using System;
using System.Deployment.Application;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
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

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
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

        private void TsmiSalir_Click(object sender, EventArgs e)
        {
            Sesion.Menu_salir = "menu_consalud";
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

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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
            if (Application.OpenForms["frmIngreso"] is frmIngreso i)
            {
                i.Focus();
            }
            else
            {
                frmIngreso i2 = new frmIngreso();
                i2.Show();
            }
        }

        private void BtnMantenedor_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMantenedorPrincipal"] is frmMantenedorPrincipal mp)
            {
                mp.Focus();
            }
            else
            {
                frmMantenedorPrincipal mp2 = new frmMantenedorPrincipal();
                mp2.Show();
            }
        }

        private void BtnGenerarRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarArchivoRendicion"] is frmGenerarArchivoRendicion ar)
            {
                ar.Focus();
            }
            else
            {
                frmGenerarArchivoRendicion ar2 = new frmGenerarArchivoRendicion();
                ar2.Show();
            }
        }

        private void BtnRendicion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRendicion"] is frmRendicion r)
            {
                r.Focus();
            }
            else
            {
                frmRendicion r2 = new frmRendicion();
                r2.Show();
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

        private void BtnEliminarFun_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmEliminarFun"] is frmEliminarFun ef)
            {
                ef.Focus();
            }
            else
            {
                frmEliminarFun ef2 = new frmEliminarFun();
                ef2.Show();
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBuscarFun"] is frmBuscarFun bf)
            {
                bf.Focus();
            }
            else
            {
                frmBuscarFun bf2 = new frmBuscarFun();
                bf2.Show();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmModificarFun"] is frmModificarFun mf)
            {
                mf.Focus();
            }
            else
            {
                frmModificarFun mf2 = new frmModificarFun();
                mf2.Show();
            }
        }

        private void BtnCargarExcel_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCargarExcel"] is frmCargarExcel ce)
            {
                ce.Focus();
            }
            else
            {
                frmCargarExcel ce2 = new frmCargarExcel();
                ce2.Show();
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

        private void BtnGenerarDocCarga_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGenerarCargaNotificador"] is frmGenerarCargaNotificador gcn)
            {
                gcn.Focus();
            }
            else
            {
                frmGenerarCargaNotificador gcn2 = new frmGenerarCargaNotificador();
                gcn2.Show();
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