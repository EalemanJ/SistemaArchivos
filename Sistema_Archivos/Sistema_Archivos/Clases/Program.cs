using System;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                string ruta = Application.StartupPath + "\\config.ini";
                string accesoDirecto = "C:\\Users\\" + Environment.UserName + "\\Desktop\\ruta.txt";
                if (File.Exists(ruta))
                {
                    StreamReader archivo = new StreamReader(ruta);
                    string conn = Cadena(archivo);
                    if (string.IsNullOrWhiteSpace(conn))
                    {
                        File.WriteAllText(ruta, "Data Source=192.168.1.88; initial catalog=sistema_archivos; integrated security=false; User ID=sa; Password=administrador;");
                        MessageBox.Show("Por favor reinicie la aplicación.", "ARCHIVOS RECONSTRUIDOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.ExitThread();
                    }
                    else
                    {
                        Sesion.CadenaConexion = conn;
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmInicio());
                    }
                }
                else
                {
                    try
                    {
                        File.WriteAllText(ruta, "Data Source=192.168.1.88; initial catalog=sistema_archivos; integrated security=false; User ID=sa; Password=administrador;");
                        File.WriteAllText(accesoDirecto, Application.StartupPath);
                        MessageBox.Show("Se ha creado el archivo de configuración ya que no existía en el Pc cliente, además se ha creado un archivo en su escritorio llamado ruta.txt.",
                            "ARCHIVO CREADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        StreamReader archivo = new StreamReader(ruta);
                        Sesion.CadenaConexion = Cadena(archivo);
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmInicio());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se ha podido crear el archivo de configuración. La ruta de acceso es " + Application.StartupPath + " ... Detalles: " + ex.Message, "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.ExitThread();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar la aplicación. Detalle: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sesion.CadenaConexion = "";
                Application.ExitThread();
            }
        }

        public static string Cadena(StreamReader file)
        {
            string linea = "", conn = "";
            while ((linea = file.ReadLine()) != null)
            {
                conn = linea;
                break;
            }
            return conn;
        }
    }
}

//teli188273ad