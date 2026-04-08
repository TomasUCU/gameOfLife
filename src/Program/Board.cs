using System;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Representa el tablero del juego.
    /// Conoce el tamaño de la matriz y el estado de cada posición.
    /// </summary>
    public class Board
    {
        private readonly bool[,] cells;

        public Board(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "El ancho debe ser mayor a 0.");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "El alto debe ser mayor a 0.");
            }

            this.cells = new bool[width, height];
        }

        public Board(bool[,] initialState)
        {
            this.cells = initialState ?? throw new ArgumentNullException(nameof(initialState));
        }

        public int Width => this.cells.GetLength(0);

        public int Height => this.cells.GetLength(1);

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < this.Width && y >= 0 && y < this.Height;
        }

        public bool GetCellState(int x, int y)
        {
            if (!this.IsValidPosition(x, y))
            {
                throw new ArgumentOutOfRangeException($"La posición ({x}, {y}) está fuera del tablero.");
            }

            return this.cells[x, y];
        }

        public void SetCellState(int x, int y, bool state)
        {
            if (!this.IsValidPosition(x, y))
            {
                throw new ArgumentOutOfRangeException($"La posición ({x}, {y}) está fuera del tablero.");
            }

            this.cells[x, y] = state;
        }

        public bool[,] GetCellsCopy()
        {
            return (bool[,])this.cells.Clone();
        }
    }
}
