using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        struct GuardInterval
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        class Guard
        {
            public int Id { get; set; }
            public List<GuardInterval> SleepIntervals { get; set; }
        }

        public static int Day4_Part1(string input)
        {
             
            return -1;
        }

        static void Main(string[] args)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, @"../../input.txt");
            string input = File.ReadAllText(filename);

            int day4_part1_result = Day4_Part1(input);

            Console.WriteLine("Answer for Day4_Part1: " + day4_part1_result);

            Console.ReadKey();
        }
    }
}
