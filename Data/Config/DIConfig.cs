using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;

namespace SGIEscolar.Data.Config
{
    public static class DIConfig
    {
        public static IServiceCollection DIREsolveDependences(this IServiceCollection services)
        {
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}
