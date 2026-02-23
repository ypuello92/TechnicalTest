using TechnicalTest.Aplication.DTO_s;

namespace TechnicalTest.Aplication.Interface
{
    public interface ICrudRegionService
    {
        Task<RegionReadDTO> CreateRecordAsync(CreateRegionDTO dto, CancellationToken ct);
        Task<List<RegionReadDTO>> GetAllAsync(CancellationToken ct);
        Task<RegionReadDTO?> GetByIdAsync(int id, CancellationToken ct);
        Task<RegionReadDTO?> GetByExternalIdAsync(int recordId, CancellationToken ct);
        Task<bool> UpdateAsync(int id, RegionUpdateDTO dto, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}
