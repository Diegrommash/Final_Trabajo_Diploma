using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace UI
{
    partial class frmKanban
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flpPendiente;
        private FlowLayoutPanel flpEnProceso;
        private FlowLayoutPanel flpBloqueada;
        private FlowLayoutPanel flpEnRevision;
        private FlowLayoutPanel flpFinalizada;
        private Button btnNuevaTarea;
        private Label lblPendiente;
        private Label lblEnProceso;
        private Label lblBloqueada;
        private Label lblEnRevision;
        private Label lblFinalizada;


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flpPendiente = new FlowLayoutPanel();
            flpEnProceso = new FlowLayoutPanel();
            flpBloqueada = new FlowLayoutPanel();
            flpEnRevision = new FlowLayoutPanel();
            flpFinalizada = new FlowLayoutPanel();

            lblPendiente = new Label();
            lblEnProceso = new Label();
            lblBloqueada = new Label();
            lblEnRevision = new Label();
            lblFinalizada = new Label();

            btnNuevaTarea = new Button();

            SuspendLayout();

            // -----------------------------
            // Labels de columnas
            // -----------------------------
            Label[] labels =
            {
                lblPendiente,
                lblEnProceso,
                lblBloqueada,
                lblEnRevision,
                lblFinalizada
            };

            string[] textos =
            {
                "Pendiente",
                "En Proceso",
                "Bloqueada",
                "En Revisión",
                "Finalizada"
            };

            int xLabel = 10;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = textos[i];
                labels[i].Location = new Point(xLabel, 30);
                labels[i].Size = new Size(200, 20);
                labels[i].TextAlign = ContentAlignment.MiddleCenter;
                labels[i].Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
                Controls.Add(labels[i]);

                xLabel += 210;
            }

            // -----------------------------
            // FlowLayoutPanels (columnas)
            // -----------------------------
            FlowLayoutPanel[] columnas =
            {
                flpPendiente,
                flpEnProceso,
                flpBloqueada,
                flpEnRevision,
                flpFinalizada
            };

            int xPanel = 10;
            foreach (var flp in columnas)
            {
                flp.Location = new Point(xPanel, 55);
                flp.Size = new Size(200, 400);
                flp.AutoScroll = true;
                flp.FlowDirection = FlowDirection.TopDown;
                flp.WrapContents = false;
                flp.BorderStyle = BorderStyle.FixedSingle;

                Controls.Add(flp);
                xPanel += 210;
            }

            //flpPendiente.BackColor = Color.AliceBlue;
            //flpEnProceso.BackColor = Color.Honeydew;
            //flpBloqueada.BackColor = Color.MistyRose;
            //flpEnRevision.BackColor = Color.Lavender;
            //flpFinalizada.BackColor = Color.Gainsboro;

            // -----------------------------
            // Botón nueva tarea
            // -----------------------------
            btnNuevaTarea.Text = "Nueva Tarea";
            btnNuevaTarea.Location = new Point(10, 5);
            btnNuevaTarea.Size = new Size(120, 25);
            btnNuevaTarea.Click += btnNuevaTarea_Click;
            Controls.Add(btnNuevaTarea);

            // -----------------------------
            // Form
            // -----------------------------
            ClientSize = new Size(1100, 480);
            Text = "Tablero Kanban";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmKanban_Load;

            ResumeLayout(false);
        }

    }
}
