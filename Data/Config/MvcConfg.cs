using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SGIEscolar.Data.Config
{
    public static class MvcConfg
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {                           
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            return services;
        }
    }
}
