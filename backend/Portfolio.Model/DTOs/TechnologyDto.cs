using System.ComponentModel.DataAnnotations;

namespace Portfolio.Model.DTOs;

public class TechnologyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
}

public class CreateTechnologyDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
    public string? Category { get; set; }
}

public class UpdateTechnologyDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
    public string? Category { get; set; }
}
