namespace Portfolio.Model.Entities;

public class Technology
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // e.g. "Backend", "Frontend", "Database", "DevOps", "Tools"
    public string? Category { get; set; }

    // Navigation property — populated by EF Core when Include() is used
    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; }
        = new List<ProjectTechnology>();
}
