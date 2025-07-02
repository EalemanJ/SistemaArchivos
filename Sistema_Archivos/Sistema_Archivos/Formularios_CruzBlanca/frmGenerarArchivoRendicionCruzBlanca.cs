using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmGenerarArchivoRendicionCruzBlanca : Form
    {
        public const string rut_empresa = "76869546";

        public frmGenerarArchivoRendicionCruzBlanca()
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
                string fechaProceso = "", fechaNotificacion = "",
                    fec_proc = "", fec_not = "";
                dgvArchivoRendicion.Rows.Clear();
                int usuario = Convert.ToInt32(cmbUsuario.SelectedValue.ToString());
                string fecha = dtpFechaRendicion.Value.Date.ToShortDateString().Replace("/", "-");
                if (cmbTipoRendicion.Text == "Habilitado")
                {
                    int Num = 1;
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().GenerarArchivoRendicion(fecha, usuario, "HAB");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        fec_proc = Convert.ToString(item["sa_archivo_Cruz_Blanca_fecha_proceso"]);
                        fec_not = Convert.ToString(item["sa_archivo_Cruz_Blanca_fecha_notificacion"]);
                        fec_proc = fec_proc.Replace("/", "-");
                        fec_not = fec_not.Replace("/", "-");

                        if (fec_proc != "")
                        {
                            fechaProceso = Convert.ToDateTime(fec_proc + " 00:00:00").ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            fechaProceso = "";
                        }
                        if (fec_not != "")
                        {
                            fechaNotificacion = Convert.ToDateTime(fec_not + " 00:00:00").ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            fechaNotificacion = "";
                        }

                        dgvArchivoRendicion.Rows.Add("CB", item["sa_archivo_Cruz_Blanca_fun"], item["codigo"], item["sa_archivo_cruz_blanca_comuna_empresa"], fechaProceso, "00",
                            fechaNotificacion, item["sa_archivo_cruz_blanca_direccion_dg"], Num, "SERVID");
                        Num++;
                    }
                }
                else if (cmbTipoRendicion.Text == "Fuera de Plazo")
                {
                    int Num = 1;
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().GenerarArchivoRendicion(fecha, usuario, "FPL");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        fec_proc = Convert.ToString(item["sa_archivo_Cruz_Blanca_fecha_proceso"]);
                        fec_not = Convert.ToString(item["sa_archivo_Cruz_Blanca_fecha_notificacion"]);
                        fec_proc = fec_proc.Replace("/", "-");
                        fec_not = fec_not.Replace("/", "-");

                        if (fec_proc != "")
                        {
                            fechaProceso = Convert.ToDateTime(fec_proc + " 00:00:00").ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            fechaProceso = "";
                        }
                        if (fec_not != "")
                        {
                            fechaNotificacion = Convert.ToDateTime(fec_not + " 00:00:00").ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            fechaNotificacion = "";
                        }

                        dgvArchivoRendicion.Rows.Add("CB", item["sa_archivo_Cruz_Blanca_fun"], item["codigo"], item["sa_archivo_cruz_blanca_comuna_empresa"], fechaProceso, "01",
                            fechaNotificacion, item["sa_archivo_cruz_blanca_direccion_dg"], Num, "SERVID");
                        Num++;
                    }
                }
                else if (cmbTipoRendicion.Text == "Rechazado")
                {
                    int Num = 1;
                    string Cod = Convert.ToString(CmbTipoRechazo.SelectedValue);
                    if (Cod == "1")
                    {
                        MessageBox.Show("Debe seleccionar un estado de rechazo válido.", "Estado Rechazo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    System.Data.DataTable consulta = new ArchivoCruzBlanca().GenerarArchivoRendicion(fecha, usuario, "REC");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        fec_proc = Convert.ToString(item["sa_archivo_Cruz_Blanca_fecha_proceso"]);
                        fec_not = Convert.ToString(item["sa_archivo_Cruz_Blanca_fecha_notificacion"]);
                        fec_proc = fec_proc.Replace("/", "-");
                        fec_not = fec_not.Replace("/", "-");

                        if (fec_proc != "")
                        {
                            fechaProceso = Convert.ToDateTime(fec_proc + " 00:00:00").ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            fechaProceso = "";
                        }
                        if (fec_not != "")
                        {
                            fechaNotificacion = Convert.ToDateTime(fec_not + " 00:00:00").ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            fechaNotificacion = "";
                        }

                        dgvArchivoRendicion.Rows.Add("CB", item["sa_archivo_Cruz_Blanca_fun"], item["codigo"], item["sa_archivo_cruz_blanca_comuna_empresa"], fechaProceso, item["codigo"],
                            fechaNotificacion, item["sa_archivo_cruz_blanca_direccion_dg"], Num, "SERVID");
                        Num++;
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
            string nombre_archivo = "ReporteRendicionCruz_Blanca" + nombre_usuario + ".xlsx";
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\" + nombre_archivo);
            worksheet.SaveAs(file.ToString());
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgvArchivoRendicion.Rows.Clear();
        }

        private void frmGenerarArchivoRendicionCruzBlanca_Load(object sender, EventArgs e)
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
            dgvArchivoRendicion.Columns[0].Name = "ISAPRE";
            dgvArchivoRendicion.Columns[1].Name = "FOLIO FUN";
            dgvArchivoRendicion.Columns[2].Name = "NÓMINA O REMESA";
            dgvArchivoRendicion.Columns[3].Name = "COMUNA";
            dgvArchivoRendicion.Columns[4].Name = "FECHA FUN"; //Fecha de Proceso.
            dgvArchivoRendicion.Columns[5].Name = "CÓDIGO NOTIFICACIÓN FUN";
            dgvArchivoRendicion.Columns[6].Name = "FECHA NOTIFICACIÓN O RECHAZO";
            dgvArchivoRendicion.Columns[7].Name = "OBSERVACIONES";
            dgvArchivoRendicion.Columns[8].Name = "NUM. ARCHIVO RENDICIÓN";
            dgvArchivoRendicion.Columns[9].Name = "ID PROVEEDOR";
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

        private void cmbTipoRendicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoRendicion.Text == "Rechazado")
                {
                    System.Data.DataTable Dt = new EstadoRechazadoCruzBlancaDAL().VerEstadosRechazado();
                    CmbTipoRechazo.DataSource = Dt;
                    CmbTipoRechazo.DisplayMember = "sa_estado_rechazado_Cruz_Blanca_desc";
                    CmbTipoRechazo.ValueMember = "sa_estado_rechazado_Cruz_Blanca";

                    LblTipoRechazo.Visible = true;
                    CmbTipoRechazo.Visible = true;
                }
                else
                {
                    LblTipoRechazo.Visible = false;
                    CmbTipoRechazo.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}