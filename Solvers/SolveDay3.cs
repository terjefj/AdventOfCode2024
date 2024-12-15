using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;


namespace AdventOfCode.Solvers
{
    public class SolveDay3 : ISolver
    {
        public string SolvePart1(string[] input)
        {
            
            string pattern = @"mul\((\d+),(\d+)\)";

            List<int> xvalues = new List<int>();
            
            
            List<int> yvalues = new List<int>();

            foreach (Match match in Regex.Matches(string.Join("",input), pattern))
            
            {
                xvalues.Add(int.Parse(match.Groups[1].Value));
                yvalues.Add(int.Parse(match.Groups[2].Value));
            }
            











            int sumMultiplication = xvalues.Select((x,i) => x * yvalues[i]).Sum();

            return sumMultiplication.ToString();
           

        }

        

        
        public string SolvePart2(string[] input)
        {
            string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";

            List<int> xvalues = new List<int>();

            bool multiplyEnabled = true;

            List<int> yvalues = new List<int>();
            foreach (Match match in Regex.Matches(string.Join("", input), pattern))

            {
                if (multiplyEnabled)
                {
                    try { 
                    xvalues.Add(int.Parse(match.Groups[1].Value));
                    yvalues.Add(int.Parse(match.Groups[2].Value));
                        }
                    catch 
                    {
                        
                    }
                }
                multiplyEnabled = enableMultiplication(match.Value, multiplyEnabled);

            }

            int sumMultiplication = xvalues.Select((x, i) => x * yvalues[i]).Sum();

            return sumMultiplication.ToString();


        }

        public static bool enableMultiplication(string value, bool multiplyEnabled)
        {
            if (value == "do()") return true;
            else if (value == "don't()") return false;
            else return multiplyEnabled;
        }   
        

        

        
    }
}

