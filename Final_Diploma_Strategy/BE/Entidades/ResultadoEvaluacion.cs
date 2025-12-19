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
        public int Score { get; set; } 
        public NivelRiesgo Nivel { get; set; } 
        public bool Aprobado { get; set; }
        public string Observaciones { get; set; } = string.Empty; 
    }
}
