using Library.BLL.Interfaces;
using Library.BLL.Services;
using Library.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.BLL.DI
{
    public static class BLLServiceCollection
    {
        public static void AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookService, BookService>();

            services.AddDALServices(configuration);
        }
    }
}
