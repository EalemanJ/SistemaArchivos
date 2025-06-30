using System.Data;
using System.Data.SqlClient;

namespace Sistema_Archivos
{
    public class ArchivoCartaDAL
    {
        private Conexion conectar;

        public ArchivoCartaDAL()
        {
            conectar = new Conexion();
        }

        public DataTable BuscarFUN(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select * from sa_archivo_carta where sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerAnterior(string rut, string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "SELECT TOP 1 sa_archivo_carta_direccion_dg " +
            " FROM sa_archivo_carta " +
            " WHERE sa_archivo_carta_rut_afiliado = @rut AND sa_archivo_carta_fun <> @fun" +
            " ORDER BY sa_archivo_carta DESC";
            sel.Parameters.AddWithValue("@rut", rut);
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerInubicable(string rut)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "SELECT * FROM sa_empresa_inubicable_carta WHERE sa_empresa_inubicable_carta_rut = @rut";
            sel.Parameters.AddWithValue("@rut", rut);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int EliminarRechazado(string rut)
        {
            int retorno = 0;
            SqlCommand del = conectar.Comando();
            conectar.Abrir();
            del.CommandText = "DELETE FROM sa_empresa_inubicable_carta WHERE sa_empresa_inubicable_carta_rut = @rut";
            del.Parameters.AddWithValue("@rut", rut);
            retorno = del.ExecuteNonQuery();
            conectar.Cerrar();
            return retorno;
        }

        public int ActualizarAnteriorInubicable(string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_motivo = 1, sa_estados_rechazados = 1 where sa_archivo_carta = @fun";
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int Ingreso(string fun, string rut, string nombre_e, string direccion_e, string comuna_e, int motivo, int rechazado, string direccion_dg, string fecha_ingreso,
            string fecha_carga, string fecha_noti, string fecha_dg, string fecha_proceso, string fecha_rendicion, string fecha_rechazo, string fecha_finiquito, string fecha_descarga,
            bool firma, bool timbre, int notificador, int usuario)
        {
            int res = 0;
            SqlCommand ins = conectar.Comando();
            ins.CommandText = "insert into sa_archivo_carta (sa_archivo_carta_fun, sa_archivo_carta_rut_afiliado, sa_archivo_carta_nombre_empresa, sa_archivo_carta_direccion_empresa, " +
            " sa_archivo_carta_comuna_empresa, sa_motivo, sa_estados_rechazados, sa_archivo_carta_direccion_dg, sa_archivo_carta_fecha_ingreso, sa_archivo_carta_fecha_carga, " +
            " sa_archivo_carta_fecha_notificacion, sa_archivo_carta_fecha_dg, sa_archivo_carta_fecha_proceso, sa_archivo_carta_fecha_rendicion, sa_archivo_carta_fecha_rechazo, " +
            " sa_archivo_carta_fecha_finiquito, sa_archivo_carta_fecha_descarga, sa_archivo_carta_firma, sa_archivo_carta_timbre, sa_notificador, sa_usuario) " +
            " values (@sa_archivo_carta_fun, @sa_archivo_carta_rut_afiliado, @sa_archivo_carta_nombre_empresa, @sa_archivo_carta_direccion_empresa, " +
            " @sa_archivo_carta_comuna_empresa, @sa_motivo, @sa_estados_rechazados, @sa_archivo_carta_direccion_dg, @sa_archivo_carta_fecha_ingreso, @sa_archivo_carta_fecha_carga, " +
            " @sa_archivo_carta_fecha_notificacion, @sa_archivo_carta_fecha_dg, @sa_archivo_carta_fecha_proceso, @sa_archivo_carta_fecha_rendicion, @sa_archivo_carta_fecha_rechazo, " +
            " @sa_archivo_carta_fecha_finiquito, @sa_archivo_carta_fecha_descarga, @sa_archivo_carta_firma, @sa_archivo_carta_timbre, @sa_notificador, @sa_usuario)";
            ins.Parameters.AddWithValue("@sa_archivo_carta_fun", fun);
            ins.Parameters.AddWithValue("@sa_archivo_carta_rut_afiliado", rut);
            ins.Parameters.AddWithValue("@sa_archivo_carta_nombre_empresa", nombre_e);
            ins.Parameters.AddWithValue("@sa_archivo_carta_direccion_empresa", direccion_e);
            ins.Parameters.AddWithValue("@sa_archivo_carta_comuna_empresa", comuna_e);
            ins.Parameters.AddWithValue("@sa_motivo", motivo);
            ins.Parameters.AddWithValue("@sa_estados_rechazados", rechazado);
            ins.Parameters.AddWithValue("@sa_archivo_carta_direccion_dg", direccion_dg);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_ingreso", fecha_ingreso);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_carga", fecha_carga);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_notificacion", fecha_noti);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_dg", fecha_dg);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_proceso", fecha_proceso);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_rendicion", fecha_rendicion);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_rechazo", fecha_rechazo);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_finiquito", fecha_finiquito);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_descarga", fecha_descarga);
            ins.Parameters.AddWithValue("@sa_archivo_carta_firma", firma);
            ins.Parameters.AddWithValue("@sa_archivo_carta_timbre", timbre);
            ins.Parameters.AddWithValue("@sa_notificador", notificador);
            ins.Parameters.AddWithValue("@sa_usuario", usuario);
            conectar.Abrir();
            res = ins.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable GenerarArchivoRendicion(string fecha, int usuario, string tipo_rendicion)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta_fun, a.sa_archivo_carta_fecha_notificacion, a.sa_archivo_carta_fecha_rendicion,  " +
            " a.sa_archivo_carta_direccion_dg, sa_archivo_carta_fecha_finiquito, " +
            " CASE " +
            " WHEN a.sa_motivo = 2 THEN '00' " +
            " WHEN a.sa_motivo = 3 THEN '01' " +
            " WHEN convert(varchar(3), sa_estados_desc, 120) = 'Sin' THEN '' " +
            " Else convert(varchar(3), sa_estados_desc, 120) " +
            " End as [codigo], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo" +
            " where a.sa_archivo_carta_fecha_rendicion = @fecha and a.sa_usuario = @usuario and sa_archivo_carta_tipo_descarga = @tipo_rendicion " +
            " order by a.sa_archivo_carta_orden_rendicion";
            sel.Parameters.AddWithValue("@fecha", fecha);
            sel.Parameters.AddWithValue("@usuario", usuario);
            sel.Parameters.AddWithValue("@tipo_rendicion", tipo_rendicion);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarRendicion(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select n.sa_notificador_nombre, a.sa_archivo_carta_rut_afiliado, a.sa_archivo_carta_nombre_empresa, " +
            " a.sa_archivo_carta_direccion_empresa, a.sa_archivo_carta_comuna_empresa, a.sa_archivo_carta_fecha_ingreso, " +
            " a.sa_archivo_carta_fecha_carga, a.sa_archivo_carta_fecha_rendicion " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " where a.sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int ActualizarFechaRendicion(string fecha_rendicion, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_fecha_rendicion = @fecha_rendicion where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("fecha_rendicion", fecha_rendicion);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable VerFunEliminar(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta, a.sa_archivo_carta_fun, n.sa_notificador_nombre, " +
            " a.sa_archivo_carta_rut_afiliado, a.sa_archivo_carta_nombre_empresa, " +
            " a.sa_archivo_carta_direccion_empresa, a.sa_archivo_carta_comuna_empresa, m.sa_motivo_desc, r.sa_estados_desc, " +
            " a.sa_archivo_carta_direccion_dg, a.sa_archivo_carta_fecha_ingreso, a.sa_archivo_carta_fecha_carga, " +
            " a.sa_archivo_carta_fecha_notificacion, a.sa_archivo_carta_fecha_dg, a.sa_archivo_carta_fecha_proceso, " +
            " a.sa_archivo_carta_fecha_rendicion, a.sa_archivo_carta_fecha_rechazo, a.sa_archivo_carta_fecha_finiquito, " +
            " a.sa_archivo_carta_fecha_descarga, " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo " +
            " where a.sa_archivo_carta_fun = @fun OR a.sa_archivo_carta = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int EliminarFun(int codigo)
        {
            int retorno = 0;
            SqlCommand del = conectar.Comando();
            conectar.Abrir();
            del.CommandText = "delete from sa_archivo_carta where sa_archivo_carta = @codigo";
            del.Parameters.AddWithValue("@codigo", codigo);
            retorno = del.ExecuteNonQuery();
            conectar.Cerrar();
            return retorno;
        }

        public DataTable ConsultarFun(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta as [Código Único], a.sa_archivo_carta_fun as [FUN], n.sa_notificador_nombre as [Notificador], a.sa_archivo_carta_rut_afiliado as [Rut Afiliado], " +
            " a.sa_archivo_carta_nombre_empresa as [Nombre Empresa], a.sa_archivo_carta_direccion_empresa as [Dirección Empresa], a.sa_archivo_carta_comuna_empresa as [Comuna Empresa], " +
            " m.sa_motivo_desc as [Motivo], r.sa_estados_desc as [Detalle Rechazado], a.sa_archivo_carta_direccion_dg as [Dirección D.G.], a.sa_archivo_carta_fecha_ingreso as [Fecha Ingreso], " +
            " a.sa_archivo_carta_fecha_carga as [Fecha Carga], a.sa_archivo_carta_fecha_descarga as [Fecha Descarga], a.sa_archivo_carta_fecha_notificacion as [Fecha Notificación], " +
            " a.sa_archivo_carta_fecha_dg as [Fecha D.G.], a.sa_archivo_carta_fecha_proceso as [Fecha Proceso], a.sa_archivo_carta_fecha_rendicion as [Fecha Rendición], " +
            " a.sa_archivo_carta_fecha_rechazo as [Fecha de Rechazo], a.sa_archivo_carta_fecha_finiquito as [Fecha Finiquito], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo " +
            " where a.sa_archivo_carta_fun like '%" + @fun + "%' OR a.sa_archivo_carta_rut_afiliado like '%" + @fun + "%' OR a.sa_archivo_carta_nombre_empresa like '%" + @fun + "%'";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerTodosFun()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta as [Código Único], a.sa_archivo_carta_fun as [FUN], n.sa_notificador_nombre as [Notificador], a.sa_archivo_carta_rut_afiliado as [Rut Afiliado], " +
            " a.sa_archivo_carta_nombre_empresa as [Nombre Empresa], a.sa_archivo_carta_direccion_empresa as [Dirección Empresa], a.sa_archivo_carta_comuna_empresa as [Comuna Empresa], " +
            " m.sa_motivo_desc as [Motivo], r.sa_estados_desc as [Detalle Rechazado], a.sa_archivo_carta_direccion_dg as [Dirección D.G.], a.sa_archivo_carta_fecha_ingreso as [Fecha Ingreso], " +
            " a.sa_archivo_carta_fecha_carga as [Fecha Carga], a.sa_archivo_carta_fecha_descarga as [Fecha Descarga], a.sa_archivo_carta_fecha_notificacion as [Fecha Notificación], " +
            " a.sa_archivo_carta_fecha_dg as [Fecha D.G.], a.sa_archivo_carta_fecha_proceso as [Fecha Proceso], a.sa_archivo_carta_fecha_rendicion as [Fecha Rendición], " +
            " a.sa_archivo_carta_fecha_rechazo as [Fecha de Rechazo], a.sa_archivo_carta_fecha_finiquito as [Fecha Finiquito], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarFUNNotificador(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.*, n.sa_notificador_nombre, m.sa_motivo_desc, sr.sa_estados_desc " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as sr on a.sa_estados_rechazados = sr.sa_estados " +
            " inner join sa_motivo as m on a.sa_motivo = m.sa_motivo " +
            " where a.sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int ActualizarTodo(string rut, string nombreE, string direccionE, string comunaE, int motivo, int rechazo,
            string direccionDG, string fechaIngreso, string fechaCarga, string fechaNotificacion, string fechaDG, string fechaProceso,
            string fechaRendicion, string fechaRechazo, string fechaFiniquito, string fechaDescarga, bool firma, bool timbre, int notificador, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_rut_afiliado = @rut, " +
            " sa_archivo_carta_nombre_empresa = @nombreE, sa_archivo_carta_direccion_empresa = @direccionE, sa_archivo_carta_comuna_empresa = @comunaE, " +
            " sa_motivo = @motivo, sa_estados_rechazados = @rechazo, sa_archivo_carta_direccion_dg = @direccionDG, " +
            " sa_archivo_carta_fecha_ingreso = @fechaIngreso, sa_archivo_carta_fecha_carga = @fechaCarga, " +
            " sa_archivo_carta_fecha_notificacion = @fechaNotificacion, sa_archivo_carta_fecha_dg = @fechaDG, " +
            " sa_archivo_carta_fecha_proceso = @fechaProceso, sa_archivo_carta_fecha_rendicion = @fechaRendicion, " +
            " sa_archivo_carta_fecha_rechazo = @fechaRechazo, sa_archivo_carta_fecha_finiquito = @fechaFiniquito, sa_archivo_carta_fecha_descarga = @fechaDescarga, sa_archivo_carta_firma = @firma, " +
            " sa_archivo_carta_timbre = @timbre, sa_notificador = @notificador where sa_archivo_carta_fun = @fun ";
            update.Parameters.AddWithValue("@rut", rut);
            update.Parameters.AddWithValue("@nombreE", nombreE);
            update.Parameters.AddWithValue("@direccionE", direccionE);
            update.Parameters.AddWithValue("@comunaE", comunaE);
            update.Parameters.AddWithValue("@motivo", motivo);
            update.Parameters.AddWithValue("@rechazo", rechazo);
            update.Parameters.AddWithValue("@direccionDG", direccionDG);
            update.Parameters.AddWithValue("@fechaIngreso", fechaIngreso);
            update.Parameters.AddWithValue("@fechaCarga", fechaCarga);
            update.Parameters.AddWithValue("@fechaNotificacion", fechaNotificacion);
            update.Parameters.AddWithValue("@fechaDG", fechaDG);
            update.Parameters.AddWithValue("@fechaProceso", fechaProceso);
            update.Parameters.AddWithValue("@fechaRendicion", fechaRendicion);
            update.Parameters.AddWithValue("@fechaRechazo", fechaRechazo);
            update.Parameters.AddWithValue("@fechaFiniquito", fechaFiniquito);
            update.Parameters.AddWithValue("@fechaDescarga", fechaDescarga);
            update.Parameters.AddWithValue("@firma", firma);
            update.Parameters.AddWithValue("@timbre", timbre);
            update.Parameters.AddWithValue("@notificador", notificador);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int IngresoArchivoExcel(string fun, string rut, string nombre_e, string direccion_e, string comuna_e, int motivo, int rechazado, string fecha_ingreso,
            string fecha_proceso, int notificador, int usuario)
        {
            int res = 0;
            SqlCommand ins = conectar.Comando();
            ins.CommandText = "insert into sa_archivo_carta (sa_archivo_carta_fun, sa_archivo_carta_rut_afiliado, sa_archivo_carta_nombre_empresa, sa_archivo_carta_direccion_empresa, " +
            " sa_archivo_carta_comuna_empresa, sa_motivo, sa_estados_rechazados, sa_archivo_carta_fecha_ingreso, sa_archivo_carta_fecha_proceso, sa_notificador, sa_usuario) " +
            " values (@sa_archivo_carta_fun, @sa_archivo_carta_rut_afiliado, @sa_archivo_carta_nombre_empresa, @sa_archivo_carta_direccion_empresa, " +
            " @sa_archivo_carta_comuna_empresa, @sa_motivo, @sa_estados_rechazados, @sa_archivo_carta_fecha_ingreso, @sa_archivo_carta_fecha_proceso, @sa_notificador, @sa_usuario)";
            ins.Parameters.AddWithValue("@sa_archivo_carta_fun", fun);
            ins.Parameters.AddWithValue("@sa_archivo_carta_rut_afiliado", rut);
            ins.Parameters.AddWithValue("@sa_archivo_carta_nombre_empresa", nombre_e);
            ins.Parameters.AddWithValue("@sa_archivo_carta_direccion_empresa", direccion_e);
            ins.Parameters.AddWithValue("@sa_archivo_carta_comuna_empresa", comuna_e);
            ins.Parameters.AddWithValue("@sa_motivo", motivo);
            ins.Parameters.AddWithValue("@sa_estados_rechazados", rechazado);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_ingreso", fecha_ingreso);
            ins.Parameters.AddWithValue("@sa_archivo_carta_fecha_proceso", fecha_proceso);
            ins.Parameters.AddWithValue("@sa_notificador", notificador);
            ins.Parameters.AddWithValue("@sa_usuario", usuario);
            conectar.Abrir();
            res = ins.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable GenerarArchivoCarga(int notificador, string fecha)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_archivo_carta_fun as [FUN] from sa_archivo_carta " +
            " where sa_notificador = @notificador and sa_archivo_carta_fecha_carga = @fecha";
            sel.Parameters.AddWithValue("@notificador", notificador);
            sel.Parameters.AddWithValue("@fecha", fecha);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarPorFUN(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_archivo_carta_rut_afiliado, sa_archivo_carta_nombre_empresa, sa_archivo_carta_direccion_empresa " +
            " from sa_archivo_carta " +
            " where sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int ActualizarNotificador(int codigo, string fecha_carga, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_notificador = @codigo, sa_archivo_carta_fecha_carga = @fecha_carga where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("@codigo", codigo);
            update.Parameters.AddWithValue("@fecha_carga", fecha_carga);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int ActualizarConHabilitado(string nombre_empresa, string comuna_empresa, string direccion_empresa, int motivo, int estado_rechazado, string fecha_rendicion, string fecha_descarga,
            bool firma, bool timbre, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_nombre_empresa = @nombre_empresa, sa_archivo_carta_comuna_empresa = @comuna_empresa, " +
            " sa_archivo_carta_direccion_empresa = @direccion_empresa, sa_motivo = @motivo, sa_estados_rechazados = @estado_rechazado, sa_archivo_carta_fecha_rendicion = @fecha_rendicion, " +
            " sa_archivo_carta_fecha_descarga = @fecha_descarga, sa_archivo_carta_firma = @firma, sa_archivo_carta_timbre = @timbre, sa_archivo_carta_fecha_rechazo = NULL " +
            " where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("@nombre_empresa", nombre_empresa);
            update.Parameters.AddWithValue("@comuna_empresa", comuna_empresa);
            update.Parameters.AddWithValue("@direccion_empresa", direccion_empresa);
            update.Parameters.AddWithValue("@motivo", motivo);
            update.Parameters.AddWithValue("@estado_rechazado", estado_rechazado);
            update.Parameters.AddWithValue("@fecha_rendicion", fecha_rendicion);
            update.Parameters.AddWithValue("@fecha_descarga", fecha_descarga);
            update.Parameters.AddWithValue("@firma", firma);
            update.Parameters.AddWithValue("@timbre", timbre);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int ActualizarSinHabilitado(string nombre_empresa, string comuna_empresa, string direccion_empresa, int motivo, int estado_rechazado, string fecha_rendicion,
            string fecha_rechazo, string fecha_descarga, bool firma, bool timbre, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_nombre_empresa = @nombre_empresa, sa_archivo_carta_comuna_empresa = @comuna_empresa, " +
            " sa_archivo_carta_direccion_empresa = @direccion_empresa, sa_motivo = @motivo, sa_estados_rechazados = @estado_rechazado, sa_archivo_carta_fecha_rendicion = @fecha_rendicion, " +
            " sa_archivo_carta_fecha_rechazo = @fecha_rechazo, sa_archivo_carta_fecha_descarga = @fecha_descarga, sa_archivo_carta_firma = @firma, sa_archivo_carta_timbre = @timbre " +
            " where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("@nombre_empresa", nombre_empresa);
            update.Parameters.AddWithValue("@comuna_empresa", comuna_empresa);
            update.Parameters.AddWithValue("@direccion_empresa", direccion_empresa);
            update.Parameters.AddWithValue("@motivo", motivo);
            update.Parameters.AddWithValue("@estado_rechazado", estado_rechazado);
            update.Parameters.AddWithValue("@fecha_rendicion", fecha_rendicion);
            update.Parameters.AddWithValue("@fecha_rechazo", fecha_rechazo);
            update.Parameters.AddWithValue("@fecha_descarga", fecha_descarga);
            update.Parameters.AddWithValue("@firma", firma);
            update.Parameters.AddWithValue("@timbre", timbre);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable VerFunesPendientes()
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta_fun as [FUN], n.sa_notificador_nombre as [Notificador], a.sa_archivo_carta_rut_afiliado as [Rut Afiliado], " +
            " a.sa_archivo_carta_nombre_empresa as [Nombre Empresa], a.sa_archivo_carta_direccion_empresa as [Dirección Empresa], a.sa_archivo_carta_comuna_empresa as [Comuna Empresa], " +
            " m.sa_motivo_desc as [Motivo], r.sa_estados_desc as [Detalle Rechazado], " +
            " a.sa_archivo_carta_direccion_dg as [Dirección D.G.], a.sa_archivo_carta_fecha_ingreso as [Fecha Ingreso], a.sa_archivo_carta_fecha_carga as [Fecha Carga], " +
            " a.sa_archivo_carta_fecha_notificacion as [Fecha Notificación], a.sa_archivo_carta_fecha_dg as [Fecha D.G.], a.sa_archivo_carta_fecha_proceso as [Fecha Proceso], " +
            " a.sa_archivo_carta_fecha_rendicion as [Fecha Rendición], a.sa_archivo_carta_fecha_rechazo as [Fecha de Rechazo], a.sa_archivo_carta_fecha_finiquito as [Fecha Finiquito], " +
            " a.sa_archivo_carta_fecha_descarga as [Fecha Descarga], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo " +
            " where a.sa_archivo_carta_fecha_rendicion is null or a.sa_archivo_carta_fecha_rendicion = ''";
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerFunesPendientesNotificador(int notificador)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta_fun as [FUN], n.sa_notificador_nombre as [Notificador], a.sa_archivo_carta_rut_afiliado as [Rut Afiliado], " +
            " a.sa_archivo_carta_nombre_empresa as [Nombre Empresa], a.sa_archivo_carta_direccion_empresa as [Dirección Empresa], a.sa_archivo_carta_comuna_empresa as [Comuna Empresa], " +
            " m.sa_motivo_desc as [Motivo], r.sa_estados_desc as [Detalle Rechazado], " +
            " a.sa_archivo_carta_direccion_dg as [Dirección D.G.], a.sa_archivo_carta_fecha_ingreso as [Fecha Ingreso], a.sa_archivo_carta_fecha_carga as [Fecha Carga], " +
            " a.sa_archivo_carta_fecha_notificacion as [Fecha Notificación], a.sa_archivo_carta_fecha_dg as [Fecha D.G.], a.sa_archivo_carta_fecha_proceso as [Fecha Proceso], " +
            " a.sa_archivo_carta_fecha_rendicion as [Fecha Rendición], a.sa_archivo_carta_fecha_rechazo as [Fecha de Rechazo], a.sa_archivo_carta_fecha_finiquito as [Fecha Finiquito], " +
            " a.sa_archivo_carta_fecha_descarga as [Fecha Descarga], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo " +
            " where (a.sa_notificador = @notificador) and (a.sa_archivo_carta_fecha_rendicion is null or a.sa_archivo_carta_fecha_rendicion = '')";
            sel.Parameters.AddWithValue("@notificador", notificador);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable VerParaCargaAutomatica(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select a.sa_archivo_carta_fun, a.sa_archivo_carta_rut_afiliado, a.sa_archivo_carta_nombre_empresa, " +
            " a.sa_archivo_carta_direccion_empresa, a.sa_archivo_carta_comuna_empresa, m.sa_motivo_desc, r.sa_estados_desc, " +
            " a.sa_archivo_carta_direccion_dg, a.sa_archivo_carta_fecha_ingreso, a.sa_archivo_carta_fecha_carga, " +
            " a.sa_archivo_carta_fecha_notificacion, a.sa_archivo_carta_fecha_dg, a.sa_archivo_carta_fecha_proceso, " +
            " a.sa_archivo_carta_fecha_rendicion, a.sa_archivo_carta_fecha_rechazo, a.sa_archivo_carta_fecha_finiquito, " +
            " CASE " +
            " WHEN a.sa_archivo_carta_firma = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_firma = 0 THEN '0' " +
            " END as [Firma], " +
            " CASE " +
            " WHEN a.sa_archivo_carta_timbre = 1 THEN '1' " +
            " WHEN a.sa_archivo_carta_timbre = 0 THEN '0' " +
            " END as [Timbre] " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo " +
            " where a.sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public DataTable BuscarDatosFun(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_archivo_carta_fun, sa_archivo_carta_rut_afiliado, sa_archivo_carta_nombre_empresa, sa_archivo_carta_direccion_empresa, " +
            " sa_archivo_carta_comuna_empresa, sa_archivo_carta_firma, sa_archivo_carta_timbre from sa_archivo_carta where sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int DescargaHabilitados(string fecha_rendicion, string fecha_notificacion, string fecha_descarga, int motivo, int rechazado, bool firma, bool timbre, int usuario,
            string orden, string tipo_descarga, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_fecha_rendicion = @fecha_rendicion, sa_archivo_carta_fecha_notificacion = @fecha_notificacion, " +
            " sa_archivo_carta_fecha_descarga = @fecha_descarga, sa_motivo = @motivo, sa_estados_rechazados = @rechazado, " +
            " sa_archivo_carta_firma = @firma, sa_archivo_carta_timbre = @timbre, sa_usuario = @usuario, sa_archivo_carta_orden_rendicion = @orden, " +
            " sa_archivo_carta_tipo_descarga = @tipo_descarga where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("@fecha_rendicion", fecha_rendicion);
            update.Parameters.AddWithValue("@fecha_notificacion", fecha_notificacion);
            update.Parameters.AddWithValue("@fecha_descarga", fecha_descarga);
            update.Parameters.AddWithValue("@motivo", motivo);
            update.Parameters.AddWithValue("@rechazado", rechazado);
            update.Parameters.AddWithValue("@firma", firma);
            update.Parameters.AddWithValue("@timbre", timbre);
            update.Parameters.AddWithValue("@usuario", usuario);
            update.Parameters.AddWithValue("@orden", orden);
            update.Parameters.AddWithValue("@tipo_descarga", tipo_descarga);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public DataTable VerParaDescargaFueraPlazo(string fun)
        {
            SqlCommand sel = conectar.Comando();
            sel.CommandText = "select sa_archivo_carta_fun, sa_archivo_carta_rut_afiliado, sa_archivo_carta_nombre_empresa, sa_archivo_carta_direccion_empresa, " +
            " sa_archivo_carta_comuna_empresa, sa_archivo_carta_firma, sa_archivo_carta_timbre " +
            " from sa_archivo_carta as a " +
            " inner join sa_notificador as n on a.sa_notificador = n.sa_notificador " +
            " inner join sa_estados_rechazado as r on a.sa_estados_rechazados = r.sa_estados " +
            " inner join sa_motivo as m on m.sa_motivo = a.sa_motivo " +
            " where a.sa_archivo_carta_fun = @fun";
            sel.Parameters.AddWithValue("@fun", fun);
            SqlDataAdapter adaptador = new SqlDataAdapter(sel);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            return tabla;
        }

        public int ActualizarFueraPlazo(string fecha_rendicion, string fecha_notificacion, string fecha_descarga, int motivo, bool firma, bool timbre, int usuario, string orden,
            string tipo_descarga, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_fecha_rendicion = @fecha_rendicion, " +
            " sa_archivo_carta_fecha_notificacion = @fecha_notificacion, sa_archivo_carta_fecha_descarga = @fecha_descarga, sa_motivo = @motivo, " +
            " sa_archivo_carta_firma = @firma, sa_archivo_carta_timbre = @timbre, sa_usuario = @usuario, sa_archivo_carta_orden_rendicion = @orden, " +
            " sa_archivo_carta_tipo_descarga = @tipo_descarga where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("@fecha_rendicion", fecha_rendicion);
            update.Parameters.AddWithValue("@fecha_notificacion", fecha_notificacion);
            update.Parameters.AddWithValue("@fecha_descarga", fecha_descarga);
            update.Parameters.AddWithValue("@motivo", motivo);
            update.Parameters.AddWithValue("@firma", firma);
            update.Parameters.AddWithValue("@timbre", timbre);
            update.Parameters.AddWithValue("@usuario", usuario);
            update.Parameters.AddWithValue("@orden", orden);
            update.Parameters.AddWithValue("@tipo_descarga", tipo_descarga);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }

        public int DescargarRechazado(string fecha_rendicion, string fecha_notificacion, string fecha_descarga, string fecha_finiquito, string fecha_rechazado, int motivo,
            int rechazado, bool firma, bool timbre, int usuario, string orden, string tipo_descarga, string fun)
        {
            int res = 0;
            SqlCommand update = conectar.Comando();
            update.CommandText = "update sa_archivo_carta set sa_archivo_carta_fecha_rendicion = @fecha_rendicion, sa_archivo_carta_fecha_notificacion = @fecha_notificacion, " +
            " sa_archivo_carta_fecha_descarga = @fecha_descarga, sa_archivo_carta_fecha_finiquito = @fecha_finiquito, sa_archivo_carta_fecha_rechazo = @fecha_rechazado, sa_motivo = @motivo, " +
            " sa_estados_rechazados = @rechazado, sa_archivo_carta_firma = @firma, sa_archivo_carta_timbre = @timbre, sa_usuario = @usuario, " +
            " sa_archivo_carta_orden_rendicion = @orden, sa_archivo_carta_tipo_descarga = @tipo_descarga where sa_archivo_carta_fun= @fun";
            update.Parameters.AddWithValue("@fecha_rendicion", fecha_rendicion);
            update.Parameters.AddWithValue("@fecha_notificacion", fecha_notificacion);
            update.Parameters.AddWithValue("@fecha_descarga", fecha_descarga);
            update.Parameters.AddWithValue("@fecha_finiquito", fecha_finiquito);
            update.Parameters.AddWithValue("@fecha_rechazado", fecha_rechazado);
            update.Parameters.AddWithValue("@motivo", motivo);
            update.Parameters.AddWithValue("@rechazado", rechazado);
            update.Parameters.AddWithValue("@firma", firma);
            update.Parameters.AddWithValue("@timbre", timbre);
            update.Parameters.AddWithValue("@usuario", usuario);
            update.Parameters.AddWithValue("@orden", orden);
            update.Parameters.AddWithValue("@tipo_descarga", tipo_descarga);
            update.Parameters.AddWithValue("@fun", fun);
            conectar.Abrir();
            res = update.ExecuteNonQuery();
            conectar.Cerrar();
            return res;
        }
    }
}