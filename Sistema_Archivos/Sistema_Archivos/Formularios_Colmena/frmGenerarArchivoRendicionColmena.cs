using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmGenerarArchivoRendicionColmena : Form
    {
        public const string rut_empresa = "76869546";

        public frmGenerarArchivoRendicionColmena()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
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
                    ExportarExcel(dgvArchivoRendicion, cmbUsuario.Text.ToUpper());
                    MessageBox.Show("Reporte creado correctamente.", "REPORTE OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string fechaProceso = "", fechaNotificacion = "", fechaRendicion = "";
                dgvArchivoRendicion.Rows.Clear();
                int usuario = Convert.ToInt32(cmbUsuario.SelectedValue.ToString());
                string fecha = dtpFechaRendicion.Value.Date.ToShortDateString().Replace("/", "-");
                if (cmbTipoRendicion.Text == "Habilitado")
                {
                    System.Data.DataTable consulta = new ArchivoColmenaDAL().GenerarArchivoRendicion(fecha, usuario, "HAB");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        string fec_proc = item["sa_archivo_colmena_fecha_proceso"].ToString();
                        string fec_not = item["sa_archivo_colmena_fecha_notificacion"].ToString();
                        string fec_ren = item["sa_archivo_colmena_fecha_rendicion"].ToString();
                        string fec_finiquito = item["sa_archivo_colmena_fecha_finiquito"].ToString();
                        if (fec_proc != "")
                        {
                            fechaProceso = DateTime.ParseExact(fec_proc, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaProceso = "";
                        }
                        if (fec_not != "")
                        {
                            fechaNotificacion = DateTime.ParseExact(fec_not, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaNotificacion = "";
                        }
                        if (fec_ren != "")
                        {
                            fechaRendicion = DateTime.ParseExact(fec_ren, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaRendicion = "";
                        }
                        dgvArchivoRendicion.Rows.Add("CL", item["sa_archivo_colmena_fun"].ToString(), fechaProceso, "00",
                            fechaNotificacion, "", fechaRendicion, rut_empresa, "");
                    }
                }
                else if (cmbTipoRendicion.Text == "Fuera de Plazo")
                {
                    System.Data.DataTable consulta = new ArchivoColmenaDAL().GenerarArchivoRendicion(fecha, usuario, "FPL");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        string fec_proc = item["sa_archivo_colmena_fecha_proceso"].ToString();
                        string fec_not = item["sa_archivo_colmena_fecha_notificacion"].ToString();
                        string fec_ren = item["sa_archivo_colmena_fecha_rendicion"].ToString();
                        string fec_finiquito = item["sa_archivo_colmena_fecha_finiquito"].ToString();
                        if (fec_proc != "")
                        {
                            fechaProceso = DateTime.ParseExact(fec_proc, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaProceso = "";
                        }
                        if (fec_not != "")
                        {
                            fechaNotificacion = DateTime.ParseExact(fec_not, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaNotificacion = "";
                        }
                        if (fec_ren != "")
                        {
                            fechaRendicion = DateTime.ParseExact(fec_ren, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaRendicion = "";
                        }
                        dgvArchivoRendicion.Rows.Add("CL", item["sa_archivo_colmena_fun"].ToString(), fechaProceso, "01",
                            fechaNotificacion, "", fechaRendicion, rut_empresa, "");
                    }
                }
                else if (cmbTipoRendicion.Text == "Rechazado")
                {
                    System.Data.DataTable consulta = new ArchivoColmenaDAL().GenerarArchivoRendicion(fecha, usuario, "REC");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        string fec_proc = item["sa_archivo_colmena_fecha_proceso"].ToString();
                        string fec_not = item["sa_archivo_colmena_fecha_notificacion"].ToString();
                        string fec_ren = item["sa_archivo_colmena_fecha_rendicion"].ToString();
                        string fec_finiquito = item["sa_archivo_colmena_fecha_finiquito"].ToString();
                        if (fec_proc != "")
                        {
                            fechaProceso = DateTime.ParseExact(fec_proc, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaProceso = "";
                        }
                        if (fec_not != "")
                        {
                            fechaNotificacion = DateTime.ParseExact(fec_not, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaNotificacion = "";
                        }
                        if (fec_ren != "")
                        {
                            fechaRendicion = DateTime.ParseExact(fec_ren, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("MM-dd-yyyy");
                        }
                        else
                        {
                            fechaRendicion = "";
                        }
                        dgvArchivoRendicion.Rows.Add("CL", item["sa_archivo_colmena_fun"].ToString(), fechaProceso, item["codigo"].ToString(),
                            fechaNotificacion, fec_finiquito, fechaRendicion, rut_empresa, "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por fechas. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportarExcel(DataGridView grd, string nombre_usuario)
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
            string nombre_archivo = "ReporteRendicionColmena" + nombre_usuario + ".xlsx";
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\" + nombre_archivo);
            worksheet.SaveAs(file.ToString());
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgvArchivoRendicion.Rows.Clear();
        }

        private void frmGenerarArchivoRendicionColmena_Load(object sender, EventArgs e)
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
            dgvArchivoRendicion.ColumnCount = 9;
            dgvArchivoRendicion.Columns[0].Name = "ISA";
            dgvArchivoRendicion.Columns[1].Name = "Num FUN";
            dgvArchivoRendicion.Columns[2].Name = "Fecha FUN"; //Fecha de Proceso.
            dgvArchivoRendicion.Columns[3].Name = "Código";
            dgvArchivoRendicion.Columns[4].Name = "Fecha Notificación o Rechazo Fun";
            dgvArchivoRendicion.Columns[5].Name = "Fecha Adicional"; //fecha finiquito
            dgvArchivoRendicion.Columns[6].Name = "Fecha Rendición";
            dgvArchivoRendicion.Columns[7].Name = "ID";
            dgvArchivoRendicion.Columns[8].Name = "Observación";
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