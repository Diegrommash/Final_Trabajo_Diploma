namespace UI
{
    partial class FormStatsPersonaje
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Label lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7, lbl8;

            lbl1 = new Label();
            lbl2 = new Label();
            lbl3 = new Label();
            lbl4 = new Label();
            lbl5 = new Label();
            lbl6 = new Label();
            lbl7 = new Label();
            lbl8 = new Label();

            lblBatallasJugadas = new Label();
            lblGanadas = new Label();
            lblPerdidas = new Label();
            lblDanioCausado = new Label();
            lblDanioRecibido = new Label();
            lblEfectosAplicados = new Label();
            lblEfectosRecibidos = new Label();
            lblTurnos = new Label();
            lblMaxTurnos = new Label();

            btnCerrar = new Button();

            SuspendLayout();

            int y = 20;

            void ConfigLabel(Label l, string text)
            {
                l.Text = text;
                l.Location = new Point(20, y);
                l.AutoSize = true;
            }

            void ConfigValue(Label l)
            {
                l.Location = new Point(220, y);
                l.AutoSize = true;
                l.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                y += 25;
            }

            ConfigLabel(lbl1, "Batallas jugadas:");
            ConfigValue(lblBatallasJugadas);

            ConfigLabel(lbl2, "Ganadas:");
            ConfigValue(lblGanadas);

            ConfigLabel(lbl3, "Perdidas:");
            ConfigValue(lblPerdidas);

            ConfigLabel(lbl4, "Daño causado total:");
            ConfigValue(lblDanioCausado);

            ConfigLabel(lbl5, "Daño recibido total:");
            ConfigValue(lblDanioRecibido);

            ConfigLabel(lbl6, "Efectos aplicados:");
            ConfigValue(lblEfectosAplicados);

            ConfigLabel(lbl7, "Efectos recibidos:");
            ConfigValue(lblEfectosRecibidos);

            ConfigLabel(lbl8, "Turnos sobrevividos:");
            ConfigValue(lblTurnos);

            lblMaxTurnos.Location = new Point(220, y);
            lblMaxTurnos.AutoSize = true;
            lblMaxTurnos.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label lbl9 = new Label
            {
                Text = "Máx. turnos en batalla:",
                Location = new Point(20, y),
                AutoSize = true
            };

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(130, y + 40);
            btnCerrar.Click += btnCerrar_Click;

            Controls.AddRange(new Control[]
            {
                lbl1, lblBatallasJugadas,
                lbl2, lblGanadas,
                lbl3, lblPerdidas,
                lbl4, lblDanioCausado,
                lbl5, lblDanioRecibido,
                lbl6, lblEfectosAplicados,
                lbl7, lblEfectosRecibidos,
                lbl8, lblTurnos,
                lbl9, lblMaxTurnos,
                btnCerrar
            });

            ClientSize = new Size(360, y + 90);
            Text = "Estadísticas del Personaje";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormStatsPersonaje_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblBatallasJugadas;
        private Label lblGanadas;
        private Label lblPerdidas;
        private Label lblDanioCausado;
        private Label lblDanioRecibido;
        private Label lblEfectosAplicados;
        private Label lblEfectosRecibidos;
        private Label lblTurnos;
        private Label lblMaxTurnos;
        private Button btnCerrar;
    }
}
