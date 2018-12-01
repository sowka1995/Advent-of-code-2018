using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Day1
{
    class Program
    {
        //For example, if the device displays frequency changes of +1, -2, +3, +1, then starting from a frequency of zero, the following changes would occur:

        //Current frequency  0, change of +1; resulting frequency  1.
        //Current frequency  1, change of -2; resulting frequency -1.
        //Current frequency -1, change of +3; resulting frequency  2.
        //Current frequency  2, change of +1; resulting frequency  3.
        //In this example, the resulting frequency is 3.

        //Here are other example situations:

        //+1, +1, +1 results in  3
        //+1, +1, -2 results in  0
        //-1, -2, -3 results in -6
        public static long Day1_Part1(string input)
        {
            var integers = input.Split(
                new[] { "\r\n", "\r", "\n" }, 
                StringSplitOptions.RemoveEmptyEntries
            ).Select(x => int.Parse(x));

            return integers.Sum();
        }


        //You notice that the device repeats the same frequency change list over and over.To calibrate the device, you need to find the first frequency it reaches twice.

        //For example, using the same list of changes above, the device would loop as follows:

        //Current frequency  0, change of +1; resulting frequency  1.
        //Current frequency  1, change of -2; resulting frequency -1.
        //Current frequency -1, change of +3; resulting frequency  2.
        //Current frequency  2, change of +1; resulting frequency  3.
        //(At this point, the device continues from the start of the list.)
        //Current frequency  3, change of +1; resulting frequency  4.
        //Current frequency  4, change of -2; resulting frequency  2, which has already been seen.
        //In this example, the first frequency reached twice is 2. Note that your device might need to repeat its list of frequency changes many times before a duplicate frequency is found, and that duplicates might be found while in the middle of processing the list.

        //Here are other examples:

        //+1, -1 first reaches 0 twice.
        //+3, +3, +4, -2, -4 first reaches 10 twice.
        //-6, +3, +8, +5, -6 first reaches 5 twice.
        //+7, +7, -2, -7, -4 first reaches 14 twice.
        public static int Day1_Part2(string input)
        {
            var integers = input.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.RemoveEmptyEntries
            ).Select(x => int.Parse(x));
            var count = integers.Count();

            Dictionary<int, int> frequencies = new Dictionary<int, int> { { 0, 1 } };
            int i = 0;
            int frequency = 0;
            while (true)
            {
                int element = integers.ElementAt(i);
                frequency += element;
                if (frequencies.ContainsKey(frequency))
                {
                    break;
                }
                else
                {
                    frequencies.Add(frequency, 1);
                }

                i++;
                if (i == count)
                {
                    i = 0;
                }
            }

            return frequency;
        }

        static void Main(string[] args)
        {
            var filename = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../input.txt"));

            var input = File.ReadAllText(filename);
            var day1Result_part1 = Day1_Part1(input);
            var day1Result_part2 = Day1_Part2(input);

            Console.WriteLine("Answer for Day1_Part1: " + day1Result_part1);
            Console.WriteLine("Answer for Day1_Part2: " + day1Result_part2);
            Console.ReadKey();
        }
    }
}
