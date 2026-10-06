using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Model.DTOs;

namespace Portfolio.BAL.Services;

public interface ITechnologyService
{
    Task<IEnumerable<TechnologyDto>> GetAllAsync();
    Task<TechnologyDto?> GetByIdAsync(int id);
    Task<TechnologyDto> CreateAsync(CreateTechnologyDto createDto);
    Task<bool> UpdateAsync(int id, UpdateTechnologyDto updateDto);
    Task<bool> DeleteAsync(int id);
}
