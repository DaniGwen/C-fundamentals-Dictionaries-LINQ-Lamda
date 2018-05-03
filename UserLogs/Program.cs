using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
	class Program
	{
		static void Main()
		{
			var input = Console.ReadLine().Split().ToList();

			var users = new Dictionary<string, List<string>>();

			string command = "";
			while (true)
			{
				command = input[0];

				if (command == "end")
				{
					break;
				}

				int indexIP = command.IndexOf("=") + 1;
				string IP = command.Substring(indexIP);

				int indexUser = input[2].LastIndexOf("=") + 1;
				string user = command.Substring(indexUser);

				List<string> IPs = new List<string>();
				IPs.Add(IP);

				if (!users.ContainsKey(user))
				{
					users[user] = IPs;
				}
				else
				{
					users[user].AddRange(IPs);
				}
			}
			foreach (var user in users)
			{
				Console.WriteLine($"{user.Key}: ");

				List<string> IPs = user.Value;
				Dictionary<string, int> numOfIPs = new Dictionary<string, int>();

				foreach (var ip in IPs)
				{
					if (!numOfIPs.ContainsKey(ip))
					{
						numOfIPs[ip] = 1;
					}
					else
					{
						numOfIPs[ip] += 1;
					}
				}

				int count = numOfIPs.Count();
				foreach (var ip in numOfIPs)
				{
					count--;

					if (count > 0)
					{
						Console.WriteLine(ip.Key + " => " + ip.Value + ",");
					}
					else
					{
						Console.WriteLine(ip.Key + " => " + ip.Value + ".");
					}
				}
				Console.WriteLine();
			}

		}
	}
}
