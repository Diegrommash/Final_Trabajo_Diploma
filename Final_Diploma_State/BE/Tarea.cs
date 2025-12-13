using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string EstadoActual { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
