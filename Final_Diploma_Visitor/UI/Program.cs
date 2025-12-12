using BLL;
using DAL;
using Microsoft.Extensions.Configuration;

namespace UI
{
    internal static class Program
    {
        public static IConfiguration Configuration;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            string? cadena = Program.Configuration.GetConnectionString("default");
            Acceso acceso = new Acceso(cadena);
            RepoPersonaje repoPersonaje = new RepoPersonaje(acceso);
            ServPersonaje servPersonaje = new ServPersonaje(repoPersonaje);

            RepoStatsPersonaje repoStatsPersonaje = new RepoStatsPersonaje(acceso);
            ServStatsPersonaje servStatsPersonaje = new ServStatsPersonaje(repoStatsPersonaje);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal(servPersonaje, servStatsPersonaje));
        }
    }
}