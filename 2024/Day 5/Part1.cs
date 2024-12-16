

namespace AdventOfCode._2024.Day5
{
    public class Part1
    {
        public List<(int, int)> _rules = [];

        public void Process(string fileLocation) 
        {
            var orders = ParseInput(fileLocation);
            int pageCount = 0;

            foreach (var order in orders)
            {
                var numPages = order.Count;
                var match = true;

                for (int firstPage = 0; firstPage < numPages; firstPage++)
                {
                    if (!match)
                    {
                        break;
                    }

                    for (int secondPage = firstPage + 1; secondPage < numPages; secondPage++)
                    {
                        if (!CheckPageRule(order[firstPage], order[secondPage]))
                        {
                            match = false;
                            break;
                        }
                    }
                }    

                if (match) 
                {
                    pageCount += order[numPages / 2];
                }
            }

            Console.WriteLine(pageCount);
        }

        private bool CheckPageRule(int frontPage, int backPage)
        {
            return _rules.Where(r => r.Item1 == frontPage && r.Item2 == backPage).Any();
        }

        private List<List<int>> ParseInput(string fileLocation)
        {
            var orders = new List<List<int>>();

            foreach (string line in File.ReadLines(fileLocation))
            {
                if (line.Contains('|'))
                {
                    var numbers = line.Split(('|')).Select(int.Parse);
                    _rules.Add((numbers.First(), numbers.Last()));
                }
                else if (line.Contains(','))
                {
                    orders.Add(line.Split((',')).Select(int.Parse).ToList());
                }
            }

            return orders;
        }
    }
}
