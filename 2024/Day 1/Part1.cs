﻿namespace AdventOfCode._2024.Day1
{
    public class Part1
    {
        private List<int> _left = [];
        private List<int> _right = [];

        public void Process(string fileLocation) 
        {
            ParseInput(fileLocation);  

            var left = _left.OrderDescending();
            var right = _right.OrderDescending();
            var total = 0;
            
            for (int i = 0; i < left.Count(); i++)
            {
                total += Math.Abs(left.ElementAt(i) - right.ElementAt(i));
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
