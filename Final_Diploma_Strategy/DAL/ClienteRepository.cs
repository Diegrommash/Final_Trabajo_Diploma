using BE.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ClienteRepository
    {
        private readonly Acceso _acceso;

        public ClienteRepository(Acceso acceso)
        {
            _acceso = acceso;
        }

        public async Task AgregarAsync(Cliente cliente)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Nombre", cliente.Nombre, DbType.String),
                    _acceso.CrearParametro("@IngresosMensuales", cliente.IngresosMensuales, DbType.Decimal),
                    _acceso.CrearParametro("@Edad", cliente.Edad, DbType.Int32),
                    _acceso.CrearParametro("@ScoreHistorial", cliente.ScoreHistorial, DbType.Int32),
                    _acceso.CrearParametro("@ValorGarantias", cliente.ValorGarantias, DbType.Decimal)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Cliente_Insertar", parametros);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException("Error al insertar cliente", ex);
            }
        }

        public async Task ModificarAsync(Cliente cliente)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Id", cliente.Id, DbType.Int32),
                    _acceso.CrearParametro("@Nombre", cliente.Nombre, DbType.String),
                    _acceso.CrearParametro("@IngresosMensuales", cliente.IngresosMensuales, DbType.Decimal),
                    _acceso.CrearParametro("@Edad", cliente.Edad, DbType.Int32),
                    _acceso.CrearParametro("@ScoreHistorial", cliente.ScoreHistorial, DbType.Int32),
                    _acceso.CrearParametro("@ValorGarantias", cliente.ValorGarantias, DbType.Decimal)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Cliente_Modificar", parametros);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException("Error al modificar cliente", ex);
            }
        }

        public async Task EliminarAsync(int id)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Id", id, DbType.Int32)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Cliente_Eliminar", parametros);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException("Error al eliminar cliente", ex);
            }
        }


        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            try
            {
                var tabla = await _acceso.EjecutarQueryAsync("SP_Cliente_ObtenerTodos");
                return Mapear(tabla);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException("Error al obtener clientes", ex);
            }
        }

        public async Task<Cliente?> ObtenerPorIdAsync(int id)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Id", id, DbType.Int32)
                };

                var tabla = await _acceso.EjecutarQueryAsync("SP_Cliente_ObtenerPorId", parametros);
                return Mapear(tabla).FirstOrDefault();
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException("Error al obtener cliente por id", ex);
            }
        }

        private List<Cliente> Mapear(DataTable tabla)
        {
            var lista = new List<Cliente>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Cliente
                {
                    Id = (int)row["Id"],
                    Nombre = row["Nombre"].ToString()!,
                    IngresosMensuales = (decimal)row["IngresosMensuales"],
                    Edad = (int)row["Edad"],
                    ScoreHistorial = (int)row["ScoreHistorial"],
                    ValorGarantias = (decimal)row["ValorGarantias"],
                    Activo = (bool)row["Activo"]
                });
            }

            return lista;
        }
    }
}
