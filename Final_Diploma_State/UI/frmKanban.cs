using BLL;

namespace UI
{
    public partial class frmKanban : Form
    {
        private readonly ServTarea _servTarea;

        public frmKanban(ServTarea servTarea)
        {
            InitializeComponent();
            _servTarea = servTarea;
        }

        private async void frmKanban_Load(object sender, EventArgs e)
        {
            await CargarTableroAsync();
        }

        private async Task CargarTableroAsync()
        {
            LimpiarColumnas();

            await CargarColumnaAsync("Pendiente", flpPendiente);
            await CargarColumnaAsync("EnProceso", flpEnProceso);
            await CargarColumnaAsync("Bloqueada", flpBloqueada);
            await CargarColumnaAsync("EnRevision", flpEnRevision);
            await CargarColumnaAsync("Finalizada", flpFinalizada);
        }

        private async Task CargarColumnaAsync(string estado, FlowLayoutPanel panel)
        {
            var resultado = await _servTarea.ObtenerPorEstadoAsync(estado);
            if (!resultado.Exito) return;

            foreach (var tarea in resultado.Valor!)
            {
                var card = new ucTarea(tarea, _servTarea);
                card.EstadoCambiado += async () => await CargarTableroAsync();
                panel.Controls.Add(card);
            }
        }

        private void LimpiarColumnas()
        {
            flpPendiente.Controls.Clear();
            flpEnProceso.Controls.Clear();
            flpBloqueada.Controls.Clear();
            flpEnRevision.Controls.Clear();
            flpFinalizada.Controls.Clear();
        }

        private async void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            using var frm = new frmNuevaTarea(_servTarea);
            frm.ShowDialog();
            await CargarTableroAsync();
        }
    }
}
