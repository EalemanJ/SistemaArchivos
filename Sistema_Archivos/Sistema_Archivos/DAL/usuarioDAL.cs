using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    public class UsuarioDAL
    {
        private Conexion conectar;

        public UsuarioDAL()
        {
            conectar = new Conexion();
        }

        public DataTable Login(string nombre, string password)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_usuario where sa_usuario_nombre = @nombre and sa_usuario_clave = @clave";
            sel.Parameters.AddWithValue("@nombre", nombre);
            sel.Parameters.AddWithValue("@clave", password);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerDisponible(string nombre)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_usuario_nombre from sa_usuario where sa_usuario_nombre = @nombre";
            sel.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int CambiarClave(string clave, int codigo_usuario)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_usuario set sa_usuario_clave = @clave where sa_usuario = @codigo_usuario";
            update.Parameters.AddWithValue("@clave", clave);
            update.Parameters.AddWithValue("@codigo_usuario", codigo_usuario);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int AgregarUsuario(string nombre, string clave, bool estado)
        {
            int res = 0;
            SqlCommand ins = conectar.Comando();
            ins.CommandText = "insert into sa_usuario values (@nombre, @clave, @estado)";
            ins.Parameters.AddWithValue("@nombre", nombre);
            ins.Parameters.AddWithValue("@clave", clave);
            ins.Parameters.AddWithValue("@estado", estado);
            conectar.Abrir();
            res = ins.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable VerUsuarios()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = @"select sa_usuario as [Código Usuario], sa_usuario_nombre as [Nombre Usuario],
                CASE
                WHEN sa_usuario_estado = 1 THEN 'Habilitado'
                WHEN sa_usuario_estado = 0 THEN 'Deshabilitado'
                END as [Estado]
                from sa_usuario";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int CambiarEstado(bool estado, int codigo_usuario)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_usuario set sa_usuario_estado = @estado where sa_usuario = @codigo_usuario";
            update.Parameters.AddWithValue("@estado", estado);
            update.Parameters.AddWithValue("@codigo_usuario", codigo_usuario);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int EliminarUsuario(int codigo)
        {
            int retorno = 0;
            SqlCommand del = conectar.Comando();
            conectar.Abrir();
            del.CommandText = "delete from sa_usuario where sa_usuario = @codigo";
            del.Parameters.AddWithValue("@codigo", codigo);
            retorno = del.ExecuteNonQuery();
            conectar.Cerrar();
            return retorno;
        }
    }
}