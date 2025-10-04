using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModelMatch.Clustering;

public static class ClusteringModuleRegisterService
{
    public static IServiceCollection AddMClusteringModule(this IServiceCollection services,
        IConfiguration configuration,
        IList<Assembly> assembliesToScan)
    {
        if (assembliesToScan == null)
            throw new ArgumentNullException(nameof(assembliesToScan));



        return services;
    }
}
