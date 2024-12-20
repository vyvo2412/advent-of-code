using System.ComponentModel.DataAnnotations;

namespace AdventOfCode._2024.Day4
{
    public class Part2
    {
        private List<List<string>> _maze = [];
        private List<((int, int), (int, int), (int, int))> _masLocations = [];
        private int _maxRow;
        private int _maxCol;

        public void Process(string fileLocation) 
        {
            ParseInput(fileLocation);
            var count = 0;

            for (int i = 1; i < _maxRow - 1; i++)
            {
                for (int j = 1; j < _maxCol - 1; j++)
                {
                    if (_maze[i][j] == "A" &&
                    (
                        // Pattern: M . M / . A . / S . S
                        (_maze[i - 1][j - 1] == "M" && _maze[i - 1][j + 1] == "M" &&
                         _maze[i + 1][j - 1] == "S" && _maze[i + 1][j + 1] == "S") ||

                        // Pattern: M . S / . A . / M . S
                        (_maze[i - 1][j - 1] == "M" && _maze[i - 1][j + 1] == "S" &&
                         _maze[i + 1][j - 1] == "M" && _maze[i + 1][j + 1] == "S") ||

                        // Pattern: S . M / . A . / S . M
                        (_maze[i - 1][j - 1] == "S" && _maze[i - 1][j + 1] == "M" &&
                         _maze[i + 1][j - 1] == "S" && _maze[i + 1][j + 1] == "M") ||

                        // Pattern: S . S / . A . / M . M
                        (_maze[i - 1][j - 1] == "S" && _maze[i - 1][j + 1] == "S" &&
                         _maze[i + 1][ j - 1] == "M" && _maze[i + 1][j + 1] == "M")
                    ))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                _maze.Add(line.Select(c => c.ToString()).ToList());
            }

            _maxRow = _maze.Count;
            _maxCol = _maze[0].Count;
        }
    }
}
