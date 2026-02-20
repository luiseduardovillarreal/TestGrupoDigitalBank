using System.Threading.Tasks;

/// <summary>
/// Descripción breve de IGenderRepository
/// </summary>
public interface IGenderRepository
{
    Task<string> GetActivesAsync();
}