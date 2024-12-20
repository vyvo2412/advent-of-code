





namespace AdventOfCode._2024.Day19
{
    public class Part2
    {
        private List<string> _patterns = [];
        private List<string> _towels = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);

            long total = 0;

            foreach (var towel in _towels)
            {
                var memo = new Dictionary<string, long>();
                total += CountWays(towel, _patterns, memo);
            }

            Console.WriteLine(total);
        }
        private long CountWays(string towel, List<string> patterns, Dictionary<string, long> memo)
        {
            if (string.IsNullOrEmpty(towel))
            {
                return 1;
            }

            if (memo.ContainsKey(towel))
            {
                return memo[towel];
            }

            long total = 0;

            foreach (var pattern in patterns)
            {
                if (towel.StartsWith(pattern))
                {
                    total += CountWays(towel.Substring(pattern.Length), patterns, memo);
                }
            }

            memo[towel] = total;
            return total;
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                if (line.Contains(','))
                {
                    _patterns = line.Split(",").Select(x => x.Trim()).ToList();
                }
                else if (!string.IsNullOrEmpty(line))
                {
                    _towels.Add(line);
                }
            }
        }
    }
}
