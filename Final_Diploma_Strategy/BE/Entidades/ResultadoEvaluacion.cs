using BE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entidades
{
    public class ResultadoEvaluacion
    {
        public int Score { get; set; }               // 0 a 100
        public NivelRiesgo Nivel { get; set; }       // Bajo / Medio / Alto
        public bool Aprobado { get; set; }            // true / false
        public string Observaciones { get; set; } = string.Empty;   // explicación
    }
}
