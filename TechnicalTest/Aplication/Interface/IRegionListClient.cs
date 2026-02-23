using TechnicalTest.Aplication.DTO_s;

namespace TechnicalTest.Aplication.Interface
{
    public interface IRegionListClient
    {
        Task<IReadOnlyList<RegionListDTO>> GetRegionListAsync(string? sortBy, string? sortDirection, CancellationToken ct);

        Task<RegionListDTO> GetRegionByIdAsync(int? id, CancellationToken ct);
    }
}
