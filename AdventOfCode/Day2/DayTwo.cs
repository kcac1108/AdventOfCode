namespace AdventOfCode.Day2
{
    internal class DayTwo
    {
        int qtdErros = 0;
        public void Day2()
        {
            string path = "C:\\Users\\KauaCavalheiro\\Documents\\Projects\\AdventOfCode\\AdventOfCode\\Day2\\TextFile1.txt";
            string[] docs = File.ReadAllLines(path);
            //string[] docs = { "7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9" };
            int count = 0;
            //int contador_de_erros = 0;
            foreach (var input in docs)
            {
                qtdErros = 0;
                if ((Is_Valid(input)) && (qtdErros <= 1))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private bool Is_Valid(string input)
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

                if (!IsSafe(num1, num2))
                {
                    qtdErros++;

                    if (qtdErros <= 1)
                    {
                        Console.WriteLine($"erros: {qtdErros}");
                        // Dividir a sequência em duas partes e tentar novamente sem um dos números
                        var firstSubstring = string.Join(" ", separado.Take(i).Concat(separado.Skip(i + 1)));
                        var secondSubstring = string.Join(" ", separado.Take(i + 1).Concat(separado.Skip(i + 2)));

                        Console.WriteLine(firstSubstring);
                        Console.WriteLine(secondSubstring);

                        // Verificar se ao remover o número da primeira parte ou da segunda parte a sequência fica válida
                        if (Is_Valid(firstSubstring) || Is_Valid(secondSubstring))
                        {
                            return true;
                        }

                        safe = false;
                        break;
                    }

                }

                if (num1 > num2)
                {
                    increasing = false;
                }
                else if (num1 < num2)
                {
                    decreasing = false;
                }
            }

            return (increasing && safe) || (decreasing && safe);
        }

        private bool IsSafe(int num1, int num2)
        {
            return Math.Abs(num1 - num2) >= 1 && Math.Abs(num1 - num2) <= 3;
        }
    }
}
