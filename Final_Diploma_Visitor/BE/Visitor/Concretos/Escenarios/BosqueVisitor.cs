namespace BE.Visitor.Concretos.Escenarios
{
    public class BosqueVisitor : IEfectoVisitor
    {
        private string _nombre = "Bosque";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool inicio)
        {
            g.Defensa += 2;
            return "El bosque refuerza su armadura (+2 DEF).";
        }

        public string Visitar(Mago m, bool inicio)
        {
            m.Mana += 5;
            return "El bosque regenera su energía mágica (+5 MANÁ).";
        }

        public string Visitar(Arquero a, bool inicio)
        {
            a.Ataque += 5;
            return "El bosque potencia la precisión de sus flechas (+5 ATQ).";
        }

        public override string ToString() => _nombre;
    }
}
