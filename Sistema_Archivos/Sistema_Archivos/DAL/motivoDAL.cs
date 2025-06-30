using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    public class MotivoDAL
    {
        private Conexion conectar;

        public MotivoDAL()
        {
            conectar = new Conexion();
        }

        public DataTable BuscarMotivos()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_motivo";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionado(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT sa_motivo.sa_motivo, sa_motivo.sa_motivo_desc
                FROM sa_archivo right join sa_motivo on sa_archivo.sa_motivo = sa_motivo.sa_motivo
                WHERE (sa_archivo.sa_motivo = sa_motivo.sa_motivo) and(sa_archivo_fun = @fun)
                UNION ALL
                SELECT sa_motivo.sa_motivo, sa_motivo_desc FROM sa_archivo, sa_motivo
                WHERE (sa_archivo.sa_motivo <> sa_motivo.sa_motivo) and(sa_archivo_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable MotivoNoRechazado()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_motivo where sa_motivo_desc <> 'Rechazado'";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoColmena(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT m.sa_motivo, m.sa_motivo_desc
                FROM sa_motivo as m right join sa_archivo_colmena as ac on m.sa_motivo = ac.sa_motivo
                WHERE (ac.sa_motivo = m.sa_motivo) and(ac.sa_archivo_colmena_fun = @fun)
                UNION ALL
                SELECT m1.sa_motivo, m1.sa_motivo_desc FROM sa_motivo as m1, sa_archivo_colmena as ac1
                WHERE (ac1.sa_motivo <> m1.sa_motivo) and(ac1.sa_archivo_colmena_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoEsencial(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT m.sa_motivo, m.sa_motivo_desc
                FROM sa_motivo as m right join sa_archivo_esencial as ac on m.sa_motivo = ac.sa_motivo
                WHERE (ac.sa_motivo = m.sa_motivo) and (ac.sa_archivo_esencial_fun = @fun)
                UNION ALL
                SELECT m1.sa_motivo, m1.sa_motivo_desc FROM sa_motivo as m1, sa_archivo_esencial as ac1
                WHERE (ac1.sa_motivo <> m1.sa_motivo) and (ac1.sa_archivo_esencial_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoCarta(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT m.sa_motivo, m.sa_motivo_desc FROM sa_archivo_carta as c right join sa_motivo as m on c.sa_motivo = m.sa_motivo
                WHERE (c.sa_motivo = m.sa_motivo) and (c.sa_archivo_carta_fun = @fun)
                UNION ALL
                SELECT m1.sa_motivo, m1.sa_motivo_desc FROM sa_archivo_carta as c1, sa_motivo as m1
                WHERE (c1.sa_motivo <> m1.sa_motivo) and (c1.sa_archivo_carta_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}