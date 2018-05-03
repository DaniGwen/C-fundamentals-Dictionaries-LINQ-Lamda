using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Phonebook
{
	class Program
	{
		static void Main()
		{
			SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
			var input = Console.ReadLine();

			while (input != "END")
			{
				string[] input_Details = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string command = input_Details[0];

				if (command == "A")
				{
					if (input_Details.Length > 3)
					{
						string key = input_Details[1] + " " + input_Details[2];
						string value = input_Details[3];
						phonebook[key] = value;
					}
					else
					{
						string key = input_Details[1];
						string value = input_Details[2];
						phonebook[key] = value;
					}
				}

				if (command == "ListAll")
				{
					foreach (var item in phonebook.Keys)
					{
						Console.WriteLine("{0} -> {1}", item, phonebook[item]);
					}
					return;
				}

				else if (command == "S")
				{
					string key = input_Details[1];
					if (phonebook.ContainsKey(key))
					{
						Console.WriteLine($"{key} -> {phonebook[key]}");
					}
					else
					{
						Console.WriteLine($"Contact {key} does not exist.");
					}
				}


				input = Console.ReadLine();
			}

		}
	}
}
