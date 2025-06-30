using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmModificarFun : Form
    {
        public frmModificarFun()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFun.Text))
                {
                    MessageBox.Show("Ingrese el Fun para buscar.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFun.Focus();
                }
                else
                {
                    DataTable consulta = new ArchivoDAL().BuscarFUNNotificador(txtFun.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFun.Text = "";
                        txtFun.Focus();
                    }
                    else
                    {
                        foreach (DataRow item in consulta.Rows)
                        {
                            if (Sesion.VerificarInubicable(item["sa_archivo_rut_afiliado"].ToString()))
                            {
                                MessageBox.Show("El folio está en estado inubicable.", "INUBICABLE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            txtFun.ReadOnly = true;
                            txtComuna.Text = item["sa_archivo_comuna_empresa"].ToString();
                            txtDireccionDG.Text = item["sa_archivo_direccion_dg"].ToString();
                            txtDireccionEmpresa.Text = item["sa_archivo_direccion_empresa"].ToString();
                            txtFechaCarga.Text = item["sa_archivo_fecha_carga"].ToString();
                            txtFechaDG.Text = item["sa_archivo_fecha_dg"].ToString();
                            txtFechaFiniquito.Text = item["sa_archivo_fecha_finiquito"].ToString();
                            txtFechaIngreso.Text = item["sa_archivo_fecha_ingreso"].ToString();
                            txtFechaNotificacion.Text = item["sa_archivo_fecha_notificacion"].ToString();
                            txtFechaProceso.Text = item["sa_archivo_fecha_proceso"].ToString();
                            txtFechaRechazo.Text = item["sa_archivo_fecha_rechazo"].ToString();
                            txtNombreEmpresa.Text = item["sa_archivo_nombre_empresa"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_rut_afiliado"].ToString();
                            txtFechaDescarga.Text = item["sa_archivo_fecha_descarga"].ToString();
                            txtTipoFun.Text = item["sa_tipo_fun"].ToString();
                            cmbMotivo.Enabled = true;
                            cmbObervacion.Enabled = true;
                            cbFirma.Enabled = true;
                            cbTimbre.Enabled = true;
                            string firma = item["sa_archivo_firma"].ToString();
                            string timbre = item["sa_archivo_timbre"].ToString();
                            if (string.IsNullOrWhiteSpace(firma) || firma == "False")
                            {
                                cbFirma.Checked = false;
                            }
                            else
                            {
                                cbFirma.Checked = true;
                            }
                            if (string.IsNullOrWhiteSpace(timbre) || timbre == "False")
                            {
                                cbTimbre.Checked = false;
                            }
                            else
                            {
                                cbTimbre.Checked = true;
                            }
                            txtFechaRendicion.Text = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                            txtComuna.ReadOnly = false;
                            txtDireccionDG.ReadOnly = false;
                            txtDireccionEmpresa.ReadOnly = false;
                            txtFechaCarga.ReadOnly = false;
                            txtFechaDG.ReadOnly = false;
                            txtFechaFiniquito.ReadOnly = false;
                            txtFechaIngreso.ReadOnly = false;
                            txtFechaNotificacion.ReadOnly = false;
                            txtFechaProceso.ReadOnly = false;
                            txtFechaRechazo.ReadOnly = false;
                            txtNombreEmpresa.ReadOnly = false;
                            txtRutAfiliado.ReadOnly = false;
                            txtFechaDescarga.ReadOnly = false;
                            txtTipoFun.ReadOnly = false;
                            cmbNuevoNotificador.Enabled = true;
                            //motivos consalud
                            cmbMotivo.DataSource = new MotivoDAL().CargarListaSeleccionado(txtFun.Text);
                            cmbMotivo.DisplayMember = "sa_motivo_desc";
                            cmbMotivo.ValueMember = "sa_motivo";
                            //estados rechazados
                            cmbObervacion.DataSource = new EstadoRechazadoDAL().CargarListaSeleccionado(txtFun.Text);
                            cmbObervacion.ValueMember = "sa_estados";
                            cmbObervacion.DisplayMember = "sa_estados_desc";
                            //notificador
                            cmbNuevoNotificador.DataSource = new NotificadorDAL().NotificadorConsalud(txtFun.Text);
                            cmbNuevoNotificador.ValueMember = "sa_notificador";
                            cmbNuevoNotificador.DisplayMember = "sa_notificador_nombre";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmModificarFun_Load(object sender, EventArgs e)
        {
            txtFun.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            txtFun.Text = "";
            txtFun.ReadOnly = false;
            txtFun.Focus();
            txtComuna.Text = "";
            txtDireccionDG.Text = "";
            txtDireccionEmpresa.Text = "";
            txtFechaCarga.Text = "";
            txtFechaDG.Text = "";
            txtFechaFiniquito.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaNotificacion.Text = "";
            txtFechaProceso.Text = "";
            txtFechaRechazo.Text = "";
            txtFechaRendicion.Text = "";
            txtNombreEmpresa.Text = "";
            txtRutAfiliado.Text = "";
            txtTipoFun.Text = "";
            txtComuna.ReadOnly = true;
            txtDireccionDG.ReadOnly = true;
            txtDireccionEmpresa.ReadOnly = true;
            txtFechaCarga.ReadOnly = true;
            txtFechaDG.ReadOnly = true;
            txtFechaFiniquito.ReadOnly = true;
            txtFechaIngreso.ReadOnly = true;
            txtFechaNotificacion.ReadOnly = true;
            txtFechaProceso.ReadOnly = true;
            txtFechaRechazo.ReadOnly = true;
            txtFechaRendicion.ReadOnly = true;
            txtNombreEmpresa.ReadOnly = true;
            txtRutAfiliado.ReadOnly = true;
            txtTipoFun.ReadOnly = true;
            txtFechaDescarga.ReadOnly = true;
            cmbMotivo.Enabled = false;
            cmbObervacion.Enabled = false;
            cbFirma.Enabled = false;
            cbTimbre.Enabled = false;
            cbFirma.Checked = false;
            cbTimbre.Checked = false;
            cmbNuevoNotificador.Enabled = false;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFun.Text))
                {
                    MessageBox.Show("No hay datos para poder actualizar.", "SIN REGISTROS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int actualizar_todo = 0;
                    int tipo_fun = Convert.ToInt32(txtTipoFun.Text);
                    int notificador = Convert.ToInt32(cmbNuevoNotificador.SelectedValue.ToString());
                    int motivo = Convert.ToInt32(cmbMotivo.SelectedValue.ToString());
                    int rechazo = Convert.ToInt32(cmbObervacion.SelectedValue.ToString());
                    if (cmbMotivo.Text != "Rechazado")
                    {
                        //NO ESTÁ RECHAZADO (HABILITADO)
                        actualizar_todo = new ArchivoDAL().ActualizarTodo(tipo_fun, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, 1, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNotificacion.Text,
                        txtFechaDG.Text, txtFechaProceso.Text, txtFechaRendicion.Text, txtFechaRechazo.Text, txtFechaFiniquito.Text, txtFechaDescarga.Text,
                        cbFirma.Checked, cbTimbre.Checked, notificador, txtFun.Text);
                        int eliminar = new ArchivoDAL().EliminarRechazado(txtRutAfiliado.Text);
                    }
                    else
                    {
                        //RECHAZADO
                        actualizar_todo = new ArchivoDAL().ActualizarTodo(tipo_fun, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, rechazo, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNotificacion.Text,
                        txtFechaDG.Text, txtFechaProceso.Text, txtFechaRendicion.Text, txtFechaRechazo.Text, txtFechaFiniquito.Text, txtFechaDescarga.Text,
                        cbFirma.Checked, cbTimbre.Checked, notificador, txtFun.Text);
                        if (rechazo == 7)
                        {
                            if (!Sesion.VerificarInubicable(txtRutAfiliado.Text))
                            {
                                int inserta = new ArchivoDAL().IngresaInubicable(txtRutAfiliado.Text);
                            }
                        }
                    }
                    if (actualizar_todo >= 1)
                    {
                        MessageBox.Show("Información actualizada con éxito.", "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2022'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void TxtTipoFun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CmbMotivo_TextChanged(object sender, EventArgs e)
        {
            if (cmbMotivo.Text == "Rechazado")
            {
                cmbObervacion.Enabled = true;
            }
            else
            {
                cmbObervacion.Enabled = false;
            }
        }
    }
}