using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fullaround
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, int> dict = new Dictionary<string, int>();
			dict["az"] = 31;
			dict["ti"] = 20;
			dict["toi"] = 35;
			dict.Add("tq", 27);

			if (dict.ContainsKey("ti"))
			{
				dict.Add
			}
			
			foreach (var name in dict)
			{
				Console.WriteLine($"{name.Key} -> {name.Value}");
			}
		}
	}
}
