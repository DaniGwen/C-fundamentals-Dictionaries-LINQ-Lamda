using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictMatches = new Dictionary<string, string>();

            var pattern = @"(([@]{1})(?<wordOne>[a-zA-Z]{3,})[@]{1}[@]{1}(?<wordTwo>[a-zA-Z]{3,})[@]{1})|(([#]{1})(?<wordOne2>[a-zA-Z]{3,})[#]{1}[#]{1}(?<wordTwo2>[a-zA-Z]{3,})[#]{1})";


            var regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var reversedWordTwo = string.Empty;
                var reversedWordTwo2 = string.Empty;

                var wordTwo = match.Groups["wordTwo"].Value;
                var wordOne = match.Groups["wordOne"].Value;

                var wordOne2 = match.Groups["wordOne2"].Value;
                var wordTwo2 = match.Groups["wordTwo2"].Value;

                var isDifferent = false;

                if (wordOne != "")
                {
                    for (int i = wordTwo.Length - 1; i >= 0; i--)
                    {
                        reversedWordTwo += wordTwo[i];
                    }

                    for (int i = 0; i < wordOne.Length; i++)
                    {

                        if (wordOne.Length != reversedWordTwo.Length)
                        {
                            isDifferent = true;
                            break;
                        }
                        if (wordOne[i] != reversedWordTwo[i])
                        {
                            isDifferent = true;
                        }
                    }

                    if (!isDifferent)
                    {
                        dictMatches[wordOne] = wordTwo;
                    }
                }
                else
                {
                    for (int i = wordTwo2.Length - 1; i >= 0; i--)
                    {
                        reversedWordTwo2 += wordTwo2[i];
                    }

                    for (int i = 0; i < wordOne2.Length; i++)
                    {

                        if (wordOne2.Length != reversedWordTwo2.Length)
                        {
                            isDifferent = true;
                            break;
                        }
                        if (wordOne2[i] != reversedWordTwo2[i])
                        {
                            isDifferent = true;
                            break;
                        }
                    }

                    if (!isDifferent)
                    {
                        dictMatches[wordOne2] = wordTwo2;
                    }
                }
            }


            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {

                Console.WriteLine($"{matches.Count} word pairs found!");
                if (dictMatches.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");

                    var sb = new StringBuilder();

                    foreach (var mirrorWord in dictMatches)
                    {
                        sb.Append($"{mirrorWord.Key} <=> {mirrorWord.Value}, ");
                    }

                    Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
                }
            }

        }
    }
}
