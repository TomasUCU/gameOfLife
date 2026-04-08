using System.IO;
namespace Ucu.Poo.GameOfLife;
/// <summary>
/// Importa desde archivo el tamaño de la matriz y la posición inicial de las células en ella.
/// Usa esta matriz para instanciar el primer Board.
/// </summary>
public class BoardImporter
{
    string url = "board.txt";
    public Board Import()
    {
        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');

        int height = contentLines.Length;
        int width = contentLines[0].Trim().Length;
        bool[,] cells = new bool[width, height];

        for (int y = 0; y < height; y++)
        {
            string line = contentLines[y].Trim();
            if (line == "") continue; // evita líneas vacías

            for (int x = 0; x < line.Length; x++)
            {
                cells[x, y] = line[x] == '1';
            }
        }

        return new Board(cells);
    }
}