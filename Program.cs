using System;

class Program
{
    static void Main()
    {
        int? lastChoice = null;

        while (true)
        {
            // 1. Display menu
            Console.WriteLine("\n--- Unit Converter Pro ---");
            Console.WriteLine("1. Kilometers ↔ Miles");
            Console.WriteLine("2. Kilograms ↔ Pounds");
            Console.WriteLine("3. Celsius ↔ Fahrenheit");
            Console.WriteLine("4. Meters ↔ Feet");
            Console.WriteLine("5. Exit");

            if (lastChoice.HasValue)
                Console.WriteLine($"[Press Enter to repeat last choice ({lastChoice})]");

            // 2. Read choice
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine()?.Trim();

            int choice;
            if (string.IsNullOrEmpty(input) && lastChoice.HasValue)
            {
                choice = lastChoice.Value;
            }
            else if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. Please enter a number 1-5.");
                continue;
            }

            if (choice == 5) // Exit
            {
                Console.WriteLine("Exiting Unit Converter Pro. Goodbye!");
                break;
            }

            // 3. Read value for conversion
            double value;
            while (true)
            {
                Console.Write("Enter value to convert: ");
                string valInput = Console.ReadLine()?.Trim();
                if (double.TryParse(valInput, out value))
                    break;
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }

            double result = 0;
            string fromUnit = "", toUnit = "";

            // 4. Perform chosen conversion
            switch (choice)
            {
                case 1: // km ↔ mi
                    Console.Write("Convert (1) km→mi or (2) mi→km? ");
                    string dir1 = Console.ReadLine()?.Trim();
                    if (dir1 == "2")
                    {
                        result = value * 1.60934;
                        fromUnit = "mi"; toUnit = "km";
                    }
                    else
                    {
                        result = value * 0.621371;
                        fromUnit = "km"; toUnit = "mi";
                    }
                    break;

                case 2: // kg ↔ lb
                    Console.Write("Convert (1) kg→lb or (2) lb→kg? ");
                    string dir2 = Console.ReadLine()?.Trim();
                    if (dir2 == "2")
                    {
                        result = value * 0.453592;
                        fromUnit = "lb"; toUnit = "kg";
                    }
                    else
                    {
                        result = value * 2.20462;
                        fromUnit = "kg"; toUnit = "lb";
                    }
                    break;

                case 3: // C ↔ F
                    Console.Write("Convert (1) C→F or (2) F→C? ");
                    string dir3 = Console.ReadLine()?.Trim();
                    if (dir3 == "2")
                    {
                        result = (value - 32) * 5 / 9;
                        fromUnit = "°F"; toUnit = "°C";
                    }
                    else
                    {
                        result = (value * 9 / 5) + 32;
                        fromUnit = "°C"; toUnit = "°F";
                    }
                    break;

                case 4: // m ↔ ft
                    Console.Write("Convert (1) m→ft or (2) ft→m? ");
                    string dir4 = Console.ReadLine()?.Trim();
                    if (dir4 == "2")
                    {
                        result = value * 0.3048;
                        fromUnit = "ft"; toUnit = "m";
                    }
                    else
                    {
                        result = value * 3.28084;
                        fromUnit = "m"; toUnit = "ft";
                    }
                    break;
            }

            // 5. Print result
            Console.WriteLine($"{value:F2} {fromUnit} = {result:F2} {toUnit}");

            // 6. Update lastChoice
            lastChoice = choice;
        }
    }
}