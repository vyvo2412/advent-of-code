namespace AdventOfCode._2024.Day7
{
    public class Part1
    {
        public List<(long, List<int>)> _calibrations = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            long total = 0;

            foreach (var c in _calibrations)
            {
                if (FindMatch(c.Item1, c.Item2))
                {
                    total += c.Item1;
                }
            }
            Console.WriteLine(total);
        }

        private bool FindMatch(long target, List<int> inputs)
        {
            List<char[]> operatorCombinations = GenerateOperatorCombinations(inputs.Count - 1);

            foreach (var operators in operatorCombinations)
            {
                if (EvaluateExpression(inputs, operators) == target)
                {
                    return true;
                }
            }

            return false;
        }

        private List<char[]> GenerateOperatorCombinations(int count)
        {
            List<char[]> combinations = [];
            int totalCombinations = (int)Math.Pow(2, count); // 2^count combinations of + and *

            for (int i = 0; i < totalCombinations; i++)
            {
                char[] combination = new char[count];

                for (int j = 0; j < count; j++)
                {
                    combination[j] = (i & (1 << j)) != 0 ? '+' : '*';
                }

                combinations.Add(combination);
            }

            return combinations;
        }

        private long EvaluateExpression(List<int> numbers, char[] operators)
        {
            long result = numbers[0];

            for (int i = 0; i < operators.Length; i++)
            {
                if (operators[i] == '+')
                {
                    result += numbers[i + 1];
                }
                else if (operators[i] == '*')
                {
                    result *= numbers[i + 1];
                }
            }

            return result;
        }

        private void ParseInput(string fileLocation)
        {
            var orders = new List<List<int>>();

            foreach (string line in File.ReadLines(fileLocation))
            {
                var result = line.Split(":");
                var numbers = result[1].Trim().Split(" ").Select(int.Parse).ToList();
                _calibrations.Add((long.Parse(result[0]), numbers));
            }
        }
    }
}
