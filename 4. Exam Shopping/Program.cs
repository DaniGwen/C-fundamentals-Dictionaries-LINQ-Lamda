using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Exam_Shopping
{
	class Program
	{
		static void Main()
		{
			var dictShop = new Dictionary<string, int>();

			while (true)
			{
				string input = Console.ReadLine();
				var splitInput = input.Split(new[] { ' ' }).ToArray();

				string stock = "";
				int quantity = 0;

				if (input == "shopping time")
				{
					input = Console.ReadLine();

					var inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

					while (true)
					{
						if (inputArgs[0] != "buy")
						{
							break;
						}

						stock = inputArgs[1];
						quantity = int.Parse(inputArgs[2]);

						if (!dictShop.ContainsKey(stock))
						{
							Console.WriteLine($"{stock} doesn't exist");
						}
						else if (dictShop[stock] == 0 || dictShop[stock] < 0)
						{
							Console.WriteLine($"{stock} out of stock");
						}
						else if (quantity >= dictShop[stock])
						{
							dictShop[stock] = 0;
						}
						else if (dictShop[stock] > quantity)
						{
							dictShop[stock] -= quantity;
						}
						input = Console.ReadLine();

						inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
					}
				}

				else if (input == "exam time")
				{
					foreach (var item in dictShop)
					{
						if (item.Value > 0)
						{
							Console.WriteLine($"{item.Key} -> {item.Value}");
						}
					}
					return;
				}

				else if (splitInput[0] == "stock")
				{
					stock = splitInput[1];
					quantity = int.Parse(splitInput[2]);

					if (!dictShop.ContainsKey(stock))
					{
						dictShop.Add(stock, quantity);
					}
					else
					{
						dictShop[stock] += quantity;
					}
				}
			}
		}
	}
}
