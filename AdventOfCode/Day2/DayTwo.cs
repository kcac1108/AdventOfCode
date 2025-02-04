namespace AdventOfCode.Day2
{
    internal class DayTwo
    {
        public void Day2()
        {
            string path = "C:\\Users\\KauaCavalheiro\\Documents\\Projects\\AdventOfCode\\AdventOfCode\\Day2\\TextFile1.txt";
            string[] docs = File.ReadAllLines(path);

            int count = 0;

            foreach (var input in docs)
            {
                string[] separado = input.Split(" ");
                int length = separado.Length;

                for (int i = 0; i < length - 1; i++)
                {
                    int num1 = int.Parse(separado[i]);
                    int num2 = int.Parse(separado[i + 1]);

                    if (Math.Abs(num1 - num2) < 1 || Math.Abs(num1 - num2) > 3 || num1 != num2)
                    {
                        var firstSubstring = string.Join(" ", separado.Take(i).Concat(separado.Skip(i + 1)));
                        var secondSubstring = string.Join(" ", separado.Take(i + 1).Concat(separado.Skip(i + 2)));
                        if (IsValid(firstSubstring) == true || IsValid(secondSubstring) == true)
                        {
                            count++;
                            break;
                        }
                    }
                }

            }
            Console.WriteLine("safe cases: {0}", count);
        }
        private bool IsValid(string input)
        {
            string[] separado = input.Split(" ");
            int length = separado.Length;

            bool increasing = true;
            bool decreasing = true;
            bool safe = true;

            for (int i = 0; i < length - 1; i++)
            {
                int num1 = int.Parse(separado[i]);
                int num2 = int.Parse(separado[i + 1]);

                if (Math.Abs(num1 - num2) < 1 || Math.Abs(num1 - num2) > 3)
                {
                    safe = false;
                    break;
                }
                else if (num1 > num2)
                {
                    increasing = false;
                }
                else if (num1 < num2)
                {
                    decreasing = false;
                }

            }
            if ((increasing == true && safe == true) || (decreasing == true && safe == true))
            {
                return true;
            }
            return false;
        }
    }
}
