using BE.Entidades;

namespace UI
{
    public partial class frmClientes : Form
    {
        private readonly ServicioCliente _servicioCliente;
        private Cliente? _clienteSeleccionado;

        public frmClientes(ServicioCliente servicioCliente)
        {
            InitializeComponent();
            _servicioCliente = servicioCliente;

            Load += FrmClientes_Load;
            dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;
            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private async void FrmClientes_Load(object? sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private async Task CargarClientesAsync()
        {
            dgvClientes.DataSource = await _servicioCliente.ObtenerTodosAsync();
            dgvClientes.ClearSelection();
        }

        private void DgvClientes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow?.DataBoundItem is not Cliente cliente)
                return;

            _clienteSeleccionado = cliente;

            txtNombre.Text = cliente.Nombre;
            nudIngresos.Value = cliente.IngresosMensuales;
            nudEdad.Value = cliente.Edad;
            nudHistorial.Value = cliente.ScoreHistorial;
            nudGarantias.Value = cliente.ValorGarantias;
        }

        private async void BtnAgregar_Click(object? sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                IngresosMensuales = nudIngresos.Value,
                Edad = (int)nudEdad.Value,
                ScoreHistorial = (int)nudHistorial.Value,
                ValorGarantias = nudGarantias.Value
            };

            await _servicioCliente.AgregarAsync(cliente);
            await CargarClientesAsync();
            Limpiar();
        }

        private async void BtnModificar_Click(object? sender, EventArgs e)
        {
            if (_clienteSeleccionado == null) return;

            _clienteSeleccionado.Nombre = txtNombre.Text;
            _clienteSeleccionado.IngresosMensuales = nudIngresos.Value;
            _clienteSeleccionado.Edad = (int)nudEdad.Value;
            _clienteSeleccionado.ScoreHistorial = (int)nudHistorial.Value;
            _clienteSeleccionado.ValorGarantias = nudGarantias.Value;

            await _servicioCliente.ModificarAsync(_clienteSeleccionado);
            await CargarClientesAsync();
            Limpiar();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_clienteSeleccionado == null) return;

            await _servicioCliente.EliminarAsync(_clienteSeleccionado.Id);
            await CargarClientesAsync();
            Limpiar();
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            nudIngresos.Value = 0;
            nudEdad.Value = 0;
            nudHistorial.Value = 0;
            nudGarantias.Value = 0;
            _clienteSeleccionado = null;
            dgvClientes.ClearSelection();
        }
    }
}
