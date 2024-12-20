
namespace AdventOfCode._2024.Day14
{
    public class Part1
    {
        private int _wide = 101;
        private int _tall = 103;
        private List<Robot> _robots = [];
        
        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);
            
            long q1 = 0;
            long q2 = 0;
            long q3 = 0;
            long q4 = 0;

            for (int i = 1; i <= 100; i++)
            {
                foreach (var robot in _robots)
                {
                    robot.PosX += robot.VelX;
                    robot.PosY += robot.VelY;

                    if (robot.PosX < 0) 
                        robot.PosX = _wide + robot.PosX;
                    else if (robot.PosX >= _wide) 
                        robot.PosX -= _wide;
                
                    if (robot.PosY < 0)
                        robot.PosY = _tall + robot.PosY;
                    else if (robot.PosY >= _tall)
                        robot.PosY -= _tall;

                    if (i == 100)
                    {
                        if (0 <= robot.PosX && robot.PosX <= 49 && 0 <= robot.PosY && robot.PosY <= 50) q1++;
                        else if (51 <= robot.PosX && 0 <= robot.PosY && robot.PosY <= 50) q2++;
                        else if (0 <= robot.PosX && robot.PosX <= 49 && 52 <= robot.PosY) q3++;
                        else if (51 <= robot.PosX && 52 <= robot.PosY) q4++;
                    }    
                }   
            }

            Console.WriteLine(q1*q2*q3*q4);
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                var pv = line.Split(" ");
                var p = pv[0].Split("=")[1].Split(",").Select(int.Parse).ToList();
                var v = pv[1].Split("=")[1].Split(",").Select(int.Parse).ToList();
                
                _robots.Add(new Robot { PosX = p[0], PosY = p[1], VelX = v[0], VelY = v[1] });
            }
        }
    }

    public record Robot
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int VelX { get; init; }
        public int VelY { get; init; }
    }
}
