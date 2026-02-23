namespace TechnicalTest.Domain.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public int RecordId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; } 
        public int? Departments { get; set; }
    }
}
