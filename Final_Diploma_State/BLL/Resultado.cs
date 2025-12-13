using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Resultado
    {
        public bool Exito { get; set; }
        public string? Error { get; set; }

        protected Resultado() { }

        public static Resultado Correcto()
            => new Resultado { Exito = true };

        public static Resultado Fallo(string mensaje)
            => new Resultado { Exito = false, Error = mensaje };
    }

    public class Resultado<T> : Resultado
    {
        public T? Valor { get; set; }

        protected Resultado() : base() { }

        public static Resultado<T> Correcto(T valor)
            => new Resultado<T> { Exito = true, Valor = valor };

        public static Resultado<T> Fallo(string mensaje)
            => new Resultado<T> { Exito = false, Error = mensaje };
    }

}