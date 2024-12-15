using System.Collections.Generic;

namespace AdventOfCode.Parsers
{
    public class Parsers
    {
        public static int[] ParseStrToInt(string[] StringList) {

            List<int> intList = [];
            
            foreach (string str in StringList) 
            {
            intList.Add(int.Parse(str));
            }
            return intList.ToArray();
        }
    }
}
