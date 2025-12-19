using BE.Entidades;
using BE.Enums;
using BE.Strategy;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class EvaluacionCrediticiaRepository
    {
        private readonly Acceso _acceso;

        public EvaluacionCrediticiaRepository(Acceso acceso)
        {
            _acceso = acceso;
        }

        public async Task RegistrarAsync(EvaluacionCrediticia evaluacion)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@ClienteId", evaluacion.Cliente.Id, DbType.Int32),
                    _acceso.CrearParametro("@EstrategiaRiesgoId", evaluacion.TipoRiesgo.Id, DbType.Int32),
                    _acceso.CrearParametro("@Score", evaluacion.Score, DbType.Int32),
                    _acceso.CrearParametro("@NivelRiesgo", (int)evaluacion.NivelRiesgo, DbType.Int32),
                    _acceso.CrearParametro("@Aprobado", evaluacion.Aprobado, DbType.Boolean),
                    _acceso.CrearParametro("@Observaciones", evaluacion.Observaciones, DbType.String)
                };

                await _acceso
                    .EjecutarNonQueryAsync("SP_EvaluacionCrediticia_Insertar", parametros);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException(
                    "Error al registrar evaluación crediticia",
                    ex);
            }
        }

        public async Task<List<EvaluacionCrediticia>> ObtenerPorClienteAsync(int clienteId)
        {
            try
            {
                var parametros = new List<SqlParameter>
        {
            _acceso.CrearParametro("@ClienteId", clienteId, DbType.Int32)
        };

                var tabla = await _acceso
                    .EjecutarQueryAsync("SP_EvaluacionCrediticia_ObtenerPorCliente", parametros);

                return MapearEvaluaciones(tabla);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException(
                    "Error al obtener historial de evaluaciones",
                    ex);
            }
        }


        private List<EvaluacionCrediticia> MapearEvaluaciones(DataTable tabla)
        {
            var lista = new List<EvaluacionCrediticia>();

            foreach (DataRow row in tabla.Rows)
            {
                var evaluacion = new EvaluacionCrediticia
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Score = Convert.ToInt32(row["Score"]),
                    NivelRiesgo = (NivelRiesgo)Convert.ToInt32(row["NivelRiesgo"]),
                    Aprobado = Convert.ToBoolean(row["Aprobado"]),
                    Observaciones = row["Observaciones"]?.ToString(),
                    FechaEvaluacion = Convert.ToDateTime(row["FechaEvaluacion"]),

                    Cliente = new Cliente
                    {
                        Id = Convert.ToInt32(row["ClienteId"]),
                        Nombre = row["NombreCliente"]?.ToString()
                    },

                    TipoRiesgo = new TipoRiesgo
                    {
                        Id = Convert.ToInt32(row["EstrategiaRiesgoId"]),
                        Nombre = row["NombreRiesgoEstrategia"]?.ToString()
                    }
                };

                lista.Add(evaluacion);
            }

            return lista;
        }


    }
}
