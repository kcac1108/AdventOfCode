using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    internal class DayOne
    {
        public void Day1()
        {
            // Caminho do arquivo de entrada
            string path = "C:\\Users\\KauaCavalheiro\\Documents\\Projects\\AdventOfCode\\AdventOfCode\\Day1\\input.txt";

            // Chamando o método que calcula a pontuação de similaridade
            int similarityScore = CalculateSimilarityScore(path);

            // Exibindo o resultado
            Console.WriteLine(similarityScore);
        }

        // Método que calcula o score de similaridade
        static int CalculateSimilarityScore(string path)
        {
            string[] docs = File.ReadAllLines(path);

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int similarity = 0;
            int similarityScore = 0;

            // Preenchendo as listas left e right
            foreach (var input in docs)
            {
                string[] separado = input.Split("   ");
                left.Add(int.Parse(separado[0]));
                right.Add(int.Parse(separado[1]));
            }

            // Ordenando as listas
            left.Sort();
            right.Sort();

            // Calculando a pontuação de similaridade
            foreach (var numberLeft in left)
            {
                similarity = 0;
                foreach (var numberRight in right)
                {
                    if (numberLeft == numberRight)
                    {
                        similarity++;
                    }
                }
                similarityScore += similarity * numberLeft;
            }

            return similarityScore;
        }
    }
}

