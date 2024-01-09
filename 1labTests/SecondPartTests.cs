using System;

namespace lab1v6
{
    public class SecondPartTests
    {
        [Fact]
        public void TestFindMatchingRowAndColumn()
        {
            SecondPart part = new SecondPart();
            int[,] matrix = new int[,]
            {
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 2, 1, 4, 3, 6, 5, 8, 7 },
            { 3, 4, 1, 2, 7, 8, 5, 6 },
            { 4, 3, 2, 1, 8, 7, 6, 5 },
            { 5, 6, 7, 8, 1, 2, 3, 4 },
            { 6, 5, 8, 7, 2, 1, 4, 3 },
            { 7, 8, 5, 6, 3, 4, 1, 2 },
            { 8, 7, 6, 5, 4, 3, 2, 1 }
            };

            string output = CaptureConsoleOutput(() => part.FindMatchingRowAndColumn(matrix));

            Assert.Contains("Строка 1 совпадает с столбцом 1", output);
            Assert.Contains("Строка 2 совпадает с столбцом 2", output);
            Assert.Contains("Строка 3 совпадает с столбцом 3", output);
            Assert.Contains("Строка 4 совпадает с столбцом 4", output);
            Assert.Contains("Строка 5 совпадает с столбцом 5", output);
            Assert.Contains("Строка 6 совпадает с столбцом 6", output);
            Assert.Contains("Строка 7 совпадает с столбцом 7", output);
            Assert.Contains("Строка 8 совпадает с столбцом 8", output);
        }

        [Fact]
        public void TestSumRowsWithNegativeElement()
        {

            SecondPart part = new SecondPart();
            // Готовая матрица
            int[,] matrix = new int[,]
            {
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 2, -1, 4, 3, 6, 5, 8, 7 },
            { 3, 4, 1, 2, 7, 8, 5, 6 },
            { 4, 3, 2, 1, 8, 7, 6, 5 },
            { 5, 6, 7, 8, 1, 2, 3, 4 },
            { 6, 5, 8, 7, 2, 1, 4, 3 },
            { 7, 8, 5, 6, 3, 4, 1, 2 },
            { 8, 7, -6, 5, 4, 3, 2, 1 }
            };

            // Получаем результат
            string output = CaptureConsoleOutput(() => part.SumRowsWithNegativeElement(matrix));

            // Сравниваем с тем, что должно получиться
            Assert.Contains("Сумма элементов в строке 2: 34", output);
            Assert.Contains("Сумма элементов в строке 8: 24", output);
        }

        private string CaptureConsoleOutput(Action action)
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            try
            {
                action();
                return consoleOutput.ToString();
            }
            finally
            {
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }
    }

}
