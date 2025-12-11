namespace BE
{
    public class IraVisitor : IEfectoVisitor
    {
        public string Visitar(Guerrero g, bool esInicial)
        {
            if (esInicial)
            {
                g.Ataque += 25;
                g.Defensa -= 10;

                g.EstadosTemporales.Add(new EstadoTemporal
                {
                    Nombre = "Ira",
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Guerrero entra en furia descontrolada: +25 Ataque, -10 Defensa. La ira durará 2 turnos.";
            }
            else
            {
                g.Vida -= 5;     // desgaste
                g.Defensa -= 3;  // se descuida cada vez más
                g.Ataque += 5;   // golpear más fuerte sin control

                return "La furia consume al Guerrero: -5 Vida, -3 Defensa, +5 Ataque.";
            }
        }

        public string Visitar(Mago m, bool esInicial)
        {
            if (esInicial)
            {
                m.Ataque += 10;
                m.Defensa -= 5;

                m.EstadosTemporales.Add(new EstadoTemporal
                {
                    Nombre = "Ira",
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "La Ira perturba al Mago: +10 Ataque, -5 Defensa. Durará 2 turnos.";
            }
            else
            {
                m.Vida -= 8;
                m.Defensa -= 2;
                m.Ataque += 3;

                return "La furia arcana desgasta al Mago: -8 Vida, -2 Defensa, +3 Ataque.";
            }
        }

        public string Visitar(Arquero a, bool esInicial)
        {
            if (esInicial)
            {
                a.Ataque += 15;
                a.Defensa -= 8;

                a.EstadosTemporales.Add(new EstadoTemporal
                {
                    Nombre = "Ira",
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Arquero dispara con furia implacable: +15 Ataque, -8 Defensa. Durará 2 turnos.";
            }
            else
            {
                a.Vida -= 6;
                a.Defensa -= 3;
                a.Ataque += 4;

                return "La ira sigue ardiendo en el Arquero: -6 Vida, -3 Defensa, +4 Ataque.";
            }
        }

    }
}
