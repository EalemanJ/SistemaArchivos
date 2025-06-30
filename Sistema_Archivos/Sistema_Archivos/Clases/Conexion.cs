using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public class Conexion
    {
        public SqlConnection Conn { get; set; }

        public Conexion()
        {
            Conn = new SqlConnection(Sesion.CadenaConexion);
        }

        public void Abrir()
        {
            if (Conn.State != ConnectionState.Open)
            {
                try
                {
                    Conn.Open();
                }
                catch (Exception)
                {
                    try
                    {
                        Conn = new SqlConnection(Sesion.CadenaConexion);
                        Conn.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo establecer la conexión con el servidor.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void Cerrar()
        {
            Conn.Close();
        }

        public SqlCommand Comando()
        {
            SqlCommand com = new SqlCommand
            {
                Connection = Conn
            };
            return com;
        }
    }
}