using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Data;
using Portfolio.Model.Entities;

namespace Portfolio.DAL.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly PortfolioDbContext _context;

    public ProjectRepository(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects
            .Include(p => p.ProjectTechnologies)
            .ThenInclude(pt => pt.Technology)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _context.Projects
            .Include(p => p.ProjectTechnologies)
            .ThenInclude(pt => pt.Technology)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project?> GetBySlugAsync(string slug)
    {
        return await _context.Projects
            .Include(p => p.ProjectTechnologies)
            .ThenInclude(pt => pt.Technology)
            .FirstOrDefaultAsync(p => p.Slug == slug);
    }

    public async Task<Project> CreateAsync(Project project)
    {
        project.CreatedAt = DateTime.UtcNow;
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task UpdateAsync(Project project)
    {
        project.UpdatedAt = DateTime.UtcNow;
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProjectTechnologiesAsync(int projectId, IEnumerable<int> technologyIds)
    {
        var existingRelations = await _context.ProjectTechnologies
            .Where(pt => pt.ProjectId == projectId)
            .ToListAsync();

        _context.ProjectTechnologies.RemoveRange(existingRelations);

        var newRelations = technologyIds.Select(tId => new ProjectTechnology
        {
            ProjectId = projectId,
            TechnologyId = tId
        });

        await _context.ProjectTechnologies.AddRangeAsync(newRelations);
        await _context.SaveChangesAsync();
    }
}
