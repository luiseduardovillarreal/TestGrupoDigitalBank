using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de IExecuteQuery
/// </summary>
public interface IExecuteQuery
{
    Task<string> ExecuteSentenceSQL(string storedProcedure, List<SqlParameter> parameters);
}