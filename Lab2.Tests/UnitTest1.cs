using System;
using System.Collections.Generic;
using Xunit;

namespace Lab2.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("4", "1 2 9 4", 16, new int[] { 1, 2, 3, 4 })]

        public void CalculateMaxSumAndPathIndices_ValidInput_ReturnsExpectedResult(
            string n, string steps, int expectedSum, int[] expectedPath)
        {
            string[] values = { n, steps };

            var (maxSum, pathIndices) = Program.CalculateMaxSumAndPathIndices(values);

            Assert.Equal(expectedSum, maxSum);
            Assert.Equal(expectedPath, pathIndices);
        }

        [Fact]
        public void CalculateMaxSumAndPathIndices_SingleStep_ReturnsStepValue()
        {
            string[] values = { "1", "7" };
            int expectedSum = 7;
            var expectedPath = new List<int> { 1 };

            var (maxSum, pathIndices) = Program.CalculateMaxSumAndPathIndices(values);

            Assert.Equal(expectedSum, maxSum);
            Assert.Equal(expectedPath, pathIndices);
        }

        [Fact]
        public void InputCheck_InvalidN_ThrowsException()
        {
            string[] values = { "1001", "1 2 3" };

            Assert.Throws<InvalidOperationException>(() => Program.InputCheck(values));
        }

        [Fact]
        public void InputCheck_StepCountMismatch_ThrowsException()
        {
            string[] values = { "3", "1 2" };

            Assert.Throws<InvalidOperationException>(() => Program.InputCheck(values));
        }

        [Fact]
        public void FormatOptimalPath_ReturnsFormattedOutput()
        {
            int maxSum = 15;
            List<int> pathIndices = new List<int> { 1, 3, 5 };
            string expectedOutput = "15\n1 3 5\n";

            string result = Program.FormatOptimalPath(maxSum, pathIndices);

            Assert.Equal(expectedOutput, result);
        }
    }
}
