namespace Homework4_four_.data.entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }
        public ICollection<Batch> Batches { get; set; }
    }
}