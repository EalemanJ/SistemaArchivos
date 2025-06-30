using System;
using System.Text;

namespace Sistema_Archivos
{
    public static class Sesion
    {
        public static System.Windows.Forms.ProgressBar ProgressBar { get; set; }

        public static string CadenaConexion { get; set; }

        public static int IdUsuario { get; set; }

        public static string NombreUsuario { get; set; }

        public static string ClaveUsuario { get; set; }

        public static bool EstadoUsuario { get; set; }

        public static string Menu_salir { get; set; }

        public static void LimpiarSesion()
        {
            IdUsuario = 0;
            NombreUsuario = "";
            ClaveUsuario = "";
            EstadoUsuario = false;
            Menu_salir = "";
            CadenaConexion = "";
            ProgressBar = null;
        }

        public static bool VerificarInubicable(string rut)
        {
            try
            {
                System.Data.DataTable consulta = new ArchivoDAL().VerInubicable(rut);
                if (consulta.Rows.Count > 0)
                {
                    //ESTA INUBICABLE
                    return true;
                }
                else
                {
                    //NO ESTA INUBICABLE
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string Encriptar(string claveAEncriptar)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(claveAEncriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesEncriptar(this string claveADesEncriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(claveADesEncriptar);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}