using BE.Entidades;
using BE.Strategy.Base;

namespace BE.Strategy.Concretas
{
    public class RiesgoAgresivoStrategy : EstrategiaRiesgoBase
    {
        public override ResultadoEvaluacion Evaluar(Cliente cliente)
        {
            int ingresos = NormalizarIngresos(cliente.IngresosMensuales);
            int historial = NormalizarHistorial(cliente.ScoreHistorial);
            int edad = NormalizarEdad(cliente.Edad);
            int garantias = NormalizarGarantias(cliente.ValorGarantias);

            int scoreFinal =
                (int)(
                    ingresos * 0.45 +
                    edad * 0.25 +
                    historial * 0.20 +
                    garantias * 0.10
                );

            return ConstruirResultado(
                scoreFinal,
                "Evaluación agresiva: se prioriza capacidad de pago actual."
            );
        }
    }
}
