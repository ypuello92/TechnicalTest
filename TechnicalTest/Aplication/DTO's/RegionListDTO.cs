using System.Text.Json.Serialization;

namespace TechnicalTest.Aplication.DTO_s
{
    public sealed record RegionListDTO(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string? Description,
        [property: JsonPropertyName("departments")] int? Departments
    );
}
