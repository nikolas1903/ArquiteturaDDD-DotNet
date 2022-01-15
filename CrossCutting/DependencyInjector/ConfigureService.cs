using Domain.Interfaces.Usuario;
using Microsoft.Extensions.DependencyInjection;
using Services.Services.Usuario;

namespace CrossCutting.DependencyInjector
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUsuarioAppService, UsuarioAppService>();
        }
    }
}