using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class StatsPersonaje
    {
        public int IdPersonaje { get; set; }
        public int BatallasJugadas { get; set; }
        public int BatallasGanadas { get; set; }
        public int BatallasPerdidas { get; set; }
        public int DanioCausadoTotal { get; set; }
        public int DanioRecibidoTotal { get; set; }
        public int EfectosAplicados { get; set; }
        public int EfectosRecibidos { get; set; }
        public int TurnosSobrevividosTotales { get; set; }
        public int MaxTurnosEnBatalla { get; set; }
    }
}
