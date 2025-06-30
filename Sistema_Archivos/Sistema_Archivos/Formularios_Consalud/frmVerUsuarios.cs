using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmVerUsuarios : Form
    {
        public frmVerUsuarios()
        {
            InitializeComponent();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Código Usuario"].Value.ToString());
                bool estado = true;
                int actualizar = new UsuarioDAL().CambiarEstado(estado, codigo);
                MessageBox.Show("Estado cambido a 'Habilitado' correctamente.", "USUARIO ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cargar_datos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al habilitar el Usuario. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Código Usuario"].Value.ToString());
                bool estado = false;
                int actualizar = new UsuarioDAL().CambiarEstado(estado, codigo);
                MessageBox.Show("Estado cambido a 'Deshabilitado' correctamente.", "USUARIO ACTUALIZADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cargar_datos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Deshabilitar el Usuario. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult mensaje = MessageBox.Show("¿Está seguro en eliminar el usuario seleccionado?", "CONFIRMAR COMANDO", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (mensaje == DialogResult.Yes)
                {
                    int codigo = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Código Usuario"].Value.ToString());
                    int actualizar = new UsuarioDAL().EliminarUsuario(codigo);
                    MessageBox.Show("Usuario eliminado correctamente.", "USUARIO ELIMINADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cargar_datos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eiminar el Usuario. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void formato_dgv()
        {
            dgvUsuarios.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvUsuarios.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void cargar_datos()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = new UsuarioDAL().VerUsuarios();
            formato_dgv();
        }

        private void frmVerUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                cargar_datos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}