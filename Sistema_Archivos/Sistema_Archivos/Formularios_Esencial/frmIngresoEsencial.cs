using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmIngresoEsencial : Form
    {
        public frmIngresoEsencial()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_y_cargar();
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

        private void BtnVolverCargar_Click(object sender, EventArgs e)
        {
            Cargar_lista();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha_descarga = "";
                if (Validar_campos())
                {
                    int motivo = Convert.ToInt32(cmbMotivo.SelectedValue.ToString());
                    int estado_rechazo = Convert.ToInt32(cmbObservacion.SelectedValue.ToString());
                    int notificador = Convert.ToInt32(cmbNotificador.SelectedValue.ToString());
                    string FecIngreso = "", FecCarga = "", FecNoti = "", FecDg = "", FecProc = "", FecRend = "", FecRechazo = "", FecFiniquito = "";
                    FecIngreso = txtFechaIngreso.Text;
                    FecCarga = txtFechaCarga.Text;
                    FecNoti = txtFechaNoti.Text;
                    FecDg = txtFechaDG.Text;
                    FecProc = txtFechaProceso.Text;
                    FecRend = txtFechaRendicion.Text;
                    FecRechazo = txtfechaRechazo.Text;
                    FecFiniquito = txtFechaFiniquito.Text;

                    FormatoFecha(ref FecIngreso, ref FecCarga, ref FecNoti, ref FecDg, ref FecProc, ref FecRend, ref FecRechazo, ref FecFiniquito);
                    if (cmbMotivo.Text == "Rechazado")
                    {
                        //rechazado
                        int ingreso = new ArchivoEsencial().Ingreso(txtFun.Text, txtTipoFun.Text, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text, txtComunaEmpresa.Text,
                            motivo, estado_rechazo, txtDireccionDG.Text, FecIngreso, FecCarga, FecNoti, FecDg, FecProc, FecRend, FecRechazo, FecFiniquito, fecha_descarga, notificador, Sesion.IdUsuario);
                        MessageBox.Show("Ingreso correcto.", "INFORMACIÓN INGRESADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_y_cargar();
                    }
                    else
                    {
                        //habilitado
                        estado_rechazo = 1; //defecto
                        int ingreso = new ArchivoEsencial().Ingreso(txtFun.Text, txtTipoFun.Text, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text, txtComunaEmpresa.Text,
                            motivo, estado_rechazo, txtDireccionDG.Text, FecIngreso, FecCarga, FecNoti, FecDg, FecProc, FecRend, FecRechazo, FecFiniquito, fecha_descarga, notificador, Sesion.IdUsuario);
                        MessageBox.Show("Ingreso correcto.", "INFORMACIÓN INGRESADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_y_cargar();
                    }
                }
                else
                {
                    MessageBox.Show("Hay campos incompletos. Por favor complete todos los datos básicos.", "CAMPO(S) VACÍO(S)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar_y_cargar();
            }
        }

        public void FormatoFecha(ref string FecIngreso, ref string FecCarga, ref string FecNoti, ref string FecDg, ref string FecProc, ref string FecRend,
            ref string FecRechazo, ref string FecFiniquito)
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
        }

        public bool Validar_campos()
        {
            if (string.IsNullOrWhiteSpace(txtTipoFun.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtComunaEmpresa.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtRutAfiliado.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDireccionEmpresa.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmIngresoesencial_Load(object sender, EventArgs e)
        {
            Cargar_lista();
            Limpiar_y_cargar();
            txtFun.Focus();
        }

        public void Cargar_lista()
        {
            try
            {
                cmbMotivo.DataSource = new MotivoDAL().BuscarMotivos();
                cmbMotivo.DisplayMember = "sa_motivo_desc";
                cmbMotivo.ValueMember = "sa_motivo";

                cmbObservacion.DataSource = new EstadoRechazadoEsencialDAL().VerEstadosRechazado();
                cmbObservacion.DisplayMember = "sa_estado_rechazado_esencial_desc";
                cmbObservacion.ValueMember = "sa_estado_rechazado_esencial";

                cmbNotificador.DataSource = new NotificadorDAL().VerNotificadores();
                cmbNotificador.DisplayMember = "sa_notificador_nombre";
                cmbNotificador.ValueMember = "sa_notificador";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar_y_cargar()
        {
            txtFun.Focus();
            txtFun.Text = "";
            txtComunaEmpresa.Text = "";
            txtDireccionDG.Text = "";
            txtDireccionEmpresa.Text = "";
            txtFechaCarga.Text = "";
            txtFechaDG.Text = "";
            txtFechaFiniquito.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaNoti.Text = "";
            txtFechaProceso.Text = "";
            txtfechaRechazo.Text = "";
            txtNombreEmpresa.Text = "";
            txtRutAfiliado.Text = "";
            txtTipoFun.Text = "";
            txtFechaIngreso.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtComunaEmpresa.Enabled = false;
            txtDireccionDG.Enabled = false;
            txtDireccionEmpresa.Enabled = false;
            txtFechaCarga.Enabled = false;
            txtFechaDG.Enabled = false;
            txtFechaFiniquito.Enabled = false;
            txtFechaIngreso.Enabled = false;
            txtFechaNoti.Enabled = false;
            txtFechaProceso.Enabled = false;
            txtfechaRechazo.Enabled = false;
            txtFechaRendicion.Enabled = false;
            txtNombreEmpresa.Enabled = false;
            txtRutAfiliado.Enabled = false;
            txtTipoFun.Enabled = false;
            btnIngresar.Enabled = false;
            cmbMotivo.Enabled = false;
            cmbObservacion.Enabled = false;
            cmbNotificador.Enabled = false;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFun.Text))
                {
                    MessageBox.Show("Ingrese el código de FUN.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFun.Focus();
                }
                else
                {
                    DataTable consulta = new ArchivoEsencial().BuscarFUN(txtFun.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        txtComunaEmpresa.Enabled = true;
                        txtDireccionDG.Enabled = true;
                        txtDireccionEmpresa.Enabled = true;
                        txtFechaCarga.Enabled = true;
                        txtFechaDG.Enabled = true;
                        txtFechaFiniquito.Enabled = true;
                        txtFechaNoti.Enabled = true;
                        txtFechaProceso.Enabled = true;
                        txtfechaRechazo.Enabled = true;
                        txtFechaRendicion.Enabled = true;
                        txtNombreEmpresa.Enabled = true;
                        txtRutAfiliado.Enabled = true;
                        txtTipoFun.Enabled = true;
                        btnIngresar.Enabled = true;
                        cmbMotivo.Enabled = true;
                        cmbNotificador.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Ya hay un documento con ese número de FUN.", "FUN YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFun.Focus();
                        txtFun.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbMotivo_TextChanged(object sender, EventArgs e)
        {
            if (cmbMotivo.Text == "Habilitado")
            {
                cmbObservacion.Enabled = false;
            }
            else if (cmbMotivo.Text == "Habilitado F.P.")
            {
                cmbObservacion.Enabled = false;
            }
            else if (cmbMotivo.Text == "Sin estado (Por Defecto)")
            {
                cmbObservacion.Enabled = false;
            }
            else
            {
                cmbObservacion.Enabled = true;
            }
        }

        private void PbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2022'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}