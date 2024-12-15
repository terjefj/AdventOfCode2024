using System;


namespace AdventOfCode.Solvers
{
    public class SolveDay4 : ISolver
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
                    xMasCount += xmasCount(i, j);
                }
            }
            return xMasCount.ToString();

            int xmasCount(int i, int j)
            {

                int count = 0;
                if (input[i][j] != 'X') return 0;

                //up check
                if (i - 3 >= 0 && input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S') count++;
                //diagonal up right check
                if (i - 3 >= 0 && j + 3 < cols && input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S') count++;
                // right check
                if (j + 3 < cols && input[i][j + 1] == 'M' && input[i][j + 2] == 'A' && input[i][j + 3] == 'S') count++;
                // diagnal down right check
                if (i + 3 < rows && j + 3 < cols && input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S') count++;
                //down check
                if (i + 3 < rows && input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S') count++;
                // diagnal down left check
                if (i + 3 < rows && j - 3 >= 0 && input[i + 1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S') count++;
                // left check
                if (j - 3 >= 0 && input[i][j - 1] == 'M' && input[i][j - 2] == 'A' && input[i][j - 3] == 'S') count++;
                // diagnal up left check
                if (i - 3 >= 0 && j - 3 >= 0 && input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S') count++;

                return count;

            }

        }
        public string SolvePart2(string[] input)
        {

            int rows = input.Length;
            int cols = input[0].Length;
            int xMasCount = 0;

            // no need to loop over first,last in rows and cols
            for (int i = 1; i < rows-1 ; i++)
            {
                for (int j = 1; j < cols-1; j++)
                {
                    //xMasCount += xmasCount(i, j);
                    if (i == 1 && j == 1) printMtrix(i,j);
                    if (i == 1 && j == cols-2) printMtrix(i, j);
                    if (i == rows-2  && j == 1) printMtrix(i, j);
                    if (i == rows-2 && j == cols-2) printMtrix(i, j);

                    xMasCount += xmasCount(i, j);

                }
            }
            return xMasCount.ToString();

            int xmasCount(int i, int j)
            {

                
                bool slash = false;
                bool backSlash = false;

                if (input[i][j] == 'A')
                {
                    
                    // Checks{                                                  | Checks{                                                           |
                    //                          **M                             |                            **S                                    |
                    //                          *A*                             |                            *A.                                    |
                    //                          S**                           } |                            M**                                    | 
                    slash = (input[i - 1][j + 1] == 'M' && input[i + 1][j - 1] == 'S') || (input[i - 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M');
                    // Checks{                                                  | Checks{                                                           |
                    //                          M**                             |                            S**                                    |
                    //                          *A*                            |                             *A*                                    |
                    //                          **S                           } |                            **M                                    | 
                    backSlash = (input[i - 1][j - 1] == 'M' && input[i + 1][j + 1] == 'S') || (input[i - 1][j - 1] == 'S' && input[i + 1][j + 1] == 'M');



                }
                
                if (slash && backSlash)

                {
                    printMtrix(i, j);
                    return 1;
                   

                }
                else return 0;

                

            }
            void printMtrix(int i, int j)
            {
                Console.WriteLine("___");
                Console.WriteLine("|" + input[i - 1][j - 1].ToString() + input[i - 1][j].ToString() + input[i - 1][j + 1].ToString() + "|");
                Console.WriteLine("|" + input[i][j - 1].ToString() + input[i][j].ToString() + input[i][j + 1].ToString() + "|");
                Console.WriteLine("|" + input[i + 1][j - 1].ToString() + input[i + 1][j].ToString() + input[i + 1][j + 1].ToString() + "|");
                Console.WriteLine("___");
            }


        }
    }






}
