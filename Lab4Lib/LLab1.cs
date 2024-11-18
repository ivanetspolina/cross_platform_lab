using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Lib
{
    public class LLab1
    {
        public static void Lab1Run(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                string[] value = File.ReadAllLines(inputFile);

                InputCheck(value);
                string result = CalculateWays(value);
                File.WriteAllText(outputFile, result.Trim());

                Console.WriteLine("File OUTPUT.TXT created");
                Console.WriteLine("Lab #1");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, value).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        public static void InputCheck(string[] values)
        {
            foreach (string value in values)
            {
                if (string.IsNullOrWhiteSpace(value) || value.Contains(" "))
                {
                    throw new InvalidOperationException("There can be only one value in the string");
                }

                if (!int.TryParse(value.Trim(), out int N) || N < 2 || N > 100)
                {
                    throw new InvalidOperationException($"'{value}' - value must be between 2 and 100");
                }
            }
        }

        public static string CalculateWays(string[] values)
        {
            StringBuilder result = new StringBuilder();
            foreach (string value in values)
            {
                if (int.TryParse(value.Trim(), out int N) && N >= 2 && N <= 100)
                {
                    int waysNumb = (int)Math.Pow(3, N * (N - 1) / 2); ;
                    result.AppendLine(waysNumb.ToString());
                }
            }
            return result.ToString().Replace("\r\n", "\n");
        }

    }
}
