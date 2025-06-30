using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmMantenedorPrincipalCarta : Form
    {
        public static bool estado_carga = false;
        public DateTimePicker dtpFecha = new DateTimePicker();
        public DateTimePicker dtpFueraPlazo = new DateTimePicker();
        public DateTimePicker dtpRechazado = new DateTimePicker();
        public static int ubicacionDH = 0, ubicacionDFP = 0, ubicacionR = 0;

        public frmMantenedorPrincipalCarta()
        {
            InitializeComponent();
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
                    System.Data.DataTable consulta = new ArchivoCartaDAL().BuscarPorFUN(txtFUN.Text);
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
                            txtRutAfiliado.Text = item["sa_archivo_carta_rut_afiliado"].ToString();
                            txtNombreEmpresa.Text = item["sa_archivo_carta_nombre_empresa"].ToString();
                            txtDireccionEmpresa.Text = item["sa_archivo_carta_direccion_empresa"].ToString();
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

        private void frmMantenedorPrincipalCarta_Load(object sender, EventArgs e)
        {
            //notificador
            try
            {
                cmbNotificador.DataSource = new NotificadorDAL().VerNotificadores();
                cmbNotificador.DisplayMember = "sa_notificador_nombre";
                cmbNotificador.ValueMember = "sa_notificador";
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la lista de notificadores.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //notificador funes pendientes
            try
            {
                cmbFunPendienteNotificador.DataSource = new NotificadorDAL().VerNotificadores();
                cmbFunPendienteNotificador.DisplayMember = "sa_notificador_nombre";
                cmbFunPendienteNotificador.ValueMember = "sa_notificador";
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la lista de notificadores.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //notificador carga automatica
            try
            {
                cmbNotificadorCargaAutomatica.DataSource = new NotificadorDAL().VerNotificadores();
                cmbNotificadorCargaAutomatica.DisplayMember = "sa_notificador_nombre";
                cmbNotificadorCargaAutomatica.ValueMember = "sa_notificador";
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la lista de notificadores.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //descargar rechazados
            try
            {
                cmbDescargarRechazados.DataSource = new EstadoRechazadoDAL().VerEstadosRechazado();
                cmbDescargarRechazados.DisplayMember = "sa_estados_desc";
                cmbDescargarRechazados.ValueMember = "sa_estados";
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la lista de Observaciones.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtFUN.Focus();
            frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
            mp.AcceptButton = btnBuscarFUN;
            cmbObervacionDescargar.Enabled = false;
            cmbMotivoDescargar.Enabled = false;
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo_notificador = Convert.ToInt32(cmbNotificador.SelectedValue.ToString());
                string fecha_carga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                int actualizar = new ArchivoCartaDAL().ActualizarNotificador(codigo_notificador, fecha_carga, txtFUN.Text);
                MessageBox.Show("Documento asignado correctamente.", "ASIGNACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtFUN.Text = "";
                txtDireccionEmpresa.Text = "";
                txtNombreEmpresa.Text = "";
                txtRutAfiliado.Text = "";
                btnAsignar.Enabled = false;
                cmbNotificador.Enabled = false;
                txtFUN.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al asignar el notificador al documento.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    System.Data.DataTable consulta = new ArchivoCartaDAL().BuscarFUNNotificador(txtFunDescargar.Text);
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
                            txtFunDescargar.Text = item["sa_archivo_carta_fun"].ToString();
                            txtFunDescargar.ReadOnly = true;
                            txtNombreEmpresaDescargar.Text = item["sa_archivo_carta_nombre_empresa"].ToString();
                            txtComunaDescargar.Text = item["sa_archivo_carta_comuna_empresa"].ToString();
                            txtNotificadorDescargar.Text = item["sa_notificador_nombre"].ToString();
                            txtDireccionDGDescargar.Text = item["sa_archivo_carta_direccion_dg"].ToString();
                            txtFechaIngresoDescargar.Text = item["sa_archivo_carta_fecha_ingreso"].ToString();
                            txtFechaCargaDescargar.Text = item["sa_archivo_carta_fecha_carga"].ToString();
                            txtFechaNotificacionDescargar.Text = item["sa_archivo_carta_fecha_notificacion"].ToString();
                            txtFechaDGDescargar.Text = item["sa_archivo_carta_fecha_dg"].ToString();
                            txtRutAfiliadoDescargar.Text = item["sa_archivo_carta_rut_afiliado"].ToString();
                            txtDireccionEmpresaDescargar.Text = item["sa_archivo_carta_direccion_empresa"].ToString();
                            txtFechaProcesoDescargar.Text = item["sa_archivo_carta_fecha_proceso"].ToString();
                            txtFechaRechazoDescargar.Text = item["sa_archivo_carta_fecha_rechazo"].ToString();
                            txtFechaFiniquitoDescargar.Text = item["sa_archivo_carta_fecha_finiquito"].ToString();
                            string firma = item["sa_archivo_carta_firma"].ToString();
                            string timbre = item["sa_archivo_carta_timbre"].ToString();
                            if (string.IsNullOrWhiteSpace(firma) || firma == "False")
                            {
                                cbFirmaDescargar.Checked = false;
                            }
                            else
                            {
                                cbFirmaDescargar.Checked = true;
                            }
                            if (string.IsNullOrWhiteSpace(timbre) || timbre == "False")
                            {
                                cbTimbreDescargar.Checked = false;
                            }
                            else
                            {
                                cbTimbreDescargar.Checked = true;
                            }
                            cmbMotivoDescargar.Enabled = true;
                            txtNombreEmpresaDescargar.ReadOnly = false;
                            txtDireccionEmpresaDescargar.ReadOnly = false;
                            txtComunaDescargar.ReadOnly = false;
                            cbFirmaDescargar.Enabled = true;
                            cbTimbreDescargar.Enabled = true;
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
                            cmbMotivoDescargar.DataSource = new MotivoDAL().CargarListaSeleccionadoCarta(txtFunDescargar.Text);
                            cmbMotivoDescargar.DisplayMember = "sa_motivo_desc";
                            cmbMotivoDescargar.ValueMember = "sa_motivo";
                            //cargar estados de error
                            cmbObervacionDescargar.DataSource = new EstadoRechazadoDAL().CargarListaSeleccionadoCarta(txtFunDescargar.Text);
                            cmbObervacionDescargar.DisplayMember = "sa_estados_desc";
                            cmbObervacionDescargar.ValueMember = "sa_estados";
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
                bool timbre = cbTimbreDescargar.Checked;
                bool firma = cbFirmaDescargar.Checked;
                string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                if (cmbMotivoDescargar.Text == "Habilitado")
                {
                    int estado_rechazo_defecto = 1;
                    int motivo = Convert.ToInt32(cmbMotivoDescargar.SelectedValue.ToString());
                    int actualizar = new ArchivoCartaDAL().ActualizarConHabilitado(txtNombreEmpresaDescargar.Text, txtComunaDescargar.Text, txtDireccionEmpresaDescargar.Text,
                        motivo, estado_rechazo_defecto, txtFechaRendicionDescargar.Text, fecha_descarga, firma, timbre, txtFunDescargar.Text);
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
                    int actualizar = new ArchivoCartaDAL().ActualizarConHabilitado(txtNombreEmpresaDescargar.Text, txtComunaDescargar.Text, txtDireccionEmpresaDescargar.Text,
                        motivo, estado_rechazo_defecto, txtFechaRendicionDescargar.Text, fecha_descarga, firma, timbre, txtFunDescargar.Text);
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
                    int actualizar = new ArchivoCartaDAL().ActualizarSinHabilitado(txtNombreEmpresaDescargar.Text, txtComunaDescargar.Text, txtDireccionEmpresaDescargar.Text,
                        motivo, estado_rechazo, txtFechaRendicionDescargar.Text, txtFechaRechazoDescargar.Text, fecha_descarga, firma, timbre, txtFunDescargar.Text);
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

        private void TcPanelPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tcPanelPrincipal.SelectedTab.Name == "tpCargarNotificador")
                {
                    txtFUN.Focus();
                    frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
                    mp.AcceptButton = btnBuscarFUN;
                }
                else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargarNotificador")
                {
                    txtFunDescargar.Focus();
                    frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
                    mp.AcceptButton = btnBuscarDescargar;
                }
                else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargaHAB")
                {
                    txtFunDescargaAutomatica.Focus();
                    frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
                    mp.AcceptButton = btnBuscarDescargaAutomatica;
                    Formato_dgv_descarga_habilitados();
                }
                else if (tcPanelPrincipal.SelectedTab.Name == "tpCargaAutomatica")
                {
                    txtFunCargaAutomatica.Focus();
                    frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
                    mp.AcceptButton = btnAgregarCargaAutomatica;
                    Formato_dgv_carga_automatica();
                }
                else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargaHFP")
                {
                    txtFunDescargarFueraPlazo.Focus();
                    frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
                    mp.AcceptButton = btnVerificarDescargarFueraPlazo;
                    Formato_dgv_descarga_fuera_plazo();
                }
                else if (tcPanelPrincipal.SelectedTab.Name == "tpDescargarRechazados")
                {
                    txtFunDescargarRechazados.Focus();
                    frmMantenedorPrincipalCarta mp = System.Windows.Forms.Application.OpenForms["frmMantenedorPrincipalCarta"] as frmMantenedorPrincipalCarta;
                    mp.AcceptButton = btnVerificarDescargarRechazados;
                    Formato_dgv_descargar_rechazados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar opciones de controlador. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Formato_dgv_descargar_rechazados()
        {
            dgvDescargarRechazados.ColumnCount = 12;
            dgvDescargarRechazados.Columns[0].Name = "FUN";
            dgvDescargarRechazados.Columns[1].Name = "Nombre Empresa";
            dgvDescargarRechazados.Columns[2].Name = "Dirección Empresa";
            dgvDescargarRechazados.Columns[3].Name = "Comuna Empresa";
            dgvDescargarRechazados.Columns[4].Name = "Rut Afiliado";
            dgvDescargarRechazados.Columns[5].Name = "Motivo";
            dgvDescargarRechazados.Columns[6].Name = "Fecha Rendición";
            dgvDescargarRechazados.Columns[7].Name = "Fecha Notificación";
            dgvDescargarRechazados.Columns[8].Name = "Fecha Finiquito";
            dgvDescargarRechazados.Columns[9].Name = "Firma";
            dgvDescargarRechazados.Columns[10].Name = "Timbre";
            dgvDescargarRechazados.Columns[11].Name = "codigo_rechazo";
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
            dgvDescargarRechazados.Columns["Firma"].ReadOnly = false;
            dgvDescargarRechazados.Columns["Timbre"].ReadOnly = false;
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

        public void Formato_dgv_descarga_habilitados()
        {
            dgvDescargaAutomatica.ColumnCount = 10;
            dgvDescargaAutomatica.Columns[0].Name = "FUN";
            dgvDescargaAutomatica.Columns[1].Name = "Nombre Empresa";
            dgvDescargaAutomatica.Columns[2].Name = "Dirección Empresa";
            dgvDescargaAutomatica.Columns[3].Name = "Comuna Empresa";
            dgvDescargaAutomatica.Columns[4].Name = "Rut Afiliado";
            dgvDescargaAutomatica.Columns[5].Name = "Motivo";
            dgvDescargaAutomatica.Columns[6].Name = "Fecha Rendición";
            dgvDescargaAutomatica.Columns[7].Name = "Fecha Notificación";
            dgvDescargaAutomatica.Columns[8].Name = "Firma";
            dgvDescargaAutomatica.Columns[9].Name = "Timbre";
            //dejar solo fecha de notificadion como editable
            dgvDescargaAutomatica.Columns["FUN"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Nombre Empresa"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Dirección Empresa"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Comuna Empresa"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Rut Afiliado"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Motivo"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Fecha Rendición"].ReadOnly = true;
            dgvDescargaAutomatica.Columns["Fecha Notificación"].ReadOnly = false;
            dgvDescargaAutomatica.Columns["Firma"].ReadOnly = false;
            dgvDescargaAutomatica.Columns["Timbre"].ReadOnly = false;
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
            dgvDescargarFueraPlazo.ColumnCount = 10;
            dgvDescargarFueraPlazo.Columns[0].Name = "FUN";
            dgvDescargarFueraPlazo.Columns[1].Name = "Nombre Empresa";
            dgvDescargarFueraPlazo.Columns[2].Name = "Dirección Empresa";
            dgvDescargarFueraPlazo.Columns[3].Name = "Comuna Empresa";
            dgvDescargarFueraPlazo.Columns[4].Name = "Rut Afiliado";
            dgvDescargarFueraPlazo.Columns[5].Name = "Motivo";
            dgvDescargarFueraPlazo.Columns[6].Name = "Fecha Rendición";
            dgvDescargarFueraPlazo.Columns[7].Name = "Fecha Notificación";
            dgvDescargarFueraPlazo.Columns[8].Name = "Firma";
            dgvDescargarFueraPlazo.Columns[9].Name = "Timbre";
            //hacer que solo el campo fecha notificacion se pueda modificar
            dgvDescargarFueraPlazo.Columns["FUN"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Nombre Empresa"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Dirección Empresa"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Comuna Empresa"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Rut Afiliado"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Motivo"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Fecha Rendición"].ReadOnly = true;
            dgvDescargarFueraPlazo.Columns["Fecha Notificación"].ReadOnly = false;
            dgvDescargarFueraPlazo.Columns["Firma"].ReadOnly = false;
            dgvDescargarFueraPlazo.Columns["Timbre"].ReadOnly = false;
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Limpiar_todo()
        {
            txtDireccionEmpresa.Text = "";
            txtFUN.Text = "";
            txtNombreEmpresa.Text = "";
            txtRutAfiliado.Text = "";
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
            txtFunDescargar.Text = "";
            cmbObervacionDescargar.Enabled = false;
            cmbMotivoDescargar.Enabled = false;
            cbFirmaDescargar.Checked = false;
            cbTimbreDescargar.Checked = false;

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
            ubicacionDFP = 0;
            ubicacionDH = 0;
            ubicacionR = 0;
        }

        private void BtnVerFunesPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFunesPendientes.DataSource = null;
                System.Data.DataTable consulta_funes = new ArchivoCartaDAL().VerFunesPendientes();
                dgvFunesPendientes.DataSource = consulta_funes;
                Formato_dgv_funes_pendientes();
            }
            catch (Exception ex)
            {
                dgvFunesPendientes.DataSource = null;
                MessageBox.Show("Error al cargar los Funes pendientes. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFunPendienteBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFunesPendientes.DataSource = null;
                int notificador = Convert.ToInt32(cmbFunPendienteNotificador.SelectedValue.ToString());
                System.Data.DataTable consulta_funes = new ArchivoCartaDAL().VerFunesPendientesNotificador(notificador);
                dgvFunesPendientes.DataSource = consulta_funes;
                Formato_dgv_funes_pendientes();
            }
            catch (Exception ex)
            {
                dgvFunesPendientes.DataSource = null;
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
                    ExportarExcel(dgvFunesPendientes, "funesPendientesCarta.xlsx");
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
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\" + nombre_archivo);
            worksheet.SaveAs(file.ToString());
        }

        private void BtnOkCargaAutomatica_Click(object sender, EventArgs e)
        {
            cmbNotificadorCargaAutomatica.Enabled = false;
            txtFunCargaAutomatica.Focus();
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
                        System.Data.DataTable consulta = new ArchivoCartaDAL().VerParaCargaAutomatica(txtFunCargaAutomatica.Text);
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
                                rut_afiliado = item["sa_archivo_carta_rut_afiliado"].ToString();
                                System.Data.DataTable anterior = new ArchivoCartaDAL().VerAnterior(rut_afiliado, txtFunCargaAutomatica.Text);
                                foreach (System.Data.DataRow dr in anterior.Rows)
                                {
                                    direccion_dg = dr["sa_archivo_carta_direccion_dg"].ToString();
                                }
                                if (!string.IsNullOrWhiteSpace(direccion_dg) || direccion_dg != "")
                                {
                                    //Tiene Doble Gestión
                                    MessageBox.Show("El Folio Fun " + txtFunCargaAutomatica.Text + " posee Doble Gestión. La dirección es " +
                                    "" + direccion_dg.ToUpper() + ".", "FUN CON DOBLE GESTIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                //**** Verificar doble gestion de FUN (TERMINO)****//

                                //**** Verificar que no esté INUBICABLE (INICIO)****//
                                System.Data.DataTable inubicable = new ArchivoCartaDAL().VerInubicable(rut_afiliado);
                                if (inubicable.Rows.Count > 0)
                                {
                                    MessageBox.Show("El Folio Fun " + txtFunCargaAutomatica.Text + " está en estado INUBICABLE", "FUN INUBICABLE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    rut_afiliado = "";
                                    direccion_dg = "";
                                    txtFunCargaAutomatica.Text = "";
                                    txtFunCargaAutomatica.Focus();
                                }
                                else
                                {
                                    dgvCargaAutomatica.Rows.Add(txtFunCargaAutomatica.Text, cmbNotificadorCargaAutomatica.Text,
                                        item["sa_archivo_carta_rut_afiliado"].ToString(), item["sa_archivo_carta_nombre_empresa"].ToString(),
                                        item["sa_archivo_carta_direccion_empresa"].ToString(), item["sa_archivo_carta_comuna_empresa"].ToString(), item["sa_motivo_desc"].ToString(),
                                        item["sa_estados_desc"].ToString(), direccion_dg, item["sa_archivo_carta_fecha_ingreso"].ToString(),
                                        item["sa_archivo_carta_fecha_carga"].ToString(), item["sa_archivo_carta_fecha_notificacion"].ToString(), item["sa_archivo_carta_fecha_dg"].ToString(),
                                        item["sa_archivo_carta_fecha_proceso"].ToString(), item["sa_archivo_carta_fecha_rendicion"].ToString(), item["sa_archivo_carta_fecha_rechazo"].ToString(),
                                        item["sa_archivo_carta_fecha_finiquito"].ToString(), item["Firma"].ToString(), item["Timbre"].ToString());
                                    rut_afiliado = "";
                                    direccion_dg = "";
                                    txtFunCargaAutomatica.Text = "";
                                    txtFunCargaAutomatica.Focus();
                                }
                                //**** Verificar que no esté INUBICABLE (TERMINO)****//
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
                        actualizar = new ArchivoCartaDAL().ActualizarNotificador(codigo_notificador, fecha_carga, fun);
                    }
                    if (actualizar >= 1)
                    {
                        ExportarExcel(dgvCargaAutomatica, cmbNotificadorCargaAutomatica.Text + ".xlsx");
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

        public void Formato_dgv_carga_automatica()
        {
            dgvCargaAutomatica.ColumnCount = 19;
            dgvCargaAutomatica.Columns[0].Name = "FUN";
            dgvCargaAutomatica.Columns[1].Name = "Notificador";
            dgvCargaAutomatica.Columns[2].Name = "Rut Afiliado";
            dgvCargaAutomatica.Columns[3].Name = "Nombre Empresa";
            dgvCargaAutomatica.Columns[4].Name = "Dirección Empresa";
            dgvCargaAutomatica.Columns[5].Name = "Comuna Empresa";
            dgvCargaAutomatica.Columns[6].Name = "Motivo";
            dgvCargaAutomatica.Columns[7].Name = "Detalle Rechazado";
            dgvCargaAutomatica.Columns[8].Name = "Dirección D.G.";
            dgvCargaAutomatica.Columns[9].Name = "Fecha Ingreso";
            dgvCargaAutomatica.Columns[10].Name = "Fecha Carga";
            dgvCargaAutomatica.Columns[11].Name = "Fecha Notificación";
            dgvCargaAutomatica.Columns[12].Name = "Fecha D.G.";
            dgvCargaAutomatica.Columns[13].Name = "Fecha Proceso";
            dgvCargaAutomatica.Columns[14].Name = "Fecha Rendición";
            dgvCargaAutomatica.Columns[15].Name = "Fecha de Rechazo";
            dgvCargaAutomatica.Columns[16].Name = "Fecha Finiquito";
            dgvCargaAutomatica.Columns[17].Name = "Firma";
            dgvCargaAutomatica.Columns[18].Name = "Timbre";
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
                    MessageBox.Show("Error al eliminar la fila seleccionada. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBuscarDescargaAutomatica_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFunDescargaAutomatica.Text))
                {
                    MessageBox.Show("Ingrese el Fun a buscar.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFunDescargaAutomatica.Focus();
                }
                else
                {
                    string fecha_rendicion = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    System.Data.DataTable consulta = new ArchivoCartaDAL().BuscarDatosFun(txtFunDescargaAutomatica.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros. Intente nuevamente.", "SIN REGISTROS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFunDescargaAutomatica.Text = "";
                        txtFunDescargaAutomatica.Focus();
                    }
                    else
                    {
                        string firma = "", timbre = "";
                        foreach (System.Data.DataRow item in consulta.Rows)
                        {
                            if (string.IsNullOrWhiteSpace(item["sa_archivo_carta_firma"].ToString()) || item["sa_archivo_carta_firma"].ToString() == "False")
                            {
                                firma = "0";
                            }
                            else
                            {
                                firma = "1";
                            }
                            if (string.IsNullOrWhiteSpace(item["sa_archivo_carta_timbre"].ToString()) || item["sa_archivo_carta_timbre"].ToString() == "False")
                            {
                                timbre = "0";
                            }
                            else
                            {
                                timbre = "1";
                            }
                            if (dgvDescargaAutomatica.Rows.Count == 0)
                            {
                                ubicacionDH = 0;
                            }
                            else
                            {
                                ubicacionDH += 1;
                            }
                            dgvDescargaAutomatica.Rows.Add(txtFunDescargaAutomatica.Text, item["sa_archivo_carta_nombre_empresa"].ToString(), item["sa_archivo_carta_direccion_empresa"].ToString(),
                                item["sa_archivo_carta_comuna_empresa"].ToString(), item["sa_archivo_carta_rut_afiliado"].ToString(), "Habilitado",
                                Convert.ToDateTime(fecha_rendicion).ToShortDateString().Replace("/", "-"), "", firma, timbre);
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
                    bool firma = false, timbre = false, estado_fecha = true, estado_firma = true, estado_timbre = true;
                    foreach (DataGridViewRow row in dgvDescargaAutomatica.Rows)
                    {
                        //campo fecha vacio
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
                        if (estado_fecha == true)
                        {
                            //firma
                            if (row.Cells[8].Value.ToString() != "1" && row.Cells[8].Value.ToString() != "0")
                            {
                                MessageBox.Show("Hay un campo de Firma que contiene un valor que no corresponde.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dgvDescargaAutomatica.CurrentCell = dgvDescargaAutomatica.Rows[row.Index].Cells[8];
                                estado_firma = false;
                                break;
                            }
                            if (estado_firma == true)
                            {
                                //timbre
                                if (row.Cells[9].Value.ToString() != "1" && row.Cells[9].Value.ToString() != "0")
                                {
                                    MessageBox.Show("Hay un campo de Timbre que contiene un valor que no corresponde.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    dgvDescargaAutomatica.CurrentCell = dgvDescargaAutomatica.Rows[row.Index].Cells[9];
                                    estado_timbre = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (estado_firma == true && estado_timbre == true && estado_fecha == true)
                    {
                        foreach (DataGridViewRow row in dgvDescargaAutomatica.Rows)
                        {
                            string fun = row.Cells["FUN"].Value.ToString();
                            string fecha_rendicion = row.Cells["Fecha Rendición"].Value.ToString();
                            string fecha_notificacion = row.Cells["Fecha Notificación"].Value.ToString();
                            int habilitado = 2; //habilitado
                            int estado_rechazado = 1; //sin estado
                            if (row.Cells["Firma"].Value.ToString() == "1")
                            {
                                firma = true;
                            }
                            else if (row.Cells["Firma"].Value.ToString() == "0")
                            {
                                firma = false;
                            }
                            if (row.Cells["Timbre"].Value.ToString() == "1")
                            {
                                timbre = true;
                            }
                            else if (row.Cells["Timbre"].Value.ToString() == "0")
                            {
                                timbre = false;
                            }
                            string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                            orden = DateTime.Now.TimeOfDay.ToString();
                            System.Threading.Thread.Sleep(10);
                            actualizar = new ArchivoCartaDAL().DescargaHabilitados(fecha_rendicion, fecha_notificacion, fecha_descarga, habilitado, estado_rechazado, firma, timbre, Sesion.IdUsuario, orden, "HAB", fun);
                        }
                        if (actualizar >= 1)
                        {
                            ExportarExcel(dgvDescargaAutomatica, "DescargaHabilitadosCarta.xlsx");
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
                    MessageBox.Show("Error al eliminar la fila seleccionada. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    System.Data.DataTable consulta = new ArchivoCartaDAL().VerParaDescargaFueraPlazo(txtFunDescargarFueraPlazo.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros del FUN ingresado.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFunDescargarFueraPlazo.Text = "";
                        txtFunDescargarFueraPlazo.Focus();
                    }
                    else
                    {
                        string firma = "", timbre = "";
                        string fecha_rendicion = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                        foreach (System.Data.DataRow item in consulta.Rows)
                        {
                            if (string.IsNullOrWhiteSpace(item["sa_archivo_carta_firma"].ToString()) || item["sa_archivo_carta_firma"].ToString() == "False")
                            {
                                firma = "0";
                            }
                            else
                            {
                                firma = "1";
                            }
                            if (string.IsNullOrWhiteSpace(item["sa_archivo_carta_timbre"].ToString()) || item["sa_archivo_carta_timbre"].ToString() == "False")
                            {
                                timbre = "0";
                            }
                            else
                            {
                                timbre = "1";
                            }
                            if (dgvDescargarFueraPlazo.Rows.Count == 0)
                            {
                                ubicacionDFP = 0;
                            }
                            else
                            {
                                ubicacionDFP += 1;
                            }
                            dgvDescargarFueraPlazo.Rows.Add(txtFunDescargarFueraPlazo.Text, item["sa_archivo_carta_nombre_empresa"].ToString(), item["sa_archivo_carta_direccion_empresa"].ToString(),
                                item["sa_archivo_carta_comuna_empresa"].ToString(), item["sa_archivo_carta_rut_afiliado"].ToString(), "Habilitado F.P.",
                                Convert.ToDateTime(fecha_rendicion).ToShortDateString().Replace("/", "-"), "", firma, timbre);
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
                    bool firma = false, timbre = false, estado_fecha = true, estado_timbre = true, estado_firma = true;
                    foreach (DataGridViewRow row in dgvDescargarFueraPlazo.Rows)
                    {
                        //campo fecha vacio
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
                        if (estado_fecha == true)
                        {
                            //firma
                            if (row.Cells[8].Value.ToString() != "1" && row.Cells[8].Value.ToString() != "0")
                            {
                                MessageBox.Show("Hay un campo de Firma que contiene un valor que no corresponde.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dgvDescargarFueraPlazo.CurrentCell = dgvDescargarFueraPlazo.Rows[row.Index].Cells[8];
                                estado_firma = false;
                                break;
                            }

                            if (estado_firma == true)
                            {
                                //timbre
                                if (row.Cells[9].Value.ToString() != "1" && row.Cells[9].Value.ToString() != "0")
                                {
                                    MessageBox.Show("Hay un campo de Timbre que contiene un valor que no corresponde.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    dgvDescargarFueraPlazo.CurrentCell = dgvDescargarFueraPlazo.Rows[row.Index].Cells[9];
                                    estado_timbre = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (estado_fecha == true && estado_firma == true && estado_timbre == true)
                    {
                        string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                        foreach (DataGridViewRow row in dgvDescargarFueraPlazo.Rows)
                        {
                            string fun = row.Cells["FUN"].Value.ToString();
                            string fecha_rendicion = row.Cells["Fecha Rendición"].Value.ToString();
                            string fecha_notificacion = row.Cells["Fecha Notificación"].Value.ToString();
                            int motivo = 3; //fuera de plazo, defecto
                            if (row.Cells["Firma"].Value.ToString() == "1")
                            {
                                firma = true;
                            }
                            else if (row.Cells["Firma"].Value.ToString() == "0")
                            {
                                firma = false;
                            }
                            if (row.Cells["Timbre"].Value.ToString() == "1")
                            {
                                timbre = true;
                            }
                            else if (row.Cells["Timbre"].Value.ToString() == "0")
                            {
                                timbre = false;
                            }
                            orden = DateTime.Now.TimeOfDay.ToString();
                            System.Threading.Thread.Sleep(10);
                            actualizar = new ArchivoCartaDAL().ActualizarFueraPlazo(fecha_rendicion, fecha_notificacion, fecha_descarga, motivo, firma, timbre, Sesion.IdUsuario, orden, "FPL", fun);
                        }
                        ExportarExcel(dgvDescargarFueraPlazo, "descargarFueraPlazoCarta.xlsx");
                        MessageBox.Show("Datos actualizados correctamente.", "DATOS ACTUALIZADOS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_todo();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al ingresar los datos actualizados.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error al eliminar la fila seleccionada. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string firma = "", timbre = "";
                    int estado_rechazado = Convert.ToInt32(cmbDescargarRechazados.SelectedValue.ToString());
                    string fecha_rendicion = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    System.Data.DataTable consulta = new ArchivoCartaDAL().BuscarDatosFun(txtFunDescargarRechazados.Text);
                    foreach (System.Data.DataRow item in consulta.Rows)
                    {
                        if (string.IsNullOrWhiteSpace(item["sa_archivo_carta_firma"].ToString()) || item["sa_archivo_carta_firma"].ToString() == "False")
                        {
                            firma = "0";
                        }
                        else
                        {
                            firma = "1";
                        }
                        if (string.IsNullOrWhiteSpace(item["sa_archivo_carta_timbre"].ToString()) || item["sa_archivo_carta_timbre"].ToString() == "False")
                        {
                            timbre = "0";
                        }
                        else
                        {
                            timbre = "1";
                        }
                        if (cmbDescargarRechazados.Text == "02    Falta Firma Cotizante" || cmbDescargarRechazados.Text == "03    Trabajador Finiquitado" ||
                            cmbDescargarRechazados.Text == "04    Empresa Inubicable" || cmbDescargarRechazados.Text == "08    Se niega a Notificar" ||
                            cmbDescargarRechazados.Text == "12    No pertenece a la Empresa" || cmbDescargarRechazados.Text == "17    Pensionado sin saldo Cuenta" ||
                            cmbDescargarRechazados.Text == "19    No es Pensionado de la Institución" || cmbDescargarRechazados.Text == "53    Trabajador Finiquitado (sin fecha finiquito)")
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
                        dgvDescargarRechazados.Rows.Add(txtFunDescargarRechazados.Text, item["sa_archivo_carta_nombre_empresa"].ToString(), item["sa_archivo_carta_direccion_empresa"].ToString(),
                                item["sa_archivo_carta_comuna_empresa"].ToString(), item["sa_archivo_carta_rut_afiliado"].ToString(), cmbDescargarRechazados.Text,
                                Convert.ToDateTime(fecha_rendicion).ToShortDateString().Replace("/", "-"), "", "", firma, timbre, estado_rechazado);
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
                    bool firma = false, timbre = false;
                    string fecha_finiquito = "";
                    string fecha_descarga = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                    bool estado_fecha = true, estado_firma = true, estado_timbre = true, estado_fecha_rechazo = true;
                    foreach (DataGridViewRow row in dgvDescargarRechazados.Rows)
                    {
                        //campo fecha vacio
                        if (row.Cells[7].Value == null || row.Cells[7].Value.ToString() == "")
                        {
                            MessageBox.Show("Hay un campo de fecha que está sin completar. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                        else if (row.Cells[7].Value.ToString().Length > 10 || row.Cells[7].Value.ToString().Length < 10)
                        {
                            //campo de fecha menor o mayor que 10 (10-10-2017)
                            MessageBox.Show("Campo de fecha con valor incorrecto. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[7];
                            estado_fecha = false;
                            break;
                        }
                        else if (row.Cells[5].Value.ToString() == "02    Falta Firma Cotizante" || row.Cells[5].Value.ToString() == "03    Trabajador Finiquitado"
                            || row.Cells[5].Value.ToString() == "04    Empresa Inubicable" || row.Cells[5].Value.ToString() == "08    Se niega a Notificar"
                            || row.Cells[5].Value.ToString() == "12    No pertenece a la Empresa" || row.Cells[5].Value.ToString() == "17    Pensionado sin saldo Cuenta"
                            || row.Cells[5].Value.ToString() == "19    No es Pensionado de la Institución" || row.Cells[5].Value.ToString() == "53    Trabajador Finiquitado (sin fecha finiquito)")
                        {
                            if (row.Cells[8].Value.ToString().Length > 10 || row.Cells[8].Value.ToString().Length < 10 || row.Cells[8].Value.ToString() == "" || row.Cells[8].Value == null)
                            {
                                //fecha finiquito
                                MessageBox.Show("Campo de fecha con valor incorrecto. El error está en la fila que se ha marcado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[8];
                                estado_fecha_rechazo = false;
                                break;
                            }
                        }
                        if (estado_fecha == true && estado_fecha_rechazo == true)
                        {
                            //firma
                            if (row.Cells[9].Value.ToString() != "1" && row.Cells[9].Value.ToString() != "0")
                            {
                                MessageBox.Show("Hay un campo de Firma que contiene un valor que no corresponde.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[9];
                                estado_firma = false;
                                break;
                            }

                            if (estado_firma == true)
                            {
                                //timbre
                                if (row.Cells[10].Value.ToString() != "1" && row.Cells[10].Value.ToString() != "0")
                                {
                                    MessageBox.Show("Hay un campo de Timbre que contiene un valor que no corresponde.", "VALOR NO VÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    dgvDescargarRechazados.CurrentCell = dgvDescargarRechazados.Rows[row.Index].Cells[10];
                                    estado_timbre = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (estado_fecha == true && estado_timbre == true && estado_firma == true && estado_fecha_rechazo == true)
                    {
                        string fecha_rechazo = DateTime.Now.Date.ToString("dd-MM-yyyy");
                        foreach (DataGridViewRow row in dgvDescargarRechazados.Rows)
                        {
                            string fun = row.Cells["FUN"].Value.ToString();
                            string fecha_rendicion = row.Cells["Fecha Rendición"].Value.ToString();
                            string fecha_notificacion = row.Cells["Fecha Notificación"].Value.ToString();
                            if (row.Cells["Fecha Finiquito"].Value.ToString() == "")
                            {
                                fecha_finiquito = "";
                            }
                            else
                            {
                                fecha_finiquito = Convert.ToDateTime(row.Cells["Fecha Finiquito"].Value.ToString()).ToShortDateString().Replace("/", "-");
                            }
                            if (row.Cells["Firma"].Value.ToString() == "1")
                            {
                                firma = true;
                            }
                            else if (row.Cells["Firma"].Value.ToString() == "0")
                            {
                                firma = false;
                            }
                            if (row.Cells["Timbre"].Value.ToString() == "1")
                            {
                                timbre = true;
                            }
                            else if (row.Cells["Timbre"].Value.ToString() == "0")
                            {
                                timbre = false;
                            }
                            int codigo_rechazo = Convert.ToInt32(row.Cells["codigo_rechazo"].Value.ToString());
                            int rechazado = 4; //rechazado
                            orden = DateTime.Now.TimeOfDay.ToString();
                            System.Threading.Thread.Sleep(10);
                            actualizar = new ArchivoCartaDAL().DescargarRechazado(fecha_rendicion, fecha_notificacion, fecha_descarga, fecha_finiquito, fecha_rechazo, rechazado, codigo_rechazo, firma, timbre, Sesion.IdUsuario, orden, "REC", fun);
                        }
                        if (actualizar >= 1)
                        {
                            ExportarExcel(dgvDescargarRechazados, "DescargaRechazadosCarta.xlsx");
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
                    MessageBox.Show("Error al eliminar la fila seleccionada. Detalle: " + ex.Message, "ERROR AL ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else if (dgvDescargaAutomatica.CurrentCell.ColumnIndex == 9)
                {
                    txtFunDescargaAutomatica.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void DgvDescargarRechazados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDescargarRechazados.Rows.Count > 0)
                {
                    if (dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "02    Falta Firma Cotizante" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "03    Trabajador Finiquitado" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "04    Empresa Inubicable" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "08    Se niega a Notificar" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "12    No pertenece a la Empresa" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "17    Pensionado sin saldo Cuenta" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "19    No es Pensionado de la Institución" ||
                        dgvDescargarRechazados.CurrentRow.Cells["Motivo"].Value.ToString() == "53    Trabajador Finiquitado (sin fecha finiquito)")
                    {
                        dgvDescargarRechazados.Columns["Fecha Finiquito"].ReadOnly = false;
                    }
                    else
                    {
                        dgvDescargarRechazados.Columns["Fecha Finiquito"].ReadOnly = true;
                    }
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
                else if (dgvDescargarFueraPlazo.CurrentCell.ColumnIndex == 9)
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
                if (dgvDescargarRechazados.CurrentCell.ColumnIndex == 7)
                {
                    if (!string.IsNullOrWhiteSpace(dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value.ToString()))
                    {
                        int anio = DateTime.Now.Year;
                        string valor = dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value.ToString();
                        dgvDescargarRechazados.CurrentRow.Cells["Fecha Notificación"].Value = valor + "-" + anio;
                    }
                }
                else if (dgvDescargarRechazados.CurrentCell.ColumnIndex == 10)
                {
                    txtFunDescargarRechazados.Focus();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}