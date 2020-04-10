using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var emojiPattern = @"([:]{2}|[*]{2})(?<middleSection>[A-Z][a-z]{2,})\1";

            //Find  Cool treshold
            var digitRegex = new Regex(@"\d");

            var matchesDigits = digitRegex.Matches(text);

            ulong coolTreshold = ulong.Parse(matchesDigits[0].Value);

            for (int i = 1; i < matchesDigits.Count; i++)
            {
                coolTreshold *= ulong.Parse(matchesDigits[i].Value);
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");

            //Find Cool emojis
            var emojiRegex = new Regex(emojiPattern);

            var emojiMatches = emojiRegex.Matches(text);

            ulong resultEmojiChars = 0;

            var emojis = new List<string>();

            foreach (Match emoji in emojiMatches)
            {
                resultEmojiChars = (ulong)emoji.Groups["middleSection"].Value.Sum(c => c);

                if (resultEmojiChars > coolTreshold)
                {
                    emojis.Add(emoji.Value);
                }
            }

            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

            foreach (var emoji in emojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
