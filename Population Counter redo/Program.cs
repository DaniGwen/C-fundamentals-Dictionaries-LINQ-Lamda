using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population_Counter_redo
{
	class Program
	{
		static void Main()
		{
			var dictCountriesCities = new Dictionary<string, Dictionary<string, long>>();
			var dictCity = new Dictionary<string, long>();

			while (true)
			{
				//input
				var input = Console.ReadLine();
				if (input == "report")
				{
					break;
				}
				var inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				string city = inputArgs[0];
				string country = inputArgs[1];
				long pop = long.Parse(inputArgs[2]);
				//input

				//add countries cities
				if (!dictCountriesCities.ContainsKey(country))
				{
					dictCity[city] = pop;
					dictCountriesCities[country] = dictCity;
				}
				else
				{
					dictCity = dictCountriesCities[country];

					if (!dictCity.ContainsKey(city))
					{
						dictCity.Add(city, pop);
					}
					else
					{
						dictCity[city] += pop;
					}
					dictCountriesCities[country] = dictCity;
				}
				//add countries cities
			}

			foreach (var cntry in dictCountriesCities.OrderByDescending(c => c.Value.Sum(y => y.Value)))
			{
				List<long> townSum = cntry.Value.Select(x => x.Value).ToList();
				Console.WriteLine($"{cntry.Key} (total population: {townSum.Sum()})");

				Console.Write($"=>{string.Join("=>", cntry.Value.OrderByDescending(x=>x.Value).Select(x=> $"{x.Key}: {x.Value}\r\n"))}");

			}
		}
	}
}

