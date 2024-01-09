using System;

namespace lab1v6
{
    public class FirstPartTests
    {
        [Fact]
        public void TestFindMaxIndex()
        {
            FirstPart firstPart = new FirstPart();
            int[] array = { 3, -5, 8, 0, 2 };

            int result = firstPart.FindMaxIndex(array);

            Assert.Equal(2, result);
        }

        [Fact]
        public void TestCalculateProductBetweenZeros()
        {
            FirstPart firstPart = new FirstPart();
            int[] array = { 1, 2, 3, 0, 4, 5, 0, 6, 7 };

            int result = firstPart.CalculateProductBetweenZeros(array, 3, 6);

            Assert.Equal(20, result);
        }

        [Fact]
        public void TestTransformArray()
        {
            FirstPart firstPart = new FirstPart();
            int[] array = { 1, 2, 3, 4, 5, 6 };

            int[] result = firstPart.TransformArray(array);

            int[] expected = { 2, 4, 6, 1, 3, 5 };
            Assert.Equal(expected, result);
        }
    }
}
