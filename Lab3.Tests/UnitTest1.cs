using System;
using System.IO;
using Xunit;

namespace Lab3.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void InputCheck_ValidData_NoExceptionThrown()
        {
            string[] validInput = {
                "3 1",
                "0 1 0",
                "1 0 1",
                "0 1 0"
            };

            Exception ex = Record.Exception(() => Program.InputCheck(validInput));
            Assert.Null(ex); 
        }

        [Fact]
        public void InputCheck_InvalidMatrix_ThrowsException()
        {
            string[] invalidInput = {
                "3 1",
                "0 1 0",
                "1 0", 
                "0 1 0"
            };

            Assert.Throws<InvalidOperationException>(() => Program.InputCheck(invalidInput));
        }

        [Fact]
        public void ProcessFriendCount_SimpleCase_ReturnsCorrectCount()
        {
            string[] input = {
                "3 1",
                "0 1 0",
                "1 0 1",
                "0 1 0"
            };

            string result = Program.ProcessFriendCount(input);

            Assert.Equal("2", result); 
        }

        [Fact]
        public void CountFriends_ComplexCase_ReturnsCorrectCount()
        {
            int[,] friendsMatrix = {
                { 0, 1, 0, 0, 1 },
                { 1, 0, 1, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 0 }
            };
            int N = 5;
            int S = 0; 

            int friendCount = Program.CountFriends(N, S, friendsMatrix);

            Assert.Equal(4, friendCount); 
        }

        [Fact]
        public void ProcessFriendCount_IsolatedPerson_ReturnsOne()
        {
            string[] input = {
                "4 2",
                "0 0 0 0",
                "0 0 0 0",
                "0 0 0 1",
                "0 0 1 0"
            };

            string result = Program.ProcessFriendCount(input);

            Assert.Equal("0", result); 
        }
    }
}
