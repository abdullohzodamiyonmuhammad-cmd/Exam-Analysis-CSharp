using System;
using System.Globalization;
using System.Text;

namespace ConsoleApplication1
{
    internal class Program
    {
        private const int StudentCount = 20;
        private const int PassScore = 50;

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Таҳлили натиҷаҳои имтиҳон ===");
            Console.WriteLine("Баҳои " + StudentCount + " донишҷӯро (аз 0 то 100) ворид кунед.");
            Console.WriteLine();

            int[] scores = new int[StudentCount];

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = ReadScore("Донишҷӯи " + (i + 1) + ": ");
            }

            double average = GetAverage(scores);
            int max = GetMax(scores);
            int min = GetMin(scores);
            int passed = CountPassed(scores);
            int failed = scores.Length - passed;

            Console.WriteLine();
            Console.WriteLine("--- Натиҷаи таҳлил ---");
            Console.WriteLine("Баҳои миёна:        " + average.ToString("0.00", CultureInfo.InvariantCulture));
            Console.WriteLine("Баҳои баландтарин:  " + max + " (донишҷӯи " + (Array.IndexOf(scores, max) + 1) + ")");
            Console.WriteLine("Баҳои пасттарин:    " + min + " (донишҷӯи " + (Array.IndexOf(scores, min) + 1) + ")");
            Console.WriteLine("Гузашта:            " + passed);
            Console.WriteLine("Нагузашта:          " + failed);
            Console.WriteLine();
            Console.WriteLine("Барои баромадан тугмаи ихтиёриро пахш кунед...");
            Console.ReadKey();
        }

        private static int ReadScore(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                int score;
                if (int.TryParse(input, out score) && score >= 0 && score <= 100)
                    return score;

                Console.WriteLine("Хато: адади бутун аз 0 то 100 ворид кунед.");
            }
        }

        private static double GetAverage(int[] scores)
        {
            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            return (double)sum / scores.Length;
        }

        private static int GetMax(int[] scores)
        {
            int max = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > max)
                    max = scores[i];
            }
            return max;
        }

        private static int GetMin(int[] scores)
        {
            int min = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < min)
                    min = scores[i];
            }
            return min;
        }

        private static int CountPassed(int[] scores)
        {
            int count = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] >= PassScore)
                    count++;
            }
            return count;
        }
    }
}