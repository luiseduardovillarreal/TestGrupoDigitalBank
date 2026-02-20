using System;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de IUserRepository
/// </summary>
public interface IUserRepository
{
    Task<string> DeleteAsync(Guid idUser);
    Task<string> GetAsync();
    Task<string> PostAsync(UserDTO user);
    Task<string> PutAsync(UserDTO user);
}