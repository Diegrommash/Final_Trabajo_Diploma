using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccesoDatosException : Exception
    {
        public AccesoDatosException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }

}
