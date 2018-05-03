using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterRepetition
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().ToCharArray();

			var dictChars = new Dictionary<char, int>();

			foreach (var character in input )
			{
				if (!dictChars.ContainsKey(character))
				{
					dictChars.Add(character, 1);
				}
				else
				{
					dictChars[character]++;
				}
			}

			foreach (var letter in dictChars)
			{
				Console.WriteLine($"{letter.Key} -> {letter.Value}");
			}
		}
	}
}
