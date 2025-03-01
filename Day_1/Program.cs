using System;
using System.IO;

namespace CombinedProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "output.txt"; // File to store text

            while (true)
            {
                Console.Write("\nEnter a value (or type 'exit' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                // Append input to the file
                File.AppendAllText(filePath, input + Environment.NewLine);

                Console.WriteLine("\n--- Parsed Values ---");

                // Integer Conversion
                if (int.TryParse(input, out int intValue))
                    Console.WriteLine($"✅ Integer: {intValue}");
                else
                    Console.WriteLine("❌ Invalid integer format.");

                // Boolean Conversion
                if (bool.TryParse(input, out bool boolValue))
                    Console.WriteLine($"✅ Boolean: {boolValue}");
                else
                    Console.WriteLine("❌ Invalid boolean format.");

                // DateTime Conversion
                if (DateTime.TryParse(input, out DateTime dateTimeValue))
                    Console.WriteLine($"✅ DateTime: {dateTimeValue}");
                else
                    Console.WriteLine("❌ Invalid DateTime format.");

                // Double Conversion
                if (double.TryParse(input, out double doubleValue))
                    Console.WriteLine($"✅ Double: {doubleValue}");
                else
                    Console.WriteLine("❌ Invalid double format.");

                // Decimal Conversion
                if (decimal.TryParse(input, out decimal decimalValue))
                    Console.WriteLine($"✅ Decimal: {decimalValue}");
                else
                    Console.WriteLine("❌ Invalid decimal format.");

                Console.WriteLine("----------------------");

                // Perform string operations if the input is not a number
                if (!int.TryParse(input, out _) && !double.TryParse(input, out _) && !bool.TryParse(input, out _) && !DateTime.TryParse(input, out _))
                {
                    Console.WriteLine("\n--- String Analysis ---");
                    Console.WriteLine($"1. Total characters: {input.Length}");
                    Console.WriteLine($"2. Count of 'l': {CountChar(input, 'l')}");
                    Console.WriteLine($"3. Formatted output: {FormatString(input)}");
                    Console.WriteLine("----------------------");
                }

                // Display updated file content
                Console.WriteLine("\n--- File Content ---");
                Console.WriteLine(File.ReadAllText(filePath));
                Console.WriteLine("----------------------");
            }

            Console.WriteLine("\nProgram exited.");
        }

        static int CountChar(string str, char ch)
        {
            int count = 0;
            foreach (char c in str)
                if (c == ch) count++;
            return count;
        }

        static string FormatString(string str)
        {
            return "*" + string.Join("*", str.ToUpper().ToCharArray()) + "*";
        }
    }
}
