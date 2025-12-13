using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IEstadoTarea
    {
        string Nombre { get; }

        void Iniciar(TareaKanban tarea);
        void Bloquear(TareaKanban tarea, string motivo);
        void Revisar(TareaKanban tarea);
        void Finalizar(TareaKanban tarea);
    }
}
