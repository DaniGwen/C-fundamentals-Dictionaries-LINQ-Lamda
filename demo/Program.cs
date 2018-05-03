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
			Dictionary<string, string> phonebook = new Dictionary<string, string>();
			string input = Console.ReadLine();
			while (input != "end")
			{
				
				string[] paramInput = input
					.ToLower()
					.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.ToArray();
				string command = paramInput[0];
				

				if (command == "a")
				{
					string key = paramInput[1];
					string value = paramInput[2];
					phonebook[key] = value;
					if (phonebook.ContainsKey(key))
					{
						phonebook[key] = value;
					}
				}
				else if (command == "s")
				{
					string key = paramInput[1];

					if (phonebook.ContainsKey(paramInput[1]))
					{
						string value = paramInput[2];
						Console.WriteLine($"{key} -> {value}");
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
