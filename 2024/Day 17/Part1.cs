


namespace AdventOfCode._2024.Day17
{
    public class Part1
    {
        private int _a;
        private int _b;
        private int _c;
        private List<int> _operands = [];

        public void Process(string fileLocation)
        {
            ParseInput(fileLocation);

            List<int> output = [];
            int instructionPointer = 0;

            while (instructionPointer < _operands.Count)
            {
                int opcode = _operands[instructionPointer];
                int operand = _operands[instructionPointer + 1];
                int comboOperand;

                if (operand >= 0 && operand <= 3) 
                {
                    comboOperand = operand;
                }
                else if (operand == 4)
                {
                    comboOperand = _a;
                }
                else if (operand == 5)
                {
                    comboOperand = _b;
                }
                else if (operand == 6)
                {
                    comboOperand = _c;
                }
                else
                {
                    comboOperand = 0;
                }

                switch (opcode)
                {
                    
                    case 0: // adv: Divide A by 2^operandValue
                        _a /= (int)Math.Pow(2, comboOperand);
                        break;

                    case 1: // bxl: B XOR literal operand
                        _b ^= operand;
                        break;

                    case 2: // bst: B = operandValue % 8
                        _b = comboOperand % 8;
                        break;

                    case 3: // jnz: Jump if A is not zero
                        if (_a != 0)
                        {
                            instructionPointer = operand;
                            continue; // Skip the normal instruction pointer increment
                        }
                        break;

                    case 4: // bxc: B XOR C
                        _b ^= _c;
                        break;

                    case 5: // out: Output operandValue % 8
                        output.Add(comboOperand % 8);
                        break;

                    case 6: // bdv: Divide A by 2^operandValue, store in B
                        _b = _a / (int)Math.Pow(2, comboOperand);
                        break;

                    case 7: // cdv: Divide A by 2^operandValue, store in C
                        _c = _a / (int)Math.Pow(2, comboOperand);
                        break;

                    default:
                        throw new InvalidOperationException($"Unknown opcode: {opcode}");
                }

                instructionPointer += 2; // Move to the next opcode-operand pair
            }

            Console.WriteLine($"{string.Join(",", output)}");
        }

        private void ParseInput(string fileLocation)
        {
            foreach (var line in File.ReadLines(fileLocation))
            {
                if (line.Contains("Register A:"))
                {
                    _a = int.Parse(line.Split(":")[1].Trim());
                }
                else if (line.Contains("Register B:"))
                {
                    _b = int.Parse(line.Split(":")[1].Trim());
                }
                else if (line.Contains("Register C:"))
                {
                    _c = int.Parse(line.Split(":")[1].Trim());
                }
                else if (line.Contains("Program:"))
                {
                    _operands = line.Split(":")[1].Trim().Split(",").Select(int.Parse).ToList();
                }
            }
        }
    }
}
