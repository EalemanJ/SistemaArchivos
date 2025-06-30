using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    internal class EstadoRechazadoDAL
    {
        private Conexion conectar;

        public EstadoRechazadoDAL()
        {
            conectar = new Conexion();
        }

        public DataTable VerEstadosRechazado()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_estados_rechazado";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionado(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT sa_estados_rechazado.sa_estados, sa_estados_rechazado.sa_estados_desc
                FROM sa_archivo right join sa_estados_rechazado on sa_archivo.sa_estados_rechazados = sa_estados_rechazado.sa_estados
                WHERE (sa_archivo.sa_estados_rechazados = sa_estados_rechazado.sa_estados) and(sa_archivo_fun = @fun)
                UNION ALL
                SELECT sa_estados_rechazado.sa_estados, sa_estados_rechazado.sa_estados_desc
                FROM sa_archivo, sa_estados_rechazado
                WHERE (sa_archivo.sa_estados_rechazados <> sa_estados_rechazado.sa_estados) and(sa_archivo_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoCarta(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT er.sa_estados, er.sa_estados_desc
                FROM sa_archivo_carta as c right join sa_estados_rechazado as er on c.sa_estados_rechazados = er.sa_estados
                WHERE (c.sa_estados_rechazados = er.sa_estados) and (c.sa_archivo_carta_fun = @fun)
                UNION ALL
                SELECT er1.sa_estados, er1.sa_estados_desc
                FROM sa_archivo_carta as c1, sa_estados_rechazado as er1
                WHERE (c1.sa_estados_rechazados <> er1.sa_estados) and (c1.sa_archivo_carta_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}