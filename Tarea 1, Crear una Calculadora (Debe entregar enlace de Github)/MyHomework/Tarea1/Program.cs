try
{
    bool running = true;

    while (running)
    {
        Console.Clear();
        Console.WriteLine("╔═════════════════════════════╗");
        Console.WriteLine("║      SIMPLE CALCULATOR      ║");
        Console.WriteLine("╠═════════════════════════════╣");
        Console.WriteLine("║  1. Add                     ║");
        Console.WriteLine("║  2. Subtract                ║");
        Console.WriteLine("║  3. Multiply                ║");
        Console.WriteLine("║  4. Divide                  ║");
        Console.WriteLine("║  5. Check student grade     ║");
        Console.WriteLine("║  6. Exit                    ║");
        Console.WriteLine("╚═════════════════════════════╝");
        Console.Write("\n Select an option (1-6): ");

        string option = Console.ReadLine();

        if (option == "6")
        {
            running = false;
            Console.WriteLine("\n Goodbye! Press any key to close...");
            break;
        }

        if (option == "5")
        {
            Console.Write("\n Enter student grade (0-100): ");
            double grade = double.Parse(Console.ReadLine());
            string status = grade >= 70 ? "PASSED ✓" : "FAILED ✗";
            Console.WriteLine($"\n Result: The student {status} with a grade of {grade}.");
            Console.Write("\n Press any key to return to menu...");
            Console.ReadKey();
            continue;
        }

        bool validOption = option == "1" || option == "2" || option == "3" || option == "4";

        if (!validOption)
        {
            Console.WriteLine("\n Invalid option. Please select a number between 1 and 6.");
            Console.Write(" Press any key to try again...");
            Console.ReadKey();
            continue;
        }

        Console.Write("\n How many numbers do you want to use? (minimum 2)(max whatever you want): ");
        int count = int.Parse(Console.ReadLine());

        if (count < 2)
        {
            Console.WriteLine("\n You must enter at least 2 numbers.");
            Console.Write(" Press any key to try again...");
            Console.ReadKey();
            continue;
        }

        double[] numbers = new double[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($" Enter number {i + 1}: ");
            numbers[i] = double.Parse(Console.ReadLine());
        }

        double result = numbers[0];
        bool divisionError = false;

        for (int i = 1; i < count; i++)
        {
            switch (option)
            {
                case "1":
                    result += numbers[i];
                    break;
                case "2":
                    result -= numbers[i];
                    break;
                case "3":
                    result *= numbers[i];
                    break;
                case "4":
                    if (numbers[i] == 0)
                    {
                        divisionError = true;
                    }
                    else
                    {
                        result /= numbers[i];
                    }
                    break;
            }
        }

        string[] symbols = { "+", "-", "*", "/" };
        string symbol = symbols[int.Parse(option) - 1];

        Console.WriteLine("\n ─────────────────────────────");
        if (divisionError)
        {
            Console.WriteLine(" Error: Cannot divide by zero.");
        }
        else
        {
            Console.Write(" Result: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(i < count - 1 ? $"{numbers[i]} {symbol} " : $"{numbers[i]}");
            }
            Console.WriteLine($" = {result}");
        }
        Console.WriteLine(" ─────────────────────────────");

        Console.Write("\n Press any key to return to menu...");
        Console.ReadKey();
    }

    Console.ReadKey();
}
catch (Exception)
{
    Console.WriteLine("An error occurred ");
}