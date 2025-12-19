namespace BE.Visitor
{
    public interface IEfectoVisitor
    {
        public string Nombre { get;}
        string Visitar(Guerrero g, bool inicio);
        string Visitar(Mago m, bool inicio);
        string Visitar(Arquero a, bool inicio);
    }
}