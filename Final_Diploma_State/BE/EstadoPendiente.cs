using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EstadoPendiente : IEstadoTarea
    {
        public string Nombre => "Pendiente";

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
            throw new InvalidOperationException("La tarea aún no puede revisarse.");
        }

        public void Finalizar(TareaKanban tarea)
        {
            throw new InvalidOperationException("La tarea no puede finalizarse desde Pendiente.");
        }
    }

}
