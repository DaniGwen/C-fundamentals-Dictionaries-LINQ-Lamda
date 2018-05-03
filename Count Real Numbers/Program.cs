using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Real_Numbers
{
	class Program
	{
		static void Main()
		{
			double[] nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

			var counts = new SortedDictionary<double, int>();

			foreach (var num in nums)
			{
				if (counts.ContainsKey(num))
				{
					counts[num]++;
				}
				else
				{
					counts[num] = 1;
				}
			}
			foreach (var count in counts)
			{
				Console.WriteLine($"{count.Key} -> {count.Value}");
			}
		} 
	}
}
