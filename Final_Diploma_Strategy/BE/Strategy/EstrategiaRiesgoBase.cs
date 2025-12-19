using BE.Entidades;
using BE.Enums;

namespace BE.Strategy.Base
{
    public abstract class EstrategiaRiesgoBase : IEstrategiaRiesgo
    {
        public abstract ResultadoEvaluacion Evaluar(Cliente cliente);

        // -----------------------------
        // Normalizaciones comunes
        // -----------------------------

        protected int NormalizarIngresos(decimal ingresos)
        {
            if (ingresos < 200_000) return 20;
            if (ingresos < 500_000) return 60;
            return 100;
        }

        protected int NormalizarHistorial(int historial)
        {
            // ya viene 0–100
            return historial;
        }

        protected int NormalizarEdad(int edad)
        {
            if (edad >= 25 && edad <= 60) return 100;
            if (edad >= 18) return 70;
            return 40;
        }

        protected int NormalizarGarantias(decimal valor)
        {
            if (valor < 100_000) return 20;
            if (valor < 500_000) return 60;
            return 100;
        }

        // -----------------------------
        // Reglas comunes de resultado
        // -----------------------------

        protected NivelRiesgo ObtenerNivel(int score)
        {
            if (score >= 80) return NivelRiesgo.Bajo;
            if (score >= 50) return NivelRiesgo.Medio;
            return NivelRiesgo.Alto;
        }

        protected ResultadoEvaluacion ConstruirResultado(int score, string obs)
        {
            return new ResultadoEvaluacion
            {
                Score = score,
                Nivel = ObtenerNivel(score),
                Aprobado = score >= 50,
                Observaciones = obs
            };
        }
    }
}
