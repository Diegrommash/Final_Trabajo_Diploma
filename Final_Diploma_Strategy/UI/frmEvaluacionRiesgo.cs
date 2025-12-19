using BE.Entidades;
using BE.Enums;
using BLL;

namespace UI
{
    public partial class frmEvaluacionRiesgo : Form
    {
        private readonly ServicioEvaluacionRiesgo _servicioEvaluacion;
        private readonly ServicioConsultaRiesgo _servicioConsulta;

        public frmEvaluacionRiesgo(
            ServicioEvaluacionRiesgo servicioEvaluacion,
            ServicioConsultaRiesgo servicioConsulta)
        {
            InitializeComponent();
            _servicioEvaluacion = servicioEvaluacion;
            _servicioConsulta = servicioConsulta;

            Load += FrmEvaluacionRiesgo_Load;
            cboClientes.SelectedIndexChanged += CboClientes_SelectedIndexChanged;
            cboRiesgos.SelectedIndexChanged += CboRiesgos_SelectedIndexChanged;
            btnEvaluar.Click += BtnEvaluar_Click;
        }

        private void CboRiesgos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboRiesgos.SelectedItem is not TipoRiesgo tipo)
                return;

            txtObservacionesEstrategia.Text = NormalizarObservaciones(tipo.Observaciones);
        }

        private async void FrmEvaluacionRiesgo_Load(object? sender, EventArgs e)
        {
            cboClientes.DataSource = await _servicioConsulta.ObtenerClientesAsync();
            cboClientes.DisplayMember = "Nombre";
            cboClientes.ValueMember = "Id";

            cboRiesgos.DataSource = await _servicioConsulta.ObternesEstrategiasActivasAsync();
            cboRiesgos.DisplayMember = "Nombre";
            cboRiesgos.ValueMember = "Id";

        }

        private async void CboClientes_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboClientes.SelectedItem is not Cliente cliente) return;

            lblIngresos.Text = $"Ingresos: {cliente.IngresosMensuales:C}";
            lblEdad.Text = $"Edad: {cliente.Edad}";
            lblHistorial.Text = $"Historial: {cliente.ScoreHistorial}";
            lblGarantias.Text = $"Garantías: {cliente.ValorGarantias:C}";

            dgvHistorial.DataSource =
                await _servicioConsulta.ObtenerHistorialEvaluacionesAsync(cliente.Id);
        }

        private async void BtnEvaluar_Click(object? sender, EventArgs e)
        {
            if (cboClientes.SelectedItem is not Cliente cliente) return;
            if (cboRiesgos.SelectedItem is not TipoRiesgo tipo) return;

            var resultado = await _servicioEvaluacion
                .EvaluarAsync(cliente, tipo);

            lblResultado.Text =
                $"Score: {resultado.Score} | Nivel: {resultado.Nivel} | " +
                $"Resultado: {(resultado.Aprobado ? "APROBADO" : "RECHAZADO")}";
        }

        private string NormalizarObservaciones(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            return texto
                .Replace("\r\n", "\n")
                .Replace("\n", Environment.NewLine)
                .Split(Environment.NewLine)
                .Select(linea => linea.Trim())
                .Aggregate((a, b) => a + Environment.NewLine + b);
        }
    }
}
