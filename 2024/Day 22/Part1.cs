namespace AdventOfCode._2024.Day22
{
    public class Part1
    {
        private List<long> _secrets = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            
            long total = 0;

            foreach (var secret in _secrets)
            {
                var secretNum = secret;
                
                for (int i = 0; i < 2000; i++)
                {
                    var step1 = secretNum * 64;
                    secretNum = step1 ^ secretNum;
                    secretNum %= 16777216;
                    var step2 = secretNum / 32;
                    secretNum = step2 ^ secretNum;
                    secretNum %= 16777216;
                    var step3 = secretNum * 2048;
                    secretNum = step3 ^ secretNum;
                    secretNum %= 16777216;
                    
                    if (i == 1999)
                    {
                        total += secretNum;
                    }         
                }   
            }

            Console.WriteLine(total);
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                _secrets.Add(long.Parse(line));
            }
        }
    }
}
