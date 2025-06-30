using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese el nombre de Usuario.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                }
                else if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese la clave de Usuario.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtClave.Focus();
                }
                else
                {
                    string encriptado = Sesion.Encriptar(txtClave.Text);
                    DataTable consulta = new UsuarioDAL().Login(txtNombre.Text, encriptado);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros. Ingrese nuevamente.", "SIN REGISTROS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtClave.Text = "";
                        txtNombre.Text = "";
                        txtNombre.Focus();
                    }
                    else
                    {
                        foreach (DataRow item in consulta.Rows)
                        {
                            Sesion.IdUsuario = Convert.ToInt32(item["sa_usuario"].ToString());
                            Sesion.NombreUsuario = item["sa_usuario_nombre"].ToString();
                            Sesion.ClaveUsuario = item["sa_usuario_clave"].ToString();
                            Sesion.EstadoUsuario = Convert.ToBoolean(item["sa_usuario_estado"].ToString());
                        }
                        if (Sesion.EstadoUsuario == false)
                        {
                            MessageBox.Show("Usuario esta en estado restringido. No puede iniciar sesión en el sistema.", "ACCESO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtClave.Text = "";
                            txtNombre.Text = "";
                            txtNombre.Focus();
                        }
                        else
                        {
                            frmSeleccionarSistema ss = Application.OpenForms["frmSeleccionarSistema"] as frmSeleccionarSistema;
                            if (ss != null)
                            {
                                ss.Focus();
                            }
                            else
                            {
                                frmSeleccionarSistema ss2 = new frmSeleccionarSistema();
                                ss2.Show();
                            }
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar al sistema. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}