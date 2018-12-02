using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        //To make sure you didn't miss any, you scan the likely candidate boxes again, counting the number that have an ID containing exactly two of any letter and then separately counting those with exactly three of any letter. You can multiply those two counts together to get a rudimentary checksum and compare it to what your device predicts.

        //For example, if you see the following box IDs:

        //abcdef contains no letters that appear exactly two or three times.
        //bababc contains two a and three b, so it counts for both.
        //abbcde contains two b, but no letter appears exactly three times.
        //abcccd contains three c, but no letter appears exactly two times.
        //aabcdd contains two a and two d, but it only counts once.
        //abcdee contains two e.
        //ababab contains three a and three b, but it only counts once.
        //Of these box IDs, four of them contain a letter which appears exactly twice, and three of them contain a letter which appears exactly three times. Multiplying these together produces a checksum of 4 * 3 = 12.
        public static long Day2_Part1(string input)
        {
            var boxes = input.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.RemoveEmptyEntries
            ).AsEnumerable();

            var twice = 0;
            var thrice = 0;

            foreach (string box in boxes)
            {
                var dictionary = new Dictionary<char, int>();
                foreach (char letter in box)
                {
                    if (dictionary.ContainsKey(letter))
                        dictionary[letter]++;
                    else
                        dictionary.Add(letter, 1);
                }
                twice += dictionary.Where(x => x.Value == 2).Any() ? 1 : 0;
                thrice += dictionary.Where(x => x.Value == 3).Any() ? 1 : 0;
            }

            return twice * thrice;
        }

        //Confident that your list of box IDs is complete, you're ready to find the boxes full of prototype fabric.

        //The boxes will have IDs which differ by exactly one character at the same position in both strings.For example, given the following box IDs:

        //abcde
        //fghij
        //klmno
        //pqrst
        //fguij
        //axcye
        //wvxyz
        //The IDs abcde and axcye are close, but they differ by two characters (the second and fourth). However, the IDs fghij and fguij differ by exactly one character, the third(h and u). Those must be the correct boxes.

        //What letters are common between the two correct box IDs? (In the example above, this is found by removing the differing character from either ID, producing fgij.)
        public static string Day2_Part2(string input)
        {
            var boxes = input.Split(
               new string[] { "\r\n", "\r", "\n" },
               StringSplitOptions.RemoveEmptyEntries
            ).AsEnumerable();
            var count = boxes.Count();
            string result = "";
            
            for (int i = 0; i < count - 1; i++)
            {
                string box1 = boxes.ElementAt(i);
                
                for (int j = i + 1; j < count; j++)
                {
                    string box2 = boxes.ElementAt(j);

                    int difference = 0;
                    for (int k = 0; k < box1.Length; k++)
                    {
                        if (box1[k] != box2[k])
                            difference++;

                        if (difference > 1)
                            break;
                    }

                    if (difference == 1)
                    {
                        for (int k = 0; k < box1.Length; k++)
                        {
                            if (box1[k] == box2[k])
                                result += box1[k];
                        }
                        return result;
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            string filename = Path.Combine(Environment.CurrentDirectory, @"../../input.txt");
            string input = File.ReadAllText(filename);

            long day2_part1_result = Day2_Part1(input);
            string day2_part2_result = Day2_Part2(input);

            Console.WriteLine("Answer for Day2_Part1: " + day2_part1_result);
            Console.WriteLine("Answer for Day2_Part2: " + day2_part2_result);

            Console.ReadKey();
        }
    }
}
