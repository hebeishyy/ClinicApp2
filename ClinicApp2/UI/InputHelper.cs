using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp2.UI
{
    internal class InputHelper
    {
        public static DateTime ReadDateTime(string prompt)
        {
            DateTime date;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out date))
                    return date;

                Console.WriteLine("Invalid date. Try again (example: 2026-05-15 14:00)");
            }
        }
        public static string ReadPhone(string prompt)
        {
            string phone;

            while (true)
            {
                Console.Write(prompt);
                phone = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(phone))
                {
                    Console.WriteLine("Phone cannot be empty.");
                    continue;
                }

                bool allDigits = phone.All(char.IsDigit);

                if (allDigits && phone.Length >= 10)
                    return phone;

                Console.WriteLine("Invalid phone. Use digits only (min 10 digits).");
            }
        }
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
