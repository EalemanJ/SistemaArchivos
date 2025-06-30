using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmModificarFunCarta : Form
    {
        public frmModificarFunCarta()
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
                    DataTable consulta = new ArchivoCartaDAL().BuscarFUNNotificador(txtFun.Text);
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
                            if (VerificarInubicable(item["sa_archivo_carta_rut_afiliado"].ToString()))
                            {
                                MessageBox.Show("El folio está en estado inubicable.", "INUBICABLE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            txtFun.ReadOnly = true;
                            txtComuna.Text = item["sa_archivo_carta_comuna_empresa"].ToString();
                            txtDireccionDG.Text = item["sa_archivo_carta_direccion_dg"].ToString();
                            txtDireccionEmpresa.Text = item["sa_archivo_carta_direccion_empresa"].ToString();
                            txtFechaCarga.Text = item["sa_archivo_carta_fecha_carga"].ToString();
                            txtFechaDG.Text = item["sa_archivo_carta_fecha_dg"].ToString();
                            txtFechaFiniquito.Text = item["sa_archivo_carta_fecha_finiquito"].ToString();
                            txtFechaIngreso.Text = item["sa_archivo_carta_fecha_ingreso"].ToString();
                            txtFechaNotificacion.Text = item["sa_archivo_carta_fecha_notificacion"].ToString();
                            txtFechaProceso.Text = item["sa_archivo_carta_fecha_proceso"].ToString();
                            txtFechaRechazo.Text = item["sa_archivo_carta_fecha_rechazo"].ToString();
                            txtNombreEmpresa.Text = item["sa_archivo_carta_nombre_empresa"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_carta_rut_afiliado"].ToString();
                            txtFechaDescarga.Text = item["sa_archivo_carta_fecha_descarga"].ToString();
                            cmbMotivo.Enabled = true;
                            cmbObervacion.Enabled = true;
                            cbFirma.Enabled = true;
                            cbTimbre.Enabled = true;
                            string firma = item["sa_archivo_carta_firma"].ToString();
                            string timbre = item["sa_archivo_carta_timbre"].ToString();
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
                            cmbNuevoNotificador.Enabled = true;
                            //motivos consalud
                            cmbMotivo.DataSource = new MotivoDAL().CargarListaSeleccionadoCarta(txtFun.Text);
                            cmbMotivo.DisplayMember = "sa_motivo_desc";
                            cmbMotivo.ValueMember = "sa_motivo";
                            //estados rechazados
                            cmbObervacion.DataSource = new EstadoRechazadoDAL().CargarListaSeleccionadoCarta(txtFun.Text);
                            cmbObervacion.ValueMember = "sa_estados";
                            cmbObervacion.DisplayMember = "sa_estados_desc";
                            //notificador
                            cmbNuevoNotificador.DataSource = new NotificadorDAL().NotificadorCarta(txtFun.Text);
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

        public bool VerificarInubicable(string rut)
        {
            try
            {
                DataTable consulta = new ArchivoCartaDAL().VerInubicable(rut);
                if (consulta.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
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
                    int notificador = Convert.ToInt32(cmbNuevoNotificador.SelectedValue.ToString());
                    int motivo = Convert.ToInt32(cmbMotivo.SelectedValue.ToString());
                    int rechazo = Convert.ToInt32(cmbObervacion.SelectedValue.ToString());
                    if (cmbMotivo.Text != "Rechazado")
                    {
                        actualizar_todo = new ArchivoCartaDAL().ActualizarTodo(txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, 1, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNotificacion.Text,
                        txtFechaDG.Text, txtFechaProceso.Text, txtFechaRendicion.Text, txtFechaRechazo.Text, txtFechaFiniquito.Text, txtFechaDescarga.Text,
                        cbFirma.Checked, cbTimbre.Checked, notificador, txtFun.Text);
                        int eliminar = new ArchivoCartaDAL().EliminarRechazado(txtRutAfiliado.Text);
                    }
                    else
                    {
                        actualizar_todo = new ArchivoCartaDAL().ActualizarTodo(txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, rechazo, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNotificacion.Text,
                        txtFechaDG.Text, txtFechaProceso.Text, txtFechaRendicion.Text, txtFechaRechazo.Text, txtFechaFiniquito.Text, txtFechaDescarga.Text,
                        cbFirma.Checked, cbTimbre.Checked, notificador, txtFun.Text);
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
            cmbMotivo.Enabled = false;
            cmbObervacion.Enabled = false;
            cbFirma.Enabled = false;
            cbTimbre.Enabled = false;
            cbFirma.Checked = false;
            cbTimbre.Checked = false;
            cmbNuevoNotificador.Enabled = false;
            txtFechaDescarga.ReadOnly = true;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void PbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2022'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}