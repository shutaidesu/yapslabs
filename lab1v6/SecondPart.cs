using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1v6
{
    public class SecondPart
    {
        public int[,] GenerateMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(-10, 11);
                }
            }

            return matrix;
        }

        public void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void FindMatchingRowAndColumn(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            Console.WriteLine("Строки, совпадающие с соответствующими столбцами:");

            for (int k = 0; k < rows; k++)
            {
                bool matchFound = true;

                for (int i = 0; i < columns; i++)
                {
                    if (matrix[k, i] != matrix[i, k])
                    {
                        matchFound = false;
                        break;
                    }
                }

                if (matchFound)
                {
                    Console.WriteLine($"Строка {k + 1} совпадает с столбцом {k + 1}");
                }
            }

            Console.WriteLine();
        }

        public void SumRowsWithNegativeElement(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int sum = 0;

            Console.WriteLine("Сумма элементов в строках с хотя бы одним отрицательным элементом:");

            for (int i = 0; i < rows; i++)
            {
                bool hasNegativeElement = false;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegativeElement = true;
                        break;
                    }
                }

                if (hasNegativeElement)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        sum += matrix[i, j];
                    }

                    Console.WriteLine($"Сумма элементов в строке {i + 1}: {sum}");
                    sum = 0;
                }
            }

            Console.WriteLine();
        }
    }

}
