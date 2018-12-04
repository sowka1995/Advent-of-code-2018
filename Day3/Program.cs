using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        public static int Day3_Part1(string input)
        {
            var claims = input.Split(
                    new[] { "\r\n", "\n", "\r" },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(claim => claim.Split(
                    new[] { "#", "@", ",", ":", "x" },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)));

            int width = 0, height = 0;
            foreach (var claim in claims)
            {
                var currentWidth = claim.ElementAt(1) + claim.ElementAt(3);
                var currentHeight = claim.ElementAt(2) + claim.ElementAt(4);

                width = currentWidth > width ? currentWidth : width;   
                height = currentHeight > height ? currentHeight : height;
            }

            int[,] claimsArray = new int[width, height];
            foreach (var claim in claims)
            {
                int widthStart = claim.ElementAt(1);
                int widthEnd = widthStart + claim.ElementAt(3) - 1;
                int heightStart = claim.ElementAt(2);
                int heightEnd = heightStart + claim.ElementAt(4) - 1;

                for (int i = widthStart; i <= widthEnd; i++)
                {
                    for (int j = heightStart; j <= heightEnd; j++)
                    {
                        claimsArray[i, j]++;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (claimsArray[i, j] > 1)
                        result++;
                }
            }

            return result;
        }

        public static int Day3_Part2(string input)
        {
            var claims = input.Split(
                    new[] { "\r\n", "\n", "\r" },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(claim => claim.Split(
                    new[] { "#", "@", ",", ":", "x" },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)));

            int width = 0, height = 0;
            foreach (var claim in claims)
            {
                var currentWidth = claim.ElementAt(1) + claim.ElementAt(3);
                var currentHeight = claim.ElementAt(2) + claim.ElementAt(4);

                width = currentWidth > width ? currentWidth : width;
                height = currentHeight > height ? currentHeight : height;
            }

            int[,] claimsArray = new int[width, height];
            foreach (var claim in claims)
            {
                int widthStart = claim.ElementAt(1);
                int widthEnd = widthStart + claim.ElementAt(3) - 1;
                int heightStart = claim.ElementAt(2);
                int heightEnd = heightStart + claim.ElementAt(4) - 1;

                for (int i = widthStart; i <= widthEnd; i++)
                {
                    for (int j = heightStart; j <= heightEnd; j++)
                    {
                        claimsArray[i, j]++;
                    }
                }
            }

            int id = 0;
            foreach (var claim in claims)
            {
                int currentId = claim.ElementAt(0);
                int widthStart = claim.ElementAt(1);
                int widthEnd = widthStart + claim.ElementAt(3) - 1;
                int heightStart = claim.ElementAt(2);
                int heightEnd = heightStart + claim.ElementAt(4) - 1;

                bool doesOverlap = false;
                for (int i = widthStart; i <= widthEnd; i++)
                {
                    for (int j = heightStart; j <= heightEnd; j++)
                    {
                        if (claimsArray[i, j] != 1)
                        {
                            doesOverlap = true;
                            break;
                        }
                    }

                    if (doesOverlap) break;
                }

                if (!doesOverlap)
                {
                    id = currentId;
                    break;
                }
            }

            return id;
        }

        static void Main(string[] args)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, @"../../input.txt");
            string input = File.ReadAllText(filename);

            int day3_part1_result = Day3_Part1(input);
            int day3_part2_result = Day3_Part2(input);

            Console.WriteLine("Answer for Day3_Part1: " + day3_part1_result);
            Console.WriteLine("Answer for Day3_Part2: " + day3_part2_result);

            Console.ReadKey();
        }
    }
}
