/// <summary>
/// Descripción breve de UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private ITestGrupoDigitalBankDbContext _dbContext;
    private readonly IExecuteQuery _executeQuery;
    private IGenderRepository _genderRepository;
    private IUserRepository _userRepository;

    public UnitOfWork(ITestGrupoDigitalBankDbContext dbContext, IExecuteQuery executeQuery)
    {
        _dbContext = dbContext;
        _executeQuery = executeQuery;
    }

    public IGenderRepository GenderRepository
    {
        get
        {
            if (_genderRepository == null)
            {
                _genderRepository = new GenderRepository(_dbContext, _executeQuery);
            }

            return _genderRepository;
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_dbContext, _executeQuery);
            }

            return _userRepository;
        }
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (disposing && _dbContext != null)
        {
            ((TestGrupoDigitalBankDbContext)_dbContext).Dispose();
            _dbContext = null;
        }
    }
}