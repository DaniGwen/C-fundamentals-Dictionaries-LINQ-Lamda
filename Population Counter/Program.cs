using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population_Counter
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();

			var countriesAndCities = new Dictionary<string, Dictionary<string, int>>();

			while (true)
			{
				int totalPopulation = 0;
				if (input == "report")
				{
					foreach (var state in countriesAndCities)
					{
						Console.WriteLine(state.Key + " (Total population: {0}", totalPopulation);
						Console.Write("=>" + state.Value + ":");

						foreach (var pop in state.Value)
						{
							Console.WriteLine(" " + pop.Value);
						}
					}
				}

				var tokens = input.Split('|').ToList();
				string city = tokens[0];
				string country = tokens[1];
				int population = int.Parse(tokens[2]);

				if (countriesAndCities.ContainsKey(country))
				{
					if (countriesAndCities[country].ContainsKey(city))
					{
						countriesAndCities[country][city] = population;
					}
				}

				else
				{
					countriesAndCities[country][city] = population;
				}

				foreach (var item in countriesAndCities.Values)
				{
					foreach (var town in item)
					{
						totalPopulation += town.Value;
					}

				}


				input = Console.ReadLine();
			}
		}
	}
}
