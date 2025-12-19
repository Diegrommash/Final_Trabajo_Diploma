
using BE.Enums;
using BE.Visitor;

namespace BE
{
    public interface IPersonaje
    {
        int Id { get; set; }
        int Vida { get; set; }
        int Mana { get; set; }
        int Ataque { get; set; }
        int Defensa { get; set; }
        TipoPersonaje Tipo { get;}

        List<EstadoTemporal> EstadosTemporales { get; }

        string Aceptar(IEfectoVisitor visitor, bool inicio);
    }
}
