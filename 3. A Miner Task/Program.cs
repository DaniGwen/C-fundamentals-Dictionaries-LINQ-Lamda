using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.A_Miner_Task
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			Dictionary<string, int> collector = new Dictionary<string, int>();

			while (input != "stop")
			{
				int quantity = 0;
				quantity = int.Parse(Console.ReadLine());

				if (collector.ContainsKey(input))
				{
					collector[input] += quantity;
				}
				else
				{
					collector.Add(input, quantity);
				}
				input = Console.ReadLine();
			}
			foreach (var item in collector)
			{

				Console.WriteLine($"{item.Key} -> {item.Value}");
			}
			
		}
	}
}

