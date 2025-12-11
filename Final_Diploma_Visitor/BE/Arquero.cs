namespace BE
{
    public class Arquero : IPersonaje
    {
        public int Id { get; set; }
        public int Vida { get; set; }
        public int Mana { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public TipoPersonaje Tipo => TipoPersonaje.Arquero;
        public List<EstadoTemporal> EstadosTemporales { get; } = new();
        public string Aceptar(IEfectoVisitor visitor, bool inicio) =>
            visitor.Visitar(this, inicio);

        public override string ToString() => "Arquero";
    }
}