using BE.Entidades;
using BE.Strategy.Base;

namespace BE.Strategy.Concretas
{
    public class RiesgoSocialStrategy : EstrategiaRiesgoBase
    {
        public override ResultadoEvaluacion Evaluar(Cliente cliente)
        {
            int ingresos = NormalizarIngresos(cliente.IngresosMensuales);
            int historial = NormalizarHistorial(cliente.ScoreHistorial);
            int edad = NormalizarEdad(cliente.Edad);
            int garantias = NormalizarGarantias(cliente.ValorGarantias);

            int scoreFinal =
                (int)(
                    edad * 0.35 +
                    ingresos * 0.35 +
                    historial * 0.20 +
                    garantias * 0.10
                );

            return ConstruirResultado(
                scoreFinal,
                "Evaluación social: se prioriza inclusión y edad productiva."
            );
        }
    }
}
