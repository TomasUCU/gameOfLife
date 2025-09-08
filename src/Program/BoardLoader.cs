namespace GameOfLife.IO
{
    /// <summary>
    /// leer un archivo de texto y convertirlo en un tablero
    /// </summary>
    public sealed class BoardLoader
    {
        public bool[,] Load(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("El nombre de archivo no puede ser vacío.", nameof(path));

            string[] rawLines = File.ReadAllLines(path);

            if (rawLines.Length == 0)
                throw new InvalidDataException("El archivo está vacío.");

            int height = rawLines.Length;
            int width = rawLines[0].Length;

            // Validar filas iguales
            foreach (var line in rawLines)
            {
                if (line.Length != width)
                    throw new InvalidDataException("Todas las filas deben tener la misma longitud.");
            }

            bool[,] board = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char c = rawLines[y][x];
                    if (c == '1')
                        board[x, y] = true;
                    else if (c == '0')
                        board[x, y] = false;
                    else
                        throw new InvalidDataException($"Carácter inválido '{c}' en fila {y}, columna {x}.");
                }
            }

            return board;
        }
    }
}