namespace Portfolio.Model.Entities;

public class Project
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

    // Navigation property — populated by EF Core when Include() is used
    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; }
        = new List<ProjectTechnology>();
}
