using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EstadoBloqueada : IEstadoTarea
    {
        public string Nombre => "Bloqueada";

        public void Iniciar(TareaKanban tarea)
        {
            tarea.CambiarEstado(new EstadoEnProceso());
        }

        public void Bloquear(TareaKanban tarea, string motivo)
        {
            throw new InvalidOperationException("La tarea ya está bloqueada.");
        }

        public void Revisar(TareaKanban tarea)
        {
            throw new InvalidOperationException("No se puede revisar una tarea bloqueada.");
        }

        public void Finalizar(TareaKanban tarea)
        {
            throw new InvalidOperationException("No se puede finalizar una tarea bloqueada.");
        }
    }

}
