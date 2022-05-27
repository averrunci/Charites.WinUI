using System.Reflection;

using Charites.Windows.Mvc;

using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$;

public static class ServiceExtensions
{
    public static IServiceCollection AddControllers(this IServiceCollection services)
        => typeof(WinUIController).Assembly.DefinedTypes
            .Concat(typeof(ServiceExtensions).Assembly.DefinedTypes)
            .Where(t => t.GetCustomAttributes<ViewAttribute>(true).Any())
            .Aggregate(services, (s, t) => s.AddTransient(t.AsType()));
}