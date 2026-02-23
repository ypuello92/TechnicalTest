using Microsoft.EntityFrameworkCore;
using TechnicalTest.Aplication.Interface;
using TechnicalTest.Domain.Entities;
using TechnicalTest.Infraestructure.Persistence;

namespace TechnicalTest.Infraestructure.Repository
{
    public class CrudRegionRepository : ICrudRegion
    {
        private readonly AppDbContext _context;

        public CrudRegionRepository(AppDbContext context)
        {
            _context = context;
        }

        //agrega registro
        public Task AddAsync(Region region, CancellationToken ct) => _context.Region.AddAsync(region, ct).AsTask();


        //busca regostro
        public async Task<Region?> FindByExternalIdAsync(int id, CancellationToken ct)
        {
            return await _context.Region.AsNoTracking().FirstOrDefaultAsync(x => x.RecordId == id, ct);
        }
        public Task<List<Region>> GetAllAsync(CancellationToken ct)
        => _context.Region.AsNoTracking().OrderBy(x => x.Name).ToListAsync(ct);

        public Task<Region?> GetByIdAsync(int id, CancellationToken ct)
       => _context.Region.FirstOrDefaultAsync(x => x.Id == id, ct);


        //actualiza registro
        public void Update(Region region) => _context.Region.Update(region);

        //elimina registro
        public void Remove(Region region) => _context.Region.Remove(region);

        public Task<int> SaveChangesAsync(CancellationToken ct) => _context.SaveChangesAsync(ct);
    }
}
