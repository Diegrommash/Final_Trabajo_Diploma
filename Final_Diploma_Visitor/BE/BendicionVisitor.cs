namespace BE
{
    public class BendicionVisitor : IEfectoVisitor
    {
        private string _nombre = "Bendicion";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool esInicial)
        {
            if (esInicial)
            {
                g.Vida += 15;
                g.Ataque += 5;
                g.Defensa += 5;

                g.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 3
                });

                return "Una luz sagrada envuelve al Guerrero: +15 Vida, +5 Ataque y +5 Defensa. Bendición durará 3 turnos.";
            }
            else
            {
                g.Vida += 5;
                g.Defensa += 2;

                return "La bendición fortalece al Guerrero: +5 Vida, +2 Defensa.";
            }
        }

        public string Visitar(Mago m, bool esInicial)
        {
            if (esInicial)
            {
                m.Vida += 20;
                m.Mana += 30;
                m.Defensa += 10;

                m.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 3
                });

                return "El Mago recibe una bendición arcana: +20 Vida, +30 Maná y +10 Defensa. Bendición durará 3 turnos.";
            }
            else
            {
                m.Vida += 8;
                m.Defensa += 3;

                return "La bendición arcana sigue protegiendo al Mago: +8 Vida, +3 Defensa.";
            }
        }

        public string Visitar(Arquero a, bool esInicial)
        {
            if (esInicial)
            {
                a.Vida += 10;
                a.Ataque += 10;

                a.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 3
                });

                return "Una claridad divina guía al Arquero: +10 Vida y +10 Ataque. Bendición durará 3 turnos.";
            }
            else
            {
                a.Vida += 4;
                a.Defensa += 2;

                return "La bendición inspira al Arquero: +4 Vida, +2 Defensa.";
            }
        }
        public override string ToString() => _nombre;
    }
}
