using System;


class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        while (true)
        {
            var commandInput = Console.ReadLine();

            if (commandInput == "Reveal")
            {
                break;
            }

            var commandArgs = commandInput.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            var command = commandArgs[0];

            switch (command)
            {
                case "InsertSpace":
                    var index = int.Parse(commandArgs[1]);

                    input = input.Insert(index, " ");
                    Console.WriteLine(input);
                    break;
                case "ChangeAll":
                    var substring = commandArgs[1];
                    var replacement = commandArgs[2];

                    input = input.Replace(substring, replacement);
                    Console.WriteLine(input);
                    break;
                case "Reverse":

                    if (!input.Contains(commandArgs[1]))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        input = ReverseString(input, commandArgs[1]);

                        Console.WriteLine(input);
                    }
                    break;
            }
        }
        Console.WriteLine($"You have a new text message: {input}");
    }

    private static string ReverseString(string input, string args)
    {
        var reversedArgs = string.Empty;

        for (int i = args.Length - 1; i >= 0; i--)
        {
            reversedArgs += args[i];
        }

        var pos = input.IndexOf(args);

        input = input.Remove(pos);

        return input + reversedArgs;
    }
}

