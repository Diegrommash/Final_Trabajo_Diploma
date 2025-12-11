using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResultadoBatalla
    {
        public IPersonaje Atacante { get; set; } = default!;
        public IPersonaje Defensor { get; set; } = default!;
        public List<string> LogEventos { get; } = new();
        public bool BatallaFinalizada { get; set; }
        public IPersonaje? Ganador { get; set; }
        public int NumeroTurno { get; set; }
    }
}
