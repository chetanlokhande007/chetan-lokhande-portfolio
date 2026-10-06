using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Portfolio.BAL.Services;
using Portfolio.DAL.Repositories;
using Portfolio.Model.DTOs;
using Portfolio.Model.Entities;
using Xunit;

namespace Portfolio.Tests.Services;

public class TechnologyServiceTests
{
    private readonly Mock<ITechnologyRepository> _mockRepo;
    private readonly TechnologyService _service;

    public TechnologyServiceTests()
    {
        _mockRepo = new Mock<ITechnologyRepository>();
        _service = new TechnologyService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsMappedDtos()
    {
        // Arrange
        var mockEntities = new List<Technology>
        {
            new Technology { Id = 1, Name = "Angular", Category = "Frontend" },
            new Technology { Id = 2, Name = "C#", Category = "Backend" }
        };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(mockEntities);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Angular", result.First().Name);
    }

    [Fact]
    public async Task GetByIdAsync_WhenExists_ReturnsDto()
    {
        // Arrange
        var mockEntity = new Technology { Id = 1, Name = "Angular" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(mockEntity);

        // Act
        var result = await _service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Angular", result.Name);
    }

    [Fact]
    public async Task GetByIdAsync_WhenNotExists_ReturnsNull()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Technology?)null);

        // Act
        var result = await _service.GetByIdAsync(99);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_ReturnsCreatedDto()
    {
        // Arrange
        var createDto = new CreateTechnologyDto { Name = "React", Category = "Frontend" };
        
        // When repository saves, it returns the entity with an ID.
        _mockRepo.Setup(r => r.CreateAsync(It.IsAny<Technology>()))
            .ReturnsAsync((Technology tech) => 
            {
                tech.Id = 3;
                return tech;
            });

        // Act
        var result = await _service.CreateAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Id);
        Assert.Equal("React", result.Name);
    }

    [Fact]
    public async Task UpdateAsync_WhenNotExists_ReturnsFalse()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Technology?)null);
        var updateDto = new UpdateTechnologyDto { Name = "React" };

        // Act
        var result = await _service.UpdateAsync(99, updateDto);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task DeleteAsync_WhenNotExists_ReturnsFalse()
    {
        // Arrange
        _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Technology?)null);

        // Act
        var result = await _service.DeleteAsync(99);

        // Assert
        Assert.False(result);
    }
}
