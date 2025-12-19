using BE.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EstadoTemporal
    {
        public string Nombre => Efecto.Nombre;
        public IEfectoVisitor Efecto { get; set; } = default!;
        public int TurnosRestantes { get; set; }

        public override string ToString()
            => $"{Nombre} ({TurnosRestantes} turnos)";
    }
}
