using BE.Entidades;
using DAL;

public class ServicioCliente
{
    private readonly ClienteRepository _repo;

    public ServicioCliente(ClienteRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Cliente>> ObtenerTodosAsync()
        => _repo.ObtenerTodosAsync();

    public Task<Cliente?> ObtenerPorIdAsync(int id)
        => _repo.ObtenerPorIdAsync(id);

    public Task AgregarAsync(Cliente cliente)
        => _repo.AgregarAsync(cliente);

    public Task ModificarAsync(Cliente cliente)
        => _repo.ModificarAsync(cliente);

    public Task EliminarAsync(int id)
        => _repo.EliminarAsync(id);
}
