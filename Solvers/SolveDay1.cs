using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers
{
    public class SolveDay1 : ISolver
    {
        public string SolvePart1(string[] input)
        {
            List<int> left = [];
            List<int> right =[];

            foreach (string line in input)
            {
                string[] item = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                left.Add(int.Parse(item[0]));
                right.Add(int.Parse(item[1]));
                            
            }
            left.Sort();
            right.Sort();

            int distance = left.Select((x,i) => Math.Abs(x - right[i])).Sum();
            
            return distance.ToString();
        }
        public string SolvePart2(string[] input)
        {
            List<int> left = [];
            List<int> right = [];

            foreach (string line in input)
            {
                string[] item = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                left.Add(int.Parse(item[0]));
                right.Add(int.Parse(item[1]));

            }
            left.Sort();
            right.Sort();

            int similarity = left.Sum(leftItem => right.Count(rightItem => rightItem  == leftItem) * leftItem);
            return similarity.ToString();
        }
    }
}

