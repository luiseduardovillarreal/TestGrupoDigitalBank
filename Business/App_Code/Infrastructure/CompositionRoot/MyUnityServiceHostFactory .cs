using Unity;
using Unity.Wcf;

/// <summary>
/// Descripción breve de UnityServiceHostFactory
/// </summary>
public class MyUnityServiceHostFactory : UnityServiceHostFactory
{
    protected override void ConfigureContainer(IUnityContainer container)
    {
        UnityConfig.RegisterTypes(container);
    }
}