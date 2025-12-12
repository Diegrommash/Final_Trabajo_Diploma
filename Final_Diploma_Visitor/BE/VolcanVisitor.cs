using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class VolcanVisitor : IEfectoVisitor
    {
        private string _nombre = "Volcan";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool inicio)
        {
            g.Vida -= 5;
            return "El calor del volcán agota al Guerrero: -5 Vida.";
        }

        public string Visitar(Mago m, bool inicio)
        {
            m.Vida -= 8;
            return "Los vapores ígneos afectan al Mago: -8 Vida.";
        }

        public string Visitar(Arquero a, bool inicio)
        {
            a.Vida -= 6;
            return "La ceniza volcánica dificulta al Arquero: -6 Vida.";
        }
        public override string ToString() => _nombre;
    }
}
