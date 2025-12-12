namespace UI
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblEfecto = new Label();
            cboEfectos = new ComboBox();
            btnRefrescar = new Button();
            lblPersonajeUno = new Label();
            cboPersonajeUno = new ComboBox();
            lblPersonajeDos = new Label();
            cboPersonajeDos = new ComboBox();
            lblEscenario = new Label();
            cboEscenario = new ComboBox();
            btnAtacar = new Button();
            lblTurno = new Label();
            lstLog = new ListBox();
            lblEfectosTurno = new Label();
            pnlArena = new Panel();
            picP1 = new PictureBox();
            picP2 = new PictureBox();
            lblVidaP1 = new Label();
            lblVidaP2 = new Label();
            lblEstadosP1 = new Label();
            lblEstadosP2 = new Label();
            lblStatsP1 = new Label();
            lblStatsP2 = new Label();
            btnStatsP1 = new Button();
            btnStatsP2 = new Button();
            pnlArena.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picP1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picP2).BeginInit();
            SuspendLayout();
            // 
            // lblEfecto
            // 
            lblEfecto.Location = new Point(13, 389);
            lblEfecto.Name = "lblEfecto";
            lblEfecto.Size = new Size(100, 23);
            lblEfecto.TabIndex = 16;
            lblEfecto.Text = "Efecto:";
            // 
            // cboEfectos
            // 
            cboEfectos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEfectos.Location = new Point(71, 386);
            cboEfectos.Name = "cboEfectos";
            cboEfectos.Size = new Size(180, 23);
            cboEfectos.TabIndex = 15;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Location = new Point(381, 385);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(80, 25);
            btnRefrescar.TabIndex = 13;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // lblPersonajeUno
            // 
            lblPersonajeUno.Location = new Point(13, 424);
            lblPersonajeUno.Name = "lblPersonajeUno";
            lblPersonajeUno.Size = new Size(100, 23);
            lblPersonajeUno.TabIndex = 9;
            lblPersonajeUno.Text = "Personaje 1:";
            // 
            // cboPersonajeUno
            // 
            cboPersonajeUno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersonajeUno.Location = new Point(96, 421);
            cboPersonajeUno.Name = "cboPersonajeUno";
            cboPersonajeUno.Size = new Size(150, 23);
            cboPersonajeUno.TabIndex = 8;
            cboPersonajeUno.SelectedIndexChanged += cboPersonajeUno_SelectedIndexChanged;
            // 
            // lblPersonajeDos
            // 
            lblPersonajeDos.Location = new Point(261, 424);
            lblPersonajeDos.Name = "lblPersonajeDos";
            lblPersonajeDos.Size = new Size(100, 23);
            lblPersonajeDos.TabIndex = 7;
            lblPersonajeDos.Text = "Personaje 2:";
            // 
            // cboPersonajeDos
            // 
            cboPersonajeDos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersonajeDos.Location = new Point(346, 421);
            cboPersonajeDos.Name = "cboPersonajeDos";
            cboPersonajeDos.Size = new Size(150, 23);
            cboPersonajeDos.TabIndex = 6;
            cboPersonajeDos.SelectedIndexChanged += cboPersonajeDos_SelectedIndexChanged;
            // 
            // lblEscenario
            // 
            lblEscenario.Location = new Point(511, 424);
            lblEscenario.Name = "lblEscenario";
            lblEscenario.Size = new Size(100, 23);
            lblEscenario.TabIndex = 5;
            lblEscenario.Text = "Escenario:";
            // 
            // cboEscenario
            // 
            cboEscenario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEscenario.Location = new Point(581, 421);
            cboEscenario.Name = "cboEscenario";
            cboEscenario.Size = new Size(140, 23);
            cboEscenario.TabIndex = 4;
            cboEscenario.SelectedIndexChanged += cboEscenario_SelectedIndexChanged;
            // 
            // btnAtacar
            // 
            btnAtacar.Location = new Point(731, 421);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(45, 23);
            btnAtacar.TabIndex = 3;
            btnAtacar.Text = "Go!";
            btnAtacar.Click += btnSimularTurno_Click;
            // 
            // lblTurno
            // 
            lblTurno.Location = new Point(10, 458);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(100, 23);
            lblTurno.TabIndex = 2;
            lblTurno.Text = "Turno: 1";
            // 
            // lstLog
            // 
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(10, 484);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(760, 139);
            lstLog.TabIndex = 0;
            // 
            // lblEfectosTurno
            // 
            lblEfectosTurno.AutoSize = true;
            lblEfectosTurno.Location = new Point(148, 458);
            lblEfectosTurno.Name = "lblEfectosTurno";
            lblEfectosTurno.Size = new Size(108, 15);
            lblEfectosTurno.TabIndex = 1;
            lblEfectosTurno.Text = "Efectos usados: 0/2";
            // 
            // pnlArena
            // 
            pnlArena.BackColor = Color.Transparent;
            pnlArena.BackgroundImageLayout = ImageLayout.Stretch;
            pnlArena.BorderStyle = BorderStyle.FixedSingle;
            pnlArena.Controls.Add(picP1);
            pnlArena.Controls.Add(picP2);
            pnlArena.Controls.Add(lblVidaP1);
            pnlArena.Controls.Add(lblVidaP2);
            pnlArena.Controls.Add(lblEstadosP1);
            pnlArena.Controls.Add(lblEstadosP2);
            pnlArena.Controls.Add(lblStatsP1);
            pnlArena.Controls.Add(lblStatsP2);
            pnlArena.Controls.Add(btnStatsP1);
            pnlArena.Controls.Add(btnStatsP2);
            pnlArena.Location = new Point(12, 12);
            pnlArena.Name = "pnlArena";
            pnlArena.Size = new Size(760, 334);
            pnlArena.TabIndex = 18;
            // 
            // picP1
            // 
            picP1.Location = new Point(80, 40);
            picP1.Name = "picP1";
            picP1.Size = new Size(150, 150);
            picP1.SizeMode = PictureBoxSizeMode.StretchImage;
            picP1.TabIndex = 0;
            picP1.TabStop = false;
            picP1.Click += picP1_Click;
            picP1.BackColor = Color.Transparent;
            // 
            // picP2
            // 
            picP2.Location = new Point(530, 40);
            picP2.Name = "picP2";
            picP2.Size = new Size(150, 150);
            picP2.SizeMode = PictureBoxSizeMode.StretchImage;
            picP2.TabIndex = 1;
            picP2.TabStop = false;
            picP2.Click += picP2_Click;
            picP1.BackColor = Color.Transparent;
            // 
            // lblVidaP1
            // 
            lblVidaP1.AutoSize = true;
            lblVidaP1.Font = new Font(lblVidaP1.Font, FontStyle.Bold);
            lblVidaP1.Location = new Point(80, 10);
            lblVidaP1.Name = "lblVidaP1";
            lblVidaP1.Size = new Size(56, 15);
            lblVidaP1.TabIndex = 2;
            lblVidaP1.Text = "VIDA: 0/0";
            // 
            // lblVidaP2
            // 
            lblVidaP2.AutoSize = true;
            lblVidaP2.Font = new Font(lblVidaP2.Font, FontStyle.Bold);
            lblVidaP2.Location = new Point(530, 10);
            lblVidaP2.Name = "lblVidaP2";
            lblVidaP2.Size = new Size(56, 15);
            lblVidaP2.TabIndex = 3;
            lblVidaP2.Text = "VIDA: 0/0";
            // 
            // lblEstadosP1
            // 
            lblEstadosP1.AutoSize = true;
            lblEstadosP1.Font = new Font(lblEstadosP1.Font, FontStyle.Bold);
            lblEstadosP1.Location = new Point(80, 195);
            lblEstadosP1.Name = "lblEstadosP1";
            lblEstadosP1.Size = new Size(67, 15);
            lblEstadosP1.TabIndex = 4;
            lblEstadosP1.Text = "ESTADOS: -";
            // 
            // lblEstadosP2
            // 
            lblEstadosP2.AutoSize = true;
            lblEstadosP2.Font = new Font(lblEstadosP2.Font, FontStyle.Bold);
            lblEstadosP2.Location = new Point(530, 195);
            lblEstadosP2.Name = "lblEstadosP2";
            lblEstadosP2.Size = new Size(67, 15);
            lblEstadosP2.TabIndex = 5;
            lblEstadosP2.Text = "ESTADOS: -";
            // 
            // lblStatsP1
            // 
            lblStatsP1.Font = new Font("Segoe UI", 9F);
            lblStatsP1.Font = new Font(lblStatsP1.Font, FontStyle.Bold);
            lblStatsP1.Location = new Point(80, 215);
            lblStatsP1.Name = "lblStatsP1";
            lblStatsP1.Size = new Size(200, 60);
            lblStatsP1.TabIndex = 6;
            lblStatsP1.Text = "STATS:";
            // 
            // lblStatsP2
            // 
            lblStatsP2.Font = new Font("Segoe UI", 9F);
            lblStatsP2.Font = new Font(lblStatsP2.Font, FontStyle.Bold);
            lblStatsP2.Location = new Point(530, 215);
            lblStatsP2.Name = "lblStatsP2";
            lblStatsP2.Size = new Size(200, 60);
            lblStatsP2.TabIndex = 7;
            lblStatsP2.Text = "STATS:";
            // 
            // btnStatsP1
            // 
            btnStatsP1.Location = new Point(80, 280);
            btnStatsP1.Name = "btnStatsP1";
            btnStatsP1.Size = new Size(150, 25);
            btnStatsP1.TabIndex = 8;
            btnStatsP1.Text = "Ver Stats P1";
            btnStatsP1.Click += btnStatsP1_Click;
            // 
            // btnStatsP2
            // 
            btnStatsP2.Location = new Point(530, 280);
            btnStatsP2.Name = "btnStatsP2";
            btnStatsP2.Size = new Size(150, 25);
            btnStatsP2.TabIndex = 9;
            btnStatsP2.Text = "Ver Stats P2";
            btnStatsP2.Click += btnStatsP2_Click;
            // 
            // FormPrincipal
            // 
            ClientSize = new Size(784, 650);
            Controls.Add(lstLog);
            Controls.Add(lblEfectosTurno);
            Controls.Add(lblTurno);
            Controls.Add(btnAtacar);
            Controls.Add(cboEscenario);
            Controls.Add(lblEscenario);
            Controls.Add(cboPersonajeDos);
            Controls.Add(lblPersonajeDos);
            Controls.Add(cboPersonajeUno);
            Controls.Add(lblPersonajeUno);
            Controls.Add(btnRefrescar);
            Controls.Add(cboEfectos);
            Controls.Add(lblEfecto);
            Controls.Add(pnlArena);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Batalla RPG - Visitor Pattern";
            Load += FormPrincipal_Load;
            pnlArena.ResumeLayout(false);
            pnlArena.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picP1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picP2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private System.Windows.Forms.Label lblEfecto;
        private System.Windows.Forms.ComboBox cboEfectos;
        private System.Windows.Forms.Button btnRefrescar;

        private System.Windows.Forms.Label lblPersonajeUno;
        private System.Windows.Forms.ComboBox cboPersonajeUno;
        private System.Windows.Forms.Label lblPersonajeDos;
        private System.Windows.Forms.ComboBox cboPersonajeDos;
        private System.Windows.Forms.Label lblEscenario;
        private System.Windows.Forms.ComboBox cboEscenario;
        private System.Windows.Forms.Button btnAtacar;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label lblEfectosTurno;

        private System.Windows.Forms.Panel pnlArena;
        private System.Windows.Forms.PictureBox picP1;
        private System.Windows.Forms.PictureBox picP2;
        private System.Windows.Forms.Label lblVidaP1;
        private System.Windows.Forms.Label lblVidaP2;
        private System.Windows.Forms.Label lblEstadosP1;
        private System.Windows.Forms.Label lblEstadosP2;
        private Label lblStatsP1;
        private Label lblStatsP2;
        private Button btnStatsP1;
        private Button btnStatsP2;

    }
}
