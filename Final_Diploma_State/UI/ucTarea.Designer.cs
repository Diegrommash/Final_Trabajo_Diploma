using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    partial class ucTarea
    {
        private Label lblTitulo;
        private Label lblDescripcion;
        private Label lblEstado;
        private Button btnIniciar;
        private Button btnBloquear;
        private Button btnRevisar;
        private Button btnFinalizar;
        private Button btnHistorial;

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblDescripcion = new Label();
            lblEstado = new Label();
            btnIniciar = new Button();
            btnBloquear = new Button();
            btnRevisar = new Button();
            btnFinalizar = new Button();
            btnHistorial = new Button();

            // ------------------------
            // lblTitulo
            // ------------------------
            lblTitulo.Text = "Título";
            lblTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo.Location = new Point(5, 5);
            lblTitulo.Size = new Size(180, 20);

            // ------------------------
            // lblDescripcion
            // ------------------------
            lblDescripcion.Text = "(Descripción)";
            lblDescripcion.Location = new Point(5, 25);
            lblDescripcion.Size = new Size(180, 35);
            lblDescripcion.Font = new Font("Segoe UI", 8F);
            lblDescripcion.ForeColor = Color.DimGray;
            lblDescripcion.AutoEllipsis = true;
            lblDescripcion.MaximumSize = new Size(180, 35);

            // ------------------------
            // lblEstado
            // ------------------------
            lblEstado.Text = "Estado";
            lblEstado.Location = new Point(5, 65);
            lblEstado.Size = new Size(180, 15);
            lblEstado.Font = new Font("Segoe UI", 8F, FontStyle.Italic);

            // ------------------------
            // btnIniciar
            // ------------------------
            btnIniciar.Text = "Iniciar";
            btnIniciar.Location = new Point(5, 85);
            btnIniciar.Size = new Size(80, 23);
            btnIniciar.Click += btnIniciar_Click;

            // ------------------------
            // btnBloquear
            // ------------------------
            btnBloquear.Text = "Bloquear";
            btnBloquear.Location = new Point(95, 85);
            btnBloquear.Size = new Size(80, 23);
            btnBloquear.Click += btnBloquear_Click;

            // ------------------------
            // btnRevisar
            // ------------------------
            btnRevisar.Text = "Revisar";
            btnRevisar.Location = new Point(5, 115);
            btnRevisar.Size = new Size(80, 23);
            btnRevisar.Click += btnRevisar_Click;

            // ------------------------
            // btnFinalizar
            // ------------------------
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.Location = new Point(95, 115);
            btnFinalizar.Size = new Size(80, 23);
            btnFinalizar.Click += btnFinalizar_Click;

            // ------------------------
            // btnHistorial
            // ------------------------
            btnHistorial.Text = "Historial";
            btnHistorial.Location = new Point(5, 145);
            btnHistorial.Size = new Size(170, 23);
            btnHistorial.Click += btnHistorial_Click;

            // ------------------------
            // Control
            // ------------------------
            Controls.AddRange(new Control[]
            {
                lblTitulo,
                lblDescripcion,
                lblEstado,
                btnIniciar,
                btnBloquear,
                btnRevisar,
                btnFinalizar,
                btnHistorial
            });

            Size = new Size(190, 175);
            BorderStyle = BorderStyle.FixedSingle;

           
        }
    }
}
