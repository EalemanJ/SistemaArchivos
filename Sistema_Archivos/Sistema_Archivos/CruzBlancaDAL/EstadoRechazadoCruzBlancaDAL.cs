using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    public class EstadoRechazadoCruzBlancaDAL
    {
        private Conexion conectar;

        public EstadoRechazadoCruzBlancaDAL()
        {
            conectar = new Conexion();
        }

        public DataTable VerEstadosRechazado()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_estado_rechazado_Cruz_Blanca";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable CargarListaSeleccionadoRechazado(string fun)
        {
            //observacion
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "SELECT erc.sa_estado_rechazado_Cruz_Blanca, erc.sa_estado_rechazado_Cruz_Blanca_desc " +
            " FROM sa_archivo_Cruz_Blanca as ac right join sa_estado_rechazado_Cruz_Blanca as erc on ac.sa_estado_rechazado_Cruz_Blanca = erc.sa_estado_rechazado_Cruz_Blanca " +
            " WHERE(ac.sa_estado_rechazado_Cruz_Blanca = erc.sa_estado_rechazado_Cruz_Blanca) and(ac.sa_archivo_Cruz_Blanca_fun = @fun) " +
            " UNION ALL " +
            " SELECT erc1.sa_estado_rechazado_Cruz_Blanca, erc1.sa_estado_rechazado_Cruz_Blanca_desc FROM sa_archivo_Cruz_Blanca as ac1, sa_estado_rechazado_Cruz_Blanca as erc1 " +
            " WHERE(ac1.sa_estado_rechazado_Cruz_Blanca <> erc1.sa_estado_rechazado_Cruz_Blanca) and(ac1.sa_archivo_Cruz_Blanca_fun = @fun)";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }
    }
}