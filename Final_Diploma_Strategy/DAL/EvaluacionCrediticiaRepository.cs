using BE.Entidades;
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
                    _acceso.CrearParametro("@ClienteId", evaluacion.ClienteId, DbType.Int32),
                    _acceso.CrearParametro("@EstrategiaRiesgoId", evaluacion.EstrategiaRiesgoId, DbType.Int32),
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

        public async Task<DataTable> ObtenerPorClienteAsync(int clienteId)
        {
            try
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@ClienteId", clienteId, DbType.Int32)
                };

                return await _acceso
                    .EjecutarQueryAsync("SP_EvaluacionCrediticia_ObtenerPorCliente", parametros);
            }
            catch (AccesoDatosException ex)
            {
                throw new RepositorioException(
                    "Error al obtener historial de evaluaciones",
                    ex);
            }
        }
    }
}
