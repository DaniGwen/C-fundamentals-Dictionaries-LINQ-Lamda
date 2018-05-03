using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raznomernosti
{
	class Program
	{
		static void Main(string[] args)
		{
			int num = int.Parse(Console.ReadLine());

			int[] array = new int[num];
			int sum = 0;
			int count = 0;

			if (num <= 30)
			{
				for (int i = 0; i < num; i++)
				{
					array[i] = int.Parse(Console.ReadLine());
				}
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != 0)
					{
						sum += array[i];
					}
					if (array[i] == 0)
					{
						count++;
					}
				}

			}
			Console.WriteLine(string.Join(" ", array));
			Console.WriteLine("sum -> {0}",sum);
			Console.WriteLine("count of zero -> {0}", count);

		}
	}
}
