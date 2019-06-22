using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._Odd_Occurrences
{
    class StartUp
    {
        static void Main()
        {
            var dict = new Dictionary<string, int>();
            var list = new List<string>();

            var input = Console.ReadLine().ToLower().Split();

            foreach (var word in input)
            {
                if (!dict.ContainsKey(word))
                    dict.Add(word, 1);

                else
                    dict[word]++;
            }

            foreach (var word in dict.Where(w => w.Value % 2 == 1))
            {
                list.Add(word.Key);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
