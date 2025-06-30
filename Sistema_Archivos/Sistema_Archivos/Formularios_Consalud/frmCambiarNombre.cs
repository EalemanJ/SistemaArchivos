using System;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmCambiarNombre : Form
    {
        public static int codigo_noti = 0;
        public static string nombre_noti = "";

        public frmCambiarNombre(int codigo, string nombre)
        {
            InitializeComponent();
            codigo_noti = codigo;
            nombre_noti = nombre;
        }

        private void frmCambiarNombre_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = codigo_noti.ToString();
            txtNombre.Text = nombre_noti;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNuevoNombre.Text))
                {
                    MessageBox.Show("Ingrese el nuevo nombre del notificador.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNuevoNombre.Text = "";
                    txtNuevoNombre.Focus();
                }
                else
                {
                    int actualizar = new NotificadorDAL().ActualizarNombre(txtNuevoNombre.Text, codigo_noti);
                    MessageBox.Show("Notificador actualizado correctamente.", "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    frmMantenedorPrincipal algo = new frmMantenedorPrincipal();
                    algo.Cargar_datos_dgv_modificar();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el nombre. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}