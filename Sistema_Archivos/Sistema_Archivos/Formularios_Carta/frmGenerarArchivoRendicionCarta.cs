using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmGenerarArchivoRendicionCarta : Form
    {
        public const string rut_empresa = "76869546";

        public frmGenerarArchivoRendicionCarta()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgvArchivoRendicion.Rows.Clear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvArchivoRendicion.Rows.Clear();
                int usuario = Convert.ToInt32(cmbUsuario.SelectedValue.ToString());
                string fecha = dtpFechaRendicion.Value.Date.ToShortDateString().Replace("/", "-");
                if (cmbTipoRendicion.Text == "Habilitado")
                {
                    System.Data.DataTable consulta = new ArchivoCartaDAL().GenerarArchivoRendicion(fecha, usuario, "HAB");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        dgvArchivoRendicion.Rows.Add("CS", item["sa_archivo_carta_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_carta_fecha_notificacion"].ToString(),
                            "", item["sa_archivo_carta_fecha_rendicion"].ToString(), rut_empresa,
                            item["sa_archivo_carta_direccion_dg"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
                    }
                }
                else if (cmbTipoRendicion.Text == "Fuera de Plazo")
                {
                    System.Data.DataTable consulta = new ArchivoCartaDAL().GenerarArchivoRendicion(fecha, usuario, "FPL");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        dgvArchivoRendicion.Rows.Add("CS", item["sa_archivo_carta_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_carta_fecha_notificacion"].ToString(),
                            "", item["sa_archivo_carta_fecha_rendicion"].ToString(), rut_empresa,
                            item["sa_archivo_carta_direccion_dg"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
                    }
                }
                else if (cmbTipoRendicion.Text == "Rechazado")
                {
                    System.Data.DataTable consulta = new ArchivoCartaDAL().GenerarArchivoRendicion(fecha, usuario, "REC");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        if (item["sa_archivo_carta_fecha_notificacion"].ToString() != "")
                        {
                            dgvArchivoRendicion.Rows.Add("CS", item["sa_archivo_carta_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_carta_fecha_notificacion"].ToString(),
                                item["sa_archivo_carta_fecha_finiquito"].ToString(), item["sa_archivo_carta_fecha_rendicion"].ToString(), rut_empresa,
                                item["sa_archivo_carta_direccion_dg"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else if (item["sa_archivo_carta_fecha_rechazo"].ToString() != "")
                        {
                            dgvArchivoRendicion.Rows.Add("CS", item["sa_archivo_carta_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_carta_fecha_rechazo"].ToString(),
                                item["sa_archivo_carta_fecha_finiquito"].ToString(), item["sa_archivo_carta_fecha_rendicion"].ToString(), rut_empresa,
                                item["sa_archivo_carta_direccion_dg"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por fechas. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArchivoRendicion.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ExportarExcel(dgvArchivoRendicion);
                    MessageBox.Show("Reporte creado correctamente.", "REPORTE OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportarExcel(DataGridView grd)
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
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\ReporteRendicionCarta.xlsx");
            worksheet.SaveAs(file.ToString());
        }

        private void frmGenerarArchivoRendicionCarta_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUsuario.DataSource = new UsuarioDAL().VerUsuarios();
                cmbUsuario.DisplayMember = "Nombre Usuario";
                cmbUsuario.ValueMember = "Código Usuario";
                Formato_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar formato al visualizador. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Formato_dgv()
        {
            dgvArchivoRendicion.ColumnCount = 10;
            dgvArchivoRendicion.Columns[0].Name = "ISA";
            dgvArchivoRendicion.Columns[1].Name = "Num FUN";
            dgvArchivoRendicion.Columns[2].Name = "Código";
            dgvArchivoRendicion.Columns[3].Name = "Fecha Notificación o Rechazo Fun";
            dgvArchivoRendicion.Columns[4].Name = "Fecha Adicional";//fecha finiquito
            dgvArchivoRendicion.Columns[5].Name = "Fecha Rendición";
            dgvArchivoRendicion.Columns[6].Name = "ID";
            dgvArchivoRendicion.Columns[7].Name = "Dirección D.G.";
            dgvArchivoRendicion.Columns[8].Name = "Firma";
            dgvArchivoRendicion.Columns[9].Name = "Timbre";
            dgvArchivoRendicion.Rows.Clear();
            dgvArchivoRendicion.RowsDefaultCellStyle.BackColor = Color.White;
            dgvArchivoRendicion.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvArchivoRendicion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvArchivoRendicion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvArchivoRendicion.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}