
namespace AdventOfCode._2024.Day10
{
    public class Part2
    {
        private List<List<int>> _map = [];
        private int _maxRow;
        private int _maxCol;

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            var total = 0;
            _maxRow = _map.Count;
            _maxCol = _map[0].Count;

            for (int i = 0; i < _maxRow; i++)
            {
                for (int j = 0; j < _maxCol; j++)
                {
                    if (_map[i][j] == 0)
                    {
                        foreach (var find1 in FindNum(i, j, 1))
                        {
                            foreach (var find2 in FindNum(find1.Item1, find1.Item2, 2))
                            {
                                foreach (var find3 in FindNum(find2.Item1, find2.Item2, 3))
                                {
                                    foreach (var find4 in FindNum(find3.Item1, find3.Item2, 4))
                                    {
                                        foreach (var find5 in FindNum(find4.Item1, find4.Item2, 5))
                                        {
                                            foreach (var find6 in FindNum(find5.Item1, find5.Item2, 6))
                                            {
                                                foreach (var find7 in FindNum(find6.Item1, find6.Item2, 7))
                                                {
                                                    foreach (var find8 in FindNum(find7.Item1, find7.Item2, 8))
                                                    {                            
                                                        total += FindNum(find8.Item1, find8.Item2, 9).Count;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }

        private List<(int, int)> FindNum(int i, int j, int v)
        {
            var result = new List<(int, int)>();

            if (i >= 1 && _map[i - 1][j] == v) //top
            {
                result.Add((i - 1, j));
            }

            if (i + 1 < _maxRow && _map[i + 1][j] == v) //bottom
            {
                result.Add((i + 1, j));
            }

            if (j >= 1 && _map[i][j - 1] == v) //left
            {
                result.Add((i, j - 1));
            }

            if (j + 1 < _maxCol && _map[i][j + 1] == v) //right
            {
                result.Add((i, j + 1));
            }

            return result;
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                _map.Add(line.Select(c => int.Parse(c.ToString())).ToList());
            }
        }
    }
}
