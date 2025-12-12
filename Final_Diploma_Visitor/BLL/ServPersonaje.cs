using BE;
using DAL;


namespace BLL
{
    public class ServPersonaje
    {
        private readonly RepoPersonaje _repoPersonaje;

        public ServPersonaje(RepoPersonaje repoPersonaje)
        {
            _repoPersonaje = repoPersonaje;
        }

        public async Task<Resultado<List<IPersonaje>>> ObtenerTodosAsync()
        {
            try
            {
                var lista = await _repoPersonaje.ListarAsync();
                return Resultado<List<IPersonaje>>.Correcto(lista);
            }
            catch (Exception ex)
            {
                return Resultado<List<IPersonaje>>.Fallo(
                    "Error al obtener los personajes: " + ex.Message);
            }
        }

        public async Task<Resultado<IPersonaje>> ObtenerPorIdAsync(int id)
        {
            try
            {
                var personaje = await _repoPersonaje.ObtenerPorIdAsync(id);

                if (personaje == null)
                    return Resultado<IPersonaje>.Fallo("El personaje solicitado no existe.");

                return Resultado<IPersonaje>.Correcto(personaje);
            }
            catch (Exception ex)
            {
                return Resultado<IPersonaje>.Fallo(
                    "Error al obtener el personaje: " + ex.Message);
            }
        }

        public async Task<Resultado<int>> CrearAsync(IPersonaje personaje)
        {
            try
            {
                int nuevoId = await _repoPersonaje.InsertarAsync(personaje);
                return Resultado<int>.Correcto(nuevoId);
            }
            catch (Exception ex)
            {
                return Resultado<int>.Fallo(
                    "No se pudo crear el personaje: " + ex.Message);
            }
        }

        public async Task<Resultado> ModificarAsync(IPersonaje personaje)
        {
            try
            {
                int filas = await _repoPersonaje.ModificarAsync(personaje);

                if (filas == 0)
                    return Resultado.Fallo("No existe el personaje que intenta modificar.");

                return Resultado.Correcto();
            }
            catch (Exception ex)
            {
                return Resultado.Fallo(
                    "Error al modificar el personaje: " + ex.Message);
            }
        }

        public async Task<Resultado> EliminarAsync(int id)
        {
            try
            {
                int filas = await _repoPersonaje.EliminarAsync(id);

                if (filas == 0)
                    return Resultado.Fallo("El personaje no existe o ya fue eliminado.");

                return Resultado.Correcto();
            }
            catch (Exception ex)
            {
                return Resultado.Fallo(
                    "Error al eliminar el personaje: " + ex.Message);
            }
        }

        //public async Task<Resultado> AplicarEfectoAsync(IPersonaje personaje, IEfectoVisitor efecto)
        //{
        //    try
        //    {
        //        if (personaje == null)
        //            return Resultado.Fallo("No se recibió un personaje válido.");

        //        personaje.Aceptar(efecto, true);

        //        int filas = await _repoPersonaje.ModificarAsync(personaje);

        //        if (filas == 0)
        //            return Resultado.Fallo("No se pudo guardar el efecto aplicado en la base de datos.");

        //        return Resultado.Correcto();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Resultado.Fallo(
        //            "Error al aplicar el efecto: " + ex.Message);
        //    }
        //}

        //public async Task<Resultado> AplicarEfectoAsync(int id, IEfectoVisitor efecto)
        //{
        //    try
        //    {
        //        var resPj = await ObtenerPorIdAsync(id);
        //        if (!resPj.Exito || resPj.Valor == null)
        //            return Resultado.Fallo(resPj.Error ?? "No se pudo obtener el personaje.");

        //        var personaje = resPj.Valor;

        //        personaje.Aceptar(efecto, true);

        //        int filas = await _repoPersonaje.ModificarAsync(personaje);
        //        if (filas == 0)
        //            return Resultado.Fallo("No se pudo guardar el efecto aplicado.");

        //        return Resultado.Correcto();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Resultado.Fallo("Error al aplicar el efecto: " + ex.Message);
        //    }
        //}

      
    }
}
