using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmRendicionCruzBlanca : Form
    {
        public frmRendicionCruzBlanca()
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

        private void BtnVerificar_Click(object sender, EventArgs e)
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
                    DataTable consulta = new ArchivoCruzBlanca().BuscarRendicion(txtFun.Text);
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
                            txtComunaE.Text = item["sa_archivo_Cruz_Blanca_comuna_empresa"].ToString();
                            txtDireccionE.Text = item["sa_archivo_Cruz_Blanca_direccion_empresa"].ToString();
                            txtFechaCarga.Text = item["sa_archivo_Cruz_Blanca_fecha_carga"].ToString();
                            txtFechaIngreso.Text = item["sa_archivo_Cruz_Blanca_fecha_ingreso"].ToString();
                            txtFechaRendicion.Text = item["sa_archivo_Cruz_Blanca_fecha_rendicion"].ToString();
                            txtNombreE.Text = item["sa_archivo_Cruz_Blanca_nombre_empresa"].ToString();
                            txtNotificador.Text = item["sa_notificador_nombre"].ToString();
                            txtRutAfiliado.Text = item["sa_archivo_Cruz_Blanca_rut_afiliado"].ToString();
                            txtTipoFun.Text = item["sa_archivo_Cruz_Blanca_tipo_fun"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de verificar el FUN. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
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
                    int actualizar = new ArchivoCruzBlanca().ActualizarFechaRendicion(txtFechaRendicion.Text.Replace("/", "-"), txtFun.Text);
                    MessageBox.Show("Actualización correcta.", "INFO ACTUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Limpiar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al momento de actualizar la fecha Rendición.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar()
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

        private void PbInformacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El formato de fechas es 'dd-MM-yyyy'. Ejemplo: '10-10-2030'", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}