using BE.Entidades;
using BE.Enums;
using DAL;

namespace BLL
{
    public class ServicioConsultaRiesgo
    {
        private readonly ClienteRepository _clienteRepo;
        private readonly EstrategiaRiesgoRepository _estrategiaRepo;
        private readonly EvaluacionCrediticiaRepository _evaluacionRepo;

        public ServicioConsultaRiesgo(
            ClienteRepository clienteRepo,
            EstrategiaRiesgoRepository estrategiaRepo,
            EvaluacionCrediticiaRepository evaluacionRepo)
        {
            _clienteRepo = clienteRepo;
            _estrategiaRepo = estrategiaRepo;
            _evaluacionRepo = evaluacionRepo;
        }


        public Task<List<Cliente>> ObtenerClientesAsync()
            => _clienteRepo.ObtenerTodosAsync();

        public Task<Cliente?> ObtenerClienteAsync(int id)
            => _clienteRepo.ObtenerPorIdAsync(id);

        public Task<TipoRiesgo?> ObtenerEstrategiaActivaAsync(TipoEstrategiaRiesgo tipo)
            => _estrategiaRepo.ObtenerActivaPorTipoAsync(tipo);

        public Task<List<TipoRiesgo>> ObternesEstrategiasActivasAsync()
            => _estrategiaRepo.ObtenerTodasActivasAsync();

        public Task<List<EvaluacionCrediticia>> ObtenerHistorialEvaluacionesAsync(int clienteId)
            => _evaluacionRepo.ObtenerPorClienteAsync(clienteId);
    }
}
