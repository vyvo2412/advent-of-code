


namespace AdventOfCode._2024.Day5
{
    public class Part2
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

                if (!match) 
                {
                    var correctedOrder = ProcessIncorrectOrder(order);
                    pageCount += correctedOrder[correctedOrder.Count / 2];
                }
            }

            Console.WriteLine(pageCount);
        }

        private List<int> ProcessIncorrectOrder(List<int> order)
        {
            var newOrder = new List<int> { order[0] };

            for (int i = 1; i < order.Count; i++)
            {
                for (int j = 0; j < newOrder.Count; j++)
                {
                    if (newOrder.Count == 1)
                    {
                        if (CheckPageRule(newOrder[j], order[i]))
                        {
                            newOrder.Add(order[i]);
                        }
                        else if (CheckPageRule(order[i], newOrder[j]))
                        {
                            newOrder.Insert(j, order[i]);
                        }
                        break;
                    } 
                    else if (j < newOrder.Count)
                    {
                        if (CheckPageRule(newOrder[j], order[i]))
                        {
                            if (j == newOrder.Count -1)
                            {
                                newOrder.Add(order[i]);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (CheckPageRule(order[i], newOrder[j]))
                        {
                            newOrder.Insert(j, order[i]);
                            break;
                        }
                    }
                    else
                    {
                        newOrder.Add(order[i]);
                    }
                }
            }

            return newOrder;
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
