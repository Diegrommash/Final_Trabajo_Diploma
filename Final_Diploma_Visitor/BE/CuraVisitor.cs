
namespace BE
{
    public class CuraVisitor : IEfectoVisitor
    {
        public string Visitar(Guerrero g, bool inicio)
        {
            g.Vida += 20;
            return "El Guerrero recupera vitalidad: +20 Vida.";
        }

        public string Visitar(Mago m, bool inicio)
        {
            m.Vida += 35; 
            return "La energía arcana sana profundamente al Mago: +35 Vida.";
        }

        public string Visitar(Arquero a, bool inicio)
        {
            a.Vida += 25;
            return "El Arquero recupera aliento y precisión: +25 Vida.";
        }
    }
}
