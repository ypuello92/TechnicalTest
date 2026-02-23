using Microsoft.EntityFrameworkCore;
using TechnicalTest.Aplication.DTO_s;
using TechnicalTest.Domain.Entities;

namespace TechnicalTest.Aplication.Interface
{
    public interface ICrudRegion
    {
        Task AddAsync(Region region, CancellationToken ct);
        Task<Region?> FindByExternalIdAsync(int id, CancellationToken ct);
        Task<List<Region>> GetAllAsync(CancellationToken ct);
        Task<Region?> GetByIdAsync(int id, CancellationToken ct);

        public void Update(Region region);

        public void Remove(Region region);

        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
