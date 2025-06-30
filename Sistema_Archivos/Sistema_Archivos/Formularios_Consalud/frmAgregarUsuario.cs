using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmAgregarUsuario : Form
    {
        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese el nombre del nuevo usuario.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                }
                else
                {
                    DataTable consulta = new UsuarioDAL().VerDisponible(txtNombre.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        txtClave.Enabled = true;
                        cmbEstado.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ya hay un usuario con ese nombre. Por favor ingrese otro.", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Limpiar();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al verificar el nombre del usuario.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Ingrese el nombre del nuevo usuario.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    MessageBox.Show("Ingrese la clave del nuevo usuario.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (cmbEstado.Text == "Habilitado")
                    {
                        bool estado = true;
                        string encriptado = Sesion.Encriptar(txtClave.Text);
                        int ingresar = new UsuarioDAL().AgregarUsuario(txtNombre.Text, encriptado, estado);
                        MessageBox.Show("Usuario creado correctamente.", "INGRESO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar();
                    }
                    else if (cmbEstado.Text == "Deshabilitado")
                    {
                        bool estado = false;
                        string encriptado = Sesion.Encriptar(txtClave.Text);
                        int ingresar = new UsuarioDAL().AgregarUsuario(txtNombre.Text, encriptado, estado);
                        MessageBox.Show("Usuario creado correctamente.", "INGRESO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Por favor selecciona un Estado para el Usuario.", "SIN ESTADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el nuevo usuario. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtClave.Text = "";
            txtClave.Enabled = false;
            txtNombre.Text = "";
            cmbEstado.Enabled = false;
            txtNombre.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}