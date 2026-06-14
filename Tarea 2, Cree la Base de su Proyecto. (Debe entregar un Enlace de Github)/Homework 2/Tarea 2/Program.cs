try
{
    List<string[]> products = new List<string[]>();

    bool running = true;

    while (running)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║     PHARMACY PRODUCT CONTROL         ║");
        Console.WriteLine("╠══════════════════════════════════════╣");
        Console.WriteLine("║  1. Add product                      ║");
        Console.WriteLine("║  2. List all products                ║");
        Console.WriteLine("║  3. Search product by name           ║");
        Console.WriteLine("║  4. Search product by laboratory     ║");
        Console.WriteLine("║  5. Modify product                   ║");
        Console.WriteLine("║  6. Delete product                   ║");
        Console.WriteLine("║  7. Exit                             ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.Write("\n Select an option (1-7): ");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("── ADD PRODUCT ──");
                Console.Write(" Product name: ");
                string name = Console.ReadLine();
                Console.Write(" Laboratory: ");
                string lab = Console.ReadLine();
                Console.Write(" Lot number: ");
                string lot = Console.ReadLine();
                Console.Write(" Stock (units): ");
                string stock = Console.ReadLine();
                Console.Write(" Expiration date (MM/DD/YYYY): ");
                string expDate = Console.ReadLine();

                products.Add(new string[] { name, lab, lot, stock, expDate });

                Console.WriteLine("\n Product added successfully.");
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("── PRODUCT LIST ──\n");

                if (products.Count == 0)
                {
                    Console.WriteLine(" No products registered.");
                }
                else
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.WriteLine($" [{i + 1}] Name: {products[i][0]}");
                        Console.WriteLine($"     Laboratory: {products[i][1]}");
                        Console.WriteLine($"     Lot: {products[i][2]}");
                        Console.WriteLine($"     Stock: {products[i][3]} units");
                        Console.WriteLine($"     Expiration: {products[i][4]}");
                        Console.WriteLine(" ──────────────────────────────────");
                    }
                }
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("── SEARCH BY NAME ──");
                Console.Write(" Enter product name: ");
                string searchName = Console.ReadLine().ToLower();
                bool foundName = false;

                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i][0].ToLower().Contains(searchName))
                    {
                        Console.WriteLine($"\n [{i + 1}] Name: {products[i][0]}");
                        Console.WriteLine($"     Laboratory: {products[i][1]}");
                        Console.WriteLine($"     Lot: {products[i][2]}");
                        Console.WriteLine($"     Stock: {products[i][3]} units");
                        Console.WriteLine($"     Expiration: {products[i][4]}");
                        foundName = true;
                    }
                }

                if (!foundName)
                {
                    Console.WriteLine("\n No product found with that name.");
                }
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("── SEARCH BY LABORATORY ──");
                Console.Write(" Enter laboratory name: ");
                string searchLab = Console.ReadLine().ToLower();
                bool foundLab = false;

                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i][1].ToLower().Contains(searchLab))
                    {
                        Console.WriteLine($"\n [{i + 1}] Name: {products[i][0]}");
                        Console.WriteLine($"     Laboratory: {products[i][1]}");
                        Console.WriteLine($"     Lot: {products[i][2]}");
                        Console.WriteLine($"     Stock: {products[i][3]} units");
                        Console.WriteLine($"     Expiration: {products[i][4]}");
                        foundLab = true;
                    }
                }

                if (!foundLab)
                {
                    Console.WriteLine("\n No product found for that laboratory.");
                }
                break;

            case "5":
                Console.Clear();
                Console.WriteLine("── MODIFY PRODUCT ──");

                if (products.Count == 0)
                {
                    Console.WriteLine(" No products registered.");
                    break;
                }

                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($" [{i + 1}] {products[i][0]} - Lab: {products[i][1]}");
                }

                Console.Write("\n Select product number to modify: ");
                int modIndex = int.Parse(Console.ReadLine()) - 1;

                if (modIndex < 0 || modIndex >= products.Count)
                {
                    Console.WriteLine("\n Invalid selection.");
                    break;
                }

                Console.Write($" New name ({products[modIndex][0]}): ");
                string newName = Console.ReadLine();
                Console.Write($" New laboratory ({products[modIndex][1]}): ");
                string newLab = Console.ReadLine();
                Console.Write($" New lot ({products[modIndex][2]}): ");
                string newLot = Console.ReadLine();
                Console.Write($" New stock ({products[modIndex][3]}): ");
                string newStock = Console.ReadLine();
                Console.Write($" New expiration date ({products[modIndex][4]}): ");
                string newExp = Console.ReadLine();

                if (newName != "") products[modIndex][0] = newName;
                if (newLab != "") products[modIndex][1] = newLab;
                if (newLot != "") products[modIndex][2] = newLot;
                if (newStock != "") products[modIndex][3] = newStock;
                if (newExp != "") products[modIndex][4] = newExp;

                Console.WriteLine("\n Product updated successfully.");
                break;

            case "6":
                Console.Clear();
                Console.WriteLine("── DELETE PRODUCT ──");

                if (products.Count == 0)
                {
                    Console.WriteLine(" No products registered.");
                    break;
                }

                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($" [{i + 1}] {products[i][0]} - Lab: {products[i][1]}");
                }

                Console.Write("\n Select product number to delete: ");
                int delIndex = int.Parse(Console.ReadLine()) - 1;

                if (delIndex < 0 || delIndex >= products.Count)
                {
                    Console.WriteLine("\n Invalid selection.");
                    break;
                }

                Console.Write($" Are you sure you want to delete '{products[delIndex][0]}'? (y/n): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm == "y")
                {
                    products.RemoveAt(delIndex);
                    Console.WriteLine("\n Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("\n Deletion cancelled.");
                }
                break;

            case "7":
                running = false;
                Console.WriteLine("\n Goodbye! Press any key to close...");
                break;

            default:
                Console.WriteLine("\n Invalid option. Please select a number between 1 and 7.");
                break;
        }

        if (running)
        {
            Console.Write("\n Press any key to return to menu...");
            Console.ReadKey();
        }
    }

    Console.ReadKey();
}
catch (Exception)
{
    Console.WriteLine("An error occurred ");
}