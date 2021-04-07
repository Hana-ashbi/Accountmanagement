using Account.Application.interfaces;
using Account.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Persistence
{
    public static class DependencyInjection
    {
        public static void AddAccountPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountRepo>(opt => opt.UseInMemoryDatabase("UsersDB"));
            services.AddScoped<IAccountRepo>(provider => provider.GetService<AccountRepo>());
        }
    }
}
