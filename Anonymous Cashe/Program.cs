using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Cashe
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();

			Dictionary<string, Dictionary<string, long>> dataSET = new Dictionary<string, Dictionary<string, long>>();
			Dictionary<string, int> cashe = new Dictionary<string, int>();

			while (input != "thetinggoesskrra")
			{
				var inputArgs = input.Split(new[] {' ', '-', '>', '|'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

				if (inputArgs.Length == 1)
				{
					string set = inputArgs[0];
					cashe.Add(set,new int());
				}
				else
				{
					string dataKey = inputArgs[0];
					long dataSize = long.Parse(inputArgs[1]);
					string dataSet = inputArgs[2];

					if (!dataSET.ContainsKey(dataSet))
					{
						dataSET.Add(dataSet, new Dictionary<string, long>());
					}
					dataSET[dataSet][dataKey] = dataSize;
				}
				input = Console.ReadLine();
			}

			if (dataSET.Count > 0)
			{
				var result = dataSET.OrderByDescending(s => s.Value.Sum(l => l.Value)).First();

				Console.WriteLine($"Data Set: , {result.Key}, Total Size: {result.Value.Sum(v => v.Value)}");

				foreach (var name in result.Value)
				{
					Console.WriteLine($"$.{name.Key}");
				}
			}
		}
	}
}
