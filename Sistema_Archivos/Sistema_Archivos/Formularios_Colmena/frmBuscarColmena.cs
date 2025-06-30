using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmBuscarColmena : Form
    {
        public frmBuscarColmena()
        {
            InitializeComponent();
        }

        public void Formato_dgv()
        {
            dgvBuscarFun.RowsDefaultCellStyle.BackColor = Color.White;
            dgvBuscarFun.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvBuscarFun.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvBuscarFun.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvBuscarFun.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvBuscarFun.DataSource = null;
                lblCantidad.Text = "0";
                if (string.IsNullOrWhiteSpace(txtFun.Text))
                {
                    MessageBox.Show("Ingrese el Fun a buscar.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFun.Focus();
                }
                else
                {
                    DataTable consulta = new ArchivoColmenaDAL().ConsultarFun(txtFun.Text);
                    dgvBuscarFun.DataSource = consulta;
                    Formato_dgv();
                    lblCantidad.Text = dgvBuscarFun.Rows.Count.ToString("N0");
                    txtFun.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el Fun. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerTodo_Click(object sender, EventArgs e)
        {
            try
            {
                dgvBuscarFun.DataSource = null;
                lblCantidad.Text = "0";
                DataTable consulta = new ArchivoColmenaDAL().VerTodosFun();
                dgvBuscarFun.DataSource = consulta;
                Formato_dgv();
                lblCantidad.Text = dgvBuscarFun.Rows.Count.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el Fun. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgvBuscarFun.DataSource = null;
            txtFun.Focus();
            txtFun.Text = "";
            lblCantidad.Text = "0";
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}