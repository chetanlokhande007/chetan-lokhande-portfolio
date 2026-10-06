using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Model.DTOs;

namespace Portfolio.BAL.Services;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllAsync();
    Task<ProjectDto?> GetByIdAsync(int id);
    Task<ProjectDto?> GetBySlugAsync(string slug);
    Task<ProjectDto> CreateAsync(CreateProjectDto createDto);
    Task<bool> UpdateAsync(int id, UpdateProjectDto updateDto);
    Task<bool> DeleteAsync(int id);
}
