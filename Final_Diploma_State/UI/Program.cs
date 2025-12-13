using BLL;
using DAL;
using Microsoft.Extensions.Configuration;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            string? cadenaConexion = configuration.GetConnectionString("default");

            if (string.IsNullOrEmpty(cadenaConexion))
                throw new Exception("No se encontró la cadena de conexión.");

            var acceso = new Acceso(cadenaConexion);
            var repo = new RepositorioTarea(acceso);
            var servicio = new ServTarea(repo);

            ApplicationConfiguration.Initialize();
            Application.Run(new frmKanban(servicio));
        }
    }
}
