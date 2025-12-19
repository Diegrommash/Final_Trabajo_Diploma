using BE.Entidades;

namespace BE.Strategy
{
    public interface IEstrategiaRiesgo
    {
        ResultadoEvaluacion Evaluar(Cliente cliente);
    }
}
