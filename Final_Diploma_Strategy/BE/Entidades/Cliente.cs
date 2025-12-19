using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public decimal IngresosMensuales { get; set; }   // $
        public int Edad { get; set; }                     // años

        // Score histórico 0–100 (ej: comportamiento crediticio previo)
        public int ScoreHistorial { get; set; }

        // Valor de garantías declaradas
        public decimal ValorGarantias { get; set; }

        public bool Activo { get; set; }
    }
}
