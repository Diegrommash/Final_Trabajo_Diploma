using BE;
using BE.Visitor;
using System;

namespace BLL
{
    public class ServBatalla
    {

        public EstadoBatalla CrearBatalla(IPersonaje p1, IPersonaje p2)
        {
            return new EstadoBatalla
            {
                Personaje1 = p1,
                Personaje2 = p2,
                TurnoP1 = Random.Shared.Next(2) == 0
            };
        }

        public Resultado<ResultadoBatalla> EjecutarTurno(
            EstadoBatalla estado,
            IEfectoVisitor? escenario)
        {
            try
            {
                if (estado.Finalizada)
                    return Resultado<ResultadoBatalla>.Fallo("La batalla ya finalizó.");

                IPersonaje atacante = estado.TurnoP1
                    ? estado.Personaje1
                    : estado.Personaje2;

                IPersonaje defensor = estado.TurnoP1
                    ? estado.Personaje2
                    : estado.Personaje1;

                var resultado = new ResultadoBatalla
                {
                    Atacante = atacante,
                    Defensor = defensor,
                    NumeroTurno = estado.NumeroTurno
                };

                resultado.LogEventos.Add($"--- TURNO {estado.NumeroTurno} ---");

                AplicarEstadosTemporales(atacante, resultado);
                AplicarEstadosTemporales(defensor, resultado);

                if (escenario != null)
                {
                    string logA = atacante.Aceptar(escenario, true);
                    string logD = defensor.Aceptar(escenario, true);

                    resultado.LogEventos.Add("Escenario:");
                    resultado.LogEventos.Add($" - {atacante}: {logA}");
                    resultado.LogEventos.Add($" - {defensor}: {logD}");
                }

                int danio = Math.Max(0, atacante.Ataque - defensor.Defensa);
                defensor.Vida -= danio;

                resultado.DanioCausado = danio;

                resultado.LogEventos.Add(
                    $"{atacante} ataca a {defensor} y causa {danio} de daño. " +
                    $"Vida restante: {Math.Max(0, defensor.Vida)}");

                EvaluarFinDeBatalla(estado, resultado);

                if (!estado.Finalizada)
                {
                    estado.TurnoP1 = !estado.TurnoP1;
                    estado.NumeroTurno++;
                }

                return Resultado<ResultadoBatalla>.Correcto(resultado);
            }
            catch (Exception ex)
            {
                return Resultado<ResultadoBatalla>.Fallo(
                    "Error al ejecutar el turno de batalla: " + ex.Message);
            }
        }

        private void AplicarEstadosTemporales(IPersonaje p, ResultadoBatalla res)
        {
            for (int i = p.EstadosTemporales.Count - 1; i >= 0; i--)
            {
                var estado = p.EstadosTemporales[i];

                string log = p.Aceptar(estado.Efecto, false);
                estado.TurnosRestantes--;
                 
                res.LogEventos.Add(
                    $"Estado '{estado.Nombre}' en {p}: {log} " +
                    $"(restan {estado.TurnosRestantes})");

                if (estado.TurnosRestantes <= 0)
                {
                    res.LogEventos.Add(
                        $"El estado '{estado.Nombre}' se desvanece de {p}.");
                    p.EstadosTemporales.RemoveAt(i);
                }
            }
        }

        private void EvaluarFinDeBatalla(
            EstadoBatalla estado,
            ResultadoBatalla resultado)
        {
            var p1 = estado.Personaje1;
            var p2 = estado.Personaje2;

            if (p1.Vida <= 0 && p2.Vida <= 0)
            {
                estado.Finalizada = true;
                resultado.BatallaFinalizada = true;
                resultado.LogEventos.Add("Ambos personajes han caído. Empate.");
                return;
            }

            if (p1.Vida <= 0)
            {
                estado.Finalizada = true;
                resultado.BatallaFinalizada = true;
                resultado.Ganador = p2;
                resultado.LogEventos.Add($"{p2} ha ganado la batalla.");
                return;
            }

            if (p2.Vida <= 0)
            {
                estado.Finalizada = true;
                resultado.BatallaFinalizada = true;
                resultado.Ganador = p1;
                resultado.LogEventos.Add($"{p1} ha ganado la batalla.");
            }
        }
    }
}
