using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModelMatch.Project;

public static class ProjectModuleRegisterService
{
    public static IServiceCollection AddProjectModule(this IServiceCollection services,
        IConfiguration configuration,
        IList<Assembly> assembliesToScan)
    {
        if (assembliesToScan == null)
            throw new ArgumentNullException(nameof(assembliesToScan));



        return services;
    }
}
