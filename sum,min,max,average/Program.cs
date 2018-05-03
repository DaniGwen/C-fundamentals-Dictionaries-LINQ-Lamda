using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_min_max_average
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			List<int> result = new List<int>();

			for (int i = 0; i < n; i++)
			{
			
				var num = int.Parse(Console.ReadLine());
				result.Add(num);
			}
			Console.WriteLine("Sum = {0}", result.Sum());
			Console.WriteLine("Min = {0}", result.Min());
			Console.WriteLine("Max = {0}", result.Max());
			Console.WriteLine("Average = {0}", result.Average());
		}
	}
}
