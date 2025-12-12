using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class VenenoVisitor : IEfectoVisitor
    {
        private string _nombre = "Veneno";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool esInicial)
        {
            // daño dependiendo de si es el primer turno o uno prolongado
            g.Vida -= esInicial ? 10 : 5;

            if (esInicial)
            {
                g.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 3
                });

                return "El Guerrero es envenenado: -10 Vida. El veneno actuará durante 3 turnos.";
            }

            return "El veneno sigue afectando al Guerrero: -5 Vida.";
        }

        public string Visitar(Mago m, bool esInicial)
        {
            m.Vida -= esInicial ? 25 : 10;

            if (esInicial)
            {
                m.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 3
                });

                return "El Mago sufre un veneno arcano: -25 Vida. Continuará dañándolo por 3 turnos.";
            }

            return "El veneno arcano sigue drenando al Mago: -10 Vida.";
        }

        public string Visitar(Arquero a, bool esInicial)
        {
            a.Vida -= esInicial ? 20 : 8;

            if (esInicial)
            {
                a.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 3
                });

                return "El Arquero es intoxicado: -20 Vida. El veneno persistirá por 3 turnos.";
            }

            return "El veneno continúa debilitando al Arquero: -8 Vida.";
        }
        public override string ToString() => _nombre;
    }
}
