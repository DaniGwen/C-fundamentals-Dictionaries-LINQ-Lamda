using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rallyEndurance
{
	class Program
	{
		static void Main(string[] args)
		{
			var drivers = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

			var zones = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

			var checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

			foreach (var driver in drivers)
			{
				double fuel = driver[0];
				int reachedZone = 0;
				bool isFuelOver = false;

				for (int i = 0; i < zones.Count; i++)
				{
					if (checkpoints.Contains(i))
					{
						fuel += zones[i];
					}
					else
					{
						fuel -= zones[i];
					}

					if (fuel <= 0)
					{
						isFuelOver = true;
						reachedZone = i;
						break;
					}
				}
				if (isFuelOver == true)
				{
					Console.WriteLine($"{driver} - reached {reachedZone }");
				}
				else
				{
					Console.WriteLine($"{driver} - fuel left {fuel:F2}");
				}

			}
		}
	}
}
