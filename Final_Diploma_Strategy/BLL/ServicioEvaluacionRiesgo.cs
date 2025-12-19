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
            TipoRiesgo estrategia)
        {
            // 1️⃣ Obtener cliente
            var clienteBD = await _clienteRepo.ObtenerPorIdAsync(cliente.Id)
                ?? throw new Exception("Cliente no encontrado.");

            // 2️⃣ Obtener estrategia configurada (DB)
            var estrategiaBD = await _estrategiaRepo
                .ObtenerActivaPorTipoAsync(estrategia.TipoEstrategia)
                ?? throw new Exception("Estrategia no configurada o inactiva.");

            // 3️⃣ Crear estrategia concreta (Factory)
            var estrategiaRiesgo = EstrategiaRiesgoFactory
                .Crear(estrategiaBD.TipoEstrategia);

            // 4️⃣ Ejecutar evaluación
            ResultadoEvaluacion resultado = estrategiaRiesgo.Evaluar(cliente);

            // 5️⃣ Registrar evaluación
            var evaluacion = new EvaluacionCrediticia
            {
                ClienteId = cliente.Id,
                EstrategiaRiesgoId = estrategiaBD.Id,
                Score = resultado.Score,
                NivelRiesgo = resultado.Nivel,
                Aprobado = resultado.Aprobado,
                Observaciones = resultado.Observaciones,
                FechaEvaluacion = DateTime.Now
            };

            await _evaluacionRepo.RegistrarAsync(evaluacion);

            // 6️⃣ Devolver resultado a la UI
            return resultado;
        }
    }
}
