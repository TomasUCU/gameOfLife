using GameOfLife.IO;
using Program;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializamos instancias
            BoardLoader loader = new BoardLoader();
            BoardPrinter printer = new BoardPrinter();
            GameController controller = new GameController();
            
            // Cargamos board desde archivo
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(currentDir, "board.txt");
            controller.Board = loader.Load(path);
            
            // Calculamos e Imprimimos proxima generacion
            while (true)
            {
                controller.Next();
                printer.PrintBoard(controller.Board);
            }
        }
    }
}
