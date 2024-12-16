namespace AdventOfCode._2024.Day2
{
    public class Part1
    {
        public void Process(string fileLocation) 
        {
            var total = 0;

            foreach (var line in File.ReadLines(fileLocation))
            {
                var numbers = line.Split(" ").Select(int.Parse);
                var previousOrder = Order.Starting; 
                var currentOrder = Order.Neither;
                var safe = true;

                for (int i = 0; i < numbers.Count() - 1; i++)
                {
                    var pace = Math.Abs(numbers.ElementAt(i) - numbers.ElementAt(i + 1));

                    if (numbers.ElementAt(i) > numbers.ElementAt(i + 1))
                    {
                        currentOrder = Order.Decrease;
                    }
                    else if (numbers.ElementAt(i) < numbers.ElementAt(i + 1))
                    {
                        currentOrder = Order.Increase;
                    }
                    else
                    {
                        currentOrder = Order.Neither;
                    }

                    if ((previousOrder == Order.Starting || currentOrder != Order.Neither && previousOrder == currentOrder) && pace <= 3)
                    {
                        previousOrder = currentOrder;
                    }
                    else
                    {
                        safe = false;
                        break;
                    }
                }
                
                if (safe)
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }

        public enum Order
        {
            Increase,
            Decrease,
            Neither,
            Starting
        }
    }
}
