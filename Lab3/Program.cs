using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                string inputFilePath = args.Length > 0 ? args[0] : Path.Combine("Lab3", "INPUT.TXT");
                string outputFilePath = Path.Combine("Lab3", "OUTPUT.TXT");
                string[] value = File.ReadAllLines(inputFilePath);

                InputCheck(value);
                string result= ProcessFriendCount(value);
                File.WriteAllText(outputFilePath, result.Trim());

                Console.WriteLine("File OUTPUT.TXT created");
                Console.WriteLine("Lab #3");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, value).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine('\n');
        }

        public static void InputCheck(string[] values)
        {
            var firstLine = values[0].Split();
            if (firstLine.Length != 2)
                throw new InvalidOperationException("The first line should contain two numbers: N and S.");

            if (!int.TryParse(firstLine[0], out int N) || N < 1 || N > 100)
                throw new InvalidOperationException("N повинно бути цілим числом від 1 до 100.");

            if (!int.TryParse(firstLine[1], out int S) || S < 1 || S > N)
                throw new InvalidOperationException("N must be an integer between 1 and 100.");

            for (int i = 1; i <= N; i++)
            {
                var row = values[i].Split();
                if (row.Length != N)
                    throw new InvalidOperationException($"The string {i} must contain {N} numbers.");

                foreach (var cell in row)
                {
                    if (cell != "0" && cell != "1")
                        throw new InvalidOperationException("The adjacency matrix should contain only 0 and 1.");
                }
            }
        }

        public static string ProcessFriendCount(string[] lines)
        {
            var firstLine = lines[0].Split();
            int N = int.Parse(firstLine[0]);
            int S = int.Parse(firstLine[1]) - 1;

            int[,] friendsMatrix = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var row = lines[i + 1].Split().Select(int.Parse).ToArray();
                for (int j = 0; j < N; j++)
                {
                    friendsMatrix[i, j] = row[j];
                }
            }

            int friendCount = CountFriends(N, S, friendsMatrix);
            return friendCount.ToString();
        }

        public static int CountFriends(int N, int S, int[,] friendsMatrix)
        {
            bool[] visited = new bool[N];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(S);
            visited[S] = true;
            int friendCount = 0;

            while (queue.Count > 0)
            {
                int person = queue.Dequeue();
                friendCount++;

                for (int i = 0; i < N; i++)
                {
                    if (friendsMatrix[person, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            return friendCount - 1;
        }
    }    
}
