using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Model.DTOs;

public class ProjectDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? GithubUrl { get; set; }
    public string? LiveUrl { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<TechnologyDto> Technologies { get; set; } = new();
}

public class CreateProjectDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Slug is required.")]
    [MaxLength(200, ErrorMessage = "Slug cannot exceed 200 characters.")]
    [RegularExpression(@"^[a-z0-9-]+$", ErrorMessage = "Slug can only contain lowercase letters, numbers, and hyphens.")]
    public string Slug { get; set; } = string.Empty;

    [Required(ErrorMessage = "Short Description is required.")]
    [MaxLength(300, ErrorMessage = "Short Description cannot exceed 300 characters.")]
    public string ShortDescription { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? GithubUrl { get; set; }

    [MaxLength(500)]
    public string? LiveUrl { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public bool IsFeatured { get; set; }
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }

    // List of Technology IDs to associate with this project
    public List<int> TechnologyIds { get; set; } = new();
}

public class UpdateProjectDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Slug is required.")]
    [MaxLength(200, ErrorMessage = "Slug cannot exceed 200 characters.")]
    [RegularExpression(@"^[a-z0-9-]+$", ErrorMessage = "Slug can only contain lowercase letters, numbers, and hyphens.")]
    public string Slug { get; set; } = string.Empty;

    [Required(ErrorMessage = "Short Description is required.")]
    [MaxLength(300, ErrorMessage = "Short Description cannot exceed 300 characters.")]
    public string ShortDescription { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? GithubUrl { get; set; }

    [MaxLength(500)]
    public string? LiveUrl { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    public bool IsFeatured { get; set; }
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }

    public List<int> TechnologyIds { get; set; } = new();
}
