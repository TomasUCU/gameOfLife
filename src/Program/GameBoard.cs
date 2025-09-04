using System;
using System.Drawing;

namespace Ucu.Poo.GameOfLife;

public class GameBoard
{
    public int tamaño;
    public int[,] tablero;

    public GameBoard(int tamaño, int[,] tablero) // Constructor 
    {
        this.tamaño = tamaño;
        this.tablero = tablero; // No pongo new ya que uso el tablero que paso por parametro, no lo creo de cero
    }

    public void IniciarAleatorio() // Inicializa el tablero con celulas vivas y muertas aleatorias
    {
        Random random = new Random();
        for (int i = 0; i < tamaño; i++)
        {
            for (int j = 0; j < tamaño; j++)
            {
                tablero[i, j] = random.Next(2); // Los posibles valores son 0 (apagado) y 1 (prendido)
            }
        }
    }

    public int ContarVecinos(int x, int y) // Cuenta cuantas celulas vivas hay en el tablero (sin contar la del medio, que es la nuestra). Posisciones x e y para ver las coordenadas de los vecinos
    {
        int contador = 0; // Cuenta cuales están encendidos (tablero[x,y]==1)
        if (x > 0 && tablero[x-1,y] == 1) // Arriba (por cuestiones de filas y columnas)
        {
            contador++;
        }
        if (x > 0 && y > 0 && tablero[x-1,y-1] == 1) // Arriba-Izq. x>0 para que no se pase de la altura del tablero, y>0 para que no se pase del ancho del tablero (posisción negativa)
        {
            contador++;
        }
        if (x > 0 && y < tamaño-1 && tablero[x-1,y+1] == 1) // Arriba-Der. y<tamaño-1 para que no se pase del ancho del tablero
        {
            contador++;
        }
        if (y < tamaño-1 && tablero[x,y+1] == 1) // Derecha
        {
            contador++;
        }
        if (y > 0 && tablero[x,y-1] == 1) // Izquierda
        {
            contador++;
        }
        if (x < tamaño-1 &&  tablero[x+1,y] == 1) // Abajo
        {
            contador++;
        }
        if (x < tamaño-1 && y > 0 && tablero[x+1,y-1] == 1) // Abajo-Izq
        {
            contador++;
        }
        if (x < tamaño-1 && y < tamaño-1 && tablero[x+1,y+1] == 1) // Abajo-Der. x<tamaño-1 para que no se pase de la altura del tablero
        {
            contador++;
        }
        return contador;
    }

    public void RefrescarTablero()  // Calcula la siguiente generación del tablero aplicando las reglas del juego de la vida
    {
        int[,] nuevotablero = new int[tamaño, tamaño];  // Creo un nuevo tablero para la siguiente generación 

        for (int x = 0; x < tamaño; x++)
        {
            for (int y = 0; y < tamaño; y++)
            {
                int vecinos =  ContarVecinos(x,y);  // Invoco a la función para tener el contador

                if ( (vecinos < 2 || vecinos > 3) && (tablero[x,y]==1) ) 
                {
                    nuevotablero[x,y] = 0; // Muere por soledad o sobrepoblación
                }

                if ( (vecinos == 2 || vecinos == 3) && (tablero[x,y]==1) ) 
                {
                    nuevotablero[x,y] = 1; // Sobrevive 
                }

                if (vecinos == 3 && tablero[x, y] == 0)
                {
                    nuevotablero[x,y] = 1; // Nace por reproducción
                }
            }
        }
        tablero = nuevotablero; // Afuera del for para calcular el nuevo tablero y recíen ahí actualizar. nuevotablero se guarda en tablero para poder operar correctamente en la siguiente iteración
    }
} 