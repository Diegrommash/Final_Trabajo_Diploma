using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HistorialTarea
    {
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaCambio { get; set; }
        public string? Motivo { get; set; }
    }
}
