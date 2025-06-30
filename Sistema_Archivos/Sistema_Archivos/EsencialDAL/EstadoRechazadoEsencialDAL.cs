using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    public class EstadoRechazadoEsencialDAL
    {
        private Conexion conectar;

        public EstadoRechazadoEsencialDAL()
        {
            conectar = new Conexion();
        }

        public DataTable VerEstadosRechazado()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_estado_rechazado_esencial";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoRechazado(string fun)
        {
            //observacion
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "SELECT erc.sa_estado_rechazado_esencial, erc.sa_estado_rechazado_esencial_desc " +
            " FROM sa_archivo_esencial as ac right join sa_estado_rechazado_esencial as erc on ac.sa_estado_rechazado_esencial = erc.sa_estado_rechazado_esencial " +
            " WHERE(ac.sa_estado_rechazado_esencial = erc.sa_estado_rechazado_esencial) and(ac.sa_archivo_esencial_fun = @fun) " +
            " UNION ALL " +
            " SELECT erc1.sa_estado_rechazado_esencial, erc1.sa_estado_rechazado_esencial_desc FROM sa_archivo_esencial as ac1, sa_estado_rechazado_esencial as erc1 " +
            " WHERE(ac1.sa_estado_rechazado_esencial <> erc1.sa_estado_rechazado_esencial) and(ac1.sa_archivo_esencial_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}