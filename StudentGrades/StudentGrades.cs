using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
	class StudentGrades
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

			for (int i = 0; i < n; i++)
			{
				var token = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string name = token[0];
				double grade = double.Parse(token[1]);

				if (!grades.ContainsKey(name))
				{
					grades[name] = new List<double> ();
					grades[name].Add(grade);
				}

			}

			foreach (var item in grades)
			{
				var name = item.Key;
				var studentGrades = item.Value;
				var average = studentGrades.Average();

				Console.Write($"{name} -> ");

				foreach (var grade in studentGrades)
				{
					Console.WriteLine($"{grade:F2}");
					Console.WriteLine($" {average:f2}");
				}
				Console.WriteLine();
				
			}
		}
	}
}
