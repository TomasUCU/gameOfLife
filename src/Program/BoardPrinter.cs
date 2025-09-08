using System.Text;

namespace Ucu.Poo.GameOfLife
{
    // BoardPrinter cumple con SRP porque tiene una única responsabilidad: mostrar el tablero en consola.
    // No calcula la siguiente generación, no lee archivos, ni modifica nada; solo imprime.
    // Y cumple con Expert porque es experta en representar en texto un tablero de GameBoard 
    /// y conoce cómo mostrar los valores 0 (muerto) y 1 (vivo).
    

    public class BoardPrinter
    {

        public void PrintBoard(bool[,] board) 
        {
            // Limpia la Consola antes de empezar
            Console.Clear();
            
            //Obtiene las dimensiones del tablero
            int width = board.GetLength(0);// numero de filas
            int height = board.GetLength(1);// numero de columnas
            
            // StringBuilder para construir el texto a imprimir de mejor manera
            StringBuilder output = new StringBuilder();

            //Recorre cada fila
            for (int x = 0; x < width; x++)
            {
                //Recorre cada columna
                for (int y = 0; y < height; y++)
                {
                    
                    // Si la celda está viva, agrega "|X|", si está muerta, "__"
                    if (board[x, y])
                    {
                        output.Append("|X|");
                    }
                    else
                    {
                        output.Append("___");
                    }
                }
                //Salto de linea  al final de cada fila
                output.Append("\n");    
            }
            //Imprime el tablero en consola
            Console.WriteLine(output.ToString());
        }
    }
}

