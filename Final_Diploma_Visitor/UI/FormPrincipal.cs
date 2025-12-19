using BE;
using BE.Enums;
using BE.Visitor;
using BE.Visitor.Concretos.Escenarios;
using BLL;

namespace UI
{
    public partial class FormPrincipal : Form
    {
        private bool _batallaEnCurso = false;
        private int _efectosUsadosEnTurno = 0;

        private IPersonaje? _personaje1;
        private IPersonaje? _personaje2;

        private EstadoBatalla? _estadoBatalla;

        private readonly ServPersonaje _servPersonaje;
        private readonly ServBatalla _servBatalla = new();
        private readonly ServStatsPersonaje _servStatsPersonaje;

        private List<IPersonaje> _personajes = new();

        public FormPrincipal(ServPersonaje servPersonaje, ServStatsPersonaje servStatsPersonaje)
        {
            InitializeComponent();
            _servPersonaje = servPersonaje;
            _servStatsPersonaje = servStatsPersonaje;
        }

        private async void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarEfectos();
            CargarEscenarios();
            await CargarPersonajesAsync();

            ActualizarSpritesPersonajesSeleccionados();
            ActualizarVidaYEstadosUI();
            ActualizarEscenarioVisual();
        }

        private async void btnSimularTurno_Click(object sender, EventArgs e)
        {
            if (!_batallaEnCurso)
            {
                if (cboPersonajeUno.SelectedItem is not IPersonaje p1 ||
                    cboPersonajeDos.SelectedItem is not IPersonaje p2)
                {
                    MessageBox.Show("Seleccione dos personajes.");
                    return;
                }

                if (p1 == p2)
                {
                    MessageBox.Show("Los personajes deben ser distintos.");
                    return;
                }

                _personaje1 = p1;
                _personaje2 = p2;

                _estadoBatalla = _servBatalla.CrearBatalla(_personaje1, _personaje2);
                _batallaEnCurso = true;

                cboPersonajeUno.Enabled = false;
                cboPersonajeDos.Enabled = false;
                cboEscenario.Enabled = false;

                lstLog.Items.Add("=== ¡La batalla comienza! ===");

                string inicia = _estadoBatalla.TurnoP1
                    ? _personaje1.ToString()!
                    : _personaje2.ToString()!;

                lstLog.Items.Add($"🎲 El azar decide: comienza atacando {inicia}");

                _efectosUsadosEnTurno = 0;
                lblEfectosTurno.Text = "Efectos usados este turno: 0/2";
                lblTurno.Text = $"Turno: {_estadoBatalla.NumeroTurno}";

                await _servStatsPersonaje.RegistrarBatalla(_personaje1.Id);
                await _servStatsPersonaje.RegistrarBatalla(_personaje2.Id);

                ActualizarVidaYEstadosUI();
                ActualizarSpritesPersonajesSeleccionados();
                return;
            }

            if (_estadoBatalla == null)
                return;

            var escenario = (IEfectoVisitor)cboEscenario.SelectedItem!;
            var resultado = _servBatalla.EjecutarTurno(_estadoBatalla, escenario);

            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Error);
                return;
            }

            var datos = resultado.Valor!;

            foreach (var linea in datos.LogEventos)
                lstLog.Items.Add(linea);

            PictureBox spriteDefensor =
                datos.Defensor == _personaje1 ? picP1 : picP2;

            await AnimarGolpe(spriteDefensor);

            if (datos.DanioCausado > 0)
            {
                await _servStatsPersonaje.RegistrarDanioCausado(
                    datos.Atacante.Id, datos.DanioCausado);

                await _servStatsPersonaje.RegistrarDanioRecibido(
                    datos.Defensor.Id, datos.DanioCausado);
            }

            if (datos.Atacante.Vida > 0)
                await _servStatsPersonaje.RegistrarTurnoSobrevivido(datos.Atacante.Id);

            if (datos.Defensor.Vida > 0)
                await _servStatsPersonaje.RegistrarTurnoSobrevivido(datos.Defensor.Id);

            ActualizarVidaYEstadosUI();

            if (datos.BatallaFinalizada)
            {
                if (datos.Ganador != null)
                {
                    IPersonaje ganador = datos.Ganador;
                    IPersonaje perdedor = ganador == _personaje1 ? _personaje2! : _personaje1!;

                    lstLog.Items.Add($"🏆 GANADOR: {ganador}");

                    await _servStatsPersonaje.RegistrarVictoria(ganador.Id);
                    await _servStatsPersonaje.RegistrarDerrota(perdedor.Id);

                    await _servStatsPersonaje.ActualizarMaxTurnos(
                        ganador.Id, _estadoBatalla.NumeroTurno);

                    await _servStatsPersonaje.ActualizarMaxTurnos(
                        perdedor.Id, _estadoBatalla.NumeroTurno);
                }
                else
                {
                    lstLog.Items.Add("🤝 EMPATE.");
                }

                DialogResult r = MostrarMensajeFinal(datos.Ganador);

                if (r == DialogResult.Yes)
                    ReiniciarBatalla();
                else
                    TerminarBatalla();

                return;
            }

            _efectosUsadosEnTurno = 0;
            lblEfectosTurno.Text = "Efectos usados este turno: 0/2";
            lblTurno.Text = $"Turno: {_estadoBatalla.NumeroTurno}";
        }

        private void TerminarBatalla()
        {
            _batallaEnCurso = false;
            _estadoBatalla = null;

            cboPersonajeUno.Enabled = true;
            cboPersonajeDos.Enabled = true;
            cboEscenario.Enabled = true;

            lblTurno.Text = "Turno: -";
            lstLog.Items.Add("=== La batalla ha terminado ===");
        }

        private async void ReiniciarBatalla()
        {
            lstLog.Items.Clear();
            lstLog.Items.Add("=== Nueva batalla iniciada ===");

            _personaje1 = (await _servPersonaje.ObtenerPorIdAsync(_personaje1!.Id)).Valor!;
            _personaje2 = (await _servPersonaje.ObtenerPorIdAsync(_personaje2!.Id)).Valor!;

            _estadoBatalla = _servBatalla.CrearBatalla(_personaje1, _personaje2);
            _batallaEnCurso = true;

            _efectosUsadosEnTurno = 0;
            lblTurno.Text = $"Turno: {_estadoBatalla.NumeroTurno}";
            lblEfectosTurno.Text = "Efectos usados este turno: 0/2";

            string inicia = _estadoBatalla.TurnoP1
                ? _personaje1.ToString()!
                : _personaje2.ToString()!;

            lstLog.Items.Add($"🎲 El azar decide: comienza atacando {inicia}");

            await _servStatsPersonaje.RegistrarBatalla(_personaje1.Id);
            await _servStatsPersonaje.RegistrarBatalla(_personaje2.Id);

            ActualizarVidaYEstadosUI();
            ActualizarSpritesPersonajesSeleccionados();
        }


        private void CargarAtacantesYDefensores()
        {
            cboPersonajeUno.DataSource = null;
            cboPersonajeDos.DataSource = null;

            cboPersonajeUno.DataSource = new List<IPersonaje>(_personajes);
            cboPersonajeUno.DisplayMember = "ToString";

            cboPersonajeDos.DataSource = new List<IPersonaje>(_personajes);
            cboPersonajeDos.DisplayMember = "ToString";

            if (_personajes.Count >= 2)
            {
                cboPersonajeUno.SelectedIndex = 0;
                cboPersonajeDos.SelectedIndex = 1;
            }
        }

        private void CargarEfectos()
        {
            cboEfectos.Items.Clear();
            cboEfectos.Items.Add(new CuraVisitor());
            cboEfectos.Items.Add(new QuemaduraVisitor());
            cboEfectos.Items.Add(new VenenoVisitor());
            cboEfectos.Items.Add(new BendicionVisitor());
            cboEfectos.Items.Add(new IraVisitor());
            cboEfectos.Items.Add(new MejoraAtaqueVisitor());
            cboEfectos.Items.Add(new CongelamientoVisitor());

            cboEfectos.SelectedIndex = 0;
        }

        private void CargarEscenarios()
        {
            cboEscenario.Items.Clear();
            cboEscenario.Items.Add(new SinEscenarioVisitor());
            cboEscenario.Items.Add(new BosqueVisitor());
            cboEscenario.Items.Add(new VolcanVisitor());

            cboEscenario.SelectedIndex = 0;
        }

        private async Task CargarPersonajesAsync()
        {
            var resultado = await _servPersonaje.ObtenerTodosAsync();

            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Error, "Error");
                return;
            }

            _personajes = resultado.Valor!;
            CargarAtacantesYDefensores();
        }

        private Image? ObtenerSprite(IPersonaje p)
        {
            return p.Tipo switch
            {
                TipoPersonaje.Guerrero => ByteArrayAImagen(Properties.Resources.GuerreroSNES),
                TipoPersonaje.Mago => ByteArrayAImagen(Properties.Resources.MagoSNES),
                TipoPersonaje.Arquero => ByteArrayAImagen(Properties.Resources.ArqueroSNES),
                _ => null
            };
        }

        private void ActualizarSpritesPersonajesSeleccionados()
        {
            IPersonaje? p1 = _personaje1 ?? (cboPersonajeUno.SelectedItem as IPersonaje);
            IPersonaje? p2 = _personaje2 ?? (cboPersonajeDos.SelectedItem as IPersonaje);

            if (p1 != null)
                picP1.Image = ObtenerSprite(p1);

            if (p2 != null)
                picP2.Image = ObtenerSprite(p2);
        }

        private void ActualizarEscenarioVisual()
        {
            var escenario = (IEfectoVisitor)cboEscenario.SelectedItem!;

            pnlArena.BackgroundImage = escenario.Nombre switch
            {
                "Bosque" => ByteArrayAImagen(Properties.Resources.BosqueSNES),
                "Volcan" => ByteArrayAImagen(Properties.Resources.VolcanSNES),
                _ => null
            };
        }

        private Image ByteArrayAImagen(byte[] bytes)
        {
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        private void cboPersonajeUno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_batallaEnCurso) return;

            _personaje1 = (IPersonaje)cboPersonajeUno.SelectedItem!;
            ActualizarSpritesPersonajesSeleccionados();
            ActualizarVidaYEstadosUI();
        }

        private void cboPersonajeDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_batallaEnCurso) return;

            _personaje2 = (IPersonaje)cboPersonajeDos.SelectedItem!;
            ActualizarSpritesPersonajesSeleccionados();
            ActualizarVidaYEstadosUI();
        }

        private void cboEscenario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_batallaEnCurso) return;
            ActualizarEscenarioVisual();
        }

        private void ActualizarVidaYEstadosUI()
        {
            if (_personaje1 != null)
            {
                lblVidaP1.Text = $"VIDA: {_personaje1.Vida}";
                lblEstadosP1.Text = FormatearEstados(_personaje1);
                ActualizarStats(_personaje1, lblStatsP1);
            }
            else
            {
                lblVidaP1.Text = "VIDA: -";
                lblEstadosP1.Text = "ESTADOS: -";
                lblStatsP1.Text = "STATS: -";
            }

            if (_personaje2 != null)
            {
                lblVidaP2.Text = $"VIDA: {_personaje2.Vida}";
                lblEstadosP2.Text = FormatearEstados(_personaje2);
                ActualizarStats(_personaje2, lblStatsP2);
            }
            else
            {
                lblVidaP2.Text = "VIDA: -";
                lblEstadosP2.Text = "ESTADOS: -";
                lblStatsP2.Text = "STATS: -";
            }
        }

        private string FormatearEstados(IPersonaje p)
        {
            if (p.EstadosTemporales == null || p.EstadosTemporales.Count == 0)
                return "ESTADOS: -";

            var partes = p.EstadosTemporales
                .Select(e => $"{e.Nombre}({e.TurnosRestantes})");

            return "ESTADOS: " + string.Join(", ", partes);
        }

        private void ActualizarStats(IPersonaje p, Label destino)
        {
            if (p == null)
            {
                destino.Text = "STATS: -";
                return;
            }

            destino.Text =
                $"ATQ: {p.Ataque}\n" +
                $"DEF: {p.Defensa}\n" +
                $"MANÁ: {p.Mana}\n" +
                $"TIPO: {p.Tipo}";
        }

        private async Task AnimarGolpe(PictureBox objetivo)
        {
            int originalX = objetivo.Left;

            for (int i = 0; i < 4; i++)
            {
                if (i == 2)
                    _ = FlashOverlay(objetivo);

                objetivo.Left = originalX + 8;
                await Task.Delay(40);
                objetivo.Left = originalX - 8;
                await Task.Delay(40);
            }

            _ = FlashOverlay(objetivo);
            objetivo.Left = originalX;
        }

        private async Task FlashOverlay(PictureBox pic)
        {
            Panel overlay = new()
            {
                BackColor = Color.FromArgb(160, Color.Red),
                Size = pic.Size,
                Location = pic.Location
            };
            overlay.Parent = pic.Parent;
            overlay.BringToFront();
            overlay.Visible = true;

            await Task.Delay(150);
            overlay.Dispose();
        }

        private async Task AnimarEfecto(PictureBox pic, IEfectoVisitor efecto)
        {
            if (pic.Parent == null) return;

            Color color = efecto.Nombre switch
            {
                "Cura" => Color.FromArgb(120, Color.Lime),
                "Bendicion" => Color.FromArgb(120, Color.DeepSkyBlue),
                "Mejora ataque" => Color.FromArgb(120, Color.Gold),
                "Quemadura" => Color.FromArgb(140, Color.OrangeRed),
                "Veneno" => Color.FromArgb(140, Color.Purple),
                "Ira" => Color.FromArgb(140, Color.DarkRed),
                "Congelamiento" => Color.FromArgb(140, Color.Cyan),
                _ => Color.FromArgb(140, Color.Red)
            };

            Panel overlay = new Panel
            {
                BackColor = color,
                Bounds = pic.Bounds
            };

            pic.Parent.Controls.Add(overlay);
            overlay.BringToFront();

            await Task.Delay(220);

            pic.Parent.Controls.Remove(overlay);
            overlay.Dispose();
        }



        private async void picP1_Click(object sender, EventArgs e)
        {
            await AplicarEfectoDesdeClick(_personaje1, "Personaje 1", picP1);
        }

        private async void picP2_Click(object sender, EventArgs e)
        {
            await AplicarEfectoDesdeClick(_personaje2, "Personaje 2", picP2);
        }

        private async Task AplicarEfectoDesdeClick(IPersonaje? personaje, string nombre, PictureBox picObjetivo)
        {
            if (personaje == null)
            {
                MessageBox.Show("No hay personaje cargado.");
                return;
            }

            if (!_batallaEnCurso)
            {
                MessageBox.Show("La batalla no ha comenzado. No podés aplicar efectos.");
                return;
            }

            if (_efectosUsadosEnTurno >= 2)
            {
                MessageBox.Show("Solo podés aplicar 2 efectos por turno.");
                return;
            }

            var efecto = (IEfectoVisitor)cboEfectos.SelectedItem!;

            if (efecto == null)
            {
                MessageBox.Show("Efecto no reconocido.");
                return;
            }

            string log = personaje.Aceptar(efecto, true);
            lstLog.Items.Add($"[{nombre}] {log}");

            _efectosUsadosEnTurno++;
            lblEfectosTurno.Text = $"Efectos usados este turno: {_efectosUsadosEnTurno}/2";

            await _servStatsPersonaje.RegistrarEfectoAplicado(personaje.Id);
            await _servStatsPersonaje.RegistrarEfectoRecibido(personaje.Id);

            await AnimarEfecto(picObjetivo, efecto);

            ActualizarVidaYEstadosUI();
        }

        private void btnStatsP1_Click(object sender, EventArgs e)
        {
            if (_personaje1 == null)
            {
                MessageBox.Show("No hay personaje 1 seleccionado.");
                return;
            }

            var form = new FormStatsPersonaje(_personaje1.Id, _servStatsPersonaje);
            form.ShowDialog(this);
        }

        private void btnStatsP2_Click(object sender, EventArgs e)
        {
            if (_personaje2 == null)
            {
                MessageBox.Show("No hay personaje 2 seleccionado.");
                return;
            }

            var form = new FormStatsPersonaje(_personaje2.Id, _servStatsPersonaje);
            form.ShowDialog(this);
        }

        private DialogResult MostrarMensajeFinal(IPersonaje? ganador)
        {
            string titulo = "⚔️ Batalla finalizada";
            string mensaje;

            if (ganador != null)
            {
                mensaje =
                    $"🏆 ¡Victoria!\n\n" +
                    $"El vencedor es:\n" +
                    $"➡ {ganador}\n\n" +
                    $"¿Querés jugar otra batalla?";
            }
            else
            {
                mensaje =
                    $"🤝 ¡Empate!\n\n" +
                    $"Ambos combatientes cayeron al mismo tiempo.\n\n" +
                    $"¿Querés jugar otra batalla?";
            }

            return MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );
        }

    }
}
