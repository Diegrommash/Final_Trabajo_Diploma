namespace BE
{
    public class EscudoMagicoVisitor : IEfectoVisitor
    {
        private string _nombre = "Escudo magico";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool esInicial)
        {
            if (esInicial)
            {
                g.Defensa += 5;

                g.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "Un escudo arcano refuerza al Guerrero: +5 Defensa. Durará 2 turnos.";
            }
            else
            {
                g.Defensa += 2;
                return "El escudo mágico fortalece al Guerrero: +2 Defensa adicional.";
            }
        }

        public string Visitar(Mago m, bool esInicial)
        {
            if (esInicial)
            {
                m.Defensa += 20;

                m.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Mago es envuelto por un poderoso escudo mágico: +20 Defensa. Durará 2 turnos.";
            }
            else
            {
                m.Defensa += 5;
                return "El escudo mágico continúa protegiendo al Mago: +5 Defensa adicional.";
            }
        }

        public string Visitar(Arquero a, bool esInicial)
        {
            if (esInicial)
            {
                a.Defensa += 10;

                a.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Arquero recibe una barrera protectora: +10 Defensa. Durará 2 turnos.";
            }
            else
            {
                a.Defensa += 3;
                return "El escudo mágico sigue amortiguando ataques del Arquero: +3 Defensa adicional.";
            }
        }
        public override string ToString() => _nombre;
    }
}
