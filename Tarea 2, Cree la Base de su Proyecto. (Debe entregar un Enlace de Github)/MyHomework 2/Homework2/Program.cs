try
{
    Dictionary<int, string> names = new Dictionary<int, string>();
    Dictionary<int, string> laboratories = new Dictionary<int, string>();
    Dictionary<int, string> lots = new Dictionary<int, string>();
    Dictionary<int, int> stocks = new Dictionary<int, int>();
    Dictionary<int, DateTime> expirations = new Dictionary<int, DateTime>();
    List<int> ids = new List<int>();

    bool running = true;

    while (running)
    {
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. List Products");
        Console.WriteLine("3. Search by Name");
        Console.WriteLine("4. Search by Laboratory");
        Console.WriteLine("5. Modify Product");
        Console.WriteLine("6. Delete Product");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                int newId = ids.Count == 0 ? 1 : ids[ids.Count - 1] + 1;
                ids.Add(newId);

                Console.Write("Product name: ");
                names.Add(newId, Console.ReadLine());

                Console.Write("Laboratory: ");
                laboratories.Add(newId, Console.ReadLine());

                Console.Write("Lot number: ");
                lots.Add(newId, Console.ReadLine());

                Console.Write("Stock (units): ");
                stocks.Add(newId, Convert.ToInt32(Console.ReadLine()));

                Console.Write("Expiration date (yyyy-MM-dd): ");
                expirations.Add(newId, Convert.ToDateTime(Console.ReadLine()));

                Console.WriteLine("Product added successfully");
                break;

            case 2:
                if (ids.Count == 0)
                {
                    Console.WriteLine("No products registered");
                    break;
                }

                Console.WriteLine("Id   Name   Laboratory   Lot   Stock   Expiration");
                Console.WriteLine("--------------------------------------------------");
                foreach (int id in ids)
                {
                    Console.WriteLine($"{id}   {names[id]}   {laboratories[id]}   {lots[id]}   {stocks[id]}   {expirations[id].ToShortDateString()}");
                }
                break;

            case 3:
                Console.Write("Enter product name: ");
                string searchName = Console.ReadLine().ToLower();
                bool foundName = false;

                foreach (int id in ids)
                {
                    if (names[id].ToLower().Contains(searchName))
                    {
                        Console.WriteLine($"{id}   {names[id]}   {laboratories[id]}   {lots[id]}   {stocks[id]}   {expirations[id].ToShortDateString()}");
                        foundName = true;
                    }
                }

                if (!foundName)
                {
                    Console.WriteLine("No product found with that name");
                }
                break;

            case 4:
                Console.Write("Enter laboratory name: ");
                string searchLab = Console.ReadLine().ToLower();
                bool foundLab = false;

                foreach (int id in ids)
                {
                    if (laboratories[id].ToLower().Contains(searchLab))
                    {
                        Console.WriteLine($"{id}   {names[id]}   {laboratories[id]}   {lots[id]}   {stocks[id]}   {expirations[id].ToShortDateString()}");
                        foundLab = true;
                    }
                }

                if (!foundLab)
                {
                    Console.WriteLine("No product found for that laboratory");
                }
                break;

            case 5:
                if (ids.Count == 0)
                {
                    Console.WriteLine("No products registered");
                    break;
                }

                foreach (int id in ids)
                {
                    Console.WriteLine($"{id}   {names[id]}   {laboratories[id]}");
                }

                Console.Write("Enter product id to modify: ");
                int modId = Convert.ToInt32(Console.ReadLine());

                if (!ids.Contains(modId))
                {
                    Console.WriteLine("Product not found");
                    break;
                }

                Console.Write($"New name ({names[modId]}): ");
                names[modId] = Console.ReadLine();

                Console.Write($"New laboratory ({laboratories[modId]}): ");
                laboratories[modId] = Console.ReadLine();

                Console.Write($"New lot ({lots[modId]}): ");
                lots[modId] = Console.ReadLine();

                Console.Write($"New stock ({stocks[modId]}): ");
                stocks[modId] = Convert.ToInt32(Console.ReadLine());

                Console.Write($"New expiration date ({expirations[modId].ToShortDateString()}): ");
                expirations[modId] = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Product updated successfully");
                break;

            case 6:
                if (ids.Count == 0)
                {
                    Console.WriteLine("No products registered");
                    break;
                }

                foreach (int id in ids)
                {
                    Console.WriteLine($"{id}   {names[id]}   {laboratories[id]}");
                }

                Console.Write("Enter product id to delete: ");
                int delId = Convert.ToInt32(Console.ReadLine());

                if (!ids.Contains(delId))
                {
                    Console.WriteLine("Product not found");
                    break;
                }

                Console.Write($"Are you sure you want to delete '{names[delId]}'? 1. Yes 2. No: ");
                int confirm = Convert.ToInt32(Console.ReadLine());

                if (confirm == 1)
                {
                    names.Remove(delId);
                    laboratories.Remove(delId);
                    lots.Remove(delId);
                    stocks.Remove(delId);
                    expirations.Remove(delId);
                    ids.Remove(delId);
                    Console.WriteLine("Product deleted successfully");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled");
                }
                break;

            case 7:
                running = false;
                break;

            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

    Console.ReadKey();
}
catch (Exception)
{
    Console.WriteLine("An error occurred ");
}