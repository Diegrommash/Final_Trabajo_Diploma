using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServTarea
    {
        private readonly RepositorioTarea _repo;

        public ServTarea(RepositorioTarea repo)
        {
            _repo = repo;
        }

        // --------------------------------------------
        // Crear tarea
        // --------------------------------------------
        public async Task<Resultado<int>> CrearTareaAsync(string titulo, string descripcion)
        {
            try
            {
                int id = await _repo.CrearAsync(titulo, descripcion);
                return Resultado<int>.Correcto(id);
            }
            catch (Exception ex)
            {
                return Resultado<int>.Fallo(ex.Message);
            }
        }

        // --------------------------------------------
        // Iniciar tarea
        // --------------------------------------------
        public async Task<Resultado> IniciarAsync(TareaKanban tarea)
        {
            try
            {
                tarea.Iniciar();
                await PersistirEstadoAsync(tarea, "Inicio de la tarea");
                return Resultado.Correcto();
            }
            catch (Exception ex)
            {
                return Resultado.Fallo(ex.Message);
            }
        }

        // --------------------------------------------
        // Bloquear tarea
        // --------------------------------------------
        public async Task<Resultado> BloquearAsync(TareaKanban tarea, string motivo)
        {
            try
            {
                tarea.Bloquear(motivo);
                await PersistirEstadoAsync(tarea, motivo);
                return Resultado.Correcto();
            }
            catch (Exception ex)
            {
                return Resultado.Fallo(ex.Message);
            }
        }

        // --------------------------------------------
        // Enviar a revisión
        // --------------------------------------------
        public async Task<Resultado> RevisarAsync(TareaKanban tarea)
        {
            try
            {
                tarea.Revisar();
                await PersistirEstadoAsync(tarea, "En revisión");
                return Resultado.Correcto();
            }
            catch (Exception ex)
            {
                return Resultado.Fallo(ex.Message);
            }
        }

        // --------------------------------------------
        // Finalizar tarea
        // --------------------------------------------
        public async Task<Resultado> FinalizarAsync(TareaKanban tarea)
        {
            try
            {
                tarea.Finalizar();
                await PersistirEstadoAsync(tarea, "Tarea finalizada");
                return Resultado.Correcto();
            }
            catch (Exception ex)
            {
                return Resultado.Fallo(ex.Message);
            }
        }

        // --------------------------------------------
        // Obtener tareas por estado
        // --------------------------------------------
        public async Task<Resultado<List<TareaKanban>>> ObtenerPorEstadoAsync(string estado)
        {
            try
            {
                var dtos = await _repo.ObtenerPorEstadoAsync(estado);
                var tareas = dtos.Select(MapearDominio).ToList();

                return Resultado<List<TareaKanban>>.Correcto(tareas);
            }
            catch (Exception ex)
            {
                return Resultado<List<TareaKanban>>.Fallo(ex.Message);
            }
        }

        // --------------------------------------------
        // Persistir estado
        // --------------------------------------------
        private async Task PersistirEstadoAsync(TareaKanban tarea, string? motivo)
        {
            await _repo.CambiarEstadoAsync(
                tarea.IdTarea,
                tarea.EstadoActual,
                motivo);
        }

        public async Task<Resultado<List<HistorialTarea>>> ObtenerHistorialAsync(int idTarea)
        {
            try
            {
                var lista = await _repo.ObtenerHistorialAsync(idTarea);
                return Resultado<List<HistorialTarea>>.Correcto(lista);
            }
            catch (Exception ex)
            {
                return Resultado<List<HistorialTarea>>.Fallo(ex.Message);
            }
        }


        // --------------------------------------------
        // Mapper DTO → Dominio
        // --------------------------------------------
        private TareaKanban MapearDominio(Tarea dto)
        {
            IEstadoTarea estado = dto.EstadoActual switch
            {
                "Pendiente" => new EstadoPendiente(),
                "EnProceso" => new EstadoEnProceso(),
                "Bloqueada" => new EstadoBloqueada(),
                "EnRevision" => new EstadoEnRevision(),
                "Finalizada" => new EstadoFinalizada(),
                _ => throw new InvalidOperationException("Estado desconocido")
            };

            return new TareaKanban(dto.IdTarea, dto.Titulo, estado, dto.Descripcion ?? "Sin descripcion");
        }
    }
}
