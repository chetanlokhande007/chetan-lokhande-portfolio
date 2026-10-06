using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.DAL.Repositories;
using Portfolio.Model.DTOs;
using Portfolio.Model.Entities;

namespace Portfolio.BAL.Services;

public class TechnologyService : ITechnologyService
{
    private readonly ITechnologyRepository _repository;

    public TechnologyService(ITechnologyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TechnologyDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(MapToDto);
    }

    public async Task<TechnologyDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;

        return MapToDto(entity);
    }

    public async Task<TechnologyDto> CreateAsync(CreateTechnologyDto createDto)
    {
        var entity = new Technology
        {
            Name = createDto.Name,
            Category = createDto.Category
        };

        var createdEntity = await _repository.CreateAsync(entity);
        return MapToDto(createdEntity);
    }

    public async Task<bool> UpdateAsync(int id, UpdateTechnologyDto updateDto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        entity.Name = updateDto.Name;
        entity.Category = updateDto.Category;

        await _repository.UpdateAsync(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }

    private static TechnologyDto MapToDto(Technology entity)
    {
        return new TechnologyDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Category = entity.Category
        };
    }
}
