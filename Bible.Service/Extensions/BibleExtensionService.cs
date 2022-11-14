using Bible.Database.Data;
using Bible.Service.Interfaces;
using Bible.Service.Services;
using Bible.Service.Services.LanguageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Service.Extensions
{
    public static class BibleExtensionService
    {
        public static IServiceCollection AddBibleServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Default DI
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // Custom DI
            services.AddTransient(typeof(ILanguageService), typeof(LanguageService));

            // Add ConnectionString
            services.AddDbContext<BibleContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));
            return services;
        }
    }
}
