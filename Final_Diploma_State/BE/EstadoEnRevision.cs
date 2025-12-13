using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EstadoEnRevision : IEstadoTarea
    {
        public string Nombre => "EnRevision";

        public void Iniciar(TareaKanban tarea)
        {
            tarea.CambiarEstado(new EstadoEnProceso());
        }

        public void Bloquear(TareaKanban tarea, string motivo)
        {
            tarea.CambiarEstado(new EstadoBloqueada());
        }

        public void Revisar(TareaKanban tarea)
        {
            throw new InvalidOperationException("La tarea ya está en revisión.");
        }

        public void Finalizar(TareaKanban tarea)
        {
            tarea.CambiarEstado(new EstadoFinalizada());
        }
    }

}
