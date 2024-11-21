using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Lab5.Controllers
{
    public class LabController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public LabController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult GetLab1()
        {
            var model = new LabViewModel
            {
                TaskNumber = "1",
                TaskVariant = "4",
                TaskDescription = "У відомому місті Кизилорда, де знаходяться N центрів, мешкає якийсь граф - Азамат. Він бажає дізнатися кількість різних \r\n" +
                "будівель доріг між ними, якщо відомо, що два центри можуть бути пов'язані в одному з двох\r\nнапрямків або не пов'язані взагалі. Наприклад, при N=2 все виходить 3 варіанти: \r\n" +
                "обидва центри не пов'язані\r\nдорога йде з першого до другого центру\r\nдорога йде з другого до першого центру",
                InputDescription = "У вхідному файлі INPUT.TXT записано єдине натуральне число - кількість центрів у місті, 2 ≤ N ≤ 100.",
                OutputDescription = "У єдиний рядок вихідного файлу OUTPUT.TXT необхідно вивести число різних будівель доріг.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "2", Output = "3" },
                new TestCase { Input = "4", Output = "729" }
            }
            };
            return View(model);
        }

        public IActionResult GetLab2()
        {
            var model = new LabViewModel
            {
                TaskNumber = "2",
                TaskVariant = "4",
                TaskDescription = "Вова стоїть перед драбинкою з N ступенів. На кожному з щаблів написані довільні цілі числа. Першим кроком Вова може\r\n " +
                "перейти на перший щабель або, перестрибнувши через перший, відразу опинитися на другому. Також він надходить і далі, поки не досягне " +
                "N-го ступеня. Порахуємо суму всіх чисел, написаних на сходах, через які пройшов Вова.\r\nПотрібно написати програму, яка визначить оптимальний " +
                "маршрут Вови, за якого, крокуючи, він отримає найбільшу суму.",
                InputDescription = "Вхідний файл INPUT.TXT містить у першому рядку натуральне число N – кількість ступенів сходів (2 ≤ N ≤ 1000). У другому рядку\r\n" +
                "через пропуск задані числа, написані на сходах, починаючи з першої. Числа, написані на сходах, не перевищують модуля 1000.",
                OutputDescription = "Вихідний файл OUTPUT.TXT повинен містити у першому рядку найбільше значення суми. У другому рядку повинні бути записані через\r\n" +
                "пропуск номера щаблів за зростанням, по яких повинен крокувати Вова. Якщо є кілька різних правильних маршрутів, можна вивести будь-який з них.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "3\n1 2 1", Output = "4\n1 2 3" },
                new TestCase { Input = "3\n1 -1 1", Output = "2\n1 3" }
            }
            };
            return View(model);
        }

        public IActionResult GetLab3()
        {
            var model = new LabViewModel
            {
                TaskNumber = "3",
                TaskVariant = "4",
                TaskDescription = "У клубі N людина. Багато з них – друзі. Також відомо, що друзі друзів так само є друзями. Потрібно з'ясувати, скільки всього друзів у конкретної людини у клубі.",
                InputDescription = "У першому рядку вхідного файлу INPUT.TXT задані два числа: N і S (1 ≤ N ≤ 100; 1 ≤ S ≤ N), де N – кількість осіб у клубі,\r\n" +
                "а S – номер конкретної людини. У наступних N рядках записано N чисел - матриця суміжності, що складається з одиниць і нулів. Причому одиниця,\r\n" +
                "що стоїть у i-му рядку та j-му стовпчику гарантує, що люди з номерами i та j – друзі, а 0 – висловлює невизначеність.",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть кількість гарантованих друзів у людини з номером S, пам'ятаючи транзитивність дружби.",
                TestCases = new List<TestCase>
            {
                new TestCase
                {
                    Input = "3 1\n0 1 0\n1 0 1\n0 1 0",
                    Output = "2"
                }
            }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessLab(int labNumber, IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
                return BadRequest("Please upload a file");

            string[] lines;
            using (var reader = new StreamReader(inputFile.OpenReadStream()))
            {
                lines = (await reader.ReadToEndAsync()).Split(Environment.NewLine);
            }

            string output;

            try
            {
                switch (labNumber)
                {
                    case 1:
                        Lab1.Program.InputCheck(lines);
                        output = Lab1.Program.CalculateWays(lines);
                        break;
                    case 2:
                        output = Lab2.Program.ProcessSingleDataSet(lines);
                        break;
                    case 3:
                        Lab3.Program.InputCheck(lines);
                        output = Lab3.Program.ProcessFriendCount(lines);
                        break;
                    default:
                        return BadRequest("Invalid lab number");
                }
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Input validation failed: {ex.Message}");
            }

            var result = new { output = output };
            return Json(result);
        }
    }
}
