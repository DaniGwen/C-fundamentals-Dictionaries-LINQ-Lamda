using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Mixed_Phones
{
	class StartPr
	{
		static void Main(string[] args)
		{
			var dictPhoneBook = new SortedDictionary<string, long>();

			while (true)
			{
				string input = Console.ReadLine();
				if (input == "Over")
				{
					foreach (var person in dictPhoneBook)
					{
						Console.WriteLine($"{person.Key} -> {person.Value}");
					}
					break;
				}

				var inputArgs = input.Split(new[] { ':', ' ' }, StringSplitOptions .RemoveEmptyEntries).ToArray();

				long number = 0;
				var name = inputArgs[0];
				var numberParse = long.TryParse(inputArgs[1], out number);

				if (numberParse == true)
				{
					if (!dictPhoneBook.ContainsKey(name))
					{
						dictPhoneBook.Add(name, number);
					}
					else
					{
						dictPhoneBook[name] = number;
					}
				}
				else if (numberParse == false)
				{
					name = inputArgs[1];
					number = int.Parse(inputArgs[0]);

					if (!dictPhoneBook.ContainsKey(name))
					{
						dictPhoneBook.Add(name, number);
					}
					else
					{
						dictPhoneBook[name] = number;
					}
				}
			}
		}
	}
}
