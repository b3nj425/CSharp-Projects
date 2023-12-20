//Benjamin Castro Ceballos

const int FILAS = 3; const int COLUMNAS = 9;
int[,] MATRIZ = new int[FILAS, COLUMNAS];
Random Random = new Random();


for (int i = 0; i < FILAS; i++)
{
    for (int j = 0; j < COLUMNAS; j++)
    {
        MATRIZ[i, j] = Random.Next(0, 9) + (10 * j);
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
                if (MATRIZ[i, j] == MATRIZ[pos, j])
                {
                    do
                        MATRIZ[pos, j] = Random.Next(0, 9) + (10 * j);
                    while (MATRIZ[i, j] == MATRIZ[pos, j]);
                }
            }
        }
    }
}
// ordenar de mayor a menor
int AUX;
for (int j = 0; j < COLUMNAS - 1; j++)
{
    for (int i = 0; i < FILAS; i++)
    {
        for (int pos = i + 1; pos < 3; pos++)
        {
            if (MATRIZ[i, j] > MATRIZ[pos, j])
            {
                AUX = MATRIZ[i, j];
                MATRIZ[i, j] = MATRIZ[pos, j];
                MATRIZ[pos, j] = AUX;
            }
        }
    }
}

int[,] MATRIZELIMINACION = new int[FILAS, COLUMNAS];

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

// mostrar el cartón
Console.WriteLine("Su cartón del bingo Es:");

Console.WriteLine("-----------------------------------------------------------------------------------");
for (int i = 0; i < FILAS; i++)
{
    Console.WriteLine(" ");
    for (int j = 0; j < COLUMNAS; j++)
    {
        if (MATRIZELIMINACION[i, j] == 0)
        {
            Console.Write(" |--| ");
        }
        else
        {
            if (MATRIZ[i, j] < 10)
                Console.Write($" |0{MATRIZ[i, j]}| ");
            else
                Console.Write($" |{MATRIZ[i, j]}| ");
        }

    }
}
Console.WriteLine();
Console.WriteLine("------------------------------------------------------------------------------------");