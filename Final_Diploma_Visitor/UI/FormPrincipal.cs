using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class FormPrincipal : Form
    {
        private bool _batallaEnCurso = false;
        private int _efectosUsadosEnTurno = 0;

        private readonly ServPersonaje _servPersonaje;
        private readonly ServBatalla _servBatalla = new();

        private List<IPersonaje> _personajes = new();
        private int _turnoActual = 1;

        public FormPrincipal(ServPersonaje servPersonaje)
        {
            InitializeComponent();
            _servPersonaje = servPersonaje;
        }

        // ============================================================
        // FORM LOAD
        // ============================================================
        private async void FormPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarEfectos();
            CargarEscenarios();

            await CargarPersonajesAsync();
            btnAplicarEfecto.Enabled = false;
        }

        // ============================================================
        // CONFIGURACIONES INICIALES
        // ============================================================
        private void ConfigurarGrilla()
        {
            dgvPersonajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonajes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            dgvPersonajes.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        private void CargarEfectos()
        {
            cboEfectos.Items.Clear();
            cboEfectos.Items.Add("Cura");
            cboEfectos.Items.Add("Quemadura");
            cboEfectos.Items.Add("Veneno");
            cboEfectos.Items.Add("Bendición");
            cboEfectos.Items.Add("Ira");
            cboEfectos.Items.Add("Mejora Ataque");
            cboEfectos.Items.Add("Congelamiento");

            cboEfectos.SelectedIndex = 0;
        }

        private void CargarEscenarios()
        {
            cboEscenario.Items.Clear();
            cboEscenario.Items.Add("Ninguno");
            cboEscenario.Items.Add("Bosque");
            cboEscenario.Items.Add("Volcán");
            cboEscenario.SelectedIndex = 0;
        }

        // ============================================================
        // CARGAR PERSONAJES
        // ============================================================
        private async Task CargarPersonajesAsync()
        {
            var resultado = await _servPersonaje.ObtenerTodosAsync();

            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Error, "Error");
                return;
            }

            _personajes = resultado.Valor!;
            dgvPersonajes.DataSource = null;
            dgvPersonajes.DataSource = _personajes;

            CargarAtacantesYDefensores();
        }

        private void CargarAtacantesYDefensores()
        {
            cboPersonajeUno.DataSource = null;
            cboPersonajeDos.DataSource = null;

            cboPersonajeUno.DataSource = new List<IPersonaje>(_personajes);
            cboPersonajeUno.DisplayMember = "ToString";

            cboPersonajeDos.DataSource = new List<IPersonaje>(_personajes);
            cboPersonajeDos.DisplayMember = "ToString";
        }

        // ============================================================
        // APLICAR EFECTO (MANUAL)
        // ============================================================
        private async void btnAplicarEfecto_Click(object sender, EventArgs e)
        {
            // 1️⃣ No permitir efectos fuera de batalla
            if (!_batallaEnCurso)
            {
                MessageBox.Show("No podés aplicar efectos hasta que inicie la batalla.");
                return;
            }

            // 2️⃣ No permitir más de 2 efectos por turno
            if (_efectosUsadosEnTurno >= 2)
            {
                MessageBox.Show("Solo podés aplicar 2 efectos por turno.");
                return;
            }

            // 3️⃣ Validar personaje seleccionado
            if (dgvPersonajes.CurrentRow?.DataBoundItem is not IPersonaje personaje)
            {
                MessageBox.Show("Seleccione un personaje.");
                return;
            }

            // 4️⃣ Crear visitor según la selección
            string efectoNom = cboEfectos.SelectedItem.ToString();
            var visitor = CrearBuffDebuff(efectoNom);

            if (visitor == null)
            {
                MessageBox.Show("Efecto no reconocido.");
                return;
            }

            // 5️⃣ Aplicar efecto manual
            string log = personaje.Aceptar(visitor, true);
            lstLog.Items.Add($"[Efecto Manual] {log}");

            // 6️⃣ Incrementar contador
            _efectosUsadosEnTurno++;

            // 7️⃣ Actualizar label
            lblEfectosTurno.Text = $"Efectos usados este turno: {_efectosUsadosEnTurno}/2";

            // 8️⃣ Bloquear botón si ya llegó a 2
            if (_efectosUsadosEnTurno >= 2)
                btnAplicarEfecto.Enabled = false;

            // 9️⃣ Refrescar grilla para ver cambios en atributos
            dgvPersonajes.Refresh();

            // 🔟 Guardar cambios en BD
            var res = await _servPersonaje.ModificarAsync(personaje);
            if (!res.Exito)
                MessageBox.Show(res.Error);
        }



        private IEfectoVisitor? CrearBuffDebuff(string nombre)
        {
            return nombre switch
            {
                "Cura" => new CuraVisitor(),
                "Quemadura" => new QuemaduraVisitor(),
                "Veneno" => new VenenoVisitor(),
                "Bendición" => new BendicionVisitor(),
                "Ira" => new IraVisitor(),
                "Mejora Ataque" => new MejoraAtaqueVisitor(),
                "Congelamiento" => new CongelamientoVisitor(),
                _ => null
            };
        }

        // ============================================================
        // BOTÓN REFRESCAR
        // ============================================================
        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            await CargarPersonajesAsync();
        }

        // ============================================================
        // ELIMINAR PERSONAJE
        // ============================================================
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersonajes.CurrentRow?.DataBoundItem is not IPersonaje personaje)
            {
                MessageBox.Show("Seleccione un personaje.");
                return;
            }

            if (MessageBox.Show("¿Eliminar personaje?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var resultado = await _servPersonaje.EliminarAsync(personaje.Id);

            if (!resultado.Exito)
                MessageBox.Show(resultado.Error);
            else
                await CargarPersonajesAsync();
        }

        // ============================================================
        // SIMULAR TURNO
        // ============================================================
        private void btnSimularTurno_Click(object sender, EventArgs e)
        {
            if (cboPersonajeUno.SelectedItem is not IPersonaje atacante ||
                cboPersonajeDos.SelectedItem is not IPersonaje defensor)
            {
                MessageBox.Show("Seleccione atacante y defensor.");
                return;
            }

            if (atacante == defensor)
            {
                MessageBox.Show("Atacante y defensor deben ser distintos.");
                return;
            }

            // Si todavía no arrancó la batalla → inicializar bloqueo
            if (!_batallaEnCurso)
            {
                _batallaEnCurso = true;

                // Bloquear selección de personajes y escenario
                cboPersonajeUno.Enabled = false;
                cboPersonajeDos.Enabled = false;
                cboEscenario.Enabled = false;

                // Bloquear efectos y CRUD
                btnAplicarEfecto.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;

                lstLog.Items.Add("=== ¡La batalla comienza! ===");

                _efectosUsadosEnTurno = 0;
                lblEfectosTurno.Text = "Efectos usados este turno: 0/2";
                btnAplicarEfecto.Enabled = true;
            }

            var escenario = CrearEscenario();

            var resultado = _servBatalla.SimularTurno(atacante, defensor, escenario, _turnoActual);

            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Error);
                return;
            }

            var datos = resultado.Valor!;

            // Mostrar log
            foreach (var linea in datos.LogEventos)
                lstLog.Items.Add(linea);

            // Actualizar grilla visualmente
            dgvPersonajes.Refresh();

            if (datos.BatallaFinalizada)
            {
                if (datos.Ganador != null)
                    lstLog.Items.Add($"GANADOR: {datos.Ganador}");
                else
                    lstLog.Items.Add("EMPATE.");

                MessageBox.Show("La batalla ha concluido.");

                TerminarBatalla();
                return;
            }

            _efectosUsadosEnTurno = 0;
            btnAplicarEfecto.Enabled = true;
            lblEfectosTurno.Text = "Efectos usados este turno: 0/2";

            AlternarTurno();

            _turnoActual++;
            lblTurno.Text = $"Turno: {_turnoActual}";
        }

        private IEfectoVisitor? CrearEscenario()
        {
            string nombre = cboEscenario.SelectedItem?.ToString();

            return nombre switch
            {
                "Bosque" => new BosqueVisitor(),
                "Volcán" => new VolcanVisitor(),
                _ => null
            };
        }

        private void AlternarTurno()
        {
            // Intercambia atacante y defensor en los ComboBox
            var actualAtacante = cboPersonajeUno.SelectedItem;
            var actualDefensor = cboPersonajeDos.SelectedItem;

            cboPersonajeUno.SelectedItem = actualDefensor;
            cboPersonajeDos.SelectedItem = actualAtacante;

            lstLog.Items.Add("=== Cambian los roles: ahora ataca el otro personaje ===");
        }

        private void TerminarBatalla()
        {
            _batallaEnCurso = false;

            // Rehabilitar controles
            cboPersonajeUno.Enabled = true;
            cboPersonajeDos.Enabled = true;
            cboEscenario.Enabled = true;

            btnAplicarEfecto.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            // Reiniciar turno
            _turnoActual = 1;
            lblTurno.Text = "Turno: 1";

            lstLog.Items.Add("=== La batalla ha terminado ===");

            lblEfectosTurno.Text = "Efectos usados este turno: 0/2";
        }

        // ============================================================
        // BOTONES NUEVO / EDITAR
        // (Deshabilitados si NO usás creación)
        // ============================================================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La creación de personajes no está habilitada.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La edición de personajes no está habilitada.");
        }
    }
}
