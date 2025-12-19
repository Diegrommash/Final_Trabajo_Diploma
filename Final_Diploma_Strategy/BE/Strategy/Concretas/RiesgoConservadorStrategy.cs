using BE.Entidades;
using BE.Strategy.Base;

namespace BE.Strategy.Concretas
{
    public class RiesgoConservadorStrategy : EstrategiaRiesgoBase
    {
        public override ResultadoEvaluacion Evaluar(Cliente cliente)
        {
            int ingresos = NormalizarIngresos(cliente.IngresosMensuales);
            int historial = NormalizarHistorial(cliente.ScoreHistorial);
            int edad = NormalizarEdad(cliente.Edad);
            int garantias = NormalizarGarantias(cliente.ValorGarantias);

            int scoreFinal =
                (int)(
                    historial * 0.40 +
                    garantias * 0.30 +
                    ingresos * 0.20 +
                    edad * 0.10
                );

            return ConstruirResultado(
                scoreFinal,
                "Evaluación conservadora: se priorizan historial y garantías."
            );
        }
    }
}
