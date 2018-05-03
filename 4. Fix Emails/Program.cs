using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Fix_Emails
{
	class Program
	{
		static void Main()
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			string name = Console.ReadLine();
			string mail = Console.ReadLine();

			while (name != "stop")
			{
				if (!dict.ContainsKey(name))
				{
					if (!mail.EndsWith(".us") || mail.EndsWith(".uk"))
					{
						dict.Add(name, mail);
					}
				}
				name = Console.ReadLine();
				mail = Console.ReadLine();
			}
			foreach (var email in dict)
			{
				Console.WriteLine($"{email.Key} -> {email.Value}");
			}
		}
	}
}
