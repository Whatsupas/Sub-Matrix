using System;
using System.IO;

namespace SubMAtrix
{
    public class MatrixHelper
    {
        internal static int[,] Create2DArray(string textPath, int matrixSize)
        {
            int[,] twoDimArray = new int[matrixSize, matrixSize];

            using (StreamReader reading = new StreamReader(textPath))
            {
                while (!reading.EndOfStream)
                {
                    string line = reading.ReadLine();

                    if (line.Length > 3) // working with matrix until 99x99
                    {
                        for (int i = 0; i < matrixSize; i++)
                        {
                            for (int j = 0; j < matrixSize; j++)
                            {
                                twoDimArray[i, j] = int.Parse(line.Split(' ')[j]);
                            }
                            line = reading.ReadLine();
                        }
                    }
                }
                return twoDimArray;
            }

        }
        public static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        internal static void PrintMatrixWithMax2x2(int[,] twoDimArray, int positionIndexI, int positionIndexJ)
        {
            int matrixSize = twoDimArray.GetLength(0);
            int count = 0;
            int indexInPrintSequence = positionIndexI * matrixSize + positionIndexJ;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (count == indexInPrintSequence || count == indexInPrintSequence + 1 ||
                        count == indexInPrintSequence + matrixSize || count == indexInPrintSequence + matrixSize + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(twoDimArray[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(twoDimArray[i, j] + " ");
                    }
                    count++;
                }
                Console.WriteLine();
            }
        }
    }
}
