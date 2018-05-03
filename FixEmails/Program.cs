using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
	class Program
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			string email = Console.ReadLine();

			Dictionary<string, string> nameEmail = new Dictionary<string, string>();

			while (true)
			{
				if (name == "stop")
				{
					foreach (var nameInDict in nameEmail)
					{
						Console.WriteLine($"{nameInDict.Key} -> {nameInDict.Value}");
					}
					break;
				}
				if (!nameEmail.ContainsKey(name))
				{
					nameEmail[name] = email;

					if (email.EndsWith("uk") || email.EndsWith("us"))
					{
						nameEmail.Remove(name);
					}
					
				}
				
				name = Console.ReadLine();
				email = Console.ReadLine();
			}
		}
	}
}
