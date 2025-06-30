using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmIngresoCarta : Form
    {
        public frmIngresoCarta()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar_y_cargar();
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
            txtFechaIngreso.Text = DateTime.Now.ToString("dd-MM-yyyy");
            cbFirma.Checked = false;
            cbTimbre.Checked = false;
            cbFirma.Enabled = false;
            cbTimbre.Enabled = false;
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
            btnIngresar.Enabled = false;
            cmbMotivo.Enabled = false;
            cmbObservacion.Enabled = false;
            cmbNotificador.Enabled = false;
        }

        private void BtnVolverCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Cargar_listas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar las listas. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cargar_listas()
        {
            cmbMotivo.DataSource = new MotivoDAL().BuscarMotivos();
            cmbMotivo.DisplayMember = "sa_motivo_desc";
            cmbMotivo.ValueMember = "sa_motivo";

            cmbObservacion.DataSource = new EstadoRechazadoDAL().VerEstadosRechazado();
            cmbObservacion.DisplayMember = "sa_estados_desc";
            cmbObservacion.ValueMember = "sa_estados";

            cmbNotificador.DataSource = new NotificadorDAL().VerNotificadores();
            cmbNotificador.DisplayMember = "sa_notificador_nombre";
            cmbNotificador.ValueMember = "sa_notificador";
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
                    DataTable consulta = new ArchivoCartaDAL().BuscarFUN(txtFun.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        cbFirma.Enabled = true;
                        cbTimbre.Enabled = true;
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

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFun.Text))
                {
                    MessageBox.Show("Ingrese el código de FUN.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
                {
                    MessageBox.Show("Ingrese el nombre de la empresa.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(txtComunaEmpresa.Text))
                {
                    MessageBox.Show("Ingrese la comuna de la empresa.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(txtDireccionEmpresa.Text))
                {
                    MessageBox.Show("Ingrese la dirección de la empresa.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(txtRutAfiliado.Text))
                {
                    MessageBox.Show("Ingrese el RUT del afiliado.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(txtFechaIngreso.Text))
                {
                    MessageBox.Show("Ingrese la fecha de Ingreso. Recuerde que el formato es 'dd-MM-yyyy'.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string fecha_rendicion = "";
                    string fecha_descarga = "";
                    int motivo = Convert.ToInt32(cmbMotivo.SelectedValue.ToString());
                    int notificador = Convert.ToInt32(cmbNotificador.SelectedValue.ToString());
                    if (cmbMotivo.Text == "Habilitado")
                    {
                        int estado_rechazo = 1; //estado por defecto
                        int ingresar = new ArchivoCartaDAL().Ingreso(txtFun.Text, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text, txtComunaEmpresa.Text,
                            motivo, estado_rechazo, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNoti.Text, txtFechaDG.Text, txtFechaProceso.Text, fecha_rendicion,
                            txtfechaRechazo.Text, txtFechaFiniquito.Text, fecha_descarga, cbFirma.Checked, cbTimbre.Checked, notificador, Sesion.IdUsuario);
                        MessageBox.Show("Ingreso correcto.", "INFORMACIÓN INGRESADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_y_cargar();
                    }
                    else if (cmbMotivo.Text != "Habilitado")
                    {
                        int estado_rechazado = Convert.ToInt32(cmbObservacion.SelectedValue.ToString());
                        int ingresar = new ArchivoCartaDAL().Ingreso(txtFun.Text, txtRutAfiliado.Text, txtNombreEmpresa.Text, txtDireccionEmpresa.Text, txtComunaEmpresa.Text,
                            motivo, estado_rechazado, txtDireccionDG.Text, txtFechaIngreso.Text, txtFechaCarga.Text, txtFechaNoti.Text, txtFechaDG.Text, txtFechaProceso.Text, fecha_rendicion,
                            txtfechaRechazo.Text, txtFechaFiniquito.Text, fecha_descarga, cbFirma.Checked, cbTimbre.Checked, notificador, Sesion.IdUsuario);
                        MessageBox.Show("Ingreso correcto.", "INFORMACIÓN INGRESADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Limpiar_y_cargar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmIngresoCarta_Load(object sender, EventArgs e)
        {
            try
            {
                cmbMotivo.Enabled = false;
                cmbNotificador.Enabled = false;
                cmbObservacion.Enabled = false;
                txtFechaIngreso.Text = DateTime.Now.Date.ToShortDateString().Replace("/", "-");
                Limpiar_y_cargar();
                Cargar_listas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2022'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}