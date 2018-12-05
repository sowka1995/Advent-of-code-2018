using System;
using System.Text;
using System.IO;

namespace Day5
{
    class Program
    {
        public static int Day5_Part1(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            for (int i = 0; i < sb.Length - 1; i++)
            {
                string left = sb[i].ToString();
                string rigth = sb[i + 1].ToString();
                if ((left.ToLower() == rigth && left != rigth) ||
                    (left.ToUpper() == rigth && left != rigth))
                {
                    sb.Remove(i, 2);
                    i = i > 0 ? i - 2 : i - 1;
                }
            }

            return sb.Length;
        }

        public static int Day5_Part2(string input)
        {
            string letters = "ABCDEFGHIKLMNOPQRSTVXYZ";
          
            int min = input.Length;
            foreach (var letter in letters)
            {
                StringBuilder sb = new StringBuilder(input);
                sb.Replace(letter.ToString(), "").Replace(letter.ToString().ToLower(), "");

                for (int i = 0; i < sb.Length - 1; i++)
                {
                    string left = sb[i].ToString();
                    string rigth = sb[i + 1].ToString();
                    if ((left.ToLower() == rigth && left != rigth) ||
                        (left.ToUpper() == rigth && left != rigth))
                    {
                        sb.Remove(i, 2);
                        i = i > 0 ? i - 2 : i - 1;
                    }
                }
                if (min > sb.Length)
                    min = sb.Length;
            }
           
            return min;
        }


        static void Main(string[] args)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, @"../../input.txt");
            string input = File.ReadAllText(filename);

            int day5_part1_result = Day5_Part1(input);
            int day5_part2_result = Day5_Part2(input);

            Console.WriteLine("Answer for Day4_Part1: " + day5_part1_result);
            Console.WriteLine("Answer for Day4_Part2: " + day5_part2_result);

            Console.ReadKey();
        }
    }
}
