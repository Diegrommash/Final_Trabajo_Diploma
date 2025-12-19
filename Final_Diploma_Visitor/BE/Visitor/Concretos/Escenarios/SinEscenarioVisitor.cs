using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Visitor.Concretos.Escenarios
{
    public class SinEscenarioVisitor : IEfectoVisitor
    {
        private string _nombre = "Sin escenario";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool inicio)
        {
            return "Sin escenario por lo que no hay efectos";
        }

        public string Visitar(Mago m, bool inicio)
        {
            return "Sin escenario por lo que no hay efectos";
        }

        public string Visitar(Arquero a, bool inicio)
        {
            return "Sin escenario por lo que no hay efectos";
        }
        public override string ToString() => _nombre;
    }
}
