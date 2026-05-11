using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp2.UI
{
    internal class InputHelper
    {
        public static int ReadInt(string prompt)
        {
            int value;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value > 0)
                    return value;

                Console.WriteLine("Invalid number. Try again.");
            }
        }


        public static string ReadString(string prompt)
        {
            string value;

            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(value))
                    return value;

                Console.WriteLine("Input cannot be empty. Try again.");
            }
        }
    }
}
