using coreWebAPI.DataBase;
using Microsoft.EntityFrameworkCore;

namespace coreWebAPI.Extensions
{
    public  static class DBContextExtensions
    {

        public static IServiceCollection DBContextExtension<TContext>(this IServiceCollection servicecollection, IConfiguration configuration)
        {
            servicecollection.AddDbContext<SchoolDBContext>(
                options =>
                        {
                            options.UseSqlServer(configuration.GetConnectionString("SchoolDbconnectionString"));
                        }
                );
            return servicecollection;
        }
    }
}
