try
{
    Pharmacy pharmacy = new Pharmacy();
    bool running = true;
    while (running)
    {
        Console.WriteLine("1. Add Laboratory");
        Console.WriteLine("2. Add Medication");
        Console.WriteLine("3. Add Batch");
        Console.WriteLine("4. View Medications");
        Console.WriteLine("5. View Batches");
        Console.WriteLine("6. Update Stock");
        Console.WriteLine("7. Check Expired Batches");
        Console.WriteLine("8. Exit");
        Console.Write("Choose an option: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                pharmacy.AddLaboratory();
                break;
            case 2:
                pharmacy.AddMedication();
                break;
            case 3:
                pharmacy.AddBatch();
                break;
            case 4:
                pharmacy.ViewMedications();
                break;
            case 5:
                pharmacy.ViewBatches();
                break;
            case 6:
                pharmacy.UpdateStock();
                break;
            case 7:
                pharmacy.CheckExpired();
                break;
            case 8:
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