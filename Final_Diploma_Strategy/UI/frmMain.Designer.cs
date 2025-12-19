namespace UI
{
    partial class frmMain
    {
        private Panel pnlMenu;
        private Panel pnlHeader;
        private Panel pnlContenido;
        private Button btnClientes;
        private Button btnEvaluacion;
        private Label lblTitulo;

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            pnlHeader = new Panel();
            pnlContenido = new Panel();
            btnClientes = new Button();
            btnEvaluacion = new Button();
            lblTitulo = new Label();

            // =========================
            // Panel Menu
            // =========================
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 200;
            pnlMenu.BackColor = Color.FromArgb(45, 45, 48);

            // Botón Clientes
            btnClientes.Text = "  Clientes";
            btnClientes.Dock = DockStyle.Top;
            btnClientes.Height = 50;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.ForeColor = Color.White;
            btnClientes.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Botón Evaluación
            btnEvaluacion.Text = "  Evaluación Crediticia";
            btnEvaluacion.Dock = DockStyle.Top;
            btnEvaluacion.Height = 50;
            btnEvaluacion.FlatStyle = FlatStyle.Flat;
            btnEvaluacion.FlatAppearance.BorderSize = 0;
            btnEvaluacion.ForeColor = Color.White;
            btnEvaluacion.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            pnlMenu.Controls.Add(btnEvaluacion);
            pnlMenu.Controls.Add(btnClientes);

            // =========================
            // Panel Header
            // =========================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.FromArgb(0, 122, 204);

            lblTitulo.Text = "Sistema de Evaluación de Riesgo Crediticio";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 18);

            pnlHeader.Controls.Add(lblTitulo);

            // =========================
            // Panel Contenido
            // =========================
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.BackColor = Color.WhiteSmoke;

            // =========================
            // Form Main
            // =========================
            Text = "FINAL - Strategy";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1100, 700);
            MinimumSize = new Size(1000, 650);
            MaximizeBox = false;

            Controls.Add(pnlContenido);
            Controls.Add(pnlHeader);
            Controls.Add(pnlMenu);

        }
    }
}
