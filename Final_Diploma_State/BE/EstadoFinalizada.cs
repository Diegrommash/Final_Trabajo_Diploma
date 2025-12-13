using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EstadoFinalizada : IEstadoTarea
    {
        public string Nombre => "Finalizada";

        public void Iniciar(TareaKanban tarea)
        {
            throw new InvalidOperationException("La tarea está finalizada.");
        }

        public void Bloquear(TareaKanban tarea, string motivo)
        {
            throw new InvalidOperationException("No se puede bloquear una tarea finalizada.");
        }

        public void Revisar(TareaKanban tarea)
        {
            throw new InvalidOperationException("La tarea ya fue finalizada.");
        }

        public void Finalizar(TareaKanban tarea)
        {
            throw new InvalidOperationException("La tarea ya está finalizada.");
        }
    }

}
