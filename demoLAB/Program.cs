using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> shop = new Dictionary<string, int>();

			while (true)
			{
				string input = Console.ReadLine();
				if (input.Equals("exam time")) break;
				string[] command = input.Split(' ');
				if (input == "shopping time") continue;
				string product = command[1];
				int quantity = int.Parse(command[2]);
				if (command[0].Equals("stock"))
				{
					if (!shop.ContainsKey(product))
					{
						shop.Add(product, quantity);
					}
					else
					{
						shop[product] += quantity;
					}
				}
				else if (command[0].Equals("buy"))
				{
					if (!shop.ContainsKey(product))
					{
						Console.WriteLine($"{product} doesn't exist");
					}
					else if (shop.ContainsKey(product))
					{
						int stock = shop[product];
						if (stock == 0)
						{
							Console.WriteLine($"{product} out of stock");
							break;
						}
						else if (quantity > stock)
						{
							shop[product] = 0;
						}
						else
						{
							shop[product] -= quantity;
						}
					}
				}
			}
			foreach (var item in shop)
			{
				if (item.Value == 0)
				{
					continue;
				}
				Console.WriteLine($"{item.Key} -> {item.Value}");
			}

		}
	}
}