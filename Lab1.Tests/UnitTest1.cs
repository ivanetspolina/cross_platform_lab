using System;
using System.IO;
using System.Text;
using Xunit;

namespace Lab1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void CalculateWays_ValidInput_ReturnsCorrectResult()
        {
            string[] input = { "3" };
            string expected = $"{(int)Math.Pow(3, 3 * (3 - 1) / 2)}\n";

            string result = Program.CalculateWays(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void InputCheck_ValidInput_NoExceptionThrown()
        {
            string[] input = { "2", "5", "10" };

            Exception ex = Record.Exception(() => Program.InputCheck(input));
            Assert.Null(ex); 
        }

        [Fact]
        public void InputCheck_InvalidRange_ThrowsException()
        {
            string[] input = { "1", "101" };

            Assert.Throws<InvalidOperationException>(() => Program.InputCheck(input));
        }

        [Fact]
        public void InputCheck_EmptyString_ThrowsException()
        {
            string[] input = { "" };

            var exception = Assert.Throws<InvalidOperationException>(() => Program.InputCheck(input));
            Assert.Equal("There can be only one value in the string", exception.Message);
        }

        [Fact]
        public void CalculateWays_InvalidNumberFormat_IgnoresInvalidEntries()
        {
            string[] input = { "3", "abc", "10" };
            string expected = $"{(int)Math.Pow(3, 3 * (3 - 1) / 2)}\n{(int)Math.Pow(3, 10 * (10 - 1) / 2)}\n";

            string result = Program.CalculateWays(input);

            Assert.Equal(expected, result);
        }
    }
}
