namespace BE
{
    public interface IEfectoVisitor
    {
        string Visitar(Guerrero g, bool inicio);
        string Visitar(Mago m, bool inicio);
        string Visitar(Arquero a, bool inicio);
    }
}