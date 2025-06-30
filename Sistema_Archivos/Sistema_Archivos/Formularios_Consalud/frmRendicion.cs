using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmRendicion : Form
    {
        public frmRendicion()
        {
            InitializeComponent();
        }

        private void frmRendicion_Load(object sender, EventArgs e)
        {
            txtFun.Focus();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
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
                    DataTable consulta = new ArchivoDAL().BuscarRendicion(txtFun.Text);
                    if (consulta.Rows.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado registros con el FUN ingresado.", "SIN RESULTADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFun.Focus();
                        txtFun.Text = "";
                    }
                    else
                    {
                        foreach (DataRow item in consulta.Rows)
                        {
                            txtFun.ReadOnly = true;
                            txtFechaRendicion.ReadOnly = false;
                            txtComunaE.Text = item["sa_archivo_comuna_empresa"].ToString();
                            txtDireccionE.Text = item["sa_archivo_direccion_empresa"].ToString();
                            txtFechaCarga.Text = item["sa_archivo_fecha_carga"].ToString();
                            txtFechaIngreso.Text = item["sa_archivo_fecha_ingreso"].ToString();
                            txtFechaRendicion.Text = item["sa_archivo_fecha_rendicion"].ToString();
                            txtNombreE.Text = item["sa_archivo_nombre_empresa"].ToString();
                            txtNotificador.Text = item["sa_notificador_nombre"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_rut_afiliado"].ToString();
                            txtTipoFun.Text = item["sa_tipo_fun"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de verificar el FUN. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        public void limpiar()
        {
            txtComunaE.Text = "";
            txtDireccionE.Text = "";
            txtFechaCarga.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaRendicion.Text = "";
            txtFun.Text = "";
            txtFun.Focus();
            txtNombreE.Text = "";
            txtNotificador.Text = "";
            txtRutAfiliado.Text = "";
            txtTipoFun.Text = "";
            txtFechaRendicion.ReadOnly = true;
            txtFun.ReadOnly = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFechaRendicion.Text))
                {
                    MessageBox.Show("Ingrese la fecha de Rendición.", "CAMPO VACÍO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFechaRendicion.Focus();
                }
                else
                {
                    int actualizar = new ArchivoDAL().ActualizarFechaRendicion(txtFechaRendicion.Text, txtFun.Text);
                    MessageBox.Show("Actualización correcta.", "INFO ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    limpiar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al momento de actualizar la fecha Rendición.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2030'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}