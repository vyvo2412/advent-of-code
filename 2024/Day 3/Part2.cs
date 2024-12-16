using System.Text.RegularExpressions;

namespace AdventOfCode._2024.Day3
{
    public class Part2
    {
        public void Process(string fileLocation)
        {
            var total = 0;
            var textInput = File.ReadLines(fileLocation).First();
            // var textInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
            string pattern = @"do\(\)|don't\(\)|mul\((\d+),(\d+)\)";

            bool enabled = true;

            MatchCollection matches = Regex.Matches(textInput, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);

                if (match.Value == "do()")
                {
                    enabled = true;  
                }
                else if (match.Value == "don't()")
                {
                    enabled = false;  
                }
                else if (match.Value.StartsWith("mul"))
                {
                    if (enabled)
                    {
                        int x = int.Parse(match.Groups[1].Value);
                        int y = int.Parse(match.Groups[2].Value);

                        total += x * y;
                    }
                }
            }

            Console.WriteLine(total);
        }
    }
}
