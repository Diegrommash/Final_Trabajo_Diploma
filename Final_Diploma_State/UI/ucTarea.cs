using BE;
using BLL;


namespace UI
{
    public partial class ucTarea : UserControl
    {
        private readonly ServTarea _servTarea;
        private readonly TareaKanban _tarea;

        public event Action? EstadoCambiado;

        public ucTarea(TareaKanban tarea, ServTarea servTarea)
        {
            InitializeComponent();
            _tarea = tarea;
            _servTarea = servTarea;

            lblTitulo.Text = tarea.Titulo;
            lblEstado.Text = tarea.EstadoActual;

            ActualizarBotones();

            this.DoubleClick += ucTarea_DoubleClick;
            foreach (Control c in Controls)
            {
                c.DoubleClick += ucTarea_DoubleClick;
            }
        }

        private void ActualizarBotones()
        {
            btnIniciar.Enabled = _tarea.EstadoActual is "Pendiente" or "Bloqueada";
            btnBloquear.Enabled = _tarea.EstadoActual != "Finalizada";
            btnRevisar.Enabled = _tarea.EstadoActual == "EnProceso";
            btnFinalizar.Enabled = _tarea.EstadoActual == "EnRevision";
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            Procesar(await _servTarea.IniciarAsync(_tarea));
        }

        private async void btnBloquear_Click(object sender, EventArgs e)
        {
            Procesar(await _servTarea.BloquearAsync(_tarea, "Bloqueo manual"));
        }

        private async void btnRevisar_Click(object sender, EventArgs e)
        {
            Procesar(await _servTarea.RevisarAsync(_tarea));
        }

        private async void btnFinalizar_Click(object sender, EventArgs e)
        {
            Procesar(await _servTarea.FinalizarAsync(_tarea));
        }

        private void Procesar(Resultado resultado)
        {
            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Error);
                return;
            }

            lblEstado.Text = _tarea.EstadoActual;
            ActualizarBotones();
            EstadoCambiado?.Invoke();
        }

        private void ucTarea_DoubleClick(object? sender, EventArgs e)
        {
            MessageBox.Show(
                _tarea.Descripcion,
                _tarea.Titulo,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private async void btnHistorial_Click(object sender, EventArgs e)
        {
            var resultado = await _servTarea.ObtenerHistorialAsync(_tarea.IdTarea);

            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Error);
                return;
            }

            using var frm = new frmHistorial(resultado.Valor!, _tarea.Titulo);
            frm.ShowDialog();
        }

    }
}
