using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmEliminarFunCarta : Form
    {
        public frmEliminarFunCarta()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Limpiar()
        {
            txtFun.Text = "";
            txtFun.Focus();
            dgvEliminarFun.Rows.Clear();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable consulta = new ArchivoCartaDAL().VerFunEliminar(txtFun.Text);
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
                        dgvEliminarFun.Rows.Add(item["sa_archivo_carta"].ToString(), item["sa_archivo_carta_fun"].ToString(), item["sa_notificador_nombre"].ToString(),
                            item["sa_archivo_carta_rut_afiliado"].ToString(), item["sa_archivo_carta_nombre_empresa"].ToString(),
                            item["sa_archivo_carta_direccion_empresa"].ToString(), item["sa_archivo_carta_comuna_empresa"].ToString(), item["sa_motivo_desc"].ToString(), item["sa_estados_desc"].ToString(),
                            item["sa_archivo_carta_direccion_dg"].ToString(), item["sa_archivo_carta_fecha_ingreso"].ToString(), item["sa_archivo_carta_fecha_carga"].ToString(),
                            item["sa_archivo_carta_fecha_notificacion"].ToString(), item["sa_archivo_carta_fecha_dg"].ToString(), item["sa_archivo_carta_fecha_proceso"].ToString(),
                            item["sa_archivo_carta_fecha_rendicion"].ToString(), item["sa_archivo_carta_fecha_rechazo"].ToString(),
                            item["sa_archivo_carta_fecha_finiquito"].ToString(), item["sa_archivo_carta_fecha_descarga"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
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

        private void BtnEliminarFun_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEliminarFun.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para eliminar.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    foreach (DataGridViewRow row in dgvEliminarFun.Rows)
                    {
                        int codigo_fun = Convert.ToInt32(row.Cells["Código Único"].Value.ToString());
                        int eliminar_fun = new ArchivoCartaDAL().EliminarFun(codigo_fun);
                    }
                    MessageBox.Show("Fun(es) eliminado(s) correctamente.", "ELIMINACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Fun. Detalles: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Formato_dgv()
        {
            dgvEliminarFun.ColumnCount = 20;
            dgvEliminarFun.Columns[0].Name = "Código Único";
            dgvEliminarFun.Columns[1].Name = "FUN";
            dgvEliminarFun.Columns[2].Name = "Notificador";
            dgvEliminarFun.Columns[3].Name = "Rut Afiliado";
            dgvEliminarFun.Columns[4].Name = "Nombre Empresa";
            dgvEliminarFun.Columns[5].Name = "Dirección Empresa";
            dgvEliminarFun.Columns[6].Name = "Comuna Empresa";
            dgvEliminarFun.Columns[7].Name = "Motivo";
            dgvEliminarFun.Columns[8].Name = "Detalle Rechazado";
            dgvEliminarFun.Columns[9].Name = "Dirección D.G.";
            dgvEliminarFun.Columns[10].Name = "Fecha Ingreso";
            dgvEliminarFun.Columns[11].Name = "Fecha Carga";
            dgvEliminarFun.Columns[12].Name = "Fecha Notificación";
            dgvEliminarFun.Columns[13].Name = "Fecha D.G.";
            dgvEliminarFun.Columns[14].Name = "Fecha Proceso";
            dgvEliminarFun.Columns[15].Name = "Fecha Rendición";
            dgvEliminarFun.Columns[16].Name = "Fecha Rechazo";
            dgvEliminarFun.Columns[17].Name = "Fecha Finiquito";
            dgvEliminarFun.Columns[18].Name = "Firma";
            dgvEliminarFun.Columns[19].Name = "Timbre";
            dgvEliminarFun.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEliminarFun.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvEliminarFun.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvEliminarFun.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvEliminarFun.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DgvEliminarFun_KeyDown(object sender, KeyEventArgs e)
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
                    MessageBox.Show("Error al eliminar la fila seleccionada. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmEliminarFunCarta_Load(object sender, EventArgs e)
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
    }
}