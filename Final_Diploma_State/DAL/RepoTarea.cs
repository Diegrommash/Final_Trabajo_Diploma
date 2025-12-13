using System.Data;
using BE;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class RepositorioTarea
    {
        private readonly Acceso _acceso;

        public RepositorioTarea(Acceso acceso)
        {
            _acceso = acceso;
        }

        public async Task<int> CrearAsync(string titulo, string descripcion)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Titulo", titulo, DbType.String),
                    _acceso.CrearParametro("@Descripcion", descripcion, DbType.String)
                };

                var result = await _acceso.EjecutarEscalarAsync("SP_Tarea_Crear", parametros);
                return Convert.ToInt32(result);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioExeption(
                    "Error al crear la tarea (RepositorioTarea.CrearAsync)", ex);
            }
        }

        public async Task CambiarEstadoAsync(int idTarea, string nuevoEstado, string? motivo = null)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@IdTarea", idTarea, DbType.Int32),
                    _acceso.CrearParametro("@NuevoEstado", nuevoEstado, DbType.String),
                    _acceso.CrearParametro("@Motivo", motivo, DbType.String)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Tarea_CambiarEstado", parametros);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioExeption(
                    "Error al cambiar el estado de la tarea (RepositorioTarea.CambiarEstadoAsync)", ex);
            }
        }

        public async Task<List<Tarea>> ObtenerPorEstadoAsync(string estado)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Estado", estado, DbType.String)
                };

                DataTable tabla = await _acceso.EjecutarQueryAsync(
                    "SP_Tarea_ObtenerPorEstado", parametros);

                return MapearLista(tabla);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioExeption(
                    "Error al obtener tareas por estado (RepositorioTarea.ObtenerPorEstadoAsync)", ex);
            }
        }

        public async Task<List<Tarea>> ObtenerTodasAsync()
        {
            try
            {
                DataTable tabla = await _acceso.EjecutarQueryAsync("SP_Tarea_ObtenerTodas");
                return MapearLista(tabla);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioExeption(
                    "Error al obtener todas las tareas (RepositorioTarea.ObtenerTodasAsync)", ex);
            }
        }

        public async Task<List<HistorialTarea>> ObtenerHistorialAsync(int idTarea)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@IdTarea", idTarea, DbType.Int32)
                };

                DataTable tabla = await _acceso.EjecutarQueryAsync(
                    "SP_Tarea_ObtenerHistorial", parametros);

                List<HistorialTarea> lista = new();

                foreach (DataRow row in tabla.Rows)
                {
                    lista.Add(new HistorialTarea
                    {
                        Estado = row["Estado"].ToString()!,
                        FechaCambio = Convert.ToDateTime(row["FechaCambio"]),
                        Motivo = row["Motivo"]?.ToString()
                    });
                }

                return lista;
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioExeption(
                    "Error al obtener historial de la tarea", ex);
            }
        }


        private List<Tarea> MapearLista(DataTable tabla)
        {
            List<Tarea> lista = new();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Tarea
                {
                    IdTarea = Convert.ToInt32(row["IdTarea"]),
                    Titulo = row["Titulo"].ToString()!,
                    Descripcion = row["Descripcion"]?.ToString(),
                    EstadoActual = row["EstadoActual"].ToString()!,
                    FechaCreacion = Convert.ToDateTime(row["FechaCreacion"])
                });
            }

            return lista;
        }
    }
}
