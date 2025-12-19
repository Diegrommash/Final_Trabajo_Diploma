using BE.Entidades;
using BE.Enums;
using BE;
using DAL;

namespace BLL
{
    public class ServicioEvaluacionRiesgo
    {
        private readonly ClienteRepository _clienteRepo;
        private readonly EstrategiaRiesgoRepository _estrategiaRepo;
        private readonly EvaluacionCrediticiaRepository _evaluacionRepo;

        public ServicioEvaluacionRiesgo(
            ClienteRepository clienteRepo,
            EstrategiaRiesgoRepository estrategiaRepo,
            EvaluacionCrediticiaRepository evaluacionRepo)
        {
            _clienteRepo = clienteRepo;
            _estrategiaRepo = estrategiaRepo;
            _evaluacionRepo = evaluacionRepo;
        }

        public async Task<ResultadoEvaluacion> EvaluarAsync(
            Cliente cliente,
            TipoRiesgo tipoRiesgo)
        {
            var clienteBD = await _clienteRepo.ObtenerPorIdAsync(cliente.Id)
                ?? throw new Exception("Cliente no encontrado.");

            var estrategiaBD = await _estrategiaRepo
                .ObtenerActivaPorTipoAsync(tipoRiesgo.TipoEstrategia)
                ?? throw new Exception("Estrategia no configurada o inactiva.");

            var estrategiaRiesgo = EstrategiaRiesgoFactory
                .Crear(estrategiaBD.TipoEstrategia);

            ResultadoEvaluacion resultado = estrategiaRiesgo.Evaluar(cliente);

            var evaluacion = new EvaluacionCrediticia
            {
                Cliente = clienteBD,
                TipoRiesgo = estrategiaBD,
                Score = resultado.Score,
                NivelRiesgo = resultado.Nivel,
                Aprobado = resultado.Aprobado,
                Observaciones = resultado.Observaciones,
                FechaEvaluacion = DateTime.Now
            };

            await _evaluacionRepo.RegistrarAsync(evaluacion);

            return resultado;
        }
    }
}
