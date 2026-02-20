namespace Presentation.DTOs;

#pragma warning disable CS8618

public class UserDTO
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderDTO Gender { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}