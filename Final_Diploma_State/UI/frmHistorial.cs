using BE;

namespace UI
{
    public partial class frmHistorial : Form
    {
        public frmHistorial(List<HistorialTarea> historial, string titulo)
        {
            InitializeComponent();

            Text = $"Historial - {titulo}";
            dgvHistorial.DataSource = historial;
        }
    }
}
