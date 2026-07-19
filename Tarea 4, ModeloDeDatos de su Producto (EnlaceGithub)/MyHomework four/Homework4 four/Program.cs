using Homework4_four_.data;
using Homework4_four_.data.entities;
using Microsoft.EntityFrameworkCore;

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
catch (Exception ex)
{
    Console.WriteLine("An error occurred ");
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.InnerException?.Message);
}

class Pharmacy
{
    private Datacontext context = new Datacontext();

    public void AddLaboratory()
    {
        Console.Write("Enter laboratory name: ");
        string name = Console.ReadLine();
        Console.Write("Enter country: ");
        string country = Console.ReadLine();

        context.Laboratories.Add(new Laboratory { Name = name, Country = country });
        context.SaveChanges();
    }

    public void AddMedication()
    {
        if (!context.Laboratories.Any())
        {
            Console.WriteLine("No laboratories available");
            return;
        }

        ViewLaboratories();
        Console.Write("Enter laboratory id: ");
        int laboratoryId = Convert.ToInt32(Console.ReadLine());
        Laboratory laboratory = context.Laboratories.Find(laboratoryId);

        if (laboratory == null)
        {
            Console.WriteLine("Laboratory not found");
            return;
        }

        Console.Write("Enter medication name: ");
        string name = Console.ReadLine();
        Console.Write("Enter price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        context.Medications.Add(new Medication { Name = name, Price = price, LaboratoryId = laboratoryId });
        context.SaveChanges();
    }

    public void AddBatch()
    {
        if (!context.Medications.Any())
        {
            Console.WriteLine("No medications available");
            return;
        }

        ViewMedications();
        Console.Write("Enter medication id: ");
        int medicationId = Convert.ToInt32(Console.ReadLine());
        Medication medication = context.Medications.Find(medicationId);

        if (medication == null)
        {
            Console.WriteLine("Medication not found");
            return;
        }

        Console.Write("Enter quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter expiration date (yyyy-MM-dd): ");
        DateTime expirationDate = Convert.ToDateTime(Console.ReadLine());

        context.Batches.Add(new Batch { MedicationId = medicationId, Quantity = quantity, ExpirationDate = expirationDate });
        context.SaveChanges();
    }

    public void ViewLaboratories()
    {
        Console.WriteLine("Id   Name   Country");
        Console.WriteLine("-----------------------------");
        foreach (var laboratory in context.Laboratories)
        {
            Console.WriteLine($"{laboratory.Id}    {laboratory.Name}    {laboratory.Country}");
        }
    }

    public void ViewMedications()
    {
        Console.WriteLine("Id   Name   Laboratory   Price");
        Console.WriteLine("-----------------------------------------");
        foreach (var medication in context.Medications.Include(m => m.Laboratory))
        {
            Console.WriteLine($"{medication.Id}    {medication.Name}    {medication.Laboratory.Name}    {medication.Price}");
        }
    }

    public void ViewBatches()
    {
        Console.WriteLine("Id   Medication   Quantity   Expiration");
        Console.WriteLine("-----------------------------------------");
        foreach (var batch in context.Batches.Include(b => b.Medication))
        {
            Console.WriteLine($"{batch.Id}    {batch.Medication.Name}    {batch.Quantity}    {batch.ExpirationDate.ToShortDateString()}");
        }
    }

    public void UpdateStock()
    {
        if (!context.Batches.Any())
        {
            Console.WriteLine("No batches available");
            return;
        }

        ViewBatches();
        Console.Write("Enter batch id: ");
        int batchId = Convert.ToInt32(Console.ReadLine());
        Batch batch = context.Batches.Find(batchId);

        if (batch == null)
        {
            Console.WriteLine("Batch not found");
            return;
        }

        Console.Write("Enter new quantity: ");
        batch.Quantity = Convert.ToInt32(Console.ReadLine());
        context.SaveChanges();
    }

    public void CheckExpired()
    {
        Console.WriteLine("Expired batches:");
        foreach (var batch in context.Batches.Include(b => b.Medication).Where(b => b.ExpirationDate < DateTime.Now))
        {
            Console.WriteLine($"{batch.Id}    {batch.Medication.Name}    {batch.ExpirationDate.ToShortDateString()}");
        }
    }
}
