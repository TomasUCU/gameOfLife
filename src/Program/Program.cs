namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializamos
            BoardLoader loader = new BoardLoader();
            GameController controller = new GameController();
            controller.Board = loader.Load("board.txt");
            
            // Calculamos e Imprimimos proxima generacion
            while (true)
            {
                controller.Next();
                controller.Print();
            }
        }
    }
}
