using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Model.Entities;

namespace Portfolio.DAL.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project?> GetBySlugAsync(string slug);
    Task<Project> CreateAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Project project);
    
    // Manage Project Technologies
    Task UpdateProjectTechnologiesAsync(int projectId, IEnumerable<int> technologyIds);
}
