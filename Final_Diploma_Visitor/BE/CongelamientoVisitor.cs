namespace BE
{
    public class CongelamientoVisitor : IEfectoVisitor
    {
        public string Visitar(Guerrero g, bool esInicial)
        {
            if (esInicial)
            {
                g.Ataque -= 10;
                g.Defensa -= 5;

                g.EstadosTemporales.Add(new EstadoTemporal
                {
                    Nombre = "Congelamiento",
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El hielo entumece al Guerrero: -10 Ataque y -5 Defensa. El efecto durará 2 turnos.";
            }
            else
            {
                g.Ataque -= 3;
                g.Defensa -= 1;

                return "El frío persistente sigue afectando al Guerrero: -3 Ataque y -1 Defensa.";
            }
        }

        public string Visitar(Mago m, bool esInicial)
        {
            if (esInicial)
            {
                m.Ataque -= 3;
                m.Defensa -= 2;

                m.EstadosTemporales.Add(new EstadoTemporal
                {
                    Nombre = "Congelamiento",
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Mago resiste el frío, pero aún así se debilita: -3 Ataque y -2 Defensa. El efecto durará 2 turnos.";
            }
            else
            {
                m.Ataque -= 1;
                m.Defensa -= 1;

                return "El gélido clima sigue afectando al Mago: -1 Ataque y -1 Defensa.";
            }
        }

        public string Visitar(Arquero a, bool esInicial)
        {
            if (esInicial)
            {
                a.Ataque -= 15;
                a.Defensa -= 5;

                a.EstadosTemporales.Add(new EstadoTemporal
                {
                    Nombre = "Congelamiento",
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Arquero pierde firmeza por el congelamiento: -15 Ataque y -5 Defensa. Durará 2 turnos.";
            }
            else
            {
                a.Ataque -= 5;
                a.Defensa -= 2;

                return "El frío extremo sigue reduciendo la precisión del Arquero: -5 Ataque y -2 Defensa.";
            }
        }
    }
}
