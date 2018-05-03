using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine()
				.ToLower()
				.Split()
				.ToList();
			Dictionary<string, int> words = new Dictionary<string, int>();

			foreach (var word in input)
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
			var res = new List<string>();

			foreach (var word in words)
			{
				if (word.Value % 2 != 0)
				{
					res.Add(word.Key);
				}
			}
			Console.WriteLine(string.Join(",", res));
		}
	}
}
