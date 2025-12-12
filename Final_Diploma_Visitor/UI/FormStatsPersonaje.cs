using BE;
using BLL;

namespace UI
{
    public partial class FormStatsPersonaje : Form
    {
        private readonly ServStatsPersonaje _servStats;
        private readonly int _idPersonaje;

        public FormStatsPersonaje(int idPersonaje, ServStatsPersonaje servStats)
        {
            InitializeComponent();
            _idPersonaje = idPersonaje;
            _servStats = servStats;
        }

        private async void FormStatsPersonaje_Load(object sender, EventArgs e)
        {
            var stats = await _servStats.ObtenerStats(_idPersonaje);

            if (stats == null)
            {
                MessageBox.Show("No se encontraron estadísticas para el personaje.");
                Close();
                return;
            }

            lblBatallasJugadas.Text = stats.BatallasJugadas.ToString();
            lblGanadas.Text = stats.BatallasGanadas.ToString();
            lblPerdidas.Text = stats.BatallasPerdidas.ToString();

            lblDanioCausado.Text = stats.DanioCausadoTotal.ToString();
            lblDanioRecibido.Text = stats.DanioRecibidoTotal.ToString();

            lblEfectosAplicados.Text = stats.EfectosAplicados.ToString();
            lblEfectosRecibidos.Text = stats.EfectosRecibidos.ToString();

            lblTurnos.Text = stats.TurnosSobrevividosTotales.ToString();
            lblMaxTurnos.Text = stats.MaxTurnosEnBatalla.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
