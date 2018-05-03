using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Dict_Ref
{
	class StartPr
	{
		static void Main(string[] args)
		{
			var dictNamesValues = new Dictionary<string, int>();

			while (true)
			{
				var input = Console.ReadLine();
				if (input == "end")
				{
					foreach (var item in dictNamesValues)
					{
						Console.WriteLine($"{item.Key} === {item.Value}");
					}
					break;
				}

				var inputSplit = input.Split(' ').ToArray();
				string name = inputSplit[0];
				int value = 0;
				var valueOrName = int.TryParse(inputSplit[2], out value);

				if (!dictNamesValues.ContainsKey(name))
				{
					dictNamesValues.Add(name, value);

				}
				else
				{
					dictNamesValues[name] = value;
				}

				if (valueOrName == false)
				{
					string secondName = inputSplit[2];

					if (dictNamesValues.ContainsKey(secondName))
					{
						dictNamesValues[name] = dictNamesValues[secondName];
					}
					else // else if (!dictNamesValues.ContainsKey(secondName) )
					{
						continue;
					}
				}
			}
		}
	}
}
