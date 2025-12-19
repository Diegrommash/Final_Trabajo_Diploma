using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstadoBatalla
    {
        public IPersonaje Personaje1 { get; init; } = default!;
        public IPersonaje Personaje2 { get; init; } = default!;

        public bool TurnoP1 { get; set; }
        public int NumeroTurno { get; set; } = 1;
        public bool Finalizada { get; set; }
    }
}
