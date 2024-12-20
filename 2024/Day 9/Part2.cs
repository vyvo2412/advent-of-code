
namespace AdventOfCode._2024.Day9
{
    public class Part2
    {
        private string _inputText;
        private List<string> _blocks = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            var numbers = _inputText.Trim().Select(c => int.Parse(c.ToString()));
            // var numbers = new List<int> { 2, 3, 3, 3, 1, 3, 3, 1, 2, 1, 4, 1, 4, 1, 3, 1, 4, 0, 2 };

            bool isNum = true;
            int numTracking = 0;

            foreach (var num in numbers)
            {
                if (num == 0)
                {
                    isNum = !isNum;
                    continue;
                }

                string block = isNum ? numTracking.ToString() : ".";

                for (int x = 0; x < num; x++)
                {
                    _blocks.Add(block);
                }

                if (isNum) numTracking++;
                isNum = !isNum;
            }

            var files = new List<(int Start, int Length, int FileId)>();
            var freeSpaces = new List<(int Start, int Length)>();

            int i = 0;
            while (i < _blocks.Count)
            {
                if (_blocks[i] == ".")
                {
                    int start = i;
                    while (i < _blocks.Count && _blocks[i] == ".") i++;
                    freeSpaces.Add((start, i - start));
                }
                else
                {
                    int start = i;
                    string fileIdStr = _blocks[i];
                    while (i < _blocks.Count && _blocks[i] == fileIdStr) i++;
                    files.Add((start, i - start, int.Parse(fileIdStr)));
                }
            }

            files.Sort((a, b) => b.FileId.CompareTo(a.FileId));

            foreach (var file in files)
            {
                bool moved = false;

                foreach (var space in freeSpaces)
                {
                    if (space.Length >= file.Length && space.Start < file.Start)
                    {
                        for (int j = 0; j < file.Length; j++)
                        {
                            _blocks[space.Start + j] = file.FileId.ToString();
                            _blocks[file.Start + j] = ".";
                        }

                        int newFreeStart = space.Start + file.Length;
                        int newFreeLength = space.Length - file.Length;
                        freeSpaces.Remove(space);
                        if (newFreeLength > 0)
                        {
                            freeSpaces.Add((newFreeStart, newFreeLength));
                        }

                        freeSpaces.Sort((a, b) => a.Start.CompareTo(b.Start));

                        moved = true;
                        break;
                    }
                }

                if (!moved)
                {
                    continue;
                }
            }

            long total = 0;
            for (int idx = 0; idx < _blocks.Count; idx++)
            {
                if (_blocks[idx] != ".")
                {
                    total += idx * int.Parse(_blocks[idx]);
                }
            }

            Console.WriteLine($"Checksum: {total}");
        }

        private void ParseInput(string fileLocation)
        {
            _inputText = File.ReadLines(fileLocation).First();
        }
    }
}
