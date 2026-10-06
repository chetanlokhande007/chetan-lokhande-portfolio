using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Model.Entities;

namespace Portfolio.DAL.Repositories;

public interface ITechnologyRepository
{
    Task<IEnumerable<Technology>> GetAllAsync();
    Task<Technology?> GetByIdAsync(int id);
    Task<Technology?> GetByNameAsync(string name);
    Task<Technology> CreateAsync(Technology technology);
    Task UpdateAsync(Technology technology);
    Task DeleteAsync(Technology technology);
}
