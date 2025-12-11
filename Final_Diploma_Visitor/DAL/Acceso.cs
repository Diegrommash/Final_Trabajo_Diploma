

using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Acceso
    {
        private readonly string _cadenaConexion;

        public Acceso(string cadenaConexion)
        {
            if (string.IsNullOrWhiteSpace(cadenaConexion))
                throw new ArgumentException("La cadena de conexión no puede estar vacía.");

            _cadenaConexion = cadenaConexion;
        }

        private async Task<SqlConnection> ObtenerConexionAsync()
        {
                var conn = new SqlConnection(_cadenaConexion);
                await conn.OpenAsync();
                return conn;
        }

        public SqlParameter CrearParametro(string nombre, object valor, DbType tipo)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                Value = valor ?? DBNull.Value,
                DbType = tipo
            };
        }

        private SqlCommand CrearComando(SqlConnection conn, string sp, List<SqlParameter>? parametros)
        {
            SqlCommand cmd = new(sp, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parametros != null)
            {
                foreach (SqlParameter p in parametros)
                {
                    var clone = (SqlParameter)((ICloneable)p).Clone();
                    cmd.Parameters.Add(clone);
                }
            }

            return cmd;
        }

        public async Task<object?> EjecutarEscalarAsync(string sp, List<SqlParameter>? parametros = null)
        {
            try
            {
                using var conn = await ObtenerConexionAsync();
                using var cmd = CrearComando(conn, sp, parametros);

                return await cmd.ExecuteScalarAsync();
            }
            catch (Exception ex)
            {
                throw new AccesoDatosException("Problebmas en el acceso - Metodo EjecutarEscalarAsync", ex);
            }
           
        }

        public async Task<int> EjecutarNonQueryAsync(string sp, List<SqlParameter>? parametros = null)
        {
            try
            {
                using var conn = await ObtenerConexionAsync();
                using var cmd = CrearComando(conn, sp, parametros);

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new AccesoDatosException("Problebmas en el acceso - Metodo EjecutarNonQueryAsync", ex);
            }
          
        }

        public async Task<DataTable> EjecutarQueryAsync(string sp, List<SqlParameter>? parametros = null)
        {
            try
            {
                using var conn = await ObtenerConexionAsync();
                using var cmd = CrearComando(conn, sp, parametros);
                using var reader = await cmd.ExecuteReaderAsync();

                DataTable tabla = new();
                tabla.Load(reader);

                return tabla;
            }
            catch (SqlException ex)
            {
                throw new AccesoDatosException("Problebmas en el acceso - Metodo EjecutarQueryAsync", ex);
            }
           
        }

    }
}
