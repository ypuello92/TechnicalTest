using TechnicalTest.Aplication.DTO_s;
using TechnicalTest.Aplication.Interface;
using TechnicalTest.Domain.Entities;

namespace TechnicalTest.Aplication.Service
{
    public class CrudRegionService : ICrudRegionService
    {
        public readonly ICrudRegion _region;

        public CrudRegionService(ICrudRegion region)
        {
            _region = region;
        }

        public async Task<RegionReadDTO> CreateRecordAsync (CreateRegionDTO dto, CancellationToken ct)
        {
            var exist = await _region.FindByExternalIdAsync(dto.RecordId, ct);
            if (exist != null)
                throw new InvalidOperationException($"Ya existe una región con ExternalId={dto.RecordId}");

            var entity = new Region
            {
                RecordId = dto.RecordId,
                Name = dto.Name,
                Description = dto.Description
            };

            await _region.AddAsync(entity, ct);
            await _region.SaveChangesAsync(ct);

            return ToReadDto(entity);
        }

        public async Task<List<RegionReadDTO>> GetAllAsync(CancellationToken ct)
        {
            var items = await _region.GetAllAsync(ct);
            return items.Select(ToReadDto).ToList();
        }

        public async Task<RegionReadDTO?> GetByIdAsync(int id, CancellationToken ct)
        {
            var entity = await _region.GetByIdAsync(id, ct);
            return entity is null ? null : ToReadDto(entity);
        }

        public async Task<RegionReadDTO?> GetByExternalIdAsync(int recordId, CancellationToken ct)
        {
            var entity = await _region.FindByExternalIdAsync(recordId, ct);
            return entity is null ? null : ToReadDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, RegionUpdateDTO dto, CancellationToken ct)
        {
            var entity = await _region.GetByIdAsync(id, ct);
            if (entity is null) return false;

            entity.Name = dto.Name;
            entity.Description = dto.Description;

            _region.Update(entity);
            await _region.SaveChangesAsync(ct);

            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var entity = await _region.GetByIdAsync(id, ct);
            if (entity is null) return false;

            _region.Remove(entity);
            await _region.SaveChangesAsync(ct);

            return true;
        }

        private static RegionReadDTO ToReadDto(Region r) => new()
        {
            Id = r.Id,
            RecordId = r.RecordId,
            Name = r.Name,
            Description = r.Description
        };
    }
}
