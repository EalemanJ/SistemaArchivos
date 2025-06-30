using System;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmCambiarClave : Form
    {
        public frmCambiarClave()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar_campos() == true)
                {
                    if (txtClaveAhora.Text != Sesion.ClaveUsuario)
                    {
                        MessageBox.Show("La clave actual no es correcta.", "DATOS INVÁLIDOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Limpiar();
                    }
                    else if (txtNuevaClave.Text != txtNuevaClave2.Text)
                    {
                        MessageBox.Show("Las claves no concuerda.", "DATOS INVÁLIDOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Limpiar();
                    }
                    else
                    {
                        string encriptado = Sesion.Encriptar(txtNuevaClave2.Text);
                        int actualizar = new UsuarioDAL().CambiarClave(encriptado, Sesion.IdUsuario);
                        MessageBox.Show("Clave actualizada correctamente. El sistema se cerrará en 5 segundos.", "CLAVE ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        System.Threading.Thread.Sleep(4000);
                        Sesion.LimpiarSesion();
                        Application.ExitThread();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la Clave. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar_campos()
        {
            if (string.IsNullOrWhiteSpace(txtClaveAhora.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNuevaClave.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNuevaClave2.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Limpiar()
        {
            txtClaveAhora.Text = "";
            txtNuevaClave.Text = "";
            txtNuevaClave2.Text = "";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}