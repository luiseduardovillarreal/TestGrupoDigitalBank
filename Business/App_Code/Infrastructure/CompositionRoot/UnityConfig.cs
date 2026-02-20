using Unity;
using Unity.Lifetime;

/// <summary>
/// Descripción breve de UnityConfig
/// </summary>
public static class UnityConfig
{
    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<ITestGrupoDigitalBankDbContext, TestGrupoDigitalBankDbContext>(
            new PerResolveLifetimeManager());
        container.RegisterType<IExecuteQuery, ExecuteQuery>(new PerResolveLifetimeManager());
        container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
        container.RegisterType<IGenderService, GenderService>();
        container.RegisterType<IUserService, UserService>();
    }
}