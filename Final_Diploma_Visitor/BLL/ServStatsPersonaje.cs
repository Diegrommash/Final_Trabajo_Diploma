using BE;
using DAL;

namespace BLL
{
    public class ServStatsPersonaje
    {
        private readonly RepoStatsPersonaje _repo;

        public ServStatsPersonaje(RepoStatsPersonaje repo)
        {
            _repo = repo;
        }

        public async Task RegistrarBatalla(int id)
            => await _repo.SumarCampoAsync(id, "BatallasJugadas", 1);

        public async Task RegistrarVictoria(int id)
            => await _repo.SumarCampoAsync(id, "BatallasGanadas", 1);

        public async Task RegistrarDerrota(int id)
            => await _repo.SumarCampoAsync(id, "BatallasPerdidas", 1);

        public async Task RegistrarDanioCausado(int id, int danio)
            => await _repo.SumarCampoAsync(id, "DanioCausadoTotal", danio);

        public async Task RegistrarDanioRecibido(int id, int danio)
            => await _repo.SumarCampoAsync(id, "DanioRecibidoTotal", danio);

        public async Task RegistrarEfectoAplicado(int id)
            => await _repo.SumarCampoAsync(id, "EfectosAplicados", 1);

        public async Task RegistrarEfectoRecibido(int id)
            => await _repo.SumarCampoAsync(id, "EfectosRecibidos", 1);

        public async Task RegistrarTurnoSobrevivido(int id)
            => await _repo.SumarCampoAsync(id, "TurnosSobrevividosTotales", 1);

        public async Task ActualizarMaxTurnos(int id, int turnos)
            => await _repo.ActualizarMaxTurnosAsync(id, turnos);

        public async Task<StatsPersonaje?> ObtenerStats(int id)
            => await _repo.ObtenerPorIdAsync(id);
    }

}
