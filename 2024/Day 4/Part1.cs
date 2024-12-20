using System.ComponentModel.DataAnnotations;

namespace AdventOfCode._2024.Day4
{
    public class Part1
    {
        private List<List<string>> _maze = [];
        private int _maxRow;
        private int _maxCol;

        public void Process(string fileLocation) 
        {
            ParseInput(fileLocation);
            var total = 0;

            for (int row = 0; row < _maxRow; row++)
            {
                for (int col = 0; col < _maxCol; col++)
                {
                    if (_maze[row][col] == "X")
                    {
                        var mLocations = FindM(row, col);

                        foreach (var loc in mLocations)
                        {
                            if (FindNextLetter("A", loc.Item1, loc.Item2, loc.Item3, out int x, out int y))
                            {
                                if (FindNextLetter("S", x, y, loc.Item3, out int xx, out int yy))
                                {
                                    total++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }

        private bool FindNextLetter(string letter, int row, int col, Direction dir, out int x, out int y)
        {
            x = row;
            y = col;

            switch (dir)
            {
                case Direction.TopLeft:
                    if (row - 1 >= 0 && col - 1 >= 0 && _maze[row - 1][col - 1] == letter)
                    {
                        x = row - 1;
                        y = col - 1;
                        return true;
                    }

                    break;

                case Direction.Top:
                    if (row - 1 >= 0 && _maze[row -1][col] == letter)
                    {
                        x = row - 1;
                        return true;
                    }

                    break;
                case Direction.TopRight:
                    if (row - 1 >= 0 && col + 1 < _maxCol && _maze[row - 1][col + 1] == letter)
                    {
                        x = row - 1;
                        y = col + 1;
                        return true;
                    }

                    break;

                case Direction.Left:
                    if (col - 1 >= 0 && _maze[row][col - 1] == letter)
                    {
                        y = col - 1;
                        return true;
                    }

                    break;

                case Direction.Right:
                    if (col + 1 < _maxCol && _maze[row][col + 1] == letter)
                    {
                        y = col + 1;
                        return true;
                    }

                    break;

                case Direction.BottomLeft:
                if (row + 1 < _maxRow && col - 1 >= 0 && _maze[row + 1][col - 1] == letter)
                    {
                        x = row + 1;
                        y = col - 1;
                        return true;
                    }

                    break;

                case Direction.Bottom:
                    if (row + 1 < _maxRow && _maze[row + 1][col] == letter)
                    {
                        x = row + 1;
                        return true;
                    }

                    break;

                case Direction.BottomRight:
                    if (row + 1 < _maxRow && col + 1 < _maxCol && _maze[row + 1][col + 1] == letter)
                    {
                        x = row + 1;
                        y = col + 1;
                        return true;
                    }

                    break;
                default:
                    break;
            }

            return false;
        }

        private List<(int, int, Direction)> FindM(int row, int col)
        {
            var locations = new List<(int, int, Direction)>();

            if (row - 1 >= 0 && col - 1 >= 0 && _maze[row -1][col -1] == "M") // left top
            { 
                locations.Add((row - 1, col - 1, Direction.TopLeft));
            }
            
            if (row - 1 >= 0 && _maze[row - 1][col] == "M") // top
            {
                locations.Add((row - 1, col, Direction.Top));
            }
            
            if (row - 1 >= 0 && col + 1 < _maxCol && _maze[row - 1][col + 1] == "M") // right top
            {
                locations.Add((row - 1, col + 1, Direction.TopRight));
            }
            
            if (col - 1 >= 0 && _maze[row][col - 1] == "M") // left
            {
                locations.Add((row, col - 1, Direction.Left));
            }
            
            if (col + 1 < _maxCol && _maze[row][col + 1] == "M") // right
            {
                locations.Add((row, col + 1, Direction.Right));
            }
            
            if (row + 1 < _maxRow && col - 1 >= 0 && _maze[row + 1][col - 1] == "M") // left bottom
            {
                locations.Add((row + 1, col - 1, Direction.BottomLeft));
            }
            if (row + 1 < _maxRow && _maze[row + 1][col] == "M") // bottom
            {
                locations.Add((row + 1, col, Direction.Bottom));
            }
            if (row + 1 < _maxRow && col + 1 < _maxCol && _maze[row + 1][col + 1] == "M") // right bottom
            {
                locations.Add((row + 1, col + 1, Direction.BottomRight));
            }
            
            return locations;
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

    public enum Direction
    {
        TopLeft,
        Top,
        TopRight,
        BottomLeft,
        Bottom,
        BottomRight,
        Left,
        Right
    }
}
