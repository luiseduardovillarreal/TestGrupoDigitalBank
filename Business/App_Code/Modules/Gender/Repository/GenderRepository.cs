using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de GenderRepository
/// </summary>
public class GenderRepository : IGenderRepository
{
    protected ITestGrupoDigitalBankDbContext _dbContext;
    private readonly IExecuteQuery _executeQuery;

    public GenderRepository(ITestGrupoDigitalBankDbContext dbContext, IExecuteQuery executeQuery)
    {
        _dbContext = dbContext;
        _executeQuery = executeQuery;
    }

    public async Task<string> GetActivesAsync()
    {
        return await _executeQuery.ExecuteSentenceSQL(
            ConfigurationManager.AppSettings[Constants.Repositories.GenderRepository.SP_GET_GENDERS_ACTIVES],
            new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    DbType = DbType.Boolean,
                    ParameterName = Constants.Repositories.GenderRepository.IS_ACTIVE,
                    Direction = ParameterDirection.Input,
                    Value = true
                }
            });
    }
}