using Charites.Windows.Mvc;

using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$;

internal sealed class $safeprojectname$ControllerFactory : IWinUIControllerFactory
{
    private readonly IServiceProvider services = new ServiceCollection()
        .AddControllers()
        .BuildServiceProvider();

    public object Create(Type controllerType) => services.GetRequiredService(controllerType);
}