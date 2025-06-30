using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmModificarFunColmena : Form
    {
        public frmModificarFunColmena()
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
                    if (cmbMotivo.Text != "Rechazado")
                    {
                        actualizar_todo = new ArchivoColmenaDAL().ActualizarTodo(tipo_fun, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, 1, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNotificacion.Text,
                        txtFechaDG.Text, txtFechaProceso.Text, txtFechaRendicion.Text, txtFechaRechazo.Text, txtFechaFiniquito.Text, txtFechaDescarga.Text,
                        notificador, txtFun.Text);
                    }
                    else
                    {
                        actualizar_todo = new ArchivoColmenaDAL().ActualizarTodo(tipo_fun, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text,
                        txtComuna.Text, motivo, rechazo, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNotificacion.Text,
                        txtFechaDG.Text, txtFechaProceso.Text, txtFechaRendicion.Text, txtFechaRechazo.Text, txtFechaFiniquito.Text, txtFechaDescarga.Text,
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
                    DataTable consulta = new ArchivoColmenaDAL().BuscarFUNNotificador(txtFun.Text);
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
                            txtComuna.Text = item["sa_archivo_colmena_comuna_empresa"].ToString();
                            txtDireccionDG.Text = item["sa_archivo_colmena_direccion_dg"].ToString();
                            txtDireccionEmpresa.Text = item["sa_archivo_colmena_direccion_empresa"].ToString();
                            txtFechaCarga.Text = item["sa_archivo_colmena_fecha_carga"].ToString();
                            txtFechaDG.Text = item["sa_archivo_colmena_fecha_dg"].ToString();
                            txtFechaFiniquito.Text = item["sa_archivo_colmena_fecha_finiquito"].ToString();
                            txtFechaIngreso.Text = item["sa_archivo_colmena_fecha_ingreso"].ToString();
                            txtFechaNotificacion.Text = item["sa_archivo_colmena_fecha_notificacion"].ToString();
                            txtFechaProceso.Text = item["sa_archivo_colmena_fecha_proceso"].ToString();
                            txtFechaRechazo.Text = item["sa_archivo_colmena_fecha_rechazo"].ToString();
                            txtNombreEmpresa.Text = item["sa_archivo_colmena_nombre_empresa"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_colmena_rut_afiliado"].ToString();
                            txtTipoFun.Text = item["sa_archivo_colmena_tipo_fun"].ToString();
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
                            //estado rechazado colmena...OK
                            cmbObervacion.DataSource = new EstadoRechazadoColmenaDAL().CargarListaSeleccionadoRechazado(txtFun.Text);
                            cmbObervacion.ValueMember = "sa_estado_rechazado_colmena";
                            cmbObervacion.DisplayMember = "sa_estado_rechazado_colmena_desc";
                            //cargar notificadores
                            cmbNuevoNotificador.DataSource = new NotificadorDAL().NotificadorColmena(txtFun.Text);
                            cmbNuevoNotificador.ValueMember = "sa_notificador";
                            cmbNuevoNotificador.DisplayMember = "sa_notificador_nombre";
                            //motivos
                            cmbMotivo.DataSource = new MotivoDAL().CargarListaSeleccionadoColmena(txtFun.Text);
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

        private void frmModificarFunColmena_Load(object sender, EventArgs e)
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