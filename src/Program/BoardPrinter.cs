using System;
using System.Text;
namespace Ucu.Poo.GameOfLife
/// <summary>
/// Colabora con la clase Board y muestra por consola su estado actual. 
/// Recorre las células y representa visualmente su estado actual. 
/// </summary>
{
    public class BoardPrinter
    {
        private readonly Board board;

        public BoardPrinter(Board board)
        {
            this.board = board ?? throw new ArgumentNullException(nameof(board));
        }

        public void Print()
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    s.Append(board.GetCellState(x, y) ? "|X|" : "___");
                }
                s.Append("\n");
            }

            Console.WriteLine(s.ToString());
        }
    }
}