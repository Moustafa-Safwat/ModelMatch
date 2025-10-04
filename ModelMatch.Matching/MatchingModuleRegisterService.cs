using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModelMatch.Matching;

public static class MatchingModuleRegisterService
{
    public static IServiceCollection AddMatchingModule(this IServiceCollection services,
        IConfiguration configuration,
        IList<Assembly> assembliesToScan)
    {
        if (assembliesToScan == null)
            throw new ArgumentNullException(nameof(assembliesToScan));



        return services;
    }
}
