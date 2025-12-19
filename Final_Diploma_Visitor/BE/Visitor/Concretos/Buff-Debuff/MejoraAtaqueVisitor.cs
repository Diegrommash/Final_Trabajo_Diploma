namespace BE.Visitor
{
    public class MejoraAtaqueVisitor : IEfectoVisitor
    {
        private string _nombre = "Mejora ataque";
        public string Nombre => _nombre;

        public string Visitar(Guerrero g, bool inicio)
        {
            g.Ataque += 15;

            return "El Guerrero afila su determinación: +15 Ataque.";
        }

        public string Visitar(Mago m, bool inicio)
        {
            m.Ataque += 5;

            return "El Mago concentra energía ofensiva: +5 Ataque.";
        }

        public string Visitar(Arquero a, bool inicio)
        {
            a.Ataque += 20;

            return "El Arquero ajusta su puntería con precisión mortal: +20 Ataque.";
        }

        public override string ToString() => _nombre;
    }
}
