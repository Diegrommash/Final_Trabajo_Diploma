using BE.Enums;

namespace BE.Entidades
{
    public class TipoRiesgo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TipoEstrategiaRiesgo TipoEstrategia { get; set; }
        public bool Activa { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public override string ToString() => Nombre;

    }
}
