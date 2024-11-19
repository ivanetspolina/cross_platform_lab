using Lab4Lib;
using McMaster.Extensions.CommandLineUtils;
using System.Runtime.InteropServices;

namespace Lab4
{
    [Command(Name = "Lab4", Description = "Console application for 1-4 labs")]
    [Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }

        private void OnExecute()
        {
            Console.WriteLine("Incorrect command.");
        }

        private void OnUnknownCommand(CommandLineApplication app)
        {
            Console.WriteLine("Command list:");
            Console.WriteLine(" version: Displays app info\n");
            Console.WriteLine(" run: Run the selected lab");
            Console.WriteLine("        Example: Lab4 run lab2 --input=input.txt --output=output.txt");
            Console.WriteLine("                 Lab4 run lab1 -i input.txt -o output.txt\n");
            Console.WriteLine(" set-path: Set the path to input, output file");
            Console.WriteLine("        Example: Lab4 set-path -p /path/to/folder\n");
        }

        [Command(Name = "version", Description = "Displays app info")]
        class VersionCommand
        {
            private void OnExecute()
            {
                Console.WriteLine("Author: Ivanets Polina");
                Console.WriteLine("Version: 1.0.0");
            }
        }

        [Command(Name = "run", Description = "Run a specific lab")]
        class RunCommand
        {
            [Argument(0, "lab", "Lab for run (lab1, lab2, lab3)")]
            public string Lab { get; set; }

            [Option("-i|--input", "INPUT file", CommandOptionType.SingleValue)]
            public string InputFile { get; set; }

            [Option("-o|--output", "OUTPUT file", CommandOptionType.SingleValue)]
            public string OutputFile { get; set; }

            private int OnExecute()
            {
                Console.WriteLine(Environment.GetEnvironmentVariable("LAB_PATH"));
                string inputPath = InputFile ?? Environment.GetEnvironmentVariable("LAB_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                string outputPath = OutputFile ?? Environment.GetEnvironmentVariable("LAB_PATH") ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                inputPath = Path.Combine(inputPath, "INPUT.txt");
                outputPath = Path.Combine(outputPath, "OUTPUT.txt");
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"File {inputPath} not found.");
                    return 1;
                }

                switch (Lab?.ToLower())
                {
                    case "lab1":
                        LLab1.Lab1Run(inputPath, outputPath);
                        break;
                    case "lab2":
                        LLab2.Lab2Run(inputPath, outputPath);
                        break;
                    case "lab3":
                        LLab3.Lab3Run(inputPath, outputPath);
                        break;
                    default:
                        Console.WriteLine("Error. Enter: lab1 or lab2 or lab3.");
                        return 1;
                }

                Console.WriteLine($"Complete. Result in {outputPath} file");
                return 0;
            }
        }

        [Command(Name = "set-path", Description = "Set input/output path")]
        class SetPathCommand
        {
            [Option("-p|--path", "Folder path", CommandOptionType.SingleValue)]
            public string Path { get; set; }

            private int OnExecute()
            {
                if (string.IsNullOrEmpty(Path))
                {
                    Console.WriteLine("No path specified.");
                    return 1;
                }

                try
                {
                    SetEnvironmentVariable("LAB_PATH", Path);
                    Console.WriteLine($"The LAB_PATH variable is set to: {Path}");
                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to set environment variable: {ex.Message}");
                    return 1;
                }
            }

            private void SetEnvironmentVariable(string variable, string value)
            {
                if (OperatingSystem.IsWindows())
                {
                    Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.Machine);
                }
                else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
                {
                    string profilePath = OperatingSystem.IsLinux() ? "/etc/environment" : "/etc/paths";

                    if (File.Exists(profilePath))
                    {
                        using (StreamWriter sw = File.AppendText(profilePath))
                        {
                            sw.WriteLine($"{variable}={value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The system file for environment variables was not found.");
                        throw new InvalidOperationException("Failed to set environment variable.");
                    }
                }
            }
        }
    }
}
