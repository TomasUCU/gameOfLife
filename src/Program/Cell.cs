public class Cell
{
    private bool ConVida;

    public Cell(bool alive)
    {
        ConVida = alive;
    }

    public bool IsAlive()
    {
        return ConVida;
    }

    public void CambiarEstado(bool alive)
    {
        ConVida = alive;
    }

    public void Toggle()
    {
        ConVida = !ConVida;
    }
}