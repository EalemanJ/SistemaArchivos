using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmMantenedorPrincipalCruzBlanca : Form
    {
        public DateTimePicker dtpFecha = new DateTimePicker();
        public DateTimePicker dtpFueraPlazo = new DateTimePicker();
        public DateTimePicker dtpRechazado = new DateTimePicker();
        public static int ubicacionDH = 0, ubicacionDFP = 0, ubicacionR = 0;

        public static bool estado_carga = false;

        public frmMantenedorPrincipalCruzBlanca()
        {
            InitializeComponent();
        }

        private void frmMantenedorPrincipalCruzBlanca_Load(object sender, EventArgs e)
        {
            try
            {
                // cargar notificadores
                cmbNotificador.DataSource = new NotificadorDAL().VerNotificadores();
                cmbNotificador.DisplayMember = "sa_notificador_nombre";
                cmbNotificador.ValueMember = "sa_notificador";

                //carga notificadores ***carga automatica***
                cmbNotificadorCargaAutomatica.DataSource = new NotificadorDAL().VerNotificadores();
                cmbNotificadorCargaAutomatica.DisplayMember = "sa_notificador_nombre";
                cmbNotificadorCargaAutomatica.ValueMember = "sa_notificador";

                //descargar rechazados
                cmbDescargarRechazados.DataSource = new EstadoRechazadoCruzBlancaDAL().VerEstadosRechazado();
                cmbDescargarRechazados.DisplayMember = "sa_estado_rechazado_Cruz_Blanca_desc";
                cmbDescargarRechazados.ValueMember = "sa_estado_rechazado_Cruz_Blanca";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TcPanelPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcPanelPrincipal.SelectedTab.Name == "tpCargarNotificador")
            {
                txtFUN.Focus();
                frmMantenedorPrincipalCruzBlanca mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] as frmMantenedorPrincipalCruzBlanca;
                mp.AcceptButton = btnBuscarFUN;
            }
            else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargarNotificador")
            {
                txtFunDescargar.Focus();
                frmMantenedorPrincipalCruzBlanca mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] as frmMantenedorPrincipalCruzBlanca;
                mp.AcceptButton = btnBuscarDescargar;
            }
            else if (tcPanelPrincipal.SelectedTab.Name == "tpCargaAutomatica")
            {
                txtFunCargaAutomatica.Focus();
                frmMantenedorPrincipalCruzBlanca mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] as frmMantenedorPrincipalCruzBlanca;
                mp.AcceptButton = btnAgregarCargaAutomatica;
                Formato_dgv_carga_automatica();
            }
            else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargaHAB")
            {
                txtFunDescargaAutomatica.Focus();
                frmMantenedorPrincipalCruzBlanca mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] as frmMantenedorPrincipalCruzBlanca;
                mp.AcceptButton = btnBuscarDescargaAutomatica;
                Formato_dgv_descarga_habilitados();
            }
            else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargaHFP")
            {
                txtFunDescargarFueraPlazo.Focus();
                frmMantenedorPrincipalCruzBlanca mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] as frmMantenedorPrincipalCruzBlanca;
                mp.AcceptButton = btnVerificarDescargarFueraPlazo;
                Formato_dgv_descarga_fuera_plazo();
            }
            else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargarRechazados")
            {
                txtFunDescargarRechazados.Focus();
                frmMantenedorPrincipalCruzBlanca mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCruzBlanca"] as frmMantenedorPrincipalCruzBlanca;
                mp.AcceptButton = btnVerificarDescargarRechazados;
                Formato_dgv_descargar_rechazados();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnLimpiarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_todo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al limpiar el formulario.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar_todo()
        {
            txtDireccionEmpresa.Text = "";
            txtFUN.Text = "";
            txtNombreEmpresa.Text = "";
            txtRutAfiliado.Text = "";
            txtTipoFun.Text = "";
            btnAsignar.Enabled = false;
            cmbNotificador.Enabled = false;

            //funes pendientes
            dgvFunesPendientes.DataSource = null;

            //descargar
            txtFunDescargar.ReadOnly = false;
            txtComunaDescargar.Text = "";
            txtDireccionDGDescargar.Text = "";
            txtDireccionEmpresaDescargar.Text = "";
            txtFechaCargaDescargar.Text = "";
            txtFechaDGDescargar.Text = "";
            txtFechaFiniquitoDescargar.Text = "";
            txtFechaIngresoDescargar.Text = "";
            txtFechaNotificacionDescargar.Text = "";
            txtFechaRechazoDescargar.Text = "";
            txtNombreEmpresaDescargar.Text = "";
            txtNotificadorDescargar.Text = "";
            txtRutAfiliadoDescargar.Text = "";
            txtFechaProcesoDescargar.Text = "";
            txtFechaRendicionDescargar.Text = "";
            txtTipoFunDescargar.Text = "";
            txtFunDescargar.Text = "";
            cmbObervacionDescargar.Enabled = false;
            cmbMotivoDescargar.Enabled = false;

            //descarga de habilitados automáticamente
            txtFunDescargaAutomatica.Text = "";
            dgvDescargaAutomatica.Rows.Clear();

            //carga automatica
            dgvCargaAutomatica.Rows.Clear();
            cmbNotificadorCargaAutomatica.Enabled = true;
            txtFunCargaAutomatica.Text = "";
            txtFunCargaAutomatica.Focus();

            //descarga fuera plazo
            dgvDescargarFueraPlazo.Rows.Clear();
            txtFunDescargarFueraPlazo.Text = "";
            txtFunDescargarFueraPlazo.Focus();

            //descargar rechazados
            txtFunDescargarRechazados.Text = "";
            dgvDescargarRechazados.Rows.Clear();
            estado_carga = false;
            //descargar notificador
            cmbMotivoDescargar.DataSource = null;
            cmbObervacionDescargar.DataSource = null;
            ubicacionDFP = 0;
            ubicacionDH = 0;
            ubicacionR = 0;
        }

        private void BtnBuscarFUN_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFUN.Text))
                {
                    MessageBox.Show("Ingrese el número de FUN.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFUN.Focus();
                }
                else
                {
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().BuscarPorFUN(txtFUN.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se ha encontrado el FUN.", "NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFUN.Text = "";
                        txtFUN.Focus();
                    }
                    else
                    {
                        foreach (System.Data.DataRow item in consulta.Rows)
                        {
                            txtTipoFun.Text = item["sa_archivo_Cruz_Blanca_tipo_fun"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString();
                            txtNombreEmpresa.Text = item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString();
                            txtDireccionEmpresa.Text = item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString();
                            btnAsignar.Enabled = true;
                            cmbNotificador.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error al buscar el FUN. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo_notificador = Convert.ToInt32(cmbNotificador.SelectedValue.ToString());
                string fecha_carga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                int actualizar = new ArchivoCruzBlanca().ActualizarNotificador(codigo_notificador, fecha_carga, txtFUN.Text);
                MessageBox.Show("Documento asignado correctamente.", "ASIGNACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFUN.Text = "";
                txtDireccionEmpresa.Text = "";
                txtNombreEmpresa.Text = "";
                txtRutAfiliado.Text = "";
                txtTipoFun.Text = "";
                btnAsignar.Enabled = false;
                cmbNotificador.Enabled = false;
                txtFUN.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al asignar el documento al notificador seleccionado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscarDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFunDescargar.Text))
                {
                    MessageBox.Show("Ingrese el fun.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFunDescargar.Focus();
                }
                else
                {
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().BuscarFUNNotificador(txtFunDescargar.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No existe el FUN ingresado.", "SIN REGISTROS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFunDescargar.Text = "";
                        txtFunDescargar.Focus();
                    }
                    else
                    {
                        foreach (System.Data.DataRow item in consulta.Rows)
                        {
                            txtFunDescargar.Text = item["sa_archivo_Cruz_Blanca_fun"].ToString();
                            txtFunDescargar.ReadOnly = true;
                            txtTipoFunDescargar.Text = item["sa_archivo_Cruz_Blanca_tipo_fun"].ToString();
                            txtNombreEmpresaDescargar.Text = item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString();
                            txtComunaDescargar.Text = item["sa_archivo_Cruz_Blanca_comuna_empresa"].ToString();
                            txtNotificadorDescargar.Text = item["sa_notificador_nombre"].ToString();
                            txtDireccionDGDescargar.Text = item["sa_archivo_Cruz_Blanca_direccion_dg"].ToString();
                            txtFechaIngresoDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_ingreso"].ToString();
                            txtFechaCargaDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_carga"].ToString();
                            txtFechaNotificacionDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_notificacion"].ToString();
                            txtFechaDGDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_dg"].ToString();
                            txtRutAfiliadoDescargar.Text = item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString();
                            txtDireccionEmpresaDescargar.Text = item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString();
                            txtFechaProcesoDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_proceso"].ToString();
                            txtFechaRechazoDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_rechazo"].ToString();
                            txtFechaFiniquitoDescargar.Text = item["sa_archivo_Cruz_Blanca_fecha_finiquito"].ToString();
                            cmbMotivoDescargar.Enabled = true;
                            txtNombreEmpresaDescargar.ReadOnly = false;
                            txtDireccionEmpresaDescargar.ReadOnly = false;
                            txtComunaDescargar.ReadOnly = false;
                            txtDireccionDGDescargar.ReadOnly = false;
                            txtFechaCargaDescargar.ReadOnly = false;
                            txtFechaDGDescargar.ReadOnly = false;
                            txtFechaFiniquitoDescargar.ReadOnly = false;
                            txtFechaIngresoDescargar.ReadOnly = false;
                            txtFechaNotificacionDescargar.ReadOnly = false;
                            txtFechaProcesoDescargar.ReadOnly = false;
                            txtFechaRechazoDescargar.ReadOnly = false;
                            txtFechaRendicionDescargar.Text = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                            estado_carga = true;
                            //cargar motivos
                            cmbMotivoDescargar.DataSource = new MotivoDAL().CargarListaSeleccionadoCruzBlanca(txtFunDescargar.Text);
                            cmbMotivoDescargar.DisplayMember = "sa_motivo_desc";
                            cmbMotivoDescargar.ValueMember = "sa_motivo";
                            //cargar estados de error
                            cmbObervacionDescargar.DataSource = new EstadoRechazadoCruzBlancaDAL().CargarListaSeleccionadoRechazado(txtFunDescargar.Text);
                            cmbObervacionDescargar.DisplayMember = "sa_estado_rechazado_Cruz_Blanca_desc";
                            cmbObervacionDescargar.ValueMember = "sa_estado_rechazado_Cruz_Blanca";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar FUN. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                if (cmbMotivoDescargar.Text == "Habilitado")
                {
                    int estado_rechazo_defecto = 1;
                    int motivo = Convert.ToInt32(cmbMotivoDescargar.SelectedValue.ToString());
                    int actualizar = new ArchivoCruzBlanca().ActualizarConHabilitado(txtNombreEmpresaDescargar.Text, txtComunaDescargar.Text, txtDireccionEmpresaDescargar.Text,
                        motivo, estado_rechazo_defecto, txtFechaRendicionDescargar.Text.Replace("/", "-"), fecha_descarga, txtFunDescargar.Text);
                    if (actualizar >= 1)
                    {
                        MessageBox.Show("Datos guardados correctamente.", "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_todo();
                    }
                }
                else if (cmbMotivoDescargar.Text == "Habilitado F.P.")
                {
                    int estado_rechazo_defecto = 1;
                    int motivo = Convert.ToInt32(cmbMotivoDescargar.SelectedValue.ToString());
                    int actualizar = new ArchivoCruzBlanca().ActualizarConHabilitado(txtNombreEmpresaDescargar.Text, txtComunaDescargar.Text, txtDireccionEmpresaDescargar.Text,
                        motivo, estado_rechazo_defecto, txtFechaRendicionDescargar.Text.Replace("/", "-"), fecha_descarga, txtFunDescargar.Text);
                    if (actualizar >= 1)
                    {
                        MessageBox.Show("Datos guardados correctamente.", "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_todo();
                    }
                }
                else if (cmbMotivoDescargar.Text == "Rechazado")
                {
                    int motivo = Convert.ToInt32(cmbMotivoDescargar.SelectedValue.ToString());
                    int estado_rechazo = Convert.ToInt32(cmbObervacionDescargar.SelectedValue.ToString());
                    int actualizar = new ArchivoCruzBlanca().ActualizarSinHabilitado(txtNombreEmpresaDescargar.Text, txtComunaDescargar.Text, txtDireccionEmpresaDescargar.Text,
                        motivo, estado_rechazo, txtFechaRendicionDescargar.Text.Replace("/", "-"), txtFechaRechazoDescargar.Text.Replace("/", "-"), fecha_descarga, txtFunDescargar.Text);
                    if (actualizar >= 1)
                    {
                        MessageBox.Show("Datos guardados correctamente.", "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_todo();
                        txtFunDescargar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar_todo();
            }
        }

        private void BtnVerFunesPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable consulta_funes = new ArchivoCruzBlanca().VerFunesPendientes();
                dgvFunesPendientes.DataSource = consulta_funes;
                Formato_dgv_funes_pendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Funes pendientes. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerarReporteFuenasPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFunesPendientes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ExportarExcel(dgvFunesPendientes, "funesPendientesCruz_Blanca.xlsx");
                    MessageBox.Show("Reporte creado correctamente.", "REPORTE OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void Formato_dgv_funes_pendientes()
        {
            dgvFunesPendientes.RowsDefaultCellStyle.BackColor = Color.White;
            dgvFunesPendientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvFunesPendientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvFunesPendientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvFunesPendientes.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnOkCargaAutomatica_Click(object sender, EventArgs e)
        {
            cmbNotificadorCargaAutomatica.Enabled = false;
            txtFunCargaAutomatica.Focus();
        }

        public void Formato_dgv_carga_automatica()
        {
            dgvCargaAutomatica.ColumnCount = 19;
            dgvCargaAutomatica.Columns[0].Name = "FUN";
            dgvCargaAutomatica.Columns[1].Name = "Tipo FUN";
            dgvCargaAutomatica.Columns[2].Name = "Notificador";
            dgvCargaAutomatica.Columns[3].Name = "Rut Afiliado";
            dgvCargaAutomatica.Columns[4].Name = "Nombre Empresa";
            dgvCargaAutomatica.Columns[5].Name = "Dirección Empresa";
            dgvCargaAutomatica.Columns[6].Name = "Comuna Empresa";
            dgvCargaAutomatica.Columns[7].Name = "Motivo";
            dgvCargaAutomatica.Columns[8].Name = "Detalle Rechazado";
            dgvCargaAutomatica.Columns[9].Name = "Dirección D.G.";
            dgvCargaAutomatica.Columns[10].Name = "Fecha Ingreso";
            dgvCargaAutomatica.Columns[11].Name = "Fecha Carga";
            dgvCargaAutomatica.Columns[12].Name = "Fecha Notificación";
            dgvCargaAutomatica.Columns[13].Name = "Fecha D.G.";
            dgvCargaAutomatica.Columns[14].Name = "Fecha Proceso";
            dgvCargaAutomatica.Columns[15].Name = "Fecha Rendición";
            dgvCargaAutomatica.Columns[16].Name = "Fecha de Rechazo";
            dgvCargaAutomatica.Columns[17].Name = "Fecha Finiquito";
            dgvCargaAutomatica.Columns[18].Name = "Fecha Descarga";
            //dgvCargaAutomatica.Rows.Clear();
            dgvCargaAutomatica.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCargaAutomatica.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvCargaAutomatica.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvCargaAutomatica.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvCargaAutomatica.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void Formato_dgv_descarga_habilitados()
        {
            dgvDescargaAutomatica.ColumnCount = 8;
            dgvDescargaAutomatica.Columns[0].Name = "FUN";
            dgvDescargaAutomatica.Columns[1].Name = "Nombre Empresa";
            dgvDescargaAutomatica.Columns[2].Name = "Dirección Empresa";
            dgvDescargaAutomatica.Columns[3].Name = "Comuna Empresa";
            dgvDescargaAutomatica.Columns[4].Name = "Rut Afiliado";
            dgvDescargaAutomatica.Columns[5].Name = "Motivo";
            dgvDescargaAutomatica.Columns[6].Name = "Fecha Rendición";
            dgvDescargaAutomatica.Columns[7].Name = "Fecha Notificación";
            //dejar solo fecha de notificadion como editable
            dgvDescargaAutomatica.Columns["FUN"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Nombre Empresa"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Dirección Empresa"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Comuna Empresa"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Rut Afiliado"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Motivo"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Fecha Rendición"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Fecha Notificación"].ReadOnly = false;
            //dgvDescargaAutomatica.Rows.Clear();
            dgvDescargaAutomatica.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDescargaAutomatica.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvDescargaAutomatica.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvDescargaAutomatica.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvDescargaAutomatica.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void Formato_dgv_descarga_fuera_plazo()
        {
            dgvDescargarFueraPlazo.ColumnCount = 8;
            dgvDescargarFueraPlazo.Columns[0].Name = "FUN";
            dgvDescargarFueraPlazo.Columns[1].Name = "Nombre Empresa";
            dgvDescargarFueraPlazo.Columns[2].Name = "Dirección Empresa";
            dgvDescargarFueraPlazo.Columns[3].Name = "Comuna Empresa";
            dgvDescargarFueraPlazo.Columns[4].Name = "Rut Afiliado";
            dgvDescargarFueraPlazo.Columns[5].Name = "Motivo";
            dgvDescargarFueraPlazo.Columns[6].Name = "Fecha Rendición";
            dgvDescargarFueraPlazo.Columns[7].Name = "Fecha Notificación";
            //hacer que solo el campo fecha notificacion se pueda modificar
            dgvDescargarFueraPlazo.Columns["FUN"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Rut Afiliado"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Nombre Empresa"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Dirección Empresa"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Comuna Empresa"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Fecha Notificación"].ReadOnly = false;
            dgvDescargarFueraPlazo.Columns["Fecha Rendición"].ReadOnly = true;
            //dgvDescargarFueraPlazo.Rows.Clear();
            dgvDescargarFueraPlazo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDescargarFueraPlazo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvDescargarFueraPlazo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvDescargarFueraPlazo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvDescargarFueraPlazo.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void Formato_dgv_descargar_rechazados()
        {
            dgvDescargarRechazados.ColumnCount = 10;
            dgvDescargarRechazados.Columns[0].Name = "FUN";
            dgvDescargarRechazados.Columns[1].Name = "Nombre Empresa";
            dgvDescargarRechazados.Columns[2].Name = "Dirección Empresa";
            dgvDescargarRechazados.Columns[3].Name = "Comuna Empresa";
            dgvDescargarRechazados.Columns[4].Name = "Rut Afiliado";
            dgvDescargarRechazados.Columns[5].Name = "Motivo";
            dgvDescargarRechazados.Columns[6].Name = "Fecha Rendición";
            dgvDescargarRechazados.Columns[7].Name = "Fecha Notificación";
            dgvDescargarRechazados.Columns[8].Name = "Fecha Finiquito";
            dgvDescargarRechazados.Columns[9].Name = "codigo_rechazo";
            dgvDescargarRechazados.Columns["codigo_rechazo"].Visible = false;
            //dejar solo fecha de notificadion como editable
            dgvDescargarRechazados.Columns["FUN"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Nombre Empresa"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Dirección Empresa"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Comuna Empresa"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Rut Afiliado"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Motivo"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Fecha Rendición"].ReadOnly = true;
            dgvDescargarRechazados.Columns["Fecha Notificación"].ReadOnly = false;
            dgvDescargarRechazados.Columns["Fecha Finiquito"].ReadOnly = true;
            //dgvDescargarRechazados.Rows.Clear();
            dgvDescargarRechazados.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDescargarRechazados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvDescargarRechazados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvDescargarRechazados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvDescargarRechazados.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnAgregarCargaAutomatica_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNotificadorCargaAutomatica.Enabled == true)
                {
                    MessageBox.Show("No se ha definido un Notificador. Por favor seleccione uno y luego de click en 'Notificador OK'.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtFunCargaAutomatica.Text = "";
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtFunCargaAutomatica.Text))
                    {
                        MessageBox.Show("Ingrese el FUN para poder buscar.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        System.Data.DataTable consulta = new ArchivoCruzBlanca().VerParaCargaAutomatica(txtFunCargaAutomatica.Text);
                        if (consulta.Rows.Count == 0)
                        {
                            MessageBox.Show("No se han encontrado registros del FUN ingresado.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtFunCargaAutomatica.Text = "";
                            txtFunCargaAutomatica.Focus();
                        }
                        else
                        {
                            string rut_afiliado = "", direccion_dg = "";
                            foreach (System.Data.DataRow item in consulta.Rows)
                            {
                                //**** Verificar doble gestion de FUN (INICIO)****//
                                rut_afiliado = item["sa_archivo_cruz_blanca_rut_afiliado"].ToString();
                                System.Data.DataTable anterior = new ArchivoCruzBlanca().VerAnterior(rut_afiliado, txtFunCargaAutomatica.Text);
                                foreach (System.Data.DataRow dr in anterior.Rows)
                                {
                                    direccion_dg = dr["sa_archivo_cruz_blanca_direccion_dg"].ToString();
                                }
                                if (!string.IsNullOrWhiteSpace(direccion_dg) || direccion_dg != "")
                                {
                                    //Tiene Doble Gestión
                                    MessageBox.Show("El Folio Fun " + txtFunCargaAutomatica.Text + " posee Doble Gestión. La dirección es " +
                                    "" + direccion_dg.ToUpper() + ".", "FUN CON DOBLE GESTIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                //**** Verificar doble gestion de FUN (TERMINO)****//

                                //**** Verificar que no esté INUBICABLE (INICIO)****//
                                System.Data.DataTable inubicable = new ArchivoCruzBlanca().VerInubicable(rut_afiliado);
                                if (inubicable.Rows.Count > 0)
                                {
                                    MessageBox.Show("El Folio Fun " + txtFunCargaAutomatica.Text + " está en estado INUBICABLE", "FUN INUBICABLE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    rut_afiliado = "";
                                    direccion_dg = "";
                                    txtFunCargaAutomatica.Text = "";
                                    txtFunCargaAutomatica.Focus();
                                }
                                else
                                {
                                    dgvCargaAutomatica.Rows.Add(txtFunCargaAutomatica.Text, item["sa_archivo_Cruz_Blanca_tipo_fun"].ToString(), cmbNotificadorCargaAutomatica.Text,
                                    item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString(), item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString(),
                                    item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString(), item["sa_archivo_Cruz_Blanca_comuna_empresa"].ToString(), item["sa_motivo_desc"].ToString(),
                                    item["sa_estado_rechazado_Cruz_Blanca_desc"].ToString(), item["sa_archivo_Cruz_Blanca_direccion_dg"].ToString(), item["sa_archivo_Cruz_Blanca_fecha_ingreso"].ToString(),
                                    item["sa_archivo_Cruz_Blanca_fecha_carga"].ToString(), item["sa_archivo_Cruz_Blanca_fecha_notificacion"].ToString(), item["sa_archivo_Cruz_Blanca_fecha_dg"].ToString(),
                                    item["sa_archivo_Cruz_Blanca_fecha_proceso"].ToString(), item["sa_archivo_Cruz_Blanca_fecha_rendicion"].ToString(), item["sa_archivo_Cruz_Blanca_fecha_rechazo"].ToString(),
                                    item["sa_archivo_Cruz_Blanca_fecha_finiquito"].ToString(), item["sa_archivo_Cruz_Blanca_fecha_descarga"].ToString());
                                    txtFunCargaAutomatica.Text = "";
                                    txtFunCargaAutomatica.Focus();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de ingresar la información al visualizador. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngresarCargaAutomatica_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCargaAutomatica.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para actualizar.", "VISUALIZADOR VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int actualizar = 0;
                    string fecha_carga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    int codigo_notificador = Convert.ToInt32(cmbNotificadorCargaAutomatica.SelectedValue.ToString());
                    foreach (DataGridViewRow row in dgvCargaAutomatica.Rows)
                    {
                        string fun = row.Cells["FUN"].Value.ToString();
                        actualizar = new ArchivoCruzBlanca().ActualizarNotificador(codigo_notificador, fecha_carga, fun);
                    }
                    if (actualizar >= 1)
                    {
                        ExportarExcel(dgvCargaAutomatica, "carga_" + cmbNotificadorCargaAutomatica.Text + ".xlsx");
                        MessageBox.Show("Información actualizada correctamente.", "INFO ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtFunCargaAutomatica.Text = "";
                        txtFunCargaAutomatica.Focus();
                        dgvCargaAutomatica.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscarDescargaAutomatica_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFunDescargaAutomatica.Text))
                {
                    MessageBox.Show("Ingrese el Fun a buscar.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFunDescargaAutomatica.Text = "";
                    txtFunDescargaAutomatica.Focus();
                }
                else
                {
                    string fecha_rendicion = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().BuscarDatosFun(txtFunDescargaAutomatica.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros. Intente nuevamente.", "SIN REGISTROS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFunDescargaAutomatica.Text = "";
                        txtFunDescargaAutomatica.Focus();
                    }
                    else
                    {
                        foreach (System.Data.DataRow item in consulta.Rows)
                        {
                            if (dgvDescargaAutomatica.Rows.Count == 0)
                            {
                                ubicacionDH = 0;
                            }
                            else
                            {
                                ubicacionDH += 1;
                            }
                            dgvDescargaAutomatica.Rows.Add(txtFunDescargaAutomatica.Text, item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString(), item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString(),
                                item["sa_archivo_Cruz_Blanca_comuna_empresa"].ToString(), item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString(), "Habilitado",
                                Convert.ToDateTime(fecha_rendicion).ToShortDateString().Replace("/", "-"), "");
                            dgvDescargaAutomatica.Focus();
                            dgvDescargaAutomatica.CurrentCell = dgvDescargaAutomatica.Rows[ubicacionDH].Cells[7];
                        }
                        txtFunDescargaAutomatica.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFinalizarDescargaAutomatica_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDescargaAutomatica.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para actualizar.", "VISUALIZADOR VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string orden = "";
                    int actualizar = 0;
                    bool estado_fecha = true;
                    foreach (DataGridViewRow row in dgvDescargaAutomatica.Rows)
                    {
                        if (row.Cells[7].Value == null || row.Cells[7].Value.ToString() == "")
                        {
                            MessageBox.Show("Hay un campo de fecha que está sin completar. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargaAutomatica.CurrentCell = dgvDescargaAutomatica.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                        else if (row.Cells[7].Value.ToString().Length > 10 || row.Cells[7].Value.ToString().Length < 10)
                        {
                            MessageBox.Show("Campo de fecha con valor incorrecto. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargaAutomatica.CurrentCell = dgvDescargaAutomatica.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                    }
                    if (estado_fecha == true)
                    {
                        foreach (DataGridViewRow row in dgvDescargaAutomatica.Rows)
                        {
                            string fun = row.Cells["FUN"].Value.ToString();
                            string fecha_rendicion = row.Cells["Fecha Rendición"].Value.ToString();
                            string fecha_notificacion = row.Cells["Fecha Notificación"].Value.ToString();
                            int habilitado = 2; //habilitado
                            int estado_rechazado = 1; //sin estado
                            string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                            orden = DateTime.Now.TimeOfDay.ToString();
                            System.Threading.Thread.Sleep(10);
                            fecha_notificacion = fecha_notificacion.Replace("/", "-");
                            fecha_rendicion = fecha_rendicion.Replace("/", "-");

                            actualizar = new ArchivoCruzBlanca().DescargaHabilitados(fecha_rendicion, fecha_notificacion, fecha_descarga, habilitado, estado_rechazado, Sesion.IdUsuario, orden, "HAB", fun);
                        }
                        if (actualizar >= 1)
                        {
                            ExportarExcel(dgvDescargaAutomatica, "DescargaHabilitadosCruz_Blanca.xlsx");
                            MessageBox.Show("Actualización correcta.", "DATOS ACTUALIZADOS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtFunDescargaAutomatica.Text = "";
                            txtFunDescargaAutomatica.Focus();
                            dgvDescargaAutomatica.Rows.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de ingresar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerificarDescargarFueraPlazo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFunDescargarFueraPlazo.Text))
                {
                    MessageBox.Show("Ingrese el FUN para poder buscar.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFunDescargarFueraPlazo.Focus();
                }
                else
                {
                    string fecha_rendicion = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().VerParaDescargaFueraPlazo(txtFunDescargarFueraPlazo.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros del FUN ingresado.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFunDescargarFueraPlazo.Text = "";
                        txtFunDescargarFueraPlazo.Focus();
                    }
                    else
                    {
                        foreach (System.Data.DataRow item in consulta.Rows)
                        {
                            if (dgvDescargarFueraPlazo.Rows.Count == 0)
                            {
                                ubicacionDFP = 0;
                            }
                            else
                            {
                                ubicacionDFP += 1;
                            }
                            dgvDescargarFueraPlazo.Rows.Add(txtFunDescargarFueraPlazo.Text, item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString(),
                                item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString(), item["sa_archivo_Cruz_Blanca_comuna_empresa"].ToString(),
                                item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString(), "Habilitado F.P.",
                                fecha_rendicion, "");
                            dgvDescargarFueraPlazo.Focus();
                            dgvDescargarFueraPlazo.CurrentCell = dgvDescargarFueraPlazo.Rows[ubicacionDFP].Cells[7];
                        }
                        txtFunDescargarFueraPlazo.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el FUN. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFinalizarDescargarFueraPlazo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDescargarFueraPlazo.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para actualizar.", "VISUALIZADOR EN BLANCO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string orden = "";
                    int actualizar = 0;
                    bool estado_fecha = true;
                    foreach (DataGridViewRow row in dgvDescargarFueraPlazo.Rows)
                    {
                        if (row.Cells[7].Value == null || row.Cells[7].Value.ToString() == "")
                        {
                            MessageBox.Show("Hay un campo de fecha que está sin completar. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargarFueraPlazo.CurrentCell = dgvDescargarFueraPlazo.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                        else if (row.Cells[7].Value.ToString().Length > 10 || row.Cells[7].Value.ToString().Length < 10)
                        {
                            MessageBox.Show("Campo de fecha con valor incorrecto. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargarFueraPlazo.CurrentCell = dgvDescargarFueraPlazo.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                    }
                    if (estado_fecha == true)
                    {
                        string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                        foreach (DataGridViewRow row in dgvDescargarFueraPlazo.Rows)
                        {
                            string fun = row.Cells["FUN"].Value.ToString();
                            string fecha_rendicion = row.Cells["Fecha Rendición"].Value.ToString();
                            string fecha_notificacion = row.Cells["Fecha Notificación"].Value.ToString();
                            int motivo = 3; //fuera de plazo, defecto
                            orden = DateTime.Now.TimeOfDay.ToString();
                            fecha_rendicion = fecha_rendicion.Replace("/", "-");
                            fecha_notificacion = fecha_notificacion.Replace("/", "-");
                            System.Threading.Thread.Sleep(10);
                            actualizar = new ArchivoCruzBlanca().ActualizarFueraPlazo(fecha_rendicion, fecha_notificacion, fecha_descarga, motivo, Sesion.IdUsuario, orden, "FPL", fun);
                        }
                        ExportarExcel(dgvDescargarFueraPlazo, "descargarFueraPlazoCruz_Blanca.xlsx");
                        MessageBox.Show("Datos actualizados correctamente.", "DATOS ACTUALIZADOS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al ingresar los datos actualizados.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCargaAutomatica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    int fila = dgvCargaAutomatica.CurrentRow.Index;
                    dgvCargaAutomatica.Rows.RemoveAt(fila);
                    txtFunCargaAutomatica.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvDescargaAutomatica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dgvDescargaAutomatica.Rows.Count == 1)
                    {
                        int fila = dgvDescargaAutomatica.CurrentRow.Index;
                        dgvDescargaAutomatica.Rows.RemoveAt(fila);
                        ubicacionDH = 0;
                        txtFunDescargaAutomatica.Text = "";
                        txtFunDescargaAutomatica.Focus();
                    }
                    else
                    {
                        int fila = dgvDescargaAutomatica.CurrentRow.Index;
                        dgvDescargaAutomatica.Rows.RemoveAt(fila);
                        ubicacionDH -= 1;
                        dgvDescargaAutomatica.Focus();
                        dgvDescargaAutomatica.CurrentCell = dgvDescargaAutomatica.Rows[ubicacionDH].Cells[7];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvDescargarFueraPlazo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dgvDescargarFueraPlazo.Rows.Count == 1)
                    {
                        int fila = dgvDescargarFueraPlazo.CurrentRow.Index;
                        dgvDescargarFueraPlazo.Rows.RemoveAt(fila);
                        ubicacionDFP = 0;
                        txtFunDescargarFueraPlazo.Focus();
                        txtFunDescargarFueraPlazo.Text = "";
                    }
                    else
                    {
                        int fila = dgvDescargarFueraPlazo.CurrentRow.Index;
                        dgvDescargarFueraPlazo.Rows.RemoveAt(fila);
                        ubicacionDFP -= 1;
                        dgvDescargarFueraPlazo.Focus();
                        dgvDescargarFueraPlazo.CurrentCell = dgvDescargarFueraPlazo.Rows[ubicacionDFP].Cells[7];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnVerificarDescargarRechazados_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFunDescargarRechazados.Text))
                {
                    MessageBox.Show("Ingrese el Fun.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFunDescargarRechazados.Text = "";
                    txtFunDescargarRechazados.Focus();
                }
                else
                {
                    int estado_rechazado = Convert.ToInt32(cmbDescargarRechazados.SelectedValue.ToString());
                    string fecha_rendicion = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    System.Data.DataTable consulta = new ArchivoCruzBlanca().BuscarDatosFun(txtFunDescargarRechazados.Text);
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        if (cmbDescargarRechazados.Text == "3     Trabajador Finiquitado" || cmbDescargarRechazados.Text == "4     Empleador Inubicable en esa Dirección")
                        {
                            dgvDescargarRechazados.Columns["Fecha Finiquito"].ReadOnly = false;
                        }
                        else
                        {
                            dgvDescargarRechazados.Columns["Fecha Finiquito"].ReadOnly = true;
                        }
                        if (dgvDescargarRechazados.Rows.Count == 0)
                        {
                            ubicacionR = 0;
                        }
                        else
                        {
                            ubicacionR += 1;
                        }
                        dgvDescargarRechazados.Rows.Add(txtFunDescargarRechazados.Text, item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString(), item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString(),
                                item["sa_archivo_Cruz_Blanca_comuna_empresa"].ToString(), item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString(), cmbDescargarRechazados.Text,
                                Convert.ToDateTime(fecha_rendicion).ToShortDateString().Replace("/", "-"), "", "", estado_rechazado);
                        dgvDescargarRechazados.Focus();
                        dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[ubicacionR].Cells[7];
                    }
                    txtFunDescargarRechazados.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descargar Fun rechazados. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFinalziarDescargarRechazados_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDescargarRechazados.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para actualizar.", "VISUALIZADOR VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string orden = "";
                    int actualizar = 0;
                    string fecha_finiquito = "";
                    string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    bool estado_fecha = true;
                    foreach (DataGridViewRow row in dgvDescargarRechazados.Rows)
                    {
                        if (row.Cells[7].Value == null || row.Cells[7].Value.ToString() == "")
                        {
                            MessageBox.Show("Hay un campo de fecha que está sin completar. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                        else if (row.Cells[7].Value.ToString().Length > 10 || row.Cells[7].Value.ToString().Length < 10)
                        {
                            MessageBox.Show("Campo de fecha con valor incorrecto. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                        else if (row.Cells[5].Value.ToString() == "3     Trabajador Finiquitado" || row.Cells[5].Value.ToString() == "4     Empleador Inubicable en esa Dirección")
                        {
                            if (row.Cells[8].Value.ToString().Length > 10 || row.Cells[8].Value.ToString().Length < 10 || row.Cells[8].Value.ToString() == "")
                            {
                                //fecha finiquito
                                MessageBox.Show("Campo de fecha con valor incorrecto. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[8];
                                estado_fecha = false;
                                break;
                            }
                        }
                    }
                    if (estado_fecha == true)
                    {
                        string fecha_rechazo = DateTime.Now.Date.ToString("dd-MM-yyyy");
                        string fun = "", fecha_rendicion = "", fecha_notificacion = "", rut = "";
                        foreach (DataGridViewRow row in dgvDescargarRechazados.Rows)
                        {
                            rut = row.Cells["Rut Afiliado"].Value.ToString();
                            fun = row.Cells["FUN"].Value.ToString();
                            fecha_rendicion = row.Cells["Fecha Rendición"].Value.ToString();
                            fecha_notificacion = row.Cells["Fecha Notificación"].Value.ToString();
                            if (row.Cells["Fecha Finiquito"].Value.ToString() == "")
                            {
                                fecha_finiquito = "";
                            }
                            else
                            {
                                fecha_finiquito = Convert.ToDateTime(row.Cells["Fecha Finiquito"].Value.ToString()).ToShortDateString().Replace("/", "-");
                            }
                            int codigo_rechazo = Convert.ToInt32(row.Cells["codigo_rechazo"].Value.ToString());
                            int rechazado = 4; //rechazado
                            orden = DateTime.Now.TimeOfDay.ToString();
                            fecha_rendicion = fecha_rendicion.Replace("/", "-");
                            fecha_notificacion = fecha_notificacion.Replace("/", "-");
                            fecha_rechazo = fecha_rechazo.Replace("/", "-");

                            System.Threading.Thread.Sleep(10);
                            actualizar = new ArchivoCruzBlanca().DescargarRechazado(fecha_rendicion, fecha_notificacion, fecha_descarga, fecha_finiquito, fecha_rechazo, rechazado, codigo_rechazo,
                                Sesion.IdUsuario, orden, "REC", fun);

                            if (codigo_rechazo == 5)
                            {
                                if (!Sesion.VerificarInubicableCruzBlanca(rut))
                                {
                                    //NO ESTÁ EN INUBICABLE
                                    int ingresa = new ArchivoCruzBlanca().IngresaInubicable(rut);
                                }
                            }
                        }
                        if (actualizar >= 1)
                        {
                            ExportarExcel(dgvDescargarRechazados, "DescargaRechazadosCruz_Blanca.xlsx");
                            MessageBox.Show("Actualización correcta.", "DATOS ACTUALIZADOS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtFunDescargarRechazados.Text = "";
                            txtFunDescargarRechazados.Focus();
                            dgvDescargarRechazados.Rows.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de ingresar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvDescargarRechazados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dgvDescargarRechazados.Rows.Count == 1)
                    {
                        int fila = dgvDescargarRechazados.CurrentRow.Index;
                        dgvDescargarRechazados.Rows.RemoveAt(fila);
                        ubicacionR = 0;
                        txtFunDescargarRechazados.Text = "";
                        txtFunDescargarRechazados.Focus();
                    }
                    else
                    {
                        int fila = dgvDescargarRechazados.CurrentRow.Index;
                        dgvDescargarRechazados.Rows.RemoveAt(fila);
                        ubicacionR -= 1;
                        dgvDescargarRechazados.Focus();
                        dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[ubicacionR].Cells[7];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmbMotivoDescargar_TextChanged(object sender, EventArgs e)
        {
            if (estado_carga == true)
            {
                if (cmbMotivoDescargar.Text == "Habilitado")
                {
                    cmbObervacionDescargar.Enabled = false;
                }
                else if (cmbMotivoDescargar.Text == "Habilitado F.P.")
                {
                    cmbObervacionDescargar.Enabled = false;
                }
                else if (cmbMotivoDescargar.Text == "Sin estado (Por Defecto)")
                {
                    cmbObervacionDescargar.Enabled = false;
                }
                else
                {
                    cmbObervacionDescargar.Enabled = true;
                }
            }
        }

        private void DgvDescargaAutomatica_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDescargaAutomatica.CurrentCell.ColumnIndex == 7)
                {
                    if (!string.IsNullOrWhiteSpace(dgvDescargaAutomatica.CurrentRow.Cells["Fecha Notificación"].Value.ToString()))
                    {
                        int anio = DateTime.Now.Year;
                        string valor = dgvDescargaAutomatica.CurrentRow.Cells["Fecha Notificación"].Value.ToString();
                        dgvDescargaAutomatica.CurrentRow.Cells["Fecha Notificación"].Value = valor + "-" + anio;
                    }
                }
                if (dgvDescargaAutomatica.CurrentCell.ColumnIndex == 7)
                {
                    txtFunDescargaAutomatica.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void DgvDescargarFueraPlazo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDescargarFueraPlazo.CurrentCell.ColumnIndex == 7)
                {
                    if (!string.IsNullOrWhiteSpace(dgvDescargarFueraPlazo.CurrentRow.Cells["Fecha Notificación"].Value.ToString()))
                    {
                        int anio = DateTime.Now.Year;
                        string valor = dgvDescargarFueraPlazo.CurrentRow.Cells["Fecha Notificación"].Value.ToString();
                        dgvDescargarFueraPlazo.CurrentRow.Cells["Fecha Notificación"].Value = valor + "-" + anio;
                    }
                }
                if (dgvDescargarFueraPlazo.CurrentCell.ColumnIndex == 7)
                {
                    txtFunDescargarFueraPlazo.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void DgvDescargarRechazados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (cmbDescargarRechazados.Text == "3     Trabajador Finiquitado")
                {
                    if (dgvDescargarRechazados.CurrentCell.ColumnIndex == 8)
                    {
                        txtFunDescargarRechazados.Focus();
                    }
                    else if (dgvDescargarRechazados.CurrentCell.ColumnIndex == 7)
                    {
                        if (!string.IsNullOrWhiteSpace(dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value.ToString()))
                        {
                            int anio = DateTime.Now.Year;
                            string valor = dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value.ToString();
                            dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value = valor + "-" + anio;
                        }
                    }
                }
                else
                {
                    if (dgvDescargarRechazados.CurrentCell.ColumnIndex == 7)
                    {
                        if (!string.IsNullOrWhiteSpace(dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value.ToString()))
                        {
                            int anio = DateTime.Now.Year;
                            string valor = dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value.ToString();
                            dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value = valor + "-" + anio;
                        }
                    }
                    if (dgvDescargarRechazados.CurrentCell.ColumnIndex == 7)
                    {
                        txtFunDescargarRechazados.Focus();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}