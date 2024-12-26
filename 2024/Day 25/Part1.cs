namespace AdventOfCode._2024.Day25
{
    public class Part1
    {
        public void Process(string fileLocation)
        {
            var locks = new List<List<int>>();
            var keys = new List<List<int>>();

            var schematics = ParseInput(fileLocation);

            foreach (var schematic in schematics)
            {
                var isLock = schematic[0].StartsWith('#');

                if (isLock)
                {
                    var newLock = new int[5];

                    for (int row = 0; row < schematic.Count; row++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (schematic[row].ElementAt(i) == '#')
                            {
                                newLock[i] = row;
                            }
                        }
                    }

                    locks.Add([.. newLock]);
                }
                else
                {
                    var newKey = new int[5];

                    for (int row = 0; row < schematic.Count; row++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (schematic[row].ElementAt(i) == '.')
                            {
                                newKey[i] = 5 - row;
                            }
                        }
                    }
                    
                    keys.Add([.. newKey]);
                }
            }

            var total = 0;

            foreach (var l in locks)
            {
                foreach (var k in keys)
                {
                    var match = true;

                    for (int i = 0; i < 5; i++)
                    {
                        if (l[i] + k[i] > 5)
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        total++;
                    }
                }
            }

            Console.WriteLine(total);
        }

        private List<List<string>> ParseInput(string fileLocation)
        {
            var result = new List<List<string>>();
            var lineNum = 0;
            var schematic = new List<string>();

            foreach (var line in File.ReadLines(fileLocation))
            {
                if (lineNum == 7)
                {
                    schematic = [];
                    lineNum = 0;
                    continue;
                }
                
                schematic.Add(line);

                if (lineNum == 6)
                {
                    result.Add(schematic);
                }

                lineNum++;
            }

            return result;
        }
    }
}
