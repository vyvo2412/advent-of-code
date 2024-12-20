



namespace AdventOfCode._2024.Day19
{
    public class Part1
    {
        private List<string> _patterns = [];
        private List<string> _towels = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            
            var total = 0;

            foreach (var towel in _towels)
            {
                if (SearchTowel(towel))
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }

        private bool SearchTowel(string towel)
        {
            foreach (var pattern in _patterns)
            {
                var tempTowel = towel;

                if (tempTowel.StartsWith(pattern))
                {
                    tempTowel = tempTowel.Substring(pattern.Length);

                    if (string.IsNullOrEmpty(tempTowel) || SearchTowel(tempTowel))
                    {
                        return true;
                    }
                }
            }

            return false;
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
