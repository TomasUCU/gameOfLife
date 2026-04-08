using System.Threading;
using Ucu.Poo.GameOfLife;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BoardImporter importer = new BoardImporter();
            Board board = importer.Import();

            GameEngine engine = new GameEngine(board);
            BoardPrinter printer = new BoardPrinter(board);

            while (true)
            {
                printer.Print();          
                engine.NextGeneration(); 

                Thread.Sleep(300);        
            }
        }
    }
}