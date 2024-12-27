
namespace AdventOfCode._2024.Day13
{
    public class Part1
    {   
        private Dictionary<int, Claw> _claws = [];     
        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            
            var total = 0;

            foreach (var claw in _claws)
            {
                var clawValue = claw.Value;
                var foundCombos = FindCombos(clawValue.ButtonAX, clawValue.ButtonBX, clawValue.PrizeX, clawValue.ButtonAY, clawValue.ButtonBY, clawValue.PrizeY);
                
                if (foundCombos.Count > 0)
                {
                    total += foundCombos.Min();
                }
            }

            Console.WriteLine(total);
        }

        private List<int> FindCombos(int a1, int b1, double c1, int a2, int b2, double c2)
        {
            var solutions  = new List<int>();
            int rangeMin = 0; 
            int rangeMax = 100;  

            for (int x = rangeMin; x <= rangeMax; x++)
            {
                for (int y = rangeMin; y <= rangeMax; y++)
                {
                    if (a1 * x + b1 * y == c1 && a2 * x + b2 * y == c2)
                    {
                        solutions.Add(x*3 + y*1);
                    }
                }
            }
            return solutions;
        }
        
        private void ParseInput(string fileLocation)
        {
            int lineNum = 0;
            int clawCount = 0;

            foreach (var line in File.ReadLines(fileLocation))
            {
                if (lineNum == 0)
                {
                    var buttonA = line.Split(":")[1].Split(",");
                    var buttonAX = int.Parse(buttonA[0].Split("+")[1]);
                    var buttonAY = int.Parse(buttonA[1].Split("+")[1]);
                    var newClaw = new Claw()
                    {
                        ButtonAX = buttonAX,
                        ButtonAY = buttonAY
                    };
                    _claws.Add(clawCount, newClaw);
                }
                else if (lineNum == 1)
                {
                    var claw = _claws.GetValueOrDefault(clawCount);
                    var buttonB = line.Split(":")[1].Split(",");
                    claw.ButtonBX = int.Parse(buttonB[0].Split("+")[1]);
                    claw.ButtonBY = int.Parse(buttonB[1].Split("+")[1]);
                }
                else if (lineNum == 2)
                {
                    var claw = _claws.GetValueOrDefault(clawCount);
                    var prize = line.Split(":")[1].Split(",");
                    claw.PrizeX = int.Parse(prize[0].Split("=")[1]);
                    claw.PrizeY = int.Parse(prize[1].Split("=")[1]);
                }
                else if (lineNum == 3)
                {
                    lineNum = 0;
                    clawCount++;
                    continue;
                }

                lineNum++;
            }
        }
    }

    public record Claw
    {
        public int ButtonAX { get; set; }
        public int ButtonAY { get; set; }
        public int ButtonBX { get; set; }
        public int ButtonBY { get; set; }
        public long  PrizeX { get; set; }
        public long  PrizeY { get; set; }
    }
}
