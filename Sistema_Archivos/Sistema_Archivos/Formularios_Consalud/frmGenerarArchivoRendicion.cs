using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmGenerarArchivoRendicion : Form
    {
        public const string rut_empresa = "76869546";

        public frmGenerarArchivoRendicion()
        {
            InitializeComponent();
        }

        private void BtnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResultado.Rows.Clear();
                int usuario = Convert.ToInt32(cmbUsuario.SelectedValue.ToString());
                string fecha = dtpFecha.Value.Date.ToShortDateString().Replace("/", "-");
                if (cmbTipoRendicion.Text == "Habilitado")
                {
                    System.Data.DataTable consulta = new ArchivoDAL().GenerarArchivoRendicion(fecha, usuario, "HAB");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        if (item["sa_archivo_fecha_notificacion"].ToString() != "")
                        {
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_fecha_notificacion"].ToString(),
                                "", item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else
                        {
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), "",
                                "", item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                    }
                }
                else if (cmbTipoRendicion.Text == "Fuera de Plazo")
                {
                    System.Data.DataTable consulta = new ArchivoDAL().GenerarArchivoRendicion(fecha, usuario, "FPL");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        if (item["sa_archivo_fecha_notificacion"].ToString() != "")
                        {
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_fecha_notificacion"].ToString(),
                                "", item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else
                        {
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), "",
                                "", item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                    }
                }
                else if (cmbTipoRendicion.Text == "Rechazado")
                {
                    System.Data.DataTable consulta = new ArchivoDAL().GenerarArchivoRendicion(fecha, usuario, "REC");
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        if (item["sa_archivo_fecha_notificacion"].ToString() == "")
                        {
                            //fecha de notificacion en blanco, se agrega la de rechazo
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_fecha_rechazo"].ToString(),
                                item["sa_archivo_fecha_finiquito"].ToString(), item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else if (item["sa_archivo_fecha_rechazo"].ToString() == "")
                        {
                            //fecha de rechazo en blanco, se agrega la de notificacion
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_fecha_notificacion"].ToString(),
                                item["sa_archivo_fecha_finiquito"].ToString(), item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else if (item["sa_archivo_fecha_notificacion"].ToString() != "")
                        {
                            //fecha de notificacion distinto a blanco
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_fecha_notificacion"].ToString(),
                                item["sa_archivo_fecha_finiquito"].ToString(), item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else if (item["sa_archivo_fecha_rechazo"].ToString() != "")
                        {
                            //fecha de rechazo distinto a blanco
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), item["sa_archivo_fecha_rechazo"].ToString(),
                                item["sa_archivo_fecha_finiquito"].ToString(), item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
                        }
                        else
                        {
                            dgvResultado.Rows.Add("CS", item["sa_archivo_fun"].ToString(), item["codigo"].ToString(), "",
                                item["sa_archivo_fecha_finiquito"].ToString(), item["sa_archivo_fecha_rendicion"].ToString(), rut_empresa, item["sa_archivo_direccion_dg"].ToString(),
                                item["Firma"].ToString(), item["Timbre"].ToString());
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
                if (dgvResultado.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ExportarExcel(dgvResultado, cmbUsuario.Text.ToUpper());
                    MessageBox.Show("Reporte creado correctamente.", "REPORTE OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportarExcel(DataGridView grd, string nombreUsuario)
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
            string nombre_archivo = "ReporteRendicion" + "-" + nombreUsuario + ".xlsx";
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\" + nombre_archivo);
            worksheet.SaveAs(file.ToString());
        }

        private void frmGenerarArchivoRendicion_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUsuario.DataSource = new UsuarioDAL().VerUsuarios();
                cmbUsuario.DisplayMember = "Nombre Usuario";
                cmbUsuario.ValueMember = "Código Usuario";
                formato_dgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar formato al visualizador o cargar los datos de los usuarios. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void formato_dgv()
        {
            dgvResultado.ColumnCount = 10;
            dgvResultado.Columns[0].Name = "ISA";
            dgvResultado.Columns[1].Name = "Num FUN";
            dgvResultado.Columns[2].Name = "Código";
            dgvResultado.Columns[3].Name = "Fecha Notificación o Rechazo Fun";
            dgvResultado.Columns[4].Name = "Fecha Adicional"; // fecha de finiquito
            dgvResultado.Columns[5].Name = "Fecha Rendición";
            dgvResultado.Columns[6].Name = "ID";
            dgvResultado.Columns[7].Name = "Dirección D.G.";
            dgvResultado.Columns[8].Name = "Firma";
            dgvResultado.Columns[9].Name = "Timbre";
            dgvResultado.Rows.Clear();
            dgvResultado.RowsDefaultCellStyle.BackColor = Color.White;
            dgvResultado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvResultado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvResultado.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvResultado.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dgvResultado.Rows.Clear();
        }
    }
}