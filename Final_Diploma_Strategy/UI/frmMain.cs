using BLL;

namespace UI
{
    public partial class frmMain : Form
    {
        private readonly ServicioCliente _servicioCliente;
        private readonly ServicioEvaluacionRiesgo _servicioEvaluacion;
        private readonly ServicioConsultaRiesgo _servicioConsulta;

        public frmMain(
            ServicioCliente servicioCliente,
            ServicioEvaluacionRiesgo servicioEvaluacion,
            ServicioConsultaRiesgo servicioConsulta)
        {
            InitializeComponent();

            _servicioCliente = servicioCliente;
            _servicioEvaluacion = servicioEvaluacion;
            _servicioConsulta = servicioConsulta;

            btnClientes.Click += BtnClientes_Click;
            btnEvaluacion.Click += BtnEvaluacion_Click;
        }

        private void BtnClientes_Click(object? sender, EventArgs e)
        {
            MarcarBotonActivo(btnClientes);
            AbrirFormulario(new frmClientes(_servicioCliente));
        }

        private void BtnEvaluacion_Click(object? sender, EventArgs e)
        {
            MarcarBotonActivo(btnEvaluacion);
            AbrirFormulario(new frmEvaluacionRiesgo(
                _servicioEvaluacion,
                _servicioConsulta));
        }

        private void AbrirFormulario(Form formulario)
        {
            pnlContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void MarcarBotonActivo(Button botonActivo)
        {
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is Button btn)
                    btn.BackColor = Color.FromArgb(45, 45, 48);
            }

            botonActivo.BackColor = Color.FromArgb(28, 151, 234);
        }

    }
}
