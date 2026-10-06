using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Data;
using Portfolio.Model.Entities;

namespace Portfolio.DAL.Repositories;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly PortfolioDbContext _context;

    public TechnologyRepository(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Technology>> GetAllAsync()
    {
        return await _context.Technologies
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Technology?> GetByIdAsync(int id)
    {
        return await _context.Technologies
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Technology?> GetByNameAsync(string name)
    {
        return await _context.Technologies
            .FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<Technology> CreateAsync(Technology technology)
    {
        await _context.Technologies.AddAsync(technology);
        await _context.SaveChangesAsync();
        return technology;
    }

    public async Task UpdateAsync(Technology technology)
    {
        _context.Technologies.Update(technology);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Technology technology)
    {
        _context.Technologies.Remove(technology);
        await _context.SaveChangesAsync();
    }
}
