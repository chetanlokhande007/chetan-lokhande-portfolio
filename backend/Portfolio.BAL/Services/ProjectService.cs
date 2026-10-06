using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.DAL.Repositories;
using Portfolio.Model.DTOs;
using Portfolio.Model.Entities;

namespace Portfolio.BAL.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(MapToDto);
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        return MapToDto(entity);
    }

    public async Task<ProjectDto?> GetBySlugAsync(string slug)
    {
        var entity = await _repository.GetBySlugAsync(slug);
        if (entity == null) return null;

        return MapToDto(entity);
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto createDto)
    {
        var entity = new Project
        {
            Title = createDto.Title,
            Slug = createDto.Slug,
            ShortDescription = createDto.ShortDescription,
            Description = createDto.Description,
            GithubUrl = createDto.GithubUrl,
            LiveUrl = createDto.LiveUrl,
            ImageUrl = createDto.ImageUrl,
            IsFeatured = createDto.IsFeatured,
            IsPublished = createDto.IsPublished,
            DisplayOrder = createDto.DisplayOrder
        };

        var createdEntity = await _repository.CreateAsync(entity);
        
        if (createDto.TechnologyIds != null && createDto.TechnologyIds.Any())
        {
            await _repository.UpdateProjectTechnologiesAsync(createdEntity.Id, createDto.TechnologyIds);
            createdEntity = await _repository.GetByIdAsync(createdEntity.Id) ?? createdEntity;
        }

        return MapToDto(createdEntity);
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto updateDto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        entity.Title = updateDto.Title;
        entity.Slug = updateDto.Slug;
        entity.ShortDescription = updateDto.ShortDescription;
        entity.Description = updateDto.Description;
        entity.GithubUrl = updateDto.GithubUrl;
        entity.LiveUrl = updateDto.LiveUrl;
        entity.ImageUrl = updateDto.ImageUrl;
        entity.IsFeatured = updateDto.IsFeatured;
        entity.IsPublished = updateDto.IsPublished;
        entity.DisplayOrder = updateDto.DisplayOrder;

        await _repository.UpdateAsync(entity);

        if (updateDto.TechnologyIds != null)
        {
            await _repository.UpdateProjectTechnologiesAsync(id, updateDto.TechnologyIds);
        }

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }

    private static ProjectDto MapToDto(Project entity)
    {
        return new ProjectDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Slug = entity.Slug,
            ShortDescription = entity.ShortDescription,
            Description = entity.Description,
            GithubUrl = entity.GithubUrl,
            LiveUrl = entity.LiveUrl,
            ImageUrl = entity.ImageUrl,
            IsFeatured = entity.IsFeatured,
            IsPublished = entity.IsPublished,
            DisplayOrder = entity.DisplayOrder,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            Technologies = entity.ProjectTechnologies?.Select(pt => new TechnologyDto
            {
                Id = pt.Technology.Id,
                Name = pt.Technology.Name,
                Category = pt.Technology.Category
            }).ToList() ?? new List<TechnologyDto>()
        };
    }
}
