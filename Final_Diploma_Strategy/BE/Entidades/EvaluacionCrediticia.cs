using BE.Enums;

namespace BE.Entidades
{
    public class EvaluacionCrediticia
    {
        public int Id { get; set; }

        public Cliente Cliente { get; set; }
        public TipoRiesgo TipoRiesgo { get; set; }

        public int Score { get; set; }
        public NivelRiesgo NivelRiesgo { get; set; }
        public bool Aprobado { get; set; }

        public string Observaciones { get; set; }
        public DateTime FechaEvaluacion { get; set; }
    }
}
