using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day3
{
    public class Part1
    {
        public void Process(string fileLocation) 
        {
            var total = 0;
            var textInput = File.ReadLines(fileLocation).First();
            string pattern = @"mul\(\s*(-?\d+)\s*,\s*(-?\d+)\s*\)";

            MatchCollection matches = Regex.Matches(textInput, pattern);

            foreach (Match match in matches)
            {
                int firstNumber = int.Parse(match.Groups[1].Value);
                int secondNumber = int.Parse(match.Groups[2].Value);
                total += firstNumber * secondNumber;
            }

            Console.WriteLine(total);
        }
    }
}
