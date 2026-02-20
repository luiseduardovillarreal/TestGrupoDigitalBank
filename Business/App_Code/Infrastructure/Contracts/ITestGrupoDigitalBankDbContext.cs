using System.Data.Entity;

/// <summary>
/// Descripción breve de ITestGrupoDigitalBankDbContext
/// </summary>
public interface ITestGrupoDigitalBankDbContext
{
    void Dispose();
    int SaveChanges();
    Database Database { get; }
}