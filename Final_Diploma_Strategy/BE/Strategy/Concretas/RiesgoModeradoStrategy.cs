using BE.Entidades;
using BE.Strategy.Base;

namespace BE.Strategy.Concretas
{
    public class RiesgoModeradoStrategy : EstrategiaRiesgoBase
    {
        public override ResultadoEvaluacion Evaluar(Cliente cliente)
        {
            int ingresos = NormalizarIngresos(cliente.IngresosMensuales);
            int historial = NormalizarHistorial(cliente.ScoreHistorial);
            int edad = NormalizarEdad(cliente.Edad);
            int garantias = NormalizarGarantias(cliente.ValorGarantias);

            int scoreFinal =
                (int)(
                    ingresos * 0.30 +
                    historial * 0.30 +
                    garantias * 0.20 +
                    edad * 0.20
                );

            return ConstruirResultado(
                scoreFinal,
                "Evaluación moderada: balance entre ingresos, historial y garantías."
            );
        }
    }
}
