using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmInicio : Form
    {
        private SqlConnection con;
        public string tipo_error = "";

        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            lblAvisoCarga.Text = "";
            timer1.Start();
            Sesion.ProgressBar = pbCarga;
            //SetState, 1 = normal (green); 2 = error (red); 3 = warning (yellow);
            ModifyProgressBarColor.SetState(1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string mensaje1 = "Cargando archivos de Aplicación";
                string mensaje2 = "Buscando Actualizaciones";
                string mensaje3 = "Cargando configuración";
                string mensaje4 = "Configurando entorno";
                string mensaje5 = "Carga exitosa!";
                pbCarga.Increment(2);
                if (pbCarga.Value <= 100)
                {
                    if (pbCarga.Value == 2)
                    {
                        lblAvisoCarga.Text = mensaje1;
                    }
                    if (pbCarga.Value == 30)
                    {
                        lblAvisoCarga.Text = mensaje2;
                    }
                    if (pbCarga.Value == 36)
                    {
                        if (ConexionInternet())
                        {
                            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                            {
                                if (System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CheckForUpdate())
                                {
                                    timer1.Stop();
                                    DialogResult mensaje = MessageBox.Show("Se ha encontrado una nueva versión de la aplicación. ¿Desea actualizar ahora?", "NUEVA VERSIÓN", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                                    if (mensaje == DialogResult.Yes)
                                    {
                                        DialogResult alerta = MessageBox.Show("Una vez iniciado el proceso de actualización no se podrá detener. ¿Continuar de todas maneras?", "ESPERANDO CONFIRMACIÓN", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                                        if (alerta == DialogResult.Yes)
                                        {
                                            timer1.Stop();
                                            ComprobarUpdate u = new ComprobarUpdate();
                                            u.BuscarActualizacion("arranque");
                                        }
                                        else
                                        {
                                            timer1.Start();
                                        }
                                    }
                                    else
                                    {
                                        timer1.Start();
                                    }
                                }
                            }
                        }
                    }
                    if (pbCarga.Value == 48)
                    {
                        lblAvisoCarga.Text = mensaje3;
                    }
                    if (pbCarga.Value == 60)
                    {
                        if (EstadoConexion(Sesion.CadenaConexion) == false)
                        {
                            //iniciar_servicio();
                            lblAvisoCarga.Text = "NO HAY CONEXIÓN CON EL SERVIDOR";
                            timer1.Stop();
                            ModifyProgressBarColor.SetState(3);
                            MessageBox.Show("No hay conexión con el servidor. Por favor revise el archivo de configuración de la aplicación.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Thread.Sleep(4000);
                            Application.ExitThread();
                        }
                    }
                    if (pbCarga.Value == 74)
                    {
                        lblAvisoCarga.Text = mensaje4;
                    }
                    if (pbCarga.Value == 94)
                    {
                        lblAvisoCarga.Text = mensaje5;
                    }
                    if (pbCarga.Value == 100)
                    {
                        timer1.Stop();
                        Hide();
                        if (Application.OpenForms["frmLogin"] is frmLogin login)
                        {
                            login.Focus();
                        }
                        else
                        {
                            frmLogin login2 = new frmLogin();
                            login2.Show();
                        }
                    }
                }
            }
            catch (Exception)
            {
                tipo_error = "error_general";
                Mensaje_error();
            }
        }

        public void Mensaje_error()
        {
            lblAvisoCarga.Text = "ERROR AL CARGAR LA APLICACIÓN";
            lblAvisoCarga.ForeColor = System.Drawing.Color.Red;
            timer1.Stop();
            ModifyProgressBarColor.SetState(2);
            if (tipo_error == "error_general")
            {
                MessageBox.Show("Se ha detectado un error en la aplicación y se cerrará. Por favor contáctese con el Proveedor del sistema. ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tipo_error == "error_archivos")
            {
                string ruta = @"C:\Program Files\Aleman Informatica\Sistema Fun\";
                //string ruta = @"C:\Program Files (x86)\Aleman Informatica\Sistema Fun\";
                MessageBox.Show("Se ha producido un error al verificar los archivos de instalación del sistema. Revise la carpeta " +
                    " raiz. La ruta de instalación es '" + ruta + "'", "ARCHIVOS DE APLICACIÓN CORRUPTOS", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            Thread.Sleep(4000);
            Application.ExitThread();
        }

        public bool EstadoConexion(string conexion)
        {
            try
            {
                //Cadena de conexion
                con = new SqlConnection(conexion);
                con.Open();//se abre la conexion
                if (con.State == ConnectionState.Open)
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

        public static bool ConexionInternet()
        {
            try
            {
                System.Net.HttpWebRequest req;
                System.Net.HttpWebResponse res;
                req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.google.com");
                res = (System.Net.HttpWebResponse)req.GetResponse();
                req.Abort();
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
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
    }
}