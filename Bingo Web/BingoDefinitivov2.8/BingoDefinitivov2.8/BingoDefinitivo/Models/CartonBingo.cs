using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoDefinitivo.Models
{
    public class CartonBingo
    {
        public int[,] CARTON = new int[3, 9];
        public bool[,] ACERTADOS = new bool[3, 9];
        public bool EsGanador { get; set; }



        public CartonBingo(CartonComprimed BingoComprimido)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    CARTON[i, j] = BingoComprimido.Carton[j + (i * 9)];
                    ACERTADOS[i, j] = BingoComprimido.Aciertos[j + (i * 9)];
                }
            }
            // Esto es para que se cargue si es ganador o no
            Chequeo(-100);
        }
        //INICIADOR
        public CartonBingo()
        {
            const int FILAS = 3; const int COLUMNAS = 9; Random Random = new Random();
            //rellenador de matriz
            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COLUMNAS; j++)
                {
                    CARTON[i, j] = Random.Next(0, 9) + 10 * j;
                }
            }
            //corrector de repeticiones
            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COLUMNAS; j++)
                {
                    for (int pos = 0; pos < 3; pos++)
                    {
                        if (pos != i)
                        {
                            if (CARTON[i, j] == CARTON[pos, j])
                            {
                                do
                                    CARTON[pos, j] = Random.Next(0, 9) + 10 * j;
                                while (CARTON[i, j] == CARTON[pos, j]);
                            }
                        }
                    }
                }
            }
            //ordenar de mayor a menor
            int AUX;
            for (int j = 0; j < COLUMNAS - 1; j++)
            {
                for (int i = 0; i < FILAS; i++)
                {
                    for (int pos = i + 1; pos < 3; pos++)
                    {
                        if (CARTON[i, j] > CARTON[pos, j])
                        {
                            AUX = CARTON[i, j];
                            CARTON[i, j] = CARTON[pos, j];
                            CARTON[pos, j] = AUX;
                        }
                    }
                }
            }
            int[,] MATRIZELIMINACION = new int[FILAS, COLUMNAS];
            //Crear la Matriz de eliminacion de numeros
            for (int i = 0; i < FILAS; i++)
            {
                for (int j = 0; j < COLUMNAS; j++)
                {
                    MATRIZELIMINACION[i, j] = Random.Next(0, 1);

                }
            }
            int[] countX = new int[3]; int[] countY = new int[9];
            for (int A = 0; A < FILAS; A++)
            {
                for (int B = 0; B < COLUMNAS; B++)
                {
                    do
                    {
                        for (int i = 0; i < FILAS; i++)
                        {
                            do
                            {
                                countX[i] = 0;
                                for (int j = 0; j < COLUMNAS; j++)
                                {
                                    if (MATRIZELIMINACION[i, j] == 0)
                                    {
                                        countX[i] = countX[i] + 1;
                                    }
                                }

                                if (countX[i] > 4)
                                {
                                    for (int j = 0; j < COLUMNAS; j++)
                                    {
                                        do
                                        {
                                            MATRIZELIMINACION[i, Random.Next(0, 8)] = 1;
                                            countX[i] = 0;
                                            for (int check = 0; check < COLUMNAS; check++)
                                            {
                                                if (MATRIZELIMINACION[i, check] == 0)
                                                {
                                                    countX[i] = countX[i] + 1;
                                                }
                                            }
                                        }

                                        while (countX[i] > 4);

                                    }

                                }
                                if (countX[i] < 4)
                                {
                                    for (int j = 0; j < COLUMNAS; j++)
                                    {
                                        do
                                        {
                                            MATRIZELIMINACION[i, Random.Next(0, 8)] = 0;
                                            countX[i] = 0;
                                            for (int check = 0; check < COLUMNAS; check++)
                                            {
                                                if (MATRIZELIMINACION[i, check] == 0)
                                                {
                                                    countX[i] = countX[i] + 1;
                                                }
                                            }
                                        }

                                        while (countX[i] < 4);

                                    }
                                }
                            }

                            while (countX[i] != 4);
                        }
                        for (int i = 0; i < COLUMNAS; i++)
                        {
                            countY[i] = 0;
                            for (int j = 0; j < FILAS; j++)
                            {
                                if (MATRIZELIMINACION[j, i] == 0)
                                {
                                    countY[i]++;
                                }
                            }

                            if (countY[i] < 1)
                            {
                                do
                                {
                                    for (int check = 0; check < FILAS; check++)
                                    {
                                        MATRIZELIMINACION[Random.Next(0, 2), i] = 0;
                                    }
                                    countY[i] = 0;
                                    for (int j = 0; j < FILAS; j++)
                                    {
                                        if (MATRIZELIMINACION[j, i] == 0)
                                        {
                                            countY[i]++;
                                        }
                                    }
                                }
                                while (countY[i] < 1);
                            }
                            if (countY[i] > 2)
                            {
                                do
                                {
                                    for (int check = 0; check < FILAS; check++)
                                    {
                                        MATRIZELIMINACION[Random.Next(0, 2), i] = 1;
                                    }
                                    countY[i] = 0;
                                    for (int j = 0; j < FILAS; j++)
                                    {
                                        if (MATRIZELIMINACION[j, i] == 0)
                                        {
                                            countY[i]++;
                                        }
                                    }
                                }
                                while (countY[i] > 2);
                            }
                        }
                    }
                    while (countX[A] != 4 && (countY[B] < 1 || countY[B] > 2));
                }
            }

            // Eliminar los numeros de la matriz
            for (int X = 0; X < FILAS; X++)
            {
                for (int Y = 0; Y < COLUMNAS; Y++)
                {
                    if (MATRIZELIMINACION[X, Y] == 0)
                    {
                        CARTON[X, Y] = -1;
                    }
                }
            }
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    ACERTADOS[x, y] = false;
                }
            }
        }
        //comprimidor
        public CartonComprimed ToSimple()
        {
            CartonComprimed BingoComprimido = new CartonComprimed();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                    BingoComprimido.Carton.Add(CARTON[i, j]);
                    BingoComprimido.Aciertos.Add(ACERTADOS[i, j]);
                    }
                }
            return BingoComprimido;
        }
        //CHEQUEADOR
        public void Chequeo(int NumeroAChequear)
        {
            int contador = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (CARTON[i, j] == NumeroAChequear)
                        ACERTADOS[i, j] = true;

                    if (ACERTADOS[i, j] == true)
                    {
                        contador++;
                    }
                }
                if (contador == 15)
                {
                    EsGanador = true;
                    break;
                }
                else
                    EsGanador = false;

            }
        }

    }
}
