using Financa.IoC;

namespace Financa.Api.Setup
{
    public static class DependencyInjection
    {
        public static IServiceCollection InitializeDependencies(this IServiceCollection services)
        {
            return Bootstrapper.InitializeCrossDependencies(services);
        }
    }
}
