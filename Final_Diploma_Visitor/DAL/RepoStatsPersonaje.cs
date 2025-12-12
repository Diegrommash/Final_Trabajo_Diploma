using BE;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class RepoStatsPersonaje
    {
        private readonly Acceso _acceso;

        public RepoStatsPersonaje(Acceso acceso)
        {
            _acceso = acceso;
        }

        // ================================================================
        // Crear registro inicial al crear personaje
        // ================================================================
        public async Task CrearAsync(int idPersonaje)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@IdPersonaje", idPersonaje, DbType.Int32)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Stats_Crear", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en RepoStatsPersonaje → CrearAsync: {ex.Message}", ex);
            }
        }

        // ================================================================
        // Sumar un valor a un campo dinámicamente (daño, efectos, etc.)
        // ================================================================
        public async Task SumarCampoAsync(int idPersonaje, string campo, int valor)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@IdPersonaje", idPersonaje, DbType.Int32),
                    _acceso.CrearParametro("@Campo", campo, DbType.String),
                    _acceso.CrearParametro("@Valor", valor, DbType.Int32)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Stats_SumarCampo", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en RepoStatsPersonaje → SumarCampoAsync: {ex.Message}", ex);
            }
        }

        // ================================================================
        // Actualizar MaxTurnos solo si el nuevo valor es mayor
        // ================================================================
        public async Task ActualizarMaxTurnosAsync(int idPersonaje, int turnos)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@IdPersonaje", idPersonaje, DbType.Int32),
                    _acceso.CrearParametro("@Turnos", turnos, DbType.Int32)
                };

                await _acceso.EjecutarNonQueryAsync("SP_Stats_ActualizarMaxTurnos", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en RepoStatsPersonaje → ActualizarMaxTurnosAsync: {ex.Message}", ex);
            }
        }

        // ================================================================
        // Obtener estadísticas completas
        // ================================================================
        public async Task<StatsPersonaje?> ObtenerPorIdAsync(int idPersonaje)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@IdPersonaje", idPersonaje, DbType.Int32)
                };

                DataTable tabla = await _acceso.EjecutarQueryAsync("SP_Stats_ObtenerPorId", parametros);

                if (tabla.Rows.Count == 0)
                    return null;

                DataRow r = tabla.Rows[0];

                return new StatsPersonaje
                {
                    IdPersonaje = idPersonaje,
                    BatallasJugadas = Convert.ToInt32(r["BatallasJugadas"]),
                    BatallasGanadas = Convert.ToInt32(r["BatallasGanadas"]),
                    BatallasPerdidas = Convert.ToInt32(r["BatallasPerdidas"]),
                    DanioCausadoTotal = Convert.ToInt32(r["DanioCausadoTotal"]),
                    DanioRecibidoTotal = Convert.ToInt32(r["DanioRecibidoTotal"]),
                    EfectosAplicados = Convert.ToInt32(r["EfectosAplicados"]),
                    EfectosRecibidos = Convert.ToInt32(r["EfectosRecibidos"]),
                    TurnosSobrevividosTotales = Convert.ToInt32(r["TurnosSobrevividosTotales"]),
                    MaxTurnosEnBatalla = Convert.ToInt32(r["MaxTurnosEnBatalla"])
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en RepoStatsPersonaje → ObtenerPorIdAsync: {ex.Message}", ex);
            }
        }
    }
}
