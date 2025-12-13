namespace DAL
{
    public class RepositorioExeption : Exception
    {
        public RepositorioExeption(string mensaje, Exception inner) : base(mensaje, inner)
        {         
        }

    }
}
