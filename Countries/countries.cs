using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries
{
	class countries
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			var countriesInContinents = new Dictionary<string, Dictionary<string, List<string>>>();

			for (int i = 0; i < n; i++)
			{
				var tokens = Console.ReadLine()
					.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				var continent = tokens[0];
				var country = tokens[1];
				var city = tokens[2];

				if (!countriesInContinents.ContainsKey(continent))
				{
					countriesInContinents[continent] = new Dictionary<string, List<string>>();
				}

				if (!countriesInContinents[continent].ContainsKey(country) )
				{
					countriesInContinents[continent][country] = new List<string>() ;
				}
				countriesInContinents[continent][country].Add(city);
			}
			foreach (var continent in countriesInContinents)
			{
				Console.WriteLine(continent.Key + ":");
				foreach (var country in continent.Value)
				{
					Console.Write("  " + country.Key + "-> ");
					Console.WriteLine(string.Join(", ", country.Value));
				}
			}
		}
	}
}
