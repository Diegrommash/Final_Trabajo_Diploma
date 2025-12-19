using BE.Enums;
using BE.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class EstrategiaRiesgoRepository
    {
        private readonly Acceso _acceso;

        public EstrategiaRiesgoRepository(Acceso acceso)
        {
            _acceso = acceso;
        }

        public async Task<TipoRiesgo?> ObtenerActivaPorTipoAsync(TipoEstrategiaRiesgo tipo)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@TipoEstrategia", (int)tipo, DbType.Int32)
                };

                var tabla = await _acceso
                    .EjecutarQueryAsync("SP_EstrategiaRiesgo_ObtenerActivaPorTipo", parametros);

                return Mapear(tabla).FirstOrDefault();
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException(
                    "Error al obtener estrategia de riesgo activa",
                    ex);
            }
        }

        public async Task<List<TipoRiesgo>> ObtenerTodasActivasAsync()
        {
            try
            {
                var tabla = await _acceso
                    .EjecutarQueryAsync("SP_EstrategiaRiesgo_ObtenerTodas");

                return Mapear(tabla);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException(
                    "Error al obtener las estrategias activas",
                    ex);
            }
        }

        private List<TipoRiesgo> Mapear(DataTable tabla)
        {
            var lista = new List<TipoRiesgo>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new TipoRiesgo
                {
                    Id = (int)row["Id"],
                    Nombre = row["Nombre"].ToString()!,
                    TipoEstrategia = (TipoEstrategiaRiesgo)(int)row["TipoEstrategia"],
                    Activa = (bool)row["Activa"],
                    Observaciones = row["Observaciones"].ToString()!
                });
            }

            return lista;
        }
    }
}
