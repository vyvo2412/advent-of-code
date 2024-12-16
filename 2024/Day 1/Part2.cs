namespace AdventOfCode._2024.Day1
{
    public class Part2
    {
        private List<int> _left = [];
        private List<int> _right = [];

        public void Process(string fileLocation) 
        {
            ParseInput(fileLocation);  

            var total = 0;
            
            for (int i = 0; i < _left.Count; i++)
            {
                total += _left[i] * _right.Where(x => x == _left[i]).Count();
            }

            Console.WriteLine(total);
        }
        
        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                var numbers = line.Split("   ").Select(int.Parse);
                _left.Add(numbers.First());
                _right.Add(numbers.Last());
            }
        }
    }
}
