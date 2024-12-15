using System;
using System.Collections.Generic;
using System.Linq;


namespace AdventOfCode.Solvers
{
    public class SolveDay2 : ISolver
    {
        public string SolvePart1(string[] input)
        {
            List<int[]> levels = [];
            

            foreach (string line in input)
            {
                string[] item = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                levels.Add(Parsers.Parsers.ParseStrToInt(item));
                
                            
            }

           

            var safelevels = levels.Count(level => SafeLevels(level.ToList()) == true);
            return safelevels.ToString();
            
                
        }

        

        
        public string SolvePart2(string[] input)
        {
            List<int[]> levels = [];
            

            foreach (string line in input)
            {
                string[] item = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                levels.Add(Parsers.Parsers.ParseStrToInt(item));


            }



            var safelevels = levels.Count(level => SafeWithProblemDampener(level.ToList()) == true);
            return safelevels.ToString();
            

        }
        public static bool SafeLevels(List<int> levels)
        {
            bool? isIncreasing = null;

            for (int i = 1; i < levels.Count(); i++)
            {
                int stepSize = levels[i] - levels[i - 1];
                int absStepSize = Math.Abs(levels[i] - levels[i - 1]);

                if (absStepSize > 3 || absStepSize < 1) return false;

                if (stepSize > 0)
                {
                    isIncreasing ??= true;
                    if (!isIncreasing.Value) return false;
                }
                else
                {
                    isIncreasing ??= false;
                    if (isIncreasing.Value) return false;
                }
            }

            return true;

        
        }

        public static bool SafeWithProblemDampener(List<int> levels)
        {   
            bool unSafelevel = false;
            int index = 0;
            while (!unSafelevel)
            {
                
                List<int> copy = new List<int>(levels);

                if (index>= copy.Count()) return false;

                copy.RemoveAt(index);
                unSafelevel = SafeLevels(copy);
                index += 1;
            }
            return unSafelevel;    
        }

        
    }
}

