using System;
using System.Text;

namespace ProgrammingFundamentalsFinalExam04042020
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var password = input;

            var command = Console.ReadLine();

            var sb = new StringBuilder();

            while (command != "Done")
            {
                var commandArgs = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "TakeOdd":

                        for (int i = 1; i < password.Length; i += 2)
                        {
                            sb.Append(password[i]);
                        }

                        Console.WriteLine(sb.ToString());
                        break;
                    case "Cut":
                        var index = int.Parse(commandArgs[1]);
                        var length = int.Parse(commandArgs[2]);

                        sb.Remove(index, length);

                        Console.WriteLine(sb.ToString());

                        break;
                    case "Substitute":
                        var substring = commandArgs[1];
                        var substitute = commandArgs[2];
                        password = sb.ToString();

                        if (password.IndexOf(substring) != -1)
                        {
                            sb.Replace(substring, substitute);

                            Console.WriteLine(sb.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {sb.ToString()}");
        }
    }
}
