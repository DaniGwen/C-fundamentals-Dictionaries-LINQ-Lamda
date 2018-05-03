using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealnumbers_Exercise
{
	class Program
	{
		static void Main(string[] args)
		{
			var nums = Console.ReadLine()
				.Split()
				.Select(double.Parse)
				.OrderBy(n => n)
				.ToList();

			Dictionary<double, int> numOfOcurrances = new Dictionary<double, int>();

			foreach (var num in nums)
			{
				if (!numOfOcurrances.ContainsKey(num) )
				{
					numOfOcurrances[num] = 1;
				}
				else
				{
					numOfOcurrances[num]++;
				}
			}

			foreach (var num in numOfOcurrances)
			{
				Console.WriteLine($"{num.Key} -> {num.Value} times");
			}
		}
	}
}
