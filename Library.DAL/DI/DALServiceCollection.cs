using Library.DAL.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Library.DAL.Interfaces;
using Library.DAL.Repositories;

namespace Library.DAL.DI
{
    public static class DALServiceCollection
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("LibraryConnection")));

            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
