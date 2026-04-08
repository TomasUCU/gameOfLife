using System.IO;
namespace Ucu.Poo.GameOfLife;
/// <summary>
/// Importa desde archivo el tamaño de la matriz y la posición inicial de las células en ella.
/// Usa esta matriz para instanciar el primer Board.
/// </summary>
public class BoardImporter
{
    public Board Import()
    {
        string url = "board.txt";

        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');

        int height = contentLines.Length;
        int width = contentLines[0].Length;

        bool[,] cells = new bool[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[x, y] = contentLines[y][x] == '1';
            }
        }

        return new Board(cells);
    }
}