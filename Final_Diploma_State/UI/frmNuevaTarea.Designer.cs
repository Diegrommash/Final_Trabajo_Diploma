using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace UI
{
    partial class frmNuevaTarea
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            // lblTitulo
            lblTitulo.Text = "Título";
            lblTitulo.Location = new Point(12, 15);
            lblTitulo.Size = new Size(100, 20);

            // txtTitulo
            txtTitulo.Location = new Point(12, 35);
            txtTitulo.Size = new Size(260, 23);

            // lblDescripcion
            lblDescripcion.Text = "Descripción";
            lblDescripcion.Location = new Point(12, 65);
            lblDescripcion.Size = new Size(100, 20);

            // txtDescripcion
            txtDescripcion.Location = new Point(12, 85);
            txtDescripcion.Size = new Size(260, 80);
            txtDescripcion.Multiline = true;

            // btnGuardar
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(116, 180);
            btnGuardar.Click += btnGuardar_Click;

            // btnCancelar
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(197, 180);
            btnCancelar.Click += btnCancelar_Click;

            // Form
            ClientSize = new Size(284, 220);
            Controls.AddRange(new Control[]
            {
                lblTitulo, txtTitulo,
                lblDescripcion, txtDescripcion,
                btnGuardar, btnCancelar
            });

            Text = "Nueva Tarea";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
