namespace lab1v6
{
    internal class Program
    {
        static void Main()
        {
            FirstPart firstPart = new FirstPart();
            Console.Write("Введите размер массива N: ");
            int N = int.Parse(Console.ReadLine());

            int[] array = firstPart.GenerateRandomArray(N);

            Console.WriteLine("Сгенерированный массив:");
            firstPart.PrintArray(array);

            int maxIndex = firstPart.FindMaxIndex(array);
            Console.WriteLine($"Номер максимального элемента: {maxIndex + 1}");

            int firstZeroIndex = Array.IndexOf(array, 0);
            int secondZeroIndex = Array.IndexOf(array, 0, firstZeroIndex + 1);

            if (firstZeroIndex == -1 || secondZeroIndex == -1)
            {
                Console.WriteLine("В массиве не хватает нулевых элементов для вычисления произведения.");
            }
            else
            {
                int product = firstPart.CalculateProductBetweenZeros(array, firstZeroIndex, secondZeroIndex);
                Console.WriteLine($"Произведение элементов между первым и вторым нулевыми элементами: {product}");
            }

            int[] transformedArray = firstPart.TransformArray(array);
            Console.WriteLine("Преобразованный массив:");
            firstPart.PrintArray(transformedArray);

            // ========================================== 2 часть =========================================

            SecondPart secondPart = new SecondPart();

            int[,] matrix = secondPart.GenerateMatrix(8, 8);

            Console.WriteLine("Исходная матрица:");
            secondPart.PrintMatrix(matrix);

            secondPart.FindMatchingRowAndColumn(matrix);
            secondPart.SumRowsWithNegativeElement(matrix);
        }
    }
}