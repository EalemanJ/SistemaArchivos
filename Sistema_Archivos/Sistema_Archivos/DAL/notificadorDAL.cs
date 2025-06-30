using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    public class NotificadorDAL
    {
        private Conexion conectar;

        public NotificadorDAL()
        {
            conectar = new Conexion();
        }

        public DataTable VerNotificadores()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_notificador";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerTodosNotificadores()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_notificador as [Código Notificador], sa_notificador_nombre as [Nombre Notificador] from sa_notificador";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_notificador as [Código Notificador], sa_notificador_nombre as [Nombre Notificador] from sa_notificador where sa_notificador_nombre = @nombre";
            sel.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int IngresoNotificador(string nombre)
        {
            int res = 0;
            SqlCommand ins = conectar.Comando();
            ins.CommandText = "insert into sa_notificador values (@nombre)";
            ins.Parameters.AddWithValue("@nombre", nombre);
            conectar.Abrir();
            res = ins.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int EliminarNotificador(int codigo)
        {
            int retorno = 0;
            SqlCommand del = conectar.Comando();
            conectar.Abrir();
            del.CommandText = "delete from sa_notificador where sa_notificador = @codigo";
            del.Parameters.AddWithValue("@codigo", codigo);
            retorno = del.ExecuteNonQuery();
            conectar.Cerrar();
            return retorno;
        }

        public int ActualizarNombre(string nombre, int codigo)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_notificador set sa_notificador_nombre = @nombre where sa_notificador= @codigo";
            update.Parameters.AddWithValue("@nombre", nombre);
            update.Parameters.AddWithValue("@codigo", codigo);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable NotificadorColmena(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT n.sa_notificador, n.sa_notificador_nombre
                FROM sa_archivo_colmena as ac right join sa_notificador as n on ac.sa_notificador = n.sa_notificador
                WHERE (ac.sa_notificador = n.sa_notificador) and (ac.sa_archivo_colmena_fun = @fun)
                UNION ALL
                SELECT n1.sa_notificador, n1.sa_notificador_nombre FROM sa_archivo_colmena as ac1, sa_notificador as n1
                WHERE (ac1.sa_notificador <> n1.sa_notificador) and (ac1.sa_archivo_colmena_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable NotificadorConsalud(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT n.sa_notificador, n.sa_notificador_nombre
                FROM sa_archivo as a right join sa_notificador as n on a.sa_notificador = n.sa_notificador
                WHERE (a.sa_notificador = n.sa_notificador) and (a.sa_archivo_fun = @fun)
                UNION ALL
                SELECT n1.sa_notificador, n1.sa_notificador_nombre FROM sa_archivo as ac1, sa_notificador as n1
                WHERE (ac1.sa_notificador <> n1.sa_notificador) and (ac1.sa_archivo_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable NotificadorCarta(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT n.sa_notificador, n.sa_notificador_nombre
                FROM sa_archivo_carta as a right join sa_notificador as n on a.sa_notificador = n.sa_notificador
                WHERE (a.sa_notificador = n.sa_notificador) and (a.sa_archivo_carta_fun = @fun)
                UNION ALL
                SELECT n1.sa_notificador, n1.sa_notificador_nombre FROM sa_archivo_carta as ac1, sa_notificador as n1
                WHERE (ac1.sa_notificador <> n1.sa_notificador) and (ac1.sa_archivo_carta_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable Notificadoresencial(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"SELECT n.sa_notificador, n.sa_notificador_nombre
                FROM sa_archivo_esencial as ac right join sa_notificador as n on ac.sa_notificador = n.sa_notificador
                WHERE (ac.sa_notificador = n.sa_notificador) and (ac.sa_archivo_esencial_fun = @fun)
                UNION ALL
                SELECT n1.sa_notificador, n1.sa_notificador_nombre FROM sa_archivo_esencial as ac1, sa_notificador as n1
                WHERE (ac1.sa_notificador <> n1.sa_notificador) and (ac1.sa_archivo_esencial_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}