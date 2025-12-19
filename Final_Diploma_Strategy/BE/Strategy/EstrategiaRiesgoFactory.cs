using BE.Enums;
using BE.Strategy;
using BE.Strategy.Concretas;

namespace BE
{
    public static class EstrategiaRiesgoFactory
    {
        public static IEstrategiaRiesgo Crear(TipoEstrategiaRiesgo tipo)
        {
            return tipo switch
            {
                TipoEstrategiaRiesgo.Conservador => new RiesgoConservadorStrategy(),
                TipoEstrategiaRiesgo.Moderado => new RiesgoModeradoStrategy(),
                TipoEstrategiaRiesgo.Agresivo => new RiesgoAgresivoStrategy(),
                TipoEstrategiaRiesgo.Social => new RiesgoSocialStrategy(),
                TipoEstrategiaRiesgo.Prudente => new RiesgoPrudenteStrategy(),

                _ => throw new ArgumentException("Tipo de estrategia de riesgo no soportada")
            };
        }
    }
}
