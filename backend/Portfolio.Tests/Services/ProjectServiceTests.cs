using System;
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

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockRepo;
    private readonly ProjectService _service;

    public ProjectServiceTests()
    {
        _mockRepo = new Mock<IProjectRepository>();
        _service = new ProjectService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsMappedDtos()
    {
        var mockEntities = new List<Project>
        {
            new Project { Id = 1, Title = "P1", Slug = "p1" }
        };
        _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(mockEntities);

        var result = await _service.GetAllAsync();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("P1", result.First().Title);
    }

    [Fact]
    public async Task GetByIdAsync_WhenExists_ReturnsDto()
    {
        var mockEntity = new Project { Id = 1, Title = "P1" };
        _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(mockEntity);

        var result = await _service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("P1", result.Title);
    }

    [Fact]
    public async Task GetByIdAsync_WhenNotExists_ReturnsNull()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((Project?)null);

        var result = await _service.GetByIdAsync(99);

        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_ReturnsCreatedDto()
    {
        var createDto = new CreateProjectDto { Title = "P1", Slug = "p1", TechnologyIds = new List<int> { 1 } };
        
        _mockRepo.Setup(r => r.CreateAsync(It.IsAny<Project>()))
            .ReturnsAsync((Project p) => 
            {
                p.Id = 2;
                return p;
            });
            
        // We mock the re-fetch to ensure the created entity is returned with relationships populated
        _mockRepo.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(new Project { Id = 2, Title = "P1", Slug = "p1" });

        var result = await _service.CreateAsync(createDto);

        Assert.NotNull(result);
        Assert.Equal(2, result.Id);
        _mockRepo.Verify(r => r.UpdateProjectTechnologiesAsync(2, createDto.TechnologyIds), Times.Once);
    }
}
