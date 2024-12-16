namespace AdventOfCode._2024.Day2
{
    public class Part2
    {
        public void Process(string fileLocation) 
        {
            var total = 0;

            foreach (var line in File.ReadLines(fileLocation))
            {
                var numbers = line.Split(" ").Select(int.Parse).ToList();

                if (CheckLevels(numbers))
                {
                    total++;
                }
                else
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        var newList = numbers.ToList();
                        newList.RemoveAt(i);
                        
                        if (CheckLevels(newList))
                        {
                            total++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }

        private static bool CheckLevels(List<int> numbers)
        {
            var previousOrder = Order.Starting;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var pace = Math.Abs(numbers.ElementAt(i) - numbers.ElementAt(i + 1));

                Order currentOrder;
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
                    return false;
                }
            }

            return true;
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
