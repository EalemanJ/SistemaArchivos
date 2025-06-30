using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmEliminarFun : Form
    {
        public frmEliminarFun()
        {
            InitializeComponent();
        }

        private void frmEliminarFun_Load(object sender, EventArgs e)
        {
            try
            {
                txtFun.Focus();
                Formato_dgv();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar las columnas del visualziador.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable consulta = new ArchivoDAL().VerFunEliminar(txtFun.Text);
                if (consulta.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros con ese Fun.", "SIN RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFun.Text = "";
                    txtFun.Focus();
                    consulta.Clear();
                }
                else
                {
                    foreach (DataRow item in consulta.Rows)
                    {
                        dgvEliminarFun.Rows.Add(item["sa_archivo"].ToString(), item["sa_archivo_fun"].ToString(), item["sa_tipo_fun"].ToString(), item["sa_notificador_nombre"].ToString(),
                            item["sa_archivo_rut_afiliado"].ToString(), item["sa_archivo_nombre_empresa"].ToString(),
                            item["sa_archivo_direccion_empresa"].ToString(), item["sa_archivo_comuna_empresa"].ToString(), item["sa_motivo_desc"].ToString(), item["sa_estados_desc"].ToString(),
                            item["sa_archivo_direccion_dg"].ToString(), item["sa_archivo_fecha_ingreso"].ToString(), item["sa_archivo_fecha_carga"].ToString(), item["sa_archivo_fecha_notificacion"].ToString(),
                            item["sa_archivo_fecha_dg"].ToString(), item["sa_archivo_fecha_proceso"].ToString(), item["sa_archivo_fecha_rendicion"].ToString(), item["sa_archivo_fecha_rechazo"].ToString(),
                            item["sa_archivo_fecha_finiquito"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
                    }
                    txtFun.Text = "";
                    txtFun.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el Fun. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Formato_dgv()
        {
            dgvEliminarFun.ColumnCount = 21;
            dgvEliminarFun.Columns[0].Name = "Código Único";
            dgvEliminarFun.Columns[1].Name = "FUN";
            dgvEliminarFun.Columns[2].Name = "Tipo FUN";
            dgvEliminarFun.Columns[3].Name = "Notificador";
            dgvEliminarFun.Columns[4].Name = "Rut Afiliado";
            dgvEliminarFun.Columns[5].Name = "Nombre Empresa";
            dgvEliminarFun.Columns[6].Name = "Dirección Empresa";
            dgvEliminarFun.Columns[7].Name = "Comuna Empresa";
            dgvEliminarFun.Columns[8].Name = "Motivo";
            dgvEliminarFun.Columns[9].Name = "Detalle Rechazado";
            dgvEliminarFun.Columns[10].Name = "Dirección D.G.";
            dgvEliminarFun.Columns[11].Name = "Fecha Ingreso";
            dgvEliminarFun.Columns[12].Name = "Fecha Carga";
            dgvEliminarFun.Columns[13].Name = "Fecha Notificación";
            dgvEliminarFun.Columns[14].Name = "Fecha D.G.";
            dgvEliminarFun.Columns[15].Name = "Fecha Proceso";
            dgvEliminarFun.Columns[16].Name = "Fecha Rendición";
            dgvEliminarFun.Columns[17].Name = "Fecha Rechazo";
            dgvEliminarFun.Columns[18].Name = "Fecha Finiquito";
            dgvEliminarFun.Columns[19].Name = "Firma";
            dgvEliminarFun.Columns[20].Name = "Timbre";
            dgvEliminarFun.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEliminarFun.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvEliminarFun.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvEliminarFun.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvEliminarFun.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnEliminarFun_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEliminarFun.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    foreach (DataGridViewRow row in dgvEliminarFun.Rows)
                    {
                        int codigo_fun = Convert.ToInt32(row.Cells["Código Único"].Value.ToString());
                        int eliminar_fun = new ArchivoDAL().EliminarFun(codigo_fun);
                    }
                    MessageBox.Show("Fun(es) eliminado(s) correctamente.", "ELIMINACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Fun. Detalles: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtFun.Text = "";
            txtFun.Focus();
            dgvEliminarFun.Rows.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvEliminarFun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    int fila = dgvEliminarFun.CurrentRow.Index;
                    dgvEliminarFun.Rows.RemoveAt(fila);
                    txtFun.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}