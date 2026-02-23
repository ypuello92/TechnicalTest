namespace TechnicalTest.Aplication.DTO_s
{
    public class CreateRegionDTO
    {
        public int Id { get; set; }
        public int RecordId { get; set; } // id del registro en el servicio externo
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? Departments { get; set; }
    }
}
