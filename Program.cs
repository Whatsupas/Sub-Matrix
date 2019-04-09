using System;
using System.IO;

namespace SubMAtrix
{
    class Program
    {
            static void Main(string[] args)
            {
                string filePath = "text.txt";
                int matrixSize = 0;

                using (StreamReader firstLine = new StreamReader(filePath))
                {
                    matrixSize = int.Parse(firstLine.ReadLine());
                }

                int[,] twoDimArray = MatrixHelper.Create2DArray(filePath, matrixSize);

                Console.WriteLine($"Matrix in {filePath} file:\n ");

                MatrixHelper.printMatrix(twoDimArray);

                int max = int.MinValue;
                int positionIndexI = 0;
                int positionIndexJ = 0;

                for (int i = 0; i < matrixSize - 1; i++)
                {
                    for (int j = 0; j < matrixSize - 1; j++)
                    {
                        if (twoDimArray[i, j] + twoDimArray[i, j + 1]
                                              + twoDimArray[i + 1, j]
                                              + twoDimArray[i + 1, j + 1]
                                              > max)
                        {
                            max = twoDimArray[i, j] + twoDimArray[i, j + 1] + twoDimArray[i + 1, j] + twoDimArray[i + 1, j + 1];
                            positionIndexI = i;
                            positionIndexJ = j;
                        }
                    }

                }

                Console.WriteLine("\nSub matrix 2 x 2\n ");

                MatrixHelper.PrintMatrixWithMax2x2(twoDimArray, positionIndexI, positionIndexJ);

                Console.WriteLine("\nMaximal sum 2x2 : {0}\n", max);
            }
        
    }
}
