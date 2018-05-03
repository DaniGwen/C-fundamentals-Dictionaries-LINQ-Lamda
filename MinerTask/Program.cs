using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerTask
{
	class Program
	{
		static void Main(string[] args)
		{
			var resource = Console.ReadLine().ToLower();
			var quantity = Console.ReadLine().ToLower();

			var resourseCollect = new Dictionary<string, int>();


			while (true)
			{
				if (resource == "stop" || quantity.ToString() == "stop")
				{
					foreach (var item in resourseCollect)
					{
						Console.WriteLine($"{item.Key} -> {item.Value}");
					}
					break;
				}
				if (!resourseCollect.ContainsKey(resource))
				{
					resourseCollect[resource] = int.Parse(quantity);
				}
				else
				{
					resourseCollect[resource] += int.Parse(quantity);
				}

				



				resource = Console.ReadLine().ToLower();
				quantity = Console.ReadLine().ToLower();
			}
		}
	}
}
