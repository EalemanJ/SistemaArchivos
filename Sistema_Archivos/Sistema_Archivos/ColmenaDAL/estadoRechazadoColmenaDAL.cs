using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    internal class EstadoRechazadoColmenaDAL
    {
        private Conexion conectar;

        public EstadoRechazadoColmenaDAL()
        {
            conectar = new Conexion();
        }

        public DataTable VerEstadosRechazado()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_estado_rechazado_colmena";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoRechazado(string fun)
        {
            //observacion
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "SELECT erc.sa_estado_rechazado_colmena, erc.sa_estado_rechazado_colmena_desc " +
            " FROM sa_archivo_colmena as ac right join sa_estado_rechazado_colmena as erc on ac.sa_estado_rechazado_colmena = erc.sa_estado_rechazado_colmena " +
            " WHERE(ac.sa_estado_rechazado_colmena = erc.sa_estado_rechazado_colmena) and(ac.sa_archivo_colmena_fun = @fun) " +
            " UNION ALL " +
            " SELECT erc1.sa_estado_rechazado_colmena, erc1.sa_estado_rechazado_colmena_desc FROM sa_archivo_colmena as ac1, sa_estado_rechazado_colmena as erc1 " +
            " WHERE(ac1.sa_estado_rechazado_colmena <> erc1.sa_estado_rechazado_colmena) and(ac1.sa_archivo_colmena_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}