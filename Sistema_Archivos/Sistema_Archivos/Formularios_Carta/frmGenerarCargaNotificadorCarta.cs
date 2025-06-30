using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmGenerarCargaNotificadorCarta : Form
    {
        public frmGenerarCargaNotificadorCarta()
        {
            InitializeComponent();
        }

        private void frmGenerarCargaNotificadorCarta_Load(object sender, EventArgs e)
        {
            try
            {
                Info_dgv();
                cmbNotificador.DataSource = new NotificadorDAL().VerNotificadores();
                cmbNotificador.DisplayMember = "sa_notificador_nombre";
                cmbNotificador.ValueMember = "sa_notificador";
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los notificadores.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Info_dgv()
        {
            dgvCarga.ColumnCount = 2;
            dgvCarga.Columns[0].Name = "Código correlativo";
            dgvCarga.Columns[1].Name = "FUN";
            dgvCarga.Rows.Clear();
        }

        public void Formato_dgv()
        {
            dgvCarga.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCarga.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvCarga.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvCarga.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvCarga.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int notificador = Convert.ToInt32(cmbNotificador.SelectedValue.ToString());
                string fecha = dtpFecha.Value.Date.ToShortDateString().Replace("/", "-");
                System.Data.DataTable consulta = new ArchivoCartaDAL().GenerarArchivoCarga(notificador, fecha);
                if (consulta.Rows.Count == 0)
                {
                    MessageBox.Show("No hay carga del día y notificador seleccionado.", "SIN CARGA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int cuenta = 0;
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        cuenta += 1;
                        dgvCarga.Rows.Add(cuenta, item["FUN"].ToString());
                    }
                    Formato_dgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarga.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "VISUALIZADOR VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string fecha = dtpFecha.Value.Date.ToShortDateString().Replace("/", "-");
                    ExportarExcel(dgvCarga, "cargaNotificador_" + cmbNotificador.Text + "_" + fecha + ".xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar los datos a una planilla Excel. Detalles: " + ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportarExcel(DataGridView grd, string nombre_archivo)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            worksheet.Rows.Range["A1", "Z40000"].NumberFormatLocal = "@";
            int ColumnIndex = 0;
            foreach (DataGridViewColumn col in grd.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }
            int rowIndex = 0;
            foreach (DataGridViewRow row in grd.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in grd.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value.ToString();
                }
            }
            excel.Visible = true;
            worksheet.Activate();
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\" + nombre_archivo + "");
            worksheet.SaveAs(file.ToString());
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgvCarga.Rows.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}