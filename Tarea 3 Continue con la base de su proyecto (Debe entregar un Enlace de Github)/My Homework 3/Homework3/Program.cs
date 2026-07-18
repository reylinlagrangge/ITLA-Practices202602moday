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

class Laboratory
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Medication
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Laboratory Laboratory { get; set; }
    public double Price { get; set; }
}

class Batch
{
    public int Id { get; set; }
    public Medication Medication { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }
}

class Pharmacy
{
    private List<Laboratory> laboratories = new List<Laboratory>();
    private List<Medication> medications = new List<Medication>();
    private List<Batch> batches = new List<Batch>();
    private int nextLaboratoryId = 1;
    private int nextMedicationId = 1;
    private int nextBatchId = 1;

    public void AddLaboratory()
    {
        Console.Write("Enter laboratory name: ");
        string name = Console.ReadLine();
        Laboratory laboratory = new Laboratory { Id = nextLaboratoryId, Name = name };
        laboratories.Add(laboratory);
        nextLaboratoryId++;
    }

    public void AddMedication()
    {
        if (laboratories.Count == 0)
        {
            Console.WriteLine("No laboratories available");
            return;
        }

        ViewLaboratories();
        Console.Write("Enter laboratory id: ");
        int laboratoryId = Convert.ToInt32(Console.ReadLine());
        Laboratory laboratory = laboratories.Find(l => l.Id == laboratoryId);

        if (laboratory == null)
        {
            Console.WriteLine("Laboratory not found");
            return;
        }

        Console.Write("Enter medication name: ");
        string name = Console.ReadLine();
        Console.Write("Enter price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Medication medication = new Medication { Id = nextMedicationId, Name = name, Laboratory = laboratory, Price = price };
        medications.Add(medication);
        nextMedicationId++;
    }

    public void AddBatch()
    {
        if (medications.Count == 0)
        {
            Console.WriteLine("No medications available");
            return;
        }

        ViewMedications();
        Console.Write("Enter medication id: ");
        int medicationId = Convert.ToInt32(Console.ReadLine());
        Medication medication = medications.Find(m => m.Id == medicationId);

        if (medication == null)
        {
            Console.WriteLine("Medication not found");
            return;
        }

        Console.Write("Enter quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter expiration date (yyyy-MM-dd): ");
        DateTime expirationDate = Convert.ToDateTime(Console.ReadLine());

        Batch batch = new Batch { Id = nextBatchId, Medication = medication, Quantity = quantity, ExpirationDate = expirationDate };
        batches.Add(batch);
        nextBatchId++;
    }

    public void ViewLaboratories()
    {
        Console.WriteLine("Id   Name");
        Console.WriteLine("-----------------------------");
        foreach (var laboratory in laboratories)
        {
            Console.WriteLine($"{laboratory.Id}    {laboratory.Name}");
        }
    }

    public void ViewMedications()
    {
        Console.WriteLine("Id   Name   Laboratory   Price");
        Console.WriteLine("-----------------------------------------");
        foreach (var medication in medications)
        {
            Console.WriteLine($"{medication.Id}    {medication.Name}    {medication.Laboratory.Name}    {medication.Price}");
        }
    }

    public void ViewBatches()
    {
        Console.WriteLine("Id   Medication   Quantity   Expiration");
        Console.WriteLine("-----------------------------------------");
        foreach (var batch in batches)
        {
            Console.WriteLine($"{batch.Id}    {batch.Medication.Name}    {batch.Quantity}    {batch.ExpirationDate.ToShortDateString()}");
        }
    }

    public void UpdateStock()
    {
        if (batches.Count == 0)
        {
            Console.WriteLine("No batches available");
            return;
        }

        ViewBatches();
        Console.Write("Enter batch id: ");
        int batchId = Convert.ToInt32(Console.ReadLine());
        Batch batch = batches.Find(b => b.Id == batchId);

        if (batch == null)
        {
            Console.WriteLine("Batch not found");
            return;
        }

        Console.Write("Enter new quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        batch.Quantity = quantity;
    }

    public void CheckExpired()
    {
        Console.WriteLine("Expired batches:");
        foreach (var batch in batches)
        {
            if (batch.ExpirationDate < DateTime.Now)
            {
                Console.WriteLine($"{batch.Id}    {batch.Medication.Name}    {batch.ExpirationDate.ToShortDateString()}");
            }
        }
    }
}