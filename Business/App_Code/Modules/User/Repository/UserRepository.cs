using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de UserRepository
/// </summary>
public class UserRepository : IUserRepository
{
    protected ITestGrupoDigitalBankDbContext _dbContext;
    private readonly IExecuteQuery _executeQuery;

    public UserRepository(ITestGrupoDigitalBankDbContext dbContext, IExecuteQuery executeQuery)
    {
        _dbContext = dbContext;
        _executeQuery = executeQuery;
    }

    public async Task<string> DeleteAsync(Guid idUser)
    {
        return await _executeQuery.ExecuteSentenceSQL(
            ConfigurationManager.AppSettings[Constants.Repositories.UserRepository.SP_CRUD_USER],
            new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = Constants.Repositories.UserRepository.ACTION,
                    Direction = ParameterDirection.Input,
                    Value = Constants.Repositories.UserRepository.DELETE
                },
                new SqlParameter()
                {
                    DbType = DbType.Guid,
                    ParameterName = Constants.Repositories.UserRepository.ID_USER,
                    Direction = ParameterDirection.Input,
                    Value = idUser
                }
            });
    }

    public async Task<string> GetAsync()
    {
        return await _executeQuery.ExecuteSentenceSQL(
            ConfigurationManager.AppSettings[Constants.Repositories.UserRepository.SP_CRUD_USER],
            new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = Constants.Repositories.UserRepository.ACTION,
                    Direction = ParameterDirection.Input,
                    Value = Constants.Repositories.UserRepository.GET
                },
            });
    }

    public async Task<string> PostAsync(UserDTO user)
    {
        return await _executeQuery.ExecuteSentenceSQL(
            ConfigurationManager.AppSettings[Constants.Repositories.UserRepository.SP_CRUD_USER],
            new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = Constants.Repositories.UserRepository.ACTION,
                    Direction = ParameterDirection.Input,
                    Value = Constants.Repositories.UserRepository.POST
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = Constants.Repositories.UserRepository.NAMES,
                    Direction = ParameterDirection.Input,
                    Value = user.Names
                },
                new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = Constants.Repositories.UserRepository.DATE_OF_BIRTH,
                    Direction = ParameterDirection.Input,
                    Value = user.DateOfBirth
                },
                new SqlParameter()
                {
                    DbType = DbType.Guid,
                    ParameterName = Constants.Repositories.UserRepository.ID_GENDER,
                    Direction = ParameterDirection.Input,
                    Value = user.IdGender
                }
            });
    }

    public async Task<string> PutAsync(UserDTO user)
    {
        return await _executeQuery.ExecuteSentenceSQL(
            ConfigurationManager.AppSettings[Constants.Repositories.UserRepository.SP_CRUD_USER],
            new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = Constants.Repositories.UserRepository.ACTION,
                    Direction = ParameterDirection.Input,
                    Value = Constants.Repositories.UserRepository.PUT
                },
                new SqlParameter()
                {
                    DbType = DbType.Guid,
                    ParameterName = Constants.Repositories.UserRepository.ID_USER,
                    Direction = ParameterDirection.Input,
                    Value = user.Id
                },
                new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = Constants.Repositories.UserRepository.NAMES,
                    Direction = ParameterDirection.Input,
                    Value = user.Names
                },
                new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = Constants.Repositories.UserRepository.DATE_OF_BIRTH,
                    Direction = ParameterDirection.Input,
                    Value = user.DateOfBirth
                },
                new SqlParameter()
                {
                    DbType = DbType.Guid,
                    ParameterName = Constants.Repositories.UserRepository.ID_GENDER,
                    Direction = ParameterDirection.Input,
                    Value = user.IdGender
                }
            });
    }
}