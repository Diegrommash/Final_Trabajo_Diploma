using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TareaKanban
    {
        public int IdTarea { get; private set; }
        public string Titulo { get; private set; }
        public string? Descripcion { get; private set; }
        public string EstadoActual => _estado.Nombre;

        private IEstadoTarea _estado;

        public TareaKanban(int idTarea, string titulo, IEstadoTarea estadoInicial, string descripcion)
        {
            IdTarea = idTarea;
            Titulo = titulo;
            _estado = estadoInicial;
            Descripcion = descripcion;
        }

        internal void CambiarEstado(IEstadoTarea nuevoEstado)
        {
            _estado = nuevoEstado;
        }

        public void Iniciar() => _estado.Iniciar(this);
        public void Bloquear(string motivo) => _estado.Bloquear(this, motivo);
        public void Revisar() => _estado.Revisar(this);
        public void Finalizar() => _estado.Finalizar(this);
    }
}
