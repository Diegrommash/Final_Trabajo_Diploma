using BE.Entidades;
using BE.Strategy.Base;

public class RiesgoPrudenteStrategy : EstrategiaRiesgoBase
{
    public override ResultadoEvaluacion Evaluar(Cliente cliente)
    {
        int ingresos = NormalizarIngresos(cliente.IngresosMensuales);
        int historial = NormalizarHistorial(cliente.ScoreHistorial);
        int edad = NormalizarEdad(cliente.Edad);
        int garantias = NormalizarGarantias(cliente.ValorGarantias);

        int scoreFinal =
            (int)(
                historial * 0.35 +
                ingresos * 0.30 +
                garantias * 0.20 +
                edad * 0.15
            );

        if (historial < 40)
            scoreFinal -= 15;

        return ConstruirResultado(
            scoreFinal,
            "Evaluación prudente: penaliza historial crediticio deficiente."
        );
    }
}
