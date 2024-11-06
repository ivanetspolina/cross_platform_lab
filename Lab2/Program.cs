using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                string inputFilePath = args.Length > 0 ? args[0] : Path.Combine("Lab2", "INPUT.TXT");
                string outputFilePath = Path.Combine("Lab2", "OUTPUT.TXT");
                string[] value = File.ReadAllLines(inputFilePath);
                string result = ProcessMultipleDataSets(value);

                File.WriteAllText(outputFilePath, result.Trim() + "\n");

                Console.WriteLine("File OUTPUT.TXT created");
                Console.WriteLine("Lab #2");
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

        public static string ProcessMultipleDataSets(string[] values)
        {
            var results = new List<string>();

            for (int i = 0; i < values.Length; i += 2)
            {
                if (i + 1 < values.Length)
                {
                    var dataSet = new string[] { values[i], values[i + 1] };
                    results.Add(ProcessSingleDataSet(dataSet));
                }
            }

            return string.Join("\n\n", results); 
        }

        public static string ProcessSingleDataSet(string[] values)
        {
            InputCheck(values);
            return CalculateBestRoute(values);
        }

        public static void InputCheck(string[] values)
        {
            if (values.Length < 2)
            {
                throw new InvalidOperationException("Input data is incomplete.");
            }

            if (!int.TryParse(values[0], out int N) || N < 2 || N > 1000)
            {
                throw new InvalidOperationException("Invalid value for N; it must be between 2 and 1000.");
            }

            string[] steps = values[1].Split();
            if (steps.Length != N)
            {
                throw new InvalidOperationException("Number of steps does not match N.");
            }

            foreach (string step in steps)
            {
                if (!int.TryParse(step, out _))
                {
                    throw new InvalidOperationException("Each step must contain a valid integer value.");
                }
            }
        }

        public static (int, List<int>) CalculateMaxSumAndPathIndices(string[] values)
        {
            int N = int.Parse(values[0]);
            int[] steps = values[1].Split().Select(int.Parse).ToArray();

            if (N == 1)
                return (steps[0], new List<int> { 1 });

            int[] dp = new int[N];
            int[] path = new int[N];

            dp[0] = steps[0];
            dp[1] = Math.Max(steps[1], dp[0] + steps[1]);
            path[0] = 0; 
            path[1] = dp[1] == steps[1] ? 1 : 0;

            for (int i = 2; i < N; i++)
            {
                if (dp[i - 1] + steps[i] > dp[i - 2] + steps[i])
                {
                    dp[i] = dp[i - 1] + steps[i];
                    path[i] = i - 1;
                }
                else
                {
                    dp[i] = dp[i - 2] + steps[i];
                    path[i] = i - 2;
                }
            }

            int lastIndex = N - 1;
            if (dp[N - 2] > dp[N - 1])
            {
                lastIndex = N - 2;
            }

            int maxSum = dp[lastIndex];
            List<int> pathIndices = new List<int>();
            for (int i = lastIndex; i >= 0; i = path[i])
            {
                pathIndices.Add(i + 1); 
                if (i == path[i]) break; 
            }

            pathIndices.Reverse();
            return (maxSum, pathIndices);
        }


        public static string FormatOptimalPath(int maxSum, List<int> pathIndices)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(maxSum.ToString());
            result.AppendLine(string.Join(" ", pathIndices));
            return result.ToString().Replace("\r\n", "\n");
        }

        public static string CalculateBestRoute(string[] values)
        {
            var (maxSum, pathIndices) = CalculateMaxSumAndPathIndices(values);
            return FormatOptimalPath(maxSum, pathIndices);
        }
    }
}