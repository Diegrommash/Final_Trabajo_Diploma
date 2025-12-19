namespace UI
{
    partial class frmClientes
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvClientes;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblIngresos;
        private NumericUpDown nudIngresos;
        private Label lblEdad;
        private NumericUpDown nudEdad;
        private Label lblHistorial;
        private NumericUpDown nudHistorial;
        private Label lblGarantias;
        private NumericUpDown nudGarantias;

        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;

        private void InitializeComponent()
        {
            dgvClientes = new DataGridView();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblIngresos = new Label();
            nudIngresos = new NumericUpDown();
            lblEdad = new Label();
            nudEdad = new NumericUpDown();
            lblHistorial = new Label();
            nudHistorial = new NumericUpDown();
            lblGarantias = new Label();
            nudGarantias = new NumericUpDown();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            // DataGridView
            dgvClientes.Location = new Point(20, 20);
            dgvClientes.Size = new Size(750, 200);
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Nombre
            lblNombre.Text = "Nombre";
            lblNombre.Location = new Point(20, 240);
            txtNombre.Location = new Point(120, 235);
            txtNombre.Size = new Size(200, 23);

            // Ingresos
            lblIngresos.Text = "Ingresos";
            lblIngresos.Location = new Point(20, 270);
            nudIngresos.Location = new Point(120, 265);
            nudIngresos.Maximum = 10000000;
            nudIngresos.DecimalPlaces = 2;

            // Edad
            lblEdad.Text = "Edad";
            lblEdad.Location = new Point(20, 300);
            nudEdad.Location = new Point(120, 295);
            nudEdad.Maximum = 100;

            // Historial
            lblHistorial.Text = "Score Historial";
            lblHistorial.Location = new Point(20, 330);
            nudHistorial.Location = new Point(120, 325);
            nudHistorial.Maximum = 100;

            // Garantías
            lblGarantias.Text = "Garantías";
            lblGarantias.Location = new Point(20, 360);
            nudGarantias.Location = new Point(120, 355);
            nudGarantias.Maximum = 10000000;
            nudGarantias.DecimalPlaces = 2;

            // Botones
            btnAgregar.Text = "Agregar";
            btnAgregar.Location = new Point(360, 235);

            btnModificar.Text = "Modificar";
            btnModificar.Location = new Point(360, 275);

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(360, 315);

            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Location = new Point(360, 355);

            // Form
            ClientSize = new Size(650, 420);
            Controls.AddRange(new Control[]
            {
                dgvClientes,
                lblNombre, txtNombre,
                lblIngresos, nudIngresos,
                lblEdad, nudEdad,
                lblHistorial, nudHistorial,
                lblGarantias, nudGarantias,
                btnAgregar, btnModificar, btnEliminar, btnLimpiar
            });

            Text = "ABM de Clientes";
        }
    }
}
