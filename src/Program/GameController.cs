namespace Ucu.Poo.GameOfLife
{
    public class GameController : BoardPrinter
    {
        public bool[,] Board;
        
        public void Next()
        {
            //Obtiene las dimensiones del tablero
            int width = Board.GetLength(0);// numero de filas
            int height = Board.GetLength(1);// numero de columnas

            bool[,] cloneboard = new bool[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<width && j>=0 && j < height && Board[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(Board[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (Board[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (Board[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!Board[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x,y] = Board[x,y];
                    }
                }
            }
            Board  = cloneboard;
        }

        public void Print()
        {
            PrintBoard(Board);
        }
    }   
}