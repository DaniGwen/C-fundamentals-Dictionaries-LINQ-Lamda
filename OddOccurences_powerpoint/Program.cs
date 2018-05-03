using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurences_powerpoint
{
	class Program
	{
		static void Main(string[] args)
		{

			string input = Console.ReadLine().ToLower();
			string[] words = input.Split(' ');

			Dictionary<string, int> counts = new Dictionary<string, int>();

			foreach (var word in words)
			{
				if (counts.ContainsKey(word))
				{
					counts[word]++;
				}
				else
				{
					counts[word] = 1;
				}
			}
			List<string> result = new List<string>();
			foreach (var pair in counts)
			{
				if (pair.Value % 2 == 1)
				{
					result.Add(pair.Key);
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
	}
}
