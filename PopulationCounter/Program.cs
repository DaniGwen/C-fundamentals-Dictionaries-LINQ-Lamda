using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();
			string input = Console.ReadLine();

			while (input != "report")
			{
				string[] parameters = input.Split('|');

				string city = parameters[0];
				string country = parameters[1];
				long pop = long.Parse(parameters[2]);

				if (!countries.ContainsKey(country))
				{
					countries.Add(country, new Dictionary<string, long>());
					countries[country].Add(city, pop);
				}
				else
				{
					if (!countries[country].ContainsKey(city))
					{
						countries[country].Add(city, pop);
					}
				}
				input = Console.ReadLine();
			}

			//countries = countries.OrderBy(n => n.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);    //сортиран речник начин 1

			foreach (var country in countries.OrderByDescending(country => country.Value.Values.Sum()))                                // сортиране начин 2
			{
				Console.WriteLine($"{country.Key}(total population: {country.Value.Values.Sum()})");
				foreach (var city in country.Value.OrderByDescending(c => c.Value))
				{
					Console.WriteLine($"=>{city.Key}: {city.Value}");
				}
			}
		}
	}
}
