/// <summary>
/// Descripción breve de Constants
/// </summary>
public static class Constants
{
    internal static class GenericQuery
    {
        internal static class ExecuteQuery
        {
            internal const string REPORTS = "reports";
            internal const string YOUR_ASSEMBLY = "YourAssembly";
            internal const string YOUR_DYNAMIC_MODULE = "YourDynamicModule";
            internal const string GET_VALUE = "get_value";
            internal const string SET_VALUE = "set_value";
        }
    }

    internal static class Repositories
    {
        internal static class GenderRepository
        {
            internal const string IS_ACTIVE = "isActive";
            internal const string SP_GET_GENDERS_ACTIVES = "SPGetGenders";
        }

        internal static class UserRepository
        {
            internal const string ACTION = "action";
            internal const string IS_ACTIVE = "isActive";
            internal const string ID_USER = "idUser";
            internal const string NAMES = "names";
            internal const string DATE_OF_BIRTH = "dateOfBirth";
            internal const string ID_GENDER = "idGender";
            internal const string POST = "POST";
            internal const string PUT = "PUT";
            internal const string DELETE = "DELETE";
            internal const string GET = "GET";
            internal const string SP_GET_USERS = "SPGetUsers";
            internal const string SP_CRUD_USER = "SPCRUDUser";
        }
    }
}