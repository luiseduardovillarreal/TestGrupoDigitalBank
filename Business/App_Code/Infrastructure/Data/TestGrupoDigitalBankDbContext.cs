using System.Data.Entity;

/// <summary>
/// Descripción breve de TestGrupoDigitalBankDbContext
/// </summary>
public partial class TestGrupoDigitalBankDbContext : DbContext, ITestGrupoDigitalBankDbContext
{
    public TestGrupoDigitalBankDbContext()
        : base("name=connTestGrupoDigitalBankDbContext")
    {
    }
}