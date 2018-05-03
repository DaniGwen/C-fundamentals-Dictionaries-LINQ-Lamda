
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Occurrences
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().ToLower();

			string[] split = input.Split(' ');

			Dictionary<string, int> words = new Dictionary<string, int>();

			foreach (var word in split)
			{
				if (words.ContainsKey(word))
				{
					words[word]++;
				}
				else
				{
					words[word] = 1;
				}
			}
			var result = new List<string>();

			foreach (var pair in words) 
			{
				if (pair.Value % 2 != 0)
				{
					result.Add(pair.Key);
				}
			}
			Console.WriteLine(string.Join(", ", result));
			
		}
	}
}
