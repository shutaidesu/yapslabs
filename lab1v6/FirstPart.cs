using System;

namespace lab1v6
{
    public class FirstPart
    {

        public int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-10, 11);
            }

            return array;
        }

        public void PrintArray(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        public int FindMaxIndex(int[] arr)
        {
            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public int CalculateProductBetweenZeros(int[] arr, int firstZeroIndex, int secondZeroIndex)
        {
            int product = 1;
            for (int i = firstZeroIndex + 1; i < secondZeroIndex; i++)
            {
                product *= arr[i];
            }
            return product;
        }

        public int[] TransformArray(int[] arr)
        {
            int[] transformedArray = new int[arr.Length];
            int index = 0;

            // Элементы, стоявшие в нечетных позициях
            for (int i = 1; i < arr.Length; i += 2)
            {
                transformedArray[index] = arr[i];
                index++;
            }

            // Элементы, стоявшие на четных позициях
            for (int i = 0; i < arr.Length; i += 2)
            {
                transformedArray[index] = arr[i];
                index++;
            }

            return transformedArray;
        }
    }
}
