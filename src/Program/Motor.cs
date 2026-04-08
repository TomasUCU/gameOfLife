using System;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Responsabilidad: calcular la siguiente generación del juego aplicando las
    /// reglas de Conway sobre un tablero dado.
    /// Cumple SRP: su única razón de cambio es si las reglas del juego cambian.
    /// Cumple Expert: recibe el Board que contiene la información necesaria para
    /// aplicar las reglas; no sabe nada de cómo se carga ni cómo se muestra el tablero.
    /// </summary>
    public class GameEngine
    {
        private readonly Board board;

        public GameEngine(Board board)
        {
            this.board = board ?? throw new ArgumentNullException(nameof(board));
        }

        /// <summary>
        /// Avanza el tablero una generación aplicando las cuatro reglas de Conway.
        /// </summary>
        public void NextGeneration()
        {
            bool[,] current = this.board.GetCellsCopy();

            for (int x = 0; x < this.board.Width; x++)
            {
                for (int y = 0; y < this.board.Height; y++)
                {
                    int aliveNeighbors = this.CountAliveNeighbors(current, x, y);
                    bool isAlive = current[x, y];

                    if (isAlive && aliveNeighbors < 2)
                        this.board.SetCellState(x, y, false);   // muere por soledad
                    else if (isAlive && aliveNeighbors > 3)
                        this.board.SetCellState(x, y, false);   // muere por sobrepoblación
                    else if (!isAlive && aliveNeighbors == 3)
                        this.board.SetCellState(x, y, true);    // nace por reproducción
                    // else: mantiene su estado, no hace falta escribir nada
                }
            }
        }

        /// <summary>
        /// Cuenta los vecinos vivos de la celda (x, y) sobre una copia inmutable del tablero.
        /// Se opera sobre la copia para que las escrituras de NextGeneration no
        /// contaminen el conteo de las celdas que aún no se procesaron.
        /// </summary>
        private int CountAliveNeighbors(bool[,] snapshot, int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue;
                    if (!this.board.IsValidPosition(i, j)) continue;

                    if (snapshot[i, j]) count++;
                }
            }

            return count;
        }
    }
}