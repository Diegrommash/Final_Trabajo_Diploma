using BLL;

namespace UI
{
    public partial class frmNuevaTarea : Form
    {
        private readonly ServTarea _servTarea;

        public frmNuevaTarea(ServTarea servTarea)
        {
            InitializeComponent();
            _servTarea = servTarea;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título es obligatorio.");
                return;
            }

            Resultado<int> r = await _servTarea.CrearTareaAsync(
                txtTitulo.Text,
                txtDescripcion.Text);

            if (!r.Exito)
            {
                MessageBox.Show(r.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
