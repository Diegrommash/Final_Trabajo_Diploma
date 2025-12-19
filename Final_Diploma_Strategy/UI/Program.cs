using DAL;
using Microsoft.Extensions.Configuration;
using BLL;


namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
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

            var repoEvaluacionCrediticia = new EvaluacionCrediticiaRepository(acceso);
            var repoEstrategiaRiesgoRepository = new EstrategiaRiesgoRepository(acceso);
            var repoClienteRepository = new ClienteRepository(acceso);

            var servicioCliente = new ServicioCliente(repoClienteRepository);
            var servicioEvaluacion = new ServicioEvaluacionRiesgo(repoClienteRepository, repoEstrategiaRiesgoRepository, repoEvaluacionCrediticia);
            var servicioConsultaRiego = new ServicioConsultaRiesgo(repoClienteRepository, repoEstrategiaRiesgoRepository, repoEvaluacionCrediticia);



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain(servicioCliente, servicioEvaluacion, servicioConsultaRiego));
        }
    }
}