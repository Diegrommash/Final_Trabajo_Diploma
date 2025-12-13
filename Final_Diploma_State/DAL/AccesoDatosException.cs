namespace DAL
{
    public class AccesoDatosException : Exception
    {
        public AccesoDatosException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }

    }
}
