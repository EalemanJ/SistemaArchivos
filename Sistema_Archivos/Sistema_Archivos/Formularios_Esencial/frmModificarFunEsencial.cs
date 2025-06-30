using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmModificarFunEsencial : Form
    {
        public frmModificarFunEsencial()
        {
            InitializeComponent();
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
            txtFechaDescarga.ReadOnly = true;
            txtTipoFun.ReadOnly = true;
            cmbMotivo.Enabled = false;
            cmbObervacion.Enabled = false;
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
                    string FecIngreso = "", FecCarga = "", FecNoti = "", FecDg = "", FecProc = "", FecRend = "", FecRechazo = "", FecFiniquito = "", FecDescarga = "";
                    FecIngreso = txtFechaIngreso.Text;
                    FecCarga = txtFechaCarga.Text;
                    FecNoti = txtFechaNotificacion.Text;
                    FecDg = txtFechaDG.Text;
                    FecProc = txtFechaProceso.Text;
                    FecRend = txtFechaRendicion.Text;
                    FecRechazo = txtFechaRechazo.Text;
                    FecFiniquito = txtFechaFiniquito.Text;
                    FecDescarga = txtFechaDescarga.Text;

                    FormatoFecha(ref FecIngreso, ref FecCarga, ref FecNoti, ref FecDg, ref FecProc, ref FecRend, ref FecRechazo, ref FecFiniquito, ref FecDescarga);
                    if (cmbMotivo.Text != "Rechazado")
                    {
                        actualizar_todo = new ArchivoEsencial().ActualizarTodo(tipo_fun, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, 1, txtDireccionDG.Text, FecIngreso, FecCarga, FecNoti, FecDg, FecProc, FecRend, FecRechazo, FecFiniquito, FecDescarga,
                        notificador, txtFun.Text);
                    }
                    else
                    {
                        actualizar_todo = new ArchivoEsencial().ActualizarTodo(tipo_fun, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, rechazo, txtDireccionDG.Text, FecIngreso, FecCarga, FecNoti, FecDg, FecProc, FecRend, FecRechazo, FecFiniquito, FecDescarga,
                        notificador, txtFun.Text);
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

        public void FormatoFecha(ref string FecIngreso, ref string FecCarga, ref string FecNoti, ref string FecDg, ref string FecProc, ref string FecRend,
            ref string FecRechazo, ref string FecFiniquito, ref string FecDescarga)
        {
            if (FecIngreso.Contains("/"))
            {
                FecIngreso = FecIngreso.Replace("/", "-");
            }
            if (FecCarga.Contains("/"))
            {
                FecCarga = FecCarga.Replace("/", "-");
            }
            if (FecNoti.Contains("/"))
            {
                FecNoti = FecNoti.Replace("/", "-");
            }
            if (FecDg.Contains("/"))
            {
                FecDg = FecDg.Replace("/", "-");
            }
            if (FecProc.Contains("/"))
            {
                FecProc = FecProc.Replace("/", "-");
            }
            if (FecRend.Contains("/"))
            {
                FecRend = FecRend.Replace("/", "-");
            }
            if (FecRechazo.Contains("/"))
            {
                FecRechazo = FecRechazo.Replace("/", "-");
            }
            if (FecFiniquito.Contains("/"))
            {
                FecFiniquito = FecFiniquito.Replace("/", "-");
            }
            if (FecDescarga.Contains("/"))
            {
                FecDescarga = FecDescarga.Replace("/", "-");
            }
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
                    DataTable consulta = new ArchivoEsencial().BuscarFUNNotificador(txtFun.Text);
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
                            txtFun.ReadOnly = true;
                            txtComuna.Text = item["sa_archivo_esencial_comuna_empresa"].ToString();
                            txtDireccionDG.Text = item["sa_archivo_esencial_direccion_dg"].ToString();
                            txtDireccionEmpresa.Text = item["sa_archivo_esencial_direccion_empresa"].ToString();
                            txtFechaCarga.Text = item["sa_archivo_esencial_fecha_carga"].ToString();
                            txtFechaDG.Text = item["sa_archivo_esencial_fecha_dg"].ToString();
                            txtFechaFiniquito.Text = item["sa_archivo_esencial_fecha_finiquito"].ToString();
                            txtFechaIngreso.Text = item["sa_archivo_esencial_fecha_ingreso"].ToString();
                            txtFechaNotificacion.Text = item["sa_archivo_esencial_fecha_notificacion"].ToString();
                            txtFechaProceso.Text = item["sa_archivo_esencial_fecha_proceso"].ToString();
                            txtFechaRechazo.Text = item["sa_archivo_esencial_fecha_rechazo"].ToString();
                            txtNombreEmpresa.Text = item["sa_archivo_esencial_nombre_empresa"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_esencial_rut_afiliado"].ToString();
                            txtTipoFun.Text = item["sa_archivo_esencial_tipo_fun"].ToString();
                            cmbMotivo.Enabled = true;
                            cmbObervacion.Enabled = true;
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
                            txtTipoFun.ReadOnly = false;
                            txtFechaDescarga.ReadOnly = false;
                            cmbNuevoNotificador.Enabled = true;
                            //estado rechazado esencial...OK
                            cmbObervacion.DataSource = new EstadoRechazadoEsencialDAL().CargarListaSeleccionadoRechazado(txtFun.Text);
                            cmbObervacion.ValueMember = "sa_estado_rechazado_esencial";
                            cmbObervacion.DisplayMember = "sa_estado_rechazado_esencial_desc";
                            //cargar notificadores
                            cmbNuevoNotificador.DataSource = new NotificadorDAL().Notificadoresencial(txtFun.Text);
                            cmbNuevoNotificador.ValueMember = "sa_notificador";
                            cmbNuevoNotificador.DisplayMember = "sa_notificador_nombre";
                            //motivos
                            cmbMotivo.DataSource = new MotivoDAL().CargarListaSeleccionadoEsencial(txtFun.Text);
                            cmbMotivo.DisplayMember = "sa_motivo_desc";
                            cmbMotivo.ValueMember = "sa_motivo";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmModificarFunesencial_Load(object sender, EventArgs e)
        {
            txtFun.Focus();
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

        private void PbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2022'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}