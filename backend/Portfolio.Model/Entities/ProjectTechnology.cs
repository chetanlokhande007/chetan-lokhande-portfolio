namespace Portfolio.Model.Entities;

public class ProjectTechnology
{
    // Foreign key to Project
    public int ProjectId { get; set; }

    // Navigation property
    public Project Project { get; set; } = null!;

    // Foreign key to Technology
    public int TechnologyId { get; set; }

    // Navigation property
    public Technology Technology { get; set; } = null!;
}
