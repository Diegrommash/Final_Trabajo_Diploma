namespace BE.Visitor
{
    public class QuemaduraVisitor : IEfectoVisitor
    {
        private string _nombre = "Quemadura";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool esInicial)
        {
            if (esInicial)
            {
                g.Vida -= 15;
                g.Ataque -= 5;

                g.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "Las llamas hieren al Guerrero: -15 Vida y -5 Ataque. Las quemaduras persistirán durante 2 turnos.";
            }
            else
            {
                g.Vida -= 7;
                g.Ataque -= 2;

                return "Las quemaduras siguen afectando al Guerrero: -7 Vida y -2 Ataque.";
            }
        }

        public string Visitar(Mago m, bool esInicial)
        {
            if (esInicial)
            {
                m.Vida -= 10;
                m.Ataque -= 3;

                m.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Mago sufre quemaduras leves: -10 Vida y -3 Ataque. Continuarán durante 2 turnos.";
            }
            else
            {
                m.Vida -= 5;
                m.Ataque -= 1;

                return "Las quemaduras siguen dañando al Mago: -5 Vida y -1 Ataque.";
            }
        }

        public string Visitar(Arquero a, bool esInicial)
        {
            if (esInicial)
            {
                a.Vida -= 20;
                a.Ataque -= 7;

                a.EstadosTemporales.Add(new EstadoTemporal
                {
                    Efecto = this,
                    TurnosRestantes = 2
                });

                return "El Arquero es alcanzado por el fuego: -20 Vida y -7 Ataque. El efecto persistirá 2 turnos.";
            }
            else
            {
                a.Vida -= 8;
                a.Ataque -= 3;

                return "Las quemaduras continúan debilitando al Arquero: -8 Vida y -3 Ataque.";
            }
        }
        public override string ToString() => _nombre;
    }
}
