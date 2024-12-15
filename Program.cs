using AdventOfCode.Solvers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;




namespace AdventOfCode
{
    internal class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            // Input folderpath to where you have Stored the Day[x].txt files
            string inputFolder = $@"C:\Users\Terfje\source\repos\AdventOfCode2024\Input\";

            
            
            
            Console.WriteLine("What day do you want to solve? 1 to 24");
            string day = Console.ReadLine();
            Console.WriteLine("What part do you want to solve? 1 or 2");
            string part = Console.ReadLine();

            string inputFile = @$"Day{day}.txt";
            string inputPath = inputFolder + inputFile;


            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file for Day {day} not found.");
                return;
            }
            IEnumerable<ISolver> solvers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ISolver).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (ISolver)Activator.CreateInstance(t));

            string[] input = File.ReadAllLines(inputPath);
            string result = Runsolver(solvers, day, part, input);
            Console.WriteLine($"The Answer is {result} and it has been copied to you clipboard");
            
            Clipboard.SetText(result);

        }

        public static string Runsolver(IEnumerable<ISolver> solvers, string day, string part, string[] input)
        {
            ISolver solver = solvers.FirstOrDefault(s => s.GetType().Name == $"SolveDay{day}");

            if (solver == null)
            {
                return $"Solver for Day {day} not found.";
            }

            return part == "1" ? solver.SolvePart1(input) : solver.SolvePart2(input);
        }
    }
}
