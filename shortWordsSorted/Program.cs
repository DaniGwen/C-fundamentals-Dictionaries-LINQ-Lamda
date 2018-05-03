using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortWordsSorted
{
	class Program
	{
		static void Main(string[] args)
		{
			var words = Console.ReadLine()
				.ToLower()
				.Split(new[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '/', '\\', '!', '?', '\'', ' '})
				.Where(w=> w.Length < 5)
				.Distinct()
				.OrderBy(w => w)
				.ToList();

			Console.WriteLine(string.Join(", ", words));
		}
	}
}
