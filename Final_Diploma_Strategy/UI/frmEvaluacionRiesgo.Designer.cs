namespace UI
{
    partial class frmEvaluacionRiesgo
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cboClientes;
        private ComboBox cboRiesgos;
        private Button btnEvaluar;
        private Label lblIngresos;
        private Label lblEdad;
        private Label lblHistorial;
        private Label lblGarantias;
        private Label lblResultado;
        private DataGridView dgvHistorial;
        private GroupBox grpEstrategia;
        private TextBox txtObservacionesEstrategia;


        private void InitializeComponent()
        {
            cboClientes = new ComboBox();
            cboRiesgos = new ComboBox();
            btnEvaluar = new Button();
            lblIngresos = new Label();
            lblEdad = new Label();
            lblHistorial = new Label();
            lblGarantias = new Label();
            lblResultado = new Label();
            dgvHistorial = new DataGridView();
            grpEstrategia = new GroupBox();
            txtObservacionesEstrategia = new TextBox();

            // =========================
            // Combo Clientes
            // =========================
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.Location = new Point(20, 20);
            cboClientes.Size = new Size(250, 25);

            // =========================
            // Combo Estrategias
            // =========================
            cboRiesgos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRiesgos.Location = new Point(20, 60);
            cboRiesgos.Size = new Size(250, 25);

            // =========================
            // Botón Evaluar
            // =========================
            btnEvaluar.Text = "Evaluar Riesgo";
            btnEvaluar.Location = new Point(20, 100);
            btnEvaluar.Size = new Size(250, 30);

            // =========================
            // Datos del Cliente (derecha)
            // =========================
            lblIngresos.Location = new Point(300, 20);
            lblIngresos.Size = new Size(250, 20);

            lblEdad.Location = new Point(300, 45);
            lblEdad.Size = new Size(250, 20);

            lblHistorial.Location = new Point(300, 70);
            lblHistorial.Size = new Size(250, 20);

            lblGarantias.Location = new Point(300, 95);
            lblGarantias.Size = new Size(250, 20);

            // ===============================
            // GroupBox Estrategia
            // ===============================
            grpEstrategia.Text = "Criterios de la estrategia";
            grpEstrategia.Location = new Point(20, 150);
            grpEstrategia.Size = new Size(530, 130);

            // TextBox Observaciones
            txtObservacionesEstrategia = new TextBox();
            txtObservacionesEstrategia.Location = new Point(12, 25);
            txtObservacionesEstrategia.Size = new Size(500, 90);
            txtObservacionesEstrategia.Multiline = true;
            txtObservacionesEstrategia.ReadOnly = true;
            txtObservacionesEstrategia.BorderStyle = BorderStyle.None;
            txtObservacionesEstrategia.BackColor = Color.White;
            txtObservacionesEstrategia.ScrollBars = ScrollBars.Vertical;
            txtObservacionesEstrategia.Font = new Font("Segoe UI", 9);

            grpEstrategia.Controls.Add(txtObservacionesEstrategia);

            // =========================
            // Resultado
            // =========================
            lblResultado.Location = new Point(20, 290);
            lblResultado.Size = new Size(530, 30);
            lblResultado.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // =========================
            // Grilla historial
            // =========================
            dgvHistorial.Location = new Point(20, 330);
            dgvHistorial.Size = new Size(750, 200);
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;

            // =========================
            // Form
            // =========================
            ClientSize = new Size(800, 560);
            StartPosition = FormStartPosition.CenterParent;

            Controls.AddRange(new Control[]
            {
                cboClientes,
                cboRiesgos,
                btnEvaluar,
                lblIngresos,
                lblEdad,
                lblHistorial,
                lblGarantias,
                grpEstrategia,
                lblResultado,
                dgvHistorial
            });

            Text = "Evaluación de Riesgo Crediticio";
        }

    }
}
