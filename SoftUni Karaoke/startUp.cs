using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Karaoke
{
	class startUp
	{
		static void Main(string[] args)
		{
			HashSet<string> participants = new HashSet<string>(Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());

			HashSet<string> songs = new HashSet<string>(Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());

			var participantsDict = new Dictionary<string, SortedSet<string>>();

			while (true)
			{
				string input = Console.ReadLine();

				if (input == "dawn")
				{
					break;
				}

				string[] inputArgs = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

				string singer = inputArgs[0];
				string song = inputArgs[1];
				string award = inputArgs[2];

				if (!participants.Contains(singer) || !songs.Contains(song))
				{
					continue;
				}

				if (!participantsDict.ContainsKey(singer))
				{
					participantsDict.Add(singer, new SortedSet<string>());
				}

				participantsDict[singer].Add(award);
			}

			if (participantsDict.Count == 0)
			{
				Console.WriteLine("No awards");
				return;
			}

			foreach (var participant in participantsDict.OrderByDescending(p => p.Value.Count).ThenBy(p => p.Key))
			{
				Console.WriteLine($"{participant.Key}: {participant.Value.Count}");

				foreach (var prize in participant.Value)
				{
					Console.WriteLine($"--{prize}");
				}
			}
		}
	}
}
