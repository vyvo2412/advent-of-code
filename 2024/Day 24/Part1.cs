namespace AdventOfCode._2024.Day24
{
    public class Part1
    {
        private Dictionary<string, int> _inputs = [];
        private HashSet<Rule> _rules = [];
        
        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            
            while (_rules.Any(r => !r.IsDone))
            {
                foreach (var rule in _rules.Where(r => !r.IsDone))
                {
                    if (_inputs.TryGetValue(rule.FirstInput, out int firstInput) && _inputs.TryGetValue(rule.SecondInput, out int secondInput))
                    {
                        int output = 0;

                        switch (rule.Operand)
                        {
                            case "AND":
                                output = firstInput == 1 && secondInput == 1 ? 1 : 0;
                                break;
                            case "XOR":
                                output = firstInput == secondInput ? 0 : 1;
                                break;
                            case "OR":
                                output = firstInput == 0 && secondInput == 0 ? 0 : 1;
                                break;
                        }

                        rule.IsDone = true;
                        _inputs[rule.Output] = output;
                    }
                }
            }

            var sortedDictionary = _inputs
                .Where(x => x.Key.StartsWith('z'))
                .OrderByDescending(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            string binaryNumber = "";

            foreach (var input in sortedDictionary)
            {
                binaryNumber += input.Value.ToString();
            }

            Console.WriteLine(binaryNumber);
            Console.WriteLine(Convert.ToInt64(binaryNumber, 2));
        }

        private void ParseInput(string fileLocation)
        {
            bool readingInput = true;
            foreach (var line in File.ReadLines(fileLocation))
            {
                if (line == "")
                {
                    readingInput = false;
                    continue;
                }

                if (readingInput)
                {
                    var input = line.Split(":");
                    _inputs[input[0]] = int.Parse(input[1].Trim());
                }
                else
                {
                    var rule = line.Split(" ");
                    _rules.Add(new Rule 
                    { 
                        FirstInput = rule[0],
                        SecondInput = rule[2],
                        Operand = rule[1],
                        Output = rule[4],
                        IsDone = false
                    });
                }
            }
        }

        public record Rule
        {
            public string FirstInput { get; init; }
            public string SecondInput { get; init; }
            public string Operand { get; init; }
            public string Output { get; init; }
            public bool IsDone { get; set; }
        }
    }
}
