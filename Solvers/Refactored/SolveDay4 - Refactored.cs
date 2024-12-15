using System;
using System.Collections.Generic;
using System.Linq;


namespace AdventOfCode.Solvers
{   //to slow with the try catch use to save me from  writing checks for matrix boundaries
    public class SolveDay4_refactored : ISolver
    {
        public string SolvePart1(string[] input)
        {

            int rows = input.Length;
            int cols = input[0].Length;
            int xMasCount = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    xMasCount += xmasCount(i, j, input);
                }
            }
            return xMasCount.ToString();
        }




        public string SolvePart2(string[] input)
        {
            return "";
        }
        public static int xmasCount(int i, int j, string[] input)
        {
            List<string> strings = new List<string>();
            char test = input[i][j];
            string up = "";
            string upLeft = "";
            string left = "";
            string downLeft = "";
            string down = "";
            string downRight = "";
            string right = "";
            string rightUp = "";

            if (!("X".Equals(input[i][j].ToString()))) return 0;


            for (int k = 1; k < 4; k++)
            {
                //up
                try
                {
                    string addstring = input[i - k][j].ToString();
                    up += addstring;
                }
                catch
                {
                
                }

                //upLeft
                try
                {
                    string addstring = input[i - k][j + k].ToString();
                    upLeft += addstring;
                }
                catch
                {
                }

                //Left
                try
                {
                    string addstring = input[i][j + k].ToString();
                    left += addstring;
                }
                catch
                {
                }

                //downLeft
                try
                {
                    string addstring = input[i + k][j + k].ToString();
                    downLeft += addstring;
                }
                catch
                {

                }

                //down
                try
                {
                    string addstring = input[i + k][j].ToString();
                    down += addstring;
                }
                catch
                {

                }
                //downRight
                try
                {
                    string addstring = input[i + k][j-k].ToString();
                    downRight += addstring;
                }
                catch
                {

                }
                //right
                try
                {
                    string addstring = input[i][j - k].ToString();
                    right += addstring;
                }
                catch
                {

                }
                //rightup
                try
                {
                    string addstring = input[i - k][j - k].ToString();
                    rightUp += addstring;
                }
                catch
                {
                

                }

               

            }
            strings.Add(up);
            strings.Add(upLeft);
            strings.Add(left);
            strings.Add(downLeft);
            strings.Add(down);
            strings.Add(downRight);
            strings.Add(right);
            strings.Add(rightUp);
            int result = strings.Count(x => x == "MAS");
            return result;

        }
    }
}