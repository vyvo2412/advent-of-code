namespace AdventOfCode._2024.Day9
{
    public class Part1
    {
        private string _inputText;
        private List<string> _blocks = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            var numbers = _inputText.Trim().Select(c => int.Parse(c.ToString()));
            // var numbers = new List<int> {2,3,3,3,1,3,3,1,2,1,4,1,4,1,3,1,4,0,2};
            bool isNum = true;
            var numTracking = 0;

            foreach (var num in numbers)
            {
                if (num == 0)
                {
                    isNum = !isNum;
                    continue;
                }

                var block = isNum ? numTracking.ToString() : ".";

                for (int i = 0; i < num; i++)
                {
                    _blocks.Add(block);
                }

                numTracking = isNum ? numTracking + 1 : numTracking;
                isNum = !isNum;
            }

            var end = _blocks.Count - 1;

            for (int i = 0; i <= end; i++)
            {
                if (!int.TryParse(_blocks[i], out _))
                {
                    while (true)
                    {
                        if (int.TryParse(_blocks[end], out int replaceNum))
                        {
                            _blocks[i] = replaceNum.ToString();
                            _blocks[end] = ".";
                            break; 
                        }

                        end--;
                    }
                }
            }

            long total = 0;

            for (int i = 0; i < _blocks.Count; i++)
            {
                if (_blocks[i] != ".")
                {
                    total += i * int.Parse(_blocks[i]);      
                }                
            }

            Console.WriteLine(total);
        }

        private void ParseInput(string fileLocation)
        {
            _inputText = File.ReadLines(fileLocation).First();
        }
    }
}
