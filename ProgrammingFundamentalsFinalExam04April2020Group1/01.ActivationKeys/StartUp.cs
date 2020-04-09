using System;
using System.Linq;
using System.Text;

namespace ProgrammingFundamentalsFinalExam04April2020Group1
{
    class StartUp
    {
        static void Main()
        {
            var rawKey = Console.ReadLine();

            var startIndex = 0;
            var endIndex = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Generate")
                {
                    break;
                }

                var commandArgs = input.Split(">", StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];
                var subCommand = commandArgs.Skip(1).ToArray();

                switch (command)
                {
                    case "Contains":
                        var substring = subCommand[0];

                        if (rawKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        switch (subCommand[0])
                        {
                            case "Upper":
                                startIndex = int.Parse(subCommand[1]);
                                endIndex = int.Parse(subCommand[2]);

                                rawKey = SubstringToUpper(startIndex, endIndex, rawKey);
                                Console.WriteLine(rawKey);
                                break;
                            case "Lower":
                                startIndex = int.Parse(subCommand[1]);
                                endIndex = int.Parse(subCommand[2]);

                                rawKey = SubstringToLower(startIndex, endIndex, rawKey);
                                Console.WriteLine(rawKey);
                                break;
                        }
                        break;
                    case "Slice":
                        startIndex = int.Parse(subCommand[0]);
                        endIndex = int.Parse(subCommand[1]);

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            rawKey = rawKey.Remove(startIndex, 1);
                        }

                        Console.WriteLine(rawKey);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }

        private static string SubstringToLower(int startIndex, int endIndex, string rawKey)
        {
            var modifiedSubstring = new StringBuilder();
            var originalSubstring = new StringBuilder();

            for (int i = startIndex; i < endIndex; i++)
            {
                originalSubstring.Append(rawKey[i]);
                modifiedSubstring.Append(rawKey[i].ToString().ToLower());
            }

            rawKey = rawKey.Replace(originalSubstring.ToString(), modifiedSubstring.ToString());
            return rawKey;
        }

        private static string SubstringToUpper(int startIndex, int endIndex, string rawKey)
        {
            var modifiedSubstring = new StringBuilder();
            var originalSubstring = new StringBuilder();

            for (int i = startIndex; i < endIndex; i++)
            {
                originalSubstring.Append(rawKey[i]);
                modifiedSubstring.Append(rawKey[i].ToString().ToUpper());
            }

            rawKey = rawKey.Replace(originalSubstring.ToString(), modifiedSubstring.ToString());
            return rawKey;
        }
    }
}
