using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositorioException : Exception
    {
        public RepositorioException(string mensaje, Exception inner) : base(mensaje, inner) { }
      
    }
}
