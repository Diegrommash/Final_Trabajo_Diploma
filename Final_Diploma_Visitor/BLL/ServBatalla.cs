using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServBatalla
    {
        public ServBatalla()
        {
        }

        public Resultado<ResultadoBatalla> SimularTurno(
            IPersonaje atacante,
            IPersonaje defensor,
            IEfectoVisitor? escenario,
            int numeroTurno)
        {
            var resultado = new ResultadoBatalla
            {
                Atacante = atacante,
                Defensor = defensor,
                NumeroTurno = numeroTurno
            };

            try
            {
                // 1) Aplicar estados temporales al comienzo del turno
                AplicarEstadosTemporales(atacante, resultado);
                AplicarEstadosTemporales(defensor, resultado);

                //// 2) Aplicar escenario (si hay)
                if (escenario != null)
                {
                    string logA = atacante.Aceptar(escenario, true);
                    string logD = defensor.Aceptar(escenario, true);

                    resultado.LogEventos.Add($"[Turno {numeroTurno}] Escenario:");
                    resultado.LogEventos.Add($" - {atacante}: {logA}");
                    resultado.LogEventos.Add($" - {defensor}: {logD}");
                }

                // 3) Resolver ataque
                int danio = Math.Max(0, atacante.Ataque - defensor.Defensa);
                defensor.Vida -= danio;

                resultado.LogEventos.Add(
                    $"[Turno {numeroTurno}] {atacante} ataca a {defensor} y causa {danio} de daño. Vida defensor: {defensor.Vida}");

                // 4) Ver si alguno murió
                if (defensor.Vida <= 0 && atacante.Vida <= 0)
                {
                    resultado.BatallaFinalizada = true;
                    resultado.LogEventos.Add("Ambos personajes han caído. Empate.");
                }
                else if (defensor.Vida <= 0)
                {
                    resultado.BatallaFinalizada = true;
                    resultado.Ganador = atacante;
                    resultado.LogEventos.Add($"{atacante} ha ganado la batalla.");
                }
                else if (atacante.Vida <= 0)
                {
                    resultado.BatallaFinalizada = true;
                    resultado.Ganador = defensor;
                    resultado.LogEventos.Add($"{defensor} ha ganado la batalla.");
                }

                return Resultado<ResultadoBatalla>.Correcto(resultado);
            }
            catch (Exception ex)
            {
                return Resultado<ResultadoBatalla>.Fallo("Error al simular el turno: " + ex.Message);
            }
        }


        private void AplicarEstadosTemporales(IPersonaje p, ResultadoBatalla res)
        {
            for (int i = p.EstadosTemporales.Count - 1; i >= 0; i--)
            {
                var estado = p.EstadosTemporales[i];

                string log = p.Aceptar(estado.Efecto, false);
                estado.TurnosRestantes--;

                res.LogEventos.Add($"  Estado '{estado.Nombre}' en {p}: {log} (restan {estado.TurnosRestantes})");

                if (estado.TurnosRestantes <= 0)
                {
                    res.LogEventos.Add($"  Estado '{estado.Nombre}' se desvanece de {p}.");
                    p.EstadosTemporales.RemoveAt(i);
                }
            }
        }

    }
}
