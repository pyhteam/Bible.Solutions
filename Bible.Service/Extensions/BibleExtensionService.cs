using Bible.Database.Data;
using Bible.Service.Interfaces;
using Bible.Service.Services;
using Bible.Service.Services.AudioVerseServices;
using Bible.Service.Services.BookServices;
using Bible.Service.Services.ChapterServices;
using Bible.Service.Services.LanguageServices;
using Bible.Service.Services.SectionServices;
using Bible.Service.Services.VerseServices;
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
            services.AddTransient(typeof(ISectionService), typeof(SectionSerive));
            services.AddTransient(typeof(IBookService), typeof(BookService));
            services.AddTransient(typeof(IChapterService), typeof(ChapterService));
            services.AddTransient(typeof(IVerseService), typeof(VerseService));
            services.AddTransient(typeof(IAudioVerseService), typeof(AudioVerseService));


            // Add ConnectionString
            services.AddDbContext<BibleContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));
            return services;
        }
    }
}
