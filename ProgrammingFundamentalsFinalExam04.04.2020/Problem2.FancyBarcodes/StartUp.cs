using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2.FancyBarcodes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var patternBarcode = @"^(@{1}#+)(?<middleGroup>[A-Z][^\W_]{4,}[A-Z])(@{1}#+)$";
            var digits = @"\d+";

            var defaultProductGroup = "00";

            for (int i = 0; i < lines; i++)
            {
                var barcodeInput = Console.ReadLine();

                var barcode = Regex.Match(barcodeInput, patternBarcode);
                var matchDigits = new Regex(digits);

                if (!barcode.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    var middleGroup = barcode.Groups["middleGroup"].Value;

                    if (matchDigits.IsMatch(middleGroup))
                    {
                        var sb = new StringBuilder();

                        foreach (Match item in matchDigits.Matches(middleGroup))
                        {
                            sb.Append(item);
                        }

                        Console.WriteLine("Product group: " + sb.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Product group: " + defaultProductGroup);
                    }
                }
            }
        }
    }
}
