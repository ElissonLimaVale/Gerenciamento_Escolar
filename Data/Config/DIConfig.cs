using KissLog;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SGIEscolar.Data.Interface;
using SGIEscolar.Data.Notificacoes;
using SGIEscolar.Data.Repository;
using SGIEscolar.Data.Service;

namespace SGIEscolar.Data.Config
{
    public static class DIConfig
    {
        public static IServiceCollection DIREsolveDependences(this IServiceCollection services)
        {
            // KissLog Dependency Resolve
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped((context) =>  Logger.Factory.Get());
            services.AddLogging(logging => { logging.AddKissLog(); });

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IDapper, BaseDapper>();
            services.AddScoped<AutenticacaoService>();

            // Registro de injeção de dependência das classes
            services.AddScoped<AlunoRepository>();
            services.AddScoped<AlunoService>();
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<TurmaRepository>();
            services.AddScoped<TurmaService>();


            return services;
        }
    }
}
