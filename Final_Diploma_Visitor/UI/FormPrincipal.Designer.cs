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
            this.dgvPersonajes = new System.Windows.Forms.DataGridView();
            this.lblEfecto = new System.Windows.Forms.Label();
            this.cboEfectos = new System.Windows.Forms.ComboBox();
            this.btnAplicarEfecto = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();

            this.lblPersonajeUno = new System.Windows.Forms.Label();
            this.cboPersonajeUno = new System.Windows.Forms.ComboBox();
            this.lblPersonajeDos = new System.Windows.Forms.Label();
            this.cboPersonajeDos = new System.Windows.Forms.ComboBox();

            this.lblEscenario = new System.Windows.Forms.Label();
            this.cboEscenario = new System.Windows.Forms.ComboBox();

            this.btnAtacar = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.lblEfectosTurno = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonajes)).BeginInit();
            this.SuspendLayout();

            // ==========================================================
            // GRILLA
            // ==========================================================
            this.dgvPersonajes.AllowUserToAddRows = false;
            this.dgvPersonajes.AllowUserToDeleteRows = false;
            this.dgvPersonajes.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right))));
            this.dgvPersonajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonajes.Location = new System.Drawing.Point(12, 12);
            this.dgvPersonajes.MultiSelect = false;
            this.dgvPersonajes.Name = "dgvPersonajes";
            this.dgvPersonajes.ReadOnly = true;
            this.dgvPersonajes.RowHeadersVisible = false;
            this.dgvPersonajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonajes.Size = new System.Drawing.Size(760, 250);

            // ==========================================================
            // EFECTOS MANUALES (Fila 2)
            // ==========================================================
            this.lblEfecto.Location = new System.Drawing.Point(12, 270);
            this.lblEfecto.Text = "Efecto:";

            this.cboEfectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEfectos.Location = new System.Drawing.Point(70, 267);
            this.cboEfectos.Size = new System.Drawing.Size(180, 23);

            this.btnAplicarEfecto.Location = new System.Drawing.Point(260, 266);
            this.btnAplicarEfecto.Size = new System.Drawing.Size(110, 25);
            this.btnAplicarEfecto.Text = "Aplicar efecto";

            this.btnRefrescar.Location = new System.Drawing.Point(380, 266);
            this.btnRefrescar.Size = new System.Drawing.Size(80, 25);
            this.btnRefrescar.Text = "Refrescar";

            this.btnEliminar.Location = new System.Drawing.Point(470, 266);
            this.btnEliminar.Size = new System.Drawing.Size(75, 25);
            this.btnEliminar.Text = "Eliminar";

            this.btnNuevo.Location = new System.Drawing.Point(555, 266);
            this.btnNuevo.Size = new System.Drawing.Size(75, 25);
            this.btnNuevo.Text = "Nuevo";

            this.btnEditar.Location = new System.Drawing.Point(640, 266);
            this.btnEditar.Size = new System.Drawing.Size(75, 25);
            this.btnEditar.Text = "Editar";

            // ==========================================================
            // BATALLA: PERSONAJE 1, PERSONAJE 2, ESCENARIO (Fila 3)
            // ==========================================================
            this.lblPersonajeUno.Location = new System.Drawing.Point(12, 305);
            this.lblPersonajeUno.Text = "Personaje 1:";

            this.cboPersonajeUno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonajeUno.Location = new System.Drawing.Point(95, 302);
            this.cboPersonajeUno.Size = new System.Drawing.Size(150, 23);

            this.lblPersonajeDos.Location = new System.Drawing.Point(260, 305);
            this.lblPersonajeDos.Text = "Personaje 2:";

            this.cboPersonajeDos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonajeDos.Location = new System.Drawing.Point(345, 302);
            this.cboPersonajeDos.Size = new System.Drawing.Size(150, 23);

            this.lblEscenario.Location = new System.Drawing.Point(510, 305);
            this.lblEscenario.Text = "Escenario:";

            this.cboEscenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEscenario.Location = new System.Drawing.Point(580, 302);
            this.cboEscenario.Size = new System.Drawing.Size(140, 23);

            this.btnAtacar.Location = new System.Drawing.Point(730, 302);
            this.btnAtacar.Size = new System.Drawing.Size(45, 23);
            this.btnAtacar.Text = "Go!";

            // ==========================================================
            // Fila 4 - Turno y contador de efectos
            // ==========================================================
            this.lblTurno.Location = new System.Drawing.Point(12, 335);
            this.lblTurno.Text = "Turno: 1";

            this.lblEfectosTurno.Location = new System.Drawing.Point(150, 335);
            this.lblEfectosTurno.AutoSize = true;
            this.lblEfectosTurno.Text = "Efectos usados: 0/2";

            // ==========================================================
            // LOG DE BATALLA
            // ==========================================================
            this.lstLog.Location = new System.Drawing.Point(12, 365);
            this.lstLog.Size = new System.Drawing.Size(760, 145);

            // ==========================================================
            // FORM
            // ==========================================================
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblEfectosTurno);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.btnAtacar);
            this.Controls.Add(this.cboEscenario);
            this.Controls.Add(this.lblEscenario);
            this.Controls.Add(this.cboPersonajeDos);
            this.Controls.Add(this.lblPersonajeDos);
            this.Controls.Add(this.cboPersonajeUno);
            this.Controls.Add(this.lblPersonajeUno);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnAplicarEfecto);
            this.Controls.Add(this.cboEfectos);
            this.Controls.Add(this.lblEfecto);
            this.Controls.Add(this.dgvPersonajes);

            this.btnAplicarEfecto.Click += new System.EventHandler(this.btnAplicarEfecto_Click);
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnAtacar.Click += new System.EventHandler(this.btnSimularTurno_Click);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);


            this.Text = "Sistema de Batalla RPG - Visitor Pattern";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.DataGridView dgvPersonajes;
        private System.Windows.Forms.Label lblEfecto;
        private System.Windows.Forms.ComboBox cboEfectos;
        private System.Windows.Forms.Button btnAplicarEfecto;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;

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
    }
}
