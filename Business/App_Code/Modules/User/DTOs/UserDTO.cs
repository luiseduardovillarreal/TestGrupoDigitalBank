using System;

/// <summary>
/// Descripción breve de UserDTO
/// </summary>
public class UserDTO
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid IdGender { get; set; }
    public string NameGender { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public GenderDTO Gender
    {
        get
        {
            return new GenderDTO()
            {
                Id = IdGender,
                Name = NameGender
            };
        }
    }
}