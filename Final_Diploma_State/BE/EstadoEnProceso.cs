using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EstadoEnProceso : IEstadoTarea
    {
        public string Nombre => "EnProceso";

        public void Iniciar(TareaKanban tarea)
        {
            throw new InvalidOperationException("La tarea ya está en proceso.");
        }

        public void Bloquear(TareaKanban tarea, string motivo)
        {
            tarea.CambiarEstado(new EstadoBloqueada());
        }

        public void Revisar(TareaKanban tarea)
        {
            tarea.CambiarEstado(new EstadoEnRevision());
        }

        public void Finalizar(TareaKanban tarea)
        {
            throw new InvalidOperationException("Debe pasar por revisión antes de finalizar.");
        }
    }

}
