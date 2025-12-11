using System.Data;
using BE;
using DAL;
using Microsoft.Data.SqlClient;

public class RepoPersonaje
{
    private readonly Acceso _acceso;

    public RepoPersonaje(Acceso acceso)
    {
        _acceso = acceso;
    }

    public async Task<int> InsertarAsync(IPersonaje pj)
    {
        var parametros = new List<SqlParameter>
        {
            _acceso.CrearParametro("@Tipo", pj.Tipo, DbType.String),
            _acceso.CrearParametro("@Vida", pj.Vida, DbType.Int32),
            _acceso.CrearParametro("@Mana", pj.Mana, DbType.Int32),
            _acceso.CrearParametro("@Ataque", pj.Ataque, DbType.Int32),
            _acceso.CrearParametro("@Defensa", pj.Defensa, DbType.Int32)
        };

        object? scalar = await _acceso.EjecutarEscalarAsync("SP_INSERTAR_PERSONAJE", parametros);

        return Convert.ToInt32(scalar);
    }

    public async Task<int> ModificarAsync(IPersonaje pj)
    {
        var parametros = new List<SqlParameter>
        {
            _acceso.CrearParametro("@Id", pj.Id, DbType.Int32),
            _acceso.CrearParametro("@Tipo", pj.Tipo, DbType.String),
            _acceso.CrearParametro("@Vida", pj.Vida, DbType.Int32),
            _acceso.CrearParametro("@Mana", pj.Mana, DbType.Int32),
            _acceso.CrearParametro("@Ataque", pj.Ataque, DbType.Int32),
            _acceso.CrearParametro("@Defensa", pj.Defensa, DbType.Int32)
        };

        return await _acceso.EjecutarNonQueryAsync("SP_MODIFICAR_PERSONAJE", parametros);
    }

    public async Task<int> EliminarAsync(int id)
    {
        var parametros = new List<SqlParameter>
        {
            _acceso.CrearParametro("@Id", id, DbType.Int32)
        };

        return await _acceso.EjecutarNonQueryAsync("SP_ELIMINAR_PERSONAJE", parametros);
    }

    public async Task<IPersonaje?> ObtenerPorIdAsync(int id)
    {
        var parametros = new List<SqlParameter>
        {
            _acceso.CrearParametro("@Id", id, DbType.Int32)
        };

        DataTable tabla = await _acceso.EjecutarQueryAsync("SP_OBTENER_PERSONAJE", parametros);

        if (tabla.Rows.Count == 0)
            return null;

        DataRow row = tabla.Rows[0];

        IPersonaje? pj = CrearPersonajeDesdeRow(row);

        return pj;
    }

    public async Task<List<IPersonaje>> ListarAsync()
    {
        DataTable tabla = await _acceso.EjecutarQueryAsync("SP_LISTAR_PERSONAJES");

        List<IPersonaje> lista = new();

        foreach (DataRow row in tabla.Rows)
        {
            IPersonaje? pj = CrearPersonajeDesdeRow(row);

            if (pj != null)
                lista.Add(pj);
        }

        return lista;
    }

    private IPersonaje? CrearPersonajeDesdeRow(DataRow row)
    {
        IPersonaje? pj = row["Tipo"].ToString() switch
        {
            "Guerrero" => new Guerrero(),
            "Mago" => new Mago(),
            "Arquero" => new Arquero(),
            _ => null
        };

        if (pj != null)
        {
            pj.Id = Convert.ToInt32(row["Id"]);
            pj.Vida = Convert.ToInt32(row["Vida"]);
            pj.Mana = Convert.ToInt32(row["Mana"]);
            pj.Ataque = Convert.ToInt32(row["Ataque"]);
            pj.Defensa = Convert.ToInt32(row["Defensa"]);
        }

        return pj;
    }
}
